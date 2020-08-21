using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Faturamento
{
    public partial class TFConsultaOrcamentoProjeto : Form
    {
        private bool Altera_Relatorio = false;

        public TFConsultaOrcamentoProjeto()
        {
            InitializeComponent();
        }

        private void LimparFitros()
        {
            nr_orcamento.Clear();
            nm_clifor.Clear();
            ds_endereco.Clear();
            DT_Final.Clear();
            DT_Inicial.Clear();
            cbAberto.Checked = false;
            cbAR.Checked = false;
            cbCancelado.Checked = false;
        }

        private void afterNovo()
        {
            using (TFOrcamentoProjeto fOrc = new TFOrcamentoProjeto())
            {
                fOrc.Text = "NOVO ORÇAMENTO";
                if (fOrc.ShowDialog() == DialogResult.OK)
                    if (fOrc.rOrcamento != null)
                    {
                        try
                        {
                            CamadaNegocio.Faturamento.Orcamento.TCN_Orcamento.Gravar(fOrc.rOrcamento, null);
                            MessageBox.Show("Orçamento gravado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.LimparFitros();
                            nr_orcamento.Text = fOrc.rOrcamento.Nr_orcamentostr;
                            this.afterBusca();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
            }
        }

        private void afterAltera()
        {
            if (bsOrcamento.Current != null)
            {
                if ((bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).St_registro.Trim().ToUpper().Equals("CA"))
                {
                    MessageBox.Show("Não é permitido alterar orçamento CANCELADO.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if ((bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).Vl_faturado > decimal.Zero)
                {
                    MessageBox.Show("Não é permitido alterar orçamento com itens FATURADO.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                using (TFOrcamentoProjeto fOrc = new TFOrcamentoProjeto())
                {
                    fOrc.rOrcamento = (bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento);
                    if (fOrc.ShowDialog() == DialogResult.OK)
                    {
                        if (fOrc.rOrcamento != null)
                        {
                            try
                            {
                                CamadaNegocio.Faturamento.Orcamento.TCN_Orcamento.Gravar(fOrc.rOrcamento, null);
                                MessageBox.Show("Orçamento alterado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    this.LimparFitros();
                    nr_orcamento.Text = fOrc.rOrcamento.Nr_orcamentostr;
                    this.afterBusca();
                }
            }
            else
                MessageBox.Show("Necessario selecionar orçamento para alterar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void afterExclui()
        {
            if (bsOrcamento.Current != null)
            {
                if ((bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).Vl_faturado > decimal.Zero)
                {
                    MessageBox.Show("Não é permitido excluir orçamento com itens FATURADO.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if ((bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).St_registro.Trim().ToUpper().Equals("CA"))
                {
                    MessageBox.Show("Orçamento ja se encontra CANCELADO.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (MessageBox.Show("Confirma cancelamento do orçamento?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                     MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    try
                    {
                        CamadaNegocio.Faturamento.Orcamento.TCN_Orcamento.CancelarOrcamento(bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento, null);
                        MessageBox.Show("Orçamento cancelado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.LimparFitros();
                        cbAberto.Checked = true;
                        this.afterBusca();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
                MessageBox.Show("Obrigatorio selecionar orçamento para excluir.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void afterBusca()
        {
            string cond = string.Empty;
            string virg = string.Empty;
            if (cbAberto.Checked)
            {
                cond = "'AB'";
                virg = ",";
            }
            if (cbAR.Checked)
            {
                cond += virg + "'AR'";
                virg = ",";
            }
            if (cbCancelado.Checked)
            {
                cond += virg + "'CA'";
                virg = ",";
            }
            bsOrcamento.DataSource = CamadaNegocio.Faturamento.Orcamento.TCN_Orcamento.Buscar(nr_orcamento.Text,
                                                                                              cd_empresa.Text,
                                                                                              string.Empty,
                                                                                              cd_vendedor.Text,
                                                                                              string.Empty,
                                                                                              string.Empty,
                                                                                              string.Empty,
                                                                                              nm_clifor.Text,
                                                                                              ds_endereco.Text,
                                                                                              string.Empty,
                                                                                              DT_Inicial.Text,
                                                                                              DT_Final.Text,
                                                                                              decimal.Zero,
                                                                                              decimal.Zero,
                                                                                              cond,
                                                                                              string.Empty,
                                                                                              "S",
                                                                                              nr_orcorigem.Text,
                                                                                              rbFaturado.Checked,
                                                                                              rbSaldoFat.Checked,
                                                                                              string.Empty,
                                                                                              string.Empty,
                                                                                              false,
                                                                                              false,
                                                                                              null);
            bsOrcamento_PositionChanged(this, new EventArgs());
            tcItens_SelectedIndexChanged(this, new EventArgs());
        }

        private void afterPrint()
        {
            if (bsOrcamento.Current != null)
            {
                if (!(bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).St_registro.Trim().ToUpper().Equals("C"))
                {
                    FormRelPadrao.Relatorio Relatorio = new FormRelPadrao.Relatorio();
                    Relatorio.Altera_Relatorio = Altera_Relatorio;

                    //DADOS PERTINENTES PARA A GERAÇÂO DO RELATORIO
                    Relatorio.Nome_Relatorio = this.Name;
                    Relatorio.NM_Classe = this.Name;
                    Relatorio.Modulo = this.Tag.ToString().Substring(0, 3);


                    BindingSource BinEmpresa = new BindingSource();
                    BinEmpresa.DataSource = CamadaNegocio.Diversos.TCN_CadEmpresa.Busca(
                                                                 (bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).Cd_empresa,
                                                                 string.Empty,
                                                                 string.Empty,
                                                                 null);

                    BindingSource BinClifor = new BindingSource();
                    if (!string.IsNullOrEmpty((bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).Cd_clifor))
                        BinClifor.DataSource = CamadaNegocio.Financeiro.Cadastros.TCN_CadClifor.Busca_Clifor((bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).Cd_clifor,
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

                    BindingSource BinEndereco = new BindingSource();
                    if (!string.IsNullOrEmpty((bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).Cd_clifor))
                        BinEndereco.DataSource = CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Buscar(
                                                                        (bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).Cd_clifor,
                                                                        (bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).Cd_endereco,
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
                    BindingSource BinContatos = new BindingSource();
                    if (!string.IsNullOrEmpty((bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).Cd_clifor))
                        BinContatos.DataSource = CamadaNegocio.Financeiro.Cadastros.TCN_CadContatoCliFor.Buscar(string.Empty,
                                                                                                               (bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).Cd_clifor,
                                                                                                                string.Empty,
                                                                                                                string.Empty,
                                                                                                                string.Empty,
                                                                                                                string.Empty,
                                                                                                                string.Empty,
                                                                                                                false,
                                                                                                                false,
                                                                                                                false,
                                                                                                                string.Empty,
                                                                                                                0,
                                                                                                                null);
                    BindingSource BinContatoVend = new BindingSource();
                    BinContatoVend.DataSource = CamadaNegocio.Financeiro.Cadastros.TCN_CadContatoCliFor.Buscar(string.Empty,
                                                                                                               (bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).Cd_vendedor,
                                                                                                               string.Empty,
                                                                                                               string.Empty,
                                                                                                               string.Empty,
                                                                                                               string.Empty,
                                                                                                               string.Empty,
                                                                                                               false,
                                                                                                               false,
                                                                                                               false,
                                                                                                               string.Empty,
                                                                                                               1,
                                                                                                               null);
                    //Buscar %ICMS do Estado
                    if (BinEndereco.Current != null)
                    {
                        object objICMS =
                            new CamadaDados.Financeiro.Cadastros.TCD_CadUf().BuscarEscalar(
                                new Utils.TpBusca[]
                            {
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "a.CD_UF",
                                    vOperador = "=",
                                    vVL_Busca = "'" + (BinEndereco.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadEndereco).Cd_uf.Trim() + "'"
                                }
                            }, "a.PC_AliquotaICMS");
                        if (objICMS != null && !string.IsNullOrEmpty(objICMS.ToString()))
                            (bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).Pc_Icms_UF = Convert.ToDecimal(objICMS);
                    }
                    else if (!string.IsNullOrEmpty((bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).Uf))
                    {
                        object objICMS =
                            new CamadaDados.Financeiro.Cadastros.TCD_CadUf().BuscarEscalar(
                                new Utils.TpBusca[]
                            {
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "a.UF",
                                    vOperador = "=",
                                    vVL_Busca = "'" + (bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).Uf.Trim() + "'"
                                }
                            }, "a.PC_AliquotaICMS");
                        if (objICMS != null && !string.IsNullOrEmpty(objICMS.ToString()))
                            (bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).Pc_Icms_UF = Convert.ToDecimal(objICMS);
                    }

                    BindingSource meu_bind = new BindingSource();
                    meu_bind.DataSource = new CamadaDados.Faturamento.Orcamento.TList_Orcamento() { bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento };
                    Relatorio.Adiciona_DataSource("EMPRESA", BinEmpresa);
                    Relatorio.Adiciona_DataSource("CLIFOR", BinClifor);
                    Relatorio.Adiciona_DataSource("ENDERECO_CLIFOR", BinEndereco);
                    Relatorio.Adiciona_DataSource("ITENS", bsItens);
                    Relatorio.Adiciona_DataSource("CONTATO_CLIFOR", BinContatos);
                    Relatorio.Adiciona_DataSource("CONTATO_VENDEDOR", BinContatoVend);
                    Relatorio.DTS_Relatorio = meu_bind;
                    Relatorio.Ident = "FLan_OrcamentoProjeto";
                    if (BinEmpresa.Current != null)
                        if ((BinEmpresa.Current as CamadaDados.Diversos.TRegistro_CadEmpresa).Img != null)
                            Relatorio.Parametros_Relatorio.Add("IMAGEM_RELATORIO", (BinEmpresa.Current as CamadaDados.Diversos.TRegistro_CadEmpresa).Img);
                    if (!Altera_Relatorio)
                    {
                        //Chamar tela de gerenciamento de impressao
                        using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                        {
                            fImp.St_enabled_enviaremail = true;
                            fImp.pCd_clifor = (bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).Cd_clifor;
                            fImp.pMensagem = "ORÇAMENTO Nº " + (bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).Nr_orcamentostr;
                            if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                                Relatorio.Gera_Relatorio((bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).Nr_orcamentostr,
                                                         fImp.pSt_imprimir,
                                                         fImp.pSt_visualizar,
                                                         fImp.pSt_enviaremail,
                                                         fImp.pSt_exportPdf,
                                                         fImp.Path_exportPdf,
                                                         fImp.pDestinatarios,
                                                         null,
                                                         "ORÇAMENTO Nº " + (bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).Nr_orcamentostr,
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
        }

        private void FaturarOrcamento()
        {
            if (bsOrcamento.Current != null)
            {
                if ((bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).St_registro.Trim().ToUpper().Equals("CA"))
                {
                    MessageBox.Show("Não é permitido faturar orçamento CANCELADO.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (string.IsNullOrEmpty((bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).Cd_clifor))
                {
                    MessageBox.Show("Não é permitido faturar orçamento sem cliente.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (string.IsNullOrEmpty((bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).Cd_endereco))
                {
                    MessageBox.Show("Não é permitido faturar orçamento sem endereço.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (!(bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).lItens.Exists(p => p.Vl_faturar > decimal.Zero))
                {
                    MessageBox.Show("Orçamento não possui item com saldo disponivel para faturar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                CamadaDados.Faturamento.Cadastros.TList_CFGOrcamento lCfg =
                    CamadaNegocio.Faturamento.Cadastros.TCN_CFGOrcamento.Buscar((bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).Cd_empresa,
                                                                                string.Empty,
                                                                                string.Empty,
                                                                                null);
                if (lCfg.Count.Equals(0))
                {
                    MessageBox.Show("Não existe configuração para faturar orçamento na empresa " + (bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).Cd_empresa,
                        "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                using (TFFatOrcProjeto fFat = new TFFatOrcProjeto())
                {
                    fFat.rOrc = bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento;
                    if(fFat.ShowDialog() == DialogResult.OK)
                        try
                        {
                            List<CamadaDados.Faturamento.Pedido.TRegistro_Pedido> lPed =
                            CamadaNegocio.Faturamento.Orcamento.TCN_Orcamento.ProcessarOrcamentoProjeto(fFat.rOrc, lCfg[0], null);
                            if (MessageBox.Show("Pedido(s) gerado(s) com sucesso.\r\nDeseja faturar os pedidos?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                                 MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                            {
                                lPed.ForEach(p =>
                                    {
                                        try
                                        {
                                            //Buscar pedido
                                            p = CamadaNegocio.Faturamento.Pedido.TCN_Pedido.Busca_Registro_Pedido(p.Nr_pedido.ToString(), null);
                                            //Buscar itens pedido
                                            CamadaNegocio.Faturamento.Pedido.TCN_Pedido.Busca_Pedido_Itens(p, false, null);
                                            //Gerar Nota Fiscal
                                            CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento rFat =
                                                Proc_Commoditties.TProcessaPedFaturar.ProcessaPedFaturar(p, false, decimal.Zero);
                                            //Gravar Nota Fiscal
                                            CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.GravarFaturamento(rFat, null, null);
                                            if (new CamadaDados.Faturamento.Cadastros.TCD_CadSerieNF().BuscarEscalar(
                                                new Utils.TpBusca[]
                                            {
                                                new Utils.TpBusca()
                                                {
                                                    vNM_Campo = "a.nr_serie",
                                                    vOperador = "=",
                                                    vVL_Busca = "'" + rFat.Nr_serie.Trim() + "'"
                                                },
                                                new Utils.TpBusca()
                                                {
                                                    vNM_Campo = "a.cd_modelo",
                                                    vOperador = "=",
                                                    vVL_Busca = "'" + rFat.Cd_modelo.Trim() + "'"
                                                },
                                                new Utils.TpBusca()
                                                {
                                                    vNM_Campo = "a.tp_serie",
                                                    vOperador = "<>",
                                                    vVL_Busca = "'S'"
                                                }
                                            }, "1") != null)
                                            {
                                                using (srvNFE.TFGerenciarNFe fGerNfe = new srvNFE.TFGerenciarNFe())
                                                {
                                                    fGerNfe.rNfe = CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.BuscarNF(rFat.Cd_empresa,
                                                                                                                                    rFat.Nr_lanctofiscalstr,
                                                                                                                                    null);
                                                    fGerNfe.ShowDialog();
                                                }
                                            }
                                            else
                                            {
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
                                                }
                                            }
                                        }
                                        catch
                                        { MessageBox.Show("Erro faturar pedido Nº" + p.Nr_pedido.ToString(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                                    });
                            }
                            this.afterBusca();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            }
        }

        private void TFConsultaOrcamentoProjeto_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            this.pFiltro.set_FormatZero();
            Utils.ShapeGrid.RestoreShape(this, gOrcamento);
            Utils.ShapeGrid.RestoreShape(this, gItens);
        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { cd_empresa }, string.Empty);
        }

        private void cd_empresa_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "'", new Componentes.EditDefault[] { cd_empresa });
        }

        private void bb_vendedor_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_vendedor }, "isnull(a.st_vendedor, 'N')|=|'S';isnull(a.st_funcativo, 'N')|=|'S'");
        }

        private void cd_vendedor_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + cd_vendedor.Text.Trim() + "';isnull(a.st_vendedor, 'N')|=|'S';isnull(a.st_funcativo, 'N')|=|'S'",
                new Componentes.EditDefault[] { cd_vendedor }, new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void bb_clifor_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { nm_clifor }, string.Empty);
        }

        private void bb_endereco_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BUSCA("a.ds_endereco|Endereço|200;a.cd_endereco|Codigo|80",
                                    new Componentes.EditDefault[] { ds_endereco },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco(), string.Empty);
        }

        private void bsOrcamento_PositionChanged(object sender, EventArgs e)
        {
            if (bsOrcamento.Current != null)
            {
                (bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).lItens =
                    CamadaNegocio.Faturamento.Orcamento.TCN_Orcamento_Item.Buscar(
                    (bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).Nr_orcamentostr,
                    false,
                    false,
                    null);
                //Buscar Itens Compra
                (bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).lItensCompra =
                    CamadaNegocio.Faturamento.Orcamento.TCN_ItensCompraOrcProj.Buscar((bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).Nr_orcamentostr,
                                                                                       string.Empty,
                                                                                       null);
                (bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).Total_ItensComprados =
                    (bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).lItensCompra.Sum(p => p.Valor);
                bsOrcamento.ResetCurrentItem();
            }
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            this.afterBusca();
        }

        private void BB_Novo_Click(object sender, EventArgs e)
        {
            this.afterNovo();
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BB_Alterar_Click(object sender, EventArgs e)
        {
            this.afterAltera();
        }

        private void gOrcamento_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gOrcamento.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsOrcamento.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento());
            CamadaDados.Faturamento.Orcamento.TList_Orcamento lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gOrcamento.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gOrcamento.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new CamadaDados.Faturamento.Orcamento.TList_Orcamento(lP.Find(gOrcamento.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gOrcamento.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new CamadaDados.Faturamento.Orcamento.TList_Orcamento(lP.Find(gOrcamento.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gOrcamento.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsOrcamento.List as CamadaDados.Faturamento.Orcamento.TList_Orcamento).Sort(lComparer);
            bsOrcamento.ResetBindings(false);
            gOrcamento.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void gOrcamento_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
                if (e.ColumnIndex.Equals(0))
                {
                    if (e.Value.ToString().Trim().ToUpper().Equals("CANCELADO"))
                        gOrcamento.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
                    else if (e.Value.ToString().Trim().ToUpper().Equals("REPROVADO"))
                        gOrcamento.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Maroon;
                    else if (e.Value.ToString().Trim().ToUpper().Equals("PROCESSADO"))
                        gOrcamento.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Blue;
                    else if (e.Value.ToString().Trim().ToUpper().Equals("AGUARDANDO RETORNO"))
                        gOrcamento.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Teal;
                    else
                        gOrcamento.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                }
        }

        private void bb_faturar_Click(object sender, EventArgs e)
        {
            this.FaturarOrcamento();
        }

        private void tcItens_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tcItens.SelectedTab.Equals(tpPedidos) && (bsItens.Current != null))
            {
                BS_Pedido.DataSource = new CamadaDados.Faturamento.Pedido.TCD_Pedido().Select(
                                        new Utils.TpBusca[]
                                        {
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = string.Empty,
                                                vOperador = "exists",
                                                vVL_Busca = "(select 1 from tb_fat_pedido_itens x " +
                                                            "where x.nr_pedido = a.nr_pedido " +
                                                            "and x.nr_orcamento = " + (bsItens.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item).Nr_orcamento.Value.ToString() + " " +
                                                            "and x.id_itemorc = " + (bsItens.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item).Id_item.Value.ToString() + ")"
                                            }
                                        }, 0, string.Empty);
                BS_Pedido_PositionChanged(this, new EventArgs());
            }
            else
            {
                BS_Pedido.Clear();
                BS_Pedido.ResetBindings(true);
            }
        }

        private void BS_Pedido_PositionChanged(object sender, EventArgs e)
        {
            if (BS_Pedido.Current != null)
            {
                (BS_Pedido.Current as CamadaDados.Faturamento.Pedido.TRegistro_Pedido).Pedido_Itens =
                    CamadaNegocio.Faturamento.Pedido.TCN_LanPedido_Item.Busca(string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              (BS_Pedido.Current as CamadaDados.Faturamento.Pedido.TRegistro_Pedido).Nr_pedido.ToString(),
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              false,
                                                                              null);
                BS_Pedido.ResetCurrentItem();
            }
        }

        private void BB_Excluir_Click(object sender, EventArgs e)
        {
            this.afterExclui();
        }

        private void TFConsultaOrcamentoProjeto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F2))
                this.afterNovo();
            else if (e.KeyCode.Equals(Keys.F3))
                this.afterAltera();
            else if (e.KeyCode.Equals(Keys.F5))
                this.afterExclui();
            else if (e.KeyCode.Equals(Keys.F7))
                this.afterBusca();
            else if (e.KeyCode.Equals(Keys.F9))
                this.FaturarOrcamento();
            if (e.Control && (e.KeyCode == Keys.P))
            {
                Altera_Relatorio = true;
                MessageBox.Show("Execute o relatório que deseja alterar!", "Mensagem");
            }
        }

        private void visualizarPedidoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.afterPrint();
        }

        private void relatorioSeparacaooItensDoPedidoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bsOrcamento.Count > 0)
            {
                using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                {
                    FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                    Rel.Altera_Relatorio = Altera_Relatorio;
                    Rel.DTS_Relatorio = bsOrcamento;
                    Rel.Nome_Relatorio = this.Name;
                    Rel.NM_Classe = this.Name;
                    Rel.Modulo = this.Tag.ToString().Substring(0, 3);
                    Rel.Ident = "Sintetico_Orcamento_Projetos";
                    fImp.St_enabled_enviaremail = true;
                    fImp.pCd_clifor = string.Empty;
                    fImp.pMensagem = "RELATORIO SINTETICO ORÇAMENTO PROJETOS";

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
                                           "RELATORIO SINTETICO ORÇAMENTO PROJETOS",
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
                                               "RELATORIO SINTETICO ORÇAMENTO PROJETOS",
                                               fImp.pDs_mensagem);
                }
            }
            else
                MessageBox.Show("Não existe Registros Para Imprimir o Relatório!");
        }

        private void bb_inserirItensCompra_Click(object sender, EventArgs e)
        {
            if (bsOrcamento.Current != null)
                using (TFInserirItensCompra fItens = new TFInserirItensCompra())
                {
                    if (fItens.ShowDialog() == DialogResult.OK)
                        if (fItens.rItem != null)
                            try
                            {
                                fItens.rItem.Dt_compra = CamadaDados.UtilData.Data_Servidor();
                                fItens.rItem.Nr_orcamentostr = (bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).Nr_orcamentostr;
                                CamadaNegocio.Faturamento.Orcamento.TCN_ItensCompraOrcProj.Gravar(fItens.rItem, null);
                                MessageBox.Show("Item gravado com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                tcItens_SelectedIndexChanged(this, new EventArgs());
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
        }

        private void bb_importarXML_Click(object sender, EventArgs e)
        {
            string vColunas = "a.Nr_notafiscal|Nº NF|60;" +
                              "a.cd_clifor|Cd.clifor|80;" +
                              "h.Nm_clifor|Fornecedor|300";
            DataRowView linha = FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, 
                null, new CamadaDados.Faturamento.NotaFiscal.TCD_LanFaturamento(),
            "a.tp_movimento|=|'E'");

            if (linha != null)
            {
                CamadaDados.Faturamento.NotaFiscal.TList_RegLanFaturamento_Item lItensNota =
                    new CamadaDados.Faturamento.NotaFiscal.TCD_LanFaturamento_Item().Select(
                        new Utils.TpBusca[]
                        {
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "a.cd_empresa",
                                vOperador = "=",
                                vVL_Busca = "'" + linha["cd_empresa"].ToString() + "'"
                            },
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "a.nr_lanctofiscal",
                                vOperador = "=",
                                vVL_Busca = linha["nr_lanctofiscal"].ToString()
                            }
                        }, 0,string.Empty, string.Empty, string.Empty);

                using (TFImportarItensNF fItensNF = new TFImportarItensNF())
                {
                    fItensNF.lItensNota = lItensNota;
                    if (fItensNF.ShowDialog() == DialogResult.OK)
                        if (fItensNF.lItensNota.Count > 0)
                            try
                            {
                                CamadaDados.Faturamento.Orcamento.TList_ItensCompraOrcProj lItens =
                                    new CamadaDados.Faturamento.Orcamento.TList_ItensCompraOrcProj();
                                fItensNF.lItensNota.FindAll(p => p.St_processar).ForEach(p =>
                                 {
                                     lItens.Add(new CamadaDados.Faturamento.Orcamento.TRegistro_ItensCompraOrcProj()
                                     {
                                         Nr_orcamentostr = (bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).Nr_orcamentostr,
                                         Cd_produto = p.Cd_produto,
                                         Dt_compra = Convert.ToDateTime(linha["DT_Emissao"].ToString()),
                                         Quantidade = p.Quantidade,
                                         Valor = p.Vl_basecalcImposto
                                     });
                                 });
                                CamadaNegocio.Faturamento.Orcamento.TCN_ItensCompraOrcProj.Gravar(lItens, null);
                                MessageBox.Show("Itens gravados com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                tcItens_SelectedIndexChanged(this, new EventArgs());
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information); }

                }
            }
        }

        private void bb_excluiritem_Click(object sender, EventArgs e)
        {
            if (bsItensCompra.Current != null)
                if (MessageBox.Show("Confirma a exclusão do item selecionado?", "Pergunta", MessageBoxButtons.YesNo, 
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    try
                    {
                        CamadaNegocio.Faturamento.Orcamento.TCN_ItensCompraOrcProj.Excluir(bsItensCompra.Current as CamadaDados.Faturamento.Orcamento.TRegistro_ItensCompraOrcProj, null);
                        MessageBox.Show("Item excluído com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        tcItens_SelectedIndexChanged(this, new EventArgs());
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
    }
}
