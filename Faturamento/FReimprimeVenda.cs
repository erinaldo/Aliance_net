using System;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;
using FormBusca;
using CamadaDados.Faturamento.PDV;
using Utils;

namespace Faturamento
{
    public partial class TFReimprimeVenda : Form
    {
        public TRegistro_VendaRapida rVenda
        {
            get
            {
                if (bsVenda.Count > 0)
                    return bsVenda.Current as TRegistro_VendaRapida;
                else
                    return null;
            }
        }
        private bool Altera_Relatorio = false;
        private CamadaDados.Faturamento.Cadastros.TList_CFGCupomFiscal lCfg
        { get; set; }

        public TFReimprimeVenda()
        {
            InitializeComponent();
        }

        private void afterBusca()
        {
            TpBusca[] filtro = new TpBusca[1];
            //Venda Ativa
            filtro[0].vNM_Campo = "isnull(a.st_registro, 'A')";
            filtro[0].vOperador = "<>";
            filtro[0].vVL_Busca = "'C'";
            if (!string.IsNullOrEmpty(id_cupom.Text))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_vendarapida";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = id_cupom.Text;
            }
            if (!string.IsNullOrEmpty(CD_Empresa.Text))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + CD_Empresa.Text.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(nm_clifor.Text))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nm_clifor";
                filtro[filtro.Length - 1].vOperador = "like";
                filtro[filtro.Length - 1].vVL_Busca = "('%" + nm_clifor.Text.Trim() + "%')";
            }
            if (dt_ini.Text.Trim() != "/  /")
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.dt_emissao";
                filtro[filtro.Length - 1].vOperador = ">=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(dt_ini.Text).ToString("yyyyMMdd")) + " 00:00:00'";
            }
            if (dt_fin.Text.Trim() != "/  /")
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.dt_emissao";
                filtro[filtro.Length - 1].vOperador = "<=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(dt_fin.Text).ToString("yyyyMMdd")) + " 23:59:59'";
            }
            bsVenda.DataSource = new TCD_VendaRapida().Select(filtro, 0, string.Empty, "a.dt_emissao desc");
            bsVenda_PositionChanged(this, new EventArgs());
        }

        private void Imprimir()
        {
            if (bsVenda.Current != null)
            {
                (bsVenda.Current as TRegistro_VendaRapida).lItem =
                    CamadaNegocio.Faturamento.PDV.TCN_VendaRapida_Item.Buscar((bsVenda.Current as TRegistro_VendaRapida).Id_vendarapidastr,
                                                                              (bsVenda.Current as TRegistro_VendaRapida).Cd_empresa,
                                                                              false,
                                                                              string.Empty,
                                                                              null);
                (bsVenda.Current as TRegistro_VendaRapida).lItem.ForEach(v => v.lGradeEstoque = new CamadaDados.Estoque.TCD_GradeEstoque().Select(
                                                    new TpBusca[]
                                                    {
                                                            new TpBusca
                                                            {
                                                                vNM_Campo = string.Empty,
                                                                vOperador = "exists",
                                                                vVL_Busca = "(select 1 from tb_pdv_cupomfiscal_item_x_estoque x " +
                                                                            "where x.cd_empresa = a.cd_empresa "+
                                                                            "and x.cd_produto = a.cd_produto " +
                                                                            "and x.id_lanctoestoque = a.id_lanctoestoque " +
                                                                            "and x.cd_empresa = '" + v.Cd_empresa.Trim() + "' " +
                                                                            "and x.id_cupom = " + v.Id_vendarapida.ToString() + " " +
                                                                            "and x.id_lancto = " + v.Id_lanctovenda.ToString() + ")"

                                                            }
                                                    }, 0, string.Empty));

                object obj = new CamadaDados.Diversos.TCD_CadTerminal().BuscarEscalar(
                                                                   new TpBusca[]
                                                                {
                                                                    new TpBusca()
                                                                    {
                                                                        vNM_Campo = "a.cd_terminal",
                                                                        vOperador = "=",
                                                                        vVL_Busca = "'" + Utils.Parametros.pubTerminal.Trim() + "'"
                                                                    }
                                                                }, "a.tp_imporcamento");


                if ((obj == null ? false : obj.ToString().Trim().ToUpper().Equals("T")))
                {
                    CamadaNegocio.Faturamento.PDV.TCN_VendaRapida.ImprimirVendaRapida(rVenda);
                    return;
                }
                else if ((obj == null ? false : obj.ToString().Trim().ToUpper().Equals("F")))
                    ImprimirGraficoReduzido(rVenda);
                else if ((obj == null ? false : obj.ToString().Trim().ToUpper().Equals("R")))
                {
                    object obj1 = new CamadaDados.Diversos.TCD_CadTerminal().BuscarEscalar(
                                    new TpBusca[]
                                                    {
                                                        new TpBusca()
                                                        {
                                                            vNM_Campo = "a.cd_terminal",
                                                            vOperador = "=",
                                                            vVL_Busca = "'" + Utils.Parametros.pubTerminal.Trim() + "'"
                                                        }
                                                    }, "a.porta_imptick");
                    if (obj1 == null)
                        throw new Exception("Não existe porta de impressão configurada para o terminal " + Utils.Parametros.pubTerminal.Trim());
                    lCfg = CamadaNegocio.Faturamento.Cadastros.TCN_CFGCupomFiscal.Buscar(rVenda.Cd_empresa, null);
                    if(lCfg.Count > 0)
                        CamadaNegocio.Faturamento.PDV.TCN_VendaRapida.ImprimirReduzido(rVenda, lCfg[0].Cd_clifor, lCfg[0].St_impcpfcnpjbool, obj1.ToString());
                }
                else
                    ImprimirGrafico(rVenda);
            }
        }

        private void ImprimirGrafico(TRegistro_VendaRapida val)
        {
            FormRelPadrao.Relatorio Relatorio = new FormRelPadrao.Relatorio();
            Relatorio.Nome_Relatorio = "TFLanVendaRapida";
            Relatorio.NM_Classe = "TFLanVendaRapida";
            Relatorio.Modulo = string.Empty;
            Relatorio.Ident = "Orcamento_VendaRapida";
            Relatorio.Altera_Relatorio = Altera_Relatorio;

            BindingSource BinEmpresa = new BindingSource();
            BinEmpresa.DataSource = CamadaNegocio.Diversos.TCN_CadEmpresa.Busca(val.Cd_empresa,
                                                                                string.Empty,
                                                                                string.Empty,
                                                                                null);
            Relatorio.Adiciona_DataSource("EMPRESA", BinEmpresa);

            if (!string.IsNullOrEmpty((bsVenda.Current as TRegistro_VendaRapida).Cd_clifor))
            {
                BindingSource BinClifor = new BindingSource();
                BinClifor.DataSource = CamadaNegocio.Financeiro.Cadastros.TCN_CadClifor.Busca_Clifor(val.Cd_clifor,
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
                Relatorio.Adiciona_DataSource("CLIENTE", BinClifor);

                BindingSource BinEndereco = new BindingSource();
                BinEndereco.DataSource = CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Buscar(val.Cd_clifor,
                                                                                                   val.Cd_endereco,
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
                Relatorio.Adiciona_DataSource("ENDCLIENTE", BinEndereco);
            }
            //Financeiro Venda
            BindingSource BinPortador = new BindingSource();
            BinPortador.DataSource = new TCD_CaixaPDV().SelectMovCaixa(
                                        new TpBusca[]
                                                        {
                                                            new TpBusca()
                                                            {
                                                                vNM_Campo = "a.cd_empresa",
                                                                vOperador = "=",
                                                                vVL_Busca = "'" + val.Cd_empresa.Trim() + "'"
                                                            },
                                                            new TpBusca()
                                                            {
                                                                vNM_Campo = "a.id_cupom",
                                                                vOperador = "=",
                                                                vVL_Busca = val.Id_vendarapidastr
                                                            }
                                                        }, string.Empty);
            Relatorio.Adiciona_DataSource("FINPORTADOR", BinPortador);
            //Duplicata Venda
            BindingSource BinDup = new BindingSource();
            BinDup.DataSource = new CamadaDados.Financeiro.Duplicata.TCD_LanParcela().Select(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = "isnull(dup.st_registro, 'A')",
                                            vOperador = "<>",
                                            vVL_Busca = "'C'"
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = string.Empty,
                                            vOperador = "exists",
                                            vVL_Busca = "(select 1 from tb_pdv_cupomfiscal_x_duplicata x " +
                                                        "where x.cd_empresa = a.cd_empresa "+
                                                        "and x.nr_lancto = a.nr_lancto " +
                                                        "and x.cd_empresa = '" + val.Cd_empresa.Trim() + "' " +
                                                        "and x.id_cupom = " + val.Id_vendarapidastr + ")"
                                        }
                                    }, 0, string.Empty, string.Empty, string.Empty);
            Relatorio.Adiciona_DataSource("FINDUP", BinDup);

            //Fatura Cartao Venda
            BindingSource BinFat = new BindingSource();
            BinFat.DataSource = new CamadaDados.Financeiro.Cartao.TCD_FaturaCartao().Select(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = string.Empty,
                                            vOperador = "exists",
                                            vVL_Busca = "(select 1 from TB_FIN_FaturaCartao_X_Caixa x " +
                                                        "inner join TB_PDV_Cupom_X_MovCaixa y " +
                                                        "on y.cd_contager = x.cd_contager " +
                                                        "and y.cd_lanctocaixa = x.cd_lanctocaixa " +
                                                        "where x.id_fatura = a.id_fatura " +
                                                        "and y.cd_empresa = '" + val.Cd_empresa.Trim() + "' " + 
                                                        "and y.id_cupom = " + val.Id_vendarapidastr + ")"
                                        }
                                    }, 0, string.Empty, string.Empty);
            Relatorio.Adiciona_DataSource("FATCARTAO", BinFat);

            BindingSource meu_bind = new BindingSource();
            meu_bind.DataSource = val;
            Relatorio.DTS_Relatorio = meu_bind;

            //Verificar se Venda possui OS faturada
            StringBuilder obsOS = new StringBuilder();
            CamadaDados.Servicos.TList_LanServico lOS =
                new CamadaDados.Servicos.TCD_LanServico().Select(
                new TpBusca[]
                {
                    new TpBusca()
                    {
                        vNM_Campo = string.Empty,
                        vOperador = "exists",
                        vVL_Busca = "(select 1 from TB_OSE_Pecas_X_PreVenda x " +
                                    "inner join TB_PDV_PreVenda_X_VendaRapida y " +
                                    "on x.CD_Empresa = y.CD_Empresa " +
                                    "and x.ID_PreVenda = y.ID_PreVenda " +
                                    "and x.ID_ItemPreVenda = y.ID_ItemPreVenda " +
                                    "where x.ID_OS = a.ID_OS " +
                                    "and y.Id_Cupom = '" + (bsVenda.Current as TRegistro_VendaRapida).Id_vendarapidastr.Trim() + "')"
                    }
                }, 0, string.Empty, string.Empty);
            if (lOS.Count > 0)
            {
                obsOS.AppendLine("Pré Venda Referente a OS: " + lOS[0].Id_osstr.Trim() + "  Placa: " + lOS[0].Placaveiculo.Trim() + " Modelo: " + lOS[0].Ds_veiculo.Trim());
                (bsVenda.Current as TRegistro_VendaRapida).ObsOS = obsOS.ToString();
            }
            //Adicionar itens devolvidos
            Relatorio.Adiciona_DataSource("DTS_DEV", bsItensDev);
            if (!Altera_Relatorio)
            {
                //Chamar tela de gerenciamento de impressao
                using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                {
                    fImp.St_enabled_enviaremail = true;
                    fImp.pCd_clifor = val.Cd_clifor;
                    fImp.pMensagem = "ORÇAMENTO Nº " + val.Id_vendarapidastr;
                    if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                        Relatorio.Gera_Relatorio(val.Id_vendarapidastr,
                                                 fImp.pSt_imprimir,
                                                 fImp.pSt_visualizar,
                                                 fImp.pSt_enviaremail,
                                                 fImp.pSt_exportPdf,
                                                 fImp.Path_exportPdf,
                                                 fImp.pDestinatarios,
                                                 null,
                                                 "ORÇAMENTO Nº " + val.Id_vendarapidastr,
                                                 fImp.pDs_mensagem);
                }
            }
            else
            {
                Relatorio.Gera_Relatorio();
                Altera_Relatorio = false;
            }
        }

        private void ImprimirGraficoReduzido(TRegistro_VendaRapida val)
        {
            FormRelPadrao.Relatorio Relatorio = new FormRelPadrao.Relatorio();
            Relatorio.Nome_Relatorio = "TFLanVendaRapida";
            Relatorio.NM_Classe = "TFLanVendaRapida";
            Relatorio.Modulo = "FAT";
            Relatorio.Ident = "Orcamento_VendaGraficaReduzido";
            Relatorio.Altera_Relatorio = Altera_Relatorio;

            BindingSource BinEmpresa = new BindingSource();
            BinEmpresa.DataSource = CamadaNegocio.Diversos.TCN_CadEmpresa.Busca(val.Cd_empresa,
                                                                                string.Empty,
                                                                                string.Empty,
                                                                                null);
            Relatorio.Adiciona_DataSource("EMPRESA", BinEmpresa);

            if (!string.IsNullOrEmpty(val.Cd_clifor))
            {
                BindingSource BinClifor = new BindingSource();
                BinClifor.DataSource = CamadaNegocio.Financeiro.Cadastros.TCN_CadClifor.Busca_Clifor(val.Cd_clifor,
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
                Relatorio.Adiciona_DataSource("CLIENTE", BinClifor);

                BindingSource BinEndereco = new BindingSource();
                BinEndereco.DataSource = CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Buscar(val.Cd_clifor,
                                                                                                   val.Cd_endereco,
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
                Relatorio.Adiciona_DataSource("ENDCLIENTE", BinEndereco);
            }
            //Financeiro Venda
            BindingSource BinPortador = new BindingSource();
            BinPortador.DataSource = new TCD_CaixaPDV().SelectMovCaixa(
                                        new TpBusca[]
                                                        {
                                                            new TpBusca()
                                                            {
                                                                vNM_Campo = "a.cd_empresa",
                                                                vOperador = "=",
                                                                vVL_Busca = "'" + val.Cd_empresa.Trim() + "'"
                                                            },
                                                            new TpBusca()
                                                            {
                                                                vNM_Campo = "a.id_cupom",
                                                                vOperador = "=",
                                                                vVL_Busca = val.Id_vendarapidastr
                                                            }
                                                        }, string.Empty);
            Relatorio.Adiciona_DataSource("FINPORTADOR", BinPortador);
            //Duplicata Venda
            BindingSource BinDup = new BindingSource();
            BinDup.DataSource = new CamadaDados.Financeiro.Duplicata.TCD_LanParcela().Select(
                                    new TpBusca[]
                                                    {
                                                        new TpBusca()
                                                        {
                                                            vNM_Campo = "isnull(dup.st_registro, 'A')",
                                                            vOperador = "<>",
                                                            vVL_Busca = "'C'"
                                                        },
                                                        new TpBusca()
                                                        {
                                                            vNM_Campo = string.Empty,
                                                            vOperador = "exists",
                                                            vVL_Busca = "(select 1 from tb_pdv_cupomfiscal_x_duplicata x " +
                                                                        "where x.cd_empresa = a.cd_empresa "+
                                                                        "and x.nr_lancto = a.nr_lancto " +
                                                                        "and x.cd_empresa = '" + val.Cd_empresa.Trim() + "' " +
                                                                        "and x.id_cupom = " + val.Id_vendarapidastr + ")"
                                                        }
                                                    }, 0, string.Empty, string.Empty, string.Empty);
            Relatorio.Adiciona_DataSource("FINDUP", BinDup);

            //Fatura Cartao Venda
            BindingSource BinFat = new BindingSource();
            BinFat.DataSource = new CamadaDados.Financeiro.Cartao.TCD_FaturaCartao().Select(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = string.Empty,
                                            vOperador = "exists",
                                            vVL_Busca = "(select 1 from TB_FIN_FaturaCartao_X_Caixa x " +
                                                        "inner join TB_PDV_Cupom_X_MovCaixa y " +
                                                        "on y.cd_contager = x.cd_contager " +
                                                        "and y.cd_lanctocaixa = x.cd_lanctocaixa " +
                                                        "where x.id_fatura = a.id_fatura " +
                                                        "and y.cd_empresa = '" + val.Cd_empresa.Trim() + "' " + 
                                                        "and y.id_cupom = " + val.Id_vendarapidastr + ")"
                                        }
                                    }, 0, string.Empty, string.Empty);
            Relatorio.Adiciona_DataSource("FATCARTAO", BinFat);

            BindingSource meu_bind = new BindingSource();
            meu_bind.DataSource = val;
            Relatorio.DTS_Relatorio = meu_bind;

            //Verificar se Venda possui OS faturada
            StringBuilder obsOS = new StringBuilder();
            CamadaDados.Servicos.TList_LanServico lOS =
                new CamadaDados.Servicos.TCD_LanServico().Select(
                new TpBusca[]
                {
                    new TpBusca()
                    {
                        vNM_Campo = string.Empty,
                        vOperador = "exists",
                        vVL_Busca = "(select 1 from TB_OSE_Pecas_X_PreVenda x " +
                                    "inner join TB_PDV_PreVenda_X_VendaRapida y " +
                                    "on x.CD_Empresa = y.CD_Empresa " +
                                    "and x.ID_PreVenda = y.ID_PreVenda " +
                                    "and x.ID_ItemPreVenda = y.ID_ItemPreVenda " +
                                    "where x.ID_OS = a.ID_OS " +
                                    "and y.Id_Cupom = '" + val.Id_vendarapidastr.Trim() + "')"
                    }
                }, 0, string.Empty, string.Empty);
            if (lOS.Count > 0)
            {
                obsOS.AppendLine("Pré-Venda Referente a OS:" + lOS[0].Id_osstr.Trim() + "   Placa: " + lOS[0].Placaveiculo.Trim() + "  Modelo: " + lOS[0].Ds_veiculo.Trim());
                val.ObsOS = obsOS.ToString();
            }


            //Verificar se existe Impressora padrão para o PDV
            object obj = new CamadaDados.Faturamento.Cadastros.TCD_PontoVenda().BuscarEscalar(
                                                new TpBusca[]
                                                {
                                                    new TpBusca()
                                                    {
                                                        vNM_Campo = "a.cd_terminal",
                                                        vOperador = "=",
                                                        vVL_Busca = "'" + Utils.Parametros.pubTerminal.Trim() + "'"
                                                    }
                                                }, "a.impressorapadrao");
            string print = string.Empty;
            print = obj == null ? string.Empty : obj.ToString();
            if (string.IsNullOrEmpty(print))
                using (Parametros.Diversos.TFListaImpressoras fLista = new Parametros.Diversos.TFListaImpressoras())
                {
                    if (fLista.ShowDialog() == DialogResult.OK)
                        if (!string.IsNullOrEmpty(fLista.Impressora))
                            print = fLista.Impressora;

                }
            //Imprimir
	    if(!string.IsNullOrEmpty(print))
                Relatorio.ImprimiGraficoReduzida(print,
                                                 true,
                                                 false,
                                                 null,
                                                 string.Empty,
                                                 string.Empty,
                                                 1);
            Altera_Relatorio = false;
        }

        private void BB_Clifor_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { nm_clifor }, string.Empty);
        }

        private void BB_Empresa_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("a.NM_empresa|Nome Empresa|300;a.CD_Empresa|Cód Empresa|100"
                          , new Componentes.EditDefault[] { CD_Empresa }
                          , new CamadaDados.Diversos.TCD_CadEmpresa(),
                          "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.cd_empresa = A.cd_empresa " +
                          "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                          "(exists(select 1 from tb_div_usuario_x_grupos y " +
                          "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))");
        }

        private void CD_Empresa_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.cd_empresa|=|'" + CD_Empresa.Text.Trim() + "';" +
                                   "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.cd_empresa = A.cd_empresa " +
                                   "and((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                   "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                   "        where y.logingrp = x.login " +
                                   "        and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))"
               , new Componentes.EditDefault[] { CD_Empresa }, new CamadaDados.Diversos.TCD_CadEmpresa());
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            afterBusca();
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            Imprimir();
        }

        private void TFReimprimeVenda_Load(object sender, EventArgs e)
        {
            ShapeGrid.RestoreShape(this, gItens);
            ShapeGrid.RestoreShape(this, gVendaRapida);
            Icon = ResourcesUtils.TecnoAliance_ICO;
            pFiltro.set_FormatZero();
        }

        private void TFReimprimeVenda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F6))
                DialogResult = DialogResult.Cancel;
            else if (e.KeyCode.Equals(Keys.F7))
                afterBusca();
            else if (e.KeyCode.Equals(Keys.F8))
                Imprimir();
            else if (e.Control && e.KeyCode.Equals(Keys.P))
            {
                Altera_Relatorio = true;
                MessageBox.Show("Execute o relatorio que deseja alterar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void bsVenda_PositionChanged(object sender, EventArgs e)
        {
            if (bsVenda.Current != null)
            {
                (bsVenda.Current as TRegistro_VendaRapida).lItem =
                    CamadaNegocio.Faturamento.PDV.TCN_VendaRapida_Item.Buscar((bsVenda.Current as TRegistro_VendaRapida).Id_vendarapidastr,
                                                                              (bsVenda.Current as TRegistro_VendaRapida).Cd_empresa,
                                                                              false,
                                                                              string.Empty,
                                                                              null);
                bsVenda.ResetCurrentItem();
                //Buscar Itens Devolvidos
                bsItensDev.DataSource = CamadaNegocio.Faturamento.PDV.TCN_ItensDevolvidos.Buscar((bsVenda.Current as TRegistro_VendaRapida).Cd_empresa,
                                                                                                 string.Empty,
                                                                                                 (bsVenda.Current as TRegistro_VendaRapida).Id_vendarapidastr,
                                                                                                 null);
            }
            else bsItensDev.Clear();
        }

        private void TFReimprimeVenda_FormClosing(object sender, FormClosingEventArgs e)
        {
            ShapeGrid.SaveShape(this, gItens);
            ShapeGrid.SaveShape(this, gVendaRapida);
        }

        private void gVendaRapida_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gVendaRapida.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsVenda.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new TRegistro_VendaRapida());
            TList_VendaRapida lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gVendaRapida.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gVendaRapida.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new TList_VendaRapida(lP.Find(gVendaRapida.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gVendaRapida.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new TList_VendaRapida(lP.Find(gVendaRapida.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gVendaRapida.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsVenda.List as TList_VendaRapida).Sort(lComparer);
            bsVenda.ResetBindings(false);
            gVendaRapida.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }
    }
}
