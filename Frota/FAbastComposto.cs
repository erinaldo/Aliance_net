using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FormBusca;
using Componentes;
using CamadaDados.Financeiro.Cadastros;


namespace Frota
{
    public partial class TFAbastComposto : Form
    {
        private Utils.TTpModo tpModo = Utils.TTpModo.tm_Standby;
        public string vCd_empresa = string.Empty;
        public string vNm_empresa = string.Empty;
        public string vId_veiculo = string.Empty;
        public string vDs_veiculo = string.Empty;
        public string vCd_clifor = string.Empty;
        public string vCd_endereco = string.Empty;
        public string vDs_endereco = string.Empty;
        private CamadaDados.Frota.Cadastros.TList_CfgFrota lCfg
        { get; set; }
        private CamadaDados.Financeiro.Cadastros.TList_CadClifor lFornec
        { get; set; }
        private CamadaDados.Financeiro.Cadastros.TRegistro_CadClifor rCliforEmit
        { get; set; }
        private CamadaDados.Faturamento.NotaFiscal.TRegistro_ItensXMLNFe rItem
        { get; set; }
        private CamadaDados.Frota.TRegistro_AbastVeiculo rabast;
        public CamadaDados.Frota.TRegistro_AbastVeiculo rAbast
        {
            get
            {
                if (bsAbastComposto.Current != null)
                    return bsAbastComposto.Current as CamadaDados.Frota.TRegistro_AbastVeiculo;
                else
                    return null;
            }
            set { rabast = value; }
        }

        public TFAbastComposto()
        {
            InitializeComponent();
            this.lCfg = new CamadaDados.Frota.Cadastros.TList_CfgFrota();

            System.Collections.ArrayList cbx1 = new System.Collections.ArrayList();
            cbx1.Add(new Utils.TDataCombo("EMPRESA", "E"));
            cbx1.Add(new Utils.TDataCombo("MOTORISTA", "M"));
            tp_pagamento.DataSource = cbx1;
            tp_pagamento.DisplayMember = "Display";
            tp_pagamento.ValueMember = "Value";
        }

        #region Metodos Abastecimentos
        private void NovoAbastecimento()
        {
            if (pDados.validarCampoObrigatorio())
            {
                tpModo = Utils.TTpModo.tm_Insert;
                bb_novo_abastecimento.Enabled = false;
                bb_alterar_abastecimento.Enabled = false;
                bb_gravar_abastecimento.Enabled = true;
                bb_excluir_abastecimento.Enabled = true;
                pAbastecimento.HabilitarControls(true, tpModo);
            }
        }

        private void AlterarAbastecimento()
        {
            if (bsAbastComposto.Current != null)
            {
                tpModo = Utils.TTpModo.tm_Edit;
                pDados.HabilitarControls(false, tpModo);
                cd_empresa.Text = (bsAbastComposto.Current as CamadaDados.Frota.TRegistro_AbastVeiculo).Cd_empresa;
                if (!string.IsNullOrEmpty(cd_empresa.Text.Trim())) cd_empresa_Leave(this, new EventArgs());
                id_viagem.Text = (bsAbastComposto.Current as CamadaDados.Frota.TRegistro_AbastVeiculo).Id_viagemstr;
                if (!string.IsNullOrEmpty(id_viagem.Text.Trim())) id_viagem_Leave(this, new EventArgs());
                cd_clifor.Text = (bsAbastComposto.Current as CamadaDados.Frota.TRegistro_AbastVeiculo).Cd_fornecedor;
                if (!string.IsNullOrEmpty(cd_clifor.Text.Trim())) cd_clifor_Leave(this, new EventArgs());
                id_despesa.Text = (bsAbastComposto.Current as CamadaDados.Frota.TRegistro_AbastVeiculo).Id_despesastr;
                id_veiculo.Text = (bsAbastComposto.Current as CamadaDados.Frota.TRegistro_AbastVeiculo).Id_veiculostr;
                if (!string.IsNullOrEmpty(id_veiculo.Text.Trim())) id_veiculo_Leave(this, new EventArgs());
                ds_veiculo.Text = (bsAbastComposto.Current as CamadaDados.Frota.TRegistro_AbastVeiculo).Ds_veiculo.ToString();
                cd_produto.Text = (bsAbastComposto.Current as CamadaDados.Frota.TRegistro_AbastVeiculo).Cd_produto.ToString();
                if (!string.IsNullOrEmpty(cd_produto.Text.Trim())) cd_produto_Leave(this, new EventArgs());
                ds_produto.Text = (bsAbastComposto.Current as CamadaDados.Frota.TRegistro_AbastVeiculo).Ds_produto.ToString();
                dt_abastecimento.Text = (bsAbastComposto.Current as CamadaDados.Frota.TRegistro_AbastVeiculo).Dt_abastecimentostr;
                km_abastecimento.Value = (bsAbastComposto.Current as CamadaDados.Frota.TRegistro_AbastVeiculo).Km_atual;
                nr_notafiscalAbast.Text = (bsAbastComposto.Current as CamadaDados.Frota.TRegistro_AbastVeiculo).Nr_notafiscal.ToString();
                volume.Value = (bsAbastComposto.Current as CamadaDados.Frota.TRegistro_AbastVeiculo).Volume;
                vl_unitarioAbast.Value = (bsAbastComposto.Current as CamadaDados.Frota.TRegistro_AbastVeiculo).Vl_unitario;
                vl_subtotalAbast.Value = (bsAbastComposto.Current as CamadaDados.Frota.TRegistro_AbastVeiculo).Vl_subtotal;
                ds_observacaoAbast.Text = (bsAbastComposto.Current as CamadaDados.Frota.TRegistro_AbastVeiculo).Ds_observacao.ToString();

                gAbastecimento.Enabled = false;
                bb_novo_abastecimento.Enabled = false;
                bb_alterar_abastecimento.Enabled = false;
                bb_gravar_abastecimento.Enabled = true;
                bb_excluir_abastecimento.Enabled = false;
                pAbastecimento.HabilitarControls(true, tpModo);
            }
            else
            {
                MessageBox.Show("Selecione algum registro na lista de abastecimento, caso exista.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void ExcluirAbastecimento()
        {
            if (tpModo == Utils.TTpModo.tm_Insert)
            {
                tpModo = Utils.TTpModo.tm_Standby;
                bb_novo_abastecimento.Enabled = true;
                bb_alterar_abastecimento.Enabled = true;
                bb_gravar_abastecimento.Enabled = false;
                bb_excluir_abastecimento.Enabled = true;
                pAbastecimento.LimparRegistro();
                pAbastecimento.HabilitarControls(false, tpModo);
                return;
            }
            if (bsAbastComposto.Current != null)
                if (MessageBox.Show("Confirma exclusão da despesa selecionada?", "Pergunta", MessageBoxButtons.YesNo,
                         MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    bsAbastComposto.RemoveCurrent();
                    pAbastecimento.LimparRegistro();
                    tpModo = Utils.TTpModo.tm_Standby;
                    pAbastecimento.HabilitarControls(false, tpModo);
                }
            calculaTotalizador();
        }

        private void GravarAbastecimento()
        {
            if (pAbastecimento.validarCampoObrigatorio() && pDados.validarCampoObrigatorio())
            {
                if (tpModo == Utils.TTpModo.tm_Insert)
                {
                    //Validar nota fiscal de acordo com fornecedor
                    if (!string.IsNullOrEmpty(nr_notafiscalAbast.Text))
                    {
                        if (bsAbastComposto.Count > 0)
                            if ((bsAbastComposto.List as IEnumerable<CamadaDados.Frota.TRegistro_AbastVeiculo>).ToList().Exists(x => x.Nr_notafiscal.Equals(nr_notafiscalAbast.Text.Trim()) && x.Cd_fornecedor.Equals(cd_clifor.Text.Trim())))
                            {
                                if (MessageBox.Show("Já existe na listagem de abastecimento, um lançamento com o número de nota fiscal: " + nr_notafiscalAbast.Text +
                                    ". Com o nome de fornecedor: " + nm_fornecedor.Text.Trim() + ". Deseja lançar novamente?",
                                    "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                                    return;
                            }

                        DataTable rAbast = new CamadaDados.Frota.TCD_AbastVeiculo().Buscar(new Utils.TpBusca[] {
                        new Utils.TpBusca() { vNM_Campo = "a.NR_NotaFiscal", vOperador = "=", vVL_Busca = "'" + nr_notafiscalAbast.Text.Trim() + "'" },
                        new Utils.TpBusca() {vNM_Campo = "a.NM_Fornecedor", vOperador = "=", vVL_Busca = "'" + nm_fornecedor.Text.Trim() + "'"} }, 1);
                        if (rAbast.Rows.Count > 0)
                            if (MessageBox.Show("Já existe um registro de abastecimento composto, com o número de nota fiscal: " + nr_notafiscalAbast.Text +
                                ". Com o nome de fornecedor: " + nm_fornecedor.Text.Trim() + "Deseja lançar novamente?",
                                    "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                                return;
                    }

                    bsAbastComposto.AddNew();
                    (bsAbastComposto.Current as CamadaDados.Frota.TRegistro_AbastVeiculo).Cd_empresa = cd_empresa.Text;
                    if (!string.IsNullOrEmpty(id_viagem.Text))
                        (bsAbastComposto.Current as CamadaDados.Frota.TRegistro_AbastVeiculo).Id_viagem = decimal.Parse(id_viagem.Text);
                    (bsAbastComposto.Current as CamadaDados.Frota.TRegistro_AbastVeiculo).Id_veiculo = decimal.Parse(id_veiculo.Text);
                    (bsAbastComposto.Current as CamadaDados.Frota.TRegistro_AbastVeiculo).Ds_veiculo = ds_veiculo.Text;
                    (bsAbastComposto.Current as CamadaDados.Frota.TRegistro_AbastVeiculo).Id_despesa = decimal.Parse(id_despesa.Text);
                    (bsAbastComposto.Current as CamadaDados.Frota.TRegistro_AbastVeiculo).Ds_despesa = ds_despesa.Text;
                    (bsAbastComposto.Current as CamadaDados.Frota.TRegistro_AbastVeiculo).Cd_produto = cd_produto.Text;
                    (bsAbastComposto.Current as CamadaDados.Frota.TRegistro_AbastVeiculo).Ds_produto = ds_produto.Text;
                    (bsAbastComposto.Current as CamadaDados.Frota.TRegistro_AbastVeiculo).Dt_abastecimento = DateTime.Parse(dt_abastecimento.Text);
                    (bsAbastComposto.Current as CamadaDados.Frota.TRegistro_AbastVeiculo).Km_atual = decimal.Parse(km_abastecimento.Value.ToString());
                    (bsAbastComposto.Current as CamadaDados.Frota.TRegistro_AbastVeiculo).Nr_notafiscal = nr_notafiscalAbast.Text.Trim();
                    (bsAbastComposto.Current as CamadaDados.Frota.TRegistro_AbastVeiculo).Cd_fornecedor = cd_clifor.Text;
                    (bsAbastComposto.Current as CamadaDados.Frota.TRegistro_AbastVeiculo).Nm_fornecedor = nm_fornecedor.Text;
                    (bsAbastComposto.Current as CamadaDados.Frota.TRegistro_AbastVeiculo).Volume = decimal.Parse(volume.Value.ToString());
                    (bsAbastComposto.Current as CamadaDados.Frota.TRegistro_AbastVeiculo).Vl_unitario = decimal.Parse(vl_unitarioAbast.Value.ToString());
                    (bsAbastComposto.Current as CamadaDados.Frota.TRegistro_AbastVeiculo).Vl_subtotal = decimal.Parse(vl_subtotalAbast.Value.ToString());
                    (bsAbastComposto.Current as CamadaDados.Frota.TRegistro_AbastVeiculo).Tp_pagamento = tp_pagamento.Text.Equals("EMPRESA") ? "E" : "M";
                    (bsAbastComposto.Current as CamadaDados.Frota.TRegistro_AbastVeiculo).Tipo_pagamento = tp_pagamento.Text;
                    (bsAbastComposto.Current as CamadaDados.Frota.TRegistro_AbastVeiculo).Tp_abastecimento = "TERCEIRO";
                    (bsAbastComposto.Current as CamadaDados.Frota.TRegistro_AbastVeiculo).Tipo_abastecimento = "T";
                    (bsAbastComposto.Current as CamadaDados.Frota.TRegistro_AbastVeiculo).Ds_observacao = ds_observacaoAbast.Text;
                    if (ds_despesa.Text.Trim().Equals("ABASTECIMENTO"))
                    {
                        (bsAbastComposto.Current as CamadaDados.Frota.TRegistro_AbastVeiculo).Tipo_registro = "ABASTECIMENTO";
                        (bsAbastComposto.Current as CamadaDados.Frota.TRegistro_AbastVeiculo).Tp_registro = "A";
                    }
                }
                else
                {
                    //Alteracao
                    (bsAbastComposto.Current as CamadaDados.Frota.TRegistro_AbastVeiculo).Id_veiculostr = id_veiculo.Text;
                    (bsAbastComposto.Current as CamadaDados.Frota.TRegistro_AbastVeiculo).Ds_veiculo = ds_veiculo.Text;
                    (bsAbastComposto.Current as CamadaDados.Frota.TRegistro_AbastVeiculo).Cd_produto = cd_produto.Text;
                    (bsAbastComposto.Current as CamadaDados.Frota.TRegistro_AbastVeiculo).Ds_produto = ds_produto.Text;
                    (bsAbastComposto.Current as CamadaDados.Frota.TRegistro_AbastVeiculo).Dt_abastecimentostr = dt_abastecimento.Text;
                    (bsAbastComposto.Current as CamadaDados.Frota.TRegistro_AbastVeiculo).Km_atual = decimal.Parse(km_abastecimento.Value.ToString());
                    (bsAbastComposto.Current as CamadaDados.Frota.TRegistro_AbastVeiculo).Nr_notafiscal = nr_notafiscalAbast.Text;
                    (bsAbastComposto.Current as CamadaDados.Frota.TRegistro_AbastVeiculo).Volume = decimal.Parse(volume.Value.ToString());
                    (bsAbastComposto.Current as CamadaDados.Frota.TRegistro_AbastVeiculo).Vl_unitario = decimal.Parse(vl_unitarioAbast.Value.ToString());
                    (bsAbastComposto.Current as CamadaDados.Frota.TRegistro_AbastVeiculo).Vl_subtotal = decimal.Parse(vl_subtotalAbast.Value.ToString());
                    (bsAbastComposto.Current as CamadaDados.Frota.TRegistro_AbastVeiculo).Tp_pagamento = tp_pagamento.Text.Equals("EMPRESA") ? "E" : "M";
                    (bsAbastComposto.Current as CamadaDados.Frota.TRegistro_AbastVeiculo).Tipo_pagamento = tp_pagamento.Text;
                    (bsAbastComposto.Current as CamadaDados.Frota.TRegistro_AbastVeiculo).Tp_abastecimento = "TERCEIRO";
                    (bsAbastComposto.Current as CamadaDados.Frota.TRegistro_AbastVeiculo).Tipo_abastecimento = "T";
                    (bsAbastComposto.Current as CamadaDados.Frota.TRegistro_AbastVeiculo).Placa = placa.Text;
                    (bsAbastComposto.Current as CamadaDados.Frota.TRegistro_AbastVeiculo).Ds_observacao = ds_observacaoAbast.Text;
                    bsAbastComposto.ResetCurrentItem();
                    gAbastecimento.Enabled = true;
                }
                tpModo = Utils.TTpModo.tm_Standby;
                bb_novo_abastecimento.Enabled = true;
                bb_alterar_abastecimento.Enabled = true;
                bb_gravar_abastecimento.Enabled = false;
                bb_excluir_abastecimento.Enabled = true;
                pAbastecimento.LimparRegistro();
                pAbastecimento.HabilitarControls(false, tpModo);
            }

            calculaTotalizador();

        }

        private void afterGrava()
        {
            if (bsAbastComposto.Count > 0)
            {
                CamadaDados.Financeiro.Duplicata.TRegistro_LanDuplicata rDup = null;
                if ((bsAbastComposto.List as IEnumerable<CamadaDados.Frota.TRegistro_AbastVeiculo>).ToList().Exists(x => x.Tp_pagamento.Trim().ToUpper().Equals("E")))
                {
                    using (Financeiro.TFLanDuplicata fDup = new Financeiro.TFLanDuplicata())
                    {
                        fDup.vCd_empresa = (bsAbastComposto.Current as CamadaDados.Frota.TRegistro_AbastVeiculo).Cd_empresa;
                        fDup.vNm_empresa = (bsAbastComposto.Current as CamadaDados.Frota.TRegistro_AbastVeiculo).Nm_empresa;
                        fDup.vCd_clifor = (bsAbastComposto.Current as CamadaDados.Frota.TRegistro_AbastVeiculo).Cd_fornecedor;
                        fDup.vNm_clifor = (bsAbastComposto.Current as CamadaDados.Frota.TRegistro_AbastVeiculo).Nm_fornecedor;
                        //Buscar config abast
                        CamadaDados.Frota.Cadastros.TList_CfgFrota lCfg =
                            CamadaNegocio.Frota.Cadastros.TCN_CfgFrota.Buscar((bsAbastComposto.Current as CamadaDados.Frota.TRegistro_AbastVeiculo).Cd_empresa,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              null);
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
                            fDup.vDt_emissao = CamadaDados.UtilData.Data_Servidor().ToString("dd/MM/yyyy");
                            fDup.vVl_documento = (bsAbastComposto.List as IEnumerable<CamadaDados.Frota.TRegistro_AbastVeiculo>).ToList().Where(x => x.Tp_pagamento.Trim().ToUpper().Equals("E")).Sum(x => x.Vl_subtotal);
                            fDup.vNr_docto = "AGPABAST";
                            fDup.vSt_ecf = true;
                            fDup.St_bloquearccusto = true; //Centro Resultado sera lancado pelo modulo frota
                            fDup.St_editardataemissao = true;
                            if (fDup.ShowDialog() == DialogResult.OK)
                                if (fDup.dsDuplicata.Count > 0)
                                {
                                    rDup = fDup.dsDuplicata.Current as CamadaDados.Financeiro.Duplicata.TRegistro_LanDuplicata;
                                    rDup.Vl_documento_padrao = (bsAbastComposto.List as IEnumerable<CamadaDados.Frota.TRegistro_AbastVeiculo>).ToList().Where(x => x.Tp_pagamento.Trim().ToUpper().Equals("E")).Sum(x => x.Vl_subtotal);
                                    rDup.Parcelas[0].Vl_parcela_padrao = rDup.Parcelas[0].Vl_parcela;
                                }
                        }
                        else
                        {
                            MessageBox.Show("Não existe configuração frota para lançar duplicata!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                }
                try
                {
                    CamadaNegocio.Frota.TCN_AbastVeiculo.Gravar((bsAbastComposto.List as IEnumerable<CamadaDados.Frota.TRegistro_AbastVeiculo>).ToList(), rDup, null);
                    MessageBox.Show("Abastecimentos gravados com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    bb_novo_abastecimento.Enabled = true;
                    bb_alterar_abastecimento.Enabled = true;
                    bb_gravar_abastecimento.Enabled = false;
                    bb_excluir_abastecimento.Enabled = true;
                    bsAbastComposto.Clear();
                    pAbastecimento.HabilitarControls(false, Utils.TTpModo.tm_Standby);
                    pAbastecimento.LimparRegistro();
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void calculaTotalizador()
        {
            tot_subvalor.Value = (bsAbastComposto.List as IEnumerable<CamadaDados.Frota.TRegistro_AbastVeiculo>).ToList().Sum(p => p.Vl_subtotal);
            tot_unitario.Value = (bsAbastComposto.List as IEnumerable<CamadaDados.Frota.TRegistro_AbastVeiculo>).ToList().Sum(p => p.Vl_unitario);
            tot_volume.Value = (bsAbastComposto.List as IEnumerable<CamadaDados.Frota.TRegistro_AbastVeiculo>).ToList().Sum(p => p.Volume);
        }

        #endregion

        private void cd_empresa_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "'",
                                                    new Componentes.EditDefault[] { cd_empresa, nm_empresa });
        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { cd_empresa, nm_empresa }, string.Empty);
        }

        private void TFAbastComposto_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pDados.set_FormatZero();
            pAbastecimento.set_FormatZero();
        }

        private void id_viagem_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(id_viagem.Text))
            {
                string vParam = "a.id_viagem|=|" + id_viagem.Text + ";" +
                                "a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "';" +
                                            "isnull(a.st_viagem, 'P')|in|('P', 'E')";
                //if (!string.IsNullOrEmpty(id_veiculo.Text))
                //vParam += ";a.id_veiculo|=|" + id_veiculo.Text;
                FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { id_viagem, ds_viagem, id_veiculo, ds_veiculo, placa },
                                                          new CamadaDados.Frota.TCD_Viagem());
            }
            else
            {
                ds_viagem.Text = "";
            }

        }

        private void bb_viagem_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_viagem|Descrição Viagem|200;" +
                              "a.id_viagem|Codigo|80;" +
                              "c.ds_veiculo|Veiculo|150;" +
                              "c.placa|Placa|80;" +
                              "a.id_veiculo|Id. Veiculo|80";
            string vParam = "a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "';" +
                            "isnull(a.st_viagem, 'P')|in|('P', 'E')";
            //if (!string.IsNullOrEmpty(id_veiculo.Text))
            //vParam += ";a.id_veiculo|=|" + id_veiculo.Text;

            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { id_viagem, ds_viagem, id_veiculo, ds_veiculo, placa },
                                            new CamadaDados.Frota.TCD_Viagem(), vParam);
        }

        private void id_veiculo_Leave(object sender, EventArgs e)
        {
            string vParam = "a.id_veiculo|=|'" + id_veiculo.Text.Trim() + "';" +
                              "isnull(a.st_registro, 'A')|<>|'I';" +
                              "|EXISTS|(select * from tb_div_tpveiculo x " +
                              "where a.cd_tpveiculo = x.cd_tpveiculo " +
                              "and x.tp_veiculo = 'T')";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { id_veiculo, ds_veiculo, placa },
                                            new CamadaDados.Frota.Cadastros.TCD_CadVeiculo());
        }

        private void bb_veiculo_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_veiculo|Veiculo|200;" +
                              "a.id_veiculo|Codigo|80;" +
                              "a.placa|Placa|80";
            string vParam = "isnull(a.st_registro, 'A')|<>|'I';" +
                            "|EXISTS|(select * from tb_div_tpveiculo x " +
                             "where a.cd_tpveiculo = x.cd_tpveiculo " +
                             "and x.tp_veiculo = 'T')";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { id_veiculo, ds_veiculo, placa },
                new CamadaDados.Frota.Cadastros.TCD_CadVeiculo(),
               vParam);
        }

        private void id_despesa_Leave(object sender, EventArgs e)
        {
            string vParam = "a.id_despesa|=|" + id_despesa.Text + ";" +
                                        "a.tp_despesa|=|'AB'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { id_despesa, ds_despesa },
                                            new CamadaDados.Frota.Cadastros.TCD_Despesa());
        }

        private void bb_despesa_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_despesa|Descrição Despesa|200;" +
                              "a.id_despesa|Codigo|80";
            string vParam = "a.tp_despesa|=|'AB'";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { id_despesa, ds_despesa },
                                            new CamadaDados.Frota.Cadastros.TCD_Despesa(), vParam);
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void cd_produto_Leave(object sender, EventArgs e)
        {
            DataRow linha = FormBusca.UtilPesquisa.EDIT_LEAVEProduto("a.cd_produto|=|'" + cd_produto.Text.Trim() + "';" +
                                                     "isnull(e.st_combustivel, 'N')|=|'S'",
                                                     new Componentes.EditDefault[] { cd_produto, ds_produto },
                                                     new CamadaDados.Estoque.Cadastros.TCD_CadProduto());
            if (linha != null && rItem != null)
            {
                rItem.Cd_produto = linha["cd_produto"].ToString();
                rItem.Ds_produto = linha["ds_produto"].ToString();
            }
        }

        private void bb_produto_Click(object sender, EventArgs e)
        {
            DataRowView linha = FormBusca.UtilPesquisa.BTN_BuscaProduto(new Componentes.EditDefault[] { cd_produto, ds_produto }, "isnull(e.st_combustivel, 'N')|=|'S'");
            if (linha != null && rItem != null)
            {
                rItem.Cd_produto = linha["cd_produto"].ToString();
                rItem.Ds_produto = linha["ds_produto"].ToString();
            }
        }

        private void cd_clifor_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LEAVE("a.cd_clifor|=|'" + cd_clifor.Text + "'"
                , new Componentes.EditDefault[] { cd_clifor, nm_fornecedor }, new TCD_CadClifor());
        }

        private void bb_fornecedorAbast_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaClifor(new EditDefault[] { cd_clifor, nm_fornecedor }, string.Empty);
        }

        private void bb_novo_abastecimento_Click(object sender, EventArgs e)
        {
            this.NovoAbastecimento();
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

        private void volume_Leave(object sender, EventArgs e)
        {
            calculo();
        }

        private void vl_unitarioAbast_Leave(object sender, EventArgs e)
        {
            calculo();
        }

        private void vl_subtotalAbast_Leave(object sender, EventArgs e)
        {
            calculo();
        }

        private void calculo()
        {
            if (volume.Value.Equals(0) && vl_unitarioAbast.Value > 0 && vl_subtotalAbast.Value > 0) //calculo de volume 
                volume.Value = vl_subtotalAbast.Value / vl_unitarioAbast.Value;

            else if (volume.Value > 0 && vl_unitarioAbast.Value.Equals(0) && vl_subtotalAbast.Value > 0) // calculo de vl unitario
                vl_unitarioAbast.Value = vl_subtotalAbast.Value / volume.Value;

            else if (volume.Value > 0 && vl_unitarioAbast.Value > 0 && vl_subtotalAbast.Value.Equals(0)) // calculo de subtotal
                vl_subtotalAbast.Value = vl_unitarioAbast.Value * volume.Value;

            else
                vl_subtotalAbast.Value = vl_unitarioAbast.Value * volume.Value;

        }
    }
}
