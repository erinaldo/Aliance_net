using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FormBusca;
using Utils;
using CamadaDados.Faturamento.PDV;
using CamadaNegocio.Faturamento.PDV;

namespace Faturamento
{
    public partial class TFConsultaFrenteCaixa : Form
    {
        private bool Altera_Relatorio = false;
        private CamadaDados.Faturamento.Cadastros.TList_CFGCupomFiscal lCfg
        { get; set; }
        public TFConsultaFrenteCaixa()
        {
            InitializeComponent();
        }
        
        private void afterExclui()
        {
            if (bsVenda.Current != null)
            {
                if (MessageBox.Show("Confirma cancelamento venda?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                             MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    try
                    {
                        //Verificar se venda possui pontos resgatados
                        if ((bsVenda.Current as TRegistro_VendaRapida).PontosFidRes > decimal.Zero)
                        {
                            string loginCanc = string.Empty;
                            using (Parametros.Diversos.TFRegraUsuario fRegra = new Parametros.Diversos.TFRegraUsuario())
                            {
                                fRegra.Ds_regraespecial = "PERMITIR CANCELAR VALE PONTOS FIDELIZAÇÃO";
                                if (fRegra.ShowDialog() == DialogResult.OK)
                                    loginCanc = fRegra.Login;
                                else
                                {
                                    MessageBox.Show("Obrigatório informar LOGIN com permissão para CANCELAR venda com pontos resgatados.",
                                                    "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                            }
                            (bsVenda.Current as TRegistro_VendaRapida).LoginCancPontos = loginCanc;
                        }
                        if (string.IsNullOrEmpty((bsVenda.Current as TRegistro_VendaRapida).MotivoCanc))
                        {
                            InputBox ibp = new InputBox();
                            ibp.Text = "Motivo Cancelamento Venda";
                            (bsVenda.Current as TRegistro_VendaRapida).MotivoCanc = ibp.ShowDialog();
                            if (string.IsNullOrEmpty((bsVenda.Current as TRegistro_VendaRapida).MotivoCanc))
                            {
                                MessageBox.Show("Obrigatorio informar motivo de cancelamento da venda.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                            if ((bsVenda.Current as TRegistro_VendaRapida).MotivoCanc.Trim().Length < 10)
                            {
                                MessageBox.Show("Motivo de cancelamento deve ter mais que 10 caracteres.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }
                        TCN_VendaRapida.ExcluirVendaRapida(new List<TRegistro_VendaRapida> { bsVenda.Current as TRegistro_VendaRapida }, null);
                        MessageBox.Show("Venda rapida excluida com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        afterBusca();
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            }
        }

        private void afterBusca()
        {
            if (!dt_inicial.Text.SoNumero().Length.Equals(8) && !dt_inicial.Text.SoNumero().Length.Equals(0))
            {
                MessageBox.Show("É necessário informar Data na Busca!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (!dt_final.Text.SoNumero().Length.Equals(8) && !dt_final.Text.SoNumero().Length.Equals(0))
            {
                MessageBox.Show("É necessário informar Data na Busca!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            } 
            if (!dt_ini.SoNumero().Length.Equals(4) && !dt_ini.SoNumero().Length.Equals(4))
            {
                MessageBox.Show("É necessário informar Hora na Busca!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            } 
            if (!dt_fim.SoNumero().Length.Equals(4) && !dt_fim.SoNumero().Length.Equals(4))
            {
                MessageBox.Show("É necessário informar Hora na Busca!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string ini = string.Empty;
            string fim = string.Empty;
            if(dt_inicial.Text.SoNumero().Length.Equals(8) && !dt_inicial.Text.SoNumero().Length.Equals(0))
                ini =
                    string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(dt_inicial.Text).ToString("yyyyMMdd")) 
                + " " +
                string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(dt_ini.Text).ToString("HH:mm"))
                ;
            if (dt_final.Text.SoNumero().Length.Equals(8) && !dt_final.Text.SoNumero().Length.Equals(0))
                fim =
                    string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(dt_final.Text).ToString("yyyyMMdd"))
                + " " +
                string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(dt_fim.Text).ToString("HH:mm"))
                ;

            TList_VendaRapida lVenda = TCN_VendaRapida.Buscar(id_venda.Text,
                                                              cd_empresa.Text,
                                                              cd_vendedor.Text,
                                                              id_pdv.Text,
                                                              nm_clifor.Text,
                                                              ini,
                                                              fim,
                                                              vl_ini.Value,
                                                              vl_fin.Value,
                                                              cd_produto.Text,
                                                              nr_requisicao.Text,
                                                              Id_locacao.Text,
                                                              cbStatus.SelectedIndex.Equals(0) ? "'A'" : cbStatus.SelectedIndex.Equals(1) ? "'C'" : string.Empty,
                                                              Convert.ToInt32(qtd_nota.Text),
                                                              null);

            //Resumo Empresa
            TList_ResumoEmpresa lREmpresa = new TList_ResumoEmpresa();
            lVenda.GroupBy(p => p.Nm_empresa,
                (aux, venda) =>
                new TRegistro_ResumoEmpresa()
                {
                    Nm_empresa = aux,
                    Vl_cupom = venda.Sum(x => x.Vl_cupom),
                    Vl_devolucao =  venda.Sum(x => x.vl_devolvido),
                    VL_TotalLiquido = (venda.Sum(x => x.Vl_cupom) - venda.Sum(x => x.vl_devolvido)),
                }).ToList().ForEach(p => lREmpresa.Add(p));
            bsResumoEmpresa.DataSource = lREmpresa;
            //Resumo PDV
            TList_ResumoPDV lRPDV = new TList_ResumoPDV();
            lVenda.GroupBy(p => p.Ds_pdv,
                (aux, venda) =>
                    new TRegistro_ResumoPDV()
                    {
                        Ds_pdv = aux,
                        Vl_cupom = venda.Sum(x => x.Vl_cupom),
                        Vl_devolucao = venda.Sum(x => x.vl_devolvido),
                        Vl_totalliquido = (venda.Sum(x => x.Vl_cupom) - venda.Sum(x => x.vl_devolvido)),
                    }).ToList().ForEach(p => lRPDV.Add(p));
            bsResumoPdv.DataSource = lRPDV;
            //Resumo Cliente
            TList_ResumoCliente lRCliente = new TList_ResumoCliente();
            lVenda.GroupBy(p => p.Nm_clifor,
                (aux, venda) =>
                    new TRegistro_ResumoCliente()
                    {
                        Nm_cliente = aux,
                        Vl_cupom = venda.Sum(x => x.Vl_cupom),
                        Vl_devolucao = venda.Sum(x => x.vl_devolvido),
                        Vl_TotalLiquido = (venda.Sum(x => x.Vl_cupom) - venda.Sum(x => x.vl_devolvido)),
                    }).ToList().ForEach(p => lRCliente.Add(p));
            bsResumoCliente.DataSource = lRCliente;
            bsVenda.DataSource = lVenda;
            bsVenda_PositionChanged(this, new EventArgs());

            buscarResumos();
        }

        private void afterPrint()
        {
            if (bsVenda.Current != null)
            {
                tcFinan_SelectedIndexChanged(this, new EventArgs());
                if (MessageBox.Show("Deseja Reimprimir a Venda?", "Pergunta", MessageBoxButtons.YesNo,
                         MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
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
                        TCN_VendaRapida.ImprimirVendaRapida(bsVenda.Current as TRegistro_VendaRapida);
                        return;
                    }
                    else if ((obj == null ? false : obj.ToString().Trim().ToUpper().Equals("F")))
                        ImprimirGraficoReduzido(bsVenda.Current as TRegistro_VendaRapida);
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
                        lCfg = CamadaNegocio.Faturamento.Cadastros.TCN_CFGCupomFiscal.Buscar((bsVenda.Current as TRegistro_VendaRapida).Cd_empresa, null);
                        if(lCfg.Count > 0)
                            TCN_VendaRapida.ImprimirReduzido(bsVenda.Current as TRegistro_VendaRapida, lCfg[0].Cd_clifor, lCfg[0].St_impcpfcnpjbool, obj1.ToString());
                    }
                    else
                        ImprimirGrafico(bsVenda.Current as TRegistro_VendaRapida);
                }
            }
        }

        private void ImprimirGrafico(TRegistro_VendaRapida val)
        {
            FormRelPadrao.Relatorio Relatorio = new FormRelPadrao.Relatorio();
            Relatorio.Nome_Relatorio = "TFLanVendaRapida";
            Relatorio.NM_Classe = "TFLanVendaRapida";
            Relatorio.Modulo = Tag.ToString().Substring(0, 3);
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

            if (val.lItem.Count.Equals(0))
            {
                val.lItem = TCN_VendaRapida_Item.Buscar(val.Id_vendarapidastr,
                                                        val.Cd_empresa,
                                                        false,
                                                        string.Empty,
                                                        null);
            }

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
            //Buscar Itens Devolvidos
            BindingSource bsDev = new BindingSource();
            bsDev.DataSource = TCN_ItensDevolvidos.Buscar(
                (bsVenda.Current as TRegistro_VendaRapida).Cd_empresa,
                string.Empty,
                (bsVenda.Current as TRegistro_VendaRapida).Id_vendarapidastr,
                null);
            Relatorio.Adiciona_DataSource("DTS_DEV", bsDev);
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
            Relatorio.Gera_Relatorio();
            //Imprimir
            if (!string.IsNullOrEmpty(print))
                Relatorio.ImprimiGraficoReduzida(print,
                                                 true,
                                                 false,
                                                 null,
                                                 string.Empty,
                                                 string.Empty,
						                         1);
            Altera_Relatorio = false;
        }

        private void GerarNfe()
        {
            if (bsVenda.Current != null)
            {
                //Buscar Configuração Venda
                lCfg = new CamadaDados.Faturamento.Cadastros.TCD_CFGCupomFiscal().Select(
                        new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = "a.cd_empresa",
                                    vOperador = "=",
                                    vVL_Busca = "'" + (bsVenda.Current as TRegistro_VendaRapida).Cd_empresa.Trim() + "'"
                                }
                            }, 0, string.Empty);
                if (lCfg.Count.Equals(0))
                {
                    MessageBox.Show("Não existe configuração cupom fiscal para a empresa " + (bsVenda.Current as TRegistro_VendaRapida).Cd_empresa.Trim(),
                        "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (MessageBox.Show("Gerar NFe da venda corrente?", "Pergunta", MessageBoxButtons.YesNo,
                     MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    if ((bsVenda.Current as TRegistro_VendaRapida).St_registro.ToUpper().Equals("C"))
                    {
                        MessageBox.Show("Não é possivel gerar NFe de venda cancelada!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    //Verificar se venda possui cupom
                    if (new TCD_NFCe().BuscarEscalar(
                        new TpBusca[]
                        {
                        new TpBusca()
                        {
                            vNM_Campo = "isnull(a.st_registro, 'A')",
                            vOperador = "<>",
                            vVL_Busca = "'C'"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = string.Empty,
                            vOperador = "exists",
                            vVL_Busca = "(select 1 from tb_pdv_cupom_x_vendarapida x " +
                                        "where x.cd_empresa = a.cd_empresa " +
                                        "and x.id_cupom = a.id_nfce " +
                                        "and x.cd_empresa = '" + (bsVenda.Current as TRegistro_VendaRapida).Cd_empresa.Trim() + "' " +
                                        "and x.id_vendarapida = " + (bsVenda.Current as TRegistro_VendaRapida).Id_vendarapidastr + ")"
                        }
                        }, "1") != null)
                    {
                        MessageBox.Show("Venda possui NFCe.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    //Verificar se venda tem Nota faturada
                    object obj = new CamadaDados.Faturamento.NotaFiscal.TCD_LanFaturamento().BuscarEscalar(
                                       new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = "isnull(a.st_registro, 'A')",
                                            vOperador = "<>",
                                            vVL_Busca = "'C'"
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = string.Empty,
                                            vOperador = "exists",
                                            vVL_Busca = "(select 1 from tb_fat_notafiscal_item x " +
                                                        "inner join TB_PDV_Pedido_X_VendaRapida y " +
                                                        "on x.nr_pedido = y.nr_pedido " +
                                                        "and x.cd_produto = y.cd_produto " +
                                                        "and x.id_pedidoitem = y.id_pedidoitem " +
                                                        "and x.cd_empresa = y.cd_empresa " +
                                                        "where x.cd_empresa = a.cd_empresa " +
                                                        "and x.nr_lanctofiscal = a.nr_lanctofiscal " +
                                                        "and y.cd_empresa = '" + (bsVenda.Current as TRegistro_VendaRapida).Cd_empresa.Trim() + "'" +
                                                        "and y.Id_VendaRapida = " + (bsVenda.Current as TRegistro_VendaRapida).Id_vendarapidastr + ") " 
                                        }
                                    }, "a.nr_notafiscal");
                    if (obj != null)
                    {
                        MessageBox.Show("Essa venda já está faturada. Nota Fiscal Nº" + obj.ToString(), "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    //Verificar se existe pedido amarrado nessa venda
                    CamadaDados.Faturamento.Pedido.TList_Pedido lPed =
                    new CamadaDados.Faturamento.Pedido.TCD_Pedido().Select(
                            new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = string.Empty,
                                vOperador = "exists",
                                vVL_Busca = "(select 1 from TB_PDV_Pedido_X_VendaRapida x " +
                                                      "where x.cd_empresa = a.cd_empresa " +
                                                      "and x.nr_pedido = a.nr_pedido " +
                                                      "and x.cd_empresa =  '" + (bsVenda.Current as TRegistro_VendaRapida).Cd_empresa.Trim() + "'" +
                                                      "and isnull(a.st_pedido, 'F') <> 'C' " +
                                                      "and x.id_vendarapida = " + (bsVenda.Current as TRegistro_VendaRapida).Id_vendarapidastr + ") " 
                            }
                        }, 0, string.Empty);
                    if (lPed.Count > 0)
                        lPed.ForEach(p => CamadaNegocio.Faturamento.Pedido.TCN_Pedido.Deleta_Pedido(p, null));
                    CamadaDados.Faturamento.Pedido.TRegistro_Pedido rPedProduto = null;
                    CamadaDados.Faturamento.Pedido.TRegistro_Pedido rPedServico = null;
                    try
                    {
                        Proc_Commoditties.TProcessarPedidoVendaRapida.ProcessarPedido((bsVenda.Current as TRegistro_VendaRapida).Cd_clifor,
                                                                                      (bsVenda.Current as TRegistro_VendaRapida).Cd_endereco,
                                                                                      false,
                                                                                      string.Empty,
                                                                                      lCfg[0],
                                                                                      (bsVenda.Current as TRegistro_VendaRapida).lItem,
                                                                                      ref rPedProduto,
                                                                                      ref rPedServico);
                        if (rPedProduto != null)
                        {
                            TCN_Pedido_X_VendaRapida.ProcessarPedido(rPedProduto, null);
                            //Buscar pedido
                            rPedProduto = CamadaNegocio.Faturamento.Pedido.TCN_Pedido.Busca_Registro_Pedido(rPedProduto.Nr_pedido.ToString(), null);
                            //Buscar itens pedido
                            CamadaNegocio.Faturamento.Pedido.TCN_Pedido.Busca_Pedido_Itens(rPedProduto, false, null);
                            //Se o CMI do pedido gerar financeiro
                            CamadaDados.Financeiro.Duplicata.TList_RegLanParcela lParcVinculado = new CamadaDados.Financeiro.Duplicata.TList_RegLanParcela();
                            //Buscar parcelas em aberto dos cupons que estao sendo vinculados
                            new CamadaDados.Financeiro.Duplicata.TCD_LanParcela().Select(
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
                                        vNM_Campo = "isnull(a.st_registro, 'A')",
                                        vOperador = "in",
                                        vVL_Busca = "('A', 'P')"
                                    },
                                    new TpBusca()
                                    {
                                        vNM_Campo = string.Empty,
                                        vOperador = "exists",
                                        vVL_Busca = "(select 1 from tb_pdv_cupomfiscal_x_duplicata x " +
                                                    "where x.cd_empresa = a.cd_empresa " +
                                                    "and x.nr_lancto = a.nr_lancto " +
                                                    "and x.cd_empresa = '" + (bsVenda.Current as TRegistro_VendaRapida).Cd_empresa.Trim() + "' " +
                                                    "and x.id_cupom = " + (bsVenda.Current as TRegistro_VendaRapida).Id_vendarapidastr + ")"
                                    }
                                }, 0, string.Empty, "a.dt_vencto, c.nm_clifor", string.Empty).ForEach(v => lParcVinculado.Add(v));
                            //Gerar Nota Fiscal
                            CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento rFat =
                                Proc_Commoditties.TProcessaPedFaturar.ProcessaPedFaturar(rPedProduto, true, lParcVinculado.Sum(p => p.Vl_atual));
                            //Vincular financeiro a Nota Fiscal
                            rFat.lParcAgrupar = lParcVinculado;
                            //Gravar Nota Fiscal
                            CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.GravarFaturamento(rFat, null, null);
                            using (srvNFE.TFGerenciarNFe fGerNfe = new srvNFE.TFGerenciarNFe())
                            {
                                fGerNfe.rNfe = CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.BuscarNF(rFat.Cd_empresa,
                                                                                                                rFat.Nr_lanctofiscalstr,
                                                                                                                null);
                                fGerNfe.ShowDialog();
                            }
                            if (!string.IsNullOrEmpty(rFat.rDuplicata.Cd_clifor))
                            {
                                //Imprimir Boleto
                                CamadaDados.Financeiro.Bloqueto.blListaTitulo lBloqueto =
                                    new CamadaDados.Financeiro.Bloqueto.TCD_Titulo().Select(
                                    new TpBusca[]
                                    {
                                                    new TpBusca()
                                                    {
                                                        vNM_Campo = "a.cd_empresa",
                                                        vOperador = "=",
                                                        vVL_Busca = "'" + rFat.Cd_empresa.Trim() + "'"
                                                    },
                                                    new TpBusca()
                                                    {
                                                        vNM_Campo = "a.nr_lancto",
                                                        vOperador = "=",
                                                        vVL_Busca = rFat.rDuplicata.Nr_lancto.ToString()
                                                    }
                                    }, 0, string.Empty);
                                if (lBloqueto.Count > 0)
                                    //Chamar tela de impressao para o bloqueto
                                    using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                                    {
                                        fImp.St_enabled_enviaremail = true;
                                        fImp.pCd_clifor = lBloqueto[0].Cd_sacado;
                                        fImp.pMensagem = "BOLETO(S) NF Nº" + rFat.Nr_notafiscalstr;
                                        if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                                            FormRelPadrao.TCN_LayoutBloqueto.Imprime_Bloqueto(false,
                                                                                              lBloqueto,
                                                                                              fImp.pSt_imprimir,
                                                                                              fImp.pSt_visualizar,
                                                                                              fImp.pSt_enviaremail,
                                                                                              fImp.pSt_exportPdf,
                                                                                              fImp.Path_exportPdf,
                                                                                              fImp.pDestinatarios,
                                                                                              "BOLETO(S) NF Nº" + rFat.Nr_notafiscalstr,
                                                                                              fImp.pDs_mensagem,
                                                                                              false);
                                    }
                            }
                        }
                        if (rPedServico != null)
                        {
                            TCN_Pedido_X_VendaRapida.ProcessarPedido(rPedServico, null);
                            //Buscar pedido
                            rPedServico = CamadaNegocio.Faturamento.Pedido.TCN_Pedido.Busca_Registro_Pedido(rPedServico.Nr_pedido.ToString(), null);
                            //Buscar itens pedido
                            CamadaNegocio.Faturamento.Pedido.TCN_Pedido.Busca_Pedido_Itens(rPedServico, false, null);
                            //Se o CMI do pedido gerar financeiro
                            CamadaDados.Financeiro.Duplicata.TList_RegLanParcela lParcVinculado = new CamadaDados.Financeiro.Duplicata.TList_RegLanParcela();
                            //Buscar parcelas em aberto dos cupons que estao sendo vinculados
                            new CamadaDados.Financeiro.Duplicata.TCD_LanParcela().Select(
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
                                        vNM_Campo = "isnull(a.st_registro, 'A')",
                                        vOperador = "in",
                                        vVL_Busca = "('A', 'P')"
                                    },
                                    new TpBusca()
                                    {
                                        vNM_Campo = string.Empty,
                                        vOperador = "exists",
                                        vVL_Busca = "(select 1 from tb_pdv_cupomfiscal_x_duplicata x " +
                                                    "where x.cd_empresa = a.cd_empresa " +
                                                    "and x.nr_lancto = a.nr_lancto " +
                                                    "and x.cd_empresa = '" + (bsVenda.Current as TRegistro_VendaRapida).Cd_empresa.Trim() + "' " +
                                                    "and x.id_cupom = " + (bsVenda.Current as TRegistro_VendaRapida).Id_vendarapidastr + ")"
                                    }
                                }, 0, string.Empty, "a.dt_vencto, c.nm_clifor", string.Empty).ForEach(v => lParcVinculado.Add(v));
                            //Gerar Nota Fiscal
                            CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento rFat =
                                Proc_Commoditties.TProcessaPedFaturar.ProcessaPedFaturar(rPedServico, true, lParcVinculado.Sum(p => p.Vl_atual));
                            //Vincular financeiro a Nota Fiscal
                            rFat.lParcAgrupar = lParcVinculado;
                            //Gravar Nota Fiscal
                            CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.GravarFaturamento(rFat, null, null);
                            //Buscar CfgNfe para a empresa
                            CamadaDados.Faturamento.Cadastros.TList_CfgNfe lCfgNfe =
                                CamadaNegocio.Faturamento.Cadastros.TCN_CfgNfe.Buscar(rFat.Cd_empresa,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      null);
                            if (lCfgNfe.Count > 0)
                            {
                                NFES.TGerarRPS.CriarArquivoRPS(lCfgNfe[0],
                                                               CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.Busca(rFat.Cd_empresa,
                                                                                                                             string.Empty,
                                                                                                                             string.Empty,
                                                                                                                             rFat.Nr_lanctofiscalstr,
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
                                                                                                                             null));
                                MessageBox.Show("Lote RPS enviado com sucesso. Aguarde alguns segundos e consulte o status do lote.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                if (!string.IsNullOrEmpty(rFat.rDuplicata.Cd_clifor))
                                {
                                    //Imprimir Boleto
                                    CamadaDados.Financeiro.Bloqueto.blListaTitulo lBloqueto =
                                        new CamadaDados.Financeiro.Bloqueto.TCD_Titulo().Select(
                                        new TpBusca[]
                                        {
                                                    new TpBusca()
                                                    {
                                                        vNM_Campo = "a.cd_empresa",
                                                        vOperador = "=",
                                                        vVL_Busca = "'" + rFat.Cd_empresa.Trim() + "'"
                                                    },
                                                    new TpBusca()
                                                    {
                                                        vNM_Campo = "a.nr_lancto",
                                                        vOperador = "=",
                                                        vVL_Busca = rFat.rDuplicata.Nr_lancto.ToString()
                                                    }
                                        }, 0, string.Empty);
                                    if (lBloqueto.Count > 0)
                                        //Chamar tela de impressao para o bloqueto
                                        using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                                        {
                                            fImp.St_enabled_enviaremail = true;
                                            fImp.pCd_clifor = lBloqueto[0].Cd_sacado;
                                            fImp.pMensagem = "BOLETO(S) NF Nº" + rFat.Nr_notafiscalstr;
                                            if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                                                FormRelPadrao.TCN_LayoutBloqueto.Imprime_Bloqueto(false,
                                                                                                  lBloqueto,
                                                                                                  fImp.pSt_imprimir,
                                                                                                  fImp.pSt_visualizar,
                                                                                                  fImp.pSt_enviaremail,
                                                                                                  fImp.pSt_exportPdf,
                                                                                                  fImp.Path_exportPdf,
                                                                                                  fImp.pDestinatarios,
                                                                                                  "BOLETO(S) NF Nº" + rFat.Nr_notafiscalstr,
                                                                                                  fImp.pDs_mensagem,
                                                                                                  false);
                                        }
                                }
                            }
                        }
                        return;
                    }
                    catch (Exception ex)
                    {
                        if (rPedProduto != null)
                            CamadaNegocio.Faturamento.Pedido.TCN_Pedido.Deleta_Pedido(rPedProduto, null);
                        if (rPedServico != null)
                            CamadaNegocio.Faturamento.Pedido.TCN_Pedido.Deleta_Pedido(rPedServico, null);
                        MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            using (PDV.TFGerarCupomNFe fGerar = new PDV.TFGerarCupomNFe())
            {
                if (fGerar.ShowDialog() == DialogResult.OK)
                    if (fGerar.lItens != null)
                    {
                        CamadaDados.Faturamento.Pedido.TRegistro_Pedido rPedProduto = null;
                        CamadaDados.Faturamento.Pedido.TRegistro_Pedido rPedServico = null;
                        try
                        {
                            //Buscar configuracao
                            lCfg = CamadaNegocio.Faturamento.Cadastros.TCN_CFGCupomFiscal.Buscar(fGerar.lItens[0].Cd_empresa, null);
                            if (lCfg.Count.Equals(0))
                            {
                                MessageBox.Show("Não existe configuração para realizar venda na empresa " + fGerar.lItens[0].Cd_empresa.Trim() + ".",
                                    "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                            string pCd_clifor = fGerar.Cd_clifor;
                            if (string.IsNullOrEmpty(pCd_clifor))
                            {
                                DataRowView linha = FormBusca.UtilPesquisa.BTN_BuscaClifor(null, string.Empty);
                                if (linha != null)
                                    pCd_clifor = linha["cd_clifor"].ToString();
                            }
                            if (!string.IsNullOrEmpty(pCd_clifor))
                            {
                                //Buscar endereco
                                CamadaDados.Financeiro.Cadastros.TList_CadEndereco lEnd =
                                    CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Buscar(pCd_clifor,
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
                                                                                              0,
                                                                                              null);
                                string pCd_endereco = string.Empty;
                                if (lEnd.Count.Equals(1))
                                    pCd_endereco = lEnd[0].Cd_endereco;
                                else
                                {
                                    string vColunas = "a.ds_endereco|Endereço|200;" +
                                                      "a.cd_endereco|Codigo|80;" +
                                                      "a.bairro|Bairro|80;" +
                                                      "a.insc_estadual|Insc. Estadual|80";
                                    DataRowView linha = UtilPesquisa.BTN_BUSCA(vColunas, null, new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco(), "a.cd_clifor|=|'" + pCd_clifor.Trim() + "'");
                                    if (linha != null)
                                        pCd_endereco = linha["cd_endereco"].ToString();
                                }
                                if (string.IsNullOrEmpty(pCd_endereco))
                                {
                                    MessageBox.Show("Obrigatorio informar endereço cliente NFe.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                                Proc_Commoditties.TProcessarPedidoVendaRapida.ProcessarPedido(pCd_clifor,
                                                                                              pCd_endereco,
                                                                                              false,
                                                                                              string.Empty,
                                                                                              lCfg[0],
                                                                                              fGerar.lItens,
                                                                                              ref rPedProduto,
                                                                                              ref rPedServico);
                                if (rPedProduto != null)
                                {
                                    TCN_Pedido_X_VendaRapida.ProcessarPedido(rPedProduto, null);
                                    //Buscar pedido
                                    rPedProduto = CamadaNegocio.Faturamento.Pedido.TCN_Pedido.Busca_Registro_Pedido(rPedProduto.Nr_pedido.ToString(), null);
                                    //Buscar itens pedido
                                    CamadaNegocio.Faturamento.Pedido.TCN_Pedido.Busca_Pedido_Itens(rPedProduto, false, null);
                                    //Se o CMI do pedido gerar financeiro
                                    CamadaDados.Financeiro.Duplicata.TList_RegLanParcela lParcVinculado = new CamadaDados.Financeiro.Duplicata.TList_RegLanParcela();
                                    //Buscar parcelas em aberto dos cupons que estao sendo vinculados
                                    string vId_venda = string.Empty;
                                    string virg = string.Empty;
                                    fGerar.lItens.GroupBy(p => p.Id_vendarapida,
                                        (aux, cupom) =>
                                            new
                                            {
                                                id_cupom = aux
                                            }).ToList().ForEach(p =>
                                            {
                                                vId_venda += virg + p.id_cupom.Value.ToString();
                                                virg = ",";
                                            });
                                    new CamadaDados.Financeiro.Duplicata.TCD_LanParcela().Select(
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
                                                vNM_Campo = "isnull(a.st_registro, 'A')",
                                                vOperador = "in",
                                                vVL_Busca = "('A', 'P')"
                                            },
                                            new TpBusca()
                                            {
                                                vNM_Campo = string.Empty,
                                                vOperador = "exists",
                                                vVL_Busca = "(select 1 from tb_pdv_cupomfiscal_x_duplicata x " +
                                                            "where x.cd_empresa = a.cd_empresa " +
                                                            "and x.nr_lancto = a.nr_lancto " +
                                                            "and x.cd_empresa = '" + fGerar.lItens[0].Cd_empresa.Trim() + "' " +
                                                            "and x.id_cupom in(" + vId_venda + "))"
                                            }
                                        }, 0, string.Empty, "a.dt_vencto, c.nm_clifor", string.Empty).ForEach(v => lParcVinculado.Add(v));
                                    //Gerar Nota Fiscal
                                    CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento rFat =
                                        Proc_Commoditties.TProcessaPedFaturar.ProcessaPedFaturar(rPedProduto, true, lParcVinculado.Sum(p => p.Vl_atual));
                                    //Vincular financeiro a Nota Fiscal
                                    rFat.lParcAgrupar = lParcVinculado;
                                    //Gravar Nota Fiscal
                                    CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.GravarFaturamento(rFat, null, null);
                                    using (srvNFE.TFGerenciarNFe fGerNfe = new srvNFE.TFGerenciarNFe())
                                    {
                                        fGerNfe.rNfe = CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.BuscarNF(rFat.Cd_empresa,
                                                                                                                        rFat.Nr_lanctofiscalstr,
                                                                                                                        null);
                                        fGerNfe.ShowDialog();
                                    }
                                    if (rFat.Duplicata.Count > 0)
                                    {
                                        //Imprimir Boleto
                                        CamadaDados.Financeiro.Bloqueto.blListaTitulo lBloqueto =
                                            new CamadaDados.Financeiro.Bloqueto.TCD_Titulo().Select(
                                            new TpBusca[]
                                            {
                                                    new TpBusca()
                                                    {
                                                        vNM_Campo = "a.cd_empresa",
                                                        vOperador = "=",
                                                        vVL_Busca = "'" + rFat.Cd_empresa.Trim() + "'"
                                                    },
                                                    new TpBusca()
                                                    {
                                                        vNM_Campo = "a.nr_lancto",
                                                        vOperador = "=",
                                                        vVL_Busca = rFat.Duplicata[0].Nr_lancto.ToString()
                                                    }
                                            }, 0, string.Empty);
                                        if (lBloqueto.Count > 0)
                                            //Chamar tela de impressao para o bloqueto
                                            using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                                            {
                                                fImp.St_enabled_enviaremail = true;
                                                fImp.pCd_clifor = lBloqueto[0].Cd_sacado;
                                                fImp.pMensagem = "BOLETO(S) NF Nº" + rFat.Nr_notafiscalstr;
                                                if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                                                    FormRelPadrao.TCN_LayoutBloqueto.Imprime_Bloqueto(false,
                                                                                                      lBloqueto,
                                                                                                      fImp.pSt_imprimir,
                                                                                                      fImp.pSt_visualizar,
                                                                                                      fImp.pSt_enviaremail,
                                                                                                      fImp.pSt_exportPdf,
                                                                                                      fImp.Path_exportPdf,
                                                                                                      fImp.pDestinatarios,
                                                                                                      "BOLETO(S) NF Nº" + rFat.Nr_notafiscalstr,
                                                                                                      fImp.pDs_mensagem,
                                                                                                      false);
                                            }
                                    }
                                }
                                if (rPedServico != null)
                                {
                                    TCN_Pedido_X_VendaRapida.ProcessarPedido(rPedServico, null);
                                    //Buscar pedido
                                    rPedServico = CamadaNegocio.Faturamento.Pedido.TCN_Pedido.Busca_Registro_Pedido(rPedServico.Nr_pedido.ToString(), null);
                                    //Buscar itens pedido
                                    CamadaNegocio.Faturamento.Pedido.TCN_Pedido.Busca_Pedido_Itens(rPedServico, false, null);
                                    //Se o CMI do pedido gerar financeiro
                                    CamadaDados.Financeiro.Duplicata.TList_RegLanParcela lParcVinculado = new CamadaDados.Financeiro.Duplicata.TList_RegLanParcela();
                                    //Buscar parcelas em aberto dos cupons que estao sendo vinculados
                                    string vId_venda = string.Empty;
                                    string virg = string.Empty;
                                    fGerar.lItens.GroupBy(p => p.Id_vendarapida,
                                        (aux, cupom) =>
                                            new
                                            {
                                                id_cupom = aux
                                            }).ToList().ForEach(p =>
                                            {
                                                vId_venda += virg + p.id_cupom.Value.ToString();
                                                virg = ",";
                                            });
                                    new CamadaDados.Financeiro.Duplicata.TCD_LanParcela().Select(
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
                                                vNM_Campo = "isnull(a.st_registro, 'A')",
                                                vOperador = "in",
                                                vVL_Busca = "('A', 'P')"
                                            },
                                            new TpBusca()
                                            {
                                                vNM_Campo = string.Empty,
                                                vOperador = "exists",
                                                vVL_Busca = "(select 1 from tb_pdv_cupomfiscal_x_duplicata x " +
                                                            "where x.cd_empresa = a.cd_empresa " +
                                                            "and x.nr_lancto = a.nr_lancto " +
                                                            "and x.cd_empresa = '" + fGerar.lItens[0].Cd_empresa.Trim() + "' " +
                                                            "and x.id_cupom in(" + vId_venda + "))"
                                            }
                                        }, 0, string.Empty, "a.dt_vencto, c.nm_clifor", string.Empty).ForEach(v => lParcVinculado.Add(v));
                                    //Gerar Nota Fiscal
                                    CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento rFat =
                                        Proc_Commoditties.TProcessaPedFaturar.ProcessaPedFaturar(rPedServico, true, lParcVinculado.Sum(p => p.Vl_atual));
                                    //Vincular financeiro a Nota Fiscal
                                    rFat.lParcAgrupar = lParcVinculado;
                                    //Gravar Nota Fiscal
                                    CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.GravarFaturamento(rFat, null, null);
                                    //Buscar CfgNfe para a empresa
                                    CamadaDados.Faturamento.Cadastros.TList_CfgNfe lCfgNfe =
                                        CamadaNegocio.Faturamento.Cadastros.TCN_CfgNfe.Buscar(rFat.Cd_empresa,
                                                                                              string.Empty,
                                                                                              string.Empty,
                                                                                              null);
                                    if (lCfgNfe.Count > 0)
                                    {
                                        NFES.TGerarRPS.CriarArquivoRPS(lCfgNfe[0],
                                                                       CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.Busca(rFat.Cd_empresa,
                                                                                                                                     string.Empty,
                                                                                                                                     string.Empty,
                                                                                                                                     rFat.Nr_lanctofiscalstr,
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
                                                                                                                                     null));
                                        MessageBox.Show("Lote RPS enviado com sucesso. Aguarde alguns segundos e consulte o status do lote.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        if (!string.IsNullOrEmpty(rFat.rDuplicata.Cd_clifor))
                                        {
                                            //Imprimir Boleto
                                            CamadaDados.Financeiro.Bloqueto.blListaTitulo lBloqueto =
                                                new CamadaDados.Financeiro.Bloqueto.TCD_Titulo().Select(
                                                new TpBusca[]
                                                {
                                                    new TpBusca()
                                                    {
                                                        vNM_Campo = "a.cd_empresa",
                                                        vOperador = "=",
                                                        vVL_Busca = "'" + rFat.Cd_empresa.Trim() + "'"
                                                    },
                                                    new TpBusca()
                                                    {
                                                        vNM_Campo = "a.nr_lancto",
                                                        vOperador = "=",
                                                        vVL_Busca = rFat.rDuplicata.Nr_lancto.ToString()
                                                    }
                                                }, 0, string.Empty);
                                            if (lBloqueto.Count > 0)
                                                //Chamar tela de impressao para o bloqueto
                                                using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                                                {
                                                    fImp.St_enabled_enviaremail = true;
                                                    fImp.pCd_clifor = lBloqueto[0].Cd_sacado;
                                                    fImp.pMensagem = "BOLETO(S) NF Nº" + rFat.Nr_notafiscalstr;
                                                    if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                                                        FormRelPadrao.TCN_LayoutBloqueto.Imprime_Bloqueto(false,
                                                                                                          lBloqueto,
                                                                                                          fImp.pSt_imprimir,
                                                                                                          fImp.pSt_visualizar,
                                                                                                          fImp.pSt_enviaremail,
                                                                                                          fImp.pSt_exportPdf,
                                                                                                          fImp.Path_exportPdf,
                                                                                                          fImp.pDestinatarios,
                                                                                                          "BOLETO(S) NF Nº" + rFat.Nr_notafiscalstr,
                                                                                                          fImp.pDs_mensagem,
                                                                                                          false);
                                                }
                                        }
                                    }
                                }
                            }
                            else
                                MessageBox.Show("Obrigatorio informar cliente do pedido.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            if (rPedProduto != null)
                                CamadaNegocio.Faturamento.Pedido.TCN_Pedido.Deleta_Pedido(rPedProduto, null);
                            if (rPedServico != null)
                                CamadaNegocio.Faturamento.Pedido.TCN_Pedido.Deleta_Pedido(rPedServico, null);
                            MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                        MessageBox.Show("Não existe venda selecionada para gerar NFe.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        
        private void GerarNFCe()
        {
            if (bsVenda.Current == null ? false : 
                MessageBox.Show("Gerar NFCe da venda corrente?", "Pergunta", MessageBoxButtons.YesNo,
                 MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                if ((bsVenda.Current as TRegistro_VendaRapida).St_registro.ToUpper().Equals("C"))
                {
                    MessageBox.Show("Não é possivel gerar cupom de venda cancelada!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                //Verificar se existe configuração para emitir NFC-e
                object obj = new CamadaDados.Faturamento.Cadastros.TCD_CfgNfe().BuscarEscalar(
                                new TpBusca[]
                                {
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.cd_empresa",
                                        vOperador = "=",
                                        vVL_Busca = "'" + (bsVenda.Current as TRegistro_VendaRapida).Cd_empresa.Trim() + "'"
                                    }
                                }, "a.tp_ambiente_nfce");
                if (obj == null ? true : string.IsNullOrEmpty(obj.ToString()))
                {
                    MessageBox.Show("Empresa<" + (bsVenda.Current as TRegistro_VendaRapida).Cd_empresa.Trim() + "> não esta habilitada para emitir NFC-e.",
                                    "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                //Verificar se venda possui cupom
                if (new TCD_NFCe().BuscarEscalar(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = "isnull(a.st_registro, 'A')",
                            vOperador = "<>",
                            vVL_Busca = "'C'"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = string.Empty,
                            vOperador = "exists",
                            vVL_Busca = "(select 1 from tb_pdv_cupom_x_vendarapida x " +
                                        "where x.cd_empresa = a.cd_empresa " +
                                        "and x.id_cupom = a.id_nfce " +
                                        "and x.cd_empresa = '" + (bsVenda.Current as TRegistro_VendaRapida).Cd_empresa.Trim() + "' " +
                                        "and x.id_vendarapida = " + (bsVenda.Current as TRegistro_VendaRapida).Id_vendarapidastr + ")"
                        }
                    }, "1") != null)
                {
                    MessageBox.Show("Venda possui NFCe.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                //Verificar se venda possui nfe
                if (new CamadaDados.Faturamento.NotaFiscal.TCD_LanFaturamento_Item().BuscarEscalar(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = "isnull(nf.st_registro, 'A')",
                            vOperador = "<>",
                            vVL_Busca = "'C'"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = string.Empty,
                            vOperador = "exists",
                            vVL_Busca = "(select 1 from tb_pdv_pedido_x_vendarapida x " +
                                        "where x.nr_pedido = a.nr_pedido " +
                                        "and x.cd_produto = a.cd_produto " +
                                        "and x.id_pedidoitem = a.id_pedidoitem " +
                                        "and x.cd_empresa = '" + (bsVenda.Current as TRegistro_VendaRapida).Cd_empresa.Trim() + "' " +
                                        "and x.id_vendarapida = " + (bsVenda.Current as TRegistro_VendaRapida).Id_vendarapidastr + ")"
                        }
                    }, "1") != null)
                {
                    MessageBox.Show("Venda possui Faturamento.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                try
                {
                    //Processar cupom fiscal
                    PDV.TDadosCupom dados = new PDV.TDadosCupom();
                    //Buscar dados PDV
                    obj = new CamadaDados.Faturamento.Cadastros.TCD_PontoVenda().BuscarEscalar(
                            new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = "a.cd_terminal",
                                    vOperador = "=",
                                    vVL_Busca = "'" + Utils.Parametros.pubTerminal.Trim() + "'"
                                }
                            }, "a.id_pdv");
                    if (obj == null)
                    {
                        MessageBox.Show("Não existe PDV cadastrado para o terminal " + Utils.Parametros.pubTerminal,
                                        "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if (new TCD_Sessao().BuscarEscalar(
                        new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = "isnull(a.st_registro, 'A')",
                                vOperador = "=",
                                vVL_Busca = "'A'"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "a.id_pdv",
                                vOperador = "=",
                                vVL_Busca = obj.ToString()
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "a.login",
                                vOperador = "=",
                                vVL_Busca = "'" + Utils.Parametros.pubLogin + "'"
                            }
                        }, "1") == null)
                        TCN_Sessao.AbrirSessao(
                            new TRegistro_Sessao()
                            {
                                Id_pdvstr = obj.ToString(),
                                Login = Utils.Parametros.pubLogin
                            }, null);
                    //Buscar sessao aberta
                    dados.rSessao = TCN_Sessao.Buscar(obj.ToString(),
                                                      string.Empty,
                                                      Utils.Parametros.pubLogin,
                                                      string.Empty,
                                                      string.Empty,
                                                      string.Empty,
                                                      "'A'",
                                                      1,
                                                      null)[0];
                    dados.lItens = (bsVenda.Current as TRegistro_VendaRapida).lItem;
                    dados.Cd_clifor = (bsVenda.Current as TRegistro_VendaRapida).Cd_clifor;
                    dados.Nm_clifor = (bsVenda.Current as TRegistro_VendaRapida).Nm_clifor;
                    dados.CpfCgc = string.Empty;
                    dados.Endereco = string.Empty;
                    dados.Mensagem = string.Empty;
                    dados.lPortador = new List<CamadaDados.Financeiro.Cadastros.TRegistro_CadPortador>();
                    dados.St_vendacombustivel = false;
                    dados.St_cupomavulso = true;
                    dados.St_agruparProduto = false;

                    TRegistro_NFCe rNFCe = new PDV.TGerenciarCupom().GerarNFCe(dados, false);
                    if (rNFCe != null)
                        if (!rNFCe.St_contingencia)
                            using (NFCe.TFGerenciarNFCe fGerNfe = new NFCe.TFGerenciarNFCe())
                            {
                                fGerNfe.rNFCe = TCN_NFCe.BuscarNFCe(rNFCe.Cd_empresa,
                                                                    rNFCe.Id_nfcestr,
                                                                    null);
                                fGerNfe.ShowDialog();
                            }
                        else
                        {
                            FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                            Rel.Altera_Relatorio = Altera_Relatorio;
                            BindingSource dts = new BindingSource();
                            dts.DataSource = new TList_NFCe_Item();
                            Rel.DTS_Relatorio = dts;// bsItens;
                            //DTS Cupom
                            BindingSource bsNFCe = new BindingSource();
                            bsNFCe.DataSource = TCN_NFCe.BuscarNFCe(rNFCe.Cd_empresa,
                                                                    rNFCe.Id_nfcestr,
                                                                    null);
                            NFCe.TGerarQRCode.GerarQRCode2(bsNFCe.Current as TRegistro_NFCe);
                            Rel.Adiciona_DataSource("DTS_NFCE", bsNFCe);
                            //Buscar Empresa
                            BindingSource bsEmpresa = new BindingSource();
                            bsEmpresa.DataSource = new CamadaDados.Diversos.TList_CadEmpresa { (bsNFCe.Current as TRegistro_NFCe).rEmpresa };
                            Rel.Adiciona_DataSource("DTS_EMP", bsEmpresa);
                            //Forma Pagamento
                            BindingSource bsPagto = new BindingSource();
                            List<TRegistro_MovCaixa> lPagto = new List<TRegistro_MovCaixa>();
                            new TCD_CaixaPDV().SelectMovCaixa(
                                new TpBusca[]
                                {
                                    new TpBusca()
                                    {
                                        vNM_Campo = string.Empty,
                                        vOperador = "exists",
                                        vVL_Busca = "(select 1 from tb_pdv_cupom_x_vendarapida x " +
                                                    "where x.cd_empresa = a.cd_empresa " +
                                                    "and x.id_vendarapida = a.id_cupom " +
                                                    "and x.cd_empresa = '" + (bsNFCe.Current as TRegistro_NFCe).Cd_empresa.Trim() + "' " +
                                                    "and x.id_cupom = " + (bsNFCe.Current as TRegistro_NFCe).Id_nfcestr + ")"
                                    }
                                }, string.Empty).GroupBy(v => v.Tp_portador,
                                                    (aux, venda) =>
                                                        new
                                                        {
                                                            tp_portador = aux,
                                                            Vl_recebido = venda.Sum(x => x.Vl_recebido),
                                                            Vl_troco_ch = venda.Sum(x => x.Vl_troco_ch),
                                                            Vl_troco_dh = venda.Sum(x => x.Vl_troco_dh)
                                                        }).ToList().ForEach(x => lPagto.Add(new TRegistro_MovCaixa()
                                                        {
                                                            Tp_portador = x.tp_portador,
                                                            Vl_recebido = x.Vl_recebido,
                                                            Vl_troco_ch = x.Vl_troco_ch,
                                                            Vl_troco_dh = x.Vl_troco_dh
                                                        }));
                            CamadaDados.Financeiro.Duplicata.TList_RegLanDuplicata lDup =
                                    new CamadaDados.Financeiro.Duplicata.TCD_LanDuplicata().Select(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = string.Empty,
                                            vOperador = "exists",
                                            vVL_Busca = "(select 1 from TB_PDV_CupomFiscal_X_Duplicata x " +
                                                        "inner join TB_PDV_Cupom_X_VendaRapida y " +
                                                        "on x.cd_empresa = y.cd_empresa " +
                                                        "and x.id_cupom = y.id_vendarapida " +
                                                        "where x.cd_empresa = a.cd_empresa " +
                                                        "and x.Nr_Lancto = a.Nr_Lancto " +
                                                        "and y.cd_empresa = '" + (bsNFCe.Current as TRegistro_NFCe).Cd_empresa.Trim() + "' " +
                                                        "and y.id_cupom = " + (bsNFCe.Current as TRegistro_NFCe).Id_nfcestr + ")"
                                        }
                                    }, 1, string.Empty);
                            if (lDup.Count > 0)
                                lPagto.Add(new TRegistro_MovCaixa()
                                {
                                    Tp_portador = "05",
                                    Vl_recebido = lDup[0].Vl_documento
                                });
                            bsPagto.DataSource = lPagto;
                            Rel.Adiciona_DataSource("DTS_PAGTO", bsPagto);
                            //Parametros
                            Rel.Parametros_Relatorio.Add("TOT_IMP_APROX", (bsNFCe.Current as TRegistro_NFCe).lItem.Sum(p => p.Vl_imposto_Aprox));
                            Rel.Parametros_Relatorio.Add("QTD_ITENS", (bsNFCe.Current as TRegistro_NFCe).lItem.Count);
                            Rel.Parametros_Relatorio.Add("TOT_SUBTOTAL", (bsNFCe.Current as TRegistro_NFCe).lItem.Sum(p => p.Vl_subtotal));
                            Rel.Parametros_Relatorio.Add("TOT_ACRESCIMO", (bsNFCe.Current as TRegistro_NFCe).lItem.Sum(p => p.Vl_acrescimo));
                            Rel.Parametros_Relatorio.Add("TOT_DESCONTO", (bsNFCe.Current as TRegistro_NFCe).lItem.Sum(p => p.Vl_desconto));
                            Rel.Parametros_Relatorio.Add("ST_VIAEMPRESA", "N");
                            obj = new CamadaDados.Faturamento.NFCe.TCD_LoteNFCe().BuscarEscalar(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = string.Empty,
                                            vOperador = "exists",
                                            vVL_Busca = "(select 1 from TB_FAT_Lote_X_NFCe x " +
                                                        "where x.cd_empresa = a.cd_empresa " +
                                                        "and x.id_lote = a.id_lote " +
                                                        "and x.status = '100')"
                                        }
                                    }, "a.tp_ambiente");
                            Rel.Parametros_Relatorio.Add("TP_AMBIENTE", obj == null ? string.Empty : obj.ToString());
                            string dadoscf = TCN_NFCe.BuscarPlacaKM((bsNFCe.Current as TRegistro_NFCe).Cd_empresa,
                                                                    (bsNFCe.Current as TRegistro_NFCe).Id_nfcestr,
                                                                    null);
                            if (!string.IsNullOrEmpty(dadoscf))
                            {
                                string[] linhas = dadoscf.Split(new char[] { ':' });
                                string placa = string.Empty;
                                string km = string.Empty;
                                string frota = string.Empty;
                                string requisicao = string.Empty;
                                string nm_motorista = string.Empty;
                                string cpf_motorista = string.Empty;
                                string media = string.Empty;
                                string virg = string.Empty;
                                foreach (string s in linhas)
                                {
                                    string[] colunas = s.Split(new char[] { '/' });
                                    placa += virg + colunas[0];
                                    km += virg + colunas[1];
                                    frota += virg + colunas[2];
                                    requisicao += virg + colunas[3];
                                    nm_motorista += virg + colunas[4];
                                    cpf_motorista += virg + colunas[5];
                                    media += virg + colunas[6];
                                    virg = ",";
                                }
                                if (!string.IsNullOrEmpty(placa))
                                    Rel.Parametros_Relatorio.Add("PLACA", placa);
                                if (!string.IsNullOrEmpty(km))
                                    Rel.Parametros_Relatorio.Add("KM", km);
                                if (!string.IsNullOrEmpty(media))
                                    Rel.Parametros_Relatorio.Add("MEDIA", media + " KM/LT");
                                if (!string.IsNullOrEmpty(frota))
                                    Rel.Parametros_Relatorio.Add("FROTA", frota);
                                if (!string.IsNullOrEmpty(requisicao))
                                    Rel.Parametros_Relatorio.Add("REQUISICAO", requisicao);
                                if (!string.IsNullOrEmpty(nm_motorista))
                                    Rel.Parametros_Relatorio.Add("NM_MOTORISTA", nm_motorista);
                                if (!string.IsNullOrEmpty(cpf_motorista))
                                    Rel.Parametros_Relatorio.Add("CPF_MOTORISTA", cpf_motorista);
                            }
                            Rel.Nome_Relatorio = "DANFE_NFCE";
                            Rel.NM_Classe = "TFConsultaFrenteCaixa";
                            Rel.Modulo = "FAT";
                            Rel.Ident = "DANFE_NFCE";
                            if (CamadaNegocio.ConfigGer.TCN_CadParamGer.BuscaVlBool("ST_IMP_DANFE_NFCE_DETALHADA", null))
                            {
                                BindingSource bsItens = new BindingSource();
                                bsItens.DataSource = (bsNFCe.Current as TRegistro_NFCe).lItem;
                                Rel.DTS_Relatorio = bsItens;
                            }
                            if ((bsNFCe.Current as TRegistro_NFCe).Id_contingencia.HasValue)
                                if (Rel.Parametros_Relatorio.ContainsKey("ST_VIAEMPRESA"))
                                    Rel.Parametros_Relatorio["ST_VIAEMPRESA"] = "S";
                                else
                                    Rel.Parametros_Relatorio.Add("ST_VIAEMPRESA", "S");
                            //Verificar se existe Impressora padrão para o PDV
                            obj = new CamadaDados.Faturamento.Cadastros.TCD_PontoVenda().BuscarEscalar(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.cd_terminal",
                                            vOperador = "=",
                                            vVL_Busca = "'" + Utils.Parametros.pubTerminal.Trim() + "'"
                                        }
                                    }, "a.impressorapadrao");
                            string print = obj == null ? string.Empty : obj.ToString();
                            if (string.IsNullOrEmpty(print))
                                using (Parametros.Diversos.TFListaImpressoras fLista = new Parametros.Diversos.TFListaImpressoras())
                                {
                                    if (fLista.ShowDialog() == DialogResult.OK)
                                        if (!string.IsNullOrEmpty(fLista.Impressora))
                                            print = fLista.Impressora;
                                }
                            //Imprimir
                            if (!string.IsNullOrEmpty(print))
                            {
                                Rel.ImprimiGraficoReduzida(print,
                                                           true,
                                                           false,
                                                           null,
                                                           string.Empty,
                                                           string.Empty,
                                                           1);
                                if ((bsNFCe.Current as TRegistro_NFCe).Id_contingencia.HasValue &&
                                    rNFCe.rCfgNFCe.Tp_ambiente_nfce.Equals(1))
                                    Rel.ImprimiGraficoReduzida(print,
                                                               true,
                                                               false,
                                                               null,
                                                               string.Empty,
                                                               string.Empty,
                                                               1);
                            }
                        }
                    return;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                using (PDV.TFGerarCupomNFe fGerar = new PDV.TFGerarCupomNFe())
                {
                    fGerar.St_NFCe = true;
                    if (fGerar.ShowDialog() == DialogResult.OK)
                        if (fGerar.lItens != null)
                            if (fGerar.lItens.Count > 0)
                            {
                                try
                                {
                                    //Processar cupom fiscal
                                    PDV.TDadosCupom dados = new PDV.TDadosCupom();
                                    //Buscar dados PDV
                                    object obj = new CamadaDados.Faturamento.Cadastros.TCD_PontoVenda().BuscarEscalar(
                                                    new TpBusca[]
                                                    {
                                                        new TpBusca()
                                                        {
                                                            vNM_Campo = "a.cd_terminal",
                                                            vOperador = "=",
                                                            vVL_Busca = "'" + Utils.Parametros.pubTerminal.Trim() + "'"
                                                        }
                                                    }, "a.id_pdv");
                                    if (obj == null)
                                    {
                                        MessageBox.Show("Não existe PDV cadastrado para o terminal " + Utils.Parametros.pubTerminal,
                                                        "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        return;
                                    }
                                    if (new TCD_Sessao().BuscarEscalar(
                                        new TpBusca[]
                                        {
                                            new TpBusca()
                                            {
                                                vNM_Campo = "isnull(a.st_registro, 'A')",
                                                vOperador = "=",
                                                vVL_Busca = "'A'"
                                            },
                                            new TpBusca()
                                            {
                                                vNM_Campo = "a.id_pdv",
                                                vOperador = "=",
                                                vVL_Busca = obj.ToString()
                                            },
                                            new TpBusca()
                                            {
                                                vNM_Campo = "a.login",
                                                vOperador = "=",
                                                vVL_Busca = "'" + Utils.Parametros.pubLogin + "'"
                                            }
                                        }, "1") == null)
                                        CamadaNegocio.Faturamento.PDV.TCN_Sessao.AbrirSessao(
                                            new TRegistro_Sessao()
                                            {
                                                Id_pdvstr = obj.ToString(),
                                                Login = Utils.Parametros.pubLogin
                                            }, null);
                                    //Buscar sessao aberta
                                    dados.rSessao = TCN_Sessao.Buscar(obj.ToString(),
                                                                      string.Empty,
                                                                      Utils.Parametros.pubLogin,
                                                                      string.Empty,
                                                                      string.Empty,
                                                                      string.Empty,
                                                                      "'A'",
                                                                      1,
                                                                      null)[0];
                                    dados.lItens = fGerar.lItens;
                                    dados.Cd_clifor = string.Empty;
                                    dados.Nm_clifor = string.Empty;
                                    dados.CpfCgc = string.Empty;
                                    dados.Endereco = string.Empty;
                                    dados.Mensagem = string.Empty;
                                    dados.lPortador = new List<CamadaDados.Financeiro.Cadastros.TRegistro_CadPortador>();
                                    dados.St_vendacombustivel = false;
                                    dados.St_cupomavulso = true;
                                    dados.St_agruparProduto = false;

                                    PDV.TGerenciarCupom.ProcessarCupom(ref dados);
                                    TRegistro_NFCe rNFCe = new PDV.TGerenciarCupom().GerarNFCe(dados, false);
                                    if (rNFCe != null)
                                        if (!rNFCe.St_contingencia)
                                            using (NFCe.TFGerenciarNFCe fGerNfe = new NFCe.TFGerenciarNFCe())
                                            {
                                                fGerNfe.rNFCe = TCN_NFCe.BuscarNFCe(rNFCe.Cd_empresa,
                                                                                    rNFCe.Id_nfcestr,
                                                                                    null);
                                                fGerNfe.ShowDialog();
                                            }
                                        else
                                        {
                                            FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                                            Rel.Altera_Relatorio = Altera_Relatorio;
                                            BindingSource dts = new BindingSource();
                                            dts.DataSource = new TList_NFCe_Item();
                                            Rel.DTS_Relatorio = dts;// bsItens;
                                            //DTS Cupom
                                            BindingSource bsNFCe = new BindingSource();
                                            bsNFCe.DataSource = TCN_NFCe.Buscar(rNFCe.Id_nfcestr,
                                                                                string.Empty,
                                                                                rNFCe.Cd_empresa,
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
                                                                                false,
                                                                                string.Empty,
                                                                                string.Empty,
                                                                                1,
                                                                                null);
                                            (bsNFCe.Current as TRegistro_NFCe).lItem = TCN_NFCe_Item.Buscar((bsNFCe.Current as TRegistro_NFCe).Id_nfcestr,
                                                                                                            (bsNFCe.Current as TRegistro_NFCe).Cd_empresa,
                                                                                                            string.Empty,
                                                                                                            null);
                                            NFCe.TGerarQRCode.GerarQRCode2(bsNFCe.Current as TRegistro_NFCe);
                                            Rel.Adiciona_DataSource("DTS_NFCE", bsNFCe);
                                            //Buscar Empresa
                                            BindingSource bsEmpresa = new BindingSource();
                                            bsEmpresa.DataSource = CamadaNegocio.Diversos.TCN_CadEmpresa.Busca(rNFCe.Cd_empresa,
                                                                                                                string.Empty,
                                                                                                                string.Empty,
                                                                                                                null);
                                            Rel.Adiciona_DataSource("DTS_EMP", bsEmpresa);
                                            //Forma Pagamento
                                            BindingSource bsPagto = new BindingSource();
                                            List<TRegistro_MovCaixa> lPagto = new List<TRegistro_MovCaixa>();
                                            new TCD_CaixaPDV().SelectMovCaixa(
                                                new TpBusca[]
                                                {
                                                    new TpBusca()
                                                    {
                                                        vNM_Campo = string.Empty,
                                                        vOperador = "exists",
                                                        vVL_Busca = "(select 1 from tb_pdv_cupom_x_vendarapida x " +
                                                                    "where x.cd_empresa = a.cd_empresa " +
                                                                    "and x.id_vendarapida = a.id_cupom " +
                                                                    "and x.cd_empresa = '" + (bsNFCe.Current as TRegistro_NFCe).Cd_empresa.Trim() + "' " +
                                                                    "and x.id_cupom = " + (bsNFCe.Current as TRegistro_NFCe).Id_nfcestr + ")"
                                                    }
                                                }, string.Empty).GroupBy(v => v.Tp_portador,
                                                                    (aux, venda) =>
                                                                        new
                                                                        {
                                                                            tp_portador = aux,
                                                                            Vl_recebido = venda.Sum(x => x.Vl_recebido),
                                                                            Vl_troco_ch = venda.Sum(x => x.Vl_troco_ch),
                                                                            Vl_troco_dh = venda.Sum(x => x.Vl_troco_dh)
                                                                        }).ToList().ForEach(x => lPagto.Add(new TRegistro_MovCaixa()
                                                                        {
                                                                            Tp_portador = x.tp_portador,
                                                                            Vl_recebido = x.Vl_recebido,
                                                                            Vl_troco_ch = x.Vl_troco_ch,
                                                                            Vl_troco_dh = x.Vl_troco_dh
                                                                        }));
                                            CamadaDados.Financeiro.Duplicata.TList_RegLanDuplicata lDup =
                                                    new CamadaDados.Financeiro.Duplicata.TCD_LanDuplicata().Select(
                                                    new TpBusca[]
                                                    {
                                                        new TpBusca()
                                                        {
                                                            vNM_Campo = string.Empty,
                                                            vOperador = "exists",
                                                            vVL_Busca = "(select 1 from TB_PDV_CupomFiscal_X_Duplicata x " +
                                                                        "inner join TB_PDV_Cupom_X_VendaRapida y " +
                                                                        "on x.cd_empresa = y.cd_empresa " +
                                                                        "and x.id_cupom = y.id_vendarapida " +
                                                                        "where x.cd_empresa = a.cd_empresa " +
                                                                        "and x.Nr_Lancto = a.Nr_Lancto " +
                                                                        "and y.cd_empresa = '" + (bsNFCe.Current as TRegistro_NFCe).Cd_empresa.Trim() + "' " +
                                                                        "and y.id_cupom = " + (bsNFCe.Current as TRegistro_NFCe).Id_nfcestr + ")"
                                                        }
                                                    }, 1, string.Empty);
                                            if (lDup.Count > 0)
                                                lPagto.Add(new TRegistro_MovCaixa()
                                                {
                                                    Tp_portador = "05",
                                                    Vl_recebido = lDup[0].Vl_documento
                                                });
                                            bsPagto.DataSource = lPagto;
                                            Rel.Adiciona_DataSource("DTS_PAGTO", bsPagto);
                                            //Parametros
                                            Rel.Parametros_Relatorio.Add("TOT_IMP_APROX", (bsNFCe.Current as TRegistro_NFCe).lItem.Sum(p => p.Vl_imposto_Aprox));
                                            Rel.Parametros_Relatorio.Add("QTD_ITENS", (bsNFCe.Current as TRegistro_NFCe).lItem.Count);
                                            Rel.Parametros_Relatorio.Add("TOT_SUBTOTAL", (bsNFCe.Current as TRegistro_NFCe).lItem.Sum(p => p.Vl_subtotal));
                                            Rel.Parametros_Relatorio.Add("TOT_ACRESCIMO", (bsNFCe.Current as TRegistro_NFCe).lItem.Sum(p => p.Vl_acrescimo));
                                            Rel.Parametros_Relatorio.Add("TOT_DESCONTO", (bsNFCe.Current as TRegistro_NFCe).lItem.Sum(p => p.Vl_desconto));
                                            Rel.Parametros_Relatorio.Add("ST_VIAEMPRESA", "N");
                                            obj = new CamadaDados.Faturamento.NFCe.TCD_LoteNFCe().BuscarEscalar(
                                                    new TpBusca[]
                                                    {
                                                        new TpBusca()
                                                        {
                                                            vNM_Campo = string.Empty,
                                                            vOperador = "exists",
                                                            vVL_Busca = "(select 1 from TB_FAT_Lote_X_NFCe x " +
                                                                        "where x.cd_empresa = a.cd_empresa " +
                                                                        "and x.id_lote = a.id_lote " +
                                                                        "and x.status = '100')"
                                                        }
                                                    }, "a.tp_ambiente");
                                            Rel.Parametros_Relatorio.Add("TP_AMBIENTE", obj == null ? string.Empty : obj.ToString());
                                            string dadoscf = TCN_NFCe.BuscarPlacaKM((bsNFCe.Current as TRegistro_NFCe).Cd_empresa,
                                                                                    (bsNFCe.Current as TRegistro_NFCe).Id_nfcestr,
                                                                                    null);
                                            if (!string.IsNullOrEmpty(dadoscf))
                                            {
                                                string[] linhas = dadoscf.Split(new char[] { ':' });
                                                string placa = string.Empty;
                                                string km = string.Empty;
                                                string frota = string.Empty;
                                                string requisicao = string.Empty;
                                                string nm_motorista = string.Empty;
                                                string cpf_motorista = string.Empty;
                                                string media = string.Empty;
                                                string virg = string.Empty;
                                                foreach (string s in linhas)
                                                {
                                                    string[] colunas = s.Split(new char[] { '/' });
                                                    placa += virg + colunas[0];
                                                    km += virg + colunas[1];
                                                    frota += virg + colunas[2];
                                                    requisicao += virg + colunas[3];
                                                    nm_motorista += virg + colunas[4];
                                                    cpf_motorista += virg + colunas[5];
                                                    media += virg + colunas[6];
                                                    virg = ",";
                                                }
                                                if (!string.IsNullOrEmpty(placa))
                                                    Rel.Parametros_Relatorio.Add("PLACA", placa);
                                                if (!string.IsNullOrEmpty(km))
                                                    Rel.Parametros_Relatorio.Add("KM", km);
                                                if (!string.IsNullOrEmpty(media))
                                                    Rel.Parametros_Relatorio.Add("MEDIA", media + " KM/LT");
                                                if (!string.IsNullOrEmpty(frota))
                                                    Rel.Parametros_Relatorio.Add("FROTA", frota);
                                                if (!string.IsNullOrEmpty(requisicao))
                                                    Rel.Parametros_Relatorio.Add("REQUISICAO", requisicao);
                                                if (!string.IsNullOrEmpty(nm_motorista))
                                                    Rel.Parametros_Relatorio.Add("NM_MOTORISTA", nm_motorista);
                                                if (!string.IsNullOrEmpty(cpf_motorista))
                                                    Rel.Parametros_Relatorio.Add("CPF_MOTORISTA", cpf_motorista);
                                            }
                                            Rel.Nome_Relatorio = "DANFE_NFCE";
                                            Rel.NM_Classe = "TFConsultaFrenteCaixa";
                                            Rel.Modulo = "FAT";
                                            Rel.Ident = "DANFE_NFCE";
                                            if (CamadaNegocio.ConfigGer.TCN_CadParamGer.BuscaVlBool("ST_IMP_DANFE_NFCE_DETALHADA", null))
                                            {
                                                BindingSource bsItens = new BindingSource();
                                                bsItens.DataSource = (bsNFCe.Current as TRegistro_NFCe).lItem;
                                                Rel.DTS_Relatorio = bsItens;
                                            }
                                            if (rNFCe.Id_contingencia.HasValue)
                                                if (Rel.Parametros_Relatorio.ContainsKey("ST_VIAEMPRESA"))
                                                    Rel.Parametros_Relatorio["ST_VIAEMPRESA"] = "S";
                                                else
                                                    Rel.Parametros_Relatorio.Add("ST_VIAEMPRESA", "S");
                                            //Verificar se existe Impressora padrão para o PDV
                                            obj = new CamadaDados.Faturamento.Cadastros.TCD_PontoVenda().BuscarEscalar(
                                                    new TpBusca[]
                                                    {
                                                        new TpBusca()
                                                        {
                                                            vNM_Campo = "a.cd_terminal",
                                                            vOperador = "=",
                                                            vVL_Busca = "'" + Utils.Parametros.pubTerminal.Trim() + "'"
                                                        }
                                                    }, "a.impressorapadrao");
                                            string print = obj == null ? string.Empty : obj.ToString();
                                            if (string.IsNullOrEmpty(print))
                                                using (Parametros.Diversos.TFListaImpressoras fLista = new Parametros.Diversos.TFListaImpressoras())
                                                {
                                                    if (fLista.ShowDialog() == DialogResult.OK)
                                                        if (!string.IsNullOrEmpty(fLista.Impressora))
                                                            print = fLista.Impressora;

                                                }
                                            //Imprimir
                                            if (!string.IsNullOrEmpty(print))
                                            {
                                                Rel.ImprimiGraficoReduzida(print,
                                                                           true,
                                                                           false,
                                                                           null,
                                                                           string.Empty,
                                                                           string.Empty,
                                                                           1);
                                                if ((bsNFCe.Current as TRegistro_NFCe).Id_contingencia.HasValue &&
                                                    (bsNFCe.Current as TRegistro_NFCe).rCfgNFCe.Tp_ambiente_nfce.Equals(1))
                                                    Rel.ImprimiGraficoReduzida(print,
                                                                               true,
                                                                               false,
                                                                               null,
                                                                               string.Empty,
                                                                               string.Empty,
									                                           1);
                                            }
                                        }
                                    return;
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                            }
                            else
                                MessageBox.Show("Não existe venda selecionada para gerar cupom.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        
        private void TrocarVendedor()
        {
            List<TRegistro_VendaRapida> lVenda = new List<TRegistro_VendaRapida>();
            if (bsVenda.Current != null)
                    if (!(bsVenda.Current as TRegistro_VendaRapida).St_registro.Trim().ToUpper().Equals("C"))
                        if (MessageBox.Show("Trocar vendedor da venda corrente?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                             MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                            lVenda.Add(bsVenda.Current as TRegistro_VendaRapida);
            if(lVenda.Count.Equals(0))
                using (TFListaVenda fLista = new TFListaVenda())
                {
                    if (fLista.ShowDialog() == DialogResult.OK)
                        if (fLista.lVenda != null)
                            if (fLista.lVenda.Count > 0)
                                fLista.lVenda.ForEach(p => lVenda.Add(p));
                }
            if (lVenda.Count > 0)
            {
                string vColunas = "a.nm_clifor|Nome Vendedor|200;" +
                                  "a.cd_clifor|Cd. Vendedor|80";
                string vParam = "||(isnull(a.st_vendedor, 'N') = 'S') or (isnull(a.st_tecnico, 'N') = 'S');" +
                                "isnull(a.st_funcativo, 'N')|=|'S'";
                DataRowView linha = UtilPesquisa.BTN_BUSCA(vColunas, null, new CamadaDados.Financeiro.Cadastros.TCD_CadClifor(), vParam);
                if (linha != null)
                    try
                    {
                        CamadaNegocio.Faturamento.PDV.TCN_VendaRapida.TrocarVendedor(linha["cd_clifor"].ToString(),
                                                                                     lVenda,
                                                                                     null);
                        MessageBox.Show("Vendedor alterado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                else MessageBox.Show("Obrigatório informar vendedor.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else MessageBox.Show("Obrigatório selecionar venda para alterar vendedor.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
                
        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void TFConsultaFrenteCaixa_Load(object sender, EventArgs e)
        {
            Icon = ResourcesUtils.TecnoAliance_ICO;
            pDados.set_FormatZero();
            qtd_nota.Text = Utils.Parametros.pubTopMax > 0 ? Utils.Parametros.pubTopMax.ToString() : "15";
            cbStatus.SelectedIndex = 0;
            bbTrocarVendedor.Visible = CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin, "PERMITIR TROCAR VENDEDOR COMISSÃO", null);
            ShapeGrid.RestoreShape(this, gVenda);
            ShapeGrid.RestoreShape(this, gItens);
            ShapeGrid.RestoreShape(this, dataGridDefault1);
            ShapeGrid.RestoreShape(this, dataGridDefault10);
            ShapeGrid.RestoreShape(this, dataGridDefault11);
            ShapeGrid.RestoreShape(this, dataGridDefault3);
            ShapeGrid.RestoreShape(this, dataGridDefault4);
            ShapeGrid.RestoreShape(this, dataGridDefault6);
            ShapeGrid.RestoreShape(this, dataGridDefault7);
            ShapeGrid.RestoreShape(this, dataGridDefault8);
            ShapeGrid.RestoreShape(this, dataGridDefault9);
            ShapeGrid.RestoreShape(this, gNfeEnviar);
            ShapeGrid.RestoreShape(this, gResCliente);
            ShapeGrid.RestoreShape(this, gResPdv);
            ShapeGrid.RestoreShape(this, gResumoCliente);
            ShapeGrid.RestoreShape(this, gResumoEmp);
            ShapeGrid.RestoreShape(this, gResumoEmpresa);
            ShapeGrid.RestoreShape(this, gResumoPDV);
            dt_ini.Text = "00:00";
            dt_fim.Text = "23:59";
        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("a.NM_empresa|Nome Empresa|300;a.CD_Empresa|Cód Empresa|100"
                          , new Componentes.EditDefault[] { cd_empresa }
                          , new CamadaDados.Diversos.TCD_CadEmpresa(),
                          "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.cd_empresa = A.cd_empresa " +
                          "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                          "(exists(select 1 from tb_div_usuario_x_grupos y " +
                          "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))");
        }

        private void cd_empresa_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "';" +
                                  "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.cd_empresa = A.cd_empresa " +
                                  "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                  "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                  "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))"
              , new Componentes.EditDefault[] { cd_empresa }, new CamadaDados.Diversos.TCD_CadEmpresa());
        }

        private void bb_vendedor_Click(object sender, EventArgs e)
        {
            string vColunas = "a.nm_clifor|Nome Vendedor|200;" +
                              "a.cd_clifor|Cd. Vendedor|80";
            string vParam = "isnull(a.st_vendedor, 'N')|=|'S';" +
                            "isnull(a.st_funcativo, 'N')|=|'S'";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_vendedor },
                new CamadaDados.Financeiro.Cadastros.TCD_CadClifor(),
               vParam);
        }

        private void cd_vendedor_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_clifor|=|'" + cd_vendedor.Text.Trim() + "';" +
                            "isnull(a.st_vendedor, 'N')|=|'S';" +
                            "isnull(a.st_funcativo, 'N')|=|'S'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_vendedor },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void bb_pdv_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_pdv|Ponto Venda|200;" +
                              "a.id_pdv|Id. PDV|80";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { id_pdv },
                                    new CamadaDados.Faturamento.Cadastros.TCD_PontoVenda(), string.Empty);
        }

        private void id_pdv_Leave(object sender, EventArgs e)
        {
            string vParam = "a.id_pdv|=|" + id_pdv.Text;
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { id_pdv },
                                    new CamadaDados.Faturamento.Cadastros.TCD_PontoVenda());
        }

        private void bb_clifor_Click(object sender, EventArgs e)
        {
            DataRowView linha = UtilPesquisa.BTN_BuscaClifor(null, string.Empty);
            if(linha != null)
                if (linha["nm_clifor"].ToString().Length > 50)
                nm_clifor.Text = linha["nm_clifor"].ToString().Substring(0, 50);
                else
                    nm_clifor.Text = linha["nm_clifor"].ToString();

        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            afterBusca();
        }

        private void TFConsultaFrenteCaixa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F5))
                afterExclui();
            else if (e.KeyCode.Equals(Keys.F7))
                afterBusca();
            else if (e.KeyCode.Equals(Keys.F8))
                afterPrint();
            else if (e.Control && e.KeyCode.Equals(Keys.P))
            {
                Altera_Relatorio = true;
                MessageBox.Show("Execute o relatório que deseja alterar!", "Mensagem");
            }
        }

        private void BB_Excluir_Click(object sender, EventArgs e)
        {
            afterExclui();
        }

        private void BB_Imprimir_Click(object sender, EventArgs e)
        {
            afterPrint();
        }
        
        private void gVenda_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gVenda.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsVenda.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new TRegistro_VendaRapida());
            TList_VendaRapida lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gVenda.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gVenda.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new TList_VendaRapida(lP.Find(gVenda.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gVenda.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new TList_VendaRapida(lP.Find(gVenda.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gVenda.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsVenda.List as TList_VendaRapida).Sort(lComparer);
            bsVenda.ResetBindings(false);
            gVenda.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void bb_produto_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaProduto(new Componentes.EditDefault[] { cd_produto }, string.Empty);
        }

        private void cd_produto_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVEProduto("a.cd_produto|=|'" + cd_produto.Text.Trim() + "'",
                                                    new Componentes.EditDefault[] { cd_produto },
                                                    new CamadaDados.Estoque.Cadastros.TCD_CadProduto());
        }

        private void gVenda_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
                if (e.ColumnIndex.Equals(0))
                {
                    if (e.Value.ToString().Trim().ToUpper().Equals("CANCELADO"))
                        gVenda.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
                    else
                        gVenda.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                }
        }

        private void tcCentral_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bsVenda.Current != null)
            {
                if (tcCentral.SelectedTab.Equals(tpFinanceiro))
                    tcFinan_SelectedIndexChanged(this, new EventArgs());
                else if (tcCentral.SelectedTab.Equals(tpAbast))
                {
                    bsVendaCombustivel.DataSource = new CamadaDados.PostoCombustivel.TCD_VendaCombustivel().Select(
                                                    new TpBusca[]
                                                    {
                                                        new TpBusca()
                                                        {
                                                            vNM_Campo = "a.cd_empresa",
                                                            vOperador = "=",
                                                            vVL_Busca = "'" + (bsVenda.Current as TRegistro_VendaRapida).Cd_empresa.Trim() + "'"
                                                        },
                                                        new TpBusca()
                                                        {
                                                            vNM_Campo = "a.id_cupom",
                                                            vOperador = "=",
                                                            vVL_Busca = (bsVenda.Current as TRegistro_VendaRapida).Id_vendarapidastr
                                                        }
                                                    }, 0, string.Empty, string.Empty);
                    tot_abast.Text = (bsVendaCombustivel.List as CamadaDados.PostoCombustivel.TList_VendaCombustivel).Sum(p => p.Vl_subtotal).ToString("N2", new System.Globalization.CultureInfo("pt-BR"));
                }
                else if (tcCentral.SelectedTab.Equals(tpCCusto))
                    bsCCusto.DataSource = new CamadaDados.Financeiro.CCustoLan.TCD_LanCCustoLancto().Select(
                                            new TpBusca[]
                                            {
                                                new TpBusca()
                                                {
                                                    vNM_Campo = string.Empty,
                                                    vOperador = "exists",
                                                    vVL_Busca = "(select 1 from TB_FIN_Cupom_X_CCusto x " +
                                                                "where x.id_ccustolan = a.id_ccustolan " +
                                                                "and x.cd_empresa = '" + (bsVenda.Current as TRegistro_VendaRapida).Cd_empresa.Trim() + "' " +
                                                                "and x.id_cupom = " + (bsVenda.Current as TRegistro_VendaRapida).Id_vendarapidastr + ")"
                                                }
                                            }, 0, string.Empty);
                else if(tcCentral.SelectedTab.Equals(tpFiscal))
                {
                    bsNFCe.DataSource = new TCD_NFCe().Select(
                        new TpBusca[]
                        {
                            new TpBusca
                            {
                                vNM_Campo = "isnull(a.st_registro, 'A')",
                                vOperador = "<>",
                                vVL_Busca = "'C'"
                            },
                            new TpBusca
                            {
                                vNM_Campo=string.Empty,
                                vOperador = "exists",
                                vVL_Busca = "(select 1 from tb_pdv_cupom_x_vendarapida x " +
                                            "where x.cd_empresa = a.cd_empresa " +
                                            "and x.id_cupom = a.id_nfce " +
                                            "and x.cd_empresa = '" + (bsVenda.Current as TRegistro_VendaRapida).Cd_empresa.Trim() + "' " +
                                            "and x.id_vendarapida = " + (bsVenda.Current as TRegistro_VendaRapida).Id_vendarapidastr + ")"
                            }
                        }, 0, string.Empty, string.Empty);
                    bsNotaFiscal.DataSource = new CamadaDados.Faturamento.NotaFiscal.TCD_LanFaturamento()
                        .Select(
                        new TpBusca[]
                        {
                            new TpBusca()
                                {
                                    vNM_Campo = "isnull(a.st_registro, 'A')",
                                    vOperador = "<>",
                                    vVL_Busca = "'C'"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = string.Empty,
                                    vOperador = "exists",
                                    vVL_Busca = "(select 1 from tb_fat_notafiscal_item x " +
                                                "inner join tb_pdv_pedido_x_vendarapida y " +
                                                "on x.nr_pedido = y.nr_pedido " +
                                                "and x.cd_produto = y.cd_produto " +
                                                "and x.id_pedidoitem = y.id_pedidoitem " +
                                                "where x.cd_empresa = a.cd_empresa " +
                                                "and x.nr_lanctofiscal = a.nr_lanctofiscal " +
                                                "and y.cd_empresa = '" + (bsVenda.Current as TRegistro_VendaRapida).Cd_empresa.Trim() + "' " +
                                                "and y.id_vendarapida = " + (bsVenda.Current as TRegistro_VendaRapida).Id_vendarapidastr + ")"
                                }
                        }, 0, string.Empty);
                }
            }
            else
            {
                bsVendaCombustivel.Clear();
                bsDuplicata.Clear();
                bsCaixaDevCred.Clear();
                bsCartaFrete.Clear();
                bsCCusto.Clear();
                bsNFCe.Clear();
                bsNotaFiscal.Clear();
            }
        }

        private void qtd_nota_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!char.IsDigit(e.KeyChar)) && (!e.KeyChar.ToString().Equals("\b")))
                e.Handled = true;
        }

        private void dt_inicial_Leave(object sender, EventArgs e)
        {
            if (!dt_inicial.SoNumero().Length.Equals(12) && !dt_inicial.SoNumero().Length.Equals(0))
            {
                MessageBox.Show("É necessário informar Data e Hora na Busca!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void dt_final_Leave(object sender, EventArgs e)
        {
            if (!dt_final.SoNumero().Length.Equals(12) && !dt_final.SoNumero().Length.Equals(0))
            {
                MessageBox.Show("É necessário informar Data e Hora na Busca!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void tmReVendas_Click(object sender, EventArgs e)
        {
            if (bsVenda.Current != null)
            {
                FormRelPadrao.Relatorio Relatorio = new FormRelPadrao.Relatorio();
                Relatorio.Nome_Relatorio = "TFLanConsultaFrenteCaixa_RelVendas";
                Relatorio.NM_Classe = Name;
                Relatorio.Modulo = Tag.ToString().Substring(0, 3);
                Relatorio.Ident = "TFLanConsultaFrenteCaixa_RelVendas";
                Relatorio.Altera_Relatorio = Altera_Relatorio;
                Relatorio.DTS_Relatorio = bsVenda;
                if (!Altera_Relatorio)
                {
                    //Chamar tela de gerenciamento de impressao
                    using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                    {
                        fImp.St_enabled_enviaremail = true;
                        fImp.pCd_clifor = (bsVenda.Current as TRegistro_VendaRapida).Cd_clifor;
                        fImp.pMensagem = "RELATÓRIO DE VENDAS";
                        if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                            Relatorio.Gera_Relatorio(string.Empty,
                                                     fImp.pSt_imprimir,
                                                     fImp.pSt_visualizar,
                                                     fImp.pSt_enviaremail,
                                                     fImp.pSt_exportPdf,
                                                     fImp.Path_exportPdf,
                                                     fImp.pDestinatarios,
                                                     null,
                                                     "RELATÓRIO DE VENDAS",
                                                     fImp.pDs_mensagem);
                    }
                }
                else
                {
                    Relatorio.Gera_Relatorio();
                    Altera_Relatorio = false;
                }
            }
        }
                
        private void gerarNFeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GerarNfe();
        }

        private void gerarNFCeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GerarNFCe();
        }

        private void imprimirConToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bsVenda.Current != null)
            {
                CamadaDados.Financeiro.Duplicata.TList_RegLanParcela lParc =
                    new CamadaDados.Financeiro.Duplicata.TCD_LanParcela().Select(
                      new TpBusca[]
                      {
                        new TpBusca { vNM_Campo = "isnull(dup.st_registro, 'A')", vOperador = "<>", vVL_Busca = "'C'" },
                        new TpBusca
                        {
                            vNM_Campo = string.Empty,
                            vOperador = "exists",
                            vVL_Busca = "(select 1 from tb_pdv_cupomfiscal_x_duplicata x " +
                                        "where x.cd_empresa = a.cd_empresa " +
                                        "and x.nr_lancto = a.nr_lancto " +
                                        "and x.cd_empresa = '" + (bsVenda.Current as TRegistro_VendaRapida).Cd_empresa.Trim() + "' " +
                                        "and x.id_cupom = " + (bsVenda.Current as TRegistro_VendaRapida).Id_vendarapidastr + ")"
                        }
                      }, 0, string.Empty, string.Empty, string.Empty);
                if (lParc.Count > 0)
                {
                    FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                    Rel.Altera_Relatorio = Altera_Relatorio;
                    BindingSource bin = new BindingSource();
                    bin.DataSource = new TList_VendaRapida { bsVenda.Current as TRegistro_VendaRapida };
                    Rel.DTS_Relatorio = bin;
                    //DTS Cupom
                    BindingSource dts = new BindingSource();
                    if((bsVenda.Current as TRegistro_VendaRapida).lItem.Count > 0)
                        dts.DataSource =  (bsVenda.Current as TRegistro_VendaRapida).lItem;
                    else
                        dts.DataSource = CamadaNegocio.Faturamento.PDV.TCN_VendaRapida_Item.Buscar((bsVenda.Current as TRegistro_VendaRapida).Id_vendarapidastr,
                                                                                                   (bsVenda.Current as TRegistro_VendaRapida).Cd_empresa,
                                                                                                   false,
                                                                                                   string.Empty,
                                                                                                   null);
                    Rel.Adiciona_DataSource("DTS_ITENS", dts);
                    //Buscar Empresa
                    BindingSource bsEmpresa = new BindingSource();
                    bsEmpresa.DataSource = CamadaNegocio.Diversos.TCN_CadEmpresa.Busca((bsVenda.Current as TRegistro_VendaRapida).Cd_empresa, string.Empty, string.Empty, null);
                    Rel.Adiciona_DataSource("DTS_EMP", bsEmpresa);
                    Rel.Parametros_Relatorio.Add("NM_CLIENTE", lParc[0].Nm_clifor);
                    Rel.Parametros_Relatorio.Add("CPF_CLIENTE", lParc[0].Cnpj_cpf);
                    BindingSource bsend = new BindingSource();
                    bsend.DataSource =
                        CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Buscar(lParc[0].Cd_clifor,
                                                                                    lParc[0].Cd_endereco,
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

                    Rel.Adiciona_DataSource("END", bsend);
                    Rel.Parametros_Relatorio.Add("ENDERECO", (bsend.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadEndereco).Ds_endereco.Trim() + ", " +
                                                             (bsend.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadEndereco).Numero.Trim() + ", " +
                                                             (bsend.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadEndereco).Bairro.Trim() + ", " +
                                                             (bsend.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadEndereco).DS_Cidade.Trim() + ", " +
                                                             (bsend.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadEndereco).UF.Trim());
                    string dadosdi = CamadaNegocio.Faturamento.PDV.TCN_VendaRapida.BuscarPlacaKM((bsVenda.Current as TRegistro_VendaRapida).Cd_empresa,
                                                                                                (bsVenda.Current as TRegistro_VendaRapida).Id_vendarapidastr,
                                                                                                null);
                    if (!string.IsNullOrEmpty(dadosdi))
                    {
                        string[] linhas = dadosdi.Split(new char[] { ':' });
                        string placa = string.Empty;
                        string km = string.Empty;
                        string frota = string.Empty;
                        string requisicao = string.Empty;
                        string nm_motorista = string.Empty;
                        string cpf_motorista = string.Empty;
                        string media = string.Empty;
                        string virg = string.Empty;
                        foreach (string s in linhas)
                        {
                            string[] colunas = s.Split(new char[] { '/' });
                            if (colunas.Length > 0)
                            {
                                placa += virg + colunas[0];
                                if(colunas.Length > 1)
                                    km += virg + colunas[1];
                                if(colunas.Length > 2)
                                    frota += virg + colunas[2];
                                if(colunas.Length > 3)
                                    requisicao += virg + colunas[3];
                                if(colunas.Length > 4)
                                    nm_motorista += virg + colunas[4];
                                if(colunas.Length > 5)
                                    cpf_motorista += virg + colunas[5];
                                if(colunas.Length > 6)
                                    media += virg + colunas[6];
                                virg = ",";
                            }
                        }
                        if (!string.IsNullOrEmpty(placa))
                            Rel.Parametros_Relatorio.Add("PLACA", placa);
                        if (!string.IsNullOrEmpty(km))
                            Rel.Parametros_Relatorio.Add("KM", km);
                        if (!string.IsNullOrEmpty(media))
                            Rel.Parametros_Relatorio.Add("MEDIA", media + " KM/LT");
                        if (!string.IsNullOrEmpty(frota))
                            Rel.Parametros_Relatorio.Add("FROTA", frota);
                        if (!string.IsNullOrEmpty(requisicao))
                            Rel.Parametros_Relatorio.Add("REQUISICAO", requisicao);
                        if (!string.IsNullOrEmpty(nm_motorista))
                            Rel.Parametros_Relatorio.Add("MOTORISTA", nm_motorista);
                        if (!string.IsNullOrEmpty(cpf_motorista))
                            Rel.Parametros_Relatorio.Add("CPF_MOTORISTA", cpf_motorista);
                    }
                    //Buscar Valor Pago
                    decimal vl_pago = decimal.Zero;
                    List<TRegistro_MovCaixa> lPagto =
                        new TCD_CaixaPDV().SelectMovCaixa(
                            new TpBusca[]
                            {
                                new TpBusca { vNM_Campo = "a.cd_empresa", vOperador = "=", vVL_Busca = "'" + (bsVenda.Current as TRegistro_VendaRapida).Cd_empresa.Trim() + "'"},
                                new TpBusca {vNM_Campo = "a.id_cupom", vOperador = "=", vVL_Busca = (bsVenda.Current as TRegistro_VendaRapida).Id_vendarapidastr }
                            }, string.Empty);

                    if (lPagto.Count > 0)
                        vl_pago = lPagto.Sum(p => p.Vl_recebidoliq);
                    vl_pago += lParc.Sum(p => p.Vl_liquidado);
                    Rel.Parametros_Relatorio.Add("VL_PAGO", vl_pago);
                    Rel.Parametros_Relatorio.Add("VL_PAGAR", lParc.Sum(p => p.Vl_atual));
                    //Buscar documento fiscal
                    StringBuilder sql = new StringBuilder();
                    sql.AppendLine("select a.nr_nfce, a.dt_emissao, a.chave_acesso, '0' as tp_docto ");
                    sql.AppendLine("from tb_pdv_nfce a ");
                    sql.AppendLine("where isnull(a.st_registro, 'A') <> 'C' ");
                    sql.AppendLine("and exists(select 1 from tb_pdv_cupom_x_vendarapida x ");
                    sql.AppendLine("            where x.cd_empresa = a.cd_empresa ");
                    sql.AppendLine("            and x.id_cupom = a.id_nfce ");
                    sql.AppendLine("            and x.cd_empresa = '" + (bsVenda.Current as TRegistro_VendaRapida).Cd_empresa.Trim() + "'");
                    sql.AppendLine("            and x.id_vendarapida = " + (bsVenda.Current as TRegistro_VendaRapida).Id_vendarapidastr + ")");
                    sql.AppendLine("union all ");
                    sql.AppendLine("select a.nr_notafiscal, a.dt_emissao, a.chave_acesso_nfe, '1' as tp_docto ");
                    sql.AppendLine("from tb_fat_notafiscal a ");

                    sql.AppendLine("where isnull(a.st_registro, 'A') <> 'C' ");
                    sql.AppendLine("and exists(select 1 from tb_pdv_pedido_x_vendarapida x ");
                    sql.AppendLine("            inner join tb_fat_notafiscal_item y ");
                    sql.AppendLine("            on x.nr_pedido = y.nr_pedido ");
                    sql.AppendLine("            and x.cd_produto = y.cd_produto ");
                    sql.AppendLine("            and x.id_pedidoitem = y.id_pedidoitem ");
                    sql.AppendLine("            where y.cd_empresa = a.cd_empresa ");
                    sql.AppendLine("            and y.nr_lanctofiscal = a.nr_lanctofiscal ");
                    sql.AppendLine("            and x.cd_empresa = '" + (bsVenda.Current as TRegistro_VendaRapida).Cd_empresa.Trim() + "'");
                    sql.AppendLine("            and x.id_vendarapida = " + (bsVenda.Current as TRegistro_VendaRapida).Id_vendarapidastr + ")");
                    DataTable tb = new CamadaDados.TDataQuery().ExecutarBusca(sql.ToString(), null);
                    if (tb.Rows.Count > 0)
                    {
                        Rel.Parametros_Relatorio.Add("NR_DOCUMENTO", tb.Rows[0][0].ToString());
                        Rel.Parametros_Relatorio.Add("DT_EMISSAO", tb.Rows[0][1].ToString());
                        Rel.Parametros_Relatorio.Add("CHAVE_ACESSO", tb.Rows[0][2].ToString());
                        Rel.Parametros_Relatorio.Add("TP_DOCUMENTO", tb.Rows[0][3].ToString());//1-NF-e;0-NFC-e
                    }
                    else
                    {
                        Rel.Parametros_Relatorio.Add("NR_DOCUMENTO", (bsVenda.Current as TRegistro_VendaRapida).Id_vendarapidastr);
                        Rel.Parametros_Relatorio.Add("DT_EMISSAO", (bsVenda.Current as TRegistro_VendaRapida).Dt_emissaostr);
                        Rel.Parametros_Relatorio.Add("CHAVE_ACESSO", string.Empty);
                        Rel.Parametros_Relatorio.Add("TP_DOCUMENTO", "2");//1-NF-e;0-NFC-e
                    }
                    Rel.Nome_Relatorio = "CONFISSAO_DIVIDA";
                    Rel.NM_Classe = "TFConsultaFrenteCaixa";
                    Rel.Modulo = "FAT";
                    Rel.Ident = "CONFISSAO_DIVIDA";
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
                    string print = obj == null ? string.Empty : obj.ToString();
                    if (string.IsNullOrEmpty(print))
                        using (Parametros.Diversos.TFListaImpressoras fLista = new Parametros.Diversos.TFListaImpressoras())
                        {
                            if (fLista.ShowDialog() == DialogResult.OK)
                                if (!string.IsNullOrEmpty(fLista.Impressora))
                                    print = fLista.Impressora;

                        }
                    Rel.ImprimiGraficoReduzida(print,
                                               true,
                                               false,
                                               null,
                                               string.Empty,
                                               string.Empty,
                                               1);
                    Altera_Relatorio = false;
                }
            }
        }

        private void tcFinan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bsVenda.Current != null)
            {
                if (tcFinan.SelectedTab.Equals(tpCaixa))
                {
                    bsMovCaixa.DataSource = new TCD_Cupom_X_MovCaixa().Select(
                        new TpBusca[]
                        {
                            new TpBusca
                            {
                                vNM_Campo = "a.cd_empresa",
                                vOperador = "=",
                                vVL_Busca = (bsVenda.Current as TRegistro_VendaRapida).Cd_empresa.Trim()
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "a.id_cupom",
                                vOperador = "=",
                                vVL_Busca = (bsVenda.Current as TRegistro_VendaRapida).Id_vendarapidastr
                            }
                        }, 0, string.Empty);
                }
                else if (tcFinan.SelectedTab.Equals(tpDuplicata))
                    bsDuplicata.DataSource = new CamadaDados.Financeiro.Duplicata.TCD_LanDuplicata().Select(
                                                new TpBusca[]
                                                {
                                                    new TpBusca()
                                                    {
                                                        vNM_Campo = string.Empty,
                                                        vOperador = "exists",
                                                        vVL_Busca = "(select 1 from tb_pdv_cupomfiscal_x_duplicata x " +
                                                                    "where x.cd_empresa = a.cd_empresa " +
                                                                    "and x.nr_lancto = a.nr_lancto " +
                                                                    "and x.cd_empresa = '" + (bsVenda.Current as TRegistro_VendaRapida).Cd_empresa.Trim() + "' " +
                                                                    "and x.id_cupom = " + (bsVenda.Current as TRegistro_VendaRapida).Id_vendarapidastr + ")"
                                                    }
                                                }, 0, string.Empty);
                else if (tcFinan.SelectedTab.Equals(tpDevCred))
                    bsCaixaDevCred.DataSource = new CamadaDados.Financeiro.Caixa.TCD_LanCaixa().Select(
                                                    new TpBusca[]
                                                    {
                                                        new TpBusca()
                                                        {
                                                            vNM_Campo = string.Empty,
                                                            vOperador = "exists",
                                                            vVL_Busca = "(select 1 from tb_pdv_cupom_x_devcredito x " +
                                                                        "where x.cd_contager = a.cd_contager " +
                                                                        "and x.cd_lanctocaixa = a.cd_lanctocaixa " +
                                                                        "and x.cd_empresa = '" + (bsVenda.Current as TRegistro_VendaRapida).Cd_empresa.Trim() + "' " +
                                                                        "and x.id_cupom = " + (bsVenda.Current as TRegistro_VendaRapida).Id_vendarapidastr + ")"
                                                        }
                                                    }, 0, string.Empty);
                else if (tcFinan.SelectedTab.Equals(tpCartaFrete))
                    bsCartaFrete.DataSource = new CamadaDados.PostoCombustivel.TCD_CartaFrete().Select(
                                                new TpBusca[]
                                                {
                                                    new TpBusca()
                                                    {
                                                        vNM_Campo = string.Empty,
                                                        vOperador = "exists",
                                                        vVL_Busca = "(select 1 from tb_pdv_cupom_x_movcaixa x " +
                                                                    "where x.cd_empresa = a.cd_empresa " +
                                                                    "and x.id_cartafrete = a.id_cartafrete " +
                                                                    "and x.cd_empresa = '" + (bsVenda.Current as TRegistro_VendaRapida).Cd_empresa.Trim() + "' " +
                                                                    "and x.id_cupom = " + (bsVenda.Current as TRegistro_VendaRapida).Id_vendarapidastr + ")"
                                                    }
                                                }, 0, string.Empty);
            }
        }

        private void gResumoEmp_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gResumoEmp.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsResumoEmpresa.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new TRegistro_ResumoEmpresa());
            TList_ResumoEmpresa lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gResumoEmp.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gResumoEmp.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new TList_ResumoEmpresa(lP.Find(gResumoEmp.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gResumoEmp.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new TList_ResumoEmpresa(lP.Find(gResumoEmp.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gResumoEmp.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsResumoEmpresa.List as TList_ResumoEmpresa).Sort(lComparer);
            bsResumoEmpresa.ResetBindings(false);
            gResumoEmp.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void gResPdv_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gResumoPDV.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsResumoPdv.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new TRegistro_ResumoPDV());
            TList_ResumoPDV lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gResumoPDV.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gResumoPDV.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new TList_ResumoPDV(lP.Find(gResumoPDV.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gResumoPDV.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new TList_ResumoPDV(lP.Find(gResumoPDV.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gResumoPDV.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsResumoPdv.List as TList_ResumoPDV).Sort(lComparer);
            bsResumoPdv.ResetBindings(false);
            gResumoPDV.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void gResCliente_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gResCliente.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsResumoCliente.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new TRegistro_ResumoCliente());
            TList_ResumoCliente lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gResCliente.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gResCliente.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new TList_ResumoCliente(lP.Find(gResCliente.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gResCliente.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new TList_ResumoCliente(lP.Find(gResCliente.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gResCliente.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsResumoCliente.List as TList_ResumoCliente).Sort(lComparer);
            bsResumoCliente.ResetBindings(false);
            gResCliente.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void bb_impResumo_Click(object sender, EventArgs e)
        {
            if (bsResumoCliente.Count > 0)
            {
                FormRelPadrao.Relatorio Relatorio = new FormRelPadrao.Relatorio();
                Relatorio.Altera_Relatorio = Altera_Relatorio;

                //DADOS PERTINENTES PARA A GERAÇÂO DO RELATORIO
                Relatorio.Nome_Relatorio = "TFConsultaFrenteCaixa";
                Relatorio.NM_Classe = "TFConsultaFrenteCaixa";
                Relatorio.Ident = "FRel_PDV_ResumoCliente";
                Relatorio.Modulo = string.Empty;
                string periodo = string.Empty;
                if (string.IsNullOrEmpty(dt_inicial.Text.SoNumero()))
                    periodo = (bsVenda.List as TList_VendaRapida).OrderBy(p => p.Dt_emissao).Take(1).ToList()[0].Dt_emissaostr;
                else periodo = dt_inicial.Text;
                if (string.IsNullOrEmpty(dt_final.Text.SoNumero()))
                    periodo += " até " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                else periodo += " até " + dt_final.Text;
                Relatorio.Parametros_Relatorio.Add("PERIODO", periodo);
                
                Relatorio.DTS_Relatorio = bsResumoCliente;
                
                if (!Altera_Relatorio)
                {
                    //Chamar tela de gerenciamento de impressao
                    using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                    {
                        fImp.St_enabled_enviaremail = true;
                        fImp.pMensagem = "RESUMO VENDA POR CLIENTE";
                        if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                            Relatorio.Gera_Relatorio(string.Empty,
                                                     fImp.pSt_imprimir,
                                                     fImp.pSt_visualizar,
                                                     fImp.pSt_enviaremail,
                                                     fImp.pSt_exportPdf,
                                                     fImp.Path_exportPdf,
                                                     fImp.pDestinatarios,
                                                     null,
                                                     "RESUMO VENDA POR CLIENTE",
                                                     fImp.pDs_mensagem);
                    }
                }
                else
                {
                    Relatorio.Gera_Relatorio();
                    Altera_Relatorio = false;
                }
            }
        }

        private void bbTrocarVendedor_Click(object sender, EventArgs e)
        {
            TrocarVendedor();
        }

        private void gItens_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
                if (e.ColumnIndex.Equals(0))
                {
                    if (e.Value.ToString().Trim().ToUpper().Equals("CANCELADO"))
                        gItens.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
                    else
                        gItens.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                }
        }

        private void TFConsultaFrenteCaixa_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            ShapeGrid.SaveShape(this, gVenda);
            ShapeGrid.SaveShape(this, gItens);
            ShapeGrid.SaveShape(this, dataGridDefault1);
            ShapeGrid.SaveShape(this, dataGridDefault10);
            ShapeGrid.SaveShape(this, dataGridDefault11);
            ShapeGrid.SaveShape(this, dataGridDefault3);
            ShapeGrid.SaveShape(this, dataGridDefault4);
            ShapeGrid.SaveShape(this, dataGridDefault6);
            ShapeGrid.SaveShape(this, dataGridDefault7);
            ShapeGrid.SaveShape(this, dataGridDefault8);
            ShapeGrid.SaveShape(this, dataGridDefault9);
            ShapeGrid.SaveShape(this, gNfeEnviar);
            ShapeGrid.SaveShape(this, gResCliente);
            ShapeGrid.SaveShape(this, gResPdv);
            ShapeGrid.SaveShape(this, gResumoCliente);
            ShapeGrid.SaveShape(this, gResumoEmp);
            ShapeGrid.SaveShape(this, gResumoEmpresa);
            ShapeGrid.SaveShape(this, gResumoPDV);
        }

        private void dt_ini_Leave(object sender, EventArgs e)
        { 
            if (!dt_ini.SoNumero().Length.Equals(4) && !dt_ini.SoNumero().Length.Equals(4))
            {
                MessageBox.Show("É necessário informar Hora na Busca!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void dt_fim_Leave(object sender, EventArgs e)
        { 
            if (!dt_fim.SoNumero().Length.Equals(4) && !dt_fim.SoNumero().Length.Equals(4))
            {
                MessageBox.Show("É necessário informar Hora na Busca!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

        }

        private void nm_clifor_TextChanged(object sender, EventArgs e)
        {
            if(nm_clifor.Text.Length > 50)
                nm_clifor.Text = nm_clifor.Text.Substring(0, 50);
        }

        private void bsVenda_PositionChanged(object sender, EventArgs e)
        {
            if(bsVenda.Current != null)
            {
                (bsVenda.Current as TRegistro_VendaRapida).lItem =
                    TCN_VendaRapida_Item.Buscar((bsVenda.Current as TRegistro_VendaRapida).Id_vendarapidastr,
                                                (bsVenda.Current as TRegistro_VendaRapida).Cd_empresa,
                                                false,
                                                string.Empty,
                                                null);
                bsVenda.ResetCurrentItem();
            }
        }

        private void gVenda_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void buscarResumos()
        {
            TpBusca[] tps = new TpBusca[0];
            int vQtd_nota = 0;
            if (!string.IsNullOrEmpty(qtd_nota.Text.Trim().SoNumero()))
                vQtd_nota = Convert.ToInt32(qtd_nota.Text.Trim().SoNumero());

            string ini = string.Empty;
            string fim = string.Empty;
            if (dt_inicial.Text.SoNumero().Length.Equals(8) && !dt_inicial.Text.SoNumero().Length.Equals(0))
                ini = string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(dt_inicial.Text).ToString("yyyyMMdd")) + " " +
                string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(dt_ini.Text).ToString("HH:mm"));
            if (dt_final.Text.SoNumero().Length.Equals(8) && !dt_final.Text.SoNumero().Length.Equals(0))
                fim = string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(dt_final.Text).ToString("yyyyMMdd")) + " " +
                string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(dt_fim.Text).ToString("HH:mm")) ;

            if (dt_inicial.Text.SoNumero().Length.Equals(8))
                Estruturas.CriarParametro(ref tps, "dt_lancto", "'" + ini + "'", ">=");
            if (dt_final.Text.SoNumero().Length.Equals(8))
                Estruturas.CriarParametro(ref tps, "dt_lancto", "'" + fim + "'", "<=");

            if (tcResumo.SelectedIndex.Equals(3))
            {
                Estruturas.CriarParametro(ref tps, "a.ds_portador", "'DINHEIRO'");
                bsDinheiro.DataSource = new TCD_CaixaPDV().SelectMovCaixaPortador(tps, string.Empty, vQtd_nota);
                bsDinheiro.ResetBindings(true);
            }
            else if (tcResumo.SelectedIndex.Equals(4))
            {
                Estruturas.CriarParametro(ref tps, "a.ds_portador", "'CARTAO'");
                bsCartao.DataSource = new TCD_CaixaPDV().SelectMovCaixaPortador(tps, string.Empty, vQtd_nota);
                bsCartao.ResetBindings(true);
            }
            else if (tcResumo.SelectedIndex.Equals(5))
            {
                Estruturas.CriarParametro(ref tps, "a.ds_portador", "'NOTA A COBRAR'");
                bsNotaPagar.DataSource = new TCD_CaixaPDV().SelectMovCaixaPortador(tps, string.Empty, vQtd_nota);
                bsNotaPagar.ResetBindings(true);
            }
        }

        private void tcResumo_SelectedIndexChanged(object sender, EventArgs e)
        {
            buscarResumos();
        }
    }
}
