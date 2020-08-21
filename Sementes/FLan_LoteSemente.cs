using System;
using System.Drawing;
using System.Windows.Forms;
using FormBusca;
using Componentes;
using CamadaDados.Graos;

namespace Sementes
{
    public partial class TFLan_LoteSemente : Form
    {
        public bool Altera_Relatorio = false;

        public TFLan_LoteSemente()
        {
            InitializeComponent();
        }

        private void limparFiltros()
        {
            id_lote.Clear();
            cd_empresa.Clear();
            nr_lote.Clear();
            cd_produto.Clear();
            cd_atestado.Clear();
            anosafra.Clear();
            id_analise.Clear();
            cd_laboratorio.Clear();
        }

        private void afterNovo()
        {
            using (Proc_Commoditties.TFNovoLote fLote = new Proc_Commoditties.TFNovoLote())
            {
                if (fLote.ShowDialog() == DialogResult.OK)
                    try
                    {
                        CamadaNegocio.Sementes.TCN_LoteSemente.Gravar(fLote.rLote, null);
                        MessageBox.Show("Lote gravado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        limparFiltros();
                        id_lote.Text = fLote.rLote.Id_lote.ToString();
                        afterBusca();
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void afterAltera()
        {
            if (bsLoteSemente.Current != null)
            {
                if((bsLoteSemente.Current as CamadaDados.Sementes.TRegistro_LoteSemente).Tp_lote.Trim().ToUpper().Equals("P"))
                    using (TFLoteSemente fLote = new TFLoteSemente())
                    {
                        fLote.vModo = Utils.TTpModo.tm_Edit;
                        fLote.rSementes = (bsLoteSemente.Current as CamadaDados.Sementes.TRegistro_LoteSemente);
                        if (fLote.ShowDialog() == DialogResult.OK)
                        {
                            try
                            {
                                CamadaNegocio.Sementes.TCN_LoteSemente.Alterar(fLote.rSementes, null);
                                MessageBox.Show("Lote alterado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                limparFiltros();
                                id_lote.Text = fLote.rSementes.Id_lote.ToString();
                                afterBusca();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                else 
                    using (Proc_Commoditties.TFNovoLote fLote = new Proc_Commoditties.TFNovoLote())
                    {
                        fLote.rLote = bsLoteSemente.Current as CamadaDados.Sementes.TRegistro_LoteSemente;
                        if(fLote.ShowDialog() == DialogResult.OK)
                            try
                            {
                                CamadaNegocio.Sementes.TCN_LoteSemente.Alterar(fLote.rLote, null);
                                MessageBox.Show("Lote alterado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                limparFiltros();
                                id_lote.Text = fLote.rLote.Id_lote.ToString();
                                afterBusca();
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    }
            }
            else
                MessageBox.Show("Obrigatorio selecionar lote para alterar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void afterExclui()
        {
            if (bsLoteSemente.Current != null)
            {         
                if (MessageBox.Show("Confirma exclusão do lote selecionado?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    == DialogResult.Yes)
                {
                    try
                    {
                        CamadaNegocio.Sementes.TCN_LoteSemente.Excluir(bsLoteSemente.Current as CamadaDados.Sementes.TRegistro_LoteSemente, null);
                        MessageBox.Show("Lote de semente excluido com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        limparFiltros();
                        afterBusca();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.Trim());
                    }
                }
            }
            else
                MessageBox.Show("Obrigatorio selecionar lote para excluir.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void afterBusca()
        {
            string vStatus = string.Empty;
            string virg = string.Empty;
            if (st_aberto.Checked)
            {
                vStatus += virg + "'A'";
                virg = ",";
            }
            if (st_processado.Checked)
            {
                vStatus += virg + "'P'";
                virg = ",";
            }
            if (st_refugado.Checked)
            {
                vStatus += virg + "'R'";
                virg = ",";
            }
            if (st_encerrado.Checked)
            {
                vStatus += virg + "'E'";
                virg = ",";
            }
            bsLoteSemente.DataSource = CamadaNegocio.Sementes.TCN_LoteSemente.Buscar(id_lote.Text,
                                                                                     cd_empresa.Text,
                                                                                     cd_produto.Text,
                                                                                     anosafra.Text,
                                                                                     nr_lote.Text,
                                                                                     cd_atestado.Text,
                                                                                     id_analise.Text,
                                                                                     cd_laboratorio.Text,
                                                                                     string.Empty,
                                                                                     vStatus,
                                                                                     cb_lotevencido.Checked,
                                                                                     cb_lotesemsaldo.Checked,
                                                                                     0,
                                                                                     string.Empty,
                                                                                     editDefault1.Text,
                                                                                     nfOrigem.Text,
                                                                                     rbLote.Checked ? "L" : "V",
                                                                                     dt_ini.Text,
                                                                                     dt_fin.Text,
                                                                                     null);
            bsLoteSemente_PositionChanged(this, new EventArgs());
        }

        private void afterPrint()
        {
            if (bsLoteSemente.Current != null)
            {
                using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                {
                    FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                    Rel.Altera_Relatorio = Altera_Relatorio;
                    BindingSource bs = new BindingSource();
                    bs.DataSource = new CamadaDados.Sementes.TList_LoteSemente() { bsLoteSemente.Current as CamadaDados.Sementes.TRegistro_LoteSemente };
                    Rel.DTS_Relatorio = bs;
                    Rel.Nome_Relatorio = "FRel_LaudoAmostra";
                    Rel.NM_Classe = Name;
                    Rel.Modulo = "SEM";
                    Rel.Ident = "FRel_LaudoAmostra";
                    fImp.St_enabled_enviaremail = true;
                    fImp.pCd_clifor = string.Empty;
                    fImp.pMensagem = "PEDIDO DE SERVIÇO E RELAÇÃO DE AMOSTRA";

                    if (Altera_Relatorio)
                    {
                        Rel.Gera_Relatorio(string.Empty,
                                           fImp.pSt_imprimir,
                                           fImp.pSt_visualizar,
                                           fImp.pSt_enviaremail,
                                           fImp.pSt_exportPdf,
                                           fImp.Path_exportPdf,
                                           null,
                                           fImp.pDestinatarios,
                                           "PEDIDO DE SERVIÇO E RELAÇÃO DE AMOSTRA",
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
                                               "PEDIDO DE SERVIÇO E RELAÇÃO DE AMOSTRA",
                                               fImp.pDs_mensagem);
                }
            }
            else
                MessageBox.Show("Obrigatorio selecionar lote para imprimir laudo.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void AprovarLoteSemente()
        {
            if (bsLoteSemente.Current != null)
            {
                if ((bsLoteSemente.Current as CamadaDados.Sementes.TRegistro_LoteSemente).St_registro.Trim().ToUpper() != "A")
                {
                    MessageBox.Show("Permitido aprovar somente lote com status <ABERTO>.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if(MessageBox.Show("Confirma aprovação do lote?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    == DialogResult.Yes)
                    using (TFAprovarLote fAprovar = new TFAprovarLote())
                    {
                        fAprovar.rSemente = (bsLoteSemente.Current as CamadaDados.Sementes.TRegistro_LoteSemente);
                        if (fAprovar.ShowDialog() == DialogResult.OK)
                        {
                            if (!CamadaNegocio.ConfigGer.TCN_CadParamGer.BuscaVL_Bool("APONT_PRODUCAO_SEMENTE", fAprovar.rSemente.Cd_empresa, null).Trim().ToUpper().Equals("S"))
                            {
                                using (TFPedidoItemSemente fNfOrigem = new TFPedidoItemSemente())
                                {
                                    fNfOrigem.Cd_empresa = fAprovar.rSemente.Cd_empresa;
                                    fNfOrigem.Cd_amostra = fAprovar.rSemente.Cd_amostra;
                                    fNfOrigem.Qtd_lote = fAprovar.rSemente.Qtd_amostra;
                                    if (fNfOrigem.ShowDialog() == DialogResult.OK)
                                    {
                                        fAprovar.rSemente.lLoteNfItens = fNfOrigem.lNfItem;
                                        try
                                        {
                                            CamadaNegocio.Sementes.TCN_LoteSemente.Aprovar(fAprovar.rSemente, null);
                                            MessageBox.Show("Lote semente aprovado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                    }
                                }
                            }
                            else
                            {
                                try
                                {
                                    CamadaNegocio.Sementes.TCN_LoteSemente.Aprovar(fAprovar.rSemente, null);
                                    MessageBox.Show("Lote semente aprovado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                        afterBusca();
                    }
            }
            else
                MessageBox.Show("Obrigatorio selecionar lote para aprovar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ReprovarLoteSemente()
        {
            if (bsLoteSemente.Current != null)
            {
                if ((bsLoteSemente.Current as CamadaDados.Sementes.TRegistro_LoteSemente).St_registro.Trim().ToUpper() != "A")
                {
                    MessageBox.Show("Permitido reprovar somente lote com status <ABERTO>.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if(MessageBox.Show("Confirma reprovação do lote?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    == DialogResult.Yes)
                {
                    using (TFReprovarLote fRep = new TFReprovarLote())
                    {
                        fRep.rSemente = bsLoteSemente.Current as CamadaDados.Sementes.TRegistro_LoteSemente;
                        if (fRep.ShowDialog() == DialogResult.OK)
                        {
                            using (TFPedidoItemSemente fNfOrigem = new TFPedidoItemSemente())
                            {
                                fNfOrigem.Cd_empresa = fRep.rSemente.Cd_empresa;
                                fNfOrigem.Cd_amostra = fRep.rSemente.Cd_amostra;
                                fNfOrigem.Qtd_lote = fRep.rSemente.Qtd_lote;
                                if (fNfOrigem.ShowDialog() == DialogResult.OK)
                                {
                                    fRep.rSemente.lLoteNfItens = fNfOrigem.lNfItem;
                                    try
                                    {
                                        CamadaNegocio.Sementes.TCN_LoteSemente.Reprovar(fRep.rSemente, null);
                                        MessageBox.Show("Lote reprovado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                            }
                        }
                        afterBusca();
                    }
                }
            }
            else
                MessageBox.Show("Obrigatorio selecionar lote para reprovar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void EncerrarLoteSemente()
        {
            if (bsLoteSemente.Current != null)
            {
                if ((bsLoteSemente.Current as CamadaDados.Sementes.TRegistro_LoteSemente).St_registro.Trim().ToUpper() != "P")
                {
                    MessageBox.Show("Permitido encerrar somente lote com status <APROVADO>.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                bool st_saldolote = ((!CamadaNegocio.ConfigGer.TCN_CadParamGer.BuscaVL_Bool("APONT_PRODUCAO_SEMENTE",
                                    (bsLoteSemente.Current as CamadaDados.Sementes.TRegistro_LoteSemente).Cd_empresa, null).Trim().ToUpper().Equals("S")) &&
                                    ((bsLoteSemente.Current as CamadaDados.Sementes.TRegistro_LoteSemente).Qtd_saldo > 0));
                if (MessageBox.Show((st_saldolote ?
                    "Lote possui saldo semente processado disponivel para venda.\r\n"+
                    "O encerramento do lote ira reprocessar o saldo restante.\r\n\r\n"+
                    "Saldo Disponivel: "+ (bsLoteSemente.Current as CamadaDados.Sementes.TRegistro_LoteSemente).Qtd_saldo.ToString("N0", new System.Globalization.CultureInfo("en-US", true)) + "\r\n":
                    string.Empty) + 
                    "Confirma encerramento do lote selecionado?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    == DialogResult.Yes)
                {
                    if (st_saldolote)
                    {
                        using (TFFormulaEstornoSemente fFormula = new TFFormulaEstornoSemente())
                        {
                            fFormula.rSemente = (bsLoteSemente.Current as CamadaDados.Sementes.TRegistro_LoteSemente);
                            if (fFormula.ShowDialog() == DialogResult.OK)
                            {
                                try
                                {
                                    CamadaNegocio.Sementes.TCN_LoteSemente.Encerrar(bsLoteSemente.Current as CamadaDados.Sementes.TRegistro_LoteSemente, null);
                                    MessageBox.Show("Lote encerrado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                afterBusca();
                            }
                            else
                            {
                                (bsLoteSemente.Current as CamadaDados.Sementes.TRegistro_LoteSemente).Id_formestorno = null;
                                (bsLoteSemente.Current as CamadaDados.Sementes.TRegistro_LoteSemente).Ds_formulaestorno = string.Empty;
                            }
                        }
                    }
                    else
                    {
                        try
                        {
                            CamadaNegocio.Sementes.TCN_LoteSemente.Encerrar(bsLoteSemente.Current as CamadaDados.Sementes.TRegistro_LoteSemente, null);
                            MessageBox.Show("Lote encerrado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        afterBusca();
                    }
                }
            }
            else
                MessageBox.Show("Obrigatorio selecionar lote para encerrar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }   

        private void TFLan_LoteSemente_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, dataGridDefault1);
            Utils.ShapeGrid.RestoreShape(this, dataGridDefault2);
            Utils.ShapeGrid.RestoreShape(this, dataGridDefault3);
            Utils.ShapeGrid.RestoreShape(this, dataGridDefault4);
            Utils.ShapeGrid.RestoreShape(this, dataGridDefault5);
            Utils.ShapeGrid.RestoreShape(this, dataGridDefault6);
            Utils.ShapeGrid.RestoreShape(this, gLoteSemente);
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
            Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pFiltro.set_FormatZero();
        }

        private void BB_Novo_Click(object sender, EventArgs e)
        {
            afterNovo();
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            afterBusca();
        }

        private void BB_Alterar_Click(object sender, EventArgs e)
        {
            afterAltera();
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            afterExclui();
        }

        private void gLoteSemente_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if(e.Value != null)
                if (e.ColumnIndex.Equals(0))
                {
                    if (e.Value.ToString().Trim().ToUpper().Equals("APROVADO"))
                        gLoteSemente.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Blue;
                    else if (e.Value.ToString().Trim().ToUpper().Equals("REPROVADO"))
                        gLoteSemente.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Green;
                    else if (e.Value.ToString().Trim().ToUpper().Equals("ENCERRADO"))
                        gLoteSemente.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Maroon;
                    else if (e.Value.ToString().Trim().ToUpper().Equals("VENCIDO"))
                        gLoteSemente.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
                    else
                        gLoteSemente.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                }
        }

        private void BB_ProcessarLote_Click(object sender, EventArgs e)
        {
            AprovarLoteSemente();    
        }

        private void st_aberto_Click(object sender, EventArgs e)
        {
            if (st_aberto.Checked)
            {
                cb_lotevencido.Checked = false;
                cb_lotesemsaldo.Checked = false;
            }
        }

        private void st_processado_Click(object sender, EventArgs e)
        {
            if (st_processado.Checked)
            {
                cb_lotevencido.Checked = false;
                cb_lotesemsaldo.Checked = false;
            }
        }

        private void st_refugado_Click(object sender, EventArgs e)
        {
            if (st_refugado.Checked)
            {
                cb_lotevencido.Checked = false;
                cb_lotesemsaldo.Checked = false;
            }
        }

        private void st_cancelado_Click(object sender, EventArgs e)
        {
            if (st_encerrado.Checked)
            {
                cb_lotevencido.Checked = false;
                cb_lotesemsaldo.Checked = false;
            }
        }

        private void cb_lotevencido_Click(object sender, EventArgs e)
        {
            if (cb_lotevencido.Checked)
            {
                cb_lotesemsaldo.Checked = true;
                st_aberto.Checked = false;
                st_encerrado.Checked = false;
                st_processado.Checked = true;
                st_refugado.Checked = true;

                cb_lotesemsaldo.Enabled = false;
                st_processado.Enabled = false;
                st_refugado.Enabled = false;
            }
            else
            {
                cb_lotesemsaldo.Enabled = true;
                st_processado.Enabled = true;
                st_refugado.Enabled = true;
            }
        }

        private void cb_lotesemsaldo_Click(object sender, EventArgs e)
        {
            if (cb_lotesemsaldo.Checked)
            {
                cb_lotevencido.Checked = false;
                st_aberto.Checked = false;
                st_encerrado.Checked = false;
                st_processado.Checked = false;
                st_refugado.Checked = false;
            }
        }

        private void bsLoteSemente_PositionChanged(object sender, EventArgs e)
        {
            if (bsLoteSemente.Current != null)
            {
                if ((bsLoteSemente.Current as CamadaDados.Sementes.TRegistro_LoteSemente).Id_lote.ToString() != string.Empty)
                {
                    //Buscar Tipo de Analise
                    (bsLoteSemente.Current as CamadaDados.Sementes.TRegistro_LoteSemente).lAnalise =
                        CamadaNegocio.Sementes.TCN_LoteSemente_X_TipoAnalise.BuscarAnalises(
                        (bsLoteSemente.Current as CamadaDados.Sementes.TRegistro_LoteSemente).Id_lote.ToString(),
                        null);
                    //Buscar apontamento producao
                    (bsLoteSemente.Current as CamadaDados.Sementes.TRegistro_LoteSemente).lApontamento =
                        new CamadaDados.Producao.Producao.TCD_ApontamentoProducao().Select(
                        new Utils.TpBusca[]
                    {
                        new Utils.TpBusca()
                        {
                            vNM_Campo = string.Empty,
                            vOperador = "exists",
                            vVL_Busca = "(select 1 from tb_sem_lotesemente_x_apontamento x "+
                                        "where x.id_apontamento = a.id_apontamento "+
                                        "and x.id_lote = "+(bsLoteSemente.Current as CamadaDados.Sementes.TRegistro_LoteSemente).Id_lote.ToString()+")"
                        }
                    }, 0, string.Empty);
                    //Buscar estoque do apontamento
                    (bsLoteSemente.Current as CamadaDados.Sementes.TRegistro_LoteSemente).lApontamento.ForEach(p =>
                        p.LApontamentoEstoque = new CamadaDados.Producao.Producao.TCD_Apontamento_Estoque().Select(
                                                    new Utils.TpBusca[]
                                                {
                                                    new Utils.TpBusca()
                                                    {
                                                        vNM_Campo = "a.id_apontamento",
                                                        vOperador = "=",
                                                        vVL_Busca = p.Id_apontamentostr
                                                    }
                                                }, 0, string.Empty));
                    //Buscar itens nf de origem
                    (bsLoteSemente.Current as CamadaDados.Sementes.TRegistro_LoteSemente).lItensNfOrigem =
                        new CamadaDados.Sementes.TCD_LoteSemente_X_NFItem().Select(
                        new Utils.TpBusca[]
                        {
                            //Id do lote
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "a.id_lote",
                                vOperador = "=",
                                vVL_Busca = (bsLoteSemente.Current as CamadaDados.Sementes.TRegistro_LoteSemente).Id_lote.ToString()
                            },
                            //Nota Fiscal nao cancelada
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "isnull(c.st_registro, 'A')",
                                vOperador = "<>",
                                vVL_Busca = "'C'"
                            },
                            //Tipo Movimento da nota Entrada
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "c.tp_movimento",
                                vOperador = "=",
                                vVL_Busca = "'E'"
                            },
                            //Tipo Movimento do lote Origem
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "a.tp_movimento",
                                vOperador = "=",
                                vVL_Busca = "'O'"
                            }
                        }, 0, string.Empty);

                    //Buscar itens nf de venda
                    (bsLoteSemente.Current as CamadaDados.Sementes.TRegistro_LoteSemente).lNfVenda =
                        new CamadaDados.Sementes.TCD_LoteSemente_X_NFItem().Select(
                        new Utils.TpBusca[]
                        {
                            //Id do lote
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "a.id_lote",
                                vOperador = "=",
                                vVL_Busca = (bsLoteSemente.Current as CamadaDados.Sementes.TRegistro_LoteSemente).Id_lote.ToString()
                            },
                            //Nota Fiscal nao cancelada
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "isnull(c.st_registro, 'A')",
                                vOperador = "<>",
                                vVL_Busca = "'C'"
                            },
                            //Tipo Movimento da nota Saida
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "c.tp_movimento",
                                vOperador = "=",
                                vVL_Busca = "'S'"
                            },
                            //Tipo Movimento do lote Destino
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "a.tp_movimento",
                                vOperador = "=",
                                vVL_Busca = "'V'"
                            }
                        }, 0, string.Empty);
                                                                               
                    //Buscar itens nf devolucao venda
                    (bsLoteSemente.Current as CamadaDados.Sementes.TRegistro_LoteSemente).lNfDevolucao =
                        new CamadaDados.Sementes.TCD_LoteSemente_X_NFItem().Select(
                        new Utils.TpBusca[]
                        {
                            //Id do lote
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "a.id_lote",
                                vOperador = "=",
                                vVL_Busca = (bsLoteSemente.Current as CamadaDados.Sementes.TRegistro_LoteSemente).Id_lote.ToString()
                            },
                            //Nota Fiscal nao cancelada
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "isnull(c.st_registro, 'A')",
                                vOperador = "<>",
                                vVL_Busca = "'C'"
                            },
                            //Tipo Movimento do lote Destino
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "a.tp_movimento",
                                vOperador = "=",
                                vVL_Busca = "'D'"
                            }
                        }, 0, string.Empty);

                    bsLoteSemente.ResetCurrentItem();
                }
                if ((bsLoteSemente.Current as CamadaDados.Sementes.TRegistro_LoteSemente).Tp_lote.Trim().ToUpper().Equals("P"))
                    tlpGrid.RowStyles[1].Height = 150;
                else tlpGrid.RowStyles[1].Height = 0;
            }
        }

        private void bb_analise_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_analise|Tipo Análise|200;" +
                              "a.id_analise|Id. Análise|80";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { id_analise },
                                    new CamadaDados.Sementes.Cadastros.TCD_TipoAnalise(), string.Empty);
        }

        private void id_analise_Leave(object sender, EventArgs e)
        {
            string vParam = "a.id_analise|=|" + id_analise.Text;
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { id_analise },
                                    new CamadaDados.Sementes.Cadastros.TCD_TipoAnalise());
        }

        private void bb_laboratorio_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BUSCA(
                "a.nm_clifor|Nome Clifor|300;a.cd_clifor|Código Clifor|90;" +
                "tp_pessoa|Tipo Pessoa|80;" +
                "nr_cgc|C.N.P.J|80;" +
                "nr_cpf|C.P.F|80;" +
                "nr_rg|R.G|80;" +
                "nm_razaosocial|Razão Social|100;" +
                "nm_fantasia|Fantasia|100;" +
                "EMAILPF|E-Mail P.F|100;" +
                "EMAILPJ|E-Mail P.J|100"
              , new Componentes.EditDefault[] { cd_laboratorio }, new CamadaDados.Financeiro.Cadastros.TCD_CadClifor(), "isnull(a.st_registro, 'A')|<>|'C'");
        }

        private void cd_laboratorio_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_clifor|=|'" + cd_laboratorio.Text.Trim() + "';" +
                            "isnull(a.st_registro, 'A')|<>|'C'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_laboratorio },
                                        new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void BB_Reprovar_Click(object sender, EventArgs e)
        {
            ReprovarLoteSemente();
        }

        private void BB_Encerrar_Click(object sender, EventArgs e)
        {
            EncerrarLoteSemente();
        }

        private void TFLan_LoteSemente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F2))
                afterNovo();
            else if (e.KeyCode.Equals(Keys.F3))
                afterAltera();
            else if (e.KeyCode.Equals(Keys.F5))
                afterExclui();
            else if (e.KeyCode.Equals(Keys.F7))
                afterBusca();
            else if (e.KeyCode.Equals(Keys.F8))
                afterPrint();
            else if (e.KeyCode.Equals(Keys.F9))
                AprovarLoteSemente();
            else if (e.KeyCode.Equals(Keys.F10))
                ReprovarLoteSemente();
            else if (e.KeyCode.Equals(Keys.F11))
                EncerrarLoteSemente();
        }

        private void BB_Imprimir_Click(object sender, EventArgs e)
        {
            afterPrint();
        }

        private void TFLan_LoteSemente_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, dataGridDefault1);
            Utils.ShapeGrid.SaveShape(this, dataGridDefault2);
            Utils.ShapeGrid.SaveShape(this, dataGridDefault3);
            Utils.ShapeGrid.SaveShape(this, dataGridDefault4);
            Utils.ShapeGrid.SaveShape(this, dataGridDefault5);
            Utils.ShapeGrid.SaveShape(this, dataGridDefault6);
            Utils.ShapeGrid.SaveShape(this, gLoteSemente);
        }

        private void cd_empresa_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "'", new Componentes.EditDefault[] { cd_empresa });
        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { cd_empresa }, string.Empty);
        }

        private void cd_produto_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVEProduto("a.cd_produto|=|'" + cd_produto.Text.Trim() + "'",
                                                   new EditDefault[] { cd_produto },
                                                   new CamadaDados.Estoque.Cadastros.TCD_CadProduto());
        }

        private void bb_produto_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaProduto(new EditDefault[] { cd_produto }, string.Empty);
        }

        private void anosafra_Leave(object sender, EventArgs e)
        {
            string vParam = "a.anosafra|=|'" + anosafra.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { anosafra }, new TCD_CadSafra());
        }

        private void bb_safra_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_safra|Descrição|150;" +
                             "a.anosafra|Código|60";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { anosafra }, new TCD_CadSafra(), string.Empty);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_grupo|Grupo|200;" +
                              "a.cd_grupo|Id. Grupo|80";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { editDefault1},
                                    new CamadaDados.Estoque.Cadastros.TCD_CadGrupoProduto(), string.Empty);
        }

        private void editDefault1_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_grupo|=|" + editDefault1.Text;
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { editDefault1 },
                                    new CamadaDados.Estoque.Cadastros.TCD_CadGrupoProduto());
        }
    }
}
