using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Utils;
using FormBusca;
using CamadaDados.Financeiro.Caixa;
using CamadaNegocio.Financeiro.Caixa;
using CamadaDados.Financeiro.Cadastros;
using CamadaNegocio.Diversos;

namespace Financeiro
{
    public partial class TFConsultaCaixa : Form
    {
        bool Altera_Relatorio = false;

        public TFConsultaCaixa()
        {
            InitializeComponent();
            panelbusca.set_FormatZero();  
        }

        private void somarValores()
        {
            decimal soma_receber = 0;
            decimal soma_pagar = 0;
            for (int i = 0; i < dataGridcaixa.SelectedRows.Count; i++)
            {
                soma_receber += Convert.ToDecimal(dataGridcaixa.SelectedRows[i].Cells["vlRECEBERDataGridViewTextBoxColumn1"].Value.ToString());
                soma_pagar += Convert.ToDecimal(dataGridcaixa.SelectedRows[i].Cells["vlPAGARDataGridViewTextBoxColumn1"].Value.ToString());
            }
            soma_vlrecebido.Value = soma_receber;
            soma_vlpago.Value = soma_pagar;
        }

        private void ImprimirRecibo()
        {
            if (bindingSourceCaixa.Current != null)
            {
                using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                {
                    //Preencher dados empresa da duplicata
                    BindingSource Empresa = new BindingSource();
                    Empresa.DataSource = TCN_CadEmpresa.Busca((bindingSourceCaixa.Current as TRegistro_LanCaixa).Cd_Empresa, string.Empty, string.Empty, null);
                    decimal valor = (bindingSourceCaixa.Current as TRegistro_LanCaixa).Vl_PAGAR > 0 ?
                        (bindingSourceCaixa.Current as TRegistro_LanCaixa).Vl_PAGAR : (bindingSourceCaixa.Current as TRegistro_LanCaixa).Vl_RECEBER;
                    string Valor_Extenso = string.Empty;
                    string transf = string.Empty;
                    //Buscar Moeda da Conta Gerencial
                    TList_Moeda lMoeda =
                        new TCD_Moeda().Select(
                        new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = string.Empty,
                                vOperador = "exists",
                                vVL_Busca = "(select 1 from tb_fin_contager x "+
                                            "where x.cd_moeda = a.cd_moeda "+
                                            "and x.cd_contager = '" + (bindingSourceCaixa.Current as TRegistro_LanCaixa).Cd_ContaGer.Trim() + "')"
                            }
                        }, 1, string.Empty);
                    if (lMoeda.Count > 0)
                        Valor_Extenso = new Extenso().ValorExtenso(valor, lMoeda[0].Ds_moeda_singular, lMoeda[0].Ds_moeda_plural);
                    else
                        Valor_Extenso = new Extenso().ValorExtenso(valor, "Real", "Reais");
                    //Criar objeto Relatório
                    FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                    BindingSource Bin = new BindingSource();
                    Rel.Altera_Relatorio = Altera_Relatorio;
                    Bin.DataSource = new TList_LanCaixa() { bindingSourceCaixa.Current as TRegistro_LanCaixa };
                    Rel.DTS_Relatorio = Bin;
                    Rel.Nome_Relatorio = "TFConsulatCaixa_Recibo";
                    Rel.NM_Classe = Name;
                    Rel.Ident = "TFConsulatCaixa_Recibo";
                    Rel.Modulo = "FIN";
                    fImp.St_enabled_enviaremail = true;
                    fImp.pCd_clifor = string.Empty;
                    BindingSource moeda = new BindingSource();
                    moeda.DataSource = lMoeda[0];
                    Rel.Parametros_Relatorio.Add("VALOREXTENSO", Valor_Extenso);
                    Rel.Parametros_Relatorio.Add("VALOR", valor);
                    if (bsTransf.Current != null)
                    {
                        Rel.Adiciona_DataSource("TRANSF", bsTransf);
                        transf = "S";
                    }
                    else
                        transf = "N";
                    Rel.Parametros_Relatorio.Add("TRANSFERENCIA", transf);
                    Rel.Adiciona_DataSource("MOEDA", moeda);
                    if (Empresa.Count > 0)
                        if ((Empresa.List[0] as CamadaDados.Diversos.TRegistro_CadEmpresa).Img != null)
                            Rel.Parametros_Relatorio.Add("IMAGEM_RELATORIO", (Empresa.List[0] as CamadaDados.Diversos.TRegistro_CadEmpresa).Img);
                    Rel.Adiciona_DataSource("EMPRESA", Empresa);
                    fImp.pMensagem = "RECIBO DE MOVIMENTAÇÃO CAIXA";

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
                                           "RECIBO DE MOVIMENTAÇÃO CAIXA",
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
                                               "RECIBO DE MOVIMENTAÇÃO CAIXA",
                                               fImp.pDs_mensagem);
                }
            }
        }

        private void afterBusca()
        {
            if (cbContaGer.SelectedItem != null)
            {
                string cheque = string.Empty;
                string estorno = string.Empty;
                if (ST_Cheques.Checked)
                    cheque = string.Empty;
                else
                    cheque = ST_Cheques.Vl_False;

                if (ST_Estorno.Checked)
                    estorno = string.Empty;
                else
                    estorno = ST_Estorno.Vl_False;

                bindingSourceCaixa.DataSource = TCN_LanCaixa.Busca(cbContaGer.SelectedValue.ToString(),
                                                                   string.Empty,
                                                                   string.Empty,
                                                                   nr_docto.Text,
                                                                   cd_historico.Text,
                                                                   string.Empty,
                                                                   DT_Inicial.Text,
                                                                   DT_Final.Text,
                                                                   vl_ini.Value,
                                                                   vl_fin.Value,
                                                                   rgValor.NM_Valor,
                                                                   cheque,
                                                                   estorno,
                                                                   false,
                                                                   string.Empty,
                                                                   0,
                                                                   cbAvulsos.Checked,
                                                                   null);
                //Buscar Totais
                object obj = new CamadaDados.Financeiro.Titulo.TCD_LanTitulo().BuscarEscalar(
                        new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = "isnull(a.status_compensado, 'N')",
                                vOperador = "=",
                                vVL_Busca = "'N'"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "a.tp_titulo",
                                vOperador = "=",
                                vVL_Busca = "'R'"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = string.Empty,
                                vOperador = "exists",
                                vVL_Busca = "(select 1 from tb_fin_titulo_x_caixa x " +
                                            "inner join tb_fin_caixa y " +
                                            "on x.cd_contager = y.cd_contager " +
                                            "and x.cd_lanctocaixa = y.cd_lanctocaixa " +
                                            "where x.cd_empresa = a.cd_empresa " +
                                            "and x.cd_banco = a.cd_banco " +
                                            "and x.nr_lanctocheque = a.nr_lanctocheque " +
                                            "and y.cd_contager = '" + cbContaGer.SelectedValue.ToString() + "' " +
                                            "and isnull(y.st_estorno, 'N') <> 'S')"
                            }
                        }, "isnull(sum(a.vl_titulo), 0)");
                Tot_Ch_REC.Value = obj != null ? decimal.Parse(obj.ToString()) : decimal.Zero;
                obj = new CamadaDados.Financeiro.Titulo.TCD_LanTitulo().BuscarEscalar(
                        new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = "isnull(a.status_compensado, 'N')",
                                vOperador = "=",
                                vVL_Busca = "'N'"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "a.tp_titulo",
                                vOperador = "=",
                                vVL_Busca = "'P'"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = string.Empty,
                                vOperador = "exists",
                                vVL_Busca = "(select 1 from tb_fin_titulo_x_caixa x " +
                                            "inner join tb_fin_caixa y " +
                                            "on x.cd_contager = y.cd_contager " +
                                            "and x.cd_lanctocaixa = y.cd_lanctocaixa " +
                                            "inner join tb_fin_contager z " +
                                            "on y.cd_contager = z.cd_contager_compensacao " +
                                            "where x.cd_empresa = a.cd_empresa " +
                                            "and x.cd_banco = a.cd_banco " +
                                            "and x.nr_lanctocheque = a.nr_lanctocheque " +
                                            "and z.cd_contager = '" + cbContaGer.SelectedValue.ToString() + "' " +
                                            "and isnull(y.st_estorno, 'N') <> 'S')"
                            }
                        }, "isnull(sum(a.vl_titulo), 0)");
                Tot_Ch_PAG.Value = obj != null ? decimal.Parse(obj.ToString()) : decimal.Zero;
                VL_DifCX.Value = TCN_LanCaixa.BuscarSaldoCaixa(cbContaGer.SelectedValue.ToString(), null);
                //Verificar se a conta e de compensacao
                object obj_conta = new TCD_CadContaGer().BuscarEscalar(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = "a.cd_contager",
                            vOperador = "=",
                            vVL_Busca = "'" + cbContaGer.SelectedValue.ToString().Trim() + "'"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "isnull(a.st_contacompensacao, 'N')",
                            vOperador = "=",
                            vVL_Busca = "'S'"
                        }
                    }, "1");
                VL_SaldoLiquido.Value = VL_DifCX.Value - (obj_conta == null ? Tot_Ch_PAG.Value : Tot_Ch_PAG.Value * -1);
                //Buscar Aplicações
                bsSaldoAplic.DataSource = new TCD_SaldoContaGer().Select(string.Empty, cbContaGer.SelectedValue.ToString());
                if (bsSaldoAplic.Count > 0)
                    tlpTotais.ColumnStyles[1].Width = 405;
                else tlpTotais.ColumnStyles[1].Width = 0;
                bindingSourceCaixa_PositionChanged(this, new EventArgs());
            }
            else MessageBox.Show("Obrigatório informar conta gerencial.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BB_Novo_Click(object sender, EventArgs e)
        {
            using (TFLanCaixa FLanCaixa = new TFLanCaixa())
            {
                FLanCaixa.dsLanCaixa.DataSource = bindingSourceCaixa;

                FLanCaixa.dsLanCaixa.AddNew();

                (FLanCaixa.dsLanCaixa.Current as TRegistro_LanCaixa).Vl_Anterior = VL_DifCX.Value;
                (FLanCaixa.dsLanCaixa.Current as TRegistro_LanCaixa).Cd_ContaGer = cbContaGer.SelectedItem != null ? cbContaGer.SelectedValue.ToString() : string.Empty;

                if (FLanCaixa.ShowDialog() == DialogResult.OK)
                {
                    //Lancar Centro Resultado
                    if (CamadaNegocio.ConfigGer.TCN_CadParamGer.BuscaVL_Bool("CRESULTADO_EMPRESA",
                                                                             (FLanCaixa.dsLanCaixa.Current as TRegistro_LanCaixa).Cd_Empresa,
                                                                             null).Trim().ToUpper().Equals("S"))
                    {
                        //Verificar se historico possui centro resultado cadastrado
                        object obj = new TCD_CadHistorico().BuscarEscalar(
                                        new TpBusca[]
                                        {
                                            new TpBusca()
                                            {
                                                vNM_Campo = "a.cd_historico",
                                                vOperador = "=",
                                                vVL_Busca = "'" + (FLanCaixa.dsLanCaixa.Current as TRegistro_LanCaixa).Cd_Historico.Trim() + "'"
                                            }
                                        }, "a.cd_centroresult");
                        if (obj == null ? false : !string.IsNullOrEmpty(obj.ToString()))
                        {
                            (bindingSourceCaixa.Current as TRegistro_LanCaixa).lCustoLancto.Add(
                                new CamadaDados.Financeiro.CCustoLan.TRegistro_LanCCustoLancto()
                                {
                                    Cd_empresa = (bindingSourceCaixa.Current as TRegistro_LanCaixa).Cd_Empresa,
                                    Cd_centroresult = obj.ToString(),
                                    Vl_lancto = (bindingSourceCaixa.Current as TRegistro_LanCaixa).Vl_PAGAR > decimal.Zero ?
                                                (bindingSourceCaixa.Current as TRegistro_LanCaixa).Vl_PAGAR :
                                                (bindingSourceCaixa.Current as TRegistro_LanCaixa).Vl_RECEBER,
                                    Dt_lancto = (bindingSourceCaixa.Current as TRegistro_LanCaixa).Dt_lancto,
                                    Tp_registro = "A"
                                });
                        }
                        else
                            using (TFRateioCResultado fRateio = new TFRateioCResultado())
                            {
                                fRateio.vVl_Documento = (FLanCaixa.dsLanCaixa.Current as TRegistro_LanCaixa).Vl_PAGAR > decimal.Zero ?
                                    (FLanCaixa.dsLanCaixa.Current as TRegistro_LanCaixa).Vl_PAGAR : (FLanCaixa.dsLanCaixa.Current as TRegistro_LanCaixa).Vl_RECEBER;
                                fRateio.Tp_mov = (FLanCaixa.dsLanCaixa.Current as TRegistro_LanCaixa).Vl_PAGAR > decimal.Zero ? "P" : "R";
                                fRateio.Dt_movimento = (FLanCaixa.dsLanCaixa.Current as TRegistro_LanCaixa).Dt_lancto;
                                fRateio.ShowDialog();
                                (FLanCaixa.dsLanCaixa.Current as TRegistro_LanCaixa).lCustoLancto = fRateio.lCResultado;
                                (FLanCaixa.dsLanCaixa.Current as TRegistro_LanCaixa).lCustoLanDel = fRateio.lCResultadoDel;
                            }
                    }
                    try
                    {
                        //Setar como lancamento caixa avulso
                        (FLanCaixa.dsLanCaixa.Current as TRegistro_LanCaixa).St_avulso = "S";
                        TCN_LanCaixa.GravaLanCaixa((bindingSourceCaixa.Current as TRegistro_LanCaixa), null);
                        afterBusca();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        FLanCaixa.dsLanCaixa.CancelEdit();
                    }
                }
                else
                    FLanCaixa.dsLanCaixa.CancelEdit();
            }
        }

        private void BB_Alterar_Click(object sender, EventArgs e)
        {
            if (bindingSourceCaixa.Current != null)
            {
                TFLanCaixa FLanCaixa = new TFLanCaixa();
                FLanCaixa.CD_ContaGer.Enabled = false;
                FLanCaixa.BB_ContaGer.Enabled = false;
                FLanCaixa.CD_Empresa.Enabled = false;
                FLanCaixa.BB_Empresa.Enabled = false;
                FLanCaixa.DT_Lancto.Enabled = false;
                FLanCaixa.RB_Pagar.Enabled = false;
                FLanCaixa.RB_Receber.Enabled = false;
                FLanCaixa.VL_Receber.Enabled = false;
                FLanCaixa.VL_Pagar.Enabled = false;
                FLanCaixa.RB_Receber.Checked = (bindingSourceCaixa.Current as TRegistro_LanCaixa).Vl_RECEBER > 0;
                FLanCaixa.RB_Pagar.Checked = (bindingSourceCaixa.Current as TRegistro_LanCaixa).Vl_PAGAR > 0;
                FLanCaixa.dsLanCaixa.Add(bindingSourceCaixa.Current as TRegistro_LanCaixa);

                if (FLanCaixa.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        TCN_LanCaixa.AlterarLanCaixa((bindingSourceCaixa.Current as TRegistro_LanCaixa), null);
                        afterBusca();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
                MessageBox.Show("Obrigatorio selecionar registro de caixa para alterar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            afterBusca();
        }

        private void TFConsultaCaixa_Load(object sender, EventArgs e)
        {
            ShapeGrid.RestoreShape(this, dataGridcaixa);
            Icon = ResourcesUtils.TecnoAliance_ICO;
            panelbusca.set_FormatZero();
            DT_Inicial.Text = DateTime.Now.Date.ToString("dd/MM/yyyy");
            DT_Final.Text = DateTime.Now.Date.ToString("dd/MM/yyyy");
            
            ShapeGrid.RestoreShape(this, dataGridcaixa);
            BB_Excluir.Visible = TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin, "PERMITIR ESTORNAR CAIXA OU BANCO", null);
            BB_Transfere.Visible = TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin, "PERMITIR TRANSFERENCIA CONTAS", null);
            BB_Novo.Visible = TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin, "PERMITIR LANCAR CAIXA AVULSO", null);
            tlpCaixa.RowStyles[2] = new RowStyle(SizeType.Absolute, 0);
            tlpTotais.ColumnStyles[1].Width = 0;
            cbContaGer.DataSource = new TCD_CadContaGer().Select(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = string.Empty,
                                            vOperador = "exists",
                                            vVL_Busca = "(select 1 from tb_div_usuario_x_contager x " +
                                                        "where x.cd_contager = a.cd_contager " +
                                                        "and x.login = '" + Utils.Parametros.pubLogin.Trim() + "')"
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.st_contacf",
                                            vOperador = "<>",
                                            vVL_Busca = "0"
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.st_contacartao",
                                            vOperador = "<>",
                                            vVL_Busca = "0"
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = "isnull(a.st_contacompensacao, 'N')",
                                            vOperador = "<>",
                                            vVL_Busca = "'S'"
                                        }
                                    }, 0, string.Empty);
            cbContaGer.DisplayMember = "DS_ContaGer";
            cbContaGer.ValueMember = "CD_ContaGer";
            if (cbContaGer.Items.Count > 0)
                cbContaGer.SelectedIndex = 0;
        }

        private void TFConsultaCaixa_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {                
                case (Keys.F2):
                    {
                        if (BB_Novo.Visible)
                            BB_Novo_Click(sender, e); break;
                    }
                case (Keys.F3):
                    {
                        BB_Alterar_Click(sender, e); break;
                    }
                case (Keys.F5):
                    {
                        if (BB_Excluir.Visible)
                            BB_Excluir_Click(sender, e); break;
                    }
                case (Keys.F7):
                    {
                        afterBusca();break;
                    }
                case(Keys.F9):
                    {
                            BB_Recalcula_Click(sender, e);break;
                    }
                case (Keys.F10):
                    {
                        if (BB_Transfere.Visible)
                            BB_Transfere_Click(sender, e); break;
                    }
                case (Keys.F11):
                    {
                            BB_FecharCaixa_Click(sender, e); break;
                    }
                
            }
            if (e.Control && (e.KeyCode == Keys.P))
            {
                Altera_Relatorio = true;
                MessageBox.Show("Execute o relatório que deseja alterar!", "Mensagem");
            }
        }

        private void BB_Excluir_Click(object sender, EventArgs e)
        {
            if (bindingSourceCaixa.Current != null)
            {
                if ((bindingSourceCaixa.Current as TRegistro_LanCaixa).St_Estorno.Trim().ToUpper().Equals("S"))
                {
                    MessageBox.Show("Lançamento de caixa ja esta estornado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (!(bindingSourceCaixa.Current as TRegistro_LanCaixa).Status_avulso)
                {
                    MessageBox.Show("Permitido estornar somente lançamento de caixa avulso.\r\n" +
                                    "Para estornar lançamento de caixa que teve origem em outro processo,\r\n" +
                                    "va a tela de origem do lançamento e estorne o processo completo.", "Mensagem",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (MessageBox.Show("Confirma Estorno do Lançamento de Caixa: " + (bindingSourceCaixa.Current as TRegistro_LanCaixa).Cd_LanctoCaixa.ToString(),
                                    "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    try
                    {
                        if (TCN_LanCaixa.EstornarCaixa((bindingSourceCaixa.Current as TRegistro_LanCaixa), null, null))
                            afterBusca();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
                MessageBox.Show("Obrigatorio selecionar registro caixa para estornar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BB_Recalcula_Click(object sender, EventArgs e)
        {
            TCD_LanCaixa QTB_Caixa = new TCD_LanCaixa();
            QTB_Caixa.Recalcula((bindingSourceCaixa.Current as TRegistro_LanCaixa));
            afterBusca();
        }
                
        private void dataGridcaixa_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if(e.Value != null)
                if(e.ColumnIndex == 1)
                {
                    if (e.Value.ToString().Trim().ToUpper().Equals("SIM"))
                        dataGridcaixa.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
                    else
                        dataGridcaixa.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                }
        }

        private void BB_Transfere_Click(object sender, EventArgs e)
        {
            if (cbContaGer.SelectedItem == null)
            {
                MessageBox.Show("Obrigatorio informar conta gerencial.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbContaGer.Focus();
                return;
            }
            using (TFLan_Transfere_Caixa FLan_Transfere_Caixa = new TFLan_Transfere_Caixa())
            {
                FLan_Transfere_Caixa.BS_Transfere_Caixa.AddNew();
                (FLan_Transfere_Caixa.BS_Transfere_Caixa.Current as TRegistro_Lan_Transfere_Caixa).CD_LanctoCaixa = string.Empty;
                (FLan_Transfere_Caixa.BS_Transfere_Caixa.Current as TRegistro_Lan_Transfere_Caixa).CD_ContaGer_Saida = cbContaGer.SelectedValue.ToString();
                (FLan_Transfere_Caixa.BS_Transfere_Caixa.Current as TRegistro_Lan_Transfere_Caixa).DS_ContaGer_Saida = string.Empty;
                (FLan_Transfere_Caixa.BS_Transfere_Caixa.Current as TRegistro_Lan_Transfere_Caixa).NM_Empresa = string.Empty;

                FLan_Transfere_Caixa.CD_ContaGer_Saida.Enabled = false;
                FLan_Transfere_Caixa.DS_ContaGer_Saida.Enabled = false;

                if (FLan_Transfere_Caixa.ShowDialog() == DialogResult.OK)
                    try
                    {
                        //Transferencia avulsa
                        (FLan_Transfere_Caixa.BS_Transfere_Caixa.Current as TRegistro_Lan_Transfere_Caixa).St_avulso = true;
                        TCN_Lan_Transfere_Caixa.Transfere_Caixa(FLan_Transfere_Caixa.BS_Transfere_Caixa.Current as TRegistro_Lan_Transfere_Caixa, null);
                        afterBusca();
                    }
                    catch (Exception ex)
                    { MessageBox.Show("Erro: " + ex.Message); }
                else
                    FLan_Transfere_Caixa.BS_Transfere_Caixa.EndEdit();
            }
        }

        private void BB_FecharCaixa_Click(object sender, EventArgs e)
        {
            if (cbContaGer.SelectedItem != null)
            {
                TFLan_FechamentoCaixa fFechamentoCaixa = new TFLan_FechamentoCaixa();
                try
                {
                    fFechamentoCaixa.pCd_contager = cbContaGer.SelectedValue.ToString();
                    fFechamentoCaixa.ShowDialog();
                }
                finally
                {
                    fFechamentoCaixa.Dispose();
                }
            }
            else
                MessageBox.Show("Obrigatório informar conta gerencial!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        
        private void dataGridcaixa_SelectionChanged(object sender, EventArgs e)
        {
            somarValores();
        }
                
        private void cd_historico_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.cd_historico|=|'" + cd_historico.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[]{ cd_historico },
                                    new TCD_CadHistorico());
        }

        private void bb_historico_Click(object sender, EventArgs e)
        {
            string vColunas = "a.DS_Historico|Descrição Historico|250;" +
                              "a.CD_Historico|Cd. Historico|80";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[]{ cd_historico },
                                   new TCD_CadHistorico(), string.Empty);
        }

        private void dataGridcaixa_DoubleClick(object sender, EventArgs e)
        {
            if (bindingSourceCaixa.Current != null)
            {
                TFRastrearLancamentos fRastrear = new TFRastrearLancamentos();
                try
                {
                    fRastrear.bindingSourceCaixa.Add(bindingSourceCaixa.Current as TRegistro_LanCaixa);
                    fRastrear.TRastrear = TP_Rastrear.tm_caixa;
                    fRastrear.ShowDialog();
                }
                finally
                {
                    fRastrear.Dispose();
                }
            }
        }

        private void ImprimeRelatorio()
        {
            if (bindingSourceCaixa.Count > 0)
            {
                using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                {
                    FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                    BindingSource BinCheque = new BindingSource();
                    BinCheque.DataSource = BuscaCheques(string.Empty, cbContaGer.SelectedItem != null ? cbContaGer.SelectedValue.ToString() : string.Empty, string.Empty, string.Empty);
                    Rel.Altera_Relatorio = Altera_Relatorio;
                    Rel.DTS_Relatorio = bindingSourceCaixa;
                    Rel.Nome_Relatorio = Name;
                    Rel.NM_Classe = Name;
                    Rel.Ident = Name;
                    Rel.Modulo = Tag.ToString().Substring(0, 3);
                    fImp.St_enabled_enviaremail = true;
                    fImp.pCd_clifor = string.Empty;
                    fImp.pMensagem = "RELATORIO " + Text.Trim();
                    Rel.Adiciona_DataSource("BINCHEQUE", BinCheque);
                    Rel.Parametros_Relatorio.Add("VL_DIFCX", VL_DifCX.Value);
                    Rel.Parametros_Relatorio.Add("VL_SALDOLIQUIDO", VL_SaldoLiquido.Value);
                    Rel.Parametros_Relatorio.Add("TOT_CH_REC", Tot_Ch_REC.Value);
                    Rel.Parametros_Relatorio.Add("TOT_CH_PAG", Tot_Ch_PAG.Value);

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
                                           "RELATORIO " + Text.Trim(),
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
                                               "RELATORIO " + Text.Trim(),
                                               fImp.pDs_mensagem);
                }
            }
            else
                MessageBox.Show("Não existe registros de caixas para gerar relatorio.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
      
        public DataTable BuscaCheques(string vcd_empresa, string vContaGer, string vdt_ini, string vdt_fim)
        {

            TpBusca[] filtro = new TpBusca[0];
            DataTable CheqBusca;
            if (vcd_empresa.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vcd_empresa.Trim() + "'";
            };
            if (vContaGer.Trim() != string.Empty)
            {
                //Buscar conta de compensacao de cheque
                TList_CadContaGer lConta = CamadaNegocio.Financeiro.Cadastros.TCN_CadContaGer.Buscar(vContaGer,
                    "", null, "", "", "", "", 0, "", vcd_empresa, "", "", 0, null);
                if (lConta.Count > 0)
                {
                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[filtro.Length - 1].vNM_Campo = "c.cd_contager";
                    filtro[filtro.Length - 1].vOperador = "=";
                    filtro[filtro.Length - 1].vVL_Busca = "'" + lConta[0].Cd_contager_compensacao.Trim() + "'";
                }
            };
            if ((vdt_fim.Trim() != string.Empty) && (vdt_fim.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "c.dt_lancto";
                filtro[filtro.Length - 1].vOperador = "<=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(vdt_fim).ToString("yyyyMMdd")) + " 23:59:59'";
            };
            if ((vdt_ini.Trim() != string.Empty) && (vdt_ini.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "c.dt_lancto";
                filtro[filtro.Length - 1].vOperador = ">=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(vdt_ini).ToString("yyyyMMdd")) + " 00:00:00'";
            };
            CheqBusca = new TCD_LanCaixa().buscarChequesACompensar(filtro);
            return CheqBusca;

        }

        private void TFConsultaCaixa_FormClosed(object sender, FormClosedEventArgs e)
        {
            ShapeGrid.SaveShape(this, dataGridcaixa);
        }

        private void VL_DifCX_ValueChanged(object sender, EventArgs e)
        {
            sd_dinheiro.Value = VL_DifCX.Value - Tot_Ch_REC.Value;
        }

        private void Tot_Ch_REC_ValueChanged(object sender, EventArgs e)
        {
            sd_dinheiro.Value = VL_DifCX.Value - Tot_Ch_REC.Value;
        }

        private void TFConsultaCaixa_FormClosing(object sender, FormClosingEventArgs e)
        {
            ShapeGrid.SaveShape(this, dataGridcaixa);
        }

        private void bindingSourceCaixa_PositionChanged(object sender, EventArgs e)
        {
            if (bindingSourceCaixa.Current != null)
            {
                bsTransf.DataSource = new TCD_LanCaixa().Select(
                                        new TpBusca[]
                                        {
                                            new TpBusca()
                                            {
                                                vNM_Campo = string.Empty,
                                                vOperador = "exists",
                                                vVL_Busca = "(select 1 from tb_fin_transfcaixa x "+
                                                            "where " + ((bindingSourceCaixa.Current as TRegistro_LanCaixa).Vl_PAGAR > decimal.Zero ? "x.cd_conta_ent" : "x.cd_conta_sai") + "  = a.cd_contager "+
                                                            "and " + ((bindingSourceCaixa.Current as TRegistro_LanCaixa).Vl_PAGAR > decimal.Zero ? "x.cd_lanctocaixa_ent" : "x.cd_lanctocaixa_sai") + " = a.cd_lanctocaixa "+
                                                            "and " + ((bindingSourceCaixa.Current as TRegistro_LanCaixa).Vl_PAGAR > decimal.Zero ? "x.cd_conta_sai" : "x.cd_conta_ent") + " = '" + (bindingSourceCaixa.Current as TRegistro_LanCaixa).Cd_ContaGer.Trim() + "' "+
                                                            "and " + ((bindingSourceCaixa.Current as TRegistro_LanCaixa).Vl_PAGAR > decimal.Zero ? "x.cd_lanctocaixa_sai" : "x.cd_lanctocaixa_ent") + " = " + (bindingSourceCaixa.Current as TRegistro_LanCaixa).Cd_LanctoCaixa.ToString() + ")"
                                            }
                                        }, 0, string.Empty);
                bindingSourceCaixa.ResetCurrentItem();

                if (bsTransf.Count > 0)
                    tlpCaixa.RowStyles[2] = new RowStyle(SizeType.Absolute, 105);
                else
                    tlpCaixa.RowStyles[2] = new RowStyle(SizeType.Absolute, 0);
            }
        }

        private void ImprimirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImprimeRelatorio();
        }

        private void ImprimirReciboToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImprimirRecibo();
        }

        private void saldoContasGerenciaisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (Financeiro.Relatorio.TFRel_SaldoContasGerenciais fRelSaldoContas = new Financeiro.Relatorio.TFRel_SaldoContasGerenciais())
            {
                fRelSaldoContas.WindowState = FormWindowState.Normal;
                fRelSaldoContas.StartPosition = FormStartPosition.CenterScreen;
                fRelSaldoContas.ShowDialog();
            }
        }

        private void bb_aplicar_Click(object sender, EventArgs e)
        {
            if (cbContaGer.SelectedItem == null)
            {
                MessageBox.Show("Obrigatório informar conta gerencial.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbContaGer.Focus();
                return;
            }
            if (bsSaldoAplic.Current == null)
            {
                MessageBox.Show("Obrigatório selecionar conta aplicação.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            using (TFAplicarResgatar fAplic = new TFAplicarResgatar())
            {
                fAplic.Tp_lancamento = "T";
                if(fAplic.ShowDialog() == DialogResult.OK)
                    try
                    {
                        TCN_Lan_Transfere_Caixa.Transfere_Caixa(new TRegistro_Lan_Transfere_Caixa()
                        {
                            CD_Empresa = fAplic.pCd_empresa,
                            CD_ContaGer_Entrada = (bsSaldoAplic.Current as TRegistro_SaldoContaGer).Cd_contager,
                            CD_ContaGer_Saida = cbContaGer.SelectedValue.ToString(),
                            CD_Historico = fAplic.pCd_historico,
                            DT_Lancto = fAplic.pDt_lancto,
                            NR_Docto = "APLICACAO",
                            Valor_Transferencia = fAplic.pValor
                        }, null);
                        MessageBox.Show("Aplicação realizada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        afterBusca();
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void bb_resgatar_Click(object sender, EventArgs e)
        {
            if (cbContaGer.SelectedItem == null)
            {
                MessageBox.Show("Obrigatório informar conta gerencial.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbContaGer.Focus();
                return;
            }
            if (bsSaldoAplic.Current == null)
            {
                MessageBox.Show("Obrigatório selecionar conta aplicação.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if ((bsSaldoAplic.Current as TRegistro_SaldoContaGer).Vl_saldo.Equals(decimal.Zero))
            {
                MessageBox.Show("Aplicação não possui saldo para resgatar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            using (TFAplicarResgatar fAplic = new TFAplicarResgatar())
            {
                fAplic.Tp_lancamento = "T";
                if (fAplic.ShowDialog() == DialogResult.OK)
                    try
                    {
                        TCN_Lan_Transfere_Caixa.Transfere_Caixa(new TRegistro_Lan_Transfere_Caixa()
                        {
                            CD_Empresa = fAplic.pCd_empresa,
                            CD_ContaGer_Entrada = cbContaGer.SelectedValue.ToString(),
                            CD_ContaGer_Saida = (bsSaldoAplic.Current as TRegistro_SaldoContaGer).Cd_contager,
                            CD_Historico = fAplic.pCd_historico,
                            DT_Lancto = fAplic.pDt_lancto,
                            NR_Docto = "RESGATE",
                            Valor_Transferencia = fAplic.pValor
                        }, null);
                        MessageBox.Show("Resgate aplicação realizado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        afterBusca();
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void bb_corrigir_Click(object sender, EventArgs e)
        {
            if (cbContaGer.SelectedItem == null)
            {
                MessageBox.Show("Obrigatório informar conta gerencial.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbContaGer.Focus();
                return;
            }
            if (bsSaldoAplic.Current == null)
            {
                MessageBox.Show("Obrigatório selecionar conta aplicação.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if ((bsSaldoAplic.Current as TRegistro_SaldoContaGer).Vl_saldo.Equals(decimal.Zero))
            {
                MessageBox.Show("Aplicação não possui saldo para resgatar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            using (TFAplicarResgatar fAplic = new TFAplicarResgatar())
            {
                if (fAplic.ShowDialog() == DialogResult.OK)
                    try
                    {
                        TCN_LanCaixa.GravaLanCaixa(new TRegistro_LanCaixa()
                        {
                            Cd_ContaGer = (bsSaldoAplic.Current as TRegistro_SaldoContaGer).Cd_contager,
                            Cd_Empresa = fAplic.pCd_empresa,
                            Cd_Historico = fAplic.pCd_historico,
                            Dt_lancto = fAplic.pDt_lancto,
                            Login = Utils.Parametros.pubLogin,
                            Nr_Docto = "CORRECAO",
                            St_avulso = "S",
                            Vl_RECEBER = fAplic.pValor - (bsSaldoAplic.Current as TRegistro_SaldoContaGer).Vl_saldo
                        }, null);
                        MessageBox.Show("Correção aplicação realizada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        afterBusca();
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void BB_Retorno_Click(object sender, EventArgs e)
        {
            using (TFLan_COB_Retorno fRetorno = new TFLan_COB_Retorno())
            {
                fRetorno.ShowDialog();
                afterBusca();
            }
        }
    }
}