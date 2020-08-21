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
    public partial class TFDespesasViagem : Form
    {
        private CamadaDados.Frota.Cadastros.TList_CfgFrota lCfg;
        public CamadaDados.Frota.TRegistro_Viagem rViagem
        { get; set; }
        private string vCD_Clifor
        { get; set; }
        private string vCD_CliforAbast
        { get; set; }

        public TFDespesasViagem()
        {
            InitializeComponent();
            System.Collections.ArrayList cbx = new System.Collections.ArrayList();
            cbx.Add(new Utils.TDataCombo("MOTORISTA", "M"));
            cbx.Add(new Utils.TDataCombo("EMPRESA", "E"));
            tp_pagamento.DataSource = cbx;
            tp_pagamento.DisplayMember = "Display";
            tp_pagamento.ValueMember = "Value";


            System.Collections.ArrayList cbx1 = new System.Collections.ArrayList();
            cbx1.Add(new Utils.TDataCombo("MOTORISTA", "M"));
            cbx1.Add(new Utils.TDataCombo("EMPRESA", "E"));
            tpPagtoAbast.DataSource = cbx1;
            tpPagtoAbast.DisplayMember = "Display";
            tpPagtoAbast.ValueMember = "Value";

            System.Collections.ArrayList cbx2 = new System.Collections.ArrayList();
            cbx2.Add(new Utils.TDataCombo("MOTORISTA", "M"));
            cbx2.Add(new Utils.TDataCombo("EMPRESA", "E"));
            tp_pagtoManut.DataSource = cbx2;
            tp_pagtoManut.DisplayMember = "Display";
            tp_pagtoManut.ValueMember = "Value";
        }

        #region Metodos Despesas
        private void NovaDespesa()
        {
            bb_novo_despesa.Enabled = false;
            bb_alterar_despesa.Enabled = false;
            bb_gravar_despesa.Enabled = true;
            bb_excluir_despesa.Enabled = true;
            pDespesas.HabilitarControls(true, Utils.TTpModo.tm_Insert);
            bsDespesas.AddNew();
            (bsDespesas.Current as CamadaDados.Frota.TRegistro_DespesasViagem).Id_viagem = (bsViagem.Current as CamadaDados.Frota.TRegistro_Viagem).Id_viagem;
            (bsDespesas.Current as CamadaDados.Frota.TRegistro_DespesasViagem).Cd_empresa = (bsViagem.Current as CamadaDados.Frota.TRegistro_Viagem).Cd_empresa;
            id_despesa.Focus();
        }

        private void AlterarDespesa()
        {
            if (bsDespesas.Current != null)
            {
                bb_novo_despesa.Enabled = false;
                bb_alterar_despesa.Enabled = false;
                bb_gravar_despesa.Enabled = true;
                bb_excluir_despesa.Enabled = false;
                pDespesas.HabilitarControls(true, Utils.TTpModo.tm_Edit);
                dt_despesa.Enabled = false;
                quantidade.Enabled = false;
                vl_unitario.Enabled = false;
                vl_subtotal.Enabled = false;
                tp_pagamento.Enabled = false;
                id_despesa.Focus();
            }
        }

        private void GravarDespesa()
        {
            if (bsDespesas.Current != null)
                if (pDespesas.validarCampoObrigatorio())
                {
                    if (!(bsDespesas.Current as CamadaDados.Frota.TRegistro_DespesasViagem).Id_landespesa.HasValue)
                    {
                        if ((bsDespesas.Current as CamadaDados.Frota.TRegistro_DespesasViagem).Tp_pagamento.Trim().ToUpper().Equals("E"))
                        {
                            //Buscar config abast
                            CamadaDados.Frota.Cadastros.TList_CfgFrota lCfg =
                                CamadaNegocio.Frota.Cadastros.TCN_CfgFrota.Buscar((bsDespesas.Current as CamadaDados.Frota.TRegistro_DespesasViagem).Cd_empresa,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  null);
                            using (Financeiro.TFLanDuplicata fDup = new Financeiro.TFLanDuplicata())
                            {
                                fDup.vCd_empresa = (bsViagem.Current as CamadaDados.Frota.TRegistro_Viagem).Cd_empresa;
                                fDup.vNm_empresa = (bsViagem.Current as CamadaDados.Frota.TRegistro_Viagem).Nm_empresa;
                                fDup.vCd_clifor = vCD_Clifor;
                                fDup.vNm_clifor = (bsDespesas.Current as CamadaDados.Frota.TRegistro_DespesasViagem).Nm_fornecedor;
                                if (lCfg.Count > 0)
                                {
                                    if (string.IsNullOrEmpty(lCfg[0].Tp_duplicata))
                                    {
                                        MessageBox.Show("Não existe Tp.duplicata na CFG.Frota cadastrada!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        return;
                                    }
                                    fDup.vTp_docto = lCfg[0].Tp_doctostr;
                                    fDup.vDs_tpdocto = lCfg[0].Ds_tpdocto;
                                    fDup.vTp_duplicata = lCfg[0].Tp_duplicata;
                                    fDup.vDs_tpduplicata = lCfg[0].Ds_tpduplicata;
                                    fDup.vTp_mov = "P";
                                    fDup.vCd_historico = lCfg[0].Cd_historico;
                                    fDup.vDs_historico = lCfg[0].Ds_historico;
                                    fDup.vDt_emissao = (bsDespesas.Current as CamadaDados.Frota.TRegistro_DespesasViagem).Dt_despesastr;
                                    fDup.vVl_documento = (bsDespesas.Current as CamadaDados.Frota.TRegistro_DespesasViagem).Vl_subtotal;
                                    fDup.vNr_docto = (bsDespesas.Current as CamadaDados.Frota.TRegistro_DespesasViagem).Nr_notafiscal;
                                    fDup.vSt_ecf = true;
                                    fDup.St_bloquearccusto = true;//Centro Resultado sera lancado pelo modulo frota
                                    if (fDup.ShowDialog() == DialogResult.OK)
                                        if (fDup.dsDuplicata.Count > 0)
                                            (bsDespesas.Current as CamadaDados.Frota.TRegistro_DespesasViagem).rDup = fDup.dsDuplicata.Current as CamadaDados.Financeiro.Duplicata.TRegistro_LanDuplicata;
                                }
                                else
                                {
                                    MessageBox.Show("Não existe configuração frota para lançar duplicata!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                            }
                        }
                        if (CamadaNegocio.ConfigGer.TCN_CadParamGer.BuscaVL_Bool("CRESULTADO_EMPRESA",
                                                                                 (bsViagem.Current as CamadaDados.Frota.TRegistro_Viagem).Cd_empresa,
                                                                                 null).Trim().ToUpper().Equals("S"))
                        {
                            //Verificar se historico possui centro resultado cadastrado
                            object obj = new CamadaDados.Financeiro.Cadastros.TCD_CadHistorico().BuscarEscalar(
                                            new Utils.TpBusca[]
                                            {
                                                new Utils.TpBusca()
                                                {
                                                    vNM_Campo = "a.cd_historico",
                                                    vOperador = "=",
                                                    vVL_Busca = "'" + lCfg[0].Cd_historico.Trim() + "'"
                                                }
                                            }, "a.cd_centroresult");
                            if (obj == null ? false : !string.IsNullOrEmpty(obj.ToString()))
                            {
                                (bsDespesas.Current as CamadaDados.Frota.TRegistro_DespesasViagem).lCCusto.Add(
                                    new CamadaDados.Financeiro.CCustoLan.TRegistro_LanCCustoLancto()
                                    {
                                        Cd_empresa = (bsViagem.Current as CamadaDados.Frota.TRegistro_Viagem).Cd_empresa,
                                        Cd_centroresult = obj.ToString(),
                                        Vl_lancto = (bsDespesas.Current as CamadaDados.Frota.TRegistro_DespesasViagem).Vl_subtotal,
                                        Dt_lancto = (bsDespesas.Current as CamadaDados.Frota.TRegistro_DespesasViagem).Dt_despesa,
                                        Tp_registro = "A"
                                    });
                            }
                            else 
                                using (Financeiro.TFRateioCResultado fRateio = new Financeiro.TFRateioCResultado())
                                {
                                    fRateio.vVl_Documento = (bsDespesas.Current as CamadaDados.Frota.TRegistro_DespesasViagem).Vl_subtotal;
                                    fRateio.Tp_mov = "P";
                                    fRateio.Dt_movimento = (bsDespesas.Current as CamadaDados.Frota.TRegistro_DespesasViagem).Dt_despesa;
                                    fRateio.ShowDialog();
                                    (bsDespesas.Current as CamadaDados.Frota.TRegistro_DespesasViagem).lCCusto = fRateio.lCResultado;
                                }
                        }
                    }
                    try
                    {
                        CamadaNegocio.Frota.TCN_DespesasViagem.Gravar(bsDespesas.Current as CamadaDados.Frota.TRegistro_DespesasViagem, null);
                        MessageBox.Show("Despesa gravada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        bb_novo_despesa.Enabled = true;
                        bb_alterar_despesa.Enabled = true;
                        bb_gravar_despesa.Enabled = false;
                        bb_excluir_despesa.Enabled = true;
                        pDespesas.HabilitarControls(false, Utils.TTpModo.tm_Standby);
                        //Totalizar Despesas
                        tot_despesas.Value = (bsViagem.Current as CamadaDados.Frota.TRegistro_Viagem).lDespesas.Sum(p => p.Vl_subtotal);
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
        }

        private void ExcluirDespesa()
        {
            if (bsDespesas.Current != null)
                if ((bsDespesas.Current as CamadaDados.Frota.TRegistro_DespesasViagem).Id_despesa.HasValue)
                {
                    if (MessageBox.Show("Confirma exclusão da despesa selecionada?", "Pergunta", MessageBoxButtons.YesNo,
                         MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                        try
                        {
                            CamadaNegocio.Frota.TCN_DespesasViagem.Excluir(bsDespesas.Current as CamadaDados.Frota.TRegistro_DespesasViagem, null);
                            MessageBox.Show("Despesa excluida com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            bsDespesas.RemoveCurrent();
                            bb_novo_despesa.Enabled = true;
                            bb_alterar_despesa.Enabled = true;
                            bb_gravar_despesa.Enabled = false;
                            bb_excluir_despesa.Enabled = true;
                            //Totalizar Despesas
                            tot_despesas.Value = (bsViagem.Current as CamadaDados.Frota.TRegistro_Viagem).lDespesas.Sum(p => p.Vl_subtotal);
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
                else bsDespesas.RemoveCurrent();
        }
        #endregion

        #region Metodos Manutencao
        private void NovaManutenaco()
        {
            bb_nova_manut.Enabled = false;
            bb_alterar_manut.Enabled = false;
            bb_gravar_manut.Enabled = true;
            bb_excluir_manut.Enabled = true;
            pManutencao.HabilitarControls(true, Utils.TTpModo.tm_Insert);
            bsManutencao.AddNew();
            (bsManutencao.Current as CamadaDados.Frota.Cadastros.TRegistro_ManutencaoVeiculo).Id_viagem = (bsViagem.Current as CamadaDados.Frota.TRegistro_Viagem).Id_viagem;
            (bsManutencao.Current as CamadaDados.Frota.Cadastros.TRegistro_ManutencaoVeiculo).Cd_empresa = (bsViagem.Current as CamadaDados.Frota.TRegistro_Viagem).Cd_empresa;
            (bsManutencao.Current as CamadaDados.Frota.Cadastros.TRegistro_ManutencaoVeiculo).Id_veiculo = (bsViagem.Current as CamadaDados.Frota.TRegistro_Viagem).Id_veiculo;
            (bsManutencao.Current as CamadaDados.Frota.Cadastros.TRegistro_ManutencaoVeiculo).Cd_cliforResponsavel = (bsViagem.Current as CamadaDados.Frota.TRegistro_Viagem).Cd_motorista;
            id_despesaManut.Focus();
        }

        private void AlterarManutencao()
        {
            if (bsManutencao.Current != null)
            {
                bb_nova_manut.Enabled = false;
                bb_alterar_manut.Enabled = false;
                bb_gravar_manut.Enabled = true;
                bb_excluir_manut.Enabled = false;
                pManutencao.HabilitarControls(true, Utils.TTpModo.tm_Edit);
                dt_manutencao.Enabled = false;
                vl_realizada.Enabled = false;
                tp_pagtoManut.Enabled = false;
                id_despesaManut.Focus();
            }
        }

        private void GravarManutencao()
        {
            if (bsManutencao.Current != null)
                if(pManutencao.validarCampoObrigatorio())
                    try
                    {
                        if (!(bsManutencao.Current as CamadaDados.Frota.Cadastros.TRegistro_ManutencaoVeiculo).Id_manutencao.HasValue)
                        {
                            if ((bsManutencao.Current as CamadaDados.Frota.Cadastros.TRegistro_ManutencaoVeiculo).Tp_pagamento.ToUpper().Equals("E"))
                            {
                                using (Financeiro.TFLanDuplicata fDup = new Financeiro.TFLanDuplicata())
                                {
                                    fDup.vCd_empresa = (bsViagem.Current as CamadaDados.Frota.TRegistro_Viagem).Cd_empresa;
                                    fDup.vNm_empresa = (bsViagem.Current as CamadaDados.Frota.TRegistro_Viagem).Nm_empresa;
                                    fDup.vCd_clifor = (bsManutencao.Current as CamadaDados.Frota.Cadastros.TRegistro_ManutencaoVeiculo).Cd_cliforOficina;
                                    fDup.vNm_clifor = (bsManutencao.Current as CamadaDados.Frota.Cadastros.TRegistro_ManutencaoVeiculo).Nm_cliforOficina;
                                    if (lCfg.Count > 0)
                                    {
                                        if (string.IsNullOrEmpty(lCfg[0].Tp_duplicata))
                                        {
                                            MessageBox.Show("Não existe Tp.duplicata na CFG.Frota cadastrada!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            return;
                                        }
                                        fDup.vTp_docto = lCfg[0].Tp_doctostr;
                                        fDup.vDs_tpdocto = lCfg[0].Ds_tpdocto;
                                        fDup.vTp_duplicata = lCfg[0].Tp_duplicata;
                                        fDup.vDs_tpduplicata = lCfg[0].Ds_tpduplicata;
                                        fDup.vTp_mov = "P";
                                        fDup.vCd_historico = lCfg[0].Cd_historico;
                                        fDup.vDs_historico = lCfg[0].Ds_historico;
                                        fDup.vDt_emissao = (bsManutencao.Current as CamadaDados.Frota.Cadastros.TRegistro_ManutencaoVeiculo).Dt_realizadastr;
                                        fDup.vVl_documento = (bsManutencao.Current as CamadaDados.Frota.Cadastros.TRegistro_ManutencaoVeiculo).Vl_realizada;
                                        fDup.vNr_docto = (bsManutencao.Current as CamadaDados.Frota.Cadastros.TRegistro_ManutencaoVeiculo).Nr_notafiscal;
                                        fDup.vSt_ecf = true;
                                        fDup.St_bloquearccusto = true;//Centro Resultado sera lancado pelo modulo frota
                                        if (fDup.ShowDialog() == DialogResult.OK)
                                            if (fDup.dsDuplicata.Count > 0)
                                                (bsManutencao.Current as CamadaDados.Frota.Cadastros.TRegistro_ManutencaoVeiculo).rDup = fDup.dsDuplicata.Current as CamadaDados.Financeiro.Duplicata.TRegistro_LanDuplicata;
                                    }
                                    else
                                    {
                                        MessageBox.Show("Não existe configuração frota para lançar duplicata!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        return;
                                    }
                                }
                            }
                            if (CamadaNegocio.ConfigGer.TCN_CadParamGer.BuscaVL_Bool("CRESULTADO_EMPRESA",
                                                                                     (bsViagem.Current as CamadaDados.Frota.TRegistro_Viagem).Cd_empresa,
                                                                                     null).Trim().ToUpper().Equals("S"))
                            {
                                //Verificar se historico possui centro resultado cadastrado
                                object obj = new CamadaDados.Financeiro.Cadastros.TCD_CadHistorico().BuscarEscalar(
                                                new Utils.TpBusca[]
                                                {
                                                    new Utils.TpBusca()
                                                    {
                                                        vNM_Campo = "a.cd_historico",
                                                        vOperador = "=",
                                                        vVL_Busca = "'" + lCfg[0].Cd_historico.Trim() + "'"
                                                    }
                                                }, "a.cd_centroresult");
                                if (obj == null ? false : !string.IsNullOrEmpty(obj.ToString()))
                                {
                                    (bsManutencao.Current as CamadaDados.Frota.Cadastros.TRegistro_ManutencaoVeiculo).lCCusto.Add(
                                        new CamadaDados.Financeiro.CCustoLan.TRegistro_LanCCustoLancto()
                                        {
                                            Cd_empresa = (bsViagem.Current as CamadaDados.Frota.TRegistro_Viagem).Cd_empresa,
                                            Cd_centroresult = obj.ToString(),
                                            Vl_lancto = (bsManutencao.Current as CamadaDados.Frota.Cadastros.TRegistro_ManutencaoVeiculo).Vl_realizada,
                                            Dt_lancto = (bsManutencao.Current as CamadaDados.Frota.Cadastros.TRegistro_ManutencaoVeiculo).Dt_realizada,
                                            Tp_registro = "A"
                                        });
                                }
                                else 
                                    using (Financeiro.TFRateioCResultado fRateio = new Financeiro.TFRateioCResultado())
                                    {
                                        fRateio.vVl_Documento = (bsManutencao.Current as CamadaDados.Frota.Cadastros.TRegistro_ManutencaoVeiculo).Vl_realizada;
                                        fRateio.Tp_mov = "P";
                                        fRateio.Dt_movimento = (bsManutencao.Current as CamadaDados.Frota.Cadastros.TRegistro_ManutencaoVeiculo).Dt_realizada;
                                        fRateio.ShowDialog();
                                        (bsManutencao.Current as CamadaDados.Frota.Cadastros.TRegistro_ManutencaoVeiculo).lCCusto = fRateio.lCResultado;
                                    }
                            }
                        }
                        CamadaNegocio.Frota.Cadastros.TCN_ManutencaoVeiculo.Gravar(bsManutencao.Current as CamadaDados.Frota.Cadastros.TRegistro_ManutencaoVeiculo, null);
                        MessageBox.Show("Manutenção gravada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        bb_nova_manut.Enabled = true;
                        bb_alterar_manut.Enabled = true;
                        bb_gravar_manut.Enabled = false;
                        bb_excluir_manut.Enabled = true;
                        pManutencao.HabilitarControls(false, Utils.TTpModo.tm_Standby);
                        //Totalizar Manutencao
                        tot_manutencao.Value = (bsViagem.Current as CamadaDados.Frota.TRegistro_Viagem).lManutencao.Sum(p => p.Vl_realizada);
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void ExcluirManutencao()
        {
            if (bsManutencao.Current != null)
                if ((bsManutencao.Current as CamadaDados.Frota.Cadastros.TRegistro_ManutencaoVeiculo).Id_manutencao.HasValue)
                {
                    if (MessageBox.Show("Confirma exclusão da manutenção selecionada?", "Pergunta", MessageBoxButtons.YesNo,
                         MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                        try
                        {
                            CamadaNegocio.Frota.Cadastros.TCN_ManutencaoVeiculo.Excluir(bsManutencao.Current as CamadaDados.Frota.Cadastros.TRegistro_ManutencaoVeiculo, null);
                            MessageBox.Show("Manutenção excluida com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            bsManutencao.RemoveCurrent();
                            bb_nova_manut.Enabled = true;
                            bb_alterar_manut.Enabled = true;
                            bb_gravar_manut.Enabled = false;
                            bb_excluir_manut.Enabled = true;
                            //Totalizar Manutencao
                            tot_manutencao.Value = (bsViagem.Current as CamadaDados.Frota.TRegistro_Viagem).lManutencao.Sum(p => p.Vl_realizada);
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
                else bsManutencao.RemoveCurrent();
        }
        #endregion

        #region Metodos Abastecimento
        private void NovaAbastecimento()
        {
            bb_novo_abastecimento.Enabled = false;
            bb_alterar_abastecimento.Enabled = false;
            bb_gravar_abastecimento.Enabled = true;
            bb_excluir_abastecimento.Enabled = true;
            pAbastecimento.HabilitarControls(true, Utils.TTpModo.tm_Insert);
            bsAbastecimento.AddNew();
            (bsAbastecimento.Current as CamadaDados.Frota.TRegistro_AbastVeiculo).Id_viagem = (bsViagem.Current as CamadaDados.Frota.TRegistro_Viagem).Id_viagem;
            (bsAbastecimento.Current as CamadaDados.Frota.TRegistro_AbastVeiculo).Cd_empresa = (bsViagem.Current as CamadaDados.Frota.TRegistro_Viagem).Cd_empresa;
            (bsAbastecimento.Current as CamadaDados.Frota.TRegistro_AbastVeiculo).Id_veiculo = (bsViagem.Current as CamadaDados.Frota.TRegistro_Viagem).Id_veiculo;
            (bsAbastecimento.Current as CamadaDados.Frota.TRegistro_AbastVeiculo).Tp_abastecimento = "T";
            (bsAbastecimento.Current as CamadaDados.Frota.TRegistro_AbastVeiculo).Tp_registro = "A";
            if (lCfg.Count > 0)
            {
                id_despesaAbast.Text = lCfg[0].Id_despesacombustivelstr;
                ds_despesaAbast.Text = lCfg[0].Ds_despesacombustivel;
                cd_produto.Text = lCfg[0].Cd_combustivel;
                ds_produto.Text = lCfg[0].Ds_combustivel;
                dt_abastecimento.Focus();
            }
            else
                id_despesaAbast.Focus();
        }

        private void AlterarAbastecimento()
        {
            if (bsAbastecimento.Current != null)
                if ((bsAbastecimento.Current as CamadaDados.Frota.TRegistro_AbastVeiculo).Tp_abastecimento.Trim().ToUpper().Equals("T"))
                {
                    bb_novo_abastecimento.Enabled = false;
                    bb_alterar_abastecimento.Enabled = false;
                    bb_gravar_abastecimento.Enabled = true;
                    bb_excluir_abastecimento.Enabled = false;
                    pAbastecimento.HabilitarControls(true, Utils.TTpModo.tm_Edit);
                    dt_abastecimento.Enabled = false;
                    volume.Enabled = false;
                    vl_unitarioAbast.Enabled = false;
                    vl_subtotalAbast.Enabled = false;
                    tpPagtoAbast.Enabled = false;
                    id_despesaAbast.Focus();
                }
        }

        private void GravarAbastecimento()
        {
            if (bsAbastecimento.Current != null)
                if (pAbastecimento.validarCampoObrigatorio())
                {
                    //Buscar config abast
                    CamadaDados.Frota.Cadastros.TList_CfgFrota lCfg =
                        CamadaNegocio.Frota.Cadastros.TCN_CfgFrota.Buscar((bsAbastecimento.Current as CamadaDados.Frota.TRegistro_AbastVeiculo).Cd_empresa,
                                                                          string.Empty,
                                                                          string.Empty,
                                                                          string.Empty,
                                                                          null);
                    if(lCfg.Count > 0)
                        if (lCfg[0].St_km_obrigatoriobool && km_abastecimento.Value.Equals(decimal.Zero))
                        {
                            MessageBox.Show("Configuração exige KM para toda abastecida.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    if (!(bsAbastecimento.Current as CamadaDados.Frota.TRegistro_AbastVeiculo).Id_abastecimento.HasValue)
                    {
                        if ((bsAbastecimento.Current as CamadaDados.Frota.TRegistro_AbastVeiculo).Tp_pagamento.Trim().ToUpper().Equals("E"))
                        {

                            using (Financeiro.TFLanDuplicata fDup = new Financeiro.TFLanDuplicata())
                            {
                                fDup.vCd_empresa = (bsViagem.Current as CamadaDados.Frota.TRegistro_Viagem).Cd_empresa;
                                fDup.vNm_empresa = (bsViagem.Current as CamadaDados.Frota.TRegistro_Viagem).Nm_empresa;
                                fDup.vCd_clifor = vCD_CliforAbast;
                                fDup.vNm_clifor = (bsAbastecimento.Current as CamadaDados.Frota.TRegistro_AbastVeiculo).Nm_fornecedor;
                                if (lCfg.Count > 0)
                                {
                                    if (string.IsNullOrEmpty(lCfg[0].Tp_duplicata))
                                    {
                                        MessageBox.Show("Não existe Tp.duplicata na CFG.Frota cadastrada!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        return;
                                    }
                                    fDup.vTp_docto = lCfg[0].Tp_doctostr;
                                    fDup.vDs_tpdocto = lCfg[0].Ds_tpdocto;
                                    fDup.vTp_duplicata = lCfg[0].Tp_duplicata;
                                    fDup.vDs_tpduplicata = lCfg[0].Ds_tpduplicata;
                                    fDup.vTp_mov = "P";
                                    fDup.vCd_historico = lCfg[0].Cd_historico;
                                    fDup.vDs_historico = lCfg[0].Ds_historico;
                                    fDup.vDt_emissao = (bsAbastecimento.Current as CamadaDados.Frota.TRegistro_AbastVeiculo).Dt_abastecimentostr;
                                    fDup.vVl_documento = (bsAbastecimento.Current as CamadaDados.Frota.TRegistro_AbastVeiculo).Vl_subtotal;
                                    fDup.vNr_docto = (bsAbastecimento.Current as CamadaDados.Frota.TRegistro_AbastVeiculo).Nr_notafiscal;
                                    fDup.vSt_ecf = true;
                                    fDup.St_bloquearccusto = true;//Centro Resultado sera lancado pelo modulo frota
                                    if (fDup.ShowDialog() == DialogResult.OK)
                                        if (fDup.dsDuplicata.Count > 0)
                                            (bsAbastecimento.Current as CamadaDados.Frota.TRegistro_AbastVeiculo).rDup = fDup.dsDuplicata.Current as CamadaDados.Financeiro.Duplicata.TRegistro_LanDuplicata;
                                }
                                else
                                {
                                    MessageBox.Show("Não existe configuração frota para lançar duplicata!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                            }
                        }
                        if (CamadaNegocio.ConfigGer.TCN_CadParamGer.BuscaVL_Bool("CRESULTADO_EMPRESA",
                                                                                 (bsViagem.Current as CamadaDados.Frota.TRegistro_Viagem).Cd_empresa,
                                                                                 null).Trim().ToUpper().Equals("S"))
                        {
                            //Verificar se historico possui centro resultado cadastrado
                            object obj = new CamadaDados.Financeiro.Cadastros.TCD_CadHistorico().BuscarEscalar(
                                            new Utils.TpBusca[]
                                            {
                                                new Utils.TpBusca()
                                                {
                                                    vNM_Campo = "a.cd_historico",
                                                    vOperador = "=",
                                                    vVL_Busca = "'" + lCfg[0].Cd_historico.Trim() + "'"
                                                }
                                            }, "a.cd_centroresult");
                            if (obj == null ? false : !string.IsNullOrEmpty(obj.ToString()))
                            {
                                (bsAbastecimento.Current as CamadaDados.Frota.TRegistro_AbastVeiculo).lCCusto.Add(
                                    new CamadaDados.Financeiro.CCustoLan.TRegistro_LanCCustoLancto()
                                    {
                                        Cd_empresa = (bsViagem.Current as CamadaDados.Frota.TRegistro_Viagem).Cd_empresa,
                                        Cd_centroresult = obj.ToString(),
                                        Vl_lancto = (bsAbastecimento.Current as CamadaDados.Frota.TRegistro_AbastVeiculo).Vl_subtotal,
                                        Dt_lancto = (bsAbastecimento.Current as CamadaDados.Frota.TRegistro_AbastVeiculo).Dt_abastecimento,
                                        Tp_registro = "A"
                                    });
                            }
                            else
                                using (Financeiro.TFRateioCResultado fRateio = new Financeiro.TFRateioCResultado())
                                {
                                    fRateio.vVl_Documento = (bsAbastecimento.Current as CamadaDados.Frota.TRegistro_AbastVeiculo).Vl_subtotal;
                                    fRateio.Tp_mov = "P";
                                    fRateio.Dt_movimento = (bsAbastecimento.Current as CamadaDados.Frota.TRegistro_AbastVeiculo).Dt_abastecimento;
                                    fRateio.ShowDialog();
                                    (bsAbastecimento.Current as CamadaDados.Frota.TRegistro_AbastVeiculo).lCCusto = fRateio.lCResultado;
                                }
                        }
                    }
                    try
                    {
                        CamadaNegocio.Frota.TCN_AbastVeiculo.Gravar(bsAbastecimento.Current as CamadaDados.Frota.TRegistro_AbastVeiculo, null);
                        MessageBox.Show("Abastecimento gravado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        bb_novo_abastecimento.Enabled = true;
                        bb_alterar_abastecimento.Enabled = true;
                        bb_gravar_abastecimento.Enabled = false;
                        bb_excluir_abastecimento.Enabled = true;
                        pAbastecimento.HabilitarControls(false, Utils.TTpModo.tm_Standby);
                        //Totalizar Manutencao
                        tot_abastecimento.Value = (bsViagem.Current as CamadaDados.Frota.TRegistro_Viagem).lAbastecimentos.Sum(p => p.Vl_subtotal);
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
        }

        private void ExcluirAbastecimento()
        {
            if (bsAbastecimento.Current != null)
                if ((bsAbastecimento.Current as CamadaDados.Frota.TRegistro_AbastVeiculo).Id_abastecimento.HasValue)
                {
                    if ((bsAbastecimento.Current as CamadaDados.Frota.TRegistro_AbastVeiculo).Tp_abastecimento.Trim().ToUpper().Equals("T"))
                        if (MessageBox.Show("Confirma exclusão do abastecimento selecionado?", "Pergunta", MessageBoxButtons.YesNo,
                             MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                            try
                            {
                                CamadaNegocio.Frota.TCN_AbastVeiculo.Excluir(bsAbastecimento.Current as CamadaDados.Frota.TRegistro_AbastVeiculo, null);
                                MessageBox.Show("Abastecimento excluido com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                bsAbastecimento.RemoveCurrent();
                                bb_novo_abastecimento.Enabled = true;
                                bb_alterar_abastecimento.Enabled = true;
                                bb_gravar_abastecimento.Enabled = false;
                                bb_excluir_abastecimento.Enabled = true;
                                //Totalizar Manutencao
                                tot_abastecimento.Value = (bsViagem.Current as CamadaDados.Frota.TRegistro_Viagem).lAbastecimentos.Sum(p => p.Vl_subtotal);
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
                else bsAbastecimento.RemoveCurrent();
        }
        #endregion

        private void TFDespesasViagem_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            bsViagem.DataSource = new CamadaDados.Frota.TList_Viagem() { rViagem };
            pDespesas.set_FormatZero();
            pAbastecimento.set_FormatZero();
            pManutencao.set_FormatZero();
            //Buscar config empresa
            lCfg = CamadaNegocio.Frota.Cadastros.TCN_CfgFrota.Buscar(rViagem.Cd_empresa,
                                                                     string.Empty,
                                                                     string.Empty,
                                                                     string.Empty,
                                                                     null);
            //Totalizar Despesas
            tot_despesas.Value = rViagem.lDespesas.Sum(p => p.Vl_subtotal);
            tot_manutencao.Value = rViagem.lManutencao.Sum(p => p.Vl_realizada);
            tot_abastecimento.Value = rViagem.lAbastecimentos.Sum(p => p.Vl_subtotal);
        }

        private void id_despesa_Leave(object sender, EventArgs e)
        {
            string vParam = "a.id_despesa|=|" + id_despesa.Text + ";" +
                            "a.tp_despesa|=|'DV'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { id_despesa, ds_despesa },
                                                new CamadaDados.Frota.Cadastros.TCD_Despesa());
        }

        private void bb_despesa_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_despesa|Despesa|200;" +
                              "a.id_despesa|Codigo|80";
            string vParam = "a.tp_despesa|=|'DV'";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { id_despesa, ds_despesa },
                                            new CamadaDados.Frota.Cadastros.TCD_Despesa(), vParam);
        }

        private void bb_fornecedor_Click(object sender, EventArgs e)
        {
            string vParam = "isnull(a.st_fornecedor, 'N')|=|'S';" +
                                "isnull(a.st_registro, 'C')|=|'A'";
           DataRowView  linha = FormBusca.UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { nm_fornecedor }, vParam);

           if (linha != null)
               vCD_Clifor = linha["cd_clifor"].ToString();
        }

        private void quantidade_Leave(object sender, EventArgs e)
        {
            vl_subtotal.Value = quantidade.Value * vl_unitario.Value;
        }

        private void vl_unitario_Leave(object sender, EventArgs e)
        {
            vl_subtotal.Value = quantidade.Value * vl_unitario.Value;
        }

        private void vl_subtotal_Leave(object sender, EventArgs e)
        {
            if(quantidade.Value > decimal.Zero)
                vl_unitario.Value = vl_subtotal.Value / quantidade.Value;
        }

        private void bb_novo_despesa_Click(object sender, EventArgs e)
        {
            this.NovaDespesa();
        }

        private void bb_alterar_despesa_Click(object sender, EventArgs e)
        {
            this.AlterarDespesa();
        }

        private void bb_gravar_despesa_Click(object sender, EventArgs e)
        {
            this.GravarDespesa();
        }

        private void bb_excluir_despesa_Click(object sender, EventArgs e)
        {
            this.ExcluirDespesa();
        }

        private void id_despesaManut_Leave(object sender, EventArgs e)
        {
            string vParam = "a.id_despesa|=|" + id_despesaManut.Text + ";" +
                            "a.tp_despesa|=|'MV'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { id_despesaManut, ds_despesaManut },
                                                new CamadaDados.Frota.Cadastros.TCD_Despesa());
        }

        private void bb_despesaManut_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_despesa|Despesa|200;" +
                              "a.id_despesa|Codigo|80";
            string vParam = "a.tp_despesa|=|'MV'";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { id_despesaManut, ds_despesaManut },
                                            new CamadaDados.Frota.Cadastros.TCD_Despesa(), vParam);
        }

        private void bb_nova_manut_Click(object sender, EventArgs e)
        {
            this.NovaManutenaco();
        }

        private void bb_alterar_manut_Click(object sender, EventArgs e)
        {
            this.AlterarManutencao();
        }

        private void bb_gravar_manut_Click(object sender, EventArgs e)
        {
            this.GravarManutencao();
        }

        private void bb_excluir_manut_Click(object sender, EventArgs e)
        {
            this.ExcluirManutencao();
        }

        private void cd_cliforoficina_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_clifor|=|'" + cd_cliforoficina.Text.Trim() + "';" +
                               "isnull(a.st_fornecedor, 'N')|=|'S';" +
                                "isnull(a.st_registro, 'C')|=|'A'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_cliforoficina, nm_cliforoficina },
                                            new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void bb_cliforoficina_Click(object sender, EventArgs e)
        {
            string vParam = "isnull(a.st_fornecedor, 'N')|=|'S';" +
                                "isnull(a.st_registro, 'C')|=|'A'";
            FormBusca.UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_cliforoficina, nm_cliforoficina }, vParam);
        }

        private void bb_novo_abastecimento_Click(object sender, EventArgs e)
        {
            this.NovaAbastecimento();
        }

        private void bb_alterar_abastecimento_Click(object sender, EventArgs e)
        {
            this.AlterarAbastecimento();
        }

        private void bb_gravar_abastecimento_Click(object sender, EventArgs e)
        {
            this.GravarAbastecimento();
        }

        private void bb_excluir_abastecimento_Click(object sender, EventArgs e)
        {
            this.ExcluirAbastecimento();
        }

        private void id_despesaAbast_Leave(object sender, EventArgs e)
        {
            string vParam = "a.id_despesa|=|" + id_despesaAbast.Text + ";" +
                            "a.tp_despesa|=|'AB'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { id_despesaAbast, ds_despesaAbast },
                                                new CamadaDados.Frota.Cadastros.TCD_Despesa());
        }

        private void bb_despesaAbast_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_despesa|Despesa|200;" +
                              "a.id_despesa|Codigo|80";
            string vParam = "a.tp_despesa|=|'AB'";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { id_despesaAbast, ds_despesaAbast },
                                            new CamadaDados.Frota.Cadastros.TCD_Despesa(), vParam);
        }

        private void bb_fornecedorAbast_Click(object sender, EventArgs e)
        {
            string vParam = "isnull(a.st_fornecedor, 'N')|=|'S';" +
                               "isnull(a.st_registro, 'C')|=|'A'";
            DataRowView linha = FormBusca.UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { nm_fornecedorAbast }, vParam);

            if (linha != null)
                vCD_CliforAbast = linha["cd_clifor"].ToString();
        }

        private void volume_Leave(object sender, EventArgs e)
        {
            vl_subtotal.Value = volume.Value * vl_unitarioAbast.Value;
        }

        private void vl_unitarioAbast_Leave(object sender, EventArgs e)
        {
            vl_subtotalAbast.Value = volume.Value * vl_unitarioAbast.Value;
        }

        private void vl_subtotalAbast_Leave(object sender, EventArgs e)
        {
            if (volume.Value > decimal.Zero)
                vl_unitarioAbast.Value = vl_subtotalAbast.Value / volume.Value;
        }

        private void bb_produto_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaProduto(new Componentes.EditDefault[] { cd_produto, ds_produto }, "isnull(e.st_combustivel, 'N')|=|'S'");
        }

        private void cd_produto_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LEAVEProduto("a.cd_produto|=|'" + cd_produto.Text.Trim() + "';" +
                                                     "isnull(e.st_combustivel, 'N')|=|'S'",
                                                     new Componentes.EditDefault[] { cd_produto, ds_produto },
                                                     new CamadaDados.Estoque.Cadastros.TCD_CadProduto());
        }

        private void gDespesas_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gDespesas.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsDespesas.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new CamadaDados.Frota.TRegistro_DespesasViagem());
            CamadaDados.Frota.TList_DespesasViagem lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gDespesas.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gDespesas.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new CamadaDados.Frota.TList_DespesasViagem(lP.Find(gDespesas.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gDespesas.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new CamadaDados.Frota.TList_DespesasViagem(lP.Find(gDespesas.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gDespesas.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsDespesas.List as CamadaDados.Frota.TList_DespesasViagem).Sort(lComparer);
            bsDespesas.ResetBindings(false);
            gDespesas.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void gManutencao_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gManutencao.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsManutencao.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new CamadaDados.Frota.Cadastros.TRegistro_ManutencaoVeiculo());
            CamadaDados.Frota.Cadastros.TList_ManutencaoVeiculo lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gManutencao.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gManutencao.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new CamadaDados.Frota.Cadastros.TList_ManutencaoVeiculo(lP.Find(gManutencao.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gManutencao.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new CamadaDados.Frota.Cadastros.TList_ManutencaoVeiculo(lP.Find(gManutencao.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gManutencao.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsManutencao.List as CamadaDados.Frota.Cadastros.TList_ManutencaoVeiculo).Sort(lComparer);
            bsManutencao.ResetBindings(false);
            gManutencao.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void gAbastecimento_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gAbastecimento.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsAbastecimento.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new CamadaDados.Frota.TRegistro_AbastVeiculo());
            CamadaDados.Frota.TList_AbastVeiculo lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gAbastecimento.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gAbastecimento.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new CamadaDados.Frota.TList_AbastVeiculo(lP.Find(gAbastecimento.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gAbastecimento.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new CamadaDados.Frota.TList_AbastVeiculo(lP.Find(gAbastecimento.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gAbastecimento.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsAbastecimento.List as CamadaDados.Frota.TList_AbastVeiculo).Sort(lComparer);
            bsAbastecimento.ResetBindings(false);
            gAbastecimento.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void button1_Click(object sender, EventArgs e)
        {
             Utils.InputBox iB = new Utils.InputBox();
            CamadaDados.Frota.Cadastros.TRegistro_Despesa a = new CamadaDados.Frota.Cadastros.TRegistro_Despesa();
            a.Tp_despesa = "DV";
           
            iB.Text = "Despesa:";
            a.Ds_despesa = iB.ShowDialog().ToUpper();
            if (string.IsNullOrEmpty(a.Ds_despesa))
            {
                MessageBox.Show("Obrigatório informar descrição da Despesa", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                string id = string.Empty;
                id = CamadaNegocio.Frota.Cadastros.TCN_Despesa.Gravar(a, null);
                id_despesa.Text = id;
                ds_despesa.Text = a.Ds_despesa;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Utils.InputBox iB = new Utils.InputBox();
            CamadaDados.Frota.Cadastros.TRegistro_Despesa a = new CamadaDados.Frota.Cadastros.TRegistro_Despesa();
            a.Tp_despesa = "MV";

            iB.Text = "Despesa:";
            a.Ds_despesa = iB.ShowDialog().ToUpper();
            if (string.IsNullOrEmpty(a.Ds_despesa))
            {
                MessageBox.Show("Obrigatório informar descrição da Despesa", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                string id = string.Empty;
                id = CamadaNegocio.Frota.Cadastros.TCN_Despesa.Gravar(a, null);
                id_despesaManut.Text = id;
                ds_despesaManut.Text = a.Ds_despesa;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Utils.InputBox iB = new Utils.InputBox();
            CamadaDados.Frota.Cadastros.TRegistro_Despesa a = new CamadaDados.Frota.Cadastros.TRegistro_Despesa();
            a.Tp_despesa = "AB";

            iB.Text = "Despesa:";
            a.Ds_despesa = iB.ShowDialog().ToUpper();
            if (string.IsNullOrEmpty(a.Ds_despesa))
            {
                MessageBox.Show("Obrigatório informar descrição da Despesa", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                string id = string.Empty;
                id = CamadaNegocio.Frota.Cadastros.TCN_Despesa.Gravar(a, null);
                id_despesaAbast.Text = id;
                ds_despesaAbast.Text = a.Ds_despesa;
            }
        }
    }
}
