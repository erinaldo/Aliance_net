using System;
using System.Data;
using System.Windows.Forms;

namespace Empreendimento
{
    public partial class FExecucaoDespesas : Form
    {
        public string vNr_Versao = string.Empty;
        public string vId_Orcamento = string.Empty;
        public string vCd_Empresa = string.Empty;
        public string vDs_Empresa = string.Empty;
        public string vCd_Historico = string.Empty;
        public string vNm_empresa = string.Empty;

        public FExecucaoDespesas()
        {
            InitializeComponent();

            System.Collections.ArrayList cbx = new System.Collections.ArrayList();
            cbx.Add(new Utils.TDataCombo("EMPRESA", "E"));
            cbx.Add(new Utils.TDataCombo("FUNCIONARIO", "F"));
            tp_pagamento.DataSource = cbx;
            tp_pagamento.DisplayMember = "Display";
            tp_pagamento.ValueMember = "Value";
            bsDespesas.AddNew();
        }

        private void editDefault1_Leave(object sender, EventArgs e)
        {
            string vParam = "a.id_regdesp|=|" + id_regDesp.Text + " ;" +
                            "a.nr_versao|=| " + vNr_Versao + ";" +
                            "a.id_orcamento|=| " + vId_Orcamento + ";" +
                            "a.vl_subtotal |<>| a.vl_executado ";
            DataRow line = FormBusca.UtilPesquisa.EDIT_LEAVE(
               vParam,
               new Componentes.EditDefault[] { id_regDesp, ds_desp },
               new CamadaDados.Empreendimento.TCD_Despesas());

            if (line != null)
                valor.Value = Convert.ToDecimal(line["vl_subtotal"].ToString());
        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            string vColunas = "b.ds_despesa|despesa|200;" +
                             "a.id_regdesp|Codigo|80";
            string vParam = "a.nr_versao|=| " + vNr_Versao + ";" +
                            "a.id_orcamento|=| " + vId_Orcamento + ";" +
                            "a.vl_subtotal |<>| a.vl_executado ";
            DataRowView line = FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { id_regDesp, ds_desp },
                new CamadaDados.Empreendimento.TCD_Despesas(),
               vParam);
            if (line != null)
            {
                if (Convert.ToDecimal(line["vl_subtotal"].ToString()) - Convert.ToDecimal(line["vl_executado"].ToString()) > 0)
                {
                    valor.Value = Convert.ToDecimal(line["vl_subtotal"].ToString()) - Convert.ToDecimal(line["vl_executado"].ToString());
                    valor_total.Value = Convert.ToDecimal(line["vl_subtotal"].ToString()) - Convert.ToDecimal(line["vl_executado"].ToString());
                }
                else
                {
                    valor.Value = decimal.Zero;
                    valor_total.Value = decimal.Zero;
                }
                id_regDesp.Text = line["id_regdesp"].ToString();
            }

        }

        private void bb_fornecedor_Click(object sender, EventArgs e)
        {
            string vParam = "isnull(a.st_fornecedor, 'N')|=|'S';" +
                                "isnull(a.st_registro, 'C')|=|'A'";
            FormBusca.UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_fornecedor, nm_fornecedor }, vParam);

        }

        private void bbBuscar_Click(object sender, EventArgs e)
        {
            if (bsDespesas.Current != null)
                if (panelDados2.validarCampoObrigatorio())
                {
                    if (tp_pagamento.SelectedIndex.Equals(0) && string.IsNullOrWhiteSpace(cd_fornecedor.Text))
                    {
                        MessageBox.Show("Obrigatório informar fornecedor para tipo de pagamento selecionado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cd_fornecedor.Focus();
                        return;
                    }
                    else if (tp_pagamento.SelectedIndex.Equals(1) && string.IsNullOrWhiteSpace(cd_funcionario.Text))
                    {
                        MessageBox.Show("Obrigatório informar funcionário para tipo de pagamento selecionado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cd_funcionario.Focus();
                        return;
                    }
                    (bsDespesas.Current as CamadaDados.Empreendimento.TRegistro_ExecDespesas).Cd_empresa = vCd_Empresa;
                    (bsDespesas.Current as CamadaDados.Empreendimento.TRegistro_ExecDespesas).Id_orcamentostr = vId_Orcamento;
                    (bsDespesas.Current as CamadaDados.Empreendimento.TRegistro_ExecDespesas).Nr_versaostr = vNr_Versao;

                    //Buscar config abast
                    CamadaDados.Empreendimento.Cadastro.TList_CadCFGEmpreendimento lCfg =
                        CamadaNegocio.Empreendimento.Cadastro.TCN_CadCFGEmpreendimento.Busca((bsDespesas.Current as CamadaDados.Empreendimento.TRegistro_ExecDespesas).Cd_empresa,
                                                                            string.Empty,
                                                                            null);

                    if (lCfg.Count > 0)
                    {
                        if (string.IsNullOrEmpty(lCfg[0].tp_dup))
                        {
                            MessageBox.Show("Não existe Tp.duplicata na CFG.empreendimento cadastrada!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Não existe CFG.empreendimento cadastrado para a empresa informada!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    //Despesa de funcionário com abatimento de adiantamento
                    if (tp_pagamento.SelectedIndex.Equals(1))
                    {
                        //Buscar conf. adiantamento
                        CamadaDados.Financeiro.Cadastros.TList_ConfigAdto lCnfAdto = CamadaNegocio.Financeiro.Cadastros.TCN_CadConfigAdto.Buscar(vCd_Empresa, string.Empty, string.Empty, string.Empty, string.Empty, 0, string.Empty, null);
                        if (lCnfAdto.Count.Equals(0)) { MessageBox.Show("Não existe CFG.adiantamento cadastrado para a empresa informada!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }

                        CamadaDados.Financeiro.Duplicata.TRegistro_LanDuplicata rDup = new CamadaDados.Financeiro.Duplicata.TRegistro_LanDuplicata();
                        rDup.Cd_empresa = vCd_Empresa;
                        rDup.Cd_clifor = cd_funcionario.Text;

                        object lEndClifor = new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco().BuscarEscalar(new Utils.TpBusca[] { new Utils.TpBusca() { vNM_Campo = "a.cd_clifor", vOperador = "=", vVL_Busca = "'" + rDup.Cd_clifor.Trim() + "'" } }, "a.cd_endereco");
                        if (!lEndClifor.Equals(null)) rDup.Cd_endereco = lEndClifor.ToString().Trim();

                        rDup.Tp_docto = 2; //Duplicata
                        rDup.Tp_duplicata = "01";
                        rDup.Tp_mov = lCnfAdto[0].Tp_mov_ADTO_C;
                        rDup.Cd_historico = rDup.Cd_historico_Dup = vCd_Historico = lCnfAdto[0].Cd_historico_ADTO_C;
                        rDup.Cd_portador = lCnfAdto[0].CD_Portador;
                        rDup.Dt_emissao = (bsDespesas.Current as CamadaDados.Empreendimento.TRegistro_ExecDespesas).Dt_execucao;
                        rDup.Vl_documento = (bsDespesas.Current as CamadaDados.Empreendimento.TRegistro_ExecDespesas).vl_executado;
                        rDup.Nr_docto = (bsDespesas.Current as CamadaDados.Empreendimento.TRegistro_ExecDespesas).Nr_docto;
                        DataTable rCond = new CamadaDados.Financeiro.Cadastros.TCD_CadCondPgto().Buscar(null, 1);
                        rDup.Cd_condpgto = rCond.Rows[0].ItemArray[0].ToString();
                        rDup.Cd_moeda = rCond.Rows[0].ItemArray[5].ToString();
                        rDup.Cd_juro = rCond.Rows[0].ItemArray[9].ToString();
                        rDup.Qt_parcelas = 0;
                        DataTable cd_contager = new CamadaDados.Financeiro.Cadastros.TCD_CadContaGer().Buscar(null, 1);
                        if (cd_contager != null) rDup.Cd_contager = cd_contager.Rows[0].ItemArray[0].ToString();
                        rDup.Parcelas.Add(new CamadaDados.Financeiro.Duplicata.TRegistro_LanParcela() { Vl_parcela = rDup.Vl_documento, Dt_vencto = rDup.Dt_emissao, Cd_parcela = 1});
                        rDup.lCred.AddRange(CamadaNegocio.Financeiro.Adiantamento.TCN_LanAdiantamento.Buscar(string.Empty,
                                                                                                              rDup.Cd_empresa,
                                                                                                              rDup.Cd_clifor,
                                                                                                              string.Empty,
                                                                                                              "'C'",
                                                                                                              string.Empty,
                                                                                                              decimal.Zero,
                                                                                                              string.Empty,
                                                                                                              string.Empty,
                                                                                                              decimal.Zero,
                                                                                                              decimal.Zero,
                                                                                                              false,
                                                                                                              false,
                                                                                                              true,
                                                                                                              string.Empty,
                                                                                                              false,
                                                                                                              false,
                                                                                                              string.Empty,
                                                                                                              string.Empty,
                                                                                                              0,
                                                                                                              string.Empty,
                                                                                                              null));
                        if (rDup.lCred.Count.Equals(0)) { MessageBox.Show("Funcionário não possui adiantamento quitado para efetuar o débito de saldo.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }

                        //Validar saldo a devolver do funcionário
                        rDup.lCred.ForEach(p => 
                        {
                            if (rDup.Vl_documento <= p.Vl_total_devolver) rDup.cVl_adiantamento = rDup.Vl_documento;
                        });
                        if (rDup.cVl_adiantamento.Equals(0)) { MessageBox.Show("Crédito do funcionário é menor do que o valor da despesa."); return; } 

                        (bsDespesas.Current as CamadaDados.Empreendimento.TRegistro_ExecDespesas).rDuplicata = rDup;
                    }
                    else
                    {
                        //Procedimento para despesa da empresa
                        using (Financeiro.TFLanDuplicata fDup = new Financeiro.TFLanDuplicata())
                        {
                            fDup.vCd_empresa = vCd_Empresa;
                            fDup.vNm_empresa = vNm_empresa;
                            fDup.vCd_clifor = tp_pagamento.SelectedIndex.Equals(1) ? cd_funcionario.Text : cd_fornecedor.Text;
                            fDup.vNm_clifor = tp_pagamento.SelectedIndex.Equals(1) ? nm_funcionario.Text : nm_fornecedor.Text;
                            //Buscar endereco
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
                                if (string.IsNullOrEmpty(lCfg[0].tp_dup))
                                {
                                    MessageBox.Show("Não existe Tp.duplicata na CFG.empreendimento cadastrada!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                                fDup.vTp_docto = lCfg[0].tp_docto;
                                fDup.vDs_tpdocto = lCfg[0].ds_docto;
                                fDup.vTp_duplicata = string.Empty;
                                fDup.vDs_tpduplicata = string.Empty;
                                fDup.vTp_mov = "P";
                                fDup.vDt_emissao = (bsDespesas.Current as CamadaDados.Empreendimento.TRegistro_ExecDespesas).Dt_execucaostr;
                                fDup.vVl_documento = (bsDespesas.Current as CamadaDados.Empreendimento.TRegistro_ExecDespesas).vl_executado;
                                fDup.vNr_docto = (bsDespesas.Current as CamadaDados.Empreendimento.TRegistro_ExecDespesas).Nr_docto;
                                fDup.St_bloquearccusto = true;
                                if (fDup.ShowDialog() == DialogResult.OK)
                                {
                                    if (fDup.dsDuplicata.Count > 0)
                                        (bsDespesas.Current as CamadaDados.Empreendimento.TRegistro_ExecDespesas).rDuplicata = fDup.dsDuplicata.Current as CamadaDados.Financeiro.Duplicata.TRegistro_LanDuplicata;

                                    vCd_Historico = fDup.vCd_historico;
                                }
                            }
                            else
                            {
                                MessageBox.Show("Não existe configuração frota para lançar duplicata!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }
                    }
                    if (CamadaNegocio.ConfigGer.TCN_CadParamGer.BuscaVL_Bool("CRESULTADO_EMPRESA",
                                                                             vCd_Empresa,
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
                                                vVL_Busca = "'" + vCd_Historico.Trim() + "'"
                                            }
                                        }, "a.cd_centroresult");
                        if (obj == null ? false : !string.IsNullOrEmpty(obj.ToString()))
                        {
                            (bsDespesas.Current as CamadaDados.Empreendimento.TRegistro_ExecDespesas).lCCusto.Add(
                                new CamadaDados.Financeiro.CCustoLan.TRegistro_LanCCustoLancto()
                                {
                                    Cd_empresa = vCd_Empresa,
                                    Cd_centroresult = obj.ToString(),
                                    Vl_lancto = (bsDespesas.Current as CamadaDados.Empreendimento.TRegistro_ExecDespesas).vl_executado,
                                    Dt_lancto = (bsDespesas.Current as CamadaDados.Empreendimento.TRegistro_ExecDespesas).Dt_execucao,
                                    Tp_registro = "A"
                                });
                        }
                        else
                            using (Financeiro.TFRateioCResultado fRateio = new Financeiro.TFRateioCResultado())
                            {
                                fRateio.vVl_Documento = (bsDespesas.Current as CamadaDados.Empreendimento.TRegistro_ExecDespesas).vl_executado;
                                fRateio.Tp_mov = "P";
                                fRateio.Dt_movimento = (bsDespesas.Current as CamadaDados.Empreendimento.TRegistro_ExecDespesas).Dt_execucao;
                                if (fRateio.ShowDialog() == DialogResult.OK)
                                {
                                    (bsDespesas.Current as CamadaDados.Empreendimento.TRegistro_ExecDespesas).lCCusto = fRateio.lCResultado;
                                }
                                else
                                    return;
                            }
                    }
                    try
                    {
                        CamadaNegocio.Empreendimento.TCN_ExecDespesas.Gravar(bsDespesas.Current as CamadaDados.Empreendimento.TRegistro_ExecDespesas, null);
                        MessageBox.Show("Despesa gravada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
        }

        private void FExecucaoDespesas_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            System.Collections.ArrayList cbx = new System.Collections.ArrayList();
            cbx.Add(new Utils.TDataCombo("EMPRESA", "E"));
            cbx.Add(new Utils.TDataCombo("FUNCIONARIO", "F"));
            tp_pagamento.DataSource = cbx;
            tp_pagamento.DisplayMember = "Display";
            tp_pagamento.ValueMember = "Value";
            bsDespesas.AddNew();
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Deseja cancelar?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                 MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                this.DialogResult = DialogResult.Cancel;
        }

        private void FExecucaoDespesas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                bbBuscar_Click(this, new EventArgs());
            if (e.KeyCode.Equals(Keys.F6))
                bb_cancelar_Click(this, new EventArgs());

        }

        private void CD_CLIFOR_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|" + cd_fornecedor.Text.Trim() + "",
             new Componentes.EditDefault[] { cd_fornecedor, nm_fornecedor }, new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void id_regDesp_Leave(object sender, EventArgs e)
        {
            string vParam = "a.id_regdesp|=|'" + id_regDesp.Text.Trim() + "';" +
                "a.nr_versao|=| " + vNr_Versao + ";" +
                          "a.id_orcamento|=| " + vId_Orcamento + ";" +
                          "a.vl_subtotal |<>| a.vl_executado ";

            DataRow line = FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { id_regDesp, ds_desp },
                                    new CamadaDados.Empreendimento.TCD_Despesas());

            if (line != null)
            {
                valor.Value = Convert.ToDecimal(line["vl_subtotal"].ToString()) - Convert.ToDecimal(line["vl_executado"].ToString());
                valor_total.Value = Convert.ToDecimal(line["vl_subtotal"].ToString()) - Convert.ToDecimal(line["vl_executado"].ToString());
                id_regDesp.Text = line["id_regdesp"].ToString();
            }
        }

        private void valor_Leave(object sender, EventArgs e)
        {
            if (valor_total.Value < valor.Value)
            {
                if (!CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin, "PERMITIR FATURAR MAIORES VALORES", null))
                    using (Proc_Commoditties.TFLanSessaoPDV fSessao = new Proc_Commoditties.TFLanSessaoPDV())
                    {
                        fSessao.Mensagem = "Usuário sem permissão de APROVAR";
                        if (fSessao.ShowDialog() == DialogResult.OK)
                        {
                            if (!CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(fSessao.Usuario, "PERMITIR FATURAR MAIORES VALORES", null))
                            {
                                MessageBox.Show("Usuário não tem permissão!");
                                valor.Value = valor_total.Value;
                                return;
                            }
                        }
                        else
                            return;
                    }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (Financeiro.Cadastros.TFCadCliforResumido fClifor = new Financeiro.Cadastros.TFCadCliforResumido())
            {
                if (fClifor.ShowDialog() == DialogResult.OK)
                    if (fClifor.rClifor != null)
                        try
                        {
                            CamadaNegocio.Financeiro.Cadastros.TCN_CadClifor.Gravar(fClifor.rClifor, null);
                            cd_fornecedor.Text = fClifor.rClifor.Cd_clifor;
                            nm_fornecedor.Text = fClifor.rClifor.Nm_clifor;
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void bbFuncionario_Click(object sender, EventArgs e)
        {
            string vParam = "isnull(a.st_funcionarios, 'N')|=|'S';" +
                            "isnull(a.st_funcativo, 'A')|<>|'C';" +
                                "isnull(a.st_registro, 'C')|=|'A'";
            FormBusca.UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_funcionario, nm_funcionario }, vParam);
        }

        private void cd_funcionario_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_clifor|=|'" + cd_funcionario.Text.Trim() + "';" +
                            "isnull(a.st_funcionarios, 'N')|=|'S';" +
                            "isnull(a.st_funcativo, 'A')|<>|'C';" +
                            "isnull(a.st_registro, 'C')|=|'A'";
            FormBusca.UtilPesquisa.EDIT_LeaveClifor(vParam, new Componentes.EditDefault[] { cd_funcionario, nm_funcionario },
                new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void tp_pagamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblFuncionario.Visible = tp_pagamento.SelectedIndex.Equals(1);
            cd_funcionario.Visible = tp_pagamento.SelectedIndex.Equals(1);
            bbFuncionario.Visible = tp_pagamento.SelectedIndex.Equals(1);
            nm_funcionario.Visible = tp_pagamento.SelectedIndex.Equals(1);
        }

        private void cd_funcionario_VisibleChanged(object sender, EventArgs e)
        {
            if (!cd_funcionario.Visible)
            {
                cd_funcionario.Clear();
                nm_funcionario.Clear();
                cd_fornecedor.Enabled = true;
                bb_fornecedor.Enabled = true;
                button1.Enabled = true;
            }
            else
            {
                cd_fornecedor.Enabled = false;
                bb_fornecedor.Enabled = false;
                button1.Enabled = false;
            }
        }
    }
}
