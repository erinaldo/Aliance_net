using CamadaDados.PostoCombustivel;
using CamadaDados.PostoCombustivel.Cadastros;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Utils;
using CamadaNegocio.Diversos;
using Parametros.Diversos;

namespace PostoCombustivel
{
    public partial class TFCliforConvenio : Form
    {
        private TList_CfgPosto lCfgPosto
        { get; set; }
        private TRegistro_Convenio_Clifor rclifor;
        public TRegistro_Convenio_Clifor rClifor
        {
            get
            {
                if (bsCliforConvenio.Count > 0)
                    return bsCliforConvenio.Current as TRegistro_Convenio_Clifor;
                else
                    return null;
            }
            set
            { rclifor = value; }
        }
        public bool tipo_insercaounica { get; set; }

        public List<CamadaDados.Financeiro.Cadastros.TRegistro_CadClifor> lClifor { get; set; }

        public List<CamadaDados.Estoque.Cadastros.TRegistro_CadProduto> lCombustivel
        { get; set; }
        public string pCd_empresa
        { get; set; }
        private bool St_alterar
        { get; set; }

        public TFCliforConvenio()
        {
            InitializeComponent();
            St_alterar = false;
            lCombustivel = new List<CamadaDados.Estoque.Cadastros.TRegistro_CadProduto>();

            System.Collections.ArrayList cbx = new System.Collections.ArrayList();
            cbx.Add(new TDataCombo("NORMAL", "N"));
            cbx.Add(new TDataCombo("ANP", "A"));
            cbx.Add(new TDataCombo("CUSTO", "C"));
            tp_preco.DataSource = cbx;
            tp_preco.DisplayMember = "Display";
            tp_preco.ValueMember = "Value";

            System.Collections.ArrayList cbx1 = new System.Collections.ArrayList();
            cbx1.Add(new TDataCombo("<NENHUM>", string.Empty));
            cbx1.Add(new TDataCombo("UN", "Q"));
            cbx1.Add(new TDataCombo("R$", "V"));
            tp_qt_vl_pc.DataSource = cbx1;
            tp_qt_vl_pc.DisplayMember = "Display";
            tp_qt_vl_pc.ValueMember = "Value";

            System.Collections.ArrayList cbx2 = new System.Collections.ArrayList();
            cbx2.Add(new TDataCombo("<NENHUM>", string.Empty));
            cbx2.Add(new TDataCombo("CLIENTE", "C"));
            cbx2.Add(new TDataCombo("PLACA", "P"));
            cbx2.Add(new TDataCombo("MOTORISTA", "M"));
            tp_pontos_fid.DataSource = cbx2;
            tp_pontos_fid.DisplayMember = "Display";
            tp_pontos_fid.ValueMember = "Value";

            System.Collections.ArrayList cbx3 = new System.Collections.ArrayList();
            cbx3.Add(new TDataCombo("", ""));
            cbx3.Add(new TDataCombo("CUPOM FISCAL", "CF"));
            cbx3.Add(new TDataCombo("NOTA FISCAL", "NF"));
            tp_faturamento.DataSource = cbx3;
            tp_faturamento.DisplayMember = "Display";
            tp_faturamento.ValueMember = "Value";

            System.Collections.ArrayList cbx4 = new System.Collections.ArrayList();
            cbx4.Add(new TDataCombo("ACRESCIMO", "A"));
            cbx4.Add(new TDataCombo("DESCONTO", "D"));
            tp_acresdesc.DataSource = cbx4;
            tp_acresdesc.DisplayMember = "Display";
            tp_acresdesc.ValueMember = "Value";

            System.Collections.ArrayList cbx5 = new System.Collections.ArrayList();
            cbx5.Add(new TDataCombo("PERCENTUAL", "P"));
            cbx5.Add(new TDataCombo("VALOR", "V"));
            tp_desconto.DataSource = cbx5;
            tp_desconto.ValueMember = "Value";
            tp_desconto.DisplayMember = "Display";
        }

        private void BuscarEndereco()
        {
            if (!string.IsNullOrEmpty(cd_clifor.Text))
            {
                object obj = new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco().BuscarEscalar(
                                new TpBusca[]
                                {
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.cd_clifor",
                                        vOperador = "=",
                                        vVL_Busca = "'" + cd_clifor.Text.Trim() + "'"
                                    }
                                }, "CONVERT(VARCHAR(100),(a.cd_endereco + ',' + a.cd_uf + ',' + a.ds_endereco))");
                if (obj != null)
                {
                    cd_endereco.Text = obj.ToString().Split(new char[] { ',' })[0];
                    ds_endereco.Text = obj.ToString().Split(new char[] { ',' })[2];
                    if (lCfgPosto[0].St_NFDiretaForaUFbool)
                    {
                        object ufEmp = new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco().BuscarEscalar(
                                new TpBusca[]
                                {
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.cd_clifor",
                                        vOperador = "=",
                                        vVL_Busca = "'" + lCfgPosto[0].Cd_clifor.Trim() + "'"
                                    }
                                }, "a.cd_uf");
                        if (ufEmp != null)
                            if (ufEmp.ToString() != obj.ToString().Split(new char[] { ',' })[1])
                            {
                                tp_faturamento.SelectedIndex = 2;
                                tp_faturamento.SelectedValue = "NF";
                                tp_faturamento.Enabled = false;
                            }
                    }
                }
            }
        }

        private void afterGrava()
        {
            if (pDados.validarCampoObrigatorio())
            {
                if (base_calc_fid.Value > decimal.Zero ||
                    qt_pontos_fid.Value > decimal.Zero)
                {
                    if (base_calc_fid.Value.Equals(decimal.Zero))
                    {
                        MessageBox.Show("Obrigatório informar Base Calc. para configurar os pontos!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        base_calc_fid.Focus();
                        return;
                    }
                    if (string.IsNullOrEmpty(tp_qt_vl_pc.Text))
                    {
                        MessageBox.Show("Obrigatório informar tipo de conversão para configurar os pontos!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        tp_qt_vl_pc.Focus();
                        return;
                    }
                    if (qt_pontos_fid.Value.Equals(decimal.Zero))
                    {
                        MessageBox.Show("Obrigatório informar quantidade para configurar os pontos!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        qt_pontos_fid.Focus();
                        return;
                    }
                    if (string.IsNullOrEmpty(tp_pontos_fid.Text))
                    {
                        MessageBox.Show("Obrigatório informar controle pontos para configurar os pontos!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        tp_pontos_fid.Focus();
                        return;
                    }
                }
                if (vl_unitario.Focused)
                    (bsCliforConvenio.Current as TRegistro_Convenio_Clifor).Vl_unitario = vl_unitario.Value;
                if (!St_alterar)
                {
                    #region Insersão composta
                    if (string.IsNullOrEmpty(cd_clifor.Text.Trim()))
                    {
                        using (TFListaClifor lCli = new TFListaClifor())
                        {
                            if (lCli.ShowDialog() == DialogResult.OK)
                            {
                                if (lCli.lClifor != null)
                                {
                                    lClifor = lCli.lClifor;
                                    using (TFListaCombustivel fLista = new TFListaCombustivel())
                                    {
                                        fLista.St_produtounicio = vl_unitario.Value > decimal.Zero;
                                        if (fLista.ShowDialog() == DialogResult.OK)
                                            if (fLista.lCombustivel != null)
                                                lCombustivel.AddRange(fLista.lCombustivel);
                                    }
                                }
                            }
                        }
                    }
                    #endregion
                    #region Inserção unica
                    else
                    {
                        using (TFListaCombustivel fLista = new TFListaCombustivel())
                        {
                            fLista.St_produtounicio = vl_unitario.Value > decimal.Zero;
                            if (fLista.ShowDialog() == DialogResult.OK)
                            {
                                if (fLista.lCombustivel != null)
                                {
                                    fLista.lCombustivel.ForEach(p =>
                                    {
                                        //Verificar se ja existe programacao para o cliente e produto
                                        object obj = new TCD_Convenio_Clifor().BuscarEscalar(
                                                            new TpBusca[]
                                                            {
                                                            new TpBusca()
                                                            {
                                                                vNM_Campo = "a.cd_clifor",
                                                                vOperador = "=",
                                                                vVL_Busca = "'" + cd_clifor.Text.Trim() + "'"
                                                            },
                                                            new TpBusca()
                                                            {
                                                                vNM_Campo = "a.cd_endereco",
                                                                vOperador = "=",
                                                                vVL_Busca = "'" + cd_endereco.Text.Trim() + "'"
                                                            },
                                                            new TpBusca()
                                                            {
                                                                vNM_Campo = "a.cd_produto",
                                                                vOperador = "=",
                                                                vVL_Busca = "'" + p.CD_Produto.Trim() + "'"
                                                            }
                                                    }, "a.id_convenio");
                                        if (obj != null)
                                        {
                                            if (CamadaNegocio.ConfigGer.TCN_CadParamGer.BuscaVlBool("ST_CLIFOR_MULTIPLOS_CONV", null))
                                            {
                                                if (MessageBox.Show("Ja existe convenio programado para o cliente " + cd_clifor.Text.Trim() +
                                                            " endereço " + ds_endereco.Text.Trim() + "\r\n" +
                                                            "e produto " + p.CD_Produto.Trim() + ".\r\n" +
                                                            "Convenio Nº " + obj.ToString() + "\r\n" +
                                                            "Deseja prosseguir e incluir o cliente em mais de um convenio?", "Pergunta",
                                                            MessageBoxButtons.YesNo,
                                                            MessageBoxIcon.Question,
                                                            MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                                                    lCombustivel.Add(p);
                                            }
                                            else if (MessageBox.Show("Ja existe convenio programado para o cliente " + cd_clifor.Text.Trim() +
                                                            " endereço " + ds_endereco.Text.Trim() + "\r\n" +
                                                            "e produto " + p.CD_Produto.Trim() + ".\r\n" +
                                                            "Convenio Nº " + obj.ToString() + "\r\n" +
                                                            "Deseja prosseguir e excluir o cliente do convenio Nº" + obj.ToString() + "?", "Pergunta",
                                                            MessageBoxButtons.YesNo,
                                                            MessageBoxIcon.Question,
                                                            MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                                                lCombustivel.Add(p);
                                        }
                                        else
                                            lCombustivel.Add(p);
                                    });
                                    if (lCombustivel.Count.Equals(0))
                                    {
                                        MessageBox.Show("Obrigatorio informar combustivel para o convenio.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        return;
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Obrigatorio informar combustivel para o convenio.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                            }
                            else
                            {
                                MessageBox.Show("Obrigatorio informar combustivel para o convenio.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }
                    }
                    #endregion
                }
                DialogResult = DialogResult.OK;
            }
        }

        private void InserirPlaca()
        {
            if (bsCliforConvenio.Current != null)
                using (TFPlacaConvenio fPlaca = new TFPlacaConvenio())
                {
                    if (fPlaca.ShowDialog() == DialogResult.OK)
                        if (fPlaca.rPlaca != null)
                        {
                            if ((bsCliforConvenio.Current as TRegistro_Convenio_Clifor).lPlaca.Exists(p =>
                                p.Placa.Trim().Equals(fPlaca.rPlaca.Placa.Trim())))
                            {
                                (bsCliforConvenio.Current as TRegistro_Convenio_Clifor).lPlaca.Find(p =>
                                    p.Placa.Trim().Equals(fPlaca.rPlaca.Placa.Trim())).Ds_veiculo = fPlaca.rPlaca.Ds_veiculo;
                                (bsCliforConvenio.Current as TRegistro_Convenio_Clifor).lPlaca.Find(p =>
                                    p.Placa.Trim().Equals(fPlaca.rPlaca.Placa.Trim())).St_km = fPlaca.rPlaca.St_km;
                                (bsCliforConvenio.Current as TRegistro_Convenio_Clifor).lPlaca.Find(p =>
                                    p.Placa.Trim().Equals(fPlaca.rPlaca.Placa.Trim())).St_diasuteis = fPlaca.rPlaca.St_diasuteis;
                                (bsCliforConvenio.Current as TRegistro_Convenio_Clifor).lPlaca.Find(p =>
                                    p.Placa.Trim().Equals(fPlaca.rPlaca.Placa.Trim())).Ds_observacao = fPlaca.rPlaca.Ds_observacao;
                            }
                            else
                                (bsCliforConvenio.Current as TRegistro_Convenio_Clifor).lPlaca.Add(fPlaca.rPlaca);
                            bsCliforConvenio.ResetCurrentItem();
                        }
                }
        }

        private void AlterarPlaca()
        {
            if (bsPlacaConvenio.Current != null)
                using (TFPlacaConvenio fPlaca = new TFPlacaConvenio())
                {
                    string ds_veiculo = (bsPlacaConvenio.Current as TRegistro_Convenio_Placa).Ds_veiculo;
                    string st_km = (bsPlacaConvenio.Current as TRegistro_Convenio_Placa).St_km;
                    string st_diautil = (bsPlacaConvenio.Current as TRegistro_Convenio_Placa).St_diasuteis;
                    string ds_obs = (bsPlacaConvenio.Current as TRegistro_Convenio_Placa).Ds_observacao;

                    fPlaca.rPlaca = bsPlacaConvenio.Current as TRegistro_Convenio_Placa;
                    if (fPlaca.ShowDialog() != DialogResult.OK)
                    {
                        (bsPlacaConvenio.Current as TRegistro_Convenio_Placa).Ds_veiculo = ds_veiculo;
                        (bsPlacaConvenio.Current as TRegistro_Convenio_Placa).St_km = st_km;
                        (bsPlacaConvenio.Current as TRegistro_Convenio_Placa).St_diasuteis = st_diautil;
                        (bsPlacaConvenio.Current as TRegistro_Convenio_Placa).Ds_observacao = ds_obs;
                        bsPlacaConvenio.ResetCurrentItem();
                    }
                }
        }

        private void ExcluirPlaca()
        {
            if (bsPlacaConvenio.Current != null)
                if (MessageBox.Show("Confirma exclusão do registro?", "Pergunta", MessageBoxButtons.YesNo,
                     MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    (bsCliforConvenio.Current as TRegistro_Convenio_Clifor).lPlacaDel.Add(
                        bsPlacaConvenio.Current as TRegistro_Convenio_Placa);
                    bsPlacaConvenio.RemoveCurrent();
                }
        }

        private void InserirMotorista()
        {
            if (bsCliforConvenio.Current != null)
                using (TFMotoristaConvenio fMot = new TFMotoristaConvenio())
                {
                    if (fMot.ShowDialog() == DialogResult.OK)
                        if (fMot.rMot != null)
                            if (!(bsCliforConvenio.Current as TRegistro_Convenio_Clifor).lMotorista.Exists(p =>
                                p.CPF_motorista.SoNumero().Equals(fMot.rMot.CPF_motorista.SoNumero())))
                            {
                                (bsCliforConvenio.Current as TRegistro_Convenio_Clifor).lMotorista.Add(fMot.rMot);
                                bsCliforConvenio.ResetCurrentItem();
                            }
                            else MessageBox.Show("CPF já informado para outro motorista.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
        }

        private void ExcluirMotorista()
        {
            if (bsMotorista.Current != null)
                if (MessageBox.Show("Confirma exclusão do registro?", "Pergunta", MessageBoxButtons.YesNo,
                     MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    (bsCliforConvenio.Current as TRegistro_Convenio_Clifor).lMotDel.Add(
                        bsMotorista.Current as TRegistro_Convenio_Motorista);
                    bsMotorista.RemoveCurrent();
                }
        }

        private void bb_clifor_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_clifor, nm_clifor }, string.Empty);
            BuscarEndereco();
        }

        private void cd_clifor_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + cd_clifor.Text.Trim() + "'",
                                                    new Componentes.EditDefault[] { cd_clifor, nm_clifor },
                                                    new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
            BuscarEndereco();
        }

        private void TFCliforConvenio_Load(object sender, EventArgs e)
        {
            if (tipo_insercaounica)
                cd_clifor.ST_NotNull = true;

            //Valida tipo de inserção unica/composta e manipula tela
            cd_clifor_TextChanged(sender, e);

            ShapeGrid.RestoreShape(this, gPlacaConv);
            ShapeGrid.RestoreShape(this, gMotorista);
            Icon = ResourcesUtils.TecnoAliance_ICO;
            pDados.set_FormatZero();
            lCfgPosto = CamadaNegocio.PostoCombustivel.Cadastros.TCN_CfgPosto.Buscar(pCd_empresa, null);
            if (rclifor != null)
            {
                bsCliforConvenio.DataSource = new TList_Convenio_Clifor() { rclifor };
                cd_clifor.Enabled = false;
                bb_clifor.Enabled = false;
                BuscarEndereco();
                St_alterar = true;
                Text = "Alterando cliente convenio - " + rclifor.Ds_produto.Trim();
            }
            else
            {
                bsCliforConvenio.AddNew();
                cd_clifor.Focus();
            }
            vl_unitario.Enabled = TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin, "PERMITIR INFORMAR O VALOR UNITÁRIO CONVÊNIO", null);
            tp_acresdesc.Enabled = vl_unitario.Enabled;
            desconto.Enabled = vl_unitario.Enabled;
            tp_desconto.Enabled = vl_unitario.Enabled;
        }

        private void btn_Inserir_Item_Click(object sender, EventArgs e)
        {
            InserirPlaca();
        }

        private void BB_Alterar_Item_Click(object sender, EventArgs e)
        {
            AlterarPlaca();
        }

        private void btn_Deleta_Item_Click(object sender, EventArgs e)
        {
            ExcluirPlaca();
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            afterGrava();
        }

        private void TFCliforConvenio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                DialogResult = DialogResult.Cancel;
            else if (e.Control && e.KeyCode.Equals(Keys.F10) && tcCentral.SelectedTab.Equals(tpPlaca))
                InserirPlaca();
            else if (e.Control && e.KeyCode.Equals(Keys.F11) && tcCentral.SelectedTab.Equals(tpPlaca))
                AlterarPlaca();
            else if (e.Control && e.KeyCode.Equals(Keys.F12) && tcCentral.SelectedTab.Equals(tpPlaca))
                ExcluirPlaca();
            else if (e.Control && e.KeyCode.Equals(Keys.F10) && tcCentral.SelectedTab.Equals(tpMotorista))
                InserirMotorista();
            else if (e.Control && e.KeyCode.Equals(Keys.F12) && tcCentral.SelectedTab.Equals(tpMotorista))
                ExcluirMotorista();
        }

        private void bb_inserirmotorista_Click(object sender, EventArgs e)
        {
            InserirMotorista();
        }

        private void bb_excluirmotorista_Click(object sender, EventArgs e)
        {
            ExcluirMotorista();
        }

        private void gPlacaConv_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gPlacaConv.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsPlacaConvenio.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new TRegistro_Convenio_Placa());
            TList_Convenio_Placa lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gPlacaConv.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gPlacaConv.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new TList_Convenio_Placa(lP.Find(gPlacaConv.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gPlacaConv.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new TList_Convenio_Placa(lP.Find(gPlacaConv.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gPlacaConv.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsPlacaConvenio.List as TList_Convenio_Placa).Sort(lComparer);
            bsPlacaConvenio.ResetBindings(false);
            gPlacaConv.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
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

        private void bb_vendedor_Click(object sender, EventArgs e)
        {
            string vColunas = "a.nm_clifor|Nome Vendedor|200;" +
                              "a.cd_clifor|Cd. Vendedor|80";
            string vParam = "isnull(a.st_vendedor, 'N')|=|'S';" +
                            "isnull(a.st_funcativo, 'N')|=|'S'";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_vendedor, Nm_vendedor },
                new CamadaDados.Financeiro.Cadastros.TCD_CadClifor(),
               vParam);
        }

        private void CD_vendedor_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_clifor|=|'" + CD_vendedor.Text.Trim() + "';" +
                            "isnull(a.st_vendedor, 'N')|=|'S';" +
                            "isnull(a.st_funcativo, 'N')|=|'S'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { CD_vendedor, Nm_vendedor },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void TFCliforConvenio_FormClosing(object sender, FormClosingEventArgs e)
        {
            ShapeGrid.SaveShape(this, gPlacaConv);
            ShapeGrid.SaveShape(this, gMotorista);
        }

        private void CliforToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CamadaNegocio.ConfigGer.TCN_CadParamGer.BuscaVlBool("ST_CADCLFOR_RESUMIDO", null))
                using (Financeiro.Cadastros.TFCadCliforResumido fClifor = new Financeiro.Cadastros.TFCadCliforResumido())
                {
                    if (fClifor.ShowDialog() == DialogResult.OK)
                        if (fClifor.rClifor != null)
                            try
                            {
                                CamadaNegocio.Financeiro.Cadastros.TCN_CadClifor.Gravar(fClifor.rClifor, null);
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            else
                using (Financeiro.Cadastros.TFCadCliforResumido fClifor = new Financeiro.Cadastros.TFCadCliforResumido())
                {
                    if (fClifor.ShowDialog() == DialogResult.OK)
                        if (fClifor.rClifor != null)
                            try
                            {
                                CamadaNegocio.Financeiro.Cadastros.TCN_CadClifor.Gravar(fClifor.rClifor, null);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                }
        }

        private void bb_endereco_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_endereco|Endereço|200;" +
                              "a.cd_endereco|Codigo|80;" +
                              "a.bairro|Bairro|80;" +
                              "a.insc_estadual|Insc. Estadual|80";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_endereco, ds_endereco },
                new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco(), "a.cd_clifor|=|'" + cd_clifor.Text.Trim() + "'");
        }

        private void cd_endereco_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_endereco|=|'" + cd_endereco.Text.Trim() + "';" +
                            "a.cd_clifor|=|'" + cd_clifor.Text.Trim() + "'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_endereco, ds_endereco },
                new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco());
        }

        private void bb_importPlaca_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cd_clifor.Text))
                using (TFImportPlaca fImport = new TFImportPlaca())
                {
                    fImport.pCd_empresa = pCd_empresa;
                    fImport.pCd_clifor = cd_clifor.Text;
                    if (fImport.ShowDialog() == DialogResult.OK)
                        if (fImport.lPlaca != null)
                        {
                            fImport.lPlaca.ForEach(p =>
                                (bsCliforConvenio.Current as TRegistro_Convenio_Clifor).lPlaca.Add(p));
                            bsCliforConvenio.ResetCurrentItem();
                        }
                }
            else MessageBox.Show("Obrigatorio informar cliente.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void bb_config_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_config|Configuração Boleto|200;" +
                              "a.id_config|Id. Config.|80";
            string vParam = "a.cd_empresa|=|'" + pCd_empresa.Trim() + "';" +
                            "isnull(a.st_registro, 'A')|<>|'C'";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { id_config, ds_config },
                new CamadaDados.Financeiro.Cadastros.TCD_CadCFGBanco(), vParam);
        }

        private void id_config_Leave(object sender, EventArgs e)
        {
            string vParam = "a.id_config|=|" + id_config.Text + ";" +
                            "a.cd_empresa|=|'" + pCd_empresa.Trim() + "';" +
                            "isnull(a.st_registro, 'A')|<>|'C'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { id_config, ds_config },
                new CamadaDados.Financeiro.Cadastros.TCD_CadCFGBanco());
        }

        private void base_calc_fid_Leave(object sender, EventArgs e)
        {
            if (base_calc_fid.Value.Equals(decimal.Zero))
            {
                tp_qt_vl_pc.SelectedIndex = 0;
                tp_pontos_fid.SelectedIndex = 0;
            }
        }

        private void bt_VLUnitario_Click(object sender, EventArgs e)
        {
            using (TFRegraUsuario obj = new TFRegraUsuario())
            {
                obj.Ds_regraespecial = "PERMITIR INFORMAR O VALOR UNITÁRIO CONVÊNIO";
                if (obj.DialogResult == DialogResult.OK)
                {
                    using (Componentes.TFQuantidade objQ = new Componentes.TFQuantidade())
                    {
                        objQ.Casas_decimais = 5;
                        objQ.Ds_label = "VL.Unitário";
                        if (objQ.DialogResult == DialogResult.OK)
                        {
                            vl_unitario.Value = objQ.Quantidade;
                        }
                    }
                }
            }

        }

        private void cd_clifor_TextChanged(object sender, EventArgs e)
        {
            //Lançamento composto de clientes em um convênio
            if (string.IsNullOrEmpty(cd_clifor.Text.Trim()))
            {
                pDados.LimparRegistro();
                cd_endereco.Enabled = false;
                bb_endereco.Enabled = false;
                tlpCentral.Controls[1].Enabled = false;
            }
            else
            {
                cd_endereco.Enabled = true;
                bb_endereco.Enabled = true;
                tlpCentral.Controls[1].Enabled = true;
            }
        }
    }
}
