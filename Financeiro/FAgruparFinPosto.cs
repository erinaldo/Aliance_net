using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Financeiro
{
    public partial class TFAgruparFinPosto : Form
    {
        private CamadaDados.PostoCombustivel.TList_CartaFrete lCartaFrete
        { get; set; }
        private CamadaDados.Financeiro.Cartao.TList_FaturaCartao lFatura
        { get; set; }
        private CamadaDados.Financeiro.Titulo.TList_RegLanTitulo lCh
        { get; set; }
        private bool Altera_Relatorio = false;
        public bool St_abrirtelahoje
        { get; set; }

        public TFAgruparFinPosto()
        {
            InitializeComponent();
            this.lCartaFrete = new CamadaDados.PostoCombustivel.TList_CartaFrete();
            this.lFatura = new CamadaDados.Financeiro.Cartao.TList_FaturaCartao();
        }

        private void afterBusca()
        {
            bsCliforAgrupar.DataSource = new CamadaDados.Financeiro.Duplicata.TCD_LanParcela().SelectCliforAgrupar(string.Empty);
            tot_agruparClifor.Text = (bsCliforAgrupar.List as CamadaDados.Financeiro.Duplicata.TList_CliforAgrupar).Sum(p => p.Vl_agrupar).ToString("C2", new System.Globalization.CultureInfo("pt-BR"));
            bsCliforAgrupar_PositionChanged(this, new EventArgs());
            this.BuscarOutrosFinanceiros();
        }

        private void BuscarOutrosFinanceiros()
        {
            //Buscar Carta Frete Receber
            lCartaFrete = new CamadaDados.PostoCombustivel.TCD_CartaFrete().Select(
                            new Utils.TpBusca[]
                            {
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_vencimento)))",
                                    vOperador = st_valoresdia.Checked ? "=" : "<=",
                                    vVL_Busca = "convert(datetime, floor(convert(decimal(30,10), getdate())))"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = string.Empty,
                                    vOperador = "exists",
                                    vVL_Busca = "(select 1 from TB_FIN_Parcela x " +
                                                "where x.CD_Empresa = a.CD_Empresa " +
                                                "and x.Nr_Lancto = a.Nr_Lancto " +
                                                "and isnull(x.ST_Registro, 'A') <> 'L')"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = string.Empty,
                                    vOperador = string.Empty,
                                    vVL_Busca = "exists(select 1 from tb_div_usuario_x_empresa u " +
                                                "where u.cd_empresa = a.CD_Empresa " +
                                                "and ((u.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                                "(exists(select 1 from tb_div_usuario_x_grupos g " +
                                                "where g.logingrp = u.login and g.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))"
                                }
                            }, 0, string.Empty);
            lblCartaFrete.Text = lCartaFrete.Sum(p => p.Vl_documento).ToString("C2", new System.Globalization.CultureInfo("pt-BR", true));
            //Buscar Fatura Cartao
            lFatura = new CamadaDados.Financeiro.Cartao.TCD_FaturaCartao().Select(
                        new Utils.TpBusca[]
                        {
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "a.tp_movimento",
                                vOperador = "=",
                                vVL_Busca = "'R'"
                            },
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "vl_nominal - vl_quitado",
                                vOperador = ">",
                                vVL_Busca = "0"
                            },
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_vencto)))",
                                vOperador = st_valoresdia.Checked ? "=" : "<=",
                                vVL_Busca = "convert(datetime, floor(convert(decimal(30,10), getdate())))"
                            },
                            new Utils.TpBusca()
                            {
                                vNM_Campo = string.Empty,
                                vOperador = string.Empty,
                                vVL_Busca = "exists(select 1 from tb_div_usuario_x_empresa u " +
                                            "where u.cd_empresa = a.CD_Empresa " +
                                            "and ((u.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                            "(exists(select 1 from tb_div_usuario_x_grupos g " +
                                            "where g.logingrp = u.login and g.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))"
                            }
                        }, 0, string.Empty, string.Empty);
            lblCartaoCred.Text = lFatura.Where(p => p.Tp_cartao.Trim().ToUpper().Equals("C")).Sum(p => p.Vl_Saldoquitar).ToString("C2", new System.Globalization.CultureInfo("pt-BR", true));
            lblCartaoDeb.Text = lFatura.Where(p => p.Tp_cartao.Trim().ToUpper().Equals("D")).Sum(p => p.Vl_Saldoquitar).ToString("C2", new System.Globalization.CultureInfo("pt-BR", true));
            //Buscar Cheques
            lCh = new CamadaDados.Financeiro.Titulo.TCD_LanTitulo().Select(
                    new Utils.TpBusca[]
                    {
                        new Utils.TpBusca()
                        {
                            vNM_Campo = "isnull(a.status_compensado, 'N')",
                            vOperador = "=",
                            vVL_Busca = "'N'"
                        },
                        new Utils.TpBusca()
                        {
                            vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_vencto)))",
                            vOperador = st_valoresdia.Checked ? "=" : "<=",
                            vVL_Busca = "convert(datetime, floor(convert(decimal(30,10), getdate())))"
                        },
                        new Utils.TpBusca()
                        {
                            vNM_Campo = string.Empty,
                            vOperador = string.Empty,
                            vVL_Busca = "exists(select 1 from tb_div_usuario_x_empresa u " +
                                        "where u.cd_empresa = a.CD_Empresa " +
                                        "and ((u.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                        "(exists(select 1 from tb_div_usuario_x_grupos g " +
                                        "where g.logingrp = u.login and g.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))"
                        }
                    }, 0, string.Empty, string.Empty);
            lblChEmitidos.Text = lCh.Where(p => p.Tp_titulo.Trim().ToUpper().Equals("P")).Sum(p => p.Vl_titulo).ToString("C2", new System.Globalization.CultureInfo("pt-BR", true));
            lblChRecebidos.Text = lCh.Where(p => p.Tp_titulo.Trim().ToUpper().Equals("R")).Sum(p => p.Vl_titulo).ToString("C2", new System.Globalization.CultureInfo("pt-BR", true));
        }

        private void afterPrint(bool st_agrupado, string Nr_lancto)
        {
            if (bsCliforAgrupar.Current != null)
            {
                using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                {
                    FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                    Rel.Altera_Relatorio = Altera_Relatorio;
                    BindingSource bs = new BindingSource();
                    bs.DataSource = new CamadaDados.Financeiro.Duplicata.TList_CliforAgrupar() { bsCliforAgrupar.Current as CamadaDados.Financeiro.Duplicata.TRegistro_CliforAgrupar };
                    Rel.DTS_Relatorio = bs;
                    BindingSource parc = new BindingSource();
                    if (st_agrupado)
                    {
                        //Buscar Parcelas
                        parc.DataSource = new CamadaDados.Financeiro.Duplicata.TCD_LanParcela().Select(
                                        new Utils.TpBusca[]
                                        {
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = string.Empty,
                                                vOperador = "exists",
                                                vVL_Busca = "(select 1 from TB_FIN_VincularDup x " +
                                                            "where x.cd_empresa = a.cd_empresa " +
                                                            "and x.nr_lanctovinculado = a.nr_lancto " +
                                                            "and x.cd_parcelavinculado = a.cd_parcela " + 
                                                            "and x.cd_empresa = '" + (bsCliforAgrupar.Current as CamadaDados.Financeiro.Duplicata.TRegistro_CliforAgrupar).Cd_empresa.Trim() + "' " +
                                                            "and x.nr_lancto = " + Nr_lancto + ")"
                                            }
                                        }, 0, string.Empty, "a.dt_vencto, c.nm_clifor", string.Empty);
                    }
                    else
                        parc.DataSource = (bsParcelas.DataSource as CamadaDados.Financeiro.Duplicata.TList_RegLanParcela).FindAll(p => p.St_processar);
                    Rel.Parametros_Relatorio.Add("VL_AGRUPADO", st_agrupado ? 
                        (parc.DataSource as CamadaDados.Financeiro.Duplicata.TList_RegLanParcela).Sum(p=> p.Vl_liquidado).ToString("C2", new System.Globalization.CultureInfo("pt-BR")) : tot_agrupar.Text);
                    Rel.Adiciona_DataSource("PARCELAS", parc);
                    Rel.Nome_Relatorio = "FAgruparFinPosto";
                    Rel.NM_Classe = this.Name;
                    Rel.Modulo = string.Empty;
                    Rel.Ident = "FAgruparFinPosto";
                    fImp.St_enabled_enviaremail = true;
                    fImp.pCd_clifor = (bsCliforAgrupar.Current as CamadaDados.Financeiro.Duplicata.TRegistro_CliforAgrupar).Cd_clifor;
                    fImp.pMensagem = "AGRUPAMENTO DE DUPLICATA";

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
                                           "AGRUPAMENTO DE DUPLICATA",
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
                                               "AGRUPAMENTO DE DUPLICATA",
                                               fImp.pDs_mensagem);
                }
            }
        }

        private void bsCliforAgrupar_PositionChanged(object sender, EventArgs e)
        {
            if (bsCliforAgrupar.Current != null)
            {
                bsParcelas.DataSource = new CamadaDados.Financeiro.Duplicata.TCD_LanParcela().Select(
                                                new Utils.TpBusca[]
                                                {
                                                    new Utils.TpBusca()
                                                    {
                                                        vNM_Campo = "a.cd_empresa",
                                                        vOperador = "=",
                                                        vVL_Busca = "'" + (bsCliforAgrupar.Current as CamadaDados.Financeiro.Duplicata.TRegistro_CliforAgrupar).Cd_empresa.Trim() + "'"
                                                    },
                                                    new Utils.TpBusca()
                                                    {
                                                        vNM_Campo = "a.cd_clifor",
                                                        vOperador = "=",
                                                        vVL_Busca = "'" + (bsCliforAgrupar.Current as CamadaDados.Financeiro.Duplicata.TRegistro_CliforAgrupar).Cd_clifor + "'"
                                                    },
                                                    new Utils.TpBusca()
                                                    {
                                                        vNM_Campo = "isnull(dup.st_registro, 'A')",
                                                        vOperador = "<>",
                                                        vVL_Busca = "'C'"
                                                    },
                                                    new Utils.TpBusca()
                                                    {
                                                        vNM_Campo = "isnull(a.st_registro, 'A')",
                                                        vOperador = "in",
                                                        vVL_Busca = "('A', 'P')"
                                                    },
                                                    new Utils.TpBusca()
                                                    {
                                                        vNM_Campo = "a.tp_mov",
                                                        vOperador = "=",
                                                        vVL_Busca = "'R'"
                                                    },
                                                    new Utils.TpBusca()
                                                    {
                                                        vNM_Campo = string.Empty,
                                                        vOperador = "not exists",
                                                        vVL_Busca = "(select 1 from TB_FIN_VincularDup x " +
                                                                    "where x.cd_empresa = a.cd_empresa " +
                                                                    "and x.nr_lancto = a.nr_lancto)"
                                                    },
                                                    new Utils.TpBusca()
                                                    {
                                                        vNM_Campo = string.Empty,
                                                        vOperador = "exists",
                                                        vVL_Busca = "(select 1 from TB_PDV_CupomFiscal_X_Duplicata x " +
                                                                    "inner join TB_PDC_VendaCombustivel y " +
                                                                    "on x.CD_Empresa = y.CD_Empresa " +
                                                                    "and x.Id_Cupom = y.Id_Cupom " +
                                                                    "inner join TB_PDC_Convenio_X_Clifor z " +
                                                                    "on y.CD_Empresa = z.CD_Empresa " +
                                                                    "and y.ID_Convenio = z.ID_Convenio " +
                                                                    "and y.CD_Clifor = z.CD_Clifor " +
                                                                    "and y.CD_Endereco = z.CD_Endereco " +
                                                                    "and y.CD_Produto = z.CD_Produto " +
                                                                    "where x.CD_Empresa = a.CD_Empresa " +
                                                                    "and x.Nr_Lancto = a.Nr_Lancto " +
                                                                    "and CONVERT(datetime, floor(convert(decimal(30,10), a.DT_Vencto))) <= convert(datetime, floor(convert(decimal(30,10), getdate()))))"
                                                    }
                                                }, 0, string.Empty, string.Empty, string.Empty);
                (bsParcelas.List as CamadaDados.Financeiro.Duplicata.TList_RegLanParcela).ForEach(p => p.St_processar = true);
                tot_agrupar.Text = (bsParcelas.List as CamadaDados.Financeiro.Duplicata.TList_RegLanParcela).Where(p => p.St_processar).Sum(p => p.Vl_atual).ToString("C2", new System.Globalization.CultureInfo("pt-BR"));
                bb_agrupar.Text = "Agrupar Duplicata (" + (bsParcelas.List as CamadaDados.Financeiro.Duplicata.TList_RegLanParcela).Where(p => p.St_processar).Sum(p => p.Vl_atual).ToString("C2", new System.Globalization.CultureInfo("pt-BR")) + ")";
                //Outras Parcelas
                bsOutrasParcelas.DataSource = new CamadaDados.Financeiro.Duplicata.TCD_LanParcela().Select(
                                                new Utils.TpBusca[]
                                                {
                                                    new Utils.TpBusca()
                                                    {
                                                        vNM_Campo = "a.cd_empresa",
                                                        vOperador = "=",
                                                        vVL_Busca = "'" + (bsCliforAgrupar.Current as CamadaDados.Financeiro.Duplicata.TRegistro_CliforAgrupar).Cd_empresa.Trim() + "'"
                                                    },
                                                    new Utils.TpBusca()
                                                    {
                                                        vNM_Campo = "a.cd_clifor",
                                                        vOperador = "=",
                                                        vVL_Busca = "'" + (bsCliforAgrupar.Current as CamadaDados.Financeiro.Duplicata.TRegistro_CliforAgrupar).Cd_clifor + "'"
                                                    },
                                                    new Utils.TpBusca()
                                                    {
                                                        vNM_Campo = "isnull(dup.st_registro, 'A')",
                                                        vOperador = "<>",
                                                        vVL_Busca = "'C'"
                                                    },
                                                    new Utils.TpBusca()
                                                    {
                                                        vNM_Campo = "isnull(a.st_registro, 'A')",
                                                        vOperador = "in",
                                                        vVL_Busca = "('A', 'P')"
                                                    },
                                                    new Utils.TpBusca()
                                                    {
                                                        vNM_Campo = "a.tp_mov",
                                                        vOperador = "=",
                                                        vVL_Busca = "'R'"
                                                    },
                                                    new Utils.TpBusca()
                                                    {
                                                        vNM_Campo = string.Empty,
                                                        vOperador = "not exists",
                                                        vVL_Busca = "(select 1 from TB_FIN_VincularDup x " +
                                                                    "where x.cd_empresa = a.cd_empresa " +
                                                                    "and x.nr_lancto = a.nr_lancto)"
                                                    },
                                                    new Utils.TpBusca()
                                                    {
                                                        vNM_Campo = string.Empty,
                                                        vOperador = "not exists",
                                                        vVL_Busca = "(select 1 from TB_PDV_CupomFiscal_X_Duplicata x " +
                                                                    "inner join TB_PDC_VendaCombustivel y " +
                                                                    "on x.CD_Empresa = y.CD_Empresa " +
                                                                    "and x.Id_Cupom = y.Id_Cupom " +
                                                                    "inner join TB_PDC_Convenio_X_Clifor z " +
                                                                    "on y.CD_Empresa = z.CD_Empresa " +
                                                                    "and y.ID_Convenio = z.ID_Convenio " +
                                                                    "and y.CD_Clifor = z.CD_Clifor " +
                                                                    "and y.CD_Endereco = z.CD_Endereco " +
                                                                    "and y.CD_Produto = z.CD_Produto " +
                                                                    "where x.CD_Empresa = a.CD_Empresa " +
                                                                    "and x.Nr_Lancto = a.Nr_Lancto)"
                                                    }
                                                }, 0, string.Empty, string.Empty, string.Empty);
                (bsOutrasParcelas.List as CamadaDados.Financeiro.Duplicata.TList_RegLanParcela).ForEach(p => p.St_processar = !p.Nr_docto.Contains("EMP"));
                tslOutrasDup.Text = (bsOutrasParcelas.List as CamadaDados.Financeiro.Duplicata.TList_RegLanParcela).Where(p => p.St_processar).Sum(p => p.Vl_atual).ToString("C2", new System.Globalization.CultureInfo("pt-BR"));
                bb_agrupar.Text = "Agrupar Duplicata (" + ((bsParcelas.List as CamadaDados.Financeiro.Duplicata.TList_RegLanParcela).Where(p => p.St_processar).Sum(p => p.Vl_atual) +
                                                           (bsOutrasParcelas.List as CamadaDados.Financeiro.Duplicata.TList_RegLanParcela).Where(p=> p.St_processar).Sum(p=> p.Vl_atual)).ToString("C2", new System.Globalization.CultureInfo("pt-BR")) + ")";
            }
            else
                bsParcelas.Clear();
        }

        private void TFAgruparFinPosto_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            st_abrirtelahoje.Visible = this.St_abrirtelahoje;
            this.afterBusca();
        }

        private void gParcelas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.ColumnIndex == 0) && (bsParcelas.Current != null))
            {
                (bsParcelas.Current as CamadaDados.Financeiro.Duplicata.TRegistro_LanParcela).St_processar =
                    !(bsParcelas.Current as CamadaDados.Financeiro.Duplicata.TRegistro_LanParcela).St_processar;
                bsParcelas.ResetCurrentItem();
                tot_agrupar.Text = (bsParcelas.List as CamadaDados.Financeiro.Duplicata.TList_RegLanParcela).Where(p => p.St_processar).Sum(p => p.Vl_atual).ToString("C2", new System.Globalization.CultureInfo("pt-BR"));
                bb_agrupar.Text = ((bsParcelas.List as CamadaDados.Financeiro.Duplicata.TList_RegLanParcela).Where(p => p.St_processar).Sum(p => p.Vl_atual) +
                    bsOutrasParcelas.Count > 0 ? (bsOutrasParcelas.List as CamadaDados.Financeiro.Duplicata.TList_RegLanParcela).Where(p => p.St_processar).Sum(p => p.Vl_atual) : decimal.Zero).ToString("C2", new System.Globalization.CultureInfo("pt-BR"));
            }
        }

        private void bb_agrupar_Click(object sender, EventArgs e)
        {
            if (bsParcelas.Count > 0)
            {
                List<CamadaDados.Financeiro.Duplicata.TRegistro_LanParcela> lParc =
                (bsParcelas.List as CamadaDados.Financeiro.Duplicata.TList_RegLanParcela).FindAll(p => p.St_processar);
                if (bsOutrasParcelas.Count > 0)
                    (bsOutrasParcelas.List as CamadaDados.Financeiro.Duplicata.TList_RegLanParcela).FindAll(p => p.St_processar).ForEach(p => lParc.Add(p));
                if (lParc.Count > 0)
                {
                    //Verificar se convenio possui dados para emitir duplicata
                    CamadaDados.PostoCombustivel.TRegistro_Convenio rConv =
                        CamadaNegocio.PostoCombustivel.TCN_Convenio.Buscar((bsCliforAgrupar.Current as CamadaDados.Financeiro.Duplicata.TRegistro_CliforAgrupar).Id_convenio.Value.ToString(),
                                                                           (bsCliforAgrupar.Current as CamadaDados.Financeiro.Duplicata.TRegistro_CliforAgrupar).Cd_empresa,
                                                                           string.Empty,
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
                                                                           null)[0];
                    if ((!string.IsNullOrEmpty(rConv.Tp_duplicata)) &&
                        rConv.Tp_docto.HasValue)
                    {
                        //Gerar Duplicata
                        CamadaDados.Financeiro.Duplicata.TRegistro_LanDuplicata rDup = new CamadaDados.Financeiro.Duplicata.TRegistro_LanDuplicata();
                        rDup.Cd_empresa = (bsCliforAgrupar.Current as CamadaDados.Financeiro.Duplicata.TRegistro_CliforAgrupar).Cd_empresa;
                        rDup.Nm_empresa = (bsCliforAgrupar.Current as CamadaDados.Financeiro.Duplicata.TRegistro_CliforAgrupar).Nm_empresa;
                        rDup.Tp_duplicata = rConv.Tp_duplicata;
                        rDup.Ds_tpduplicata = rConv.Ds_tpduplicata;
                        rDup.Tp_mov = rConv.Tp_movduplicata;
                        rDup.Cd_historico = rConv.Cd_historicodup;
                        rDup.Ds_historico = rConv.Ds_historicodup;
                        rDup.Tp_docto = rConv.Tp_docto;
                        rDup.Ds_tpdocto = rConv.Ds_tpdocto;
                        rDup.Tp_mov = "R";
                        rDup.Cd_clifor = (bsCliforAgrupar.Current as CamadaDados.Financeiro.Duplicata.TRegistro_CliforAgrupar).Cd_clifor;
                        rDup.Nm_clifor = (bsCliforAgrupar.Current as CamadaDados.Financeiro.Duplicata.TRegistro_CliforAgrupar).Nm_clifor;
                        rDup.Cd_endereco = (bsCliforAgrupar.Current as CamadaDados.Financeiro.Duplicata.TRegistro_CliforAgrupar).Cd_endereco;
                        //Buscar condição pagamento
                        CamadaDados.Financeiro.Cadastros.TRegistro_CadCondPgto rCond =
                            CamadaNegocio.Financeiro.Cadastros.TCN_CadCondPgto.Buscar((bsCliforAgrupar.Current as CamadaDados.Financeiro.Duplicata.TRegistro_CliforAgrupar).Cd_condpgto,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      decimal.Zero,
                                                                                      decimal.Zero,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      1,
                                                                                      string.Empty,
                                                                                      null)[0];
                        rDup.Cd_juro = rCond.Cd_juro;
                        rDup.Cd_moeda = !string.IsNullOrEmpty(rCond.Cd_moeda) ? rCond.Cd_moeda :
                            CamadaNegocio.ConfigGer.TCN_CadParamGer.BuscaVL_String_Empresa("CD_MOEDA_PADRAO", (bsCliforAgrupar.Current as CamadaDados.Financeiro.Duplicata.TRegistro_CliforAgrupar).Cd_empresa, null);
                        rDup.Cd_condpgto = rCond.Cd_condpgto;
                        rDup.Ds_condpgto = rCond.Ds_condpgto;
                        rDup.Qt_dias_desdobro = rCond.Qt_diasdesdobro;
                        rDup.Qt_parcelas = rCond.Qt_parcelas;
                        rDup.Nr_docto = "AGPCONV" + rConv.Id_conveniostr;
                        rDup.Vl_documento = (bsParcelas.List as CamadaDados.Financeiro.Duplicata.TList_RegLanParcela).Where(p => p.St_processar).Sum(p => p.cVl_atual) +
                            (bsOutrasParcelas.Count > 0 ? (bsOutrasParcelas.List as CamadaDados.Financeiro.Duplicata.TList_RegLanParcela).Where(p => p.St_processar).Sum(p => p.cVl_atual) : decimal.Zero);
                        rDup.Vl_documento_padrao = (bsParcelas.List as CamadaDados.Financeiro.Duplicata.TList_RegLanParcela).Where(p => p.St_processar).Sum(p => p.cVl_atual) +
                            (bsOutrasParcelas.Count > 0 ? (bsOutrasParcelas.List as CamadaDados.Financeiro.Duplicata.TList_RegLanParcela).Where(p => p.St_processar).Sum(p => p.cVl_atual) : decimal.Zero);
                        rDup.Dt_emissao = CamadaDados.UtilData.Data_Servidor();
                        rDup.Qt_parcelas = rCond.Qt_parcelas;
                        rDup.Qt_dias_desdobro = rCond.Qt_diasdesdobro;
                        rDup.St_comentrada = rCond.St_comentrada;
                        rDup.Tp_juro = rCond.Tp_juro;
                        rDup.Pc_jurodiario_atrazo = rCond.Pc_jurodiario_atrazo;
                        rDup.St_registro = "A";
                        rDup.Id_configBoleto = (bsCliforAgrupar.Current as CamadaDados.Financeiro.Duplicata.TRegistro_CliforAgrupar).Id_configBoleto.HasValue ?
                            (bsCliforAgrupar.Current as CamadaDados.Financeiro.Duplicata.TRegistro_CliforAgrupar).Id_configBoleto : rConv.Id_config_boleto;
                        rDup.Ds_configboleto = (bsCliforAgrupar.Current as CamadaDados.Financeiro.Duplicata.TRegistro_CliforAgrupar).Id_configBoleto.HasValue ?
                            (bsCliforAgrupar.Current as CamadaDados.Financeiro.Duplicata.TRegistro_CliforAgrupar).Ds_condigBoleto : rConv.Ds_config_boleto;
                        rDup.Parcelas = CamadaNegocio.Financeiro.Duplicata.TCN_LanDuplicata.calcularParcelas(rDup, null);
                        using (TFDuplicataAgrup fDup = new TFDuplicataAgrup())
                        {
                            fDup.rDup = rDup;
                            if(fDup.ShowDialog() == DialogResult.OK)
                                if(fDup.rDup != null)
                                    try
                                    {
                                        string ret = CamadaNegocio.Financeiro.Duplicata.TCN_LanDuplicata.AgruparDuplicata(fDup.rDup,
                                                                                                                          lParc,
                                                                                                                          decimal.Zero,
                                                                                                                          decimal.Zero,
                                                                                                                          null);
                                        if (!string.IsNullOrEmpty(ret))
                                        {
                                            string lan = CamadaDados.TDataQuery.getPubVariavel(ret, "@P_NR_LANCTO");

                                            MessageBox.Show("Lançamento Financeiro nr:" + lan + " Gravado com Sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            //Imprimir Boleto
                                            CamadaDados.Financeiro.Bloqueto.blListaTitulo lBloqueto =
                                                CamadaNegocio.Financeiro.Bloqueto.TCN_Titulo.Buscar(fDup.rDup.Cd_empresa,
                                                                                                    (lan.Trim() != string.Empty ? Convert.ToDecimal(lan) : decimal.Zero),
                                                                                                    decimal.Zero,
                                                                                                    decimal.Zero,
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
                                                                                                    string.Empty,
                                                                                                    string.Empty,
                                                                                                    string.Empty,
                                                                                                    string.Empty,
                                                                                                    string.Empty,
                                                                                                    string.Empty,
                                                                                                    string.Empty,
                                                                                                    string.Empty,
                                                                                                    string.Empty,
                                                                                                    false,
                                                                                                    0,
                                                                                                    null);
                                            if (lBloqueto.Count > 0)
                                                //Chamar tela de impressao para o bloqueto
                                                using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                                                {
                                                    fImp.St_enabled_enviaremail = true;
                                                    fImp.pCd_clifor = fDup.rDup.Cd_clifor;
                                                    fImp.pMensagem = "BLOQUETOS DO DOCUMENTO Nº" + fDup.rDup.Nr_docto;
                                                    if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                                                        FormRelPadrao.TCN_LayoutBloqueto.Imprime_Bloqueto(false,
                                                                                                          lBloqueto,
                                                                                                          fImp.pSt_imprimir,
                                                                                                          fImp.pSt_visualizar,
                                                                                                          fImp.pSt_enviaremail,
                                                                                                          fImp.pSt_exportPdf,
                                                                                                          fImp.Path_exportPdf,
                                                                                                          fImp.pDestinatarios,
                                                                                                          "BLOQUETO(S) DO DOCUMENTO Nº " + fDup.rDup.Nr_docto,
                                                                                                          fImp.pDs_mensagem,
                                                                                                          false);
                                                }
                                            //Imprimir Duplicata
                                            if (fDup.rDup.Tp_mov.Trim().ToUpper().Equals("R"))
                                            {
                                                if (new CamadaDados.Financeiro.Cadastros.TCD_CadTpDoctoDup().BuscarEscalar(
                                                        new Utils.TpBusca[]
                                                                {
                                                                    new Utils.TpBusca()
                                                                    {
                                                                        vNM_Campo = "a.tp_docto",
                                                                        vOperador = "=",
                                                                        vVL_Busca = fDup.rDup.Tp_doctostring
                                                                    },
                                                                    new Utils.TpBusca()
                                                                    {
                                                                        vNM_Campo = "isnull(a.st_duplicata, 'N')",
                                                                        vOperador = "=",
                                                                        vVL_Busca = "'S'"
                                                                    }
                                                                }, "1") != null)
                                                {
                                                    //Chamar tela de impressao duplicata
                                                    using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                                                    {
                                                        fImp.St_enabled_enviaremail = true;
                                                        fImp.pCd_clifor = fDup.rDup.Cd_clifor;
                                                        fImp.pMensagem = "DUPLICATAS DO DOCUMENTO Nº" + fDup.rDup.Nr_docto;
                                                        if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                                                            FormRelPadrao.TCN_LayoutDuplicata.Imprime_Duplicata(false,
                                                                                                                fDup.rDup.Parcelas,
                                                                                                                null,
                                                                                                                null,
                                                                                                                fImp.pSt_imprimir,
                                                                                                                fImp.pSt_visualizar,
                                                                                                                fImp.pSt_exportPdf,
                                                                                                                fImp.Path_exportPdf,
                                                                                                                fImp.pSt_enviaremail,
                                                                                                                fImp.pDestinatarios,
                                                                                                                "DUPLICATAS(S) DO DOCUMENTO Nº " + fDup.rDup.Nr_docto,
                                                                                                                fImp.pDs_mensagem);
                                                    }
                                                }
                                            }
                                            this.afterPrint(true, lan);
                                            this.afterBusca();
                                        }
                                    }
                                    catch (Exception ex)
                                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                        }
                    }
                    else
                        using (TFLanDuplicata fDuplicata = new TFLanDuplicata())
                        {
                            fDuplicata.vSt_agrupar = true;
                            fDuplicata.vCd_empresa = lParc[0].Cd_empresa;
                            fDuplicata.vNm_empresa = lParc[0].Nm_empresa;
                            fDuplicata.vCd_clifor = lParc[0].Cd_clifor;
                            fDuplicata.vNm_clifor = lParc[0].Nm_clifor;
                            fDuplicata.vCd_endereco = lParc[0].Cd_endereco;
                            fDuplicata.vTp_duplicata = lParc[0].Tp_duplicata;
                            fDuplicata.vTp_mov = lParc[0].Tp_mov;
                            fDuplicata.vVl_documento = lParc.Sum(p => p.cVl_atual);
                            if (fDuplicata.ShowDialog() == DialogResult.OK)
                                if (fDuplicata.dsDuplicata.Count > 0)
                                    try
                                    {
                                        string ret = CamadaNegocio.Financeiro.Duplicata.TCN_LanDuplicata.AgruparDuplicata(fDuplicata.dsDuplicata.Current as CamadaDados.Financeiro.Duplicata.TRegistro_LanDuplicata,
                                                                                                                          lParc,
                                                                                                                          decimal.Zero,
                                                                                                                          decimal.Zero,
                                                                                                                          null);
                                        if (!string.IsNullOrEmpty(ret))
                                        {
                                            string lan = CamadaDados.TDataQuery.getPubVariavel(ret, "@P_NR_LANCTO");

                                            MessageBox.Show("Lançamento Financeiro nr:" + lan + " Gravado com Sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            //Imprimir Boleto
                                            CamadaDados.Financeiro.Bloqueto.blListaTitulo lBloqueto =
                                                CamadaNegocio.Financeiro.Bloqueto.TCN_Titulo.Buscar((fDuplicata.dsDuplicata.Current as CamadaDados.Financeiro.Duplicata.TRegistro_LanDuplicata).Cd_empresa,
                                                                                                    (lan.Trim() != string.Empty ? Convert.ToDecimal(lan) : decimal.Zero),
                                                                                                    decimal.Zero,
                                                                                                    decimal.Zero,
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
                                                                                                    string.Empty,
                                                                                                    string.Empty,
                                                                                                    string.Empty,
                                                                                                    string.Empty,
                                                                                                    string.Empty,
                                                                                                    string.Empty,
                                                                                                    string.Empty,
                                                                                                    string.Empty,
                                                                                                    string.Empty,
                                                                                                    false,
                                                                                                    0,
                                                                                                    null);
                                            if (lBloqueto.Count > 0)
                                                //Chamar tela de impressao para o bloqueto
                                                using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                                                {
                                                    fImp.St_enabled_enviaremail = true;
                                                    fImp.pCd_clifor = (fDuplicata.dsDuplicata.Current as CamadaDados.Financeiro.Duplicata.TRegistro_LanDuplicata).Cd_clifor;
                                                    fImp.pMensagem = "BLOQUETOS DO DOCUMENTO Nº" + (fDuplicata.dsDuplicata.Current as CamadaDados.Financeiro.Duplicata.TRegistro_LanDuplicata).Nr_docto;
                                                    if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                                                        FormRelPadrao.TCN_LayoutBloqueto.Imprime_Bloqueto(false,
                                                                                                          lBloqueto,
                                                                                                          fImp.pSt_imprimir,
                                                                                                          fImp.pSt_visualizar,
                                                                                                          fImp.pSt_enviaremail,
                                                                                                          fImp.pSt_exportPdf,
                                                                                                          fImp.Path_exportPdf,
                                                                                                          fImp.pDestinatarios,
                                                                                                          "BLOQUETO(S) DO DOCUMENTO Nº " + (fDuplicata.dsDuplicata.Current as CamadaDados.Financeiro.Duplicata.TRegistro_LanDuplicata).Nr_docto,
                                                                                                          fImp.pDs_mensagem,
                                                                                                          false);
                                                }
                                            //Imprimir Duplicata
                                            if ((fDuplicata.dsDuplicata.Current as CamadaDados.Financeiro.Duplicata.TRegistro_LanDuplicata).Tp_mov.Trim().ToUpper().Equals("R"))
                                            {
                                                object obj = new CamadaDados.Financeiro.Cadastros.TCD_CadTpDoctoDup().BuscarEscalar(
                                                                new Utils.TpBusca[]
                                                                {
                                                                    new Utils.TpBusca()
                                                                    {
                                                                        vNM_Campo = "a.tp_docto",
                                                                        vOperador = "=",
                                                                        vVL_Busca = (fDuplicata.dsDuplicata.Current as CamadaDados.Financeiro.Duplicata.TRegistro_LanDuplicata).Tp_doctostring
                                                                    },
                                                                    new Utils.TpBusca()
                                                                    {
                                                                        vNM_Campo = "isnull(a.st_duplicata, 'N')",
                                                                        vOperador = "=",
                                                                        vVL_Busca = "'S'"
                                                                    }
                                                                }, "1");
                                                if (obj != null)
                                                {
                                                    //Chamar tela de impressao duplicata
                                                    using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                                                    {
                                                        fImp.St_enabled_enviaremail = true;
                                                        fImp.pCd_clifor = (fDuplicata.dsDuplicata.Current as CamadaDados.Financeiro.Duplicata.TRegistro_LanDuplicata).Cd_clifor;
                                                        fImp.pMensagem = "DUPLICATAS DO DOCUMENTO Nº" + (fDuplicata.dsDuplicata.Current as CamadaDados.Financeiro.Duplicata.TRegistro_LanDuplicata).Nr_docto;
                                                        if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                                                            FormRelPadrao.TCN_LayoutDuplicata.Imprime_Duplicata(false,
                                                                                                                (fDuplicata.dsDuplicata.Current as CamadaDados.Financeiro.Duplicata.TRegistro_LanDuplicata).Parcelas,
                                                                                                                null,
                                                                                                                null,
                                                                                                                fImp.pSt_imprimir,
                                                                                                                fImp.pSt_visualizar,
                                                                                                                fImp.pSt_exportPdf,
                                                                                                                fImp.Path_exportPdf,
                                                                                                                fImp.pSt_enviaremail,
                                                                                                                fImp.pDestinatarios,
                                                                                                                "DUPLICATAS(S) DO DOCUMENTO Nº " + (fDuplicata.dsDuplicata.Current as CamadaDados.Financeiro.Duplicata.TRegistro_LanDuplicata).Nr_docto,
                                                                                                                fImp.pDs_mensagem);
                                                    }
                                                }
                                            }
                                            afterPrint(true, lan);
                                            afterBusca();
                                        }
                                    }
                                    catch (Exception ex)
                                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                        }
                }
            }
        }

        private void st_abrirtelahoje_Click(object sender, EventArgs e)
        {
            Utils.SettingsUtils.Default.ST_DESATIVAFINPOSTO = st_abrirtelahoje.Checked ? "S" : "N";
            Utils.SettingsUtils.Default.Save();
        }

        private void bb_buscar_Click(object sender, EventArgs e)
        {
            afterBusca();
        }

        private void TFAgruparFinPosto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F7))
                afterBusca();
            else if (e.Control && e.KeyCode.Equals(Keys.P))
            {
                Altera_Relatorio = true;
                MessageBox.Show("Selecione o relatorio para alterar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void gCliforAgrupar_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gCliforAgrupar.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsCliforAgrupar.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new CamadaDados.Financeiro.Duplicata.TRegistro_CliforAgrupar());
            CamadaDados.Financeiro.Duplicata.TList_CliforAgrupar lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gCliforAgrupar.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gCliforAgrupar.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new CamadaDados.Financeiro.Duplicata.TList_CliforAgrupar(lP.Find(gCliforAgrupar.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gCliforAgrupar.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new CamadaDados.Financeiro.Duplicata.TList_CliforAgrupar(lP.Find(gCliforAgrupar.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gCliforAgrupar.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsCliforAgrupar.List as CamadaDados.Financeiro.Duplicata.TList_CliforAgrupar).Sort(lComparer);
            bsCliforAgrupar.ResetBindings(false);
            gCliforAgrupar.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void bb_cliforNegativado_Click(object sender, EventArgs e)
        {
            using (TFListaCliforInadimplente fClifor = new TFListaCliforInadimplente())
            {
                fClifor.ShowDialog();
            }
        }

        private void bb_visualizarConvenio_Click(object sender, EventArgs e)
        {
            if (bsCliforAgrupar.Current != null)
            {
                using (TFVisualizarConvenio fVisualizar = new TFVisualizarConvenio())
                {
                    fVisualizar.Id_convenio = (bsCliforAgrupar.Current as CamadaDados.Financeiro.Duplicata.TRegistro_CliforAgrupar).Id_convenio.ToString();
                    fVisualizar.Cd_empresa = (bsCliforAgrupar.Current as CamadaDados.Financeiro.Duplicata.TRegistro_CliforAgrupar).Cd_empresa;
                    fVisualizar.ShowDialog();
                }
            }
        }

        private void bb_impDuplicata_Click(object sender, EventArgs e)
        {
            this.afterPrint(false, string.Empty);
        }

        private void lblCartaFrete_MouseEnter(object sender, EventArgs e)
        {
            lblCartaFrete.ForeColor = Color.Blue;
        }

        private void lblCartaFrete_MouseLeave(object sender, EventArgs e)
        {
            lblCartaFrete.ForeColor = Color.Maroon;
        }

        private void lblCartaoDeb_MouseEnter(object sender, EventArgs e)
        {
            lblCartaoDeb.ForeColor = Color.Blue;
        }

        private void lblCartaoDeb_MouseLeave(object sender, EventArgs e)
        {
            lblCartaoDeb.ForeColor = Color.Maroon;
        }

        private void lblCartaoCred_MouseEnter(object sender, EventArgs e)
        {
            lblCartaoCred.ForeColor = Color.Blue;
        }

        private void lblCartaoCred_MouseLeave(object sender, EventArgs e)
        {
            lblCartaoCred.ForeColor = Color.Maroon;
        }

        private void lblChEmitidos_MouseEnter(object sender, EventArgs e)
        {
            lblChEmitidos.ForeColor = Color.Blue;
        }

        private void lblChEmitidos_MouseLeave(object sender, EventArgs e)
        {
            lblChEmitidos.ForeColor = Color.Maroon;
        }

        private void lblChRecebidos_MouseEnter(object sender, EventArgs e)
        {
            lblChRecebidos.ForeColor = Color.Blue;
        }

        private void lblChRecebidos_MouseLeave(object sender, EventArgs e)
        {
            lblChRecebidos.ForeColor = Color.Maroon;
        }

        private void lblCartaFrete_Click(object sender, EventArgs e)
        {
            if (lCartaFrete.Count > 0)
                using (TFVisualizarCFReceber fVisualizar = new TFVisualizarCFReceber())
                {
                    fVisualizar.lCartaFrete = lCartaFrete;
                    fVisualizar.ShowDialog();
                }
            else MessageBox.Show("Não existe carta frete para visualizar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void lblCartaoDeb_Click(object sender, EventArgs e)
        {
            if (lFatura.Exists(p => p.Tp_cartao.Trim().ToUpper().Equals("D") && p.Vl_Saldoquitar > decimal.Zero))
                using (TFVisualizarCartao fVisualizar = new TFVisualizarCartao())
                {
                    fVisualizar.St_debito = true;
                    fVisualizar.lFatura = lFatura.FindAll(p => p.Tp_cartao.Trim().ToUpper().Equals("D"));
                    fVisualizar.ShowDialog();
                }
            else MessageBox.Show("Não existe fatura DÉBITO para visualizar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void lblCartaoCred_Click(object sender, EventArgs e)
        {
            if (lFatura.Exists(p => p.Tp_cartao.Trim().ToUpper().Equals("D") && p.Vl_Saldoquitar > decimal.Zero))
                using (TFVisualizarCartao fVisualizar = new TFVisualizarCartao())
                {
                    fVisualizar.St_debito = false;
                    fVisualizar.lFatura = lFatura.FindAll(p => p.Tp_cartao.Trim().ToUpper().Equals("C"));
                    fVisualizar.ShowDialog();
                }
            else MessageBox.Show("Não existe fatura CRÉDITO para visualizar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void lblChEmitidos_Click(object sender, EventArgs e)
        {
            if(lCh.Exists(p=> p.Tp_titulo.Trim().ToUpper().Equals("P")))
                using(TFVisualizaCheques fVisualizar = new TFVisualizaCheques())
                {
                    fVisualizar.St_emitido = true;
                    fVisualizar.lCh = lCh.FindAll(p => p.Tp_titulo.Trim().ToUpper().Equals("P"));
                    fVisualizar.ShowDialog();
                }
            else MessageBox.Show("Não existe cheques EMITIDOS para visualizar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void lblChRecebidos_Click(object sender, EventArgs e)
        {
            if (lCh.Exists(p => p.Tp_titulo.Trim().ToUpper().Equals("R")))
                using (TFVisualizaCheques fVisualizar = new TFVisualizaCheques())
                {
                    fVisualizar.St_emitido = false;
                    fVisualizar.lCh = lCh.FindAll(p => p.Tp_titulo.Trim().ToUpper().Equals("R"));
                    fVisualizar.ShowDialog();
                }
            else MessageBox.Show("Não existe cheques RECEBIDOS para visualizar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void st_valoresdia_Click(object sender, EventArgs e)
        {
            this.BuscarOutrosFinanceiros();
        }

        private void gOutrasParcelas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.ColumnIndex == 0) && (bsOutrasParcelas.Current != null))
            {
                (bsOutrasParcelas.Current as CamadaDados.Financeiro.Duplicata.TRegistro_LanParcela).St_processar =
                    !(bsOutrasParcelas.Current as CamadaDados.Financeiro.Duplicata.TRegistro_LanParcela).St_processar;
                bsOutrasParcelas.ResetCurrentItem();
                tslOutrasDup.Text = (bsOutrasParcelas.List as CamadaDados.Financeiro.Duplicata.TList_RegLanParcela).Where(p => p.St_processar).Sum(p => p.Vl_atual).ToString("C2", new System.Globalization.CultureInfo("pt-BR"));
                bb_agrupar.Text = "Agrupar Duplicatas (" + ((bsOutrasParcelas.List as CamadaDados.Financeiro.Duplicata.TList_RegLanParcela).Where(p => p.St_processar).Sum(p => p.Vl_atual) +
                    (bsParcelas.Count > 0 ? (bsParcelas.List as CamadaDados.Financeiro.Duplicata.TList_RegLanParcela).Where(p => p.St_processar).Sum(p => p.Vl_atual) : decimal.Zero)).ToString("C2", new System.Globalization.CultureInfo("pt-BR")) + ")";
            }
        }
    }
}
