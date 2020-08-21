using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using Utils;
using CamadaDados.Financeiro.Duplicata;
using CamadaNegocio.Financeiro.Duplicata;
using CamadaDados.Financeiro.Cadastros;
using CamadaNegocio.Diversos;
using CamadaNegocio.Financeiro.Cadastros;
using CamadaDados.Diversos;
using FormRelPadrao;
using FormBusca;

namespace Financeiro
{
    public partial class TFLanContas : Form
    {
        FormRelPadrao.Relatorio Relatorio;
        public TTpModo vTP_Modo;
        public bool Altera_Relatorio = false;
        private bool st_busca = true;

        public TFLanContas()
        {
            InitializeComponent();
        }

        private void afterNovo()
        {
            using (TFLanDuplicata fDuplicata = new TFLanDuplicata())
            {
                if (fDuplicata.ShowDialog() == DialogResult.OK)
                {
                    BS_Duplicata.Add(fDuplicata.dsDuplicata.Current as TRegistro_LanDuplicata);
                    try
                    {

                        string ret = TCN_LanDuplicata.GravarDuplicata((fDuplicata.dsDuplicata.Current as TRegistro_LanDuplicata), true, null);
                        if (!string.IsNullOrEmpty(ret))
                        {
                            string lan = CamadaDados.TDataQuery.getPubVariavel(ret, "@P_NR_LANCTO");
                            BS_Duplicata.EndEdit();

                            MessageBox.Show("Lançamento Financeiro nr:" + lan + " Gravado com Sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //Imprimir Boleto
                            CamadaDados.Financeiro.Bloqueto.blListaTitulo lBloqueto =
                                CamadaNegocio.Financeiro.Bloqueto.TCN_Titulo.Buscar((fDuplicata.dsDuplicata.Current as TRegistro_LanDuplicata).Cd_empresa,
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
                                using (TFGerenciadorImpressao fImp = new TFGerenciadorImpressao())
                                {
                                    fImp.St_enabled_enviaremail = true;
                                    fImp.pCd_clifor = (fDuplicata.dsDuplicata.Current as TRegistro_LanDuplicata).Cd_clifor;
                                    fImp.pMensagem = "BLOQUETOS DO DOCUMENTO Nº" + (fDuplicata.dsDuplicata.Current as TRegistro_LanDuplicata).Nr_docto;
                                    if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                                        TCN_LayoutBloqueto.Imprime_Bloqueto(false,
                                                                            lBloqueto,
                                                                            fImp.pSt_imprimir,
                                                                            fImp.pSt_visualizar,
                                                                            fImp.pSt_enviaremail,
                                                                            fImp.pSt_exportPdf,
                                                                            fImp.Path_exportPdf,
                                                                            fImp.pDestinatarios,
                                                                            "BLOQUETO(S) DO DOCUMENTO Nº " + (fDuplicata.dsDuplicata.Current as TRegistro_LanDuplicata).Nr_docto,
                                                                            fImp.pDs_mensagem,
                                                                            false);
                                }
                            //Imprimir Duplicata
                            else if ((fDuplicata.dsDuplicata.Current as TRegistro_LanDuplicata).Tp_mov.Trim().ToUpper().Equals("R"))
                            {
                                object obj = new TCD_CadTpDoctoDup().BuscarEscalar(
                                                new TpBusca[]
                                                {
                                                    new TpBusca()
                                                    {
                                                        vNM_Campo = "a.tp_docto",
                                                        vOperador = "=",
                                                        vVL_Busca = (fDuplicata.dsDuplicata.Current as TRegistro_LanDuplicata).Tp_doctostring
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
                                            TCN_CadEmpresa.Busca((fDuplicata.dsDuplicata.Current as TRegistro_LanDuplicata).Cd_empresa,
                                                                                        string.Empty,
                                                                                        string.Empty,
                                                                                        null);
                                        //Buscar dados do sacado
                                        TList_CadClifor lSacado =
                                            TCN_CadClifor.Busca_Clifor((fDuplicata.dsDuplicata.Current as TRegistro_LanDuplicata).Cd_clifor,
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
                                                TCN_CadEndereco.Buscar((fDuplicata.dsDuplicata.Current as TRegistro_LanDuplicata).Cd_clifor,
                                                                                                          (fDuplicata.dsDuplicata.Current as TRegistro_LanDuplicata).Cd_endereco,
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
                                        fImp.pCd_clifor = (fDuplicata.dsDuplicata.Current as TRegistro_LanDuplicata).Cd_clifor;
                                        if (CamadaNegocio.ConfigGer.TCN_CadParamGer.BuscaVL_Bool("ST_CARNE",
                                                                         (fDuplicata.dsDuplicata.Current as TRegistro_LanDuplicata).Cd_empresa,
                                                                         null).Trim().ToUpper().Equals("S"))
                                        {
                                            FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                                            //Duplicata
                                            BindingSource bs = new BindingSource();
                                            bs.DataSource = fDuplicata.dsDuplicata;
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
                                            bs_parc.DataSource = (fDuplicata.dsDuplicata.Current as TRegistro_LanDuplicata).Parcelas;
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
                                            fImp.pMensagem = "CARNÊ DUPLICATAS(S) DO DOCUMENTO Nº " + (fDuplicata.dsDuplicata.Current as TRegistro_LanDuplicata).Nr_docto;

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
                                                                   "CARNÊ DUPLICATAS(S) DO DOCUMENTO Nº " + (fDuplicata.dsDuplicata.Current as TRegistro_LanDuplicata).Nr_docto,
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
                                                                   "CARNÊ DUPLICATAS(S) DO DOCUMENTO Nº " + (fDuplicata.dsDuplicata.Current as TRegistro_LanDuplicata).Nr_docto,
                                                                   fImp.pDs_mensagem);
                                        }
                                        else
                                        {
                                            fImp.pMensagem = "DUPLICATAS DO DOCUMENTO Nº" + (fDuplicata.dsDuplicata.Current as TRegistro_LanDuplicata).Nr_docto;
                                            if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                                                TCN_LayoutDuplicata.Imprime_Duplicata(false,
                                                                                      (fDuplicata.dsDuplicata.Current as TRegistro_LanDuplicata).Parcelas,
                                                                                      lEmpresa,
                                                                                      lSacado,
                                                                                      fImp.pSt_imprimir,
                                                                                      fImp.pSt_visualizar,
                                                                                      fImp.pSt_exportPdf,
                                                                                      fImp.Path_exportPdf,
                                                                                      fImp.pSt_enviaremail,
                                                                                      fImp.pDestinatarios,
                                                                                      "DUPLICATAS(S) DO DOCUMENTO Nº " + (fDuplicata.dsDuplicata.Current as TRegistro_LanDuplicata).Nr_docto,
                                                                                      fImp.pDs_mensagem);
                                        }
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.Trim());
                        BS_Duplicata.CancelEdit();
                    }
                }
            }
        }

        private string BuscarMoedaPadrao(string pCd_empresa)
        {
            TList_Moeda tb_moeda = CamadaNegocio.ConfigGer.TCN_CadParamGer_X_Empresa.BuscarMoedaPadrao(pCd_empresa, null);
            if (tb_moeda != null)
                if (tb_moeda.Count > 0)
                    return tb_moeda[0].Cd_moeda;
                else
                    return string.Empty;
            else
                return string.Empty;
        }

        private void afterLiquidar()
        {
            if (bsParcelas.Count > 0)
            {
                List<TRegistro_LanParcela> lParc = (bsParcelas.List as TList_RegLanParcela).FindAll(p => p.St_processar);
                if (lParc.Count > 0)
                {
                    string pCd_empresa = lParc[0].Cd_empresa;
                    string pTp_mov = lParc[0].Tp_mov;
                    string pCd_moeda = lParc[0].Cd_moeda;
                    string pCd_clifor = lParc[0].Cd_clifor;
                    lParc = lParc.FindAll(p => p.Cd_empresa.Trim().Equals(pCd_empresa.Trim()) &&
                                              p.Tp_mov.Trim().ToUpper().Equals(pTp_mov.Trim().ToUpper()) &&
                                              p.Cd_moeda.Trim().Equals(pCd_moeda.Trim()) &&
                                              p.Cd_clifor.Trim().Equals(pCd_clifor.Trim()));
                    using (TFLanLiquidacao fLiquidacao = new TFLanLiquidacao())
                    {
                        fLiquidacao.vTp_mov = lParc[0].Tp_mov;
                        fLiquidacao.vCd_clifor = lParc[0].Cd_clifor;
                        fLiquidacao.vCd_moeda = lParc[0].Cd_moeda;
                        fLiquidacao.vCd_moeda_padrao = BuscarMoedaPadrao(lParc[0].Cd_empresa);
                        fLiquidacao.vCd_empresa = lParc[0].Cd_empresa;
                        fLiquidacao.vCd_historico = lParc[0].Cd_historico;
                        fLiquidacao.NrDoc.Text = lParc[0].Nr_docto;
                        fLiquidacao.pFiltro.Enabled = false;
                        fLiquidacao.LParcela = lParc;
                        fLiquidacao.ShowDialog();
                        afterBusca();
                    }
                }
            }
        }

        private void afterBusca()
        {
            if (st_busca)
            {
                tcDadosDocumentos.SelectedTab = tpParcelas;
                bsParcelas.DataSource = new TCD_LanParcela().Select(PreparaBusca_parcela(), 0, string.Empty, "a.dt_vencto, c.nm_clifor", string.Empty);
                SomarVlSelecionado();
                SomarCamposParcelas();
                if (BS_Duplicata.Count.Equals(0) && (bsParcelas.Current != null))
                    BS_Duplicata.DataSource = BuscarDuplicata((bsParcelas.Current as TRegistro_LanParcela).Cd_empresa,
                                                              (bsParcelas.Current as TRegistro_LanParcela).Nr_lanctostr);
                bsParcelas_PositionChanged(this, new EventArgs());
            }
            else
                MessageBox.Show("Usuário não tem acesso a nenhum TP.Duplicata!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void afterCancela()
        {
            //Validar usuário para operação
            if (!TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin, "PERMITIR EXCLUSAO DE DOCUMENTO FINANCEIRO", null))
            {
                using (Parametros.Diversos.TFRegraUsuario fRegra = new Parametros.Diversos.TFRegraUsuario())
                {
                    fRegra.Login = Utils.Parametros.pubLogin;
                    fRegra.Ds_regraespecial = "PERMITIR EXCLUSAO DE DOCUMENTO FINANCEIRO";
                    if (fRegra.ShowDialog() == DialogResult.Cancel)
                    {
                        MessageBox.Show("Não será possível finalizar a operação.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }

            if (tcDadosDocumentos.SelectedTab.Equals(tpDocumento))
            {
                if (BS_Duplicata.Current != null)
                {
                    InputBox input = new InputBox(string.Empty, "Informe o motivo do cancelamento");
                    string mov = input.ShowDialog();
                    if (string.IsNullOrEmpty(mov))
                    {
                        MessageBox.Show("Não será possível finalizar a operação.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if ((BS_Duplicata.Current as TRegistro_LanDuplicata).St_registro.Trim().ToUpper().Equals("A"))
                    {
                        //Verificar se a duplicata teve origem folha pagamento
                        object obj = new CamadaDados.Financeiro.Folha_Pagamento.TCD_Folha_X_Funcionarios().BuscarEscalar(
                                        new TpBusca[]
                                        {
                                            new TpBusca()
                                            {
                                                vNM_Campo = "a.cd_empresa",
                                                vOperador = "=",
                                                vVL_Busca = "'" + (BS_Duplicata.Current as TRegistro_LanDuplicata).Cd_empresa.Trim() + "'"
                                            },
                                            new TpBusca()
                                            {
                                                vNM_Campo = "a.nr_lancto",
                                                vOperador = "=",
                                                vVL_Busca = (BS_Duplicata.Current as TRegistro_LanDuplicata).Nr_lancto.ToString()
                                            }
                                        }, "a.id_folha");
                        if (MessageBox.Show((obj != null ? "Duplicata teve origem no lote de folha pagamento Nº " + obj.ToString() + "\r\n" : string.Empty) + "Confirma cancelamento do documento?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                            try
                            {
                                (BS_Duplicata.Current as TRegistro_LanDuplicata).MotivoCanc = mov;
                                TCN_LanDuplicata.CancelarDuplicata(BS_Duplicata.Current as TRegistro_LanDuplicata, null);
                                MessageBox.Show("Documento cancelado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                afterBusca();
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    }
                }
                    
            }
            else if (tcDadosDocumentos.SelectedTab.Equals(tpLiquidacao))
            {
                if (bsLiquidacoes.Current != null)
                {
                    InputBox input = new InputBox(string.Empty, "Informe o motivo do cancelamento");
                    string mov = input.ShowDialog();
                    if (string.IsNullOrEmpty(mov))
                    {
                        MessageBox.Show("Não será possível finalizar a operação.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if ((bsLiquidacoes.Current as TRegistro_LanLiquidacao).St_registro.Trim().ToUpper().Equals("A"))
                        if (MessageBox.Show("Confirma cancelamento da liquidação?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                        {
                            //Gravar liquidacao
                            ThreadEspera tEspera = new ThreadEspera("Inicio do processo gravar liquidação...");
                            try
                            {
                                (bsLiquidacoes.Current as TRegistro_LanLiquidacao).MotivoCanc = mov;
                                TCN_LanLiquidacao.CancelarLiquidacao((bsLiquidacoes.Current as TRegistro_LanLiquidacao), tEspera, null);
                                MessageBox.Show("Liquidação cancelada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                bsLiquidacoes.RemoveCurrent();
                                afterBusca();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            finally
                            {
                                tEspera.Fechar();
                                tEspera = null;
                            }
                        }
                }
                    
            }
        }

        private void afterAltera()
        {
            if (BS_Duplicata.Current != null)
            {
                using (TFLanDuplicata fDup = new TFLanDuplicata())
                {
                    //Buscar Parcelas Duplicata
                    (BS_Duplicata.Current as TRegistro_LanDuplicata).Parcelas =
                        TCN_LanParcela.Busca((BS_Duplicata.Current as TRegistro_LanDuplicata).Cd_empresa,
                                                                                (BS_Duplicata.Current as TRegistro_LanDuplicata).Nr_lancto,
                                                                                 decimal.Zero,
                                                                                 string.Empty,
                                                                                 string.Empty,
                                                                                 string.Empty,
                                                                                 string.Empty,
                                                                                 string.Empty,
                                                                                 0,
                                                                                 string.Empty,
                                                                                 null);
                    fDup.dsDuplicata.DataSource = BS_Duplicata.Current as TRegistro_LanDuplicata;
                    fDup.dsDuplicata.ResetCurrentItem();
                    fDup.vSt_alterar = true;
                    //Verificar se existe algum bloqueto descontado para a duplicata
                    object ojb = new TCD_LanParcela().BuscarEscalar(
                        new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = string.Empty,
                                vOperador = "exists",
                                vVL_Busca = "(select 1 from tb_cob_titulo x "+
                                            "where x.cd_empresa = a.cd_empresa "+
                                            "and x.nr_lancto = a.nr_lancto "+
                                            "and x.cd_parcela = a.cd_parcela "+
                                            "and isnull(x.st_registro, 'A') = 'D' "+
                                            "and a.cd_empresa = '"+(fDup.dsDuplicata.Current as TRegistro_LanDuplicata).Cd_empresa+"'"+
                                            "and a.nr_lancto = "+(fDup.dsDuplicata.Current as TRegistro_LanDuplicata).Nr_lancto.ToString()+")"
                            }
                        }, "1");
                    if ((TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin.Trim(), "PERMITIR ALTERACAO DE VALORES FINANCEIROS", null)) &&
                        (ojb == null) &&
                        (!(BS_Duplicata.Current as TRegistro_LanDuplicata).Parcelas.Exists(p => p.St_registro.Trim().ToUpper().Equals("P")
                                                                                            || p.St_registro.Trim().ToUpper().Equals("L"))))
                        fDup.st_habilitaralterarvalor = true;

                    if (fDup.ShowDialog() == DialogResult.OK)
                        if (fDup.dsDuplicata.Current != null)
                            try
                            {
                                if ((BS_Duplicata.Current as TRegistro_LanDuplicata).lCustoLancto.Count == 0 ? false :
                                    (fDup.dsDuplicata.Current as TRegistro_LanDuplicata).Vl_documento_padrao !=
                                    (BS_Duplicata.Current as TRegistro_LanDuplicata).lCustoLancto.Sum(p => p.Vl_lancto))
                                    if ((BS_Duplicata.Current as TRegistro_LanDuplicata).lCustoLancto.Count > 1)
                                    {
                                        using (TFRateioCResultado fRateio = new TFRateioCResultado())
                                        {
                                            fRateio.vVl_Documento = (fDup.dsDuplicata.Current as TRegistro_LanDuplicata).Vl_documento_padrao;
                                            fRateio.lCResultadoDel = (fDup.dsDuplicata.Current as TRegistro_LanDuplicata).lCustoLancto;
                                            fRateio.Tp_mov = (fDup.dsDuplicata.Current as TRegistro_LanDuplicata).Tp_mov;
                                            fRateio.Dt_movimento = (fDup.dsDuplicata.Current as TRegistro_LanDuplicata).Dt_emissao;
                                            if (fRateio.ShowDialog() == DialogResult.OK)
                                            {
                                                (fDup.dsDuplicata.Current as TRegistro_LanDuplicata).lCustoLancto = fRateio.lCResultado;
                                                (fDup.dsDuplicata.Current as TRegistro_LanDuplicata).lCustoLanctoDel = fRateio.lCResultadoDel;
                                            }
                                            else
                                                return;
                                        }
                                    }
                                    else if ((BS_Duplicata.Current as TRegistro_LanDuplicata).lCustoLancto.Count == 1)
                                        (BS_Duplicata.Current as TRegistro_LanDuplicata).lCustoLancto[0].Vl_lancto = (BS_Duplicata.Current as TRegistro_LanDuplicata).Vl_documento_padrao;
                                if (TCN_LanDuplicata.AlterarDuplicata(fDup.dsDuplicata.Current as TRegistro_LanDuplicata, null).Trim() != string.Empty)
                                    MessageBox.Show("Duplicata alterada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }

                    afterBusca();
                }
            }
            else
                MessageBox.Show("Não existe duplicata selecionada para ser alterada.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void afterCobranca()
        {
            if (bsParcelas.Count > 0)
            {
                if ((bsParcelas.List as TList_RegLanParcela).Exists(p => p.St_processar))
                    using (TFLan_Cobranca fCobranca = new TFLan_Cobranca())
                    {
                        fCobranca.lParc = (bsParcelas.List as TList_RegLanParcela).FindAll(p => p.St_processar);
                        fCobranca.ShowDialog();
                        afterBusca();
                    }
                else
                    MessageBox.Show("Não existe parcela selecionada para gerar cobrança.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ImprimirRecibo()
        {
            if (bsLiquidacoes.Current != null)
            {
                TList_RegLanDuplicata lDup = BuscarDuplicata((bsParcelas.Current as TRegistro_LanParcela).Cd_empresa,
                                                             (bsParcelas.Current as TRegistro_LanParcela).Nr_lanctostr);
                object obj = new TCD_CadTerminal().BuscarEscalar(
                                   new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.cd_terminal",
                                            vOperador = "=",
                                            vVL_Busca = "'" + Utils.Parametros.pubTerminal.Trim() + "'"
                                        }
                                    }, "a.tp_imprecibo");
                if (obj == null ? false : obj.ToString().Trim().ToUpper().Equals("T"))
                {
                    TCN_LayoutRecibo.Imprime_ReciboTexto(lDup[0].Nr_docto.Trim() + "/" + (bsLiquidacoes.Current as TRegistro_LanLiquidacao).Cd_parcela.ToString(),
                                                                       (bsLiquidacoes.Current as TRegistro_LanLiquidacao));
                }
                else if (obj == null ? false : obj.ToString().Trim().ToUpper().Equals("R"))
                {
                    TCN_LayoutRecibo.Imprime_ReciboReduzido(lDup[0].Nr_docto.Trim() + "/" + (bsLiquidacoes.Current as TRegistro_LanLiquidacao).Cd_parcela.ToString(),
                                                                       (bsLiquidacoes.Current as TRegistro_LanLiquidacao));
                }
                else if (obj == null ? false : obj.ToString().Trim().ToUpper().Equals("F"))
                {
                    TCN_LayoutRecibo.Imprime_ReciboGraficoReduzido(Altera_Relatorio,
                                                                  lDup[0].Nr_docto.Trim() + "/" + (bsLiquidacoes.Current as TRegistro_LanLiquidacao).Cd_parcela.ToString(),
                                                                  (bsLiquidacoes.Current as TRegistro_LanLiquidacao),
                                                                  lDup);
                    Altera_Relatorio = false;
                }
                else
                {
                    TCN_LayoutRecibo.Imprime_Recibo(Altera_Relatorio,
                                                                  lDup[0].Nr_docto.Trim() + "/" + (bsLiquidacoes.Current as TRegistro_LanLiquidacao).Cd_parcela.ToString(),
                                                                  (bsLiquidacoes.Current as TRegistro_LanLiquidacao),
                                                                  lDup);
                    Altera_Relatorio = false;
                }
            }
        }

        private void ImprimirDuplicata(string Layout)
        {
            if (bsParcelas.Current != null)
            {
                //Buscar parcela
                TList_RegLanDuplicata lDup =
                    TCN_LanDuplicata.Busca((bsParcelas.Current as TRegistro_LanParcela).Cd_empresa,
                                           (bsParcelas.Current as TRegistro_LanParcela).Nr_lanctostr,
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
                                           true,
                                           0,
                                           string.Empty,
                                           null);
                lDup[0].Parcelas =
                    new TCD_LanParcela().Select(
                        new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = "a.cd_empresa",
                                vOperador = "=",
                                vVL_Busca = "'" + lDup[0].Cd_empresa.Trim() + "'"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "a.nr_lancto",
                                vOperador = "=",
                                vVL_Busca = "" + lDup[0].Nr_lancto + ""
                            }
                        }, 0, string.Empty, string.Empty, string.Empty);
                if (lDup.Count > 0)
                    using (TFGerenciadorImpressao fImp = new TFGerenciadorImpressao())
                    {
                        //Buscar dados Empresa
                        TList_CadEmpresa lEmpresa =
                            TCN_CadEmpresa.Busca(lDup[0].Cd_empresa,
                                                 string.Empty,
                                                 string.Empty,
                                                 null);
                        //Buscar dados do sacado
                        TList_CadClifor lSacado = TCN_CadClifor.Busca_Clifor(lDup[0].Cd_clifor,
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
                            lSacado[0].lEndereco = TCN_CadEndereco.Buscar(lDup[0].Cd_clifor,
                                                                          lDup[0].Cd_endereco,
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
                        fImp.pCd_clifor = lDup[0].Cd_clifor;
                        if (Layout.Trim().ToUpper().Equals("C"))
                        {
                            FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                            Rel.Altera_Relatorio = Altera_Relatorio;
                            //Duplicata
                            BindingSource bs = new BindingSource();
                            bs.DataSource = lDup;
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
                            bs_parc.DataSource = lDup[0].Parcelas;
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
                            fImp.pMensagem = "CARNÊ DUPLICATAS(S) DO DOCUMENTO Nº " + lDup[0].Nr_docto;

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
                                                   "CARNÊ DUPLICATAS(S) DO DOCUMENTO Nº " + lDup[0].Nr_docto,
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
                                                   "CARNÊ DUPLICATAS(S) DO DOCUMENTO Nº " + lDup[0].Nr_docto,
                                                   fImp.pDs_mensagem);
                        }
                        else
                        {
                            fImp.pMensagem = "DUPLICATAS DO DOCUMENTO Nº" + lDup[0].Nr_docto;
                            if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                            {
                                TCN_LayoutDuplicata.Imprime_Duplicata(Altera_Relatorio,
                                                                      lDup[0].Parcelas.FindAll(p => p.Cd_parcela == (bsParcelas.Current as TRegistro_LanParcela).Cd_parcela),
                                                                      lEmpresa,
                                                                      lSacado,
                                                                      fImp.pSt_imprimir,
                                                                      fImp.pSt_visualizar,
                                                                      fImp.pSt_exportPdf,
                                                                      fImp.Path_exportPdf,
                                                                      fImp.pSt_enviaremail,
                                                                      fImp.pDestinatarios,
                                                                      "DUPLICATAS(S) DO DOCUMENTO Nº " + lDup[0].Nr_docto,
                                                                      fImp.pDs_mensagem);
                                Altera_Relatorio = false;
                            }
                        }
                    }
            }
        }

        private void AlterarCResultado()
        {
            if (bsDupCCusto.Current != null && bsCentroresult.Current != null)
            {
                if ((bsCentroresult.Current as TRegistro_CentroResultado).St_sinteticobool)
                {
                    MessageBox.Show("Selecione o centro de resultado análitico para alterar!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                using (TFAlterarCResultado fAlterarCCusto = new TFAlterarCResultado())
                {
                    fAlterarCCusto.Tp_movimento = (BS_Duplicata.Current as TRegistro_LanDuplicata).Tp_mov.Trim().ToUpper().Equals("P") ? "DESPESA" : "RECEITA";
                    fAlterarCCusto.rCusto = (BS_Duplicata.Current as TRegistro_LanDuplicata).lCustoLancto.FindAll(p => p.Cd_centroresult.Equals((bsCentroresult.Current as TRegistro_CentroResultado).Cd_centroresult))[0];
                    if (fAlterarCCusto.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            fAlterarCCusto.rCusto.Cd_centroresult = fAlterarCCusto.rCusto.Cd_ccustoalt;
                            CamadaNegocio.Financeiro.CCustoLan.TCN_LanCCustoLancto.Gravar(fAlterarCCusto.rCusto, null);
                            MessageBox.Show("Lançamento Centro Resultado alterado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //Buscar Duplicata da Parcela
                            tcDadosDocumentos_SelectedIndexChanged(this, new EventArgs());
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
                MessageBox.Show("Obrigatorio selecionar lançamento centro resultado para alterar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void SomarVlSelecionado()
        {
            if (bsParcelas.Count > 0)
            {
                soma_atual_p.Value = (bsParcelas.DataSource as TList_RegLanParcela).FindAll(p => p.St_processar && p.Tp_mov.Trim().ToUpper().Equals("P")).Sum(p => p.cVl_atual);
                soma_atual_r.Value = (bsParcelas.DataSource as TList_RegLanParcela).FindAll(p => p.St_processar && p.Tp_mov.Trim().ToUpper().Equals("R")).Sum(p => p.cVl_atual);
            }
        }

        private void AgruparFinanceiro()
        {
            using (TFAgruparDuplicata fAgrupar = new TFAgruparDuplicata())
            {
                if (fAgrupar.ShowDialog() == DialogResult.OK)
                    if (fAgrupar.lParcela != null)
                        using (Financeiro.TFLanDuplicata fDuplicata = new Financeiro.TFLanDuplicata())
                        {
                            if (!fAgrupar.vPorCategoria)
                            {
                                fDuplicata.vCd_clifor = fAgrupar.lParcela[0].Cd_clifor;
                                fDuplicata.vNm_clifor = fAgrupar.lParcela[0].Nm_clifor;
                                fDuplicata.vCd_endereco = fAgrupar.lParcela[0].Cd_endereco;
                            }
                            fDuplicata.vSt_agrupar = true;
                            fDuplicata.vCd_empresa = fAgrupar.lParcela[0].Cd_empresa;
                            fDuplicata.vNm_empresa = fAgrupar.lParcela[0].Nm_empresa;
                            fDuplicata.vTp_duplicata = fAgrupar.lParcela[0].Tp_duplicata;
                            fDuplicata.vTp_mov = fAgrupar.lParcela[0].Tp_mov;
                            fDuplicata.vVl_documento = fAgrupar.lParcela.Sum(p => p.cVl_atual) + fAgrupar.pVl_juro - fAgrupar.pVl_desconto;
                            if (fDuplicata.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                                if (fDuplicata.dsDuplicata.Count > 0)
                                    try
                                    {
                                        string ret = TCN_LanDuplicata.AgruparDuplicata(fDuplicata.dsDuplicata.Current as TRegistro_LanDuplicata,
                                                                                                                          fAgrupar.lParcela,
                                                                                                                          fAgrupar.pVl_juro,
                                                                                                                          fAgrupar.pVl_desconto,
                                                                                                                          null);
                                        if (!string.IsNullOrEmpty(ret))
                                        {
                                            string lan = CamadaDados.TDataQuery.getPubVariavel(ret, "@P_NR_LANCTO");
                                            BS_Duplicata.EndEdit();

                                            MessageBox.Show("Lançamento Financeiro nr:" + lan + " Gravado com Sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            //Imprimir Boleto
                                            CamadaDados.Financeiro.Bloqueto.blListaTitulo lBloqueto =
                                                CamadaNegocio.Financeiro.Bloqueto.TCN_Titulo.Buscar((fDuplicata.dsDuplicata.Current as TRegistro_LanDuplicata).Cd_empresa,
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
                                                using (TFGerenciadorImpressao fImp = new TFGerenciadorImpressao())
                                                {
                                                    fImp.St_enabled_enviaremail = true;
                                                    fImp.pCd_clifor = (fDuplicata.dsDuplicata.Current as TRegistro_LanDuplicata).Cd_clifor;
                                                    fImp.pMensagem = "BLOQUETOS DO DOCUMENTO Nº" + (fDuplicata.dsDuplicata.Current as TRegistro_LanDuplicata).Nr_docto;
                                                    if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                                                        TCN_LayoutBloqueto.Imprime_Bloqueto(false,
                                                                                            lBloqueto,
                                                                                            fImp.pSt_imprimir,
                                                                                            fImp.pSt_visualizar,
                                                                                            fImp.pSt_enviaremail,
                                                                                            fImp.pSt_exportPdf,
                                                                                            fImp.Path_exportPdf,
                                                                                            fImp.pDestinatarios,
                                                                                            "BLOQUETO(S) DO DOCUMENTO Nº " + (fDuplicata.dsDuplicata.Current as TRegistro_LanDuplicata).Nr_docto,
                                                                                            fImp.pDs_mensagem,
                                                                                            false);
                                                }
                                            //Imprimir Duplicata
                                            if ((fDuplicata.dsDuplicata.Current as TRegistro_LanDuplicata).Tp_mov.Trim().ToUpper().Equals("R"))
                                            {
                                                object obj = new TCD_CadTpDoctoDup().BuscarEscalar(
                                                                new TpBusca[]
                                            {
                                                new TpBusca()
                                                {
                                                    vNM_Campo = "a.tp_docto",
                                                    vOperador = "=",
                                                    vVL_Busca = (fDuplicata.dsDuplicata.Current as TRegistro_LanDuplicata).Tp_doctostring
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
                                                        fImp.St_enabled_enviaremail = true;
                                                        fImp.pCd_clifor = (fDuplicata.dsDuplicata.Current as TRegistro_LanDuplicata).Cd_clifor;
                                                        if (CamadaNegocio.ConfigGer.TCN_CadParamGer.BuscaVL_Bool("ST_CARNE",
                                                                         (bsParcelas.Current as TRegistro_LanParcela).Cd_empresa,
                                                                         null).Trim().ToUpper().Equals("S"))
                                                        {
                                                            //Buscar dados Empresa
                                                            TList_CadEmpresa lEmpresa =
                                                                TCN_CadEmpresa.Busca((fDuplicata.dsDuplicata.Current as TRegistro_LanDuplicata).Cd_empresa,
                                                                                                            string.Empty,
                                                                                                            string.Empty,
                                                                                                            null);
                                                            //Buscar dados do sacado
                                                            TList_CadClifor lSacado =
                                                                CamadaNegocio.Financeiro.Cadastros.TCN_CadClifor.Busca_Clifor((fDuplicata.dsDuplicata.Current as TRegistro_LanDuplicata).Cd_clifor,
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
                                                                    CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Buscar((fDuplicata.dsDuplicata.Current as TRegistro_LanDuplicata).Cd_clifor,
                                                                                                                              (fDuplicata.dsDuplicata.Current as TRegistro_LanDuplicata).Cd_endereco,
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

                                                            FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                                                            Rel.Altera_Relatorio = Altera_Relatorio;
                                                            //Duplicata
                                                            BindingSource bs = new BindingSource();
                                                            bs.DataSource = fDuplicata.dsDuplicata;
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
                                                            bs_parc.DataSource = (fDuplicata.dsDuplicata.Current as TRegistro_LanDuplicata).Parcelas;
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
                                                            fImp.pMensagem = "CARNÊ DUPLICATAS(S) DO DOCUMENTO Nº " + (fDuplicata.dsDuplicata.Current as TRegistro_LanDuplicata).Nr_docto;

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
                                                                                   "CARNÊ DUPLICATAS(S) DO DOCUMENTO Nº " + (fDuplicata.dsDuplicata.Current as TRegistro_LanDuplicata).Nr_docto,
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
                                                                                   "CARNÊ DUPLICATAS(S) DO DOCUMENTO Nº " + (fDuplicata.dsDuplicata.Current as TRegistro_LanDuplicata).Nr_docto,
                                                                                   fImp.pDs_mensagem);
                                                        }
                                                        else
                                                        {
                                                            fImp.pMensagem = "DUPLICATAS DO DOCUMENTO Nº" + (fDuplicata.dsDuplicata.Current as TRegistro_LanDuplicata).Nr_docto;
                                                            if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                                                                TCN_LayoutDuplicata.Imprime_Duplicata(false,
                                                                                                      (fDuplicata.dsDuplicata.Current as TRegistro_LanDuplicata).Parcelas,
                                                                                                      null,
                                                                                                      null,
                                                                                                      fImp.pSt_imprimir,
                                                                                                      fImp.pSt_visualizar,
                                                                                                      fImp.pSt_exportPdf,
                                                                                                      fImp.Path_exportPdf,
                                                                                                      fImp.pSt_enviaremail,
                                                                                                      fImp.pDestinatarios,
                                                                                                      "DUPLICATAS(S) DO DOCUMENTO Nº " + (fDuplicata.dsDuplicata.Current as TRegistro_LanDuplicata).Nr_docto,
                                                                                                      fImp.pDs_mensagem);
                                                        }
                                                    }
                                                }
                                            }
                                            afterBusca();
                                        }
                                    }
                                    catch (Exception ex)
                                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                        }
            }
        }

        private void DuplicataPerdida()
        {
            if (bsParcelas.Current != null)
                if ((bsParcelas.DataSource as TList_RegLanParcela).Exists(p => p.St_processar))
                {
                    if (MessageBox.Show("Deseja marcar as parcelas selecionadas como perdidas?", "Pergunta",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                        try
                        {
                            TCN_LanDuplicata.DuplicatasPerdidas(bsParcelas.DataSource as TList_RegLanParcela, null);
                            MessageBox.Show("Duplicatas processadas com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            afterBusca();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
                else
                    MessageBox.Show("Não existe duplicatas selecionadas para marcar como perdida.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void CD_Empresa_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.cd_empresa|=|'" + CD_Empresa.Text.Trim() + "';" +
                              "|exists|(select 1 from tb_div_usuario_x_empresa x " +
                              "where x.cd_empresa = a.cd_empresa " +
                              "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                              "(exists(select 1 from tb_div_usuario_x_grupos y " +
                              "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_Empresa }, new TCD_CadEmpresa());
        }

        private void BB_Empresa_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("a.NM_empresa|Nome Empresa|300;a.CD_Empresa|Cd.Empresa|80"
               , new Componentes.EditDefault[] { CD_Empresa }, new TCD_CadEmpresa(),
               "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.cd_empresa = A.cd_empresa " +
               "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
               "(exists(select 1 from tb_div_usuario_x_grupos y " +
               "        where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))");
        }

        private void CD_Clifor_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.cd_clifor|=|'" + CD_Clifor.Text + "'"
                , new Componentes.EditDefault[] { CD_Clifor }, new TCD_CadClifor());
        }

        private void BB_Clifor_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { CD_Clifor }, String.Empty);
        }

        private void CD_Endereco_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_moeda|=|'" + cd_moeda.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_moeda },
                                    new TCD_Moeda());
        }

        private void BB_Endereco_Click(object sender, EventArgs e)
        {
            string vColunas = "a.DS_Moeda_Singular|Moeda|300;" +
                              "a.CD_Moeda|Cd. Moeda|80";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_moeda },
                                    new TCD_Moeda(), string.Empty);
        }

        private void CD_Historico_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.CD_Historico|=|'" + CD_Historico.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_Historico },
                                    new TCD_CadHistorico());
        }

        private void BB_Historico_Click(object sender, EventArgs e)
        {
            string vColunas = "a.CD_Historico|Cód. Histórico|100;" +
            "a.DS_Historico|Descrição Histórico|200";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_Historico },
                                    new TCD_CadHistorico(), string.Empty);
        }

        private void SomarCamposParcelas()
        {
            //Pagar
            Tot_Parcelas.Value = (bsParcelas.DataSource as TList_RegLanParcela).Where(p => p.Tp_mov.Trim().ToUpper().Equals("P")).Sum(p => p.Vl_parcela_padrao);
            Tot_Liquidado.Value = (bsParcelas.DataSource as TList_RegLanParcela).Where(p => p.Tp_mov.Trim().ToUpper().Equals("P")).Sum(p => p.Vl_liquidado);
            tot_vencer.Value = (bsParcelas.DataSource as TList_RegLanParcela).Where(p => p.Tp_mov.Trim().ToUpper().Equals("P") &&
                                                                                        (p.Status_parcela.Trim().ToUpper().Equals("ABERTA") ||
                                                                                        p.Status_parcela.Trim().ToUpper().Equals("PARCIAL"))).Sum(p => p.cVl_atual);
            tot_vencida.Value = (bsParcelas.DataSource as TList_RegLanParcela).Where(p => p.Tp_mov.Trim().ToUpper().Equals("P") &&
                                                                                         p.Status_parcela.Trim().ToUpper().Equals("VENCIDA")).Sum(p => p.cVl_atual);
            Tot_Atual.Value = (bsParcelas.DataSource as TList_RegLanParcela).Where(p => p.Tp_mov.Trim().ToUpper().Equals("P")).Sum(p => p.cVl_atual);
            Tot_Juro.Value = (bsParcelas.DataSource as TList_RegLanParcela).Where(p => p.Tp_mov.Trim().ToUpper().Equals("P")).Sum(p => p.Vl_JuroLiquid);
            Tot_Desconto.Value = (bsParcelas.DataSource as TList_RegLanParcela).Where(p => p.Tp_mov.Trim().ToUpper().Equals("P")).Sum(p => p.Vl_DescLiquid);
            Tot_DifCambAT.Value = (bsParcelas.DataSource as TList_RegLanParcela).Where(p => p.Tp_mov.Trim().ToUpper().Equals("P")).Sum(p => p.Vl_difcambAT);
            Tot_DifCambPA.Value = (bsParcelas.DataSource as TList_RegLanParcela).Where(p => p.Tp_mov.Trim().ToUpper().Equals("P")).Sum(p => p.Vl_difcambPA);
            //Receber
            tot_parcelas_r.Value = (bsParcelas.DataSource as TList_RegLanParcela).Where(p => p.Tp_mov.Trim().ToUpper().Equals("R")).Sum(p => p.Vl_parcela_padrao);
            tot_liquidado_r.Value = (bsParcelas.DataSource as TList_RegLanParcela).Where(p => p.Tp_mov.Trim().ToUpper().Equals("R")).Sum(p => p.Vl_liquidado); ;
            tot_vencer_r.Value = (bsParcelas.DataSource as TList_RegLanParcela).Where(p => p.Tp_mov.Trim().ToUpper().Equals("R") &&
                                                                                        (p.Status_parcela.Trim().ToUpper().Equals("ABERTA") ||
                                                                                        p.Status_parcela.Trim().ToUpper().Equals("PARCIAL"))).Sum(p => p.cVl_atual);
            tot_vencida_r.Value = (bsParcelas.DataSource as TList_RegLanParcela).Where(p => p.Tp_mov.Trim().ToUpper().Equals("R") &&
                                                                                         p.Status_parcela.Trim().ToUpper().Equals("VENCIDA")).Sum(p => p.cVl_atual);
            tot_atual_r.Value = (bsParcelas.DataSource as TList_RegLanParcela).Where(p => p.Tp_mov.Trim().ToUpper().Equals("R")).Sum(p => p.cVl_atual);
            tot_juro_r.Value = (bsParcelas.DataSource as TList_RegLanParcela).Where(p => p.Tp_mov.Trim().ToUpper().Equals("R")).Sum(p => p.Vl_JuroLiquid);
            tot_desconto_r.Value = (bsParcelas.DataSource as TList_RegLanParcela).Where(p => p.Tp_mov.Trim().ToUpper().Equals("R")).Sum(p => p.Vl_DescLiquid);
            tot_dcambat_r.Value = (bsParcelas.DataSource as TList_RegLanParcela).Where(p => p.Tp_mov.Trim().ToUpper().Equals("R")).Sum(p => p.Vl_difcambAT);
            tot_dcambpa_r.Value = (bsParcelas.DataSource as TList_RegLanParcela).Where(p => p.Tp_mov.Trim().ToUpper().Equals("R")).Sum(p => p.Vl_difcambPA);
        }

        private void somarCamposLiquidacao(ref decimal vVl_TotLiquidacao,
                                           ref decimal vVl_TotJuros,
                                           ref decimal vVl_TotDescontos,
                                           ref decimal vVl_TotDifCambAt,
                                           ref decimal vVl_TotDifCambPa)
        {
            vVl_TotDescontos = 0;
            vVl_TotDifCambAt = 0;
            vVl_TotDifCambPa = 0;
            vVl_TotJuros = 0;
            vVl_TotLiquidacao = 0;
            for (int i = 0; i < bsLiquidacoes.Count; i++)
            {
                //Totalizar Vl_Liquidado
                try
                {
                    vVl_TotLiquidacao += (bsLiquidacoes[i] as TRegistro_LanLiquidacao).Vl_liquidado_padrao;
                }
                catch
                { }
                //Totalizar Vl_Juros
                try
                {
                    vVl_TotJuros += (bsLiquidacoes[i] as TRegistro_LanLiquidacao).Vl_JuroAcrescimo;
                }
                catch
                { }
                //Totalizar Vl_Descontos
                try
                {
                    vVl_TotDescontos += (bsLiquidacoes[i] as TRegistro_LanLiquidacao).Vl_DescontoBonus;
                }
                catch
                { }
                //Totalizar DifCamb Ativa
                try
                {
                    vVl_TotDifCambAt += (bsLiquidacoes[i] as TRegistro_LanLiquidacao).Vl_difcamb_at;
                }
                catch
                { }
                //Totalizar DifCamb Passiva
                try
                {
                    vVl_TotDifCambPa += (bsLiquidacoes[i] as TRegistro_LanLiquidacao).Vl_difcamb_pa;
                }
                catch
                { }
            }
        }

        private void TFLanContas_Load(object sender, EventArgs e)
        {
            ShapeGrid.RestoreShape(this, gLiquidacao);
            ShapeGrid.RestoreShape(this, gParcelas);
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
            Icon = ResourcesUtils.TecnoAliance_ICO;
            panelFiltro.set_FormatZero();
            tlpAtVencto.ColumnStyles[1].Width = 0;
            ShapeGrid.RestoreShape(this, gLiquidacao);
            ShapeGrid.RestoreShape(this, gParcelas);
            bb_agruparConvenio.Visible = TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin, "VISUALIZAR FINANCEIRO POSTO", null);
            bb_alterarccusto.Enabled = TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin, "PERMITIR ALTERAR CENTRO RESULTADO", null);
            BB_Liquidar.Visible = tcDadosDocumentos.SelectedTab.Equals(tpParcelas);
            BB_Cobranca.Visible = tcDadosDocumentos.SelectedTab.Equals(tpParcelas);
            bbImpDuplicata.Visible = tcDadosDocumentos.SelectedTab.Equals(tpParcelas) || tcDadosDocumentos.SelectedTab.Equals(tpDocumento);
            bbImpCarnedup.Visible = tcDadosDocumentos.SelectedTab.Equals(tpParcelas) || tcDadosDocumentos.SelectedTab.Equals(tpDocumento);
            BB_Alterar.Visible = tcDadosDocumentos.SelectedTab.Equals(tpDocumento);
            bbImpRecibo.Visible = tcDadosDocumentos.SelectedTab.Equals(tpLiquidacao);
            if (!Utils.Parametros.pubLogin.ToUpper().Equals("MASTER") &&
                !Utils.Parametros.pubLogin.ToUpper().Equals("DESENV"))
            {
                //Verificar se usuario tem acesso a tipo de duplicata
                object st_pagar =
                    new TCD_CadTpDuplicata().BuscarEscalar(
                        new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = "a.tp_mov",
                            vOperador = "=",
                            vVL_Busca = "'P'"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = string.Empty,
                            vOperador = "exists",
                            vVL_Busca = "(select 1 from TB_DIV_Usuario_X_TpDuplicata x " +
                                        "where a.TP_Duplicata = x.TP_Duplicata " +
                                        "and x.login = '" + Utils.Parametros.pubLogin.Trim() + "') "
                        }
                    }, "a.tp_mov");

                //Verificar se usuario tem acesso a tipo de duplicata
                object st_receber =
                    new TCD_CadTpDuplicata().BuscarEscalar(
                        new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = "a.tp_mov",
                            vOperador = "=",
                            vVL_Busca = "'R'"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = string.Empty,
                            vOperador = "exists",
                            vVL_Busca = "(select 1 from TB_DIV_Usuario_X_TpDuplicata x " +
                                        "where a.TP_Duplicata = x.TP_Duplicata " +
                                        "and x.login = '" + Utils.Parametros.pubLogin.Trim() + "') "
                        }
                    }, "a.tp_mov");
                if (st_pagar == null && st_receber == null)
                {
                    cbPagar.Enabled = false;
                    cbReceber.Enabled = false;
                    st_busca = false;
                }
                else if (st_pagar == null && st_receber.Equals("R"))
                {
                    cbPagar.Enabled = false;
                    cbReceber.Enabled = false;
                    cbReceber.Checked = true;
                }
                else if (st_receber == null && st_pagar.Equals("P"))
                {
                    cbPagar.Enabled = false;
                    cbReceber.Enabled = false;
                    cbPagar.Checked = true;
                }
            }
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            afterBusca();
        }

        private TpBusca[] PreparaBusca_parcela()
        {
            TpBusca[] vBusca = new TpBusca[4];
            //Duplicata cancelada
            vBusca[0].vNM_Campo = "isnull(dup.st_registro, 'A')";
            vBusca[0].vOperador = "<>";
            vBusca[0].vVL_Busca = "'C'";
            //Verificar se usuario tem acesso a empresa
            vBusca[1].vNM_Campo = string.Empty;
            vBusca[1].vOperador = "exists";
            vBusca[1].vVL_Busca = "(select 1 from TB_DIV_Usuario_X_Empresa x " +
                                  "where x.cd_empresa = a.cd_empresa " +
                                  "and x.login = '" + Utils.Parametros.pubLogin.Trim() + "') ";
            //Verificar se ussuario tem acesso a TP.Duplicata
            vBusca[2].vNM_Campo = string.Empty;
            vBusca[2].vOperador = "exists";
            vBusca[2].vVL_Busca = "(select 1 from TB_DIV_Usuario_X_TpDuplicata x " +
                                    "where x.tp_duplicata = a.tp_duplicata " +
                                    "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                    "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                    "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            vBusca[3].vNM_Campo = "isnull(a.st_registro, 'A')";
            vBusca[3].vOperador = "<>";
            vBusca[3].vVL_Busca = "'G'";
            //Tipo Movimento
            string vMov = string.Empty;
            string virg = string.Empty;
            if (cbReceber.Checked)
            {
                vMov = "'R'";
                virg = ",";
            }
            if (cbPagar.Checked)
                vMov += virg + "'P'";
            if (!string.IsNullOrEmpty(vMov))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.tp_mov";
                vBusca[vBusca.Length - 1].vOperador = "in";
                vBusca[vBusca.Length - 1].vVL_Busca = "(" + vMov.Trim() + ")";
            }
            if (!string.IsNullOrEmpty(CD_Empresa.Text))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.CD_Empresa";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + CD_Empresa.Text.Trim() + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(NR_Docto.Text))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "dup.NR_Docto";
                vBusca[vBusca.Length - 1].vVL_Busca = "('%" + NR_Docto.Text.Trim() + "%')";
                vBusca[vBusca.Length - 1].vOperador = "like";
            }
            if (!string.IsNullOrEmpty(cmplementohistorico.Text))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "dup.ComplHistorico";
                vBusca[vBusca.Length - 1].vVL_Busca = "('%" + cmplementohistorico.Text.Trim() + "%')";
                vBusca[vBusca.Length - 1].vOperador = "like";
            }
            if (!string.IsNullOrEmpty(id_categoriaclifor.Text))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "c.id_categoriaclifor";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = id_categoriaclifor.Text;
            }
            if (!string.IsNullOrEmpty(Tp_Dup.Text))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "dup.tp_duplicata";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = Tp_Dup.Text.Trim();
            }
            if (!string.IsNullOrEmpty(nr_lancto.Text))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.NR_Lancto";
                vBusca[vBusca.Length - 1].vVL_Busca = nr_lancto.Text;
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(CD_Clifor.Text))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "dup.CD_Clifor";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + CD_Clifor.Text.Trim() + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(cd_moeda.Text))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "dup.CD_Moeda";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + cd_moeda.Text.Trim() + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(CD_Historico.Text))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "dup.CD_Historico";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + CD_Historico.Text.Trim() + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if (VL_Inicial.Value > 0)
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.Vl_Parcela";
                vBusca[vBusca.Length - 1].vVL_Busca = VL_Inicial.Value.ToString(new System.Globalization.CultureInfo("en-US", true));
                vBusca[vBusca.Length - 1].vOperador = ">=";
            }
            if (VL_Final.Value > 0)
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.Vl_Parcela";
                vBusca[vBusca.Length - 1].vVL_Busca = VL_Final.Value.ToString(new System.Globalization.CultureInfo("en-US", true));
                vBusca[vBusca.Length - 1].vOperador = "<=";
            }
            if ((DT_Inicial.Text.Trim() != "") && (DT_Inicial.Text.Trim() != "/  /") &&
                (RB_Emissao.Checked || RB_Vencimento.Checked))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10)," + (RB_Emissao.Checked ? "a.DT_Emissao" : "a.DT_Vencto") + ")))";
                vBusca[vBusca.Length - 1].vOperador = ">=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + DateTime.Parse(DT_Inicial.Text).ToString("yyyyMMdd") + "'";

            }
            if ((DT_Final.Text.Trim() != "") && (DT_Final.Text.Trim() != "/  /") &&
                (RB_Emissao.Checked || RB_Vencimento.Checked))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10)," + (RB_Emissao.Checked ? "a.DT_Emissao" : "a.DT_Vencto") + ")))";
                vBusca[vBusca.Length - 1].vOperador = "<=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + DateTime.Parse(DT_Final.Text).ToString("yyyyMMdd") + "'";
            }
            if (RB_Liquidacao.Checked &&
                ((DT_Inicial.Text.Trim() != "/  /") ||
                (DT_Final.Text.Trim() != "/  /")))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = string.Empty;
                vBusca[vBusca.Length - 1].vOperador = "EXISTS";
                if ((DT_Inicial.Text.Trim() != "/  /") &&
                    (DT_Final.Text.Trim() != "/  /"))
                    vBusca[vBusca.Length - 1].vVL_Busca = "(Select 1 from tb_fin_liquidacao l " +
                                                         "where l.cd_empresa = a.cd_empresa " +
                                                         "and l.nr_lancto = a.nr_lancto " +
                                                         "and l.cd_parcela = a.cd_parcela " +
                                                         "and isnull(l.st_registro, 'A') = 'A' " +
                                                         "and convert(datetime, floor(convert(decimal(30,10), l.dt_liquidacao))) between '" + DateTime.Parse(DT_Inicial.Text).ToString("yyyyMMdd") + "' " +
                                                         "and '" + DateTime.Parse(DT_Final.Text).ToString("yyyyMMdd") + "')";
                else if (DT_Inicial.Text.Trim() != "/  /")
                    vBusca[vBusca.Length - 1].vVL_Busca = "(Select 1 from tb_fin_liquidacao l " +
                                                         "where l.cd_empresa = a.cd_empresa " +
                                                         "and l.nr_lancto = a.nr_lancto " +
                                                         "and l.cd_parcela = a.cd_parcela " +
                                                         "and isnull(l.st_registro, 'A') = 'A' " +
                                                         "and convert(datetime, floor(convert(decimal(30,10), l.dt_liquidacao))) >= '" + DateTime.Parse(DT_Inicial.Text).ToString("yyyyMMdd") + "')";
                else if (DT_Final.Text.Trim() != "/  /")
                    vBusca[vBusca.Length - 1].vVL_Busca = "(Select 1 from tb_fin_liquidacao l " +
                                                         "where l.cd_empresa = a.cd_empresa " +
                                                         "and l.nr_lancto = a.nr_lancto " +
                                                         "and l.cd_parcela = a.cd_parcela " +
                                                         "and isnull(l.st_registro, 'A') = 'A' " +
                                                         "and convert(datetime, floor(convert(decimal(30,10), l.dt_liquidacao))) <= '" + DateTime.Parse(DT_Final.Text).ToString("yyyyMMdd") + "')";
            }

            if (CB_Abertas.Checked)
            {
                Array.Resize(ref vBusca, vBusca.Length + 2);
                vBusca[vBusca.Length - 2].vNM_Campo = "isnull(a.ST_Registro, 'A')";
                vBusca[vBusca.Length - 2].vVL_Busca = "('A', 'P')";
                vBusca[vBusca.Length - 2].vOperador = "IN";
                vBusca[vBusca.Length - 1].vNM_Campo = string.Empty;
                vBusca[vBusca.Length - 1].vOperador = string.Empty;
                vBusca[vBusca.Length - 1].vVL_Busca = "a.status_parcela <> 'PROTESTADO' and a.status_parcela <> 'DESCONTADO'";
            }
            if (CB_Vencidas.Checked)
            {
                Array.Resize(ref vBusca, vBusca.Length + 3);
                vBusca[vBusca.Length - 3].vNM_Campo = string.Empty;
                vBusca[vBusca.Length - 3].vOperador = string.Empty;
                vBusca[vBusca.Length - 3].vVL_Busca = "a.status_parcela <> 'PROTESTADO' and a.status_parcela <> 'DESCONTADO'";
                vBusca[vBusca.Length - 2].vNM_Campo = "isnull(a.ST_Registro, 'A')";
                vBusca[vBusca.Length - 2].vVL_Busca = "('A', 'P')";
                vBusca[vBusca.Length - 2].vOperador = "IN";
                vBusca[vBusca.Length - 1].vNM_Campo = "CONVERT(DATETIME,FLOOR(CONVERT(NUMERIC(30,10), a.DT_Vencto)))";
                vBusca[vBusca.Length - 1].vVL_Busca = "CONVERT(DATETIME,FLOOR(CONVERT(NUMERIC(30,10), getDate())))";
                vBusca[vBusca.Length - 1].vOperador = "<";

            }
            if (CB_AVencer.Checked)
            {
                Array.Resize(ref vBusca, vBusca.Length + 3);
                vBusca[vBusca.Length - 3].vNM_Campo = string.Empty;
                vBusca[vBusca.Length - 3].vOperador = string.Empty;
                vBusca[vBusca.Length - 3].vVL_Busca = "a.status_parcela <> 'PROTESTADO' and a.status_parcela <> 'DESCONTADO'";
                vBusca[vBusca.Length - 2].vNM_Campo = "isnull(a.ST_Registro, 'A')";
                vBusca[vBusca.Length - 2].vVL_Busca = "('A', 'P')";
                vBusca[vBusca.Length - 2].vOperador = "IN";
                vBusca[vBusca.Length - 1].vNM_Campo = "CONVERT(DATETIME,FLOOR(CONVERT(NUMERIC(30,10), a.DT_Vencto)))";
                vBusca[vBusca.Length - 1].vVL_Busca = "CONVERT(DATETIME,FLOOR(CONVERT(NUMERIC(30,10), getDate())))";
                vBusca[vBusca.Length - 1].vOperador = ">=";
            }
            if (cbPerdida.Checked)
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.status_parcela";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'PERDIDA'";
            }
            if (cb_execucao.Checked)
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.status_parcela";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'EM EXECUCAO'";
            }
            if (cb_negativado.Checked)
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.status_parcela";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'NEGATIVADO'";
            }
            if (st_protestado.Checked)
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.status_parcela";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'PROTESTADO'";
            }
            if (CB_Liquidadas.Checked && CB_LiqParcial.Checked)
            {
                Array.Resize(ref vBusca, vBusca.Length + 2);
                vBusca[vBusca.Length - 2].vNM_Campo = "a.status_parcela";
                vBusca[vBusca.Length - 2].vOperador = "<>";
                vBusca[vBusca.Length - 2].vVL_Busca = "'PERDIDA'";
                vBusca[vBusca.Length - 1].vNM_Campo = "isnull(a.ST_Registro, 'A')";
                vBusca[vBusca.Length - 1].vVL_Busca = "('L', 'P')";
                vBusca[vBusca.Length - 1].vOperador = "in";
            }
            else
            {
                if (CB_Liquidadas.Checked)
                {
                    Array.Resize(ref vBusca, vBusca.Length + 2);
                    vBusca[vBusca.Length - 2].vNM_Campo = "a.status_parcela";
                    vBusca[vBusca.Length - 2].vOperador = "<>";
                    vBusca[vBusca.Length - 2].vVL_Busca = "'PERDIDA'";
                    vBusca[vBusca.Length - 1].vNM_Campo = "isnull(a.ST_Registro, 'A')";
                    vBusca[vBusca.Length - 1].vVL_Busca = "'L'";
                    vBusca[vBusca.Length - 1].vOperador = "=";
                }
                if (CB_LiqParcial.Checked)
                {
                    Array.Resize(ref vBusca, vBusca.Length + 2);
                    vBusca[vBusca.Length - 2].vNM_Campo = "a.status_parcela";
                    vBusca[vBusca.Length - 2].vOperador = "<>";
                    vBusca[vBusca.Length - 2].vVL_Busca = "'PERDIDA'";
                    vBusca[vBusca.Length - 1].vNM_Campo = "isnull(a.ST_Registro, 'A')";
                    vBusca[vBusca.Length - 1].vVL_Busca = "'P'";
                    vBusca[vBusca.Length - 1].vOperador = "=";
                }
            }
            if (!string.IsNullOrEmpty(cd_condpgto.Text))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "dup.cd_condpgto";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + cd_condpgto.Text.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(cd_portador.Text))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = string.Empty;
                vBusca[vBusca.Length - 1].vOperador = "exists";
                vBusca[vBusca.Length - 1].vVL_Busca = "(select 1 from tb_fin_liquidacao x " +
                                                      "where x.cd_empresa = a.cd_empresa " +
                                                      "and x.nr_lancto = a.nr_lancto " +
                                                      "and x.cd_parcela = a.cd_parcela " +
                                                      "and x.cd_portador = '" + cd_portador.Text.Trim() + "')";
            }
            if (cbParcelasBloqueto.Checked)
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = string.Empty;
                vBusca[vBusca.Length - 1].vOperador = "exists";
                vBusca[vBusca.Length - 1].vVL_Busca = "(select 1 from tb_cob_titulo x " +
                                                      "where x.cd_empresa = a.cd_empresa " +
                                                      "and x.nr_lancto = a.nr_lancto " +
                                                      "and x.cd_parcela = a.cd_parcela " +
                                                      "and isnull(x.st_registro, 'A') <> 'C')";
            }
            if (cbBloquetosDescontados.Checked)
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.status_parcela";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'DESCONTADO'";
            }
            if (cbParcelasCobranca.Checked)
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = string.Empty;
                vBusca[vBusca.Length - 1].vOperador = "exists";
                vBusca[vBusca.Length - 1].vVL_Busca = "(select 1 from tb_fin_cobranca_x_parcelas x " +
                                                      "where x.cd_empresa = a.cd_empresa " +
                                                      "and x.nr_lancto = a.nr_lancto " +
                                                      "and x.cd_parcela = a.cd_parcela)";
            }
            if (!string.IsNullOrEmpty(nossonumero.Text))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = string.Empty;
                vBusca[vBusca.Length - 1].vOperador = "exists";
                vBusca[vBusca.Length - 1].vVL_Busca = "(select 1 from tb_cob_titulo x " +
                                                      "where x.cd_empresa = a.cd_empresa " +
                                                      "and x.nr_lancto = a.nr_lancto " +
                                                      "and x.cd_parcela = a.cd_parcela " +
                                                      "and isnull(x.st_registro, 'A') <> 'C' " +
                                                      "and x.nossonumero like ('%" + nossonumero.Text.Trim() + "%'))";
            }
            if (!string.IsNullOrEmpty(Nr_Pedido.Text))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = string.Empty;
                vBusca[vBusca.Length - 1].vOperador = "exists";
                vBusca[vBusca.Length - 1].vVL_Busca = "(select 1 from TB_FAT_NotaFiscal_X_Duplicata x  " +
                                                      " inner join TB_FAT_NotaFiscal y ON x.CD_Empresa = y.CD_Empresa and x.nr_lanctofiscal = y.nr_lanctofiscal " +
                                                      " inner join TB_FAT_NotaFiscal_item w ON x.CD_Empresa = w.CD_Empresa and x.nr_lanctofiscal = w.nr_lanctofiscal " +
                                                      " where x.cd_empresa = a.cd_empresa  " +
                                                      " and x.nr_lanctoduplicata = a.Nr_Lancto  " +
                                                      " and isnull(y.st_registro, 'A') <> 'C'  " +
                                                      " and w.nr_pedido = " + Nr_Pedido.Text + ") ";
            }
            return vBusca;
        }

        private void BB_Excluir_Click(object sender, EventArgs e)
        {
            afterCancela();
        }

        private void BB_Novo_Click(object sender, EventArgs e)
        {
            afterNovo();
        }

        private TList_RegLanDuplicata BuscarDuplicata(string vCd_empresa, string vNr_lancto)
        {
            TList_RegLanDuplicata lDup = TCN_LanDuplicata.Busca(vCd_empresa,
                                                                vNr_lancto,
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
                                                                "A",
                                                                string.Empty,
                                                                string.Empty,
                                                                true,
                                                                0,
                                                                string.Empty,
                                                                null);
            //Buscr Centro Resultado
            lDup.ForEach(p => p.lCustoLancto = TCN_DuplicataXCCusto.BuscarCusto(p.Cd_empresa, p.Nr_lancto.ToString(), null));
            return lDup;
        }

        private TList_RegLanLiquidacao BuscarLiquidacao(string vCd_empresa, decimal vNr_lancto, decimal vCd_parcela)
        {
            return TCN_LanLiquidacao.Busca(vCd_empresa,
                                           vNr_lancto,
                                           vCd_parcela,
                                           decimal.Zero,
                                           string.Empty,
                                           decimal.Zero,
                                           decimal.Zero,
                                           decimal.Zero,
                                           decimal.Zero,
                                           decimal.Zero,
                                           decimal.Zero,
                                           decimal.Zero,
                                           false,
                                           "A",
                                           0,
                                           string.Empty,
                                           null);
        }

        private void tcDadosDocumentos_SelectedIndexChanged(object sender, EventArgs e)
        {
            BB_Liquidar.Visible = tcDadosDocumentos.SelectedTab.Equals(tpParcelas);
            BB_Cobranca.Visible = tcDadosDocumentos.SelectedTab.Equals(tpParcelas);
            bbImpDuplicata.Visible = tcDadosDocumentos.SelectedTab.Equals(tpParcelas) || tcDadosDocumentos.SelectedTab.Equals(tpDocumento);
            bbImpCarnedup.Visible = tcDadosDocumentos.SelectedTab.Equals(tpParcelas) || tcDadosDocumentos.SelectedTab.Equals(tpDocumento);
            BB_Alterar.Visible = tcDadosDocumentos.SelectedTab.Equals(tpDocumento);
            bbImpRecibo.Visible = tcDadosDocumentos.SelectedTab.Equals(tpLiquidacao);
            if (tcDadosDocumentos.SelectedTab == tpDocumento)
            {
                //Buscar Duplicata da Parcela
                if (bsParcelas.Current != null)
                    BS_Duplicata.DataSource = BuscarDuplicata((bsParcelas.Current as TRegistro_LanParcela).Cd_empresa,
                                                              (bsParcelas.Current as TRegistro_LanParcela).Nr_lanctostr);
                if (BS_Duplicata.Current != null)
                {
                    string cond = string.Empty;
                    if ((BS_Duplicata.Current as TRegistro_LanDuplicata).lCustoLancto.Count > 0)
                    {
                        (BS_Duplicata.Current as TRegistro_LanDuplicata).lCustoLancto.ForEach(p =>
                        {
                            string cd_result = p.Cd_centroresult;
                            for (int i = 0; (p.Cd_centroresult.Length / 2) > i; i++)
                            {
                                if (i == 0 && cd_result.Length > 2)
                                {
                                    if (string.IsNullOrEmpty(cond))
                                        cond = "'" + p.Cd_centroresult.Trim() + "'";
                                    else
                                        cond += ", '" + p.Cd_centroresult.Trim() + "'";
                                }
                                else
                                {
                                    cd_result = p.Cd_centroresult.Substring(0, (p.Cd_centroresult.Length - (i * 2)));
                                    cond += ", '" + cd_result.Trim() + "'";
                                }
                            }

                        });
                        (BS_Duplicata.Current as TRegistro_LanDuplicata).lCentroResult =
                            new TCD_CentroResultado().Select(
                                new TpBusca[]
                                {
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.CD_CentroResult",
                                        vOperador = "in",
                                        vVL_Busca = "(" + cond.Trim() + ")"
                                    }
                                }, 0, string.Empty);
                        (BS_Duplicata.Current as TRegistro_LanDuplicata).lCentroResult.FindAll(p => p.St_sinteticobool.Equals(false)).ForEach(p =>
                        {
                            p.Valor = (BS_Duplicata.Current as TRegistro_LanDuplicata).lCustoLancto.Find(x => x.Cd_centroresult.Equals(p.Cd_centroresult)).Vl_lancto;
                            p.Pc_valor = Math.Round(p.Valor / ((BS_Duplicata.Current as TRegistro_LanDuplicata).Vl_documento / 100), 5);
                        });
                    }
                    BS_Duplicata.ResetCurrentItem();
                }
                //Buscar 
                //BB_Excluir.Visible = TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin, "PERMITIR EXCLUSAO DE DOCUMENTO FINANCEIRO", null);
                //Retirado ticket 8158    
            }
            else if (tcDadosDocumentos.SelectedTab == tpLiquidacao)
            {
                //Buscar Liquidações da Parcela
                if (bsParcelas.Current != null)
                    bsLiquidacoes.DataSource = BuscarLiquidacao((bsParcelas.Current as TRegistro_LanParcela).Cd_empresa,
                                                                (bsParcelas.Current as TRegistro_LanParcela).Nr_lancto.Value,
                                                                (bsParcelas.Current as TRegistro_LanParcela).Cd_parcela.Value);
                decimal vVl_TotLiquidado = 0;
                decimal vVl_TotJuros = 0;
                decimal vVl_TotDescontos = 0;
                decimal vVl_DifCambPa = 0;
                decimal vVl_DifCambAt = 0;
                somarCamposLiquidacao(ref vVl_TotLiquidado, ref vVl_TotJuros, ref vVl_TotDescontos, ref vVl_DifCambAt, ref vVl_DifCambPa);

                vl_totalliquidacao.Value = vVl_TotLiquidado;
                vl_totaljuro.Value = vVl_TotJuros;
                vl_totaldesconto.Value = vVl_TotDescontos;
                vl_totaldifcamb_ativa.Value = vVl_DifCambAt;
                vl_totaldifcamb_passiva.Value = vVl_DifCambPa;
            }
        }

        private void BB_Liquidar_Click(object sender, EventArgs e)
        {
            afterLiquidar();
        }

        private void TFLanContas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F2) && BB_Novo.Visible)
                afterNovo();
            else if (e.KeyCode.Equals(Keys.F3) && BB_Alterar.Visible)
                afterAltera();
            else if (e.KeyCode.Equals(Keys.F7) && BB_Buscar.Visible)
                afterBusca();
            else if (e.KeyCode.Equals(Keys.F5) && BB_Excluir.Visible)
                afterCancela();
            else if (e.KeyCode.Equals(Keys.F9) && BB_Liquidar.Visible)
                afterLiquidar();
            else if (e.Control && (e.KeyCode == Keys.P))
            {
                Altera_Relatorio = true;
                MessageBox.Show("Execute o relatório que deseja alterar!", "Mensagem");
            }
            else if (e.KeyCode.Equals(Keys.F10) && BB_Cobranca.Visible)
                afterCobranca();
        }

        private void BB_Alterar_Click(object sender, EventArgs e)
        {
            afterAltera();
        }

        private void gParcelas_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
                if (e.ColumnIndex == 1)
                {
                    if (e.Value.ToString().Trim().ToUpper().Equals("LIQUIDADA"))
                        gParcelas.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Blue;
                    else if (e.Value.ToString().Trim().ToUpper().Equals("PARCIAL"))
                        gParcelas.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Green;
                    else if (e.Value.ToString().Trim().ToUpper().Equals("VENCIDA"))
                        gParcelas.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
                    else if (e.Value.ToString().Trim().ToUpper().Equals("PERDIDA"))
                        gParcelas.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Maroon;
                    else if (e.Value.ToString().Trim().ToUpper().Equals("PROTESTADO"))
                        gParcelas.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Indigo;
                    else if (e.Value.ToString().Trim().ToUpper().Equals("AGRUPADA"))
                        gParcelas.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Teal;
                    else
                        gParcelas.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                }
        }

        private void BB_Imprimir_Click(object sender, EventArgs e)
        {
            Imprime_Relatorio();
        }

        private void gParcelas_DoubleClick(object sender, EventArgs e)
        {
            if (bsParcelas.Current != null)
            {
                TFRastrearLancamentos fRastrear = new TFRastrearLancamentos();
                try
                {
                    TpBusca[] filtro = new TpBusca[3];
                    filtro[0].vNM_Campo = "a.cd_empresa";
                    filtro[0].vOperador = "=";
                    filtro[0].vVL_Busca = "'" + (bsParcelas.Current as TRegistro_LanParcela).Cd_empresa.Trim() + "'";
                    filtro[1].vNM_Campo = "a.nr_lancto";
                    filtro[1].vOperador = "=";
                    filtro[1].vVL_Busca = (bsParcelas.Current as TRegistro_LanParcela).Nr_lanctostr;
                    filtro[2].vNM_Campo = "a.cd_parcela";
                    filtro[2].vOperador = "=";
                    filtro[2].vVL_Busca = (bsParcelas.Current as TRegistro_LanParcela).Cd_parcelastr;
                    fRastrear.bsParcelas.DataSource = new TCD_LanParcela().Select(filtro, 1, string.Empty, "a.dt_vencto, c.nm_clifor", string.Empty);
                    fRastrear.TRastrear = TP_Rastrear.tm_parcela;
                    fRastrear.ShowDialog();
                }
                finally
                {
                    fRastrear.Dispose();
                }
            }
        }

        private void dataGridDefault2_DoubleClick(object sender, EventArgs e)
        {
            if (bsLiquidacoes.Current != null)
            {
                TFRastrearLancamentos fRastrear = new TFRastrearLancamentos();
                try
                {
                    fRastrear.bsLiquidacoes.Add((bsLiquidacoes.Current as TRegistro_LanLiquidacao));
                    fRastrear.TRastrear = TP_Rastrear.tm_liquidacao;
                    fRastrear.ShowDialog();
                }
                finally
                {
                    fRastrear.Dispose();
                }
            }
        }

        private void Imprime_Relatorio()
        {
            if (BS_Duplicata.Count > 0)
            {
                Relatorio = new FormRelPadrao.Relatorio();
                Relatorio.Altera_Relatorio = Altera_Relatorio;
                Relatorio.DTS_Relatorio = bsParcelas;
                Relatorio.Nome_Relatorio = Name;
                Relatorio.NM_Classe = Name;
                Relatorio.Modulo = Tag.ToString().Substring(0, 3);

                if (tcDadosDocumentos.SelectedTab.Equals(tpParcelas))
                {
                    using (TFGerenciadorImpressao fImp = new TFGerenciadorImpressao())
                    {
                        Relatorio.Ident = "TFLanContas_Parcelas";
                        Relatorio.DTS_Relatorio = bsParcelas;
                        fImp.St_enabled_enviaremail = true;
                        fImp.pCd_clifor = string.Empty;
                        fImp.pMensagem = "RELATORIO " + Text.Trim();

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
                                                     "RELATORIO " + Text.Trim(),
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
                                                     "RELATORIO " + Text.Trim(),
                                                     fImp.pDs_mensagem);
                    }

                }
                else if (tcDadosDocumentos.SelectedTab.Equals(tpDocumento))
                {
                    using (TFGerenciadorImpressao fImp = new TFGerenciadorImpressao())
                    {
                        Relatorio.Ident = "TFLanContas_Documentos";
                        Relatorio.Adiciona_DataSource("bsParcelas", bsParcelas);
                        Relatorio.DTS_Relatorio = BS_Duplicata;
                        fImp.St_enabled_enviaremail = true;
                        fImp.pCd_clifor = string.Empty;
                        fImp.pMensagem = "RELATORIO " + Text.Trim();

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
                                                     "RELATORIO " + Text.Trim(),
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
                                                     "RELATORIO " + Text.Trim(),
                                                     fImp.pDs_mensagem);
                    }
                }
                else if (tcDadosDocumentos.SelectedTab.Equals(tpLiquidacao))
                {
                    decimal valorLiquidado = 0;
                    string Observacao = (bsLiquidacoes.Current as TRegistro_LanLiquidacao).ComplHistorico;

                    BindingSource BinClifor = new BindingSource();
                    if (BS_Duplicata.Current != null)
                        BinClifor.DataSource = TCN_CadClifor.Busca_Clifor((BS_Duplicata.Current as TRegistro_LanDuplicata).Cd_clifor,
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

                    BindingSource End = new BindingSource();
                    End.DataSource = TCN_CadEndereco.Buscar((BS_Duplicata.Current as TRegistro_LanDuplicata).Cd_clifor,
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

                    BindingSource Empresa = new BindingSource();
                    Empresa.DataSource = TCN_CadEmpresa.Busca((BS_Duplicata.Current as TRegistro_LanDuplicata).Cd_empresa, (BS_Duplicata.Current as TRegistro_LanDuplicata).Nm_empresa, "", null);

                    if (bsLiquidacoes.Count > 0)
                        valorLiquidado = (bsLiquidacoes.Current as TRegistro_LanLiquidacao).Vl_Liquidado;
                    Relatorio.Altera_Relatorio = Altera_Relatorio;
                    Relatorio.Ident = "TFLanContas_Liquidacao";
                    BindingSource UnicaParcela = new BindingSource();
                    UnicaParcela.DataSource = bsParcelas.Current;

                    Relatorio.Adiciona_DataSource("bsParcelas", UnicaParcela);
                    Relatorio.Adiciona_DataSource("LIQUIDACAO", bsLiquidacoes);

                    Relatorio.DTS_Relatorio = BS_Duplicata;
                    using (TFGerenciadorImpressao fImp = new TFGerenciadorImpressao())
                    {
                        fImp.St_enabled_enviaremail = true;
                        fImp.pCd_clifor = string.Empty;
                        fImp.pMensagem = "RELATORIO " + Text.Trim();

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
                                                     "RELATORIO " + Text.Trim(),
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
                                                     "RELATORIO " + Text.Trim(),
                                                     fImp.pDs_mensagem);
                    }
                }
            }
        }

        private void BB_Cobranca_Click(object sender, EventArgs e)
        {
            afterCobranca();
        }

        private void BB_ImpRecibo_Click(object sender, EventArgs e)
        {
            ImprimirRecibo();
        }

        private void cd_condpgto_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.cd_condpgto|=|'" + cd_condpgto.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cd_condpgto },
                                    new TCD_CadCondPgto());
        }

        private void bb_condpgto_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_condpgto|Condição Pagamento|200;" +
                              "a.cd_condpgto|Cd. CondPgto|80";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_condpgto },
                                    new TCD_CadCondPgto(), string.Empty);
        }

        private void cd_portador_Leave(object sender, EventArgs e)
        {
            string vColunas = "cd_portador|=|'" + cd_portador.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cd_portador },
                                    new TCD_CadPortador());
        }

        private void bb_portador_Click(object sender, EventArgs e)
        {
            string vColunas = "ds_portador|Descrição Portador|200;" +
                              "cd_portador|Cd. Portador|80";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_portador },
                                    new TCD_CadPortador(), string.Empty);
        }

        private void TFLanContas_FormClosed(object sender, FormClosedEventArgs e)
        {
            ShapeGrid.SaveShape(this, gLiquidacao);
            ShapeGrid.SaveShape(this, gParcelas);
        }

        private void BB_Dup_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaTpDuplicata(new Componentes.EditDefault[] { Tp_Dup }, string.Empty);
        }

        private void Tp_Dup_Leave(object sender, EventArgs e)
        {
            string vColunas = "tp_duplicata|=|'" + Tp_Dup.Text.Trim() + "'";
            UtilPesquisa.EDIT_LeaveTpDuplicata(vColunas, new Componentes.EditDefault[] { Tp_Dup });
        }

        private void bb_alterarccusto_Click(object sender, EventArgs e)
        {
            AlterarCResultado();
        }

        private void gParcelas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (bsParcelas.Count > 0)
                if (e.ColumnIndex == 0)
                {
                    if ((bsParcelas.Current as TRegistro_LanParcela).St_registro.Trim().ToUpper().Equals("L"))
                        return;
                    if ((bsParcelas.Current as TRegistro_LanParcela).St_registro.Trim().ToUpper().Equals("G"))
                        return;
                    (bsParcelas.Current as TRegistro_LanParcela).St_processar =
                        !(bsParcelas.Current as TRegistro_LanParcela).St_processar;
                    SomarVlSelecionado();
                }
                else if ((e.ColumnIndex == 2) && (bsParcelas.Current as TRegistro_LanParcela).St_agrupador.Trim().ToUpper().Equals("S"))
                    using (TFListaParcelasAgrupadas fLista = new TFListaParcelasAgrupadas())
                    {
                        fLista.Cd_empresa = (bsParcelas.Current as TRegistro_LanParcela).Cd_empresa;
                        fLista.Nr_lancto = (bsParcelas.Current as TRegistro_LanParcela).Nr_lanctostr;
                        fLista.ShowDialog();
                    }
                else if ((e.ColumnIndex == 3) && (bsParcelas.Current as TRegistro_LanParcela).St_cobrancabool)
                    using (TFLan_Cobranca fCobranca = new TFLan_Cobranca())
                    {
                        fCobranca.lParc = new List<TRegistro_LanParcela>() { bsParcelas.Current as TRegistro_LanParcela };
                        fCobranca.ShowDialog();
                    }
        }

        private void bb_agrupar_Click(object sender, EventArgs e)
        {
            AgruparFinanceiro();
        }

        private void gParcelas_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gParcelas.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsParcelas.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new TRegistro_LanParcela());
            TList_RegLanParcela lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gParcelas.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gParcelas.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new TList_RegLanParcela(lP.Find(gParcelas.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gParcelas.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new TList_RegLanParcela(lP.Find(gParcelas.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gParcelas.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsParcelas.DataSource as TList_RegLanParcela).Sort(lComparer);
            bsParcelas.ResetBindings(false);
            gParcelas.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void gLiquidacao_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gLiquidacao.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsLiquidacoes.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new TRegistro_LanLiquidacao());
            TList_RegLanLiquidacao lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gLiquidacao.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gLiquidacao.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new TList_RegLanLiquidacao(lP.Find(gLiquidacao.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gLiquidacao.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new TList_RegLanLiquidacao(lP.Find(gLiquidacao.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gLiquidacao.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsLiquidacoes.DataSource as TList_RegLanLiquidacao).Sort(lComparer);
            bsLiquidacoes.ResetBindings(false);
            gLiquidacao.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void bb_dupperdida_Click(object sender, EventArgs e)
        {

        }

        private void TFLanContas_FormClosing(object sender, FormClosingEventArgs e)
        {
            ShapeGrid.SaveShape(this, gLiquidacao);
            ShapeGrid.SaveShape(this, gParcelas);
        }

        private void bb_agruparConvenio_Click(object sender, EventArgs e)
        {
            using (TFAgruparFinPosto fAgrupar = new TFAgruparFinPosto())
            {
                fAgrupar.ShowDialog();
            }
        }

        private void bb_agruparpag_Click(object sender, EventArgs e)
        {
            using (TFLiquidarDupTitulo fLiq = new TFLiquidarDupTitulo())
            {
                if (fLiq.ShowDialog() == DialogResult.OK)
                    try
                    {
                        TCN_LanLiquidacao.LiquidarDupComCheque(fLiq.rCh, fLiq.Cd_contaliq, fLiq.Vl_liquidar, fLiq.Vl_desconto, fLiq.lParc, null);
                        MessageBox.Show("Liquidação realizada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (MessageBox.Show("Imprimir cheques emitidos?", "Mensagem", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                                     MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                            try
                            {
                                CamadaNegocio.Financeiro.Titulo.TCN_LanTitulo.ImprimirCheque(new List<CamadaDados.Financeiro.Titulo.TRegistro_LanTitulo>() { fLiq.rCh });
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void bbRelatorioDup_Click(object sender, EventArgs e)
        {
            Imprime_Relatorio();
        }

        private void bbImpRecibo_Click(object sender, EventArgs e)
        {
            ImprimirRecibo();
        }

        private void bbImpCarnedup_Click(object sender, EventArgs e)
        {
            ImprimirDuplicata("C");
        }

        private void bbImpDuplicata_Click(object sender, EventArgs e)
        {
            ImprimirDuplicata("D");
        }

        private void bb_categoriaclifor_Click(object sender, EventArgs e)
        {
            string vColunas = "a.Ds_CategoriaCliFor|Categoria Cliente/Fornec.|200;" +
                              "a.Id_CategoriaCliFor|Id. Categoria|60";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { id_categoriaclifor },
                new TCD_CadCategoriaCliFor(), string.Empty);
        }

        private void id_categoriaclifor_Leave(object sender, EventArgs e)
        {
            string vParam = "a.id_categoriaclifor|=|" + id_categoriaclifor.Text;
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { id_categoriaclifor },
                new TCD_CadCategoriaCliFor());
        }

        private void extratoDeclaraçãoImpostoRendaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (Relatorio.TFRelExtratoIR fRel = new Relatorio.TFRelExtratoIR())
            {
                fRel.ShowDialog();
            }
        }

        private void bsParcelas_PositionChanged(object sender, EventArgs e)
        {
            if (bsParcelas.Current != null)
            {
                bsAtVencto.DataSource = TCN_AtVenctoParcela.Busca((bsParcelas.Current as TRegistro_LanParcela).Cd_empresa,
                                                                  (bsParcelas.Current as TRegistro_LanParcela).Nr_lancto.Value.ToString(),
                                                                  (bsParcelas.Current as TRegistro_LanParcela).Cd_parcela.Value.ToString(),
                                                                  string.Empty,
                                                                  null);
                if (bsAtVencto.Count > 0)
                    tlpAtVencto.ColumnStyles[1].Width = 200;
                else tlpAtVencto.ColumnStyles[1].Width = 0;
            }
            else
            {
                bsAtVencto.Clear();
                tlpAtVencto.ColumnStyles[1].Width = 0;
            }
        }

        private void imprimirBoletoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bsParcelas.Current != null)
            {
                if ((bsParcelas.Current as TRegistro_LanParcela).Tp_mov.Trim().ToUpper().Equals("P"))
                {
                    MessageBox.Show("Permitido emitir boleto somente de contas a RECEBER.", "Mensagem", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    return;
                }
                if (string.IsNullOrEmpty((bsParcelas.Current as TRegistro_LanParcela).Nossonumero))
                {
                    MessageBox.Show("Parcela não possui boleto vinculado para emitir.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                CamadaDados.Financeiro.Bloqueto.blListaTitulo lBoleto = CamadaNegocio.Financeiro.Bloqueto.TCN_Titulo.Buscar((bsParcelas.Current as TRegistro_LanParcela).Cd_empresa,
                                                                                                                            (bsParcelas.Current as TRegistro_LanParcela).Nr_lancto.Value,
                                                                                                                            (bsParcelas.Current as TRegistro_LanParcela).Cd_parcela.Value,
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
                                                                                                                            1,
                                                                                                                            null);
                if (lBoleto.Count > 0)
                {
                    if (!Altera_Relatorio)
                    {
                        //Chamar tela de impressao para o bloqueto
                        using (TFGerenciadorImpressao fImp = new TFGerenciadorImpressao())
                        {
                            fImp.St_enabled_enviaremail = true;
                            fImp.pCd_clifor = lBoleto[0].Cd_sacado;
                            fImp.pMensagem = "BLOQUETO Nº" + lBoleto[0].Nosso_numero.Trim();
                            if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                                TCN_LayoutBloqueto.Imprime_Bloqueto(Altera_Relatorio,
                                                                    lBoleto,
                                                                    fImp.pSt_imprimir,
                                                                    fImp.pSt_visualizar,
                                                                    fImp.pSt_enviaremail,
                                                                    fImp.pSt_exportPdf,
                                                                    fImp.Path_exportPdf,
                                                                    fImp.pDestinatarios,
                                                                    "BLOQUETO Nº " + lBoleto[0].Nosso_numero,
                                                                    fImp.pDs_mensagem,
                                                                    false);
                        }
                    }
                    else
                        TCN_LayoutBloqueto.Imprime_Bloqueto(Altera_Relatorio,
                                                            lBoleto,
                                                            false,
                                                            false,
                                                            false,
                                                            false,
                                                            string.Empty,
                                                            null,
                                                            string.Empty,
                                                            string.Empty,
                                                            false);
                }
                Altera_Relatorio = false;
            }
        }

        private void gCentroResult_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
            {
                if (e.ColumnIndex == 0)
                    if ((bsCentroresult[e.RowIndex] as TRegistro_CentroResultado).St_sinteticobool)
                    {
                        gCentroResult.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Blue;
                        gCentroResult.Rows[e.RowIndex].DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular);
                    }
                    else
                    {
                        gCentroResult.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                        gCentroResult.Rows[e.RowIndex].DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular);
                    }
            }
        }

        private void bbAtualizaVencto_Click(object sender, EventArgs e)
        {
            if (bsParcelas.Current != null)
            {
                if ((bsParcelas.Current as TRegistro_LanParcela).St_registro.Trim().ToUpper().Equals("A") ||
                    (bsParcelas.Current as TRegistro_LanParcela).St_registro.Trim().ToUpper().Equals("P"))
                {
                    InputBox valor = new InputBox("00/00/0000", "Data Vencimento");
                    string retorno = valor.ShowDialog();
                    try
                    {
                        DateTime data = DateTime.Parse(retorno);
                        if ((bsParcelas.Current as TRegistro_LanParcela).Dt_emissao.Value.Date > data.Date)
                        {
                            MessageBox.Show("Data vencimento não pode ser menor que data de emissão da parcela.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        System.Collections.Hashtable hs = new System.Collections.Hashtable();
                        hs.Add("@cd_empresa", (bsParcelas.Current as TRegistro_LanParcela).Cd_empresa);
                        hs.Add("@nr_lancto", (bsParcelas.Current as TRegistro_LanParcela).Nr_lancto);
                        hs.Add("@cd_parcela", (bsParcelas.Current as TRegistro_LanParcela).Cd_parcela);
                        hs.Add("@dt_vencto", data);
                        new CamadaDados.TDataQuery().executarSql("update tb_fin_parcela set dt_vencto = @dt_vencto, dt_alt = getdate() " +
                                                                 "where cd_empresa = @cd_empresa and nr_lancto = @nr_lancto and cd_parcela = @cd_parcela", hs);
                        MessageBox.Show("Vencimento parcela alterada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        afterBusca();
                    }
                    catch { MessageBox.Show("Data invalida.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
                else MessageBox.Show("Permitido alterar vencimento somente de parcela com saldo liquidar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else MessageBox.Show("Obrigatório selecionar parcela para alterar vencimento.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void bb_liquidarContasPgar_Click(object sender, EventArgs e)
        {
            using (TFLiquidarContasPagar fLiquidar = new TFLiquidarContasPagar())
                fLiquidar.ShowDialog();
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            DuplicataPerdida();
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            if (bsParcelas.Current != null)
                if ((bsParcelas.DataSource as TList_RegLanParcela).Exists(p => p.St_processar))
                {
                    if (MessageBox.Show("Deseja marcar as parcelas selecionadas como NEGATIVADA?", "Pergunta",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                        try
                        {
                            TCN_LanDuplicata.DuplicatasPerdidas(bsParcelas.DataSource as TList_RegLanParcela, null, "N");
                            MessageBox.Show("Duplicatas processadas com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            afterBusca();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
                else
                    MessageBox.Show("Não existe duplicatas selecionadas para marcar como NEGATIVADA.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void emExecucaoToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (bsParcelas.Current != null)
                if ((bsParcelas.DataSource as TList_RegLanParcela).Exists(p => p.St_processar))
                {
                    if (MessageBox.Show("Deseja marcar as parcelas selecionadas como Em Execucao?", "Pergunta",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                        try
                        {
                            TCN_LanDuplicata.DuplicatasPerdidas(bsParcelas.DataSource as TList_RegLanParcela, null, "E");
                            MessageBox.Show("Duplicatas processadas com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            afterBusca();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
                else
                    MessageBox.Show("Não existe duplicatas selecionadas para marcar como Em Execucao.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void cb_execucao_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}