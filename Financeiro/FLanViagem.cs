using CamadaDados.Financeiro.Cadastros;
using CamadaDados.Financeiro.Viagem;
using CamadaNegocio.Financeiro.Cadastros;
using CamadaNegocio.Financeiro.Viagem;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Utils;

namespace Financeiro
{
    public partial class TFLanViagem : Form
    {
        private bool Altera_Relatorio = false;
        public TFLanViagem()
        {
            InitializeComponent();
        }

        private void LimpaFiltros()
        {
            Id_viagem.Clear();
            cd_empresa.Clear();
            Cd_funcionario.Clear();
            Cd_funcionario.Clear();
            dt_ini.Clear();
            dt_fin.Clear();
            cbxAberta.Checked = false;
            cbxProcessada.Checked = false;
        }

        private void afterNovo()
        {
            using (TFViagem fViagem = new TFViagem())
            {
                if (fViagem.ShowDialog() == DialogResult.OK)
                    if (fViagem.rViagem != null)
                        try
                        {
                            TCN_Viagem.Gravar(fViagem.rViagem, null);
                            MessageBox.Show("Viagem gravada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LimpaFiltros();
                            Id_viagem.Text = fViagem.rViagem.Id_viagemstr;
                            cd_empresa.Text = fViagem.rViagem.Cd_empresa;
                            afterBusca();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
            }
        }

        private void afterBusca()
        {
            string status = string.Empty;
            string virg = string.Empty;
            if (cbxAberta.Checked)
            {
                status = "'A'";
                virg = ",";
            }
            if (cbxProcessada.Checked)
                status += "'P'";
            bsViagem.DataSource = TCN_Viagem.Buscar(Id_viagem.Text,
                                                      cd_empresa.Text,
                                                      Cd_funcionario.Text,
                                                      rbIni.Checked ? "I" : rbFin.Checked ? "F" : string.Empty,
                                                      dt_ini.Text,
                                                      dt_fin.Text,
                                                      NR_NotaFiscal.Text,
                                                      NM_Fornecedor.Text,
                                                      cd_cliente.Text,
                                                      status,
                                                      null);
            bsViagem_PositionChanged(this, new EventArgs());
            bsViagem.ResetCurrentItem();
        }

        private void afterAltera()
        {
            if (bsViagem.Current != null)
            {
                if ((bsViagem.Current as TRegistro_Viagem).St_registro.ToUpper().Equals("P"))
                {
                    MessageBox.Show("Não é possível alterar em viagem PROCESSADA!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                using (TFViagem fViagem = new TFViagem())
                {
                    fViagem.rViagem = bsViagem.Current as TRegistro_Viagem;
                    if (fViagem.ShowDialog() == DialogResult.OK)
                        if (fViagem.rViagem != null)
                            try
                            {
                                TCN_Viagem.Gravar(fViagem.rViagem, null);
                                MessageBox.Show("Viagem alterada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LimpaFiltros();
                                Id_viagem.Text = fViagem.rViagem.Id_viagemstr;
                                cd_empresa.Text = fViagem.rViagem.Cd_empresa;
                                afterBusca();
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                }
            }
        }

        private void afterExclui()
        {
            if (bsViagem.Current != null)
            {
                if ((bsViagem.Current as TRegistro_Viagem).St_registro.ToUpper().Equals("P"))
                {
                    MessageBox.Show("Não é possível excluir em viagem PROCESSADA!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if ((bsViagem.Current as TRegistro_Viagem).lAdto.Count > 0)
                {
                    MessageBox.Show("Não é permitido cancelar Viagem que possui adiantamento!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (MessageBox.Show("Confirma exclusão da Viagem selecionada?", "Pergunta", MessageBoxButtons.YesNo,
                     MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    try
                    {
                        TCN_Viagem.Excluir(bsViagem.Current as TRegistro_Viagem, null);
                        MessageBox.Show("Viagem excluida com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        afterBusca();
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void IncluirAdto()
        {
            if (bsViagem.Current != null)
            {
                if ((bsViagem.Current as TRegistro_Viagem).St_registro.ToUpper().Equals("P"))
                {
                    MessageBox.Show("Não é possível incluir adiantamento em viagem PROCESSADA!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                using (Financeiro.TFLan_Adiantamento fAdto = new TFLan_Adiantamento())
                {
                    fAdto.BS_Adiantamento.AddNew();
                    (fAdto.BS_Adiantamento.Current as CamadaDados.Financeiro.Adiantamento.TRegistro_LanAdiantamento).Tp_movimento = "C";
                    (fAdto.BS_Adiantamento.Current as CamadaDados.Financeiro.Adiantamento.TRegistro_LanAdiantamento).Cd_empresa = (bsViagem.Current as TRegistro_Viagem).Cd_empresa;
                    (fAdto.BS_Adiantamento.Current as CamadaDados.Financeiro.Adiantamento.TRegistro_LanAdiantamento).Nm_empresa = (bsViagem.Current as TRegistro_Viagem).Nm_empresa;
                    (fAdto.BS_Adiantamento.Current as CamadaDados.Financeiro.Adiantamento.TRegistro_LanAdiantamento).Cd_clifor = (bsViagem.Current as TRegistro_Viagem).Cd_funcionario;
                    (fAdto.BS_Adiantamento.Current as CamadaDados.Financeiro.Adiantamento.TRegistro_LanAdiantamento).Nm_clifor = (bsViagem.Current as TRegistro_Viagem).Nm_funcionario;
                    //Buscar endereco motorista
                    TList_CadEndereco lEnd =
                        TCN_CadEndereco.Buscar((bsViagem.Current as TRegistro_Viagem).Cd_funcionario,
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
                        (fAdto.BS_Adiantamento.Current as CamadaDados.Financeiro.Adiantamento.TRegistro_LanAdiantamento).CD_Endereco = lEnd[0].Cd_endereco;
                        (fAdto.BS_Adiantamento.Current as CamadaDados.Financeiro.Adiantamento.TRegistro_LanAdiantamento).DS_Endereco = lEnd[0].Ds_endereco;
                        (fAdto.BS_Adiantamento.Current as CamadaDados.Financeiro.Adiantamento.TRegistro_LanAdiantamento).Cidade = lEnd[0].DS_Cidade;
                        (fAdto.BS_Adiantamento.Current as CamadaDados.Financeiro.Adiantamento.TRegistro_LanAdiantamento).UF = lEnd[0].UF;
                    }
                    (fAdto.BS_Adiantamento.Current as CamadaDados.Financeiro.Adiantamento.TRegistro_LanAdiantamento).TP_Lancto = "R";
                    (fAdto.BS_Adiantamento.Current as CamadaDados.Financeiro.Adiantamento.TRegistro_LanAdiantamento).Dt_prevdevolucao = (bsViagem.Current as TRegistro_Viagem).Dt_fin;

                    fAdto.CD_Empresa.Enabled = false;
                    fAdto.BB_Empresa.Enabled = false;
                    fAdto.cd_clifor.Enabled = false;
                    fAdto.bb_clifor.Enabled = false;
                    fAdto.CD_Endereco.Enabled = false;
                    fAdto.bb_endereco.Enabled = false;
                    fAdto.rb_Adiantamento.Enabled = false;
                    fAdto.rb_Recebido.Enabled = false;

                    if (fAdto.ShowDialog() == DialogResult.OK)
                        try
                        {
                            TCN_Viagem.IncluirAdiantamento(bsViagem.Current as TRegistro_Viagem,
                                                           fAdto.BS_Adiantamento.Current as CamadaDados.Financeiro.Adiantamento.TRegistro_LanAdiantamento,
                                                           null);
                            MessageBox.Show("Adiantamento incluido com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LimpaFiltros();
                            Id_viagem.Text = (bsViagem.Current as TRegistro_Viagem).Id_viagemstr;
                            cd_empresa.Text = (bsViagem.Current as TRegistro_Viagem).Cd_empresa;
                            afterBusca();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim()); }
                }
            }
        }

        private void AcertoMotorista()
        {
            using (TFAcertoViagem fAcerto = new TFAcertoViagem())
            {
                string vTp_dup = string.Empty;
                string vCd_condpagto = string.Empty;
                string vCd_historico = string.Empty;
                string vTp_docto = string.Empty;
                string vCd_centroresult = string.Empty;
                bool st_bloquear = false;
                decimal SomaDespesas = decimal.Zero;
                if (fAcerto.ShowDialog() == DialogResult.OK)
                {
                    if (fAcerto.lViagem != null)
                        fAcerto.lViagem.ForEach(p =>
                        {
                            //Buscar Config Adto
                            TList_ConfigAdto lCfgAdto = TCN_CadConfigAdto.Buscar(p.Cd_empresa,
                                                                                 string.Empty,
                                                                                 string.Empty,
                                                                                 string.Empty,
                                                                                 string.Empty,
                                                                                 1,
                                                                                 string.Empty,
                                                                                 null);
                            //Buscar Despesas
                            p.lDespesas = TCN_DespesasViagem.Buscar(p.Id_viagemstr,
                                              p.Cd_empresa,
                                              string.Empty,
                                              string.Empty,
                                              string.Empty,
                                              null);
                            if (p.lDespesas.FindAll(x => x.Tp_pagamento.ToUpper().Equals("0")).Sum(x => x.Vl_subtotal) > decimal.Zero)
                            {
                                //Calcular saldo restante
                                p.SaldoDevolverC = p.SaldoDevolverC - SomaDespesas <= 0 ? 0 : p.SaldoDevolverC - SomaDespesas;
                                if (lCfgAdto.Count > 0)
                                {
                                    if (string.IsNullOrEmpty(lCfgAdto[0].CD_HistoricoVgFin))
                                    {
                                        MessageBox.Show("Não existe histórico viagem financeiro cadastrado na cfg.adto!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        return;
                                    }
                                }
                                if (p.SaldoDevolverC > 0)
                                {
                                    CamadaDados.Financeiro.Caixa.TRegistro_LanCaixa rCaixa = new CamadaDados.Financeiro.Caixa.TRegistro_LanCaixa();
                                    rCaixa.Cd_ContaGer = lCfgAdto[0].Cd_contagerDEV_CV;
                                    rCaixa.Cd_Empresa = p.Cd_empresa;
                                    rCaixa.Nr_Docto = "DESP.VIAGEM:" + p.Id_viagemstr;
                                    rCaixa.Cd_Historico = lCfgAdto[0].CD_HistoricoVgFin;
                                    rCaixa.Login = Utils.Parametros.pubLogin;
                                    rCaixa.Dt_lancto = CamadaDados.UtilData.Data_Servidor();
                                    rCaixa.Vl_PAGAR = p.lDespesas.FindAll(x => x.Tp_pagamento.ToUpper().Equals("0")).Sum(x => x.Vl_subtotal) > p.SaldoDevolverC ?
                                    p.SaldoDevolverC : p.lDespesas.FindAll(x => x.Tp_pagamento.ToUpper().Equals("0")).Sum(x => x.Vl_subtotal);
                                    p.rCaixa = rCaixa;
                                }
                            }
                            //Se despesas forem maior que o Saldo a devolver do Funcionário gerar duplicatas à pagar
 
                           decimal subtotal = Convert.ToDecimal(p.lDespesas.FindAll(x => x.Tp_pagamento.ToUpper().Equals("0")).Sum(x => x.Vl_subtotal).ToString("N2", new System.Globalization.CultureInfo("pt-BR")));
                            if (subtotal >
                                p.SaldoDevolverC) 
                            {
                                if (string.IsNullOrEmpty(vTp_dup) &&
                                    string.IsNullOrEmpty(vCd_condpagto) &&
                                    string.IsNullOrEmpty(vCd_historico))
                                {
                                    using (TFDadosDuplicata fDados = new TFDadosDuplicata())
                                    {
                                        fDados.pCd_empresa = p.Cd_empresa;
                                        if (fDados.ShowDialog() == DialogResult.OK)
                                        {
                                            if (!string.IsNullOrEmpty(fDados.vTp_Duplicata) &&
                                                !string.IsNullOrEmpty(fDados.vCondPagto) &&
                                                !string.IsNullOrEmpty(fDados.vCd_historico))
                                            {
                                                vTp_dup = fDados.vTp_Duplicata;
                                                vCd_condpagto = fDados.vCondPagto;
                                                vCd_historico = fDados.vCd_historico;
                                                vTp_docto = fDados.vTp_docto;
                                                vCd_centroresult = fDados.vCd_centroresult;
                                                st_bloquear = false;
                                            }
                                            else
                                            {
                                                MessageBox.Show("Obrigatório informar dados para gerar duplicata!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                st_bloquear = true;
                                                return;
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("Obrigatório informar dados para gerar duplicata!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            st_bloquear = true;
                                            return;
                                        }
                                    }
                                }
                                CamadaDados.Financeiro.Duplicata.TRegistro_LanDuplicata rDup = new CamadaDados.Financeiro.Duplicata.TRegistro_LanDuplicata();
                                rDup.Cd_empresa = p.Cd_empresa;
                                rDup.Nm_empresa = p.Nm_empresa;
                                rDup.Cd_clifor = p.Cd_funcionario;
                                rDup.Nm_clifor = p.Nm_funcionario;
                                //endereco
                                TList_CadEndereco lEnd =
                                    TCN_CadEndereco.Buscar(p.Cd_funcionario,
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
                                    rDup.Cd_endereco = lEnd[0].Cd_endereco;
                                    rDup.Ds_endereco = lEnd[0].Ds_endereco;
                                }

                                if (!string.IsNullOrEmpty(vTp_docto))
                                    rDup.Tp_docto = Convert.ToDecimal(vTp_docto);
                                rDup.Tp_duplicata = vTp_dup;
                                rDup.Tp_mov = "P";
                                rDup.Cd_historico = vCd_historico;
                                //Centro Resultado
                                if (CamadaNegocio.ConfigGer.TCN_CadParamGer.BuscaVL_Bool("CRESULTADO_EMPRESA",
                                                                                p.Cd_empresa,
                                                                                null).Trim().ToUpper().Equals("S"))
                                {

                                    rDup.lCustoLancto.Add(new CamadaDados.Financeiro.CCustoLan.TRegistro_LanCCustoLancto()
                                    {
                                        Cd_empresa = p.Cd_empresa,
                                        Cd_centroresult = vCd_centroresult,
                                        Vl_lancto = p.lDespesas.FindAll(x => x.Tp_pagamento.ToUpper().Equals("0")).Sum(x => x.Vl_subtotal) -
                                                             p.SaldoDevolverC,
                                        Dt_lancto = CamadaDados.UtilData.Data_Servidor(),
                                        Tp_registro = "A"
                                    });
                                }
                                //Buscar Moeda Padrao
                                TList_Moeda tabela =
                                    CamadaNegocio.ConfigGer.TCN_CadParamGer_X_Empresa.BuscarMoedaPadrao(p.Cd_empresa, null);
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
                                rDup.Vl_documento = p.lDespesas.FindAll(x => x.Tp_pagamento.ToUpper().Equals("0")).Sum(x => x.Vl_subtotal) -
                                                     p.SaldoDevolverC;
                                rDup.Vl_documento_padrao = p.lDespesas.FindAll(x => x.Tp_pagamento.ToUpper().Equals("0")).Sum(x => x.Vl_subtotal) -
                                                     p.SaldoDevolverC;
                                DateTime dt_servidor = CamadaDados.UtilData.Data_Servidor();
                                rDup.Dt_emissao = CamadaDados.UtilData.Data_Servidor();
                                rDup.Nr_docto = "ACVG" + p.Id_viagemstr;
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
                                    Dt_vencto = rDup.Dt_emissao.Value.AddDays(2),
                                    Vl_parcela = rDup.Vl_documento,
                                    Vl_parcela_padrao = rDup.Vl_documento_padrao
                                });
                                p.rDup = rDup;
                            }
                            //Somar despesas para calcular saldo restante
                            SomaDespesas += p.lDespesas.FindAll(x => x.Tp_pagamento.ToUpper().Equals("0")).Sum(x => x.Vl_subtotal);
                        });
                    //Somente processar acerto se duplicata a pagar para funcionário estiver com os dados confirmados
                    if (!st_bloquear)
                        try
                        {
                            TCN_Viagem.AcertoViagem(fAcerto.lViagem, null);
                            MessageBox.Show("Acerto de Viagem processado com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LimpaFiltros();
                            afterBusca();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                }
            }
        }

        private void EstornarProcessamento()
        {
            if (bsViagem.Current != null)
            {
                if (!(bsViagem.Current as TRegistro_Viagem).St_registro.ToUpper().Equals("P"))
                {
                    MessageBox.Show("Somente poder ser estornada Viagem PROCESSADA!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (MessageBox.Show("Confirma o estorno da Viagem?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    == DialogResult.Yes)
                    try
                    {
                        TCN_Viagem.EstornoViagem(bsViagem.Current as TRegistro_Viagem, null);
                        MessageBox.Show("Viagem estornada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        afterBusca();
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void InserirDespesas()
        {
            using (TFDespesasViagem fDesp = new TFDespesasViagem())
            {
                if (fDesp.ShowDialog() == DialogResult.OK)
                    if (fDesp.rDespesas != null)
                    {
                        if (fDesp.rDespesas.Tp_pagamento.Trim().ToUpper().Equals("1"))
                        {
                            using (TFLanDuplicata fDup = new TFLanDuplicata())
                            {
                                fDup.vCd_empresa = (bsViagem.Current as TRegistro_Viagem).Cd_empresa;
                                fDup.vNm_empresa = (bsViagem.Current as TRegistro_Viagem).Nm_empresa;
                                fDup.vCd_clifor = fDesp.vCD_Clifor;
                                fDup.vNm_clifor = fDesp.rDespesas.Nm_fornecedor;

                                //Buscar Endereço
                                TList_CadEndereco lEnd =
                                    new TCD_CadEndereco().Select(
                                        new TpBusca[]
                                        {
                                            new TpBusca()
                                            {
                                                vNM_Campo = "a.cd_clifor",
                                                vOperador = "=",
                                                vVL_Busca = "'" + fDesp.vCD_Clifor.Trim() + "'"
                                            }
                                        }, 1, string.Empty);
                                if (lEnd.Count > 0)
                                {
                                    fDup.vCd_endereco = lEnd[0].Cd_endereco;
                                    fDup.vDs_endereco = lEnd[0].Ds_endereco;
                                }
                                fDup.vTp_mov = "P";
                                fDup.vDt_emissao = fDesp.rDespesas.Dt_despesastr;
                                fDup.vVl_documento = fDesp.rDespesas.Vl_subtotal;
                                fDup.vNr_docto = fDesp.rDespesas.Nr_notafiscal;
                                fDup.vSt_finPed = true;
                                fDup.St_bloquearccusto = true;//Centro Resultado sera lancado pela despesa da viagem
                                if (fDup.ShowDialog() == DialogResult.OK)
                                    if (fDup.dsDuplicata.Count > 0)
                                        fDesp.rDespesas.rDup = fDup.dsDuplicata.Current as CamadaDados.Financeiro.Duplicata.TRegistro_LanDuplicata;
                                    else
                                    {
                                        MessageBox.Show("Obrigatório gerar duplicata para incluir despesa!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        return;
                                    }
                                else
                                {
                                    MessageBox.Show("Obrigatório gerar duplicata para incluir despesa!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                            }
                        }
                        if (CamadaNegocio.ConfigGer.TCN_CadParamGer.BuscaVL_Bool("CRESULTADO_EMPRESA",
                                                                                 (bsViagem.Current as TRegistro_Viagem).Cd_empresa,
                                                                                 null).Trim().ToUpper().Equals("S"))
                        {
                            using (TFRateioCResultado fRateio = new TFRateioCResultado())
                            {
                                fRateio.vVl_Documento = fDesp.rDespesas.Vl_subtotal;
                                fRateio.Tp_mov = "P";
                                fRateio.Dt_movimento = fDesp.rDespesas.Dt_despesa;
                                fRateio.ShowDialog();
                                fDesp.rDespesas.lCCusto = fRateio.lCResultado;
                            }
                        }
                        try
                        {
                            fDesp.rDespesas.Cd_empresa = (bsViagem.Current as TRegistro_Viagem).Cd_empresa;
                            fDesp.rDespesas.Id_viagem = (bsViagem.Current as TRegistro_Viagem).Id_viagem;
                            TCN_DespesasViagem.Gravar(fDesp.rDespesas, null);
                            MessageBox.Show("Despesa gravada com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            bsViagem_PositionChanged(this, new EventArgs());
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    }
            }
        }

        private void AlterarDespesas()
        {
            if (bsDespesas.Current != null)
            {
                if ((bsViagem.Current as TRegistro_Viagem).St_registro.ToUpper().Equals("P"))
                {
                    MessageBox.Show("Não é permitido alterar despesa de viagem processada!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                decimal vl_despesa = (bsDespesas.Current as TRegistro_DespesasViagem).Vl_subtotal;
                using (TFDespesasViagem fDesp = new TFDespesasViagem())
                {
                    fDesp.rDespesas = bsDespesas.Current as TRegistro_DespesasViagem;
                    if (fDesp.ShowDialog() == DialogResult.OK)
                        if (fDesp.rDespesas != null)
                        {
                            //Verificar se valor da despesa foi modificada
                            if (vl_despesa != fDesp.rDespesas.Vl_subtotal)
                            {
                                if (fDesp.rDespesas.Tp_pagamento.Trim().ToUpper().Equals("1"))
                                {
                                    using (TFLanDuplicata fDup = new TFLanDuplicata())
                                    {
                                        fDup.vCd_empresa = (bsViagem.Current as TRegistro_Viagem).Cd_empresa;
                                        fDup.vNm_empresa = (bsViagem.Current as TRegistro_Viagem).Nm_empresa;
                                        fDup.vCd_clifor = fDesp.vCD_Clifor;
                                        fDup.vNm_clifor = fDesp.rDespesas.Nm_fornecedor;

                                        //Buscar Endereço
                                        TList_CadEndereco lEnd =
                                            new TCD_CadEndereco().Select(
                                                new TpBusca[]
                                                {
                                            new TpBusca()
                                            {
                                                vNM_Campo = "a.cd_clifor",
                                                vOperador = "=",
                                                vVL_Busca = "'" + fDesp.vCD_Clifor.Trim() + "'"
                                            }
                                                }, 1, string.Empty);
                                        if (lEnd.Count > 0)
                                        {
                                            fDup.vCd_endereco = lEnd[0].Cd_endereco;
                                            fDup.vDs_endereco = lEnd[0].Ds_endereco;
                                        }
                                        //fDup.vTp_docto = lCfg[0].Tp_doctostr;
                                        //fDup.vDs_tpdocto = lCfg[0].Ds_tpdocto;
                                        //fDup.vTp_duplicata = lCfg[0].Tp_duplicata;
                                        //fDup.vDs_tpduplicata = lCfg[0].Ds_tpduplicata;
                                        fDup.vTp_mov = "P";
                                        //fDup.vCd_historico = lCfg[0].Cd_historico;
                                        //fDup.vDs_historico = lCfg[0].Ds_historico;
                                        fDup.vDt_emissao = fDesp.rDespesas.Dt_despesastr;
                                        fDup.vVl_documento = fDesp.rDespesas.Vl_subtotal;
                                        fDup.vNr_docto = fDesp.rDespesas.Nr_notafiscal;
                                        fDup.vSt_finPed = true;
                                        fDup.St_bloquearccusto = true;//Centro Resultado sera lancado pela despesa da viagem
                                        if (fDup.ShowDialog() == DialogResult.OK)
                                            if (fDup.dsDuplicata.Count > 0)
                                                fDesp.rDespesas.rDup = fDup.dsDuplicata.Current as CamadaDados.Financeiro.Duplicata.TRegistro_LanDuplicata;
                                            else
                                            {
                                                MessageBox.Show("Obrigatório gerar duplicata para incluir despesa!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                return;
                                            }
                                        else
                                        {
                                            MessageBox.Show("Obrigatório gerar duplicata para incluir despesa!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            return;
                                        }
                                    }
                                }
                                if (CamadaNegocio.ConfigGer.TCN_CadParamGer.BuscaVL_Bool("CRESULTADO_EMPRESA",
                                                                                         (bsViagem.Current as TRegistro_Viagem).Cd_empresa,
                                                                                         null).Trim().ToUpper().Equals("S"))
                                {
                                    using (TFRateioCResultado fRateio = new TFRateioCResultado())
                                    {
                                        fRateio.vVl_Documento = fDesp.rDespesas.Vl_subtotal;
                                        fRateio.Tp_mov = "P";
                                        fRateio.Dt_movimento = fDesp.rDespesas.Dt_despesa;
                                        fRateio.ShowDialog();
                                        fDesp.rDespesas.lCCusto = fRateio.lCResultado;
                                    }
                                }
                            }
                            try
                            {
                                fDesp.rDespesas.Cd_empresa = (bsViagem.Current as TRegistro_Viagem).Cd_empresa;
                                fDesp.rDespesas.Id_viagem = (bsViagem.Current as TRegistro_Viagem).Id_viagem;
                                TCN_DespesasViagem.Alterar(fDesp.rDespesas, vl_despesa != fDesp.rDespesas.Vl_subtotal, null);
                                MessageBox.Show("Despesa alterada com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                bsViagem_PositionChanged(this, new EventArgs());
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                        }
                }
            }
        }

        private void ExcluirDespesas()
        {
            if (bsDespesas.Current != null)
            {
                if ((bsViagem.Current as TRegistro_Viagem).St_registro.ToUpper().Equals("P"))
                {
                    MessageBox.Show("Não é permitido excluir despesa de viagem processada!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (MessageBox.Show("Confirma a exclusão do item?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    == DialogResult.Yes)
                    try
                    {
                        TCN_DespesasViagem.Excluir(bsDespesas.Current as TRegistro_DespesasViagem, null);
                        MessageBox.Show("Despesa excluída com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        bsViagem_PositionChanged(this, new EventArgs());
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void TFLanViagem_Load(object sender, EventArgs e)
        {
            Icon = ResourcesUtils.TecnoAliance_ICO;
            pFiltro.set_FormatZero();
        }

        private void BB_Novo_Click(object sender, EventArgs e)
        {
            afterNovo();
        }

        private void BB_Alterar_Click(object sender, EventArgs e)
        {
            afterAltera();
        }

        private void BB_Excluir_Click(object sender, EventArgs e)
        {
            afterExclui();
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            afterBusca();
        }

        private void bb_adto_Click(object sender, EventArgs e)
        {
            IncluirAdto();
        }

        private void cd_empresa_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "'", new Componentes.EditDefault[] { cd_empresa });
        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { cd_empresa }, string.Empty);
        }

        private void Cd_funcionario_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_clifor|=|'" + Cd_funcionario.Text.Trim() + "';" +
                                "ISNULL(a.st_funcionarios, 'N')|=|'S'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { Cd_funcionario },
                                            new TCD_CadClifor());
        }

        private void bb_funcionario_Click(object sender, EventArgs e)
        {
            string vColunas = "a.nm_clifor|Motorista|200;" +
                             "a.cd_clifor|Codigo|80";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { Cd_funcionario },
                new TCD_CadClifor(),
               "ISNULL(a.st_funcionarios, 'N')|=|'S'");
        }

        private void TFLanViagem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F2))
                afterNovo();
            else if (e.KeyCode.Equals(Keys.F3))
                afterAltera();
            else if (e.KeyCode.Equals(Keys.F5))
                afterExclui();
            else if (e.KeyCode.Equals(Keys.F7))
                afterBusca();
            else if (e.KeyCode.Equals(Keys.F9))
                IncluirAdto();
            else if (e.KeyCode.Equals(Keys.F12))
                AcertoMotorista();
            else if (e.Control && e.KeyCode.Equals(Keys.F10))
                InserirDespesas();
            else if (e.Control && e.KeyCode.Equals(Keys.F11))
                EstornarProcessamento();
            else if (e.Control && e.KeyCode.Equals(Keys.F12))
                ExcluirDespesas();
            else if (e.Control && e.KeyCode.Equals(Keys.P))
            {
                MessageBox.Show("Execute o relatorio que deseja alterar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Altera_Relatorio = true;
            }
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bsViagem_PositionChanged(object sender, EventArgs e)
        {
            if (bsViagem.Current != null)
            {
                //Buscar Despesas
                (bsViagem.Current as TRegistro_Viagem).lDespesas =
                    TCN_DespesasViagem.Buscar((bsViagem.Current as TRegistro_Viagem).Id_viagemstr,
                                              (bsViagem.Current as TRegistro_Viagem).Cd_empresa,
                                              string.Empty,
                                              string.Empty,
                                              string.Empty,
                                              null);

                //Buscar Adiantamento
                (bsViagem.Current as TRegistro_Viagem).lAdto =
                    TCN_AdtoViagem.BuscarAdto((bsViagem.Current as TRegistro_Viagem).Cd_empresa,
                                              (bsViagem.Current as TRegistro_Viagem).Id_viagemstr,
                                              null);
                tcViagem_SelectedIndexChanged(this, new EventArgs());
                bsViagem.ResetCurrentItem();
                //Totalizar
                tot_func.Text = (bsViagem.Current as TRegistro_Viagem).lDespesas.FindAll(p => p.Tp_pagamento.Equals("0")).Sum(p => p.Vl_subtotal).ToString("N2", new System.Globalization.CultureInfo("pt-BR"));
                tot_empresa.Text = (bsViagem.Current as TRegistro_Viagem).lDespesas.FindAll(p => p.Tp_pagamento.Equals("1")).Sum(p => p.Vl_subtotal).ToString("N2", new System.Globalization.CultureInfo("pt-BR"));
                tot_geralDesp.Text = (bsViagem.Current as TRegistro_Viagem).lDespesas.Sum(p => p.Vl_subtotal).ToString("N2", new System.Globalization.CultureInfo("pt-BR"));
            }
        }

        private void bb_acerto_Click(object sender, EventArgs e)
        {
            AcertoMotorista();
        }

        private void gViagem_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
                if (e.ColumnIndex == 0)
                {
                    if (e.Value.ToString().Trim().ToUpper().Equals("ABERTA"))
                        gViagem.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                    else
                        gViagem.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Blue;
                }
        }

        private void tcViagem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bsViagem.Current != null)
            {
                if (tcViagem.SelectedTab.Equals(tpDuplicatas))
                {
                    //Buscar Duplicatas
                    (bsViagem.Current as TRegistro_Viagem).lDup =
                        TCN_Despesa_X_Duplicata.BuscarDup(string.Empty,
                                                            (bsViagem.Current as TRegistro_Viagem).Cd_empresa,
                                                            (bsViagem.Current as TRegistro_Viagem).Id_viagemstr,
                                                            null);
                    bsViagem.ResetCurrentItem();
                }
            }
        }

        private void listagemViagensToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bsViagem.Count > 0)
            {
                using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                {
                    FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                    Rel.Altera_Relatorio = Altera_Relatorio;
                    Rel.DTS_Relatorio = bsViagem;
                    Rel.Nome_Relatorio = "TFLanViagem_Lista";
                    Rel.NM_Classe = "TFLanViagem_Lista";
                    Rel.Modulo = "FIN";
                    Rel.Ident = "TFLanViagem_Lista";
                    fImp.St_enabled_enviaremail = true;
                    fImp.pCd_clifor = string.Empty;
                    fImp.pMensagem = "RELATORIO LISTA DE VIAGENS";

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
                                           "RELATORIO LISTA DE VIAGENS",
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
                                           "RELATORIO LISTA DE VIAGENS",
                                           fImp.pDs_mensagem);
                }
            }
            else
            {
                MessageBox.Show("Não existe Registros Para Imprimir o Relatório!");
            }
        }

        private void ts_btn_Inserir_Click(object sender, EventArgs e)
        {
            InserirDespesas();
        }

        private void BB_Alterar_Item_Click(object sender, EventArgs e)
        {
            AlterarDespesas();
        }

        private void ts_btn_Deletar_Click(object sender, EventArgs e)
        {
            ExcluirDespesas();
        }

        private void relatórioDaViagemToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (bsViagem.Count > 0)
            {
                using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                {
                    FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                    Rel.Altera_Relatorio = Altera_Relatorio;
                    Rel.DTS_Relatorio = bsDespesas;
                    BindingSource bs_viagem = new BindingSource();
                    bs_viagem.DataSource = new TList_Viagem() { bsViagem.Current as TRegistro_Viagem };
                    Rel.Adiciona_DataSource("dtsviagem", bs_viagem);
                    Rel.Nome_Relatorio = "TFLanRel_Viagem";
                    Rel.NM_Classe = "TFLanRel_Viagem";
                    Rel.Modulo = "FIN";
                    Rel.Ident = "TFLanRel_Viagem";
                    fImp.St_enabled_enviaremail = true;
                    fImp.pCd_clifor = string.Empty;
                    fImp.pMensagem = "RELATORIO DE VIAGEM";

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
                                           "RELATORIO DE VIAGEM",
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
                                           "RELATORIO DE VIAGEM",
                                           fImp.pDs_mensagem);
                }
            }
            else
            {
                MessageBox.Show("Não existe Registros Para Imprimir o Relatório!");
            }
        }

        private void bb_estornarProcessamento_Click(object sender, EventArgs e)
        {
            EstornarProcessamento();
        }

        private void gDespesas_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gDespesas.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsDespesas.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new TRegistro_DespesasViagem());
            TList_DespesasViagem lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gDespesas.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gDespesas.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new TList_DespesasViagem(lP.Find(gDespesas.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gDespesas.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new TList_DespesasViagem(lP.Find(gDespesas.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gDespesas.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsViagem.Current as TRegistro_Viagem).lDespesas.Sort(lComparer);
            bsDespesas.ResetBindings(false);
            gDespesas.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void gViagem_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gViagem.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsViagem.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new TRegistro_Viagem());
            TList_Viagem lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gViagem.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gViagem.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new TList_Viagem(lP.Find(gViagem.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gViagem.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new TList_Viagem(lP.Find(gViagem.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gViagem.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsViagem.List as TList_Viagem).Sort(lComparer);
            bsViagem.ResetBindings(false);
            gViagem.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void label3_TextChanged(object sender, EventArgs e)
        {

        }

        private void NM_Fornecedor_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string vColunas = "a.nm_clifor|Fornecedor|200;" +
                             "a.cd_clifor|Codigo|80";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { NM_Fornecedor },
                new TCD_CadClifor(),
               "ISNULL(a.st_fornecedor, 'N')|=|'S'");
        }

        private void bbCliente_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_cliente }, string.Empty);
        }

        private void cd_cliente_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + cd_cliente.Text.Trim() + "'",
                new Componentes.EditDefault[] { cd_cliente },
                new TCD_CadClifor());
        }
    }
}
