using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CamadaDados.Frota;
using CamadaNegocio.Frota;
using CamadaNegocio.Diversos;
using CamadaDados.Frota.Cadastros;
using CamadaNegocio.Frota.Cadastros;

namespace Frota
{
    public partial class TFLanViagem : Form
    {
        private bool Altera_Relatorio = false;
        public TFLanViagem()
        {
            InitializeComponent();
        }

        private void TFLanViagem_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gViagem);
            Utils.ShapeGrid.RestoreShape(this, gRota);
            Utils.ShapeGrid.RestoreShape(this, gCTRC);
            Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pFiltro.set_FormatZero();
        }

        private void LimpaFiltros()
        {
            Id_viagem.Clear();
            cd_empresa.Clear();
            Id_veiculo.Clear();
            Cd_motorista.Clear();
            dt_ini.Clear();
            dt_fin.Clear();
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
            if (cbProgramada.Checked)
            {
                status = "'P'";
                virg = ",";
            }
            if (cbExecutando.Checked)
            {
                status += virg + "'E'";
                virg = ",";
            }
            if (cbFinalizada.Checked)
            {
                status += virg + "'F'";
                virg = ",";
            }
            if (cbCancelada.Checked)
                status += "'C'";
            bsViagem.DataSource = TCN_Viagem.Buscar(Id_viagem.Text,
                                                      cd_empresa.Text,
                                                      Id_veiculo.Text,
                                                      string.Empty,
                                                      Cd_motorista.Text,
                                                      rbViagem.Checked ? "V" : rbRetorno.Checked ? "R" : string.Empty,
                                                      dt_ini.Text,
                                                      dt_fin.Text,
                                                      ds_observacao.Text,
                                                      status,
                                                      null);
            bsViagem_PositionChanged(this, new EventArgs());
        }

        private void afterAltera()
        {
            if (bsViagem.Current != null)
            {
                if ((bsViagem.Current as TRegistro_Viagem).St_viagem.Trim().ToUpper().Equals("C"))
                {
                    MessageBox.Show("Não é permitido alterar Viagem CANCELADA.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if ((bsViagem.Current as TRegistro_Viagem).St_viagem.Trim().ToUpper().Equals("F"))
                {
                    MessageBox.Show("Não é permitido alterar Viagem FINALIZADA.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                    LimpaFiltros();
                    Id_viagem.Text = fViagem.rViagem.Id_viagemstr;
                    cd_empresa.Text = fViagem.rViagem.Cd_empresa;
                    afterBusca();
                }
            }
        }

        private void afterExclui()
        {
            if (bsViagem.Current != null)
            {
                if ((bsViagem.Current as TRegistro_Viagem).St_viagem.Trim().ToUpper().Equals("C"))
                {
                    MessageBox.Show("Viagem ja se encontra CANCELADA.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if ((bsViagem.Current as TRegistro_Viagem).St_viagem.Trim().ToUpper().Equals("F"))
                {
                    MessageBox.Show("Não é permitido cancelar Viagem FINALIZADA.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (CamadaNegocio.ConfigGer.TCN_CadParamGer.BuscaVL_Bool("ST_ADTO_VIAGEM", string.Empty, null).Trim().ToUpper().Equals("S"))
            {
                if (bsViagem.Current != null)
                {
                    if ((bsViagem.Current as TRegistro_Viagem).St_viagem.Trim().ToUpper().Equals("F"))
                    {
                        MessageBox.Show("Não é permitido incluir adiantamento para viagem FINALIZADA.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if ((bsViagem.Current as TRegistro_Viagem).St_viagem.Trim().ToUpper().Equals("C"))
                    {
                        MessageBox.Show("Não é permitido incluir adiantamento para viagem CANCELADA.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    using (Financeiro.TFLan_Adiantamento fAdto = new Financeiro.TFLan_Adiantamento())
                    {
                        fAdto.BS_Adiantamento.AddNew();
                        (fAdto.BS_Adiantamento.Current as CamadaDados.Financeiro.Adiantamento.TRegistro_LanAdiantamento).Tp_movimento = "C";
                        (fAdto.BS_Adiantamento.Current as CamadaDados.Financeiro.Adiantamento.TRegistro_LanAdiantamento).Cd_empresa = (bsViagem.Current as TRegistro_Viagem).Cd_empresa;
                        (fAdto.BS_Adiantamento.Current as CamadaDados.Financeiro.Adiantamento.TRegistro_LanAdiantamento).Nm_empresa = (bsViagem.Current as TRegistro_Viagem).Nm_empresa;
                        (fAdto.BS_Adiantamento.Current as CamadaDados.Financeiro.Adiantamento.TRegistro_LanAdiantamento).Cd_clifor = (bsViagem.Current as TRegistro_Viagem).Cd_motorista;
                        (fAdto.BS_Adiantamento.Current as CamadaDados.Financeiro.Adiantamento.TRegistro_LanAdiantamento).Nm_clifor = (bsViagem.Current as TRegistro_Viagem).Nm_motorista;
                        //Buscar endereco motorista
                        CamadaDados.Financeiro.Cadastros.TList_CadEndereco lEnd =
                            CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Buscar((bsViagem.Current as TRegistro_Viagem).Cd_motorista,
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
                        (fAdto.BS_Adiantamento.Current as CamadaDados.Financeiro.Adiantamento.TRegistro_LanAdiantamento).Dt_prevdevolucao = (bsViagem.Current as TRegistro_Viagem).Dt_prevRetorno;

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
            else
            {
                using (Financeiro.TFLan_Adiantamento fAdto = new Financeiro.TFLan_Adiantamento())
                {
                    fAdto.BS_Adiantamento.AddNew();
                    (fAdto.BS_Adiantamento.Current as CamadaDados.Financeiro.Adiantamento.TRegistro_LanAdiantamento).Tp_movimento = "C";
                    (fAdto.BS_Adiantamento.Current as CamadaDados.Financeiro.Adiantamento.TRegistro_LanAdiantamento).TP_Lancto = "R";
                    fAdto.rb_Adiantamento.Enabled = false;
                    fAdto.rb_Recebido.Enabled = false;
                    if (bsViagem.Current != null)
                    {
                        (fAdto.BS_Adiantamento.Current as CamadaDados.Financeiro.Adiantamento.TRegistro_LanAdiantamento).Cd_empresa = (bsViagem.Current as TRegistro_Viagem).Cd_empresa;
                        (fAdto.BS_Adiantamento.Current as CamadaDados.Financeiro.Adiantamento.TRegistro_LanAdiantamento).Nm_empresa = (bsViagem.Current as TRegistro_Viagem).Nm_empresa;
                        (fAdto.BS_Adiantamento.Current as CamadaDados.Financeiro.Adiantamento.TRegistro_LanAdiantamento).Cd_clifor = (bsViagem.Current as TRegistro_Viagem).Cd_motorista;
                        (fAdto.BS_Adiantamento.Current as CamadaDados.Financeiro.Adiantamento.TRegistro_LanAdiantamento).Nm_clifor = (bsViagem.Current as TRegistro_Viagem).Nm_motorista;
                        //Buscar endereco motorista
                        CamadaDados.Financeiro.Cadastros.TList_CadEndereco lEnd =
                            CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Buscar((bsViagem.Current as TRegistro_Viagem).Cd_motorista,
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
                        (fAdto.BS_Adiantamento.Current as CamadaDados.Financeiro.Adiantamento.TRegistro_LanAdiantamento).Dt_prevdevolucao = (bsViagem.Current as TRegistro_Viagem).Dt_prevRetorno;
                    }

                    if (fAdto.ShowDialog() == DialogResult.OK)
                        if(fAdto.BS_Adiantamento.Current != null)
                            try
                            {
                                CamadaNegocio.Financeiro.Adiantamento.TCN_LanAdiantamento.Gravar(fAdto.BS_Adiantamento.Current as CamadaDados.Financeiro.Adiantamento.TRegistro_LanAdiantamento, null);
                                MessageBox.Show("Adiantamento gravado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim()); }
                }
            }
        }

        private void IncluirDespesas()
        {
            if(bsViagem.Current != null)
                if((bsViagem.Current as TRegistro_Viagem).St_viagem.Trim().ToUpper().Equals("P") ||
                    (bsViagem.Current as TRegistro_Viagem).St_viagem.Trim().ToUpper().Equals("E"))
                    using (TFDespesasViagem fDespesa = new TFDespesasViagem())
                    {
                        fDespesa.rViagem = bsViagem.Current as TRegistro_Viagem;
                        fDespesa.ShowDialog();
                        LimpaFiltros();
                        Id_viagem.Text = (bsViagem.Current as TRegistro_Viagem).Id_viagemstr;
                        cd_empresa.Text = (bsViagem.Current as TRegistro_Viagem).Cd_empresa;
                        afterBusca();
                    }
        }

        private void RequisicaoAbast()
        {
            if(bsViagem.Current != null)
                if((bsViagem.Current as TRegistro_Viagem).St_viagem.Trim().ToUpper().Equals("P") ||
                    (bsViagem.Current as TRegistro_Viagem).St_viagem.Trim().ToUpper().Equals("E"))
                    using (TFRequisicao fRequisicao = new TFRequisicao())
                    {
                        fRequisicao.rViagem = bsViagem.Current as TRegistro_Viagem;
                        if (fRequisicao.ShowDialog() == DialogResult.OK)
                            if (fRequisicao.rAbast != null)
                                try
                                {
                                    fRequisicao.rAbast.LoginRequisicao = Utils.Parametros.pubLogin;
                                    fRequisicao.rAbast.Tp_registro = "R";//Requisicao
                                    TCN_AbastVeiculo.Gravar(fRequisicao.rAbast, null);
                                    MessageBox.Show("Requisição gravada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    LimpaFiltros();
                                    Id_viagem.Text = (bsViagem.Current as TRegistro_Viagem).Id_viagemstr;
                                    afterBusca();
                                }
                                catch (Exception ex)
                                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    }
        }

        private void AcertoMotorista()
        {
            using (TFAcertoMotorista fAcerto = new TFAcertoMotorista())
            {
                if (bsViagem.Current != null)
                {
                    fAcerto.Cd_empresa = (bsViagem.Current as TRegistro_Viagem).Cd_empresa;
                    fAcerto.Nm_empresa = (bsViagem.Current as TRegistro_Viagem).Nm_empresa;
                    fAcerto.Cd_motorista = (bsViagem.Current as TRegistro_Viagem).Cd_motorista;
                    fAcerto.Nm_motorista = (bsViagem.Current as TRegistro_Viagem).Nm_motorista;
                    fAcerto.Id_viagem = (bsViagem.Current as TRegistro_Viagem).Id_viagemstr;
                    if(fAcerto.ShowDialog() == DialogResult.OK)
                        if (fAcerto.rAcerto != null)
                            try
                            {
                                TCN_AcertoMotorista.Gravar(fAcerto.rAcerto, null);
                                if (MessageBox.Show("Acerto gravado com sucesso.\r\n" +
                                                   "Deseja processar acerto?", "Pergunta",
                                                   MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                                {
                                    if (fAcerto.rAcerto.Vl_sobradinheiro > decimal.Zero)
                                    {
                                        using (Financeiro.TFLanCaixa fCaixa = new Financeiro.TFLanCaixa())
                                        {
                                            fCaixa.Text = "CAIXA SOBRA DINHEIRO";
                                            fCaixa.dsLanCaixa.AddNew();
                                            (fCaixa.dsLanCaixa.Current as CamadaDados.Financeiro.Caixa.TRegistro_LanCaixa).Cd_Empresa = fAcerto.rAcerto.Cd_empresa;
                                            (fCaixa.dsLanCaixa.Current as CamadaDados.Financeiro.Caixa.TRegistro_LanCaixa).Nm_empresa = fAcerto.rAcerto.Nm_empresa;
                                            fCaixa.RB_Receber.Checked = true;
                                            fCaixa.RB_Pagar.Enabled = false;
                                            fCaixa.RB_Receber.Enabled = false;
                                            (fCaixa.dsLanCaixa.Current as CamadaDados.Financeiro.Caixa.TRegistro_LanCaixa).Vl_RECEBER = fAcerto.rAcerto.Vl_sobradinheiro;
                                            fCaixa.VL_Receber.Enabled = false;
                                            if (fCaixa.ShowDialog() == DialogResult.OK)
                                                if (fCaixa.dsLanCaixa.Current != null)
                                                {
                                                    fAcerto.rAcerto.rCaixa = fCaixa.dsLanCaixa.Current as CamadaDados.Financeiro.Caixa.TRegistro_LanCaixa;
                                                    if (MessageBox.Show("Deseja gerar credito com a sobra de dinheiro?", "Pergunta", MessageBoxButtons.YesNo,
                                                         MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                                                    {
                                                        fAcerto.rAcerto.rAdto = new CamadaDados.Financeiro.Adiantamento.TRegistro_LanAdiantamento();
                                                        fAcerto.rAcerto.rAdto.Cd_empresa = fAcerto.rAcerto.Cd_empresa;
                                                        fAcerto.rAcerto.rAdto.Cd_clifor = fAcerto.rAcerto.Cd_motorista;
                                                        //endereco
                                                        CamadaDados.Financeiro.Cadastros.TList_CadEndereco lEnd =
                                                            CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Buscar(fAcerto.rAcerto.rAdto.Cd_clifor,
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
                                                            fAcerto.rAcerto.rAdto.CD_Endereco = lEnd[0].Cd_endereco;
                                                        fAcerto.rAcerto.rAdto.Tp_movimento = "C";
                                                        fAcerto.rAcerto.rAdto.Dt_lancto = fAcerto.rAcerto.rCaixa.Dt_lancto;
                                                        fAcerto.rAcerto.rAdto.Vl_adto = fAcerto.rAcerto.rCaixa.Vl_RECEBER;
                                                        fAcerto.rAcerto.rAdto.ST_ADTO = "A";
                                                        fAcerto.rAcerto.rAdto.TP_Lancto = "R";
                                                        fAcerto.rAcerto.rAdto.Cd_contager_qt = fAcerto.rAcerto.rCaixa.Cd_ContaGer;
                                                    }
                                                }
                                                else
                                                {
                                                    MessageBox.Show("Obrigatorio informar caixa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                    return;
                                                }
                                            else
                                            {
                                                MessageBox.Show("Obrigatorio informar caixa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                return;
                                            }
                                        }
                                    }
                                    if (fAcerto.rAcerto.Vl_resultado < decimal.Zero)
                                        using (Financeiro.TFLanDuplicata fDup = new Financeiro.TFLanDuplicata())
                                        {
                                            fDup.Text = "DUPLICATA A PAGAR PARA O MOTORISTA";
                                            //Empresa
                                            fDup.vCd_empresa = fAcerto.rAcerto.Cd_empresa;
                                            fDup.vNm_empresa = fAcerto.rAcerto.Nm_empresa;
                                            fDup.cd_empresa.Enabled = false;
                                            fDup.bb_empresa.Enabled = false;
                                            //Cliente
                                            fDup.vCd_clifor = fAcerto.rAcerto.Cd_motorista;
                                            fDup.vNm_clifor = fAcerto.rAcerto.Nm_motorista;
                                            fDup.cd_clifor.Enabled = false;
                                            fDup.bb_clifor.Enabled = false;
                                            //endereco
                                            CamadaDados.Financeiro.Cadastros.TList_CadEndereco lEnd =
                                                CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Buscar(fDup.vCd_clifor,
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
                                                fDup.cd_endereco.Enabled = false;
                                                fDup.bb_endereco.Enabled = false;
                                            }
                                            fDup.vTp_mov = "P";
                                            fDup.vVl_documento = Math.Abs(fAcerto.rAcerto.Vl_resultado);
                                            fDup.vl_documento_index.Enabled = false;
                                            fDup.vNr_docto = "AC" + fAcerto.rAcerto.Id_acertostr;
                                            if (fDup.ShowDialog() == DialogResult.OK)
                                            {
                                                if (fDup.dsDuplicata.Count > 0)
                                                    fAcerto.rAcerto.rDup = fDup.dsDuplicata.Current as CamadaDados.Financeiro.Duplicata.TRegistro_LanDuplicata;
                                            }
                                            else
                                            {
                                                MessageBox.Show("Obrigatorio informar financeiro para processar acerto.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                return;
                                            }
                                        }
                                    fAcerto.rAcerto.lCartaFrete.ForEach(p =>
                                    {
                                        using (Financeiro.TFLanDuplicata fDup = new Financeiro.TFLanDuplicata())
                                        {
                                            fDup.Text = "DUPLICATA CARTA FRETE Nº" + p.Nr_cartafretestr;
                                            //Empresa
                                            fDup.vCd_empresa = fAcerto.rAcerto.Cd_empresa;
                                            fDup.vNm_empresa = fAcerto.rAcerto.Nm_empresa;
                                            fDup.cd_empresa.Enabled = false;
                                            fDup.bb_empresa.Enabled = false;
                                            fDup.vTp_mov = "P";
                                            fDup.vVl_documento = p.Vl_documento;
                                            fDup.vl_documento_index.Enabled = false;
                                            fDup.vNr_docto = "CARTAFRETE" + p.Nr_cartafretestr;
                                            if (fDup.ShowDialog() == DialogResult.OK)
                                            {
                                                if (fDup.dsDuplicata.Count > 0)
                                                    p.rDup = fDup.dsDuplicata.Current as CamadaDados.Financeiro.Duplicata.TRegistro_LanDuplicata;
                                            }
                                            else
                                            {
                                                MessageBox.Show("Obrigatorio informar financeiro para processar acerto.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                return;
                                            }
                                        }
                                    });
                                    try
                                    {
                                        TCN_AcertoMotorista.ProcessarAcerto(fAcerto.rAcerto, null);
                                        MessageBox.Show("Acerto processado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        bsViagem_PositionChanged(this, new EventArgs());
                                        ImprimirAcerto(fAcerto.rAcerto);
                                    }
                                    catch (Exception ex)
                                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                                }
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                }
            }
        }

        private void InserirFrete()
        {
            using (TFListFrete fFretef = new TFListFrete())
            {
                fFretef.Cd_empresa = (bsViagem.Current as TRegistro_Viagem).Cd_empresa;
                if (fFretef.ShowDialog() == DialogResult.OK)
                    if (fFretef.lFreteF != null)
                    {
                        fFretef.lFreteF.ForEach(p =>
                        {
                            TCN_Viagem_X_Frete.Gravar(new TRegistro_Viagem_X_Frete()
                            {
                                Cd_empresa = p.Cd_empresa,
                                Id_viagem = (bsViagem.Current as TRegistro_Viagem).Id_viagem,
                                Nr_lanctoCTRC = p.Nr_lanctoCTRC
                            }, null);
                        });
                        MessageBox.Show("Cte inserido com sucesso a Viagem Nº " + (bsViagem.Current as TRegistro_Viagem).Id_viagem, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        bsViagem_PositionChanged(this, new EventArgs());
                        bsViagem.ResetCurrentItem();
                    }
            }
        }

        private void ExcluirFrete()
        {
            if (bsCTRC.Current != null)
            {
                if (MessageBox.Show("Confirma exclusão do frete selecionado?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    try
                    {
                        TCN_Viagem_X_Frete.Excluir(new TRegistro_Viagem_X_Frete()
                        {
                            Cd_empresa = (bsCTRC.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Cd_empresa,
                            Id_viagem = (bsViagem.Current as TRegistro_Viagem).Id_viagem,
                            Nr_lanctoCTRC = (bsCTRC.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).Nr_lanctoCTRC
                        }, null);
                        MessageBox.Show("Cte excluido com sucesso da Viagem Nº " + (bsViagem.Current as TRegistro_Viagem).Id_viagem, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        bsCTRC.RemoveCurrent();
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
            else
                MessageBox.Show("Obrigatorio selecionar um frete para excluir.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ImprimirDev(decimal valor,
                                 string Cd_contager,
                                 CamadaDados.Financeiro.Caixa.TRegistro_LanCaixa rCaixa)
        {
            using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
            {
                //Preencher dados empresa da duplicata
                BindingSource Empresa = new BindingSource();
                Empresa.DataSource = TCN_CadEmpresa.Busca((bsReceitas.Current as TRegistro_OutrasReceitas).Cd_empresa, string.Empty, string.Empty, null);
                string Valor_Extenso = string.Empty;
                string transf = string.Empty;
                //Buscar Moeda da Conta Gerencial
                CamadaDados.Financeiro.Cadastros.TList_Moeda lMoeda =
                    new CamadaDados.Financeiro.Cadastros.TCD_Moeda().Select(
                    new Utils.TpBusca[]
                    {
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = string.Empty,
                                    vOperador = "exists",
                                    vVL_Busca = "(select 1 from tb_fin_contager x "+
                                                "where x.cd_moeda = a.cd_moeda "+
                                                "and x.cd_contager = '" + Cd_contager.Trim() + "')"
                                }
                    }, 1, string.Empty);
                if (lMoeda.Count > 0)
                    Valor_Extenso = new Utils.Extenso().ValorExtenso(valor, lMoeda[0].Ds_moeda_singular, lMoeda[0].Ds_moeda_plural);
                else
                    Valor_Extenso = new Utils.Extenso().ValorExtenso(valor, "Real", "Reais");
                //Criar objeto Relatório
                FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                BindingSource Bin = new BindingSource();
                Rel.Altera_Relatorio = Altera_Relatorio;
                Bin.DataSource = new TList_OutrasReceitas { bsReceitas.Current as TRegistro_OutrasReceitas };
                Rel.DTS_Relatorio = Bin;
                Rel.Nome_Relatorio = "TFLanViagem_Recibo";
                Rel.NM_Classe = "TFLanViagem";
                Rel.Ident = "TFLanViagem_Recibo";
                Rel.Modulo = "FIN";
                fImp.St_enabled_enviaremail = true;
                fImp.pCd_clifor = string.Empty;
                BindingSource caixa = new BindingSource();
                caixa.DataSource = new CamadaDados.Financeiro.Caixa.TList_LanCaixa() { rCaixa };
                BindingSource moeda = new BindingSource();
                moeda.DataSource = lMoeda[0];
                Rel.Parametros_Relatorio.Add("VALOREXTENSO", Valor_Extenso);
                Rel.Parametros_Relatorio.Add("VALOR", valor);
                Rel.Adiciona_DataSource("MOEDA", moeda);
                Rel.Adiciona_DataSource("CAIXA", caixa);
                if (Empresa.Count > 0)
                    if ((Empresa.List[0] as CamadaDados.Diversos.TRegistro_CadEmpresa).Img != null)
                        Rel.Parametros_Relatorio.Add("IMAGEM_RELATORIO", (Empresa.List[0] as CamadaDados.Diversos.TRegistro_CadEmpresa).Img);
                Rel.Adiciona_DataSource("EMPRESA", Empresa);
                fImp.pMensagem = "RECIBO DE DEVOLUÇÃO ADIANTAMENTO CAIXA";

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
                                       "RECIBO DE DEVOLUÇÃO ADIANTAMENTO CAIXA",
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
                                       "RECIBO DE DEVOLUÇÃO ADIANTAMENTO CAIXA",
                                       fImp.pDs_mensagem);
            }
        }

        private void ImprimirAcerto(TRegistro_AcertoMotorista val)
        {
            if (val != null)
            {
                using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                {
                    FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                    Rel.Altera_Relatorio = Altera_Relatorio;
                    BindingSource bs_valor = new BindingSource();
                    bs_valor.DataSource = new TList_AcertoMotorista() { val };
                    Rel.DTS_Relatorio = bs_valor;
                    Rel.Nome_Relatorio = "TFLanViagem_Acerto";
                    Rel.Ident = "TFLanViagem_Acerto";
                    Rel.NM_Classe = "TFLanViagem_Acerto";
                    Rel.Modulo = "LOC";
                    fImp.St_enabled_enviaremail = true;
                    fImp.pCd_clifor = val.Cd_motorista;
                    fImp.pMensagem = "ACERTO MOTORISTA";

                    //Buscar dados Empresa
                    CamadaDados.Diversos.TList_CadEmpresa lEmpresa =
                        CamadaNegocio.Diversos.TCN_CadEmpresa.Busca(val.Cd_empresa,
                                                                    string.Empty,
                                                                    string.Empty,
                                                                    null);
                    if (lEmpresa.Count > 0)
                        if (lEmpresa[0].Img != null)
                            Rel.Parametros_Relatorio.Add("IMAGEM_RELATORIO", lEmpresa[0].Img);

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
                                           "ACERTO MOTORISTA",
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
                                           "ACERTO MOTORISTA",
                                           fImp.pDs_mensagem);
                }
            }
        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { cd_empresa }, string.Empty);
        }

        private void cd_empresa_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "'", new Componentes.EditDefault[] { cd_empresa });
        }

        private void bb_motorista_Click(object sender, EventArgs e)
        {
            string vParam = "isnull(a.st_motorista, 'N')|=|'S';" +
                            "isnull(a.st_ativomot, 'N')|=|'S'";
            string vColunas = "a.nm_clifor|Motorista|200;" +
                              "a.cd_clifor|Codigo|80";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { Cd_motorista },
                new CamadaDados.Financeiro.Cadastros.TCD_CadClifor(),
               vParam);
        }

        private void Cd_motorista_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_clifor|=|'" + Cd_motorista.Text.Trim() + "';" +
                            "isnull(a.st_motorista, 'N')|=|'S';" +
                            "isnull(a.st_ativomot, 'N')|=|'S'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { Cd_motorista },
                                            new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void bb_veiculo_Click(object sender, EventArgs e)
        {
            string vParam = "isnull(a.st_registro, 'A')|<>|'I'";
            string vColunas = "a.ds_veiculo|Veiculo|200;" +
                              "a.id_veiculo|Codigo|80;" +
                              "a.placa|Placa|80";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { Id_veiculo },
                new TCD_CadVeiculo(),
               vParam);
        }

        private void Id_veiculo_Leave(object sender, EventArgs e)
        {
            string vParam = "a.id_veiculo|=|'" + Id_veiculo.Text.Trim() + "';" +
                                "isnull(a.st_registro, 'A')|<>|'I'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { Id_veiculo },
                                            new TCD_CadVeiculo());
        }

        private void bsViagem_PositionChanged(object sender, EventArgs e)
        {
            if (bsViagem.Current != null)
            {   
                //Buscar Rota
                (bsViagem.Current as TRegistro_Viagem).lRota =
                    TCN_Viagem_X_Rota.BuscarRotas((bsViagem.Current as TRegistro_Viagem).Cd_empresa,
                                                                      (bsViagem.Current as TRegistro_Viagem).Id_viagemstr,
                                                                      null);

                //Buscar Frete
                (bsViagem.Current as TRegistro_Viagem).lFrete =
                    TCN_Viagem_X_Frete.BuscarCTRC((bsViagem.Current as TRegistro_Viagem).Cd_empresa,
                                                                      (bsViagem.Current as TRegistro_Viagem).Id_viagemstr,
                                                                      null);
                //Buscar Despesas
                (bsViagem.Current as TRegistro_Viagem).lDespesas =
                    TCN_DespesasViagem.Buscar(string.Empty,
                                                                  (bsViagem.Current as TRegistro_Viagem).Id_viagemstr,
                                                                  (bsViagem.Current as TRegistro_Viagem).Cd_empresa,
                                                                  string.Empty,
                                                                  string.Empty,
                                                                  string.Empty,
                                                                  null);
                //Buscar Adiantamentos
                (bsViagem.Current as TRegistro_Viagem).lAdto =
                    TCN_AdtoViagem.BuscarAdto((bsViagem.Current as TRegistro_Viagem).Cd_empresa,
                                                                  (bsViagem.Current as TRegistro_Viagem).Id_viagemstr,
                                                                  null);
                //Buscar Manutencao Veiculo Viagem
                (bsViagem.Current as TRegistro_Viagem).lManutencao =
                    TCN_ManutencaoVeiculo.Buscar(string.Empty,
                                                 string.Empty,
                                                 string.Empty,
                                                 (bsViagem.Current as TRegistro_Viagem).Id_viagemstr,
                                                 (bsViagem.Current as TRegistro_Viagem).Cd_empresa,
                                                 string.Empty,
                                                 string.Empty,
                                                 string.Empty,
                                                 string.Empty,
                                                 decimal.Zero,
                                                 decimal.Zero,
                                                 null);
                //Buscar Abastecimentos
                (bsViagem.Current as TRegistro_Viagem).lAbastecimentos =
                    TCN_AbastVeiculo.Buscar(string.Empty,
                                            (bsViagem.Current as TRegistro_Viagem).Cd_empresa,
                                            (bsViagem.Current as TRegistro_Viagem).Id_viagemstr,
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

                //Buscar Outras Receitas
                bsReceitas.DataSource =
                    TCN_OutrasReceitas.Buscar(string.Empty,
                                              (bsViagem.Current as TRegistro_Viagem).Cd_empresa,
                                              "(" + (bsViagem.Current as TRegistro_Viagem).Id_viagemstr + ")",
                                              string.Empty,
                                              string.Empty,
                                              string.Empty,
                                              string.Empty,
                                              string.Empty,
                                              false,
                                              null);
                //Buscar Acertos
                bsAcerto.DataSource = new TCD_AcertoMotorista().Select(
                        new Utils.TpBusca[]
                        {
                            new Utils.TpBusca()
                            {
                                vNM_Campo = string.Empty,
                                vOperador = "exists",
                                vVL_Busca = "(select 1 from TB_FRT_Acerto_X_Viagem x " +
                                            "where x.cd_empresa = a.cd_empresa " +
                                            "and x.id_acerto = a.id_acerto " +
                                            "and x.cd_empresa = '" + (bsViagem.Current as TRegistro_Viagem).Cd_empresa.Trim() + "'" +
                                            "and x.id_viagem = " + (bsViagem.Current as TRegistro_Viagem).Id_viagemstr + ") "
                            }
                        }, 0, string.Empty);

                //Totalizar Viagem
                tot_despesas.Value = (bsViagem.Current as TRegistro_Viagem).lDespesas.Sum(p => p.Vl_subtotal);
                tot_manutencao.Value = (bsViagem.Current as TRegistro_Viagem).lManutencao.Sum(p => p.Vl_realizada);
                tot_abastecimento.Value = (bsViagem.Current as TRegistro_Viagem).lAbastecimentos.Sum(p => p.Vl_subtotal);
                tot_adiantamento.Value = (bsViagem.Current as TRegistro_Viagem).lAdto.Sum(p => p.VL_total_quitado);
                tot_receitas.Value = (bsReceitas.List as TList_OutrasReceitas).Sum(p=> p.Vl_receita);
                tot_outrosAdto.Value = (bsReceitas.List as TList_OutrasReceitas).Sum(p => p.Sd_devadtoViagem);
                tot_comissao.Value = (bsReceitas.List as TList_OutrasReceitas).Sum(p => p.Vl_comissao) +
                                      (bsViagem.Current as TRegistro_Viagem).lFrete.Sum(p => p.Vl_comissao);
                tot_frete.Value = (bsViagem.Current as TRegistro_Viagem).lFrete.Sum(p => p.Vl_frete);
                bsViagem.ResetCurrentItem();
                bsDespesas_PositionChanged(this, new EventArgs());
            }
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

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            Close();
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
            else if (e.KeyCode.Equals(Keys.F10))
                IncluirDespesas();
            else if (e.KeyCode.Equals(Keys.F11))
                RequisicaoAbast();
            else if (e.KeyCode.Equals(Keys.F12))
                AcertoMotorista();
            else if (e.Control && tbRotaFrete.SelectedTab.Equals(tbFrete) && e.KeyCode.Equals(Keys.F10))
                InserirFrete();
            else if (e.Control && tbRotaFrete.SelectedTab.Equals(tbFrete) && e.KeyCode.Equals(Keys.F12))
                ExcluirFrete();
            else if (e.Control && e.KeyCode.Equals(Keys.P))
            {
                Altera_Relatorio = true;
                MessageBox.Show("Execute o relatório que deseja alterar!", "Mensagem");
            }
        }

        private void TFLanViagem_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gViagem);
            Utils.ShapeGrid.SaveShape(this, gRota);
            Utils.ShapeGrid.SaveShape(this, gCTRC);
        }

        private void gViagem_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
                if (e.ColumnIndex.Equals(0))
                {
                    if (e.Value.ToString().Trim().ToUpper().Equals("EXECUTANDO"))
                        gViagem.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Green;
                    else if (e.Value.ToString().Trim().ToUpper().Equals("FINALIZADA"))
                        gViagem.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Blue;
                    else if (e.Value.ToString().Trim().ToUpper().Equals("CANCELADA"))
                        gViagem.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
                    else gViagem.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                }
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

        private void bb_adto_Click(object sender, EventArgs e)
        {
            IncluirAdto();
        }

        private void bb_despesas_Click(object sender, EventArgs e)
        {
            IncluirDespesas();
        }

        private void bb_requisicao_Click(object sender, EventArgs e)
        {
            RequisicaoAbast();
        }

        private void bsDespesas_PositionChanged(object sender, EventArgs e)
        {
            if (bsDespesas.Current != null)
            {
                (bsDespesas.Current as TRegistro_DespesasViagem).lDup =
                    TCN_Despesa_X_Duplicata.BuscarDup((bsDespesas.Current as TRegistro_DespesasViagem).Id_landespesastr,
                                                                          (bsDespesas.Current as TRegistro_DespesasViagem).Cd_empresa,
                                                                          (bsDespesas.Current as TRegistro_DespesasViagem).Id_viagemstr,
                                                                          null);
                bsDespesas.ResetCurrentItem();
            }
        }

        private void bb_acerto_Click(object sender, EventArgs e)
        {
            AcertoMotorista();
        }

        private void bb_cte_Click(object sender, EventArgs e)
        {
            using (TFCTe fCte = new TFCTe())
            {
                if(bsViagem.Current != null)
                    if (!(bsViagem.Current as TRegistro_Viagem).St_viagem.Trim().Equals("C"))
                    {
                        fCte.pCd_empresa = (bsViagem.Current as TRegistro_Viagem).Cd_empresa;
                        fCte.pCd_motorista = (bsViagem.Current as TRegistro_Viagem).Cd_motorista;
                        fCte.pId_veiculo = (bsViagem.Current as TRegistro_Viagem).Id_veiculostr;
                        fCte.pId_viagem = (bsViagem.Current as TRegistro_Viagem).Id_viagemstr;
                    }
                if(fCte.ShowDialog() == DialogResult.OK)
                    if (fCte.rCte != null)
                    {
                        //Verificar se o CMI gera financeiro
                        CamadaDados.Fiscal.TList_CadCMI lCmi = CamadaNegocio.Fiscal.TCN_CadCMI.Busca(fCte.rCte.Cd_cmistr,
                                                                                                     string.Empty,
                                                                                                     string.Empty,
                                                                                                     string.Empty,
                                                                                                     string.Empty,
                                                                                                     string.Empty,
                                                                                                     false,
                                                                                                     false,
                                                                                                     false,
                                                                                                     false,
                                                                                                     false,
                                                                                                     false,
                                                                                                     false,
                                                                                                     null);
                        if(lCmi.Count > 0)
                            if (!string.IsNullOrEmpty(lCmi[0].Tp_duplicata))
                            {
                                using (Financeiro.TFLanDuplicata fDuplicata = new Financeiro.TFLanDuplicata())
                                {
                                    fDuplicata.vCd_empresa = fCte.rCte.Cd_empresa;
                                    fDuplicata.vNm_empresa = fCte.rCte.Nm_empresa;
                                    fDuplicata.vCd_clifor = fCte.rCte.Cd_remetente;
                                    fDuplicata.vNm_clifor = fCte.rCte.Nm_remetente;
                                    fDuplicata.vCd_endereco = fCte.rCte.Cd_endremetente;
                                    fDuplicata.vDs_endereco = fCte.rCte.Ds_endremetente;
                                    fDuplicata.vNr_docto = fCte.rCte.Nr_ctrcstr;
                                    fDuplicata.vDt_emissao = fCte.rCte.Dt_emissao.Value.ToString("dd/MM/yyyy");
                                    fDuplicata.vVl_documento = fCte.rCte.Vl_frete;
                                    fDuplicata.vTp_duplicata = lCmi[0].Tp_duplicata;
                                    fDuplicata.vDs_tpduplicata = lCmi[0].ds_tpduplicata;
                                    fDuplicata.vTp_mov = lCmi[0].Tp_movimento.Trim().ToUpper().Equals("E") ? "P" : "R";
                                    fDuplicata.vTp_docto = lCmi[0].Tp_doctostring;
                                    fDuplicata.vDs_tpdocto = lCmi[0].ds_tpdocto;
                                    fDuplicata.vCd_condpgto = lCmi[0].Cd_condpgto;
                                    fDuplicata.vDs_condpgto = lCmi[0].ds_condpgto;
                                    fDuplicata.vSt_ctrc = true;
                                    if (fDuplicata.ShowDialog() == DialogResult.OK)
                                        if (fDuplicata.dsDuplicata.Current != null)
                                        {
                                            fCte.rCte.rDuplicata =
                                                fDuplicata.dsDuplicata.Current as CamadaDados.Financeiro.Duplicata.TRegistro_LanDuplicata;
                                        }
                                        else
                                        {
                                            MessageBox.Show("Obrigatorio informar financeiro para gravar CTe.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            return;
                                        }
                                    else
                                    {
                                        MessageBox.Show("Obrigatorio informar financeiro para gravar CTe.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        return;
                                    }
                                }
                            }
                        try
                        {
                            CamadaNegocio.Faturamento.CTRC.TCN_ConhecimentoFrete.GravarCTe(fCte.rCte, false, null);
                            MessageBox.Show("CTe gravado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            TList_CfgFrota lCfg = TCN_CfgFrota.Buscar(fCte.rCte.Cd_empresa,
                                                                      string.Empty,
                                                                      string.Empty,
                                                                      string.Empty,
                                                                      null);
                            if (lCfg.Count > 0)
                                //Gerar e assinar Arquivos xml
                                try
                                {
                                    CTe.EnviaArq.TEnviaArq.EnviarLoteCte(new List<CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete>() { fCte.rCte }, lCfg[0]);
                                    MessageBox.Show("Lote CTe enviado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    //Consultar lote
                                    CTe.RetRecepcao.TRetRecepcao.ConsultaRetRecepcao(lCfg[0]);
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Erro enviar CTe: " + ex.Message);
                                }
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    }
            }
        }

        private void ts_btn_InserirFrete_Click(object sender, EventArgs e)
        {
            InserirFrete();
        }

        private void ts_btn_DeletarFrete_Click(object sender, EventArgs e)
        {
            ExcluirFrete();
        }

        private void bbInserirCotacao_Click(object sender, EventArgs e)
        {
            if (bsViagem.Current != null)
            {
                using (TFOutrasReceitas fReceita = new TFOutrasReceitas())
                {
                    fReceita.pCd_empresa = (bsViagem.Current as TRegistro_Viagem).Cd_empresa;
                    fReceita.pCd_motorista = (bsViagem.Current as TRegistro_Viagem).Cd_motorista;
                    fReceita.pId_Veiculo = (bsViagem.Current as TRegistro_Viagem).Id_veiculostr;
                    if (fReceita.ShowDialog() == DialogResult.OK)
                        if (fReceita.rReceita != null)
                            try
                            {
                                if (fReceita.vl_docto != decimal.Zero)
                             
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
                                fReceita.rReceita.Id_viagem = (bsViagem.Current as TRegistro_Viagem).Id_viagem;
                                TCN_OutrasReceitas.Gravar(fReceita.rReceita, null);
                                MessageBox.Show("Receita gravada com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                afterBusca();
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            }
        }

        private void bbExcluirCotacao_Click(object sender, EventArgs e)
        {
            if (bsViagem.Current != null)
                if (bsReceitas.Current != null)
                    if (MessageBox.Show("Confirma a exclusão da receita?", "Pergunta",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        try
                        {
                            TCN_OutrasReceitas.Excluir(bsReceitas.Current as TRegistro_OutrasReceitas, null);
                            MessageBox.Show("Receita excluída com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            afterBusca();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }


        private void afterDevolver()
        {
            if ((bsReceitas.Current as TRegistro_OutrasReceitas).Sd_devadtoViagem != decimal.Zero)
                using (TFDevolucaoOutrasReceitas fdevolucao = new TFDevolucaoOutrasReceitas())
                {
                    fdevolucao.preenche();
                    fdevolucao.vl_adtoViagem = (bsReceitas.Current as TRegistro_OutrasReceitas).Vl_adtoViagem;
                    if (fdevolucao.ShowDialog() == DialogResult.OK)
                        if (fdevolucao.rLancaixa != null)
                        {
                            CamadaNegocio.Financeiro.Caixa.TCN_LanCaixa.GravaLanCaixa(fdevolucao.rLancaixa, null);
                            TRegistro_DevOutrasReceitas rdevolucao = new TRegistro_DevOutrasReceitas();
                            rdevolucao.cd_contager = fdevolucao.rLancaixa.Cd_ContaGer;
                            rdevolucao.Id_lanctoCaixa = fdevolucao.rLancaixa.Cd_LanctoCaixa;
                            rdevolucao.Id_receita = (bsReceitas.Current as TRegistro_OutrasReceitas).Id_receita;
                            TCN_DevOutrasReceitas.Gravar(rdevolucao, null);
							afterBusca();
							ImprimirDev(fdevolucao.rLancaixa.Vl_RECEBER, rdevolucao.cd_contager, fdevolucao.rLancaixa);
                        }						
                }
            else
                MessageBox.Show("Não há saldo devedor!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Devolver_Click(object sender, EventArgs e)
        {
            afterDevolver();
        }

        private void bb_ImprimirAcerto_Click(object sender, EventArgs e)
        {
            ImprimirAcerto(bsAcerto.Current as TRegistro_AcertoMotorista);
        }
    }
}
