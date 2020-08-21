using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Frota
{
    public partial class TFCentralGerFrota : Form
    {
        private int month
        { get; set; }
        private decimal totfrete = decimal.Zero;
        private decimal toticms = decimal.Zero;
        private decimal vlcredpres = decimal.Zero;
        private decimal totcomissao = decimal.Zero;
        private decimal totabast = decimal.Zero;
        private decimal totmanut = decimal.Zero;
        private decimal totinfracao = decimal.Zero;
        private decimal totsalario = decimal.Zero;
        private decimal totoutrasreceitas = decimal.Zero;
        private decimal Resultado
        {
            get
            {
                if (lCfg.Count.Equals(decimal.Zero) ? true : (lCfg[0].Tp_recapuracao.Equals("2") || string.IsNullOrEmpty(lCfg[0].Tp_recapuracao)))
                    return totfrete - toticms - totcomissao - totabast - totmanut - totinfracao - totsalario + totoutrasreceitas;
                else if (lCfg[0].Tp_recapuracao.Equals("1"))
                    return totoutrasreceitas - toticms - totcomissao - totabast - totmanut - totinfracao - totsalario;
                else 
                    return totfrete - toticms - totcomissao - totabast - totmanut - totinfracao - totsalario;
            }
        }
        private CamadaDados.Frota.Cadastros.TList_CfgFrota lCfg
        { get; set; }

        private bool Altera_Relatorio = false;

        public TFCentralGerFrota()
        {
            InitializeComponent();
            for (int i = 2010; i < 2050; i++)
                cbxAno.Items.Add(i);
        }

        private void BuscarCTe()
        {
            if (!string.IsNullOrEmpty(id_veiculo.Text) || !string.IsNullOrEmpty(cd_empresa.Text))
            {
                //Buscar CTe
                Utils.TpBusca[] filtro = new Utils.TpBusca[3];
                filtro[0].vNM_Campo = "isnull(a.st_registro, 'A')";
                filtro[0].vOperador = "<>";
                filtro[0].vVL_Busca = "'C'";
                filtro[1].vNM_Campo = "isnull(a.status_cte, '0')";
                filtro[1].vOperador = "=";
                filtro[1].vVL_Busca = "'100'";
                filtro[2].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_emissao)))";
                filtro[2].vOperador = "between";
                filtro[2].vVL_Busca = "'" + new DateTime(int.Parse(cbxAno.Text), month, 1).ToString("yyyyMMdd") + "' and '" +
                                                        new DateTime(int.Parse(cbxAno.Text), month, DateTime.DaysInMonth(int.Parse(cbxAno.Text), month)).ToString("yyyyMMdd") + "'";
                if (!string.IsNullOrEmpty(id_veiculo.Text))
                {
                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[filtro.Length - 1].vNM_Campo = "a.id_veiculo";
                    filtro[filtro.Length - 1].vOperador = "=";
                    filtro[filtro.Length - 1].vVL_Busca = id_veiculo.Text;
                }
                if (!string.IsNullOrEmpty(cd_empresa.Text))
                {
                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                    filtro[filtro.Length - 1].vOperador = "=";
                    filtro[filtro.Length - 1].vVL_Busca = "'" + cd_empresa.Text.Trim() + "'";
                }
                bsCTe.DataSource = new CamadaDados.Faturamento.CTRC.TCD_ConhecimentoFrete().Select(filtro, 0, string.Empty);
                //Totalizar CTe
                //Verificar se veiculo possui Motorista Padrão
                if (!string.IsNullOrEmpty(id_veiculo.Text))
                {
                    CamadaDados.Financeiro.Cadastros.TList_CadClifor lMotorista =
                        new CamadaDados.Financeiro.Cadastros.TCD_CadClifor().Select(
                                new Utils.TpBusca[]
                                {
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = "a.id_veiculo",
                                        vOperador = "=",
                                        vVL_Busca = id_veiculo.Text
                                    }
                                },0, string.Empty);
                    if (lMotorista.Count > 0)
                    {
                        string clifor = string.Empty;
                        string virg = string.Empty;
                        if (lMotorista.Count > 1)
                            virg = ",";
                        lMotorista.ForEach(p => 
                            {
                                clifor += "'" + p.Cd_clifor + "'" + virg ;
                            });
                        clifor = clifor.TrimEnd(',');
                        object tot_sal = new CamadaDados.Financeiro.Duplicata.TCD_LanParcela().BuscarEscalar(
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
                                        vNM_Campo = "a.cd_clifor",
                                        vOperador = "in",
                                        vVL_Busca = "(" + clifor.Trim() + ")"
                                    },
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = "a.tp_mov",
                                        vOperador = "=",
                                        vVL_Busca = "'P'"
                                    }, 
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_emissao)))",
                                        vOperador = "between",
                                        vVL_Busca = "'" + new DateTime(int.Parse(cbxAno.Text), month, 1).ToString("yyyyMMdd") + "' and '" +
                                                        new DateTime(int.Parse(cbxAno.Text), month, DateTime.DaysInMonth(int.Parse(cbxAno.Text), month)).ToString("yyyyMMdd") + "'"
                                    }
                                }, "SUM(a.vl_parcela)");
                        if (tot_sal != null)
                            if (!string.IsNullOrEmpty(tot_sal.ToString()))
                                totsalario = Convert.ToDecimal(tot_sal.ToString());
                            else
                                totsalario = decimal.Zero;
                    }
                }
                else
                {
                    object tot_sal = new CamadaDados.Financeiro.Duplicata.TCD_LanParcela().BuscarEscalar(
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
                                        vNM_Campo = "a.tp_mov",
                                        vOperador = "=",
                                        vVL_Busca = "'P'"
                                    },
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = string.Empty,
                                        vOperador = "exists",
                                        vVL_Busca = "(select 1 from VTB_FIN_CLIFOR x " +
                                                    "where x.cd_clifor = a.cd_clifor " +
                                                    "and x.st_motorista = 'S') "
                                    },
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_emissao)))",
                                        vOperador = "between",
                                        vVL_Busca = "'" + new DateTime(int.Parse(cbxAno.Text), month, 1).ToString("yyyyMMdd") + "' and '" +
                                                        new DateTime(int.Parse(cbxAno.Text), month, DateTime.DaysInMonth(int.Parse(cbxAno.Text), month)).ToString("yyyyMMdd") + "'"
                                    }
                                }, "SUM(a.vl_parcela)");
                    if (tot_sal != null)
                        if (!string.IsNullOrEmpty(tot_sal.ToString()))
                            totsalario = Convert.ToDecimal(tot_sal.ToString());
                        else
                            totsalario = decimal.Zero;
                }
                if (!string.IsNullOrEmpty(id_veiculo.Text))
                {
                    //Buscar Outras Receitas
                    object obj_receita = new CamadaDados.Frota.TCD_OutrasReceitas().BuscarEscalar(
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
                                vNM_Campo = "a.id_veiculo",
                                vOperador = "=",
                                vVL_Busca = id_veiculo.Text
                            },
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_receita)))",
                                vOperador = "between",
                                vVL_Busca = "'" + new DateTime(int.Parse(cbxAno.Text), month, 1).ToString("yyyyMMdd") + "' and '" +
                                                new DateTime(int.Parse(cbxAno.Text), month, DateTime.DaysInMonth(int.Parse(cbxAno.Text), month)).ToString("yyyyMMdd") + "'"
                            }
                        }, "SUM(a.vl_receita)");
                    if (obj_receita != null)
                        if (!string.IsNullOrEmpty(obj_receita.ToString()))
                            totoutrasreceitas = Convert.ToDecimal(obj_receita.ToString());
                        else
                            totoutrasreceitas = decimal.Zero;
                }
                else
                {
                    //Buscar Outras Receitas
                    object obj_receita = new CamadaDados.Frota.TCD_OutrasReceitas().BuscarEscalar(
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
                                vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_receita)))",
                                vOperador = "between",
                                vVL_Busca = "'" + new DateTime(int.Parse(cbxAno.Text), month, 1).ToString("yyyyMMdd") + "' and '" +
                                                new DateTime(int.Parse(cbxAno.Text), month, DateTime.DaysInMonth(int.Parse(cbxAno.Text), month)).ToString("yyyyMMdd") + "'"
                            }
                        }, "SUM(a.vl_receita)");
                    if (obj_receita != null)
                        if (!string.IsNullOrEmpty(obj_receita.ToString()))
                            totoutrasreceitas = Convert.ToDecimal(obj_receita.ToString());
                        else
                            totoutrasreceitas = decimal.Zero;
                }
                totfrete = (bsCTe.List as CamadaDados.Faturamento.CTRC.TList_ConhecimentoFrete).Sum(p => p.Vl_frete);
                toticms = (bsCTe.List as CamadaDados.Faturamento.CTRC.TList_ConhecimentoFrete).Sum(p => p.Vl_ICMS);
                totcomissao = (bsCTe.List as CamadaDados.Faturamento.CTRC.TList_ConhecimentoFrete).Sum(p => p.Vl_comissao) +
                              (bsReceitas.List as CamadaDados.Frota.TList_OutrasReceitas).Sum(p => p.Vl_comissao);
                totFrete.Text = totfrete.ToString("C2", new System.Globalization.CultureInfo("pt-BR"));
                vlCredPres.Text = vlcredpres.ToString("C2", new System.Globalization.CultureInfo("pt-BR"));
                totICMS.Text = toticms.ToString("C2", new System.Globalization.CultureInfo("pt-BR"));
                totFreteLiq.Text = (totfrete - toticms).ToString("C2", new System.Globalization.CultureInfo("pt-BR"));
                totComissao.Text = totcomissao.ToString("C2", new System.Globalization.CultureInfo("pt-BR"));
                totSalario.Text = totsalario.ToString("C2", new System.Globalization.CultureInfo("pt-BR"));
                totOutrasReceitas.Text = totoutrasreceitas.ToString("C2", new System.Globalization.CultureInfo("pt-BR"));
                totResultado.Text = this.Resultado.ToString("C2", new System.Globalization.CultureInfo("pt-BR"));
                if (this.Resultado > decimal.Zero)
                    totResultado.ForeColor = Color.Blue;
                else totResultado.ForeColor = Color.Red;
            }
        }

        private void BuscarManut()
        {
            if (!string.IsNullOrEmpty(id_veiculo.Text) || !string.IsNullOrEmpty(cd_empresa.Text))
            {
                //Buscar Manutencao
                Utils.TpBusca[] filtro = new Utils.TpBusca[1];
                filtro[0].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_realizada)))";
                filtro[0].vOperador = "between";
                filtro[0].vVL_Busca = "'" + new DateTime(int.Parse(cbxAno.Text), month, 1).ToString("yyyyMMdd") + "' and '" +
                                            new DateTime(int.Parse(cbxAno.Text), month, DateTime.DaysInMonth(int.Parse(cbxAno.Text), month)).ToString("yyyyMMdd") + "'";
                if (!string.IsNullOrEmpty(id_veiculo.Text))
                {
                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[filtro.Length - 1].vNM_Campo = "a.id_veiculo";
                    filtro[filtro.Length - 1].vOperador = "=";
                    filtro[filtro.Length - 1].vVL_Busca = id_veiculo.Text;
                }
                if (!string.IsNullOrEmpty(cd_empresa.Text))
                {
                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                    filtro[filtro.Length - 1].vOperador = "=";
                    filtro[filtro.Length - 1].vVL_Busca = "'" + cd_empresa.Text.Trim() + "'";
                }
                bsManutencao.DataSource = new CamadaDados.Frota.Cadastros.TCD_ManutencaoVeiculo().Select(filtro, 0, string.Empty);
                //Somar Manutencao
                totmanut = (bsManutencao.List as CamadaDados.Frota.Cadastros.TList_ManutencaoVeiculo).Sum(p => p.Vl_realizada);
                totManutDesp.Text = totmanut.ToString("C2", new System.Globalization.CultureInfo("pt-BR"));
                totResultado.Text = this.Resultado.ToString("C2", new System.Globalization.CultureInfo("pt-BR"));
                if (this.Resultado > decimal.Zero)
                    totResultado.ForeColor = Color.Blue;
                else totResultado.ForeColor = Color.Red;
            }
        }

        private void BuscarAbast()
        {
            if (!string.IsNullOrEmpty(id_veiculo.Text) || !string.IsNullOrEmpty(cd_empresa.Text))
            {
                Utils.TpBusca[] filtro = new Utils.TpBusca[1];
                filtro[0].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_abastecimento)))";
                filtro[0].vOperador = "between";
                filtro[0].vVL_Busca = "'" + new DateTime(int.Parse(cbxAno.Text), month, 1).ToString("yyyyMMdd") + "' and '" +
                                            new DateTime(int.Parse(cbxAno.Text), month, DateTime.DaysInMonth(int.Parse(cbxAno.Text), month)).ToString("yyyyMMdd") + "'";
                if (!string.IsNullOrEmpty(id_veiculo.Text))
                {
                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[filtro.Length - 1].vNM_Campo = "a.id_veiculo";
                    filtro[filtro.Length - 1].vOperador = "=";
                    filtro[filtro.Length - 1].vVL_Busca = id_veiculo.Text;
                }
                if (!string.IsNullOrEmpty(cd_empresa.Text))
                {
                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                    filtro[filtro.Length - 1].vOperador = "=";
                    filtro[filtro.Length - 1].vVL_Busca = "'" + cd_empresa.Text.Trim() + "'";
                }
                bsAbast.DataSource = new CamadaDados.Frota.TCD_AbastVeiculo().Select(filtro, 0, string.Empty);
                totabast = (bsAbast.List as CamadaDados.Frota.TList_AbastVeiculo).Sum(p => p.Vl_subtotal);
                totCombustivel.Text = totabast.ToString("C2", new System.Globalization.CultureInfo("pt-BR"));
                totResultado.Text = this.Resultado.ToString("C2", new System.Globalization.CultureInfo("pt-BR"));
                if (this.Resultado > decimal.Zero)
                    totResultado.ForeColor = Color.Blue;
                else totResultado.ForeColor = Color.Red;
            }
        }

        private void BuscarInfracoes()
        {
            if (!string.IsNullOrEmpty(id_veiculo.Text) || !string.IsNullOrEmpty(cd_empresa.Text))
            {
                Utils.TpBusca[] filtro = new Utils.TpBusca[1];
                filtro[0].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_infracao)))";
                filtro[0].vOperador = "between";
                filtro[0].vVL_Busca = "'" + new DateTime(int.Parse(cbxAno.Text), month, 1).ToString("yyyyMMdd") + "' and '" +
                                            new DateTime(int.Parse(cbxAno.Text), month, DateTime.DaysInMonth(int.Parse(cbxAno.Text), month)).ToString("yyyyMMdd") + "'";
                if (!string.IsNullOrEmpty(id_veiculo.Text))
                {
                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[filtro.Length - 1].vNM_Campo = "a.id_veiculo";
                    filtro[filtro.Length - 1].vOperador = "=";
                    filtro[filtro.Length - 1].vVL_Busca = id_veiculo.Text;
                }
                if (!string.IsNullOrEmpty(cd_empresa.Text))
                {
                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                    filtro[filtro.Length - 1].vOperador = "=";
                    filtro[filtro.Length - 1].vVL_Busca = "'" + cd_empresa.Text.Trim() + "'";
                }
                bsInfracoes.DataSource = new CamadaDados.Frota.Cadastros.TCD_Infracoes().Select(filtro, 0, string.Empty);
                totinfracao = (bsInfracoes.List as CamadaDados.Frota.Cadastros.TList_Infracoes).Sum(p => p.Vl_infracao);
                totInfracoes.Text = totinfracao.ToString("C2", new System.Globalization.CultureInfo("pt-BR"));
                totResultado.Text = this.Resultado.ToString("C2", new System.Globalization.CultureInfo("pt-BR"));
                if (this.Resultado > decimal.Zero)
                    totResultado.ForeColor = Color.Blue;
                else totResultado.ForeColor = Color.Red;
            }
        }

        private void BuscaOutrasDesp()
        {
            bsReceitas.DataSource =
                CamadaNegocio.Frota.TCN_OutrasReceitas.Buscar(string.Empty,
                                                              cd_empresa.Text,
                                                              string.Empty,
                                                              id_veiculo.Text,
                                                              string.Empty,
                                                              string.Empty,
                                                              new DateTime(int.Parse(cbxAno.Text), month, 1).ToString("dd/MM/yyyy"),
                                                              new DateTime(int.Parse(cbxAno.Text), month, DateTime.DaysInMonth(int.Parse(cbxAno.Text), month)).ToString("dd/MM/yyyy"),
                                                              false,
                                                              null);
            bsReceitas.ResetCurrentItem();
        }


        private void afterBusca()
        {

            this.BuscaOutrasDesp();
            this.BuscarCTe();
            this.BuscarManut();
            this.BuscarAbast();
            this.BuscarInfracoes();
            this.BuscaOutrasDesp();
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
        }

        private void TFCentralGerFrota_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pFiltro.set_FormatZero();
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
        }

        private void bb_veiculo_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_veiculo|Veiculo|200;" +
                              "a.id_veiculo|Codigo|80;" +
                              "a.placa|Placa|80";
            string vParam = "isnull(a.st_registro, 'A')|<>|'I';" +
                            "|EXISTS|(select * from tb_div_tpveiculo x " +
                             "where a.cd_tpveiculo = x.cd_tpveiculo " +
                             "and x.tp_veiculo = 'T')";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { id_veiculo, ds_veiculo, placa },
                new CamadaDados.Frota.Cadastros.TCD_CadVeiculo(),
               vParam);
            this.afterBusca();
        }

        private void id_veiculo_Leave(object sender, EventArgs e)
        {
            string vParam = "a.id_veiculo|=|'" + id_veiculo.Text.Trim() + "';" +
                              "isnull(a.st_registro, 'A')|<>|'I';" +
                              "|EXISTS|(select * from tb_div_tpveiculo x " +
                              "where a.cd_tpveiculo = x.cd_tpveiculo " +
                              "and x.tp_veiculo = 'T')";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { id_veiculo, ds_veiculo, placa },
                                            new CamadaDados.Frota.Cadastros.TCD_CadVeiculo());

            if (string.IsNullOrEmpty(id_veiculo.Text))
            {
                ds_veiculo.Text = string.Empty;
                placa.Text = string.Empty;
            }
            this.afterBusca();
        }

        private void dtPeriodo_ValueChanged(object sender, EventArgs e)
        {
            this.afterBusca();
        }

        private void bbAddManut_Click(object sender, EventArgs e)
        {
            using (TFManutencao fManut = new TFManutencao())
            {
                fManut.vCd_empresa = cd_empresa.Text;
                fManut.vNm_empresa = nm_empresa.Text;
                fManut.vId_veiculo = id_veiculo.Text;
                fManut.vDs_veiculo = ds_veiculo.Text;
                if (fManut.ShowDialog() == DialogResult.OK)
                    if (fManut.rManutencao != null)
                    {
                        if (!fManut.st_consumointerno && !string.IsNullOrEmpty(fManut.rManutencao.Cd_cliforOficina))
                        {
                            //Buscar config abast
                            lCfg =
                                CamadaNegocio.Frota.Cadastros.TCN_CfgFrota.Buscar(fManut.rManutencao.Cd_empresa,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  null);
                            if (!string.IsNullOrEmpty(lCfg[0].Tp_duplicata))
                                using (Financeiro.TFLanDuplicata fDup = new Financeiro.TFLanDuplicata())
                                {
                                    fDup.vCd_empresa = fManut.rManutencao.Cd_empresa;
                                    fDup.vNm_empresa = fManut.rManutencao.Nm_empresa;
                                    fDup.vCd_clifor = fManut.rManutencao.Cd_cliforOficina;
                                    fDup.vNm_clifor = fManut.rManutencao.Nm_cliforOficina;
                                    //Buscar endereco clifor oficina
                                    CamadaDados.Financeiro.Cadastros.TList_CadEndereco lEnd =
                                        CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Buscar(fManut.rManutencao.Cd_cliforOficina,
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
                                                                                                  string.Empty,
                                                                                                  1,
                                                                                                  null);
                                    if (lEnd.Count > 0)
                                    {
                                        fDup.vCd_endereco = lEnd[0].Cd_endereco;
                                        fDup.vDs_endereco = lEnd[0].Ds_endereco;
                                    }
                                    if (lCfg.Count > 0)
                                    {
                                        fDup.vTp_docto = lCfg[0].Tp_doctostr;
                                        fDup.vDs_tpdocto = lCfg[0].Ds_tpdocto;
                                        fDup.vTp_duplicata = lCfg[0].Tp_duplicata;
                                        fDup.vDs_tpduplicata = lCfg[0].Ds_tpduplicata;
                                        fDup.vTp_mov = "P";
                                        fDup.vCd_historico = lCfg[0].Cd_historico;
                                        fDup.vDs_historico = lCfg[0].Ds_historico;
                                        fDup.vDt_emissao = fManut.rManutencao.Dt_realizadastr;
                                        fDup.vVl_documento = fManut.rManutencao.Vl_realizada;
                                        fDup.vNr_docto = fManut.rManutencao.Nr_notafiscal;
                                        fDup.vSt_ecf = true;
                                        if (fDup.ShowDialog() == DialogResult.OK)
                                            if (fDup.dsDuplicata.Count > 0)
                                                fManut.rManutencao.rDup = fDup.dsDuplicata.Current as CamadaDados.Financeiro.Duplicata.TRegistro_LanDuplicata;
                                    }
                                }
                        }
                        try
                        {
                            CamadaNegocio.Frota.Cadastros.TCN_ManutencaoVeiculo.Gravar(fManut.rManutencao, null);

                            MessageBox.Show("Manutenção gravada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.BuscarManut();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    }
            }
        }

        private void bbExcluirManut_Click(object sender, EventArgs e)
        {
            if (bsManutencao.Current != null)
                if (MessageBox.Show("Confirma exclusão da manutenção selecionada?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    == DialogResult.Yes)
                    try
                    {
                        CamadaNegocio.Frota.Cadastros.TCN_ManutencaoVeiculo.Excluir(bsManutencao.Current as CamadaDados.Frota.Cadastros.TRegistro_ManutencaoVeiculo, null);
                        this.BuscarManut();
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void bbAddAbast_Click(object sender, EventArgs e)
        {
            using (TFAbastAvulso fAbast = new TFAbastAvulso())
            {
                fAbast.vCd_empresa = cd_empresa.Text;
                fAbast.vNm_empresa = nm_empresa.Text;
                fAbast.vId_veiculo = id_veiculo.Text;
                fAbast.vDs_veiculo = ds_veiculo.Text;
                if (fAbast.ShowDialog() == DialogResult.OK)
                    if (fAbast.rAbast != null)
                    {
                        if (fAbast.rAbast.Tp_abastecimento.Trim().ToUpper().Equals("T") &&
                            fAbast.rAbast.Tp_pagamento.Trim().ToUpper().Equals("E"))
                        {
                            //Buscar config abast
                           lCfg =
                                CamadaNegocio.Frota.Cadastros.TCN_CfgFrota.Buscar(fAbast.rAbast.Cd_empresa,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  null);
                            using (Financeiro.TFLanDuplicata fDup = new Financeiro.TFLanDuplicata())
                            {
                                fDup.vCd_empresa = fAbast.rAbast.Cd_empresa;
                                fDup.vNm_empresa = fAbast.rAbast.Nm_empresa;
                                fDup.vCd_clifor = fAbast.vCd_clifor;
                                fDup.vNm_clifor = fAbast.rAbast.Nm_fornecedor;
                                fDup.vCd_endereco = fAbast.vCd_endereco;
                                fDup.vDs_endereco = fAbast.vDs_endereco;
                                if (lCfg.Count > 0)
                                {
                                    fDup.vTp_docto = lCfg[0].Tp_doctostr;
                                    fDup.vDs_tpdocto = lCfg[0].Ds_tpdocto;
                                    fDup.vTp_duplicata = lCfg[0].Tp_duplicata;
                                    fDup.vDs_tpduplicata = lCfg[0].Ds_tpduplicata;
                                    fDup.vTp_mov = "P";
                                    fDup.vCd_historico = lCfg[0].Cd_historico;
                                    fDup.vDs_historico = lCfg[0].Ds_historico;
                                    fDup.vDt_emissao = fAbast.rAbast.Dt_abastecimentostr;
                                    fDup.vVl_documento = fAbast.rAbast.Vl_subtotal;
                                    fDup.vNr_docto = fAbast.rAbast.Nr_notafiscal;
                                    fDup.vSt_ecf = true;
                                    if (fDup.ShowDialog() == DialogResult.OK)
                                        if (fDup.dsDuplicata.Count > 0)
                                            fAbast.rAbast.rDup = fDup.dsDuplicata.Current as CamadaDados.Financeiro.Duplicata.TRegistro_LanDuplicata;
                                }
                            }
                        }
                        try
                        {
                            fAbast.rAbast.Tp_captura = "M";
                            fAbast.rAbast.Tp_registro = "A";
                            CamadaNegocio.Frota.TCN_AbastVeiculo.Gravar(fAbast.rAbast, null);
                            MessageBox.Show("Abastecimento gravado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.BuscarAbast();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    }
            }
        }

        private void bbExcluiAbast_Click(object sender, EventArgs e)
        {
            if (bsAbast.Current != null)
                if (MessageBox.Show("Confirma exclusão do abastecimento selecionado?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    try
                    {
                        CamadaNegocio.Frota.TCN_AbastVeiculo.Excluir(bsAbast.Current as CamadaDados.Frota.TRegistro_AbastVeiculo, null);
                        MessageBox.Show("Abastecimento excluido com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.BuscarAbast
                            ();
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void bbAddInfracao_Click(object sender, EventArgs e)
        {
            using (TFInfracoes fInfracao = new TFInfracoes())
            {
                fInfracao.vCd_empresa = cd_empresa.Text;
                fInfracao.vNm_empresa = nm_empresa.Text;
                fInfracao.vId_veiculo = id_veiculo.Text;
                fInfracao.vDs_veiculo = ds_veiculo.Text;
                if (fInfracao.ShowDialog() == DialogResult.OK)
                    if (fInfracao.rInfracoes != null)
                    {
                        //Buscar config abast
                        lCfg =
                            CamadaNegocio.Frota.Cadastros.TCN_CfgFrota.Buscar(fInfracao.rInfracoes.Cd_empresa,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              null);
                        if (!string.IsNullOrEmpty(lCfg[0].Tp_duplicata))
                            using (Financeiro.TFLanDuplicata fDup = new Financeiro.TFLanDuplicata())
                            {
                                fDup.vCd_empresa = fInfracao.rInfracoes.Cd_empresa;
                                fDup.vNm_empresa = fInfracao.rInfracoes.Nm_empresa;
                                if (lCfg.Count > 0)
                                {
                                    fDup.vTp_docto = lCfg[0].Tp_doctostr;
                                    fDup.vDs_tpdocto = lCfg[0].Ds_tpdocto;
                                    fDup.vTp_duplicata = lCfg[0].Tp_duplicata;
                                    fDup.vDs_tpduplicata = lCfg[0].Ds_tpduplicata;
                                    fDup.vTp_mov = "P";
                                    fDup.vCd_historico = lCfg[0].Cd_historico;
                                    fDup.vDs_historico = lCfg[0].Ds_historico;
                                    fDup.vDt_emissao = fInfracao.rInfracoes.Dt_infracaostr;
                                    fDup.vVl_documento = fInfracao.rInfracoes.Vl_infracao;
                                    fDup.vNr_docto = fInfracao.rInfracoes.Cd_infracao;
                                    fDup.vSt_ecf = true;
                                    if (fDup.ShowDialog() == DialogResult.OK)
                                        if (fDup.dsDuplicata.Count > 0)
                                            fInfracao.rInfracoes.rDup = fDup.dsDuplicata.Current as CamadaDados.Financeiro.Duplicata.TRegistro_LanDuplicata;
                                }
                            }
                        try
                        {
                            CamadaNegocio.Frota.Cadastros.TCN_Infracoes.Gravar(fInfracao.rInfracoes, null);
                            MessageBox.Show("Infração gravada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.BuscarInfracoes();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    }
            }
        }

        private void bbExcluiInfracao_Click(object sender, EventArgs e)
        {
            if (bsInfracoes.Current != null)
                if (MessageBox.Show("Confirma exclusão da infração selecionada?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    == DialogResult.Yes)
                    try
                    {
                        CamadaNegocio.Frota.Cadastros.TCN_Infracoes.Excluir(bsInfracoes.Current as CamadaDados.Frota.Cadastros.TRegistro_Infracoes, null);
                        MessageBox.Show("Infração excluida com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.BuscarInfracoes();
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void bb_fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bbAltManut_Click(object sender, EventArgs e)
        {
            if (bsManutencao.Current != null)
            {
                //Verificar se TP.Despesa é Manutenção Interna
                if (new CamadaDados.Frota.Cadastros.TCD_Despesa().BuscarEscalar(
                    new Utils.TpBusca[]
                    {
                        new Utils.TpBusca()
                        {
                            vNM_Campo = "a.id_despesa",
                            vOperador = "=",
                            vVL_Busca = (bsManutencao.Current as CamadaDados.Frota.Cadastros.TRegistro_ManutencaoVeiculo).Id_despesastr
                        },
                        new Utils.TpBusca()
                        {
                            vNM_Campo = "a.TP_Despesa",
                            vOperador = "<>",
                            vVL_Busca = "'MI'"
                        }
                    }, "1") != null)
                {
                    using (TFManutencao fManut = new TFManutencao())
                    {
                        fManut.rManutencao = bsManutencao.Current as CamadaDados.Frota.Cadastros.TRegistro_ManutencaoVeiculo;
                        if (fManut.ShowDialog() == DialogResult.OK)
                            try
                            {
                                CamadaNegocio.Frota.Cadastros.TCN_ManutencaoVeiculo.Gravar(fManut.rManutencao, null);
                                MessageBox.Show("Manutenção alterada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.BuscarManut();
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    }
                }
                else
                    MessageBox.Show("Não é permitido alterar Despesas de Movimentação Interna!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void bbAltAbast_Click(object sender, EventArgs e)
        {
            if (bsAbast.Current != null)
            {
                if ((bsAbast.Current as CamadaDados.Frota.TRegistro_AbastVeiculo).Tp_registro.Trim().ToUpper().Equals("R"))
                    using (TFRequisicao fRequisicao = new TFRequisicao())
                    {
                        fRequisicao.rAbast = bsAbast.Current as CamadaDados.Frota.TRegistro_AbastVeiculo;
                        if (fRequisicao.ShowDialog() == DialogResult.OK)
                            if (fRequisicao.rAbast != null)
                                try
                                {
                                    CamadaNegocio.Frota.TCN_AbastVeiculo.Gravar(fRequisicao.rAbast, null);
                                    MessageBox.Show("Requisição alterada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    this.BuscarAbast();
                                }
                                catch (Exception ex)
                                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    }
                else
                    using (TFAbastAvulso fAbast = new TFAbastAvulso())
                    {
                        fAbast.rAbast = bsAbast.Current as CamadaDados.Frota.TRegistro_AbastVeiculo;
                        if (fAbast.ShowDialog() == DialogResult.OK)
                            if (fAbast.rAbast != null)
                                try
                                {
                                    CamadaNegocio.Frota.TCN_AbastVeiculo.Gravar(fAbast.rAbast, null);
                                    MessageBox.Show("Abastecimento alterado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    this.BuscarAbast();
                                }
                                catch (Exception ex)
                                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    }
            }
        }

        private void bbAltInfracao_Click(object sender, EventArgs e)
        {
            if (bsInfracoes.Current != null)
                using (TFInfracoes fInfracao = new TFInfracoes())
                {
                    fInfracao.rInfracoes = bsInfracoes.Current as CamadaDados.Frota.Cadastros.TRegistro_Infracoes;
                    if (fInfracao.ShowDialog() == DialogResult.OK)
                        if (fInfracao.rInfracoes != null)
                            try
                            {
                                CamadaNegocio.Frota.Cadastros.TCN_Infracoes.Gravar(fInfracao.rInfracoes, null);
                                MessageBox.Show("Infração alterada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.BuscarInfracoes();
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { cd_empresa, nm_empresa }, 
                "|exists|(select 1 from tb_frt_cfgfrota x where x.cd_empresa = a.cd_empresa)");
            //Buscar CFG Transportadora
            lCfg =
                CamadaNegocio.Frota.Cadastros.TCN_CfgFrota.Buscar(cd_empresa.Text,
                                                                    string.Empty,
                                                                    string.Empty,
                                                                    string.Empty,
                                                                    null);
            this.afterBusca();
        }

        private void cd_empresa_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "';|exists|(select 1 from tb_frt_cfgfrota x where x.cd_empresa = a.cd_empresa)", 
                                                    new Componentes.EditDefault[] { cd_empresa, nm_empresa });
            //Buscar CFG Transportadora
            lCfg =
                CamadaNegocio.Frota.Cadastros.TCN_CfgFrota.Buscar(cd_empresa.Text,
                                                                    string.Empty,
                                                                    string.Empty,
                                                                    string.Empty,
                                                                    null);
            this.afterBusca();
        }

        private void bb_imprimir_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(id_veiculo.Text) || !string.IsNullOrEmpty(cd_empresa.Text))
            {
                using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                {
                    FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                    Rel.Altera_Relatorio = Altera_Relatorio;
                    Rel.Nome_Relatorio = this.Name;
                    Rel.NM_Classe = this.Name;
                    Rel.Modulo = this.Tag.ToString().Substring(0, 3);
                    Rel.DTS_Relatorio = bsCTe;
                    Rel.Adiciona_DataSource("DTS_ABAST", bsAbast);
                    Rel.Adiciona_DataSource("DTS_MANUT", bsManutencao);
                    Rel.Adiciona_DataSource("DTS_INFRA", bsInfracoes);
                    //Criar fonte de dados com o resumo
                    DataTable tb_resumo = new DataTable();
                    tb_resumo.Columns.Add("TOT_FRETE", Type.GetType("System.Decimal"));
                    tb_resumo.Columns.Add("TOT_ICMS", Type.GetType("System.Decimal"));
                    tb_resumo.Columns.Add("TOT_FRETELIQ", Type.GetType("System.Decimal"));
                    tb_resumo.Columns.Add("TOT_ABAST", Type.GetType("System.Decimal"));
                    tb_resumo.Columns.Add("TOT_MANUT", Type.GetType("System.Decimal"));
                    tb_resumo.Columns.Add("TOT_INFRA", Type.GetType("System.Decimal"));
                    tb_resumo.Columns.Add("TOT_COMISSAO", Type.GetType("System.Decimal"));
                    tb_resumo.Columns.Add("RESULTADO", Type.GetType("System.Decimal"));
                    DataRow linha = tb_resumo.NewRow();
                    linha["TOT_FRETE"] = totfrete;
                    linha["TOT_ICMS"] = toticms;
                    linha["TOT_FRETELIQ"] = totfrete - toticms;
                    linha["TOT_ABAST"] = totabast;
                    linha["TOT_MANUT"] = totmanut;
                    linha["TOT_INFRA"] = totinfracao;
                    linha["TOT_COMISSAO"] = totcomissao;
                    linha["RESULTADO"] = totfrete - toticms - totcomissao - totabast - totmanut - totinfracao;
                    tb_resumo.Rows.Add(linha);
                    BindingSource bs_resumo = new BindingSource();
                    bs_resumo.DataSource = tb_resumo;
                    Rel.Adiciona_DataSource("DTS_RESUMO", bs_resumo);
                    Rel.Parametros_Relatorio.Add("TRANSPORTADORA", cd_empresa.Text.Trim() + "-" + nm_empresa.Text.Trim());
                    Rel.Parametros_Relatorio.Add("VEICULO", id_veiculo.Text.Trim() + "-" + ds_veiculo.Text.Trim());
                    Rel.Parametros_Relatorio.Add("PERIODO", cbxMes.Text + "/" + cbxAno.Text);
                    Rel.Parametros_Relatorio.Add("PLACA", placa.Text);

                    fImp.St_enabled_enviaremail = true;
                    fImp.pCd_clifor = string.Empty;
                    fImp.pMensagem = "RELATORIO RESULTADO FROTA PERIODO";

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
                                           "RELATORIO RESULTADO FROTA PERIODO",
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
                                               "RELATORIO RESULTADO FROTA PERIODO",
                                               fImp.pDs_mensagem);
                }
            }
            else
                MessageBox.Show("Não existe Registros Para Imprimir o Relatório!");
        }

        private void TFCentralGerFrota_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode.Equals(Keys.P))
            {
                MessageBox.Show("Execute o relatorio que deseja alterar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Altera_Relatorio = true;
            }
        }

        private void bbInserirCotacao_Click(object sender, EventArgs e)
        {
            using (TFOutrasReceitas fReceita = new TFOutrasReceitas())
            {
                if (fReceita.ShowDialog() == DialogResult.OK)
                    if (fReceita.rReceita != null)
                        try
                        {
                            //Lançar Duplicata
                            using (Financeiro.TFLanDuplicata fDup = new Financeiro.TFLanDuplicata())
                            {
                                fDup.vSt_ctrc = true;
                                fDup.vCd_empresa = fReceita.rReceita.Cd_empresa;
                                fDup.vNm_empresa = fReceita.rReceita.Nm_empresa;
                                fDup.vCd_clifor = fReceita.rReceita.Cd_clifor;
                                fDup.vNm_clifor = fReceita.rReceita.Nm_clifor;
                                //Buscar endereco clifor
                                CamadaDados.Financeiro.Cadastros.TList_CadEndereco lEnd =
                                    CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Buscar(fReceita.rReceita.Cd_clifor,
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
                                                                                              string.Empty,
                                                                                              1,
                                                                                              null);
                                if (lEnd.Count > 0)
                                {
                                    fDup.vCd_endereco = lEnd[0].Cd_endereco;
                                    fDup.vDs_endereco = lEnd[0].Ds_endereco;
                                }
                                fDup.vTp_mov = "R";
                                //Buscar TP.Duplicata
                                CamadaDados.Financeiro.Cadastros.TList_CadTpDuplicata lTpDup =
                                   new CamadaDados.Financeiro.Cadastros.TCD_CadTpDuplicata().Select(
                                            new Utils.TpBusca[]
                                            {
                                                new Utils.TpBusca()
                                                {
                                                    vNM_Campo = "a.tp_mov",
                                                    vOperador = "=",
                                                    vVL_Busca = "'R'"
                                                }
                                            }, 1, string.Empty);
                                fDup.vTp_duplicata = lTpDup.Count > 0 ? lTpDup[0].Tp_duplicata : string.Empty;
                                fDup.vDs_tpduplicata = lTpDup.Count > 0 ? lTpDup[0].Ds_tpduplicata : string.Empty;
                                fDup.vDt_emissao = fReceita.rReceita.Dt_receitastr;
                                fDup.vVl_documento = fReceita.rReceita.Vl_receita;
                                fDup.vNr_docto = "RECEITA" + fReceita.rReceita.Dt_receitastr;
                                if (fDup.ShowDialog() == DialogResult.OK)
                                    if (fDup.dsDuplicata.Count > 0)
                                        fReceita.rReceita.rDup = fDup.dsDuplicata.Current as CamadaDados.Financeiro.Duplicata.TRegistro_LanDuplicata;
                                    else
                                    {
                                        MessageBox.Show("Obrigatório gravar Duplicata para lançar receita!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        return;
                                    }
                                else
                                {
                                    MessageBox.Show("Obrigatório gravar Duplicata para lançar receita!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                            }
                            CamadaNegocio.Frota.TCN_OutrasReceitas.Gravar(fReceita.rReceita, null);
                            MessageBox.Show("Receita gravada com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.afterBusca();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void bbExcluirCotacao_Click(object sender, EventArgs e)
        {
            if (bsReceitas.Current != null)
                if (MessageBox.Show("Confirma a exclusão da receita?", "Pergunta",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    try
                    {
                        CamadaNegocio.Frota.TCN_OutrasReceitas.Excluir(bsReceitas.Current as CamadaDados.Frota.TRegistro_OutrasReceitas, null);
                        MessageBox.Show("Receita excluída com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.afterBusca();
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void bb_addsalario_Click(object sender, EventArgs e)
        {
            //Lançar Duplicata
            using (Financeiro.TFLanDuplicata fDup = new Financeiro.TFLanDuplicata())
            {
                fDup.vCd_empresa = !string.IsNullOrEmpty(cd_empresa.Text) ? cd_empresa.Text : string.Empty;
                fDup.vNm_empresa = !string.IsNullOrEmpty(nm_empresa.Text) ? nm_empresa.Text : string.Empty;
                //Verificar se veiculo possui Motorista Padrão
                if (!string.IsNullOrEmpty(id_veiculo.Text))
                {
                    CamadaDados.Financeiro.Cadastros.TList_CadClifor lMotorista =
                        new CamadaDados.Financeiro.Cadastros.TCD_CadClifor().Select(
                                new Utils.TpBusca[]
                                {
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = "a.id_veiculo",
                                        vOperador = "=",
                                        vVL_Busca = id_veiculo.Text
                                    }
                                }, 1, string.Empty);
                    if (lMotorista.Count == 1)
                    {
                        fDup.vCd_clifor = lMotorista[0].Cd_clifor;
                        fDup.vNm_clifor = lMotorista[0].Nm_clifor;

                        //Buscar endereco clifor oficina
                        CamadaDados.Financeiro.Cadastros.TList_CadEndereco lEnd =
                            CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Buscar(lMotorista[0].Cd_clifor,
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
                                                                                      string.Empty,
                                                                                      1,
                                                                                      null);
                        if (lEnd.Count > 0)
                        {
                            fDup.vCd_endereco = lEnd[0].Cd_endereco;
                            fDup.vDs_endereco = lEnd[0].Ds_endereco;
                        }
                    }
                }
                
                fDup.vTp_mov = "P";
                fDup.vNr_docto = "SALARIO" + CamadaDados.UtilData.Data_Servidor().ToString("dd/MM/yyyy");
                if (fDup.ShowDialog() == DialogResult.OK)
                    if (fDup.dsDuplicata.Count > 0)
                        try
                        {
                            CamadaNegocio.Financeiro.Duplicata.TCN_LanDuplicata.GravarDuplicata
                                (fDup.dsDuplicata.Current as CamadaDados.Financeiro.Duplicata.TRegistro_LanDuplicata, false, null);
                            MessageBox.Show("Duplicata gravada com sucesso");
                            this.afterBusca();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }

                    else
                    {
                        MessageBox.Show("Obrigatório gravar Duplicata para lançar receita!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                else
                {
                    MessageBox.Show("Obrigatório gravar Duplicata para lançar receita!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
        }

        private void bb_anterior_Click(object sender, EventArgs e)
        {
            month = month - 1;
            if (month.Equals(0))
            {
                cbxMes.Text = new DateTime(int.Parse(cbxAno.Text) - 1, 12, 01).ToString("MMMM", new System.Globalization.CultureInfo("pt-BR"));
                cbxAno.Text = (int.Parse(cbxAno.Text) - 1).ToString();
            }
            else
                cbxMes.Text = new DateTime(int.Parse(cbxAno.Text), month, 01).ToString("MMMM", new System.Globalization.CultureInfo("pt-BR"));
            this.afterBusca();
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
            this.afterBusca();
        }

        private void cbxMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            BuscarMes();
            this.afterBusca();
        }

        private void cbxAno_SelectedIndexChanged(object sender, EventArgs e)
        {
            BuscarMes();
            this.afterBusca();
        }

    }
}
