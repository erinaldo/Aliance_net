using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using FormBusca;
using CamadaDados.PostoCombustivel;
using CamadaNegocio.PostoCombustivel;

namespace PostoCombustivel
{
    public partial class TFLanConvenio : Form
    {
        public TFLanConvenio()
        {
            InitializeComponent();
        }

        private void LimparFiltros()
        {
            id_convenio.Clear();
            cd_cond.Clear();
            cd_empresa.Clear();
            tp_doc.Clear();
            tp_dup.Clear();
            portador.Clear();
            cbAtivo.Checked = true;
            cbEncerrado.Checked = false;
            DT_Final.Clear();
            DT_Inicial.Clear();
            DS_convenio.Clear();
        }

        private void afterNovo()
        {
            using (TFConvenio fConvenio = new TFConvenio())
            {
                if (fConvenio.ShowDialog() == DialogResult.OK)
                    if (fConvenio.rConvenio != null)
                        try
                        {
                            TCN_Convenio.Gravar(fConvenio.rConvenio, null);
                            MessageBox.Show("Convenio gravado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LimparFiltros();
                            cd_empresa.Text = fConvenio.rConvenio.Cd_empresa;
                            id_convenio.Text = fConvenio.rConvenio.Id_conveniostr;
                            afterBusca();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void afterAltera()
        {
            if (bsConvenio.Current != null)
                using (TFAlterarConvenio fAlt = new TFAlterarConvenio())
                {
                    fAlt.rConvenio = bsConvenio.Current as TRegistro_Convenio;
                    if (fAlt.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            TCN_Convenio.Alterar(fAlt.rConvenio, null);
                            MessageBox.Show("Convenio alterado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    }
                    LimparFiltros();
                    cd_empresa.Text = (bsConvenio.Current as TRegistro_Convenio).Cd_empresa;
                    id_convenio.Text = (bsConvenio.Current as TRegistro_Convenio).Id_conveniostr;
                    afterBusca();
                }
        }

        private void afterExclui()
        {
            if (bsConvenio.Current != null)
                if (MessageBox.Show("Confirma exclusão do convenio selecionado?", "Pergunta",
                     MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    try
                    {
                        TCN_Convenio.Excluir(bsConvenio.Current as TRegistro_Convenio, null);
                        MessageBox.Show("Convenio excluido com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LimparFiltros();
                        afterBusca();
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void afterBusca()
        {
            string status = string.Empty;
            string virg = string.Empty;
            if (cbAtivo.Checked)
            {
                status = "'A'";
                virg = ",";
            }
            if (cbEncerrado.Checked)
                status += virg + "'E'";
            bsConvenio.DataSource = TCN_Convenio.Buscar(id_convenio.Text,
                                                        cd_empresa.Text,
                                                        cd_cond.Text,
                                                        tp_dup.Text,
                                                        tp_doc.Text,
                                                        portador.Text,
                                                        cd_clifor.Text,
                                                        cd_produto.Text,
                                                        DT_Inicial.Text,
                                                        DT_Final.Text,
                                                        status,
                                                        st_valorFixo.Checked,
                                                        DS_convenio.Text,
                                                        cd_vend.Text,
                                                        null);
            bsConvenio_PositionChanged(this, new EventArgs());
        }

        private void InserirClifor()
        {
            if (bsConvenio.Current != null)
                using (TFCliforConvenio fClifor = new TFCliforConvenio())
                {
                    fClifor.pCd_empresa = (bsConvenio.Current as TRegistro_Convenio).Cd_empresa;
                    fClifor.tipo_insercaounica = false;
                    if (fClifor.ShowDialog() == DialogResult.OK)
                        #region Inserção unica
                        if ((fClifor.rClifor != null) && (fClifor.lCombustivel != null) && !string.IsNullOrEmpty(fClifor.rClifor.Cd_clifor))
                        {
                            TList_Convenio_Clifor lConv = new TList_Convenio_Clifor();
                            fClifor.lCombustivel.ForEach(p =>
                            {
                                lConv.Add(
                                        new TRegistro_Convenio_Clifor()
                                        {
                                            Cd_clifor = fClifor.rClifor.Cd_clifor,
                                            Cd_endereco = fClifor.rClifor.Cd_endereco,
                                            Cd_empresa = (bsConvenio.Current as TRegistro_Convenio).Cd_empresa,
                                            Cd_produto = p.CD_Produto,
                                            Id_convenio = (bsConvenio.Current as TRegistro_Convenio).Id_convenio,
                                            lMotorista = fClifor.rClifor.lMotorista,
                                            lPlaca = fClifor.rClifor.lPlaca,
                                            St_faturardireto = fClifor.rClifor.St_faturardireto,
                                            St_motconveniado = fClifor.rClifor.St_motconveniado,
                                            St_placaconveniada = fClifor.rClifor.St_placaconveniada,
                                            St_registro = fClifor.rClifor.St_registro,
                                            Vl_unitario = fClifor.rClifor.Vl_unitario,
                                            CD_vendedor = fClifor.rClifor.CD_vendedor,
                                            Id_config = fClifor.rClifor.Id_config,
                                            Qtd_convenio = fClifor.rClifor.Qtd_convenio,
                                            Tp_preco = fClifor.rClifor.Tp_preco,
                                            Tp_faturamento = fClifor.rClifor.Tp_faturamento,
                                            St_exigirrequisicao = fClifor.rClifor.St_exigirrequisicao,
                                            St_exigirnomemot = fClifor.rClifor.St_exigirnomemot,
                                            Tp_qt_vl = fClifor.rClifor.Tp_qt_vl,
                                            Base_calc_fid = fClifor.rClifor.Base_calc_fid,
                                            Qt_pontos_fid = fClifor.rClifor.Qt_pontos_fid,
                                            Nr_diasvalidade_fid = fClifor.rClifor.Nr_diasvalidade_fid,
                                            Tp_pontos_fid = fClifor.rClifor.Tp_pontos_fid,
                                            Ds_msgVale = fClifor.rClifor.Ds_msgVale
                                        });
                            });
                            try
                            {
                                TCN_Convenio_Clifor.Gravar(lConv, null);
                                MessageBox.Show("Cliente gravado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LimparFiltros();
                                id_convenio.Text = (bsConvenio.Current as TRegistro_Convenio).Id_conveniostr;
                                cd_empresa.Text = (bsConvenio.Current as TRegistro_Convenio).Cd_empresa;
                                afterBusca();
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                        }
                        #endregion
                        #region Inserção composta
                        else if (fClifor.lClifor != null && fClifor.lCombustivel != null
                                    && fClifor.lClifor.Count > 0 && fClifor.lCombustivel.Count > 0)
                        {
                            TList_Convenio_Clifor lConv = new TList_Convenio_Clifor();
                            fClifor.lClifor.ForEach(c =>
                            {
                                fClifor.lCombustivel.ForEach(p =>
                                {
                                    lConv.Add(
                                            new TRegistro_Convenio_Clifor()
                                            {
                                                Cd_clifor = c.Cd_clifor.ToString().Trim(),
                                                Cd_endereco = new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco().BuscarEscalar(
                                                    new Utils.TpBusca[]
                                                    {
                                                        new Utils.TpBusca()
                                                        {
                                                            vNM_Campo = "a.cd_clifor",
                                                            vOperador = "=",
                                                            vVL_Busca = "'" + c.Cd_clifor.ToString().Trim() + "'"
                                                        }
                                                    }, "a.cd_endereco").ToString(),
                                                Cd_empresa = (bsConvenio.Current as TRegistro_Convenio).Cd_empresa,
                                                Cd_produto = p.CD_Produto,
                                                Id_convenio = (bsConvenio.Current as TRegistro_Convenio).Id_convenio,
                                                St_faturardireto = fClifor.rClifor.St_faturardireto,
                                                St_motconveniado = fClifor.rClifor.St_motconveniado,
                                                St_placaconveniada = fClifor.rClifor.St_placaconveniada,
                                                St_registro = fClifor.rClifor.St_registro,
                                                Vl_unitario = fClifor.rClifor.Vl_unitario,
                                                CD_vendedor = fClifor.rClifor.CD_vendedor,
                                                Id_config = fClifor.rClifor.Id_config,
                                                Qtd_convenio = fClifor.rClifor.Qtd_convenio,
                                                Tp_preco = fClifor.rClifor.Tp_preco,
                                                Tp_faturamento = fClifor.rClifor.Tp_faturamento,
                                                St_exigirrequisicao = fClifor.rClifor.St_exigirrequisicao,
                                                St_exigirnomemot = fClifor.rClifor.St_exigirnomemot,
                                                Tp_qt_vl = fClifor.rClifor.Tp_qt_vl,
                                                Base_calc_fid = fClifor.rClifor.Base_calc_fid,
                                                Qt_pontos_fid = fClifor.rClifor.Qt_pontos_fid,
                                                Nr_diasvalidade_fid = fClifor.rClifor.Nr_diasvalidade_fid,
                                                Tp_pontos_fid = fClifor.rClifor.Tp_pontos_fid,
                                                Ds_msgVale = fClifor.rClifor.Ds_msgVale
                                            });
                                });
                            });
                            try
                            {
                                TCN_Convenio_Clifor.Gravar(lConv, null);
                                MessageBox.Show("Clientes gravados com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LimparFiltros();
                                id_convenio.Text = (bsConvenio.Current as TRegistro_Convenio).Id_conveniostr;
                                cd_empresa.Text = (bsConvenio.Current as TRegistro_Convenio).Cd_empresa;
                                afterBusca();
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                        }
                    #endregion
                }
        }

        private void AlterarClifor()
        {
            if (bsConvenioClifor.Current != null)
                using (TFCliforConvenio fClifor = new TFCliforConvenio())
                {
                    fClifor.pCd_empresa = (bsConvenioClifor.Current as TRegistro_Convenio_Clifor).Cd_empresa;
                    fClifor.rClifor = bsConvenioClifor.Current as TRegistro_Convenio_Clifor;
                    if (fClifor.ShowDialog() == DialogResult.OK)
                        try
                        {
                            TCN_Convenio_Clifor.Gravar(fClifor.rClifor, null);
                            MessageBox.Show("Cliente alterado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    LimparFiltros();
                    id_convenio.Text = (bsConvenioClifor.Current as TRegistro_Convenio_Clifor).Id_conveniostr;
                    cd_empresa.Text = (bsConvenioClifor.Current as TRegistro_Convenio_Clifor).Cd_empresa;
                    afterBusca();
                }
        }

        private void ExcluirClifor()
        {
            if (bsConvenioClifor.Current != null)
                if (MessageBox.Show("Confirma exclusão do cliente?", "Pergunta", MessageBoxButtons.YesNo,
                     MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    try
                    {
                        TCN_Convenio_Clifor.Excluir(bsConvenioClifor.Current as TRegistro_Convenio_Clifor, null);
                        MessageBox.Show("Cliente excluido do convenio com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LimparFiltros();
                        id_convenio.Text = (bsConvenioClifor.Current as TRegistro_Convenio_Clifor).Id_conveniostr;
                        cd_empresa.Text = (bsConvenioClifor.Current as TRegistro_Convenio_Clifor).Cd_empresa;
                        afterBusca();
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void InserirPlaca()
        {
            if (bsConvenioClifor.Current != null)
                using (TFPlacaConvenio fPlaca = new TFPlacaConvenio())
                {
                    if (fPlaca.ShowDialog() == DialogResult.OK)
                        if (fPlaca.rPlaca != null)
                        {
                            fPlaca.rPlaca.Id_convenio = (bsConvenioClifor.Current as TRegistro_Convenio_Clifor).Id_convenio;
                            fPlaca.rPlaca.Cd_empresa = (bsConvenioClifor.Current as TRegistro_Convenio_Clifor).Cd_empresa;
                            fPlaca.rPlaca.Cd_clifor = (bsConvenioClifor.Current as TRegistro_Convenio_Clifor).Cd_clifor;
                            fPlaca.rPlaca.Cd_endereco = (bsConvenioClifor.Current as TRegistro_Convenio_Clifor).Cd_endereco;
                            fPlaca.rPlaca.Cd_produto = (bsConvenioClifor.Current as TRegistro_Convenio_Clifor).Cd_produto;
                            try
                            {
                                TCN_Convenio_Placa.Gravar(fPlaca.rPlaca, null);
                                MessageBox.Show("Placa gravada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                bsConvenioClifor_PositionChanged(this, new EventArgs());
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                        }
                }
        }

        private void AlterarPlaca()
        {
            if (bsPlacaVeiculo.Current != null)
                using (TFPlacaConvenio fPlaca = new TFPlacaConvenio())
                {
                    string ds_veiculo = (bsPlacaVeiculo.Current as TRegistro_Convenio_Placa).Ds_veiculo;
                    string st_km = (bsPlacaVeiculo.Current as TRegistro_Convenio_Placa).St_km;
                    string st_diautil = (bsPlacaVeiculo.Current as TRegistro_Convenio_Placa).St_diasuteis;
                    string ds_obs = (bsPlacaVeiculo.Current as TRegistro_Convenio_Placa).Ds_observacao;

                    fPlaca.rPlaca = bsPlacaVeiculo.Current as TRegistro_Convenio_Placa;
                    if (fPlaca.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            TCN_Convenio_Placa.Gravar(fPlaca.rPlaca, null);
                            MessageBox.Show("Placa alterada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            bsConvenioClifor_PositionChanged(this, new EventArgs());
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    }
                }
        }

        private void ExcluirPlaca()
        {
            if (bsPlacaVeiculo.Current != null)
                if (MessageBox.Show("Confirma exclusão do registro selecionado?", "Pergunta", MessageBoxButtons.YesNo,
                     MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    try
                    {
                        TCN_Convenio_Placa.Excluir(bsPlacaVeiculo.Current as TRegistro_Convenio_Placa, null);
                        MessageBox.Show("Placa excluida com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        bsPlacaVeiculo.RemoveCurrent();
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
        }

        private void InserirMotorista()
        {
            if (bsConvenioClifor.Current != null)
                using (TFMotoristaConvenio fMot = new TFMotoristaConvenio())
                {
                    if (fMot.ShowDialog() == DialogResult.OK)
                        if (fMot.rMot != null)
                        {
                            fMot.rMot.Id_convenio = (bsConvenioClifor.Current as TRegistro_Convenio_Clifor).Id_convenio;
                            fMot.rMot.Cd_empresa = (bsConvenioClifor.Current as TRegistro_Convenio_Clifor).Cd_empresa;
                            fMot.rMot.Cd_clifor = (bsConvenioClifor.Current as TRegistro_Convenio_Clifor).Cd_clifor;
                            fMot.rMot.Cd_endereco = (bsConvenioClifor.Current as TRegistro_Convenio_Clifor).Cd_endereco;
                            fMot.rMot.Cd_produto = (bsConvenioClifor.Current as TRegistro_Convenio_Clifor).Cd_produto;
                            try
                            {
                                TCN_Motorista_Convenio.Gravar(fMot.rMot, null);
                                MessageBox.Show("Motorista gravado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                bsConvenioClifor_PositionChanged(this, new EventArgs());
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                        }
                }
        }

        private void ExcluirMotorista()
        {
            if (bsMotorista.Current != null)
                if (MessageBox.Show("Confirma exclusão do registro selecionado?", "Pergunta", MessageBoxButtons.YesNo,
                     MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    try
                    {
                        TCN_Motorista_Convenio.Excluir(bsMotorista.Current as TRegistro_Convenio_Motorista, null);
                        MessageBox.Show("Motorista excluido com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        bsMotorista.RemoveCurrent();
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
        }

        private void AtualizarPrecoUnit()
        {
            using (TFAtualizaPrecoUnitConv fAtualiza = new TFAtualizaPrecoUnitConv())
            {
                if (fAtualiza.ShowDialog() == DialogResult.OK)
                    if (fAtualiza.lConvCli != null)
                        try
                        {
                            TCN_Convenio_Clifor.Gravar(fAtualiza.lConvCli, null);
                            MessageBox.Show("Convenios atualizados com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void TFLanConvenio_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gridConvenio);
            Utils.ShapeGrid.RestoreShape(this, gConvenioClifor);
            Utils.ShapeGrid.RestoreShape(this, gPlaca);
            Utils.ShapeGrid.RestoreShape(this, gMotorista);
            Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pFiltro.set_FormatZero();
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            afterBusca();
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

        private void bsConvenio_PositionChanged(object sender, EventArgs e)
        {
            if (bsConvenio.Current != null)
            {
                (bsConvenio.Current as TRegistro_Convenio).lClifor =
                    TCN_Convenio_Clifor.Buscar((bsConvenio.Current as TRegistro_Convenio).Id_conveniostr,
                                               (bsConvenio.Current as TRegistro_Convenio).Cd_empresa,
                                               cd_clifor.Text,
                                               cd_endereco.Text,
                                               cd_produto.Text,
                                               null);
                bsConvenio.ResetCurrentItem();
                bsConvenioClifor_PositionChanged(this, new EventArgs());
            }
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            Close();
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

        private void TFLanConvenio_KeyDown(object sender, KeyEventArgs e)
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
                AtualizarPrecoUnit();
            else if (e.Control && e.KeyCode.Equals(Keys.F10))
                InserirClifor();
            else if (e.Control && e.KeyCode.Equals(Keys.F11))
                AlterarClifor();
            else if (e.Control && e.KeyCode.Equals(Keys.F12))
                ExcluirClifor();
        }

        private void gConvenio_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((e.Value != null) && (e.ColumnIndex == 0))
                if (e.Value.ToString().Trim().ToUpper().Equals("ENCERRADO"))
                    gConvenio.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Blue;
                else if (e.Value.ToString().Trim().ToUpper().Equals("EXPIRADO"))
                    gConvenio.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
                else
                    gConvenio.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
        }

        private void bb_cond_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_condpgto|Condição Pagamento|200;" +
                              "a.cd_condpgto|Cd. CondPgto|80";
            string vParam = "a.qt_parcelas|=|1";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_cond },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadCondPgto(), vParam);
        }

        private void cd_cond_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_condpgto|=|'" + cd_cond.Text.Trim() + "';" +
                            "a.qt_parcelas|=|1";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_cond },
                                            new CamadaDados.Financeiro.Cadastros.TCD_CadCondPgto());
        }

        private void bb_dup_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_tpduplicata|Tipo Duplicata|200;" +
                              "a.tp_duplicata|TP. Duplicata|80";
            string vParam = "a.tp_mov|=|'R'";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { tp_dup },
                                        new CamadaDados.Financeiro.Cadastros.TCD_CadTpDuplicata(), vParam);
        }

        private void tp_dup_Leave(object sender, EventArgs e)
        {
            string vParam = "a.tp_duplicata|=|'" + tp_dup.Text.Trim() + "';" +
                            "a.tp_mov|=|'R'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { tp_dup },
                                        new CamadaDados.Financeiro.Cadastros.TCD_CadTpDuplicata());
        }

        private void bb_docto_Click(object sender, EventArgs e)
        {
            string vParam = "a.ds_tpdocto|Tipo Documento|200;" +
                            "a.tp_docto|TP. Docto|80";
            FormBusca.UtilPesquisa.BTN_BUSCA(vParam, new Componentes.EditDefault[] { tp_doc },
                                            new CamadaDados.Financeiro.Cadastros.TCD_CadTpDoctoDup(), string.Empty);
        }

        private void tp_doc_Leave(object sender, EventArgs e)
        {
            string vParam = "a.tp_docto|=|" + tp_doc.Text;
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { tp_doc },
                                            new CamadaDados.Financeiro.Cadastros.TCD_CadTpDoctoDup());
        }

        private void bb_portador_Click(object sender, EventArgs e)
        {
            string vColunas = "ds_portador|Portador|200;" +
                              "cd_portador|Cd. Portador|80";
            string vParam = "TP_PortadorPDV|is not|null";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { portador },
                                            new CamadaDados.Financeiro.Cadastros.TCD_CadPortador(), vParam);
        }

        private void portador_Leave(object sender, EventArgs e)
        {
            string vparam = "a.cd_portador|=|'" + portador.Text.Trim() + "';" +
                            "TP_PortadorPDV|is not|null";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vparam, new Componentes.EditDefault[] { portador },
                                                new CamadaDados.Financeiro.Cadastros.TCD_CadPortador());
        }

        private void bsConvenioClifor_PositionChanged(object sender, EventArgs e)
        {
            if (bsConvenioClifor.Current != null)
            {
                //Buscar placas
                (bsConvenioClifor.Current as TRegistro_Convenio_Clifor).lPlaca =
                    TCN_Convenio_Placa.Buscar((bsConvenioClifor.Current as TRegistro_Convenio_Clifor).Id_conveniostr,
                                                                             (bsConvenioClifor.Current as TRegistro_Convenio_Clifor).Cd_empresa,
                                                                             (bsConvenioClifor.Current as TRegistro_Convenio_Clifor).Cd_clifor,
                                                                             (bsConvenioClifor.Current as TRegistro_Convenio_Clifor).Cd_endereco,
                                                                             (bsConvenioClifor.Current as TRegistro_Convenio_Clifor).Cd_produto,
                                                                             null);
                //Buscar motoristas
                (bsConvenioClifor.Current as TRegistro_Convenio_Clifor).lMotorista =
                    TCN_Motorista_Convenio.Buscar((bsConvenioClifor.Current as TRegistro_Convenio_Clifor).Id_conveniostr,
                                                                                 (bsConvenioClifor.Current as TRegistro_Convenio_Clifor).Cd_empresa,
                                                                                 (bsConvenioClifor.Current as TRegistro_Convenio_Clifor).Cd_clifor,
                                                                                 (bsConvenioClifor.Current as TRegistro_Convenio_Clifor).Cd_endereco,
                                                                                 (bsConvenioClifor.Current as TRegistro_Convenio_Clifor).Cd_produto,
                                                                                 string.Empty,
                                                                                 string.Empty,
                                                                                 string.Empty,
                                                                                 null);
                bsConvenioClifor.ResetCurrentItem();
            }
        }

        private void bb_clifor_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_clifor }, string.Empty);
        }

        private void cd_clifor_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + cd_clifor.Text.Trim() + "'",
                                          new Componentes.EditDefault[] { cd_clifor },
                                          new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void bb_produto_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaProduto(new Componentes.EditDefault[] { cd_produto }, "isnull(e.st_combustivel, 'N')|=|'S'");
        }

        private void cd_produto_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVEProduto("a.cd_produto|=|'" + cd_produto.Text.Trim() + "';isnull(e.st_combustivel, 'N')|=|'S'",
                                            new Componentes.EditDefault[] { cd_produto },
                                            new CamadaDados.Estoque.Cadastros.TCD_CadProduto());
        }

        private void gridConvenio_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
                if (e.ColumnIndex == 0)
                    if (e.Value.ToString().Trim().ToUpper().Equals("ENCERRADO"))
                        gridConvenio.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Maroon;
                    else
                        gridConvenio.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
        }

        private void btn_Deleta_Item_Click(object sender, EventArgs e)
        {
            ExcluirClifor();
        }

        private void btn_Inserir_Item_Click(object sender, EventArgs e)
        {
            InserirClifor();
        }

        private void BB_Alterar_Item_Click(object sender, EventArgs e)
        {
            AlterarClifor();
        }

        private void gridConvenio_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gridConvenio.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsConvenio.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new TRegistro_Convenio());
            TList_Convenio lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gridConvenio.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gridConvenio.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new TList_Convenio(lP.Find(gridConvenio.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gridConvenio.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new TList_Convenio(lP.Find(gridConvenio.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gridConvenio.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsConvenio.List as TList_Convenio).Sort(lComparer);
            bsConvenio.ResetBindings(false);
            gridConvenio.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void gConvenioClifor_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gConvenioClifor.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsConvenioClifor.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new TRegistro_Convenio_Clifor());
            TList_Convenio_Clifor lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gConvenioClifor.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gConvenioClifor.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new TList_Convenio_Clifor(lP.Find(gConvenioClifor.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gConvenioClifor.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new TList_Convenio_Clifor(lP.Find(gConvenioClifor.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gConvenioClifor.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsConvenioClifor.List as TList_Convenio_Clifor).Sort(lComparer);
            bsConvenioClifor.ResetBindings(false);
            gConvenioClifor.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void gPlaca_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gPlaca.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsPlacaVeiculo.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new TRegistro_Convenio_Placa());
            TList_Convenio_Placa lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gPlaca.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gPlaca.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new TList_Convenio_Placa(lP.Find(gPlaca.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gPlaca.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new TList_Convenio_Placa(lP.Find(gPlaca.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gPlaca.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsPlacaVeiculo.List as TList_Convenio_Placa).Sort(lComparer);
            bsPlacaVeiculo.ResetBindings(false);
            gPlaca.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void gMotorista_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gMotorista.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsMotorista.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new TRegistro_Convenio_Motorista());
            TList_convenio_Motorista lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gMotorista.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gMotorista.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new TList_convenio_Motorista(lP.Find(gMotorista.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gMotorista.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new TList_convenio_Motorista(lP.Find(gMotorista.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gMotorista.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsMotorista.List as TList_convenio_Motorista).Sort(lComparer);
            bsMotorista.ResetBindings(false);
            gMotorista.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void TFLanConvenio_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gridConvenio);
            Utils.ShapeGrid.SaveShape(this, gConvenioClifor);
            Utils.ShapeGrid.SaveShape(this, gPlaca);
            Utils.ShapeGrid.SaveShape(this, gMotorista);
        }

        private void bb_atualizaPrecoUnit_Click(object sender, EventArgs e)
        {
            AtualizarPrecoUnit();
        }

        private void bb_inserirPlaca_Click(object sender, EventArgs e)
        {
            InserirPlaca();
        }

        private void bb_alterarPlaca_Click(object sender, EventArgs e)
        {
            AlterarPlaca();
        }

        private void bb_excluirPlaca_Click(object sender, EventArgs e)
        {
            ExcluirPlaca();
        }

        private void bb_inserirMot_Click(object sender, EventArgs e)
        {
            InserirMotorista();
        }

        private void bb_excluirMot_Click(object sender, EventArgs e)
        {
            ExcluirMotorista();
        }

        private void bb_importPlaca_Click(object sender, EventArgs e)
        {
            if (bsConvenioClifor.Current != null)
                using (TFImportPlaca fLista = new TFImportPlaca())
                {
                    fLista.pCd_empresa = (bsConvenioClifor.Current as TRegistro_Convenio_Clifor).Cd_empresa;
                    fLista.pCd_clifor = (bsConvenioClifor.Current as TRegistro_Convenio_Clifor).Cd_clifor;
                    if (fLista.ShowDialog() == DialogResult.OK)
                        if (fLista.lPlaca != null)
                            try
                            {
                                fLista.lPlaca.ForEach(p =>
                                    {
                                        p.Id_convenio = (bsConvenioClifor.Current as TRegistro_Convenio_Clifor).Id_convenio;
                                        p.Cd_empresa = (bsConvenioClifor.Current as TRegistro_Convenio_Clifor).Cd_empresa;
                                        p.Cd_clifor = (bsConvenioClifor.Current as TRegistro_Convenio_Clifor).Cd_clifor;
                                        p.Cd_endereco = (bsConvenioClifor.Current as TRegistro_Convenio_Clifor).Cd_endereco;
                                        p.Cd_produto = (bsConvenioClifor.Current as TRegistro_Convenio_Clifor).Cd_produto;
                                    });
                                TCN_Convenio_Placa.Gravar(fLista.lPlaca, null);
                                MessageBox.Show("Placas gravadas com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                bsConvenioClifor_PositionChanged(this, new EventArgs());
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
        }

        private void bb_vendedor_Click(object sender, EventArgs e)
        {
            string vColunas = "a.nm_clifor|Nome Vendedor|200;" +
                              "a.cd_clifor|Cd. Vendedor|80";
            string vParam = "isnull(a.st_vendedor, 'N')|=|'S';" +
                            "isnull(a.st_funcativo, 'N')|=|'S'";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_vend },
                new CamadaDados.Financeiro.Cadastros.TCD_CadClifor(),
               vParam);
        }

        private void cd_vend_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_clifor|=|'" + cd_vend.Text.Trim() + "';" +
                            "isnull(a.st_vendedor, 'N')|=|'S';" +
                            "isnull(a.st_funcativo, 'N')|=|'S'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_vend },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void gridConvenio_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }
    }
}
