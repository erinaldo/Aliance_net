using CamadaDados.Diversos;
using CamadaDados.Financeiro.Cadastros;
using CamadaNegocio.ConfigGer;
using CamadaNegocio.Diversos;
using CamadaNegocio.Financeiro.Cadastros;
using Financeiro;
using FormRelPadrao;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Utils;

namespace Locacao
{
    public partial class TFItensFaturar : Form
    {
        private int month
        { get; set; }
        private decimal Id_config
        { get; set; }
        public TFItensFaturar()
        {
            InitializeComponent();
            for (int i = 2013; i < 2050; i++)
                cbxAno.Items.Add(i);
            Height = Screen.PrimaryScreen.Bounds.Height - (Screen.PrimaryScreen.Bounds.Height / 10) * 1;
            Width = Screen.PrimaryScreen.Bounds.Width - (Screen.PrimaryScreen.Bounds.Width / 10) * 1;
        }

        private void afterFaturar(bool st_boleto)
        {
            if (bsParcela.Current != null)
            {
                if (!(bsParcela.DataSource as CamadaDados.Locacao.TList_ParcelaLocacao).Exists(p => p.St_processar))
                {
                    MessageBox.Show("Obrigatório selecionar parcelas!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (MessageBox.Show("Deseja faturar parcelas selecionadas?", "Mensagem", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    == DialogResult.Yes)
                {
                    //Buscar CFG.Banco
                    object obj = new CamadaDados.Locacao.Cadastros.TCD_CFGLocacao().BuscarEscalar(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.cd_empresa",
                                            vOperador = "=",
                                            vVL_Busca = "'" + (bsParcela.Current as CamadaDados.Locacao.TRegistro_ParcelaLocacao).Cd_empresa.Trim() + "'"
                                        }
                                    }, "a.id_config");
                    if (obj != null)
                        Id_config = Convert.ToDecimal(obj.ToString());

                    (bsParcela.DataSource as CamadaDados.Locacao.TList_ParcelaLocacao).Where(p => p.St_processar).ToList().ForEach(p =>
                    {
                        CamadaDados.Locacao.TList_Locacao lLocacao =
                            new CamadaDados.Locacao.TCD_Locacao().Select(
                                new TpBusca[]
                                {
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.cd_empresa",
                                        vOperador = "=",
                                        vVL_Busca = "'" + p.Cd_empresa.Trim() + "'"
                                    },
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.id_locacao",
                                        vOperador = "=",
                                        vVL_Busca = p.Id_locacaostr
                                    }
                                }, 1, string.Empty, string.Empty);

                        CamadaDados.Financeiro.Duplicata.TRegistro_LanDuplicata rDup = new CamadaDados.Financeiro.Duplicata.TRegistro_LanDuplicata();
                        CamadaDados.Locacao.Cadastros.TList_CFGLocacao lParam = new CamadaDados.Locacao.Cadastros.TList_CFGLocacao();
                        lParam = CamadaNegocio.Locacao.Cadastros.TCN_CFGLocacao.buscar(p.Cd_empresa, string.Empty, null);
                        rDup.Cd_empresa = p.Cd_empresa;
                        rDup.Nm_empresa = p.Nm_empresa;
                        rDup.Cd_clifor = p.Cd_clifor;
                        rDup.Nm_clifor = p.Nm_clifor;
                        rDup.Cd_endereco = p.Cd_endereco;
                        rDup.Ds_endereco = p.Ds_endereco;
                        if (lParam.Count > 0)
                        {
                            rDup.Tp_docto = lParam[0].Tp_docto;
                            rDup.Ds_tpdocto = lParam[0].Ds_tpdocto;
                            rDup.Tp_duplicata = lParam[0].Tp_duplicata;
                            rDup.Ds_tpduplicata = lParam[0].Ds_tpduplicata;
                            rDup.Tp_mov = "R";
                            rDup.Cd_historico = lParam[0].Cd_historico;
                            rDup.Ds_historico = lParam[0].Ds_historico;
                            if (TCN_CadParamGer.BuscaVL_Bool("CRESULTADO_EMPRESA", rDup.Cd_empresa, null).Trim().ToUpper().Equals("S"))
                            {
                                if (lLocacao[0].Tp_tabela.Equals("5"))
                                    if (!string.IsNullOrEmpty(lParam[0].Cd_centroresultsem))
                                        rDup.lCustoLancto.Add(new CamadaDados.Financeiro.CCustoLan.TRegistro_LanCCustoLancto()
                                        {
                                            Cd_empresa = p.Cd_empresa,
                                            Cd_centroresult = lParam[0].Cd_centroresultsem,
                                            Vl_lancto = p.Vl_parcela,
                                            Dt_lancto = CamadaDados.UtilData.Data_Servidor(),
                                            Tp_registro = "A"
                                        });
                                    else
                                        using (TFRateioCResultado fRateio = new TFRateioCResultado())
                                        {
                                            fRateio.vVl_Documento = p.Vl_parcela;
                                            fRateio.Tp_mov = rDup.Tp_mov;
                                            fRateio.Dt_movimento = rDup.Dt_emissao;
                                            if (fRateio.ShowDialog() == DialogResult.OK)
                                                rDup.lCustoLancto = fRateio.lCResultado;
                                        }
                                else if (lLocacao[0].Tp_tabela.Equals("6"))
                                    if (!string.IsNullOrEmpty(lParam[0].Cd_centroresultquinz))
                                        rDup.lCustoLancto.Add(new CamadaDados.Financeiro.CCustoLan.TRegistro_LanCCustoLancto()
                                        {
                                            Cd_empresa = p.Cd_empresa,
                                            Cd_centroresult = lParam[0].Cd_centroresultquinz,
                                            Vl_lancto = p.Vl_parcela,
                                            Dt_lancto = CamadaDados.UtilData.Data_Servidor(),
                                            Tp_registro = "A"
                                        });
                                    else
                                        using (TFRateioCResultado fRateio = new TFRateioCResultado())
                                        {
                                            fRateio.vVl_Documento = p.Vl_parcela;
                                            fRateio.Tp_mov = rDup.Tp_mov;
                                            fRateio.Dt_movimento = rDup.Dt_emissao;
                                            if (fRateio.ShowDialog() == DialogResult.OK)
                                                rDup.lCustoLancto = fRateio.lCResultado;
                                        }
                                else if (lLocacao[0].Tp_tabela.Equals("4"))
                                    if (!string.IsNullOrEmpty(lParam[0].Cd_centroresultmes))
                                        rDup.lCustoLancto.Add(new CamadaDados.Financeiro.CCustoLan.TRegistro_LanCCustoLancto()
                                        {
                                            Cd_empresa = p.Cd_empresa,
                                            Cd_centroresult = lParam[0].Cd_centroresultmes,
                                            Vl_lancto = p.Vl_parcela,
                                            Dt_lancto = CamadaDados.UtilData.Data_Servidor(),
                                            Tp_registro = "A"
                                        });
                                    else
                                        using (TFRateioCResultado fRateio = new TFRateioCResultado())
                                        {
                                            fRateio.vVl_Documento = p.Vl_parcela;
                                            fRateio.Tp_mov = rDup.Tp_mov;
                                            fRateio.Dt_movimento = rDup.Dt_emissao;
                                            if (fRateio.ShowDialog() == DialogResult.OK)
                                                rDup.lCustoLancto = fRateio.lCResultado;
                                        }
                                else if (!string.IsNullOrEmpty(lParam[0].Cd_centroresultdia))
                                    rDup.lCustoLancto.Add(new CamadaDados.Financeiro.CCustoLan.TRegistro_LanCCustoLancto()
                                    {
                                        Cd_empresa = p.Cd_empresa,
                                        Cd_centroresult = lParam[0].Cd_centroresultdia,
                                        Vl_lancto = p.Vl_parcela,
                                        Dt_lancto = CamadaDados.UtilData.Data_Servidor(),
                                        Tp_registro = "A"
                                    });
                                else
                                    using (TFRateioCResultado fRateio = new TFRateioCResultado())
                                    {
                                        fRateio.vVl_Documento = p.Vl_parcela;
                                        fRateio.Tp_mov = rDup.Tp_mov;
                                        fRateio.Dt_movimento = rDup.Dt_emissao;
                                        if (fRateio.ShowDialog() == DialogResult.OK)
                                            rDup.lCustoLancto = fRateio.lCResultado;
                                    }
                            }
                            //Buscar Moeda Padrao
                            TList_Moeda tabela = TCN_CadParamGer_X_Empresa.BuscarMoedaPadrao(p.Cd_empresa, null);
                            if (tabela != null)
                                if (tabela.Count > 0)
                                {
                                    rDup.Cd_moeda = tabela[0].Cd_moeda;
                                    rDup.Ds_moeda = tabela[0].Ds_moeda_singular;
                                    rDup.Sigla_moeda = tabela[0].Sigla;
                                    rDup.DupCotacao = new CamadaDados.Financeiro.Duplicata.TRegistro_DuplicataCotacao
                                    {
                                        Cd_empresa = rDup.Cd_empresa,
                                        Cd_moeda = rDup.Cd_moeda,
                                        Cd_moedaresult = rDup.Cd_moeda,
                                        Vl_cotacao = 1,
                                        Operador = "*"
                                    };
                                }
                            decimal vl_devolver = decimal.Zero;
                            //Verificar vl.devolver no adiantamento da locação
                            if (lLocacao[0].Vl_entrada > decimal.Zero)
                            {
                                CamadaDados.Financeiro.Adiantamento.TList_LanAdiantamento lCred =
                                    new CamadaDados.Financeiro.Adiantamento.TCD_LanAdiantamento().Select(
                                        new TpBusca[]
                                        {
                                            new TpBusca()
                                            {
                                                vNM_Campo = "a.cd_empresa",
                                                vOperador = "=",
                                                vVL_Busca = "'" + p.Cd_empresa.Trim() + "'"
                                            },
                                            new TpBusca()
                                            {
                                                vNM_Campo = string.Empty,
                                                vOperador = "exists",
                                                vVL_Busca = "(select 1 from TB_LOC_AdtoLocacao x " +
                                                            "where x.Id_adto = a.Id_adto " +
                                                            "and x.id_locacao = " + p.Id_locacaostr + " " +
                                                            "and x.cd_empresa = '" + p.Cd_empresa.Trim() + "') "
                                            }
                                        }, 0, string.Empty);
                                if (lCred.Count > 0)
                                {
                                    vl_devolver = lCred.Sum(x => x.Vl_total_devolver);
                                    rDup.lCred = lCred;
                                }
                            }
                            if (st_boleto && vl_devolver < p.Vl_parcela)
                                rDup.Id_configBoleto = Id_config;
                            rDup.cVl_adiantamento = vl_devolver;
                            rDup.Vl_documento = p.Vl_parcela;
                            rDup.Vl_documento_padrao = p.Vl_parcela;
                            rDup.Ds_observacao = "LOCAÇÃO MENSAL REFERENTE AO MÊS " + p.Dt_vencto.AddMonths(-1).ToString("MM/yyyy");
                            DateTime dt_servidor = CamadaDados.UtilData.Data_Servidor();
                            rDup.Dt_emissao = p.Dt_vencto.Date > dt_servidor.Date ? dt_servidor : p.Dt_vencto;
                            rDup.Nr_docto = "LOC" + p.Id_locacaostr + "-" +
                               p.Dt_vencto.AddMonths(-1).ToString("MM/yyyy");
                            //Buscar cond pagamento
                            TList_CadCondPgto lCond = TCN_CadCondPgto.Buscar(string.Empty,
                                                                             string.Empty,
                                                                             string.Empty,
                                                                             string.Empty,
                                                                             string.Empty,
                                                                             string.Empty,
                                                                             1,
                                                                             decimal.Zero,
                                                                             string.Empty,
                                                                             string.Empty,
                                                                             1,
                                                                             string.Empty,
                                                                             null);
                            if (lCond.Count > 0)
                            {
                                rDup.Cd_condpgto = lCond[0].Cd_condpgto;
                                rDup.Qt_parcelas = lCond[0].Qt_parcelas;
                                rDup.Qt_dias_desdobro = lCond[0].Qt_diasdesdobro;
                                rDup.St_comentrada = lCond[0].St_comentrada;
                                rDup.Cd_juro = lCond[0].Cd_juro;
                                rDup.Tp_juro = lCond[0].Tp_juro;
                                rDup.Pc_jurodiario_atrazo = lCond[0].Pc_jurodiario_atrazo;
                            }
                            rDup.Parcelas.Add(new CamadaDados.Financeiro.Duplicata.TRegistro_LanParcela()
                            {
                                Cd_parcela = 1,
                                Dt_vencto = p.Dt_vencto,
                                Vl_parcela = p.Vl_parcela,
                                Vl_parcela_padrao = p.Vl_parcela
                            });
                            try
                            {
                                lLocacao[0].lParc.Add(p);
                                lLocacao[0].lDup.Add(rDup);
                                CamadaNegocio.Locacao.TCN_Locacao.GravaDuplicata(lLocacao[0], null);
                                
                                #region Emissão de recibo
                                if (MessageBox.Show("Locação mensal faturada com sucesso!\n Deseja emitir recibo?", "Mensagem", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                                    == DialogResult.Yes)
                                {
                                    using (TFGerenciadorImpressao fImp = new TFGerenciadorImpressao())
                                    {
                                        Relatorio Rel = new Relatorio();
                                        Rel.Altera_Relatorio = false;
                                        BindingSource bs_valor = new BindingSource();
                                        bs_valor.DataSource = new CamadaDados.Financeiro.Duplicata.TList_RegLanDuplicata { rDup as CamadaDados.Financeiro.Duplicata.TRegistro_LanDuplicata };
                                        Rel.DTS_Relatorio = bs_valor;
                                        Rel.Ident = "RECIBO_LOCACAO";
                                        Rel.NM_Classe = "TFLanLocacao_Parcelas";
                                        Rel.Modulo = "LOC";
                                        fImp.St_enabled_enviaremail = true;
                                        fImp.pCd_clifor = rDup.Cd_clifor;
                                        fImp.pMensagem = "RECIBO LOCAÇÃO";

                                        //Buscar dados Empresa
                                        BindingSource bsEmp = new BindingSource();
                                        bsEmp.DataSource =
                                            TCN_CadEmpresa.Busca(rDup.Cd_empresa,
                                                                 string.Empty,
                                                                 string.Empty,
                                                                 null);
                                        Rel.Adiciona_DataSource("EMPRESA", bsEmp);
                                        if (bsEmp.Current != null)
                                            if ((bsEmp.Current as TRegistro_CadEmpresa).Img != null)
                                                Rel.Parametros_Relatorio.Add("IMAGEM_RELATORIO", (bsEmp.Current as TRegistro_CadEmpresa).Img);
                                        //Buscar dados do cliente
                                        BindingSource bsClifor = new BindingSource();
                                        bsClifor.DataSource = TCN_CadClifor.Busca_Clifor(rDup.Cd_clifor,
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
                                                                                                                            string.Empty,
                                                                                                                            string.Empty,
                                                                                                                            string.Empty,
                                                                                                                            string.Empty,
                                                                                                                            1,
                                                                                                                            null);
                                        Rel.Adiciona_DataSource("BSCLIFOR", bsClifor);
                                        //Endereco Cliente
                                        BindingSource bsEnd = new BindingSource();
                                        bsEnd.DataSource = TCN_CadEndereco.Buscar(rDup.Cd_clifor,
                                                                                                                     rDup.Cd_endereco,
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
                                        Rel.Adiciona_DataSource("BSEND", bsEnd);
                                        //Buscar Data Vencimento
                                        object ob = new CamadaDados.Financeiro.Duplicata.TCD_LanParcela().BuscarEscalar(
                                                        new TpBusca[]
                                                        {
                                                            new TpBusca { vNM_Campo = "a.cd_empresa", vOperador = "=", vVL_Busca = "'" + rDup.Cd_empresa.Trim() + "'" },
                                                            new TpBusca { vNM_Campo = "a.nr_lancto", vOperador = "=", vVL_Busca = rDup.Nr_lancto.ToString() }
                                                        }, "a.dt_vencto");
                                        Rel.Parametros_Relatorio.Add("DT_VENCIMENTO", DateTime.Parse(ob.ToString()).ToString("dd/MM/yyyy"));
                                        //Buscar Boleto
                                        obj = new CamadaDados.Financeiro.Bloqueto.TCD_Titulo().BuscarEscalar(
                                                new TpBusca[]
                                                {
                                                    new TpBusca { vNM_Campo = "a.cd_empresa", vOperador = "=", vVL_Busca = "'" + rDup.Cd_empresa.Trim() + "'" },
                                                    new TpBusca { vNM_Campo = "a.nr_lancto", vOperador = "=", vVL_Busca = rDup.Nr_lancto.ToString() }
                                                }, "a.nossonumero");
                                        Rel.Parametros_Relatorio.Add("NOSSO_NUMERO", obj == null ? string.Empty : obj.ToString());
                                        //Buscar Nr Recibo
                                        obj = new CamadaDados.Locacao.TCD_Locacao_X_Duplicata().BuscarEscalar(
                                                new TpBusca[]
                                                {
                                                    new TpBusca { vNM_Campo = "a.cd_empresa", vOperador = "=", vVL_Busca = "'" + rDup.Cd_empresa.Trim() + "'" },
                                                    new TpBusca { vNM_Campo = "a.nr_lancto", vOperador = "=", vVL_Busca = rDup.Nr_lancto.ToString() },
                                                    new TpBusca { vNM_Campo = "a.id_locacao", vOperador = "=", vVL_Busca = p.Id_locacaostr}
                                                }, "a.nr_recibo");
                                        Rel.Parametros_Relatorio.Add("NR_RECIBO", obj.ToString());
                                        if (Rel.Altera_Relatorio)
                                        {
                                            Rel.Gera_Relatorio(string.Empty,
                                                                fImp.pSt_imprimir,
                                                                fImp.pSt_visualizar,
                                                                fImp.pSt_enviaremail,
                                                                fImp.pSt_exportPdf,
                                                                fImp.Path_exportPdf,
                                                                fImp.pDestinatarios,
                                                                null,
                                                                "RECIBO LOCAÇÃO",
                                                                fImp.pDs_mensagem);
                                            Rel.Altera_Relatorio = false;
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
                                                                "RECIBO LOCAÇÃO",
                                                                fImp.pDs_mensagem);
                                    }
                                }
                                #endregion

                                //Imprimir boleto
                                CamadaDados.Financeiro.Bloqueto.blListaTitulo lBloqueto =
                            CamadaNegocio.Financeiro.Bloqueto.TCN_Titulo.Buscar(rDup.Cd_empresa,
                                                                                rDup.Nr_lancto,
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
                                    using (TFGerenciadorImpressao fImp = new TFGerenciadorImpressao())
                                    {
                                        fImp.St_enabled_enviaremail = true;
                                        fImp.pCd_clifor = rDup.Cd_clifor;
                                        fImp.pMensagem = "BLOQUETOS DO DOCUMENTO Nº" + rDup.Nr_docto;
                                        if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                                            TCN_LayoutBloqueto.Imprime_Bloqueto(false,
                                                                                lBloqueto,
                                                                                fImp.pSt_imprimir,
                                                                                fImp.pSt_visualizar,
                                                                                fImp.pSt_enviaremail,
                                                                                fImp.pSt_exportPdf,
                                                                                fImp.Path_exportPdf,
                                                                                fImp.pDestinatarios,
                                                                                "BLOQUETO(S) DO DOCUMENTO Nº " + rDup.Nr_docto,
                                                                                fImp.pDs_mensagem,
                                                                                false);
                                    }
                                //Imprimir Duplicata
                                else
                                {
                                    obj = new TCD_CadTpDoctoDup().BuscarEscalar(
                                            new TpBusca[]
                                            {
                                                new TpBusca()
                                                {
                                                    vNM_Campo = "a.tp_docto",
                                                    vOperador = "=",
                                                    vVL_Busca = rDup.Tp_doctostring
                                                },
                                                new TpBusca()
                                                {
                                                    vNM_Campo = "isnull(a.st_duplicata, 'N')",
                                                    vOperador = "=",
                                                    vVL_Busca = "'S'"
                                                }
                                            }, "1");
                                    if (obj != null)
                                    {
                                        //Chamar tela de impressao duplicata
                                        using (TFGerenciadorImpressao fImp = new TFGerenciadorImpressao())
                                        {
                                            //Buscar dados Empresa
                                            TList_CadEmpresa lEmpresa =
                                                TCN_CadEmpresa.Busca(rDup.Cd_empresa, string.Empty, string.Empty, null);
                                            //Buscar dados do sacado
                                            TList_CadClifor lSacado =
                                                TCN_CadClifor.Busca_Clifor(rDup.Cd_clifor,
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
                                                                           string.Empty,
                                                                           string.Empty,
                                                                           string.Empty,
                                                                           string.Empty,
                                                                           0,
                                                                           null);
                                            //Buscar endereco sacado
                                            if (lSacado.Count > 0)
                                                lSacado[0].lEndereco =
                                                    TCN_CadEndereco.Buscar(rDup.Cd_clifor,
                                                                           rDup.Cd_endereco,
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
                                                                           0,
                                                                           null);
                                            fImp.St_enabled_enviaremail = true;
                                            fImp.pCd_clifor = rDup.Cd_clifor;
                                            if (CamadaNegocio.ConfigGer.TCN_CadParamGer.BuscaVL_Bool("ST_CARNE",
                                                                             rDup.Cd_empresa,
                                                                             null).Trim().ToUpper().Equals("S"))
                                            {
                                                Relatorio Rel = new Relatorio();
                                                //Duplicata
                                                BindingSource bs = new BindingSource();
                                                bs.DataSource = new CamadaDados.Financeiro.Duplicata.TList_RegLanDuplicata() { rDup };
                                                Rel.DTS_Relatorio = bs;
                                                //Verificar se existe logo configurada para a empresa
                                                if (lEmpresa.Count > 0)
                                                    if (lEmpresa[0].Img != null)
                                                        Rel.Parametros_Relatorio.Add("IMAGEM_RELATORIO", lEmpresa[0].Img);
                                                //Empresa
                                                BindingSource bs_emp = new BindingSource();
                                                bs_emp.DataSource = lEmpresa;
                                                Rel.Adiciona_DataSource("DTS_EMP", bs_emp);
                                                //Parcelas
                                                BindingSource bs_parc = new BindingSource();
                                                bs_parc.DataSource = rDup.Parcelas;
                                                Rel.Adiciona_DataSource("DTS_PARC", bs_parc);
                                                //Sacado
                                                BindingSource bs_sacado = new BindingSource();
                                                bs_sacado.DataSource = lSacado;
                                                Rel.Adiciona_DataSource("DTS_SACADO", bs_sacado);

                                                Rel.Nome_Relatorio = "FRel_CarneDup";
                                                Rel.NM_Classe = "TFDuplicata";
                                                Rel.Modulo = "FIN";
                                                Rel.Ident = "FRel_CarneDup";
                                                fImp.St_enabled_enviaremail = true;
                                                fImp.pMensagem = "CARNÊ DUPLICATAS(S) DO DOCUMENTO Nº " + rDup.Nr_docto;
                                                if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                                                    Rel.Gera_Relatorio(string.Empty,
                                                                       fImp.pSt_imprimir,
                                                                       fImp.pSt_visualizar,
                                                                       fImp.pSt_enviaremail,
                                                                       fImp.pSt_exportPdf,
                                                                       fImp.Path_exportPdf,
                                                                       fImp.pDestinatarios,
                                                                       null,
                                                                       "CARNÊ DUPLICATAS(S) DO DOCUMENTO Nº " + rDup.Nr_docto,
                                                                       fImp.pDs_mensagem);
                                            }
                                            else
                                            {
                                                fImp.pMensagem = "DUPLICATAS DO DOCUMENTO Nº" + rDup.Nr_docto;
                                                if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                                                    TCN_LayoutDuplicata.Imprime_Duplicata(false,
                                                                                          rDup.Parcelas,
                                                                                          lEmpresa,
                                                                                          lSacado,
                                                                                          fImp.pSt_imprimir,
                                                                                          fImp.pSt_visualizar,
                                                                                          fImp.pSt_exportPdf,
                                                                                          fImp.Path_exportPdf,
                                                                                          fImp.pSt_enviaremail,
                                                                                          fImp.pDestinatarios,
                                                                                          "DUPLICATAS(S) DO DOCUMENTO Nº " + rDup.Nr_docto,
                                                                                          fImp.pDs_mensagem);
                                            }
                                        }
                                    }
                                }
                                DateTime date;
                                date = Convert.ToDateTime("01" + "/" + month.ToString() + "/" + cbxAno.Text);
                                BuscarFinanceiro(date);
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                        }
                    });

                }
            }
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

        private void BuscarFinanceiro(DateTime data)
        {
            //Calcular ultimo dia do mes
            DateTime d = data.AddMonths(1);
            d = d.AddDays(-1);

            TpBusca[] filtro = new TpBusca[4];
            //Data
            filtro[0].vNM_Campo = "DATEADD(day, a.diavencto, b.dt_locacao)";
            filtro[0].vOperador = ">=";
            filtro[0].vVL_Busca = "'" + data.ToString("yyyyMMdd 00:00:00") + "'";
            //Data
            filtro[1].vNM_Campo = "DATEADD(day, a.diavencto, b.dt_locacao)";
            filtro[1].vOperador = "<=";
            filtro[1].vVL_Busca = "'" + d.ToString("yyyyMMdd 23:59:59") + "'";
            //Status
            filtro[2].vNM_Campo = "isnull(a.st_faturado, 'N')";
            filtro[2].vOperador = "in";
            filtro[2].vVL_Busca = (cbStatus.Text.ToUpper().Trim().Equals("TODOS") ? "('S' , 'N')" :
                                              cbStatus.Text.ToUpper().Trim().Equals("ABERTO") ? "('N')" : "('S')");
            //Excluir cancelados na busca
            filtro[3].vNM_Campo = "isnull(b.st_registro, '0')";
            filtro[3].vOperador = "<>";
            filtro[3].vVL_Busca = "'8'";
            if (!string.IsNullOrEmpty(id_locacao.Text))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_locacao";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = id_locacao.Text;
            }
            if (!string.IsNullOrEmpty(nm_clifor.Text))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = "exists";
                filtro[filtro.Length - 1].vVL_Busca = "(select 1 from VTB_LOC_Locacao x " +
                                                      "where a.cd_empresa = x.cd_empresa " +
                                                      "and a.id_locacao = x.id_locacao " +
                                                      "and x.nm_clifor like '%" + nm_clifor.Text.Trim() + "%')";
            }
            bsParcela.DataSource =
               new CamadaDados.Locacao.TCD_ParcelaLocacao().Select(filtro, 0, string.Empty);
        }

        private void afterPrint()
        {
            using (TFImprimir fImprimir = new TFImprimir())
            {
                fImprimir.pMes = cbxMes.Text;
                fImprimir.pAno = cbxAno.Text;
                fImprimir.pId_locacao = id_locacao.Text;
                fImprimir.pNm_cliente = nm_clifor.Text;
                fImprimir.ShowDialog();
            }
        }

        private void TFItensFaturar_Load(object sender, EventArgs e)
        {
            Icon = ResourcesUtils.TecnoAliance_ICO;
            try
            {
                cbStatus.Text = "TODOS";
                cbxAno.Text = DateTime.Now.ToString("yyyy");
                cbxMes.Text = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day).ToString("MMMM", new System.Globalization.CultureInfo("pt-BR"));
                BuscarMes();
            }
            catch
            {
                cbStatus.Text = "TODOS";
                cbxAno.Text = DateTime.Now.ToString("yyyy");
                cbxMes.Text = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day).ToString("MMMM", new System.Globalization.CultureInfo("pt-BR"));
                BuscarMes();
            }
            DateTime date;
            date = Convert.ToDateTime("01" + "/" + month.ToString() + "/" + cbxAno.Text);
            BuscarFinanceiro(date);
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            afterFaturar(false);
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void TFItensFaturar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                afterFaturar(false);
            else if (e.KeyCode.Equals(Keys.F2))
                afterFaturar(true);
            else if (e.KeyCode.Equals(Keys.F6))
                DialogResult = DialogResult.Cancel;
            else if (e.KeyCode.Equals(Keys.F8))
                afterPrint();
            else if (e.KeyCode.Equals(Keys.Enter))
                bb_buscar_Click(this, new EventArgs());
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
            BuscarMes();
            DateTime date;
            date = Convert.ToDateTime("01" + "/" + month.ToString() + "/" + cbxAno.Text);
            BuscarFinanceiro(date);
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
            BuscarMes();
            DateTime date;
            date = Convert.ToDateTime("01" + "/" + month.ToString() + "/" + cbxAno.Text);
            BuscarFinanceiro(date);
        }

        private void gFaturar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                if (!(bsParcela.Current as CamadaDados.Locacao.TRegistro_ParcelaLocacao).St_faturadobool)
                {
                    (bsParcela.Current as CamadaDados.Locacao.TRegistro_ParcelaLocacao).St_processar =
                        !(bsParcela.Current as CamadaDados.Locacao.TRegistro_ParcelaLocacao).St_processar;
                    bsParcela.ResetCurrentItem();
                }
            }
        }

        private void cbTodos_Click(object sender, EventArgs e)
        {
            if (bsParcela.Count > 0)
            {
                (bsParcela.DataSource as CamadaDados.Locacao.TList_ParcelaLocacao).Where(p => !p.St_faturadobool).ToList()
                    .ForEach(p => p.St_processar = cbTodos.Checked);
                bsParcela.ResetBindings(true);
            }
        }

        private void gFaturar_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
                if (e.ColumnIndex.Equals(8))
                {
                    if (e.Value.Equals(true))
                        gFaturar.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Blue;
                    else
                        gFaturar.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                }
        }

        private void cbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            DateTime date;
            date = Convert.ToDateTime("01" + "/" + month.ToString() + "/" + cbxAno.Text);
            BuscarFinanceiro(date);
        }

        private void bb_gerarBoleto_Click(object sender, EventArgs e)
        {
            afterFaturar(true);
        }

        private void id_locacao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || //Letras
               char.IsSymbol(e.KeyChar) || //Símbolos
               char.IsWhiteSpace(e.KeyChar) || //Espaço
               char.IsPunctuation(e.KeyChar)) //Pontuação
                e.Handled = true;
        }

        private void BB_Imprimir_Click(object sender, EventArgs e)
        {
            afterPrint();
        }

        private void bb_buscar_Click(object sender, EventArgs e)
        {
            if (month != 0) BuscarMes(); else return;
            DateTime date;
            date = Convert.ToDateTime("01" + "/" + month.ToString() + "/" + cbxAno.Text);
            BuscarFinanceiro(date);
        }

        private void gFaturar_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gFaturar.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsParcela.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new CamadaDados.Locacao.TRegistro_ParcelaLocacao());
            CamadaDados.Locacao.TList_ParcelaLocacao lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gFaturar.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gFaturar.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new CamadaDados.Locacao.TList_ParcelaLocacao(lP.Find(gFaturar.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gFaturar.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new CamadaDados.Locacao.TList_ParcelaLocacao(lP.Find(gFaturar.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gFaturar.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsParcela.List as CamadaDados.Locacao.TList_ParcelaLocacao).Sort(lComparer);
            bsParcela.ResetBindings(false);
            gFaturar.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void cbxMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.bb_buscar_Click(sender, e);
        }

        private void cbxAno_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.bb_buscar_Click(sender, e);
        }

        private void cbxMes_Leave(object sender, EventArgs e)
        {
            this.bb_buscar_Click(sender, e);
        }

        private void cbxAno_Leave(object sender, EventArgs e)
        {
            this.bb_buscar_Click(sender, e);
        }
    }
}
