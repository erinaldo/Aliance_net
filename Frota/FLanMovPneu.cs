using Almoxarifado;
using CamadaDados.Almoxarifado;
using CamadaDados.Frota.Cadastros;
using CamadaNegocio.Frota.Cadastros;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utils;

namespace Frota
{
    public partial class TFLanMovPneu : Form
    {
        public TFLanMovPneu()
        {
            InitializeComponent();
        }

        private void LimparFiltros()
        {
            nr_serie.Text = string.Empty;
            id_veiculo.Text = string.Empty;
            id_rodado.Text = string.Empty;
            rbTodos.Checked = true;
        }

        private void afterBusca()
        {
            string cond = string.Empty;
            string virg = string.Empty;
            if (rbAlmoxarifado.Checked)
            {
                cond = "'A'";
                virg = ",";
            }
            if (rbRodando.Checked)
            {
                cond += virg + "'R'";
                virg = ",";
            }
            if (rbDesativado.Checked)
            {
                cond += virg + "'D'";
                virg = ",";
            }
            if (rbManutencao.Checked)
                cond += virg + "'M'";

            bsPneus.DataSource = TCN_LanPneu.Buscar(cbEmpresa.SelectedValue != null ?
                                                    cbEmpresa.SelectedValue.ToString() : string.Empty,
                                                    string.Empty,
                                                    nr_serie.Text.SoNumero(),
                                                    id_rodado.Text,
                                                    cond,
                                                    null);
            if (!string.IsNullOrEmpty(id_veiculo.Text.SoNumero()))
                bsPneus.DataSource = (bsPneus.DataSource as IEnumerable<TRegistro_LanPneu>).ToList().FindAll(x => x.Id_veiculo.Equals(id_veiculo.Text.SoNumero()));
            if (!string.IsNullOrEmpty(nr_placa.Text.Trim()))
                bsPneus.DataSource = (bsPneus.DataSource as IEnumerable<TRegistro_LanPneu>).ToList().FindAll(x => x.Placa.Equals(nr_placa.Text));
            bsPneus.ResetCurrentItem();
            bsPneus_PositionChanged(this, new EventArgs());
        }

        private void gerarMovimentacao()
        {
            if (bsPneus.Current == null)
                return;
            else if (!(bsPneus.Current as TRegistro_LanPneu).Status.Equals("ALMOXARIFADO") && !(bsPneus.Current as TRegistro_LanPneu).Status.Equals("RODANDO"))
            {
                MessageBox.Show("É possível realizar movimentação apenas de pneus com o status ALMOXARIFADO e RODANDO.", "Informativo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (TFMovPneu fMovPneu = new TFMovPneu())
            {
                fMovPneu.pCd_empresa = cbEmpresa.SelectedValue != null ? cbEmpresa.SelectedValue.ToString() : string.Empty;
                fMovPneu.pId_veiculo = string.IsNullOrEmpty((bsPneus.Current as TRegistro_LanPneu).Id_veiculo) ? string.Empty : (bsPneus.Current as TRegistro_LanPneu).Id_veiculo;
                fMovPneu.pId_pneu = (bsPneus.Current as TRegistro_LanPneu).Id_pneustr;
                fMovPneu.ShowDialog();
            }

            afterBusca();
        }

        private void TFLanMovPneu_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pConsulta.set_FormatZero();
            //Buscar Empresa
            cbEmpresa.DataSource = new CamadaDados.Diversos.TCD_CadEmpresa().Select(
                                    new Utils.TpBusca[]
                                    {
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = string.Empty,
                                            vOperador = "exists",
                                            vVL_Busca = "(select 1 from tb_div_usuario_x_empresa x " +
                                                        "where x.cd_empresa = a.cd_empresa " +
                                                        "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                                        "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                                        "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))"
                                        }
                                    }, 0, string.Empty);
            cbEmpresa.DisplayMember = "NM_Empresa";
            cbEmpresa.ValueMember = "CD_Empresa";
        }

        private void btn_manutencao_Click(object sender, EventArgs e)
        {
            if (bsPneus.Current != null)
            {
                if ((bsPneus.Current as TRegistro_LanPneu).St_registro.ToUpper().Equals("M"))
                {
                    MessageBox.Show("Pneu já se encontra em MANUTENÇÃO!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else if ((bsPneus.Current as TRegistro_LanPneu).St_registro.ToUpper().Equals("R"))
                {
                    int hodometro = 0;
                    using (Componentes.TFQuantidade fQtde = new Componentes.TFQuantidade())
                    {
                        fQtde.Ds_label = "Hodometro final";
                        TpBusca[] tpBuscas = new TpBusca[0];
                        Estruturas.CriarParametro(ref tpBuscas, "a.cd_empresa", (bsPneus.Current as TRegistro_LanPneu).Cd_empresa);
                        Estruturas.CriarParametro(ref tpBuscas, "a.id_pneu", (bsPneus.Current as TRegistro_LanPneu).Id_pneustr);
                        Estruturas.CriarParametro(ref tpBuscas, "a.id_veiculo", (bsPneus.Current as TRegistro_LanPneu).Id_veiculo);
                        Estruturas.CriarParametro(ref tpBuscas, "a.id_rodado", (bsPneus.Current as TRegistro_LanPneu).Id_rodado);
                        fQtde.Vl_default = Convert.ToDecimal(new CamadaDados.Frota.TCD_MovPneu().BuscarEscalar(tpBuscas, "a.hodometro", "id_mov desc").ToString());
                        fQtde.Vl_Minimo = fQtde.Vl_default;
                        fQtde.Casas_decimais = 0;
                        fQtde.St_permitirValorZero = false;
                        if (fQtde.ShowDialog() == DialogResult.OK)
                            hodometro = Convert.ToInt32(fQtde.Quantidade);
                        else
                        {
                            MessageBox.Show("Obrigatório informar hodometro para desativação!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                    TCN_LanPneu.EnvioAlmoxarifado(bsPneus.Current as TRegistro_LanPneu, hodometro, null);
                }

                try
                {
                    using (TFDadosMovPneu fDadosMovPneu = new TFDadosMovPneu())
                    {
                        if (fDadosMovPneu.ShowDialog() == DialogResult.OK)
                            if (fDadosMovPneu.rMovPneu != null)
                                try
                                {
                                    TList_CfgFrota lCfg = TCN_CfgFrota.Buscar((bsPneus.Current as TRegistro_LanPneu).Cd_empresa,
                                                                               string.Empty,
                                                                               string.Empty,
                                                                               string.Empty,
                                                                               null);
                                    if (!string.IsNullOrEmpty(lCfg[0].Tp_duplicata))
                                        using (Financeiro.TFLanDuplicata fDup = new Financeiro.TFLanDuplicata())
                                        {
                                            fDup.vCd_empresa = (bsPneus.Current as TRegistro_LanPneu).Cd_empresa;
                                            fDup.vNm_empresa = (bsPneus.Current as TRegistro_LanPneu).Nm_empresa;
                                            fDup.vCd_clifor = string.Empty;
                                            fDup.vNm_clifor = string.Empty;
                                            //Buscar endereco clifor oficina
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
                                                fDup.vDt_emissao = fDadosMovPneu.rMovPneu.Dt_movimentostr;
                                                fDup.vVl_documento = fDadosMovPneu.rMovPneu.Valor_OS;
                                                fDup.vNr_docto = fDadosMovPneu.rMovPneu.Nr_OS;
                                                fDup.vSt_ecf = true;
                                                if (fDup.ShowDialog() == DialogResult.OK)
                                                {
                                                    if (fDup.dsDuplicata.Count > 0)
                                                        fDadosMovPneu.rMovPneu.rDup = fDup.dsDuplicata.Current as CamadaDados.Financeiro.Duplicata.TRegistro_LanDuplicata;
                                                }
                                                else
                                                {
                                                    MessageBox.Show("Obrigatório informar duplicata!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                    return;
                                                }
                                            }
                                        }

                                    fDadosMovPneu.rMovPneu.Cd_empresa = (bsPneus.Current as TRegistro_LanPneu).Cd_empresa;
                                    fDadosMovPneu.rMovPneu.Cd_produto = (bsPneus.Current as TRegistro_LanPneu).Cd_produto;
                                    fDadosMovPneu.rMovPneu.Id_pneu = (bsPneus.Current as TRegistro_LanPneu).Id_pneu;
                                    fDadosMovPneu.rMovPneu.St_rodando = "N";
                                    CamadaNegocio.Frota.TCN_MovPneu.GravarManutencao(fDadosMovPneu.rMovPneu, (bsPneus.Current as TRegistro_LanPneu), null);
                                    MessageBox.Show("Pneu enviado para a manutenção!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    afterBusca();
                                }
                                catch (Exception ex)
                                { MessageBox.Show(ex.Message.Trim(), "erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    }
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message.Trim(), "erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void btn_desativacao_Click(object sender, EventArgs e)
        {
            if (bsPneus.Current != null)
            {
                if ((bsPneus.Current as TRegistro_LanPneu).St_registro.ToUpper().Equals("D"))
                    return;
                else if ((bsPneus.Current as TRegistro_LanPneu).Status.Equals("MANUTENÇÃO"))
                {
                    MessageBox.Show("Não é possível desativar pneus com status em MANUTENÇÃO", "Informativo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (MessageBox.Show("Confirma a desativação do pneu selecionado?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    == DialogResult.Yes)
                    try
                    {
                        InputBox ibp = new InputBox();
                        ibp.Text = "Motivo Desativação";
                        string motivo = ibp.ShowDialog();
                        if (string.IsNullOrEmpty(motivo))
                        {
                            MessageBox.Show("Obrigatório informar motivo de desativação!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        if (motivo.Trim().Length < 10)
                        {
                            MessageBox.Show("Motivo de desativação deve ter mais que 10 caracteres!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        (bsPneus.Current as TRegistro_LanPneu).MotivoDesativacao = motivo;
                        if ((bsPneus.Current as TRegistro_LanPneu).Status.Equals("RODANDO"))
                            using (Componentes.TFQuantidade fQtde = new Componentes.TFQuantidade())
                            {
                                fQtde.Ds_label = "Hodometro final";
                                TpBusca[] tpBuscas = new TpBusca[0];
                                Estruturas.CriarParametro(ref tpBuscas, "a.cd_empresa", (bsPneus.Current as TRegistro_LanPneu).Cd_empresa);
                                Estruturas.CriarParametro(ref tpBuscas, "a.id_pneu", (bsPneus.Current as TRegistro_LanPneu).Id_pneustr);
                                Estruturas.CriarParametro(ref tpBuscas, "a.id_veiculo", (bsPneus.Current as TRegistro_LanPneu).Id_veiculo);
                                Estruturas.CriarParametro(ref tpBuscas, "a.id_rodado", (bsPneus.Current as TRegistro_LanPneu).Id_rodado);
                                fQtde.Vl_default = Convert.ToDecimal(new CamadaDados.Frota.TCD_MovPneu().BuscarEscalar(tpBuscas, "a.hodometro", "id_mov desc").ToString());
                                fQtde.Vl_Minimo = fQtde.Vl_default;
                                fQtde.Casas_decimais = 0;
                                fQtde.St_permitirValorZero = false;
                                if (fQtde.ShowDialog() == DialogResult.OK)
                                    (bsPneus.Current as TRegistro_LanPneu).HodometroDesativacao = Convert.ToInt32(fQtde.Quantidade);
                                else
                                {
                                    MessageBox.Show("Obrigatório informar hodometro para desativação!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                            }
                        TCN_LanPneu.Desativacao(bsPneus.Current as TRegistro_LanPneu, null);
                        MessageBox.Show("Pneu desativado com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        afterBusca();
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void bb_exclusao_Click(object sender, EventArgs e)
        {
            if (bsPneus.Current != null)
            {
                if ((bsPneus.Current as TRegistro_LanPneu).St_registro.ToUpper().Equals("M"))
                {
                    MessageBox.Show("Não é possível excluir pneus com status em MANUTENÇÃO!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                try
                {
                    if ((bsPneus.Current as TRegistro_LanPneu).Status.Equals("RODANDO"))
                        using (Componentes.TFQuantidade fQtde = new Componentes.TFQuantidade())
                        {
                            fQtde.Ds_label = "Hodometro final";
                            TpBusca[] tpBuscas = new TpBusca[0];
                            Estruturas.CriarParametro(ref tpBuscas, "a.cd_empresa", (bsPneus.Current as TRegistro_LanPneu).Cd_empresa);
                            Estruturas.CriarParametro(ref tpBuscas, "a.id_pneu", (bsPneus.Current as TRegistro_LanPneu).Id_pneustr);
                            Estruturas.CriarParametro(ref tpBuscas, "a.id_veiculo", (bsPneus.Current as TRegistro_LanPneu).Id_veiculo);
                            Estruturas.CriarParametro(ref tpBuscas, "a.id_rodado", (bsPneus.Current as TRegistro_LanPneu).Id_rodado);
                            fQtde.Vl_default = Convert.ToDecimal(new CamadaDados.Frota.TCD_MovPneu().BuscarEscalar(tpBuscas, "a.hodometro", "id_mov desc").ToString());
                            fQtde.Vl_Minimo = fQtde.Vl_default;
                            fQtde.Casas_decimais = 0;
                            fQtde.St_permitirValorZero = false;
                            if (fQtde.ShowDialog() == DialogResult.OK)
                                (bsPneus.Current as TRegistro_LanPneu).HodometroDesativacao = Convert.ToInt32(fQtde.Quantidade);
                            else
                            {
                                MessageBox.Show("Obrigatório informar hodometro para exclusão do pneu!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }

                    TCN_LanPneu.Excluir(bsPneus.Current as TRegistro_LanPneu, null);
                    MessageBox.Show("Pneu excluído com sucesso!", "Informativo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    afterBusca();
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void bb_adicionar_Click(object sender, EventArgs e)
        {
            using (TFCadPneu fPneu = new TFCadPneu())
            {
                fPneu.pStatus = "N";
                if (fPneu.ShowDialog() == DialogResult.OK)
                    if (fPneu.rPneu != null)
                        try
                        {
                            if (fPneu.rPneu.GerarAlmoxarifado)
                            {
                                TRegistro_Movimentacao _Movimentacao = new TRegistro_Movimentacao();
                                _Movimentacao.Cd_empresa = fPneu.rPneu.Cd_empresa;
                                _Movimentacao.Id_almox = fPneu.rPneu.Id_almox;
                                _Movimentacao.Cd_produto = fPneu.rPneu.Cd_produto;
                                _Movimentacao.Dt_movimento = CamadaDados.UtilData.Data_Servidor();
                                _Movimentacao.Tp_movimento = "E";
                                _Movimentacao.Quantidade = 1;
                                _Movimentacao.Vl_unitario = _Movimentacao.Vl_subtotal = fPneu.rPneu.CustoPneuAlmoxarifado;
                                _Movimentacao.St_registro = "A";
                                _Movimentacao.Ds_observacao = "ENTRADA POR CADASTRO DE PNEUS NOVOS";
                                CamadaNegocio.Almoxarifado.TCN_Movimentacao.Gravar(_Movimentacao, null);
                            }

                            TCN_LanPneu.Gravar(fPneu.rPneu, null);
                            if (fPneu.rPneu.GerarAlmoxarifado)
                                MessageBox.Show("Gerado movimentação de entrada no almoxarifado para o produto informado. Pneu gravado com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            else
                                MessageBox.Show("Pneu gravado com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LimparFiltros();
                            afterBusca();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void bb_veiculo_Click(object sender, EventArgs e)
        {
            string vParam = "isnull(a.st_registro, 'A')|<>|'I'";
            string vColunas = "a.ds_veiculo|Veiculo|200;" +
                              "a.id_veiculo|Codigo|80;" +
                              "a.placa|Placa|80";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { id_veiculo },
                new TCD_CadVeiculo(),
               vParam);
        }

        private void id_veiculo_Leave(object sender, EventArgs e)
        {
            string vParam = "a.id_veiculo|=|'" + id_veiculo.Text.Trim() + "';" +
                                "isnull(a.st_registro, 'A')|<>|'I'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { id_veiculo },
                                            new TCD_CadVeiculo());
        }

        private void bb_rodado_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_rodado|Veiculo|200;" +
                              "a.id_rodado|Codigo|80";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { id_rodado },
                new TCD_Rodado(),
               string.Empty);
        }

        private void id_rodado_Leave(object sender, EventArgs e)
        {
            string vParam = "a.id_rodado|=|'" + id_rodado.Text.Trim() + "';" +
                                "isnull(a.st_registro, 'A')|<>|'I'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { id_rodado },
                                            new TCD_Rodado());
        }

        private void bsPneus_PositionChanged(object sender, EventArgs e)
        {
            if (bsPneus.Current != null)
            {
                (bsPneus.Current as TRegistro_LanPneu).lMovPneu =
                    CamadaNegocio.Frota.TCN_MovPneu.Buscar((bsPneus.Current as TRegistro_LanPneu).Cd_empresa,
                                                           (bsPneus.Current as TRegistro_LanPneu).Id_pneustr,
                                                           string.Empty,
                                                           string.Empty,
                                                           null);
                bsPneus.ResetCurrentItem();
            }
        }

        private void TFLanMovPneu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F7))
                afterBusca();
        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            afterBusca();
        }

        private void gPneu_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
                if (e.ColumnIndex.Equals(0))
                {

                    if (e.Value.ToString().Trim().ToUpper().Equals("ALMOXARIFADO"))
                        gPneu.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                    else if (e.Value.ToString().Trim().ToUpper().Equals("RODANDO"))
                        gPneu.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Green;
                    else if (e.Value.ToString().Trim().ToUpper().Equals("MANUTENÇÃO"))
                        gPneu.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Blue;
                    else
                        gPneu.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
                }
        }

        private void gPneu_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gPneu.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsPneus.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new CamadaDados.Frota.Cadastros.TRegistro_LanPneu());
            CamadaDados.Frota.Cadastros.TList_LanPneu lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gPneu.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gPneu.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new CamadaDados.Frota.Cadastros.TList_LanPneu(lP.Find(gPneu.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gPneu.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new CamadaDados.Frota.Cadastros.TList_LanPneu(lP.Find(gPneu.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gPneu.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsPneus.List as CamadaDados.Frota.Cadastros.TList_LanPneu).Sort(lComparer);
            bsPneus.ResetBindings(false);
            gPneu.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void btn_retornarManut_Click(object sender, EventArgs e)
        {
            if (bsPneus.Current != null)
            {
                if ((bsPneus.Current as TRegistro_LanPneu).St_registro.ToUpper().Equals("M"))
                {
                    if (MessageBox.Show("Confirma o retorno do pneu selecionado da manutenção?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                     == DialogResult.Yes)
                        using (TFCadPneu fPneu = new TFCadPneu())
                        {
                            fPneu.rPneu = bsPneus.Current as TRegistro_LanPneu;
                            fPneu.pStatus = "M";
                            if (fPneu.ShowDialog() == DialogResult.OK)
                                if (fPneu.rPneu != null)
                                    try
                                    {
                                        CamadaNegocio.Frota.Cadastros.TCN_LanPneu.RetornoManutencao(bsPneus.Current as TRegistro_LanPneu, null);
                                        MessageBox.Show("Pneu retornado da manutenção!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        afterBusca();
                                    }
                                    catch (Exception ex)
                                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                        }
                }
            }
        }

        private void btn_fechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_enviarAlmoxarifado_Click(object sender, EventArgs e)
        {
            if (bsPneus.Current != null)
            {
                if ((bsPneus.Current as TRegistro_LanPneu).St_registro.ToUpper().Equals("R"))
                {
                    if (MessageBox.Show("Confirma o envio ao almoxarifado para o pneu selecionado?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                     == DialogResult.Yes)
                        try
                        {
                            //Informar Hodometro
                            int hodometro = 0;
                            using (Componentes.TFQuantidade fQtde = new Componentes.TFQuantidade())
                            {
                                fQtde.Ds_label = "Hodometro final";
                                TpBusca[] tpBuscas = new TpBusca[0];
                                Estruturas.CriarParametro(ref tpBuscas, "a.cd_empresa", (bsPneus.Current as TRegistro_LanPneu).Cd_empresa);
                                Estruturas.CriarParametro(ref tpBuscas, "a.id_pneu", (bsPneus.Current as TRegistro_LanPneu).Id_pneustr);
                                Estruturas.CriarParametro(ref tpBuscas, "a.id_veiculo", (bsPneus.Current as TRegistro_LanPneu).Id_veiculo);
                                Estruturas.CriarParametro(ref tpBuscas, "a.id_rodado", (bsPneus.Current as TRegistro_LanPneu).Id_rodado);
                                fQtde.Vl_default = Convert.ToDecimal(new CamadaDados.Frota.TCD_MovPneu().BuscarEscalar(tpBuscas, "a.hodometro", "id_mov desc").ToString());
                                fQtde.Vl_Minimo = fQtde.Vl_default;
                                fQtde.Casas_decimais = 0;
                                fQtde.St_permitirValorZero = false;
                                if (fQtde.ShowDialog() == DialogResult.OK)
                                    hodometro = Convert.ToInt32(fQtde.Quantidade);
                                else
                                {
                                    MessageBox.Show("Obrigatório informar hodometro para desativação!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                            }

                            CamadaNegocio.Frota.Cadastros.TCN_LanPneu.EnvioAlmoxarifado(bsPneus.Current as TRegistro_LanPneu, hodometro, null);
                            MessageBox.Show("Pneu enviado ao almoxarifado!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            afterBusca();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
                else
                    MessageBox.Show("Pneu deve ter status RODANDO para enviar ao almoxarifado!", "Informativo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BB_Placa_Click(object sender, EventArgs e)
        {
            string vParam = "isnull(a.st_registro, 'A')|<>|'I'";
            string vColunas = "a.placa|Placa|80;" +
                              "a.ds_veiculo|Veiculo|200;" +
                              "a.id_veiculo|Codigo|80";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { nr_placa }, new TCD_CadVeiculo(), vParam);
        }

        private void BB_Movimentacao_Click(object sender, EventArgs e)
        {
            gerarMovimentacao();
        }

        private void BB_Alterar_Click(object sender, EventArgs e)
        {
            if (bsPneus.Current == null)
                return;
            
            using (TFCadPneu fPneu = new TFCadPneu())
            {
                fPneu.pTitle = "Alteração de Pneu";
                fPneu.rPneu = (bsPneus.Current as TRegistro_LanPneu);
                if (fPneu.ShowDialog() == DialogResult.OK)
                    if (fPneu.rPneu != null)
                        try
                        {
                            if (fPneu.rPneu.GerarAlmoxarifado)
                            {
                                TRegistro_Movimentacao _Movimentacao = new TRegistro_Movimentacao();
                                _Movimentacao.Cd_empresa = fPneu.rPneu.Cd_empresa;
                                _Movimentacao.Id_almox = fPneu.rPneu.Id_almox;
                                _Movimentacao.Cd_produto = fPneu.rPneu.Cd_produto;
                                _Movimentacao.Dt_movimento = CamadaDados.UtilData.Data_Servidor();
                                _Movimentacao.Tp_movimento = "E";
                                _Movimentacao.Quantidade = 1;
                                _Movimentacao.Vl_unitario = _Movimentacao.Vl_subtotal = fPneu.rPneu.CustoPneuAlmoxarifado;
                                _Movimentacao.St_registro = "A";
                                _Movimentacao.Ds_observacao = "ENTRADA POR CADASTRO DE PNEUS NOVOS";
                                CamadaNegocio.Almoxarifado.TCN_Movimentacao.Gravar(_Movimentacao, null);
                            }

                            TCN_LanPneu.Gravar(fPneu.rPneu, null);
                            if (fPneu.rPneu.GerarAlmoxarifado)
                                MessageBox.Show("Gerado movimentação de entrada no almoxarifado para o produto informado. Pneu gravado com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            else
                                MessageBox.Show("Pneu gravado com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LimparFiltros();
                            afterBusca();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void BB_Observacao_Click(object sender, EventArgs e)
        {
            if (bsPneus.Current != null)
            {
                InputBox input = new InputBox();
                input.Text = "Observação para o pneu: " + (bsPneus.Current as TRegistro_LanPneu).Ds_produto;
                string obs = input.ShowDialog();
                if (!string.IsNullOrEmpty(obs))
                {
                    (bsPneus.Current as TRegistro_LanPneu).DS_Observacao = obs;
                    TCN_LanPneu.Gravar((bsPneus.Current as TRegistro_LanPneu), null);
                    afterBusca();
                }
            }
        }

        private void BB_Trocar_Click(object sender, EventArgs e)
        {
            using(TFMovimentarVeiculo fMovVeiculo = new TFMovimentarVeiculo())
            {
                fMovVeiculo.ShowDialog();
            }
        }
    }
}
