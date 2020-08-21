using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utils;
using FormBusca;
using CamadaDados.Servicos;
using CamadaNegocio.Servicos;
using CamadaDados.Diversos;
using CamadaNegocio.Servicos.Cadastros;
using CamadaDados.Estoque.Cadastros;
using CamadaNegocio.Diversos;
using CamadaDados.Financeiro.Cadastros;
using CamadaDados.Servicos.Cadastros;
using CamadaNegocio.Estoque.Cadastros;
using CamadaDados.Locacao.Cadastros;
using Servicos;

namespace Locacao
{
    public partial class TFLocManutencao : Form
    {
        private string tpOrdem;
        private string tpOrdemP;
        private TRegistro_CFGLocacao rCfg;

        public bool Altera_Relatorio { get; private set; }

        public TFLocManutencao()
        {
            InitializeComponent();
        }
        /// <summary>
        /// teste 1
        /// </summary>
        private void afterBuscarOrdem()
        {
            string st_os = string.Empty;
            string virg = string.Empty;
            if (ST_OS_Aberta.Checked)
            {
                st_os += virg + "'AB'";
                virg = ",";
            }
            if (ST_OS_Cancelada.Checked)
            {
                st_os += virg + "'CA'";
                virg = ",";
            }
            if (ST_OS_Fechada.Checked)
            {
                st_os += virg + "'FE'";
                virg = ",";
            }
            if (cbProcessada.Checked)
            {
                st_os += virg + "'PR'";
                virg = ",";
            }
            string tp_data = "A";
            if (rbAbertura.Checked)
                tp_data = "A";
            else if (rbFinalizacao.Checked)
                tp_data = "F";
            else if (rbProcessamento.Checked)
                tp_data = "P";
            TList_LanServico lista = TCN_LanServico.Buscar(NR_Serial_Busca.Text,
                                                             CD_Empresa_Busca.Text,
                                                             CD_Clifor_Busca.Text,
                                                             string.Empty,
                                                             CD_Produto_Busca.Text,
                                                             nr_patrimoniobusca.Text,
                                                             string.Empty,
                                                             id_osbusca.Text,
                                                             string.Empty,
                                                             string.Empty,
                                                             id_tecnico.Text,
                                                             id_etapa.Text,
                                                             string.Empty,
                                                             cd_fornecedor.Text,
                                                             tp_data,
                                                             DT_Inic.Text,
                                                             DT_Final.Text,
                                                             st_os,
                                                             RG_PrioridadeBusca.NM_Valor,
                                                             false,
                                                             string.Empty,
                                                             string.Empty,
                                                             string.Empty,
                                                             false,
                                                             false,
                                                             false,
                                                             false,
                                                             false,
                                                             0,
                                                             string.Empty,
                                                             string.Empty,
                                                             null,
                                                             Tp_Ordem: TP_Ordem.Text);
            bsOrdemServico.DataSource = lista;
        }

        private void afterBuscarPatri()
        {
            TpBusca[] vBusca = new TpBusca[0];
            if (!string.IsNullOrEmpty(CD_Produto.Text))
                Estruturas.CriarParametro(ref vBusca, "a.CD_Patrimonio", "'" + CD_Produto.Text.Trim() + "'");
            if (!string.IsNullOrEmpty(NM_Patrimonio.Text))
                Estruturas.CriarParametro(ref vBusca, "a.Nr_patrimonio", "'" + NM_Patrimonio.Text.Trim() + "'");
            if (!string.IsNullOrEmpty(cd_grupo.Text))
                Estruturas.CriarParametro(ref vBusca, "b.cd_grupo", "'" + cd_grupo.Text.Trim() + "%'", "like");
            
            bsPatrimonio.DataSource = new TCD_CadPatrimonio(null).SelectView(vBusca, 0, "");
            bsPatrimonio.ResetBindings(true);
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex.Equals(0))
                afterBuscarPatri();
            else afterBuscarOrdem();
        }

        private void FLocManutencao_Load(object sender, EventArgs e)
        {
            panelDados1.set_FormatZero();
            tabControl1_SelectedIndexChanged(sender, new EventArgs());
            TList_CFGLocacao lCfg = CamadaNegocio.Locacao.Cadastros.TCN_CFGLocacao.buscar(string.Empty, string.Empty, null);
            if (lCfg == null || lCfg.Count.Equals(0))
            {
                MessageBox.Show("Não existe CFG.Locação para empresa", "Mensagem",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                rCfg = lCfg[0];
            }

            object a = rCfg.Tp_ordem;
            object b = rCfg.Tp_ordemp;
            if (a == null || b == null)
            {
                MessageBox.Show("Obrigatório que tenha pré-cadastrado tipo de ordem corretiva e preventiva. Configuração Locação.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
            else
            {
                tpOrdem = a.ToString();
                tpOrdemP = b.ToString();
            }

        }

        private void CD_Produto_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.cd_produto|=|'" + CD_Produto.Text + "'"
              , new Componentes.EditDefault[] { CD_Produto_Busca }, new TCD_CadProduto());
        }

        private void BB_Produto_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("a.DS_Produto|Produto|300;a.cd_Produto|Código Produto|90"
                          , new Componentes.EditDefault[] { CD_Produto }, new TCD_CadProduto(), null);
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CD_Produto_Busca_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.cd_produto|=|'" + CD_Produto_Busca.Text + "'"
               , new Componentes.EditDefault[] { CD_Produto_Busca }, new TCD_CadProduto());
        }

        private void BB_Produto_Busca_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("a.DS_Produto|Produto|300;a.cd_Produto|Código Produto|90"
                          , new Componentes.EditDefault[] { CD_Produto_Busca }, new TCD_CadProduto(), null);
        }

        private void CD_Empresa_Busca_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.cd_empresa|=|'" + CD_Empresa_Busca.Text.Trim() + "';" +
                                 "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.login = '" + Utils.Parametros.pubLogin.Trim() + "' and x.cd_empresa = A.cd_empresa)"
             , new Componentes.EditDefault[] { CD_Empresa_Busca }, new TCD_CadEmpresa());
        }

        private void BB_Empresa_Busca_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("a.NM_empresa|Nome Empresa|300;a.CD_Empresa|Cód Empresa|100"
              , new Componentes.EditDefault[] { CD_Empresa_Busca }
              , new TCD_CadEmpresa(),
              "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.login = '" + Utils.Parametros.pubLogin.Trim() + "' and x.cd_empresa = A.cd_empresa)");
        }

        private void CD_Clifor_Busca_Leave(object sender, EventArgs e)
        {

            UtilPesquisa.EDIT_LEAVE("a.cd_clifor|=|'" + CD_Clifor_Busca.Text + "'"
               , new Componentes.EditDefault[] { CD_Clifor_Busca }, new TCD_CadClifor());
        }

        private void BB_Clifor_Busca_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { CD_Clifor_Busca }, string.Empty);
        }

        private void id_tecnico_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + id_tecnico.Text.Trim() +
                                                    "';isnull(a.st_tecnico, 'N')|=|'S'" +
                                                    ";isnull(a.ST_Funcionarios, 'N')|=|'S'",
                                                      new Componentes.EditDefault[] { id_tecnico },
                                                      new TCD_CadClifor());
        }

        private void bb_tecnico_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { id_tecnico }, "isnull(a.st_tecnico, 'N')|=|'S';isnull(a.ST_Funcionarios, 'N')|=|'S'");
        }

        private void id_etapa_Leave(object sender, EventArgs e)
        {
            string vParam = "a.id_etapa|=|" + id_etapa.Text;
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { id_etapa },
                new TCD_EtapaOrdem());
        }

        private void bb_etapa_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_etapa|Descrição Etapa|200;" +
                              "a.id_etapa|Id. Etapa|80";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { id_etapa },
                new TCD_EtapaOrdem(), string.Empty);
        }

        private void cd_fornecedor_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_clifor|=|'" + cd_fornecedor.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_fornecedor },
                new TCD_CadClifor());
        }

        private void bb_fornecedor_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_fornecedor }, string.Empty);
        }

        private void TP_Ordem_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.tp_Ordem|=|" + TP_Ordem.Text, new Componentes.EditDefault[] { TP_Ordem, DS_TPOrdem }, new TCD_TpOrdem());

            if (!string.IsNullOrEmpty(TP_Ordem.Text))
                DS_TPOrdem.Text = "";
        }

        private void BB_TPOrdem_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("a.DS_TipoOrdem|Tipo Ordem|300;a.tp_Ordem|Código|90"
            , new Componentes.EditDefault[] { TP_Ordem, DS_TPOrdem }, new TCD_TpOrdem(), null);
        }

        private void novoPatri()
        {
            if (bsPatrimonio.Current == null)
                return;

            using (FLocOrdemServico fNovaOrdem = new FLocOrdemServico())
            {
                TRegistro_LanServico rOs = new TRegistro_LanServico();
                rOs.Cd_empresa = rCfg.Cd_empresa;
                rOs.Nm_empresa = rCfg.Nm_empresa;
                rOs.Tp_ordem = rCfg.Tp_ordemp;
                rOs.Ds_tipoordem = rCfg.Ds_tipoordemP;
                rOs.CD_ProdutoOS = (bsPatrimonio.Current as TRegistro_CadPatrimonio).CD_Patrimonio;
                rOs.DS_ProdutoOS = (bsPatrimonio.Current as TRegistro_CadPatrimonio).DS_Patrimonio;
                rOs.Nr_patrimonio = (bsPatrimonio.Current as TRegistro_CadPatrimonio).Nr_patrimonio;
                rOs.Dt_abertura = CamadaDados.UtilData.Data_Servidor();
                rOs.St_prioridade = "1";
                rOs.Ds_observacoesgerais = "MANUTENÇÃO PREVENTIVA ITEM PATRIMÔNNIO " + (bsPatrimonio.Current as TRegistro_CadPatrimonio).Nr_patrimonio;
                rOs.St_os = "AB";

                //Etapa de abertura
                TList_EtapaOrdem lEtapa = new TCD_EtapaOrdem().Select(
                new TpBusca[]
                {
                    new TpBusca()
                    {
                        vNM_Campo = "isnull(a.st_iniciarOS, 'N')",
                        vOperador = "=",
                        vVL_Busca = "'S'"
                    },
                new TpBusca()
                {
                    vNM_Campo = string.Empty,
                    vOperador = "exists",
                    vVL_Busca = "(select 1 from tb_ose_tpordem_x_etapa x "+
                                                "where x.id_etapa = a.id_etapa "+
                                                "and x.tp_ordem = " + rCfg.Tp_ordemstr + ")"
                }
                }, 1, string.Empty);

                if (lEtapa.Count > 0)
                    rOs.lEvolucao.Add(
                        new TRegistro_LanServicoEvolucao()
                        {
                            Dt_inicio = rOs.Dt_abertura,
                            Id_etapa = lEtapa[0].Id_etapa,
                            Ds_evolucao = "ETAPA ABERTURA DA OS",
                            St_envterceiro = lEtapa[0].St_envterceirobool,
                            St_finalizarOS = lEtapa[0].St_finalizarOSbool,
                            St_iniciarOS = lEtapa[0].St_iniciarOSbool
                        });
                else
                    throw new Exception("Não existe etapa de ABERTURA configurada para o tipo de ordem " + rCfg.Tp_ordemstr);

                fNovaOrdem.lanServico = rOs;
                if (fNovaOrdem.ShowDialog() == DialogResult.OK)
                {
                    if (fNovaOrdem.lanServico != null)
                    {
                        try
                        {
                            TCN_LanServico.Gravar(fNovaOrdem.lanServico, null);
                            MessageBox.Show("Ordem de serviço gerada com sucesso.", "Informativo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            bsPatrimonio.RemoveCurrent();
                        }
                        catch (Exception ex) { MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    }
                }
            }
        }

        private void BB_Novo_Click(object sender, EventArgs e)
        {
            novoPatri();
        }

        private void bb_processar_Click(object sender, EventArgs e)
        {
            processarOS();
        }

        private void processarOS()
        {
            if (bsOrdemServico.Current == null)
                return;
            else if (!(bsOrdemServico.Current as TRegistro_LanServico).St_os.Equals("FE"))
            {
                MessageBox.Show("Permitido processar apenas ordem de serviço com Status de Finalizado.", "Informativo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("Confirma o processamento da OS Nº " + (bsOrdemServico.Current as TRegistro_LanServico).Id_osstr + "?",
                                "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                try
                {
                    TCN_LanServico.ProcessarOSPatrimonio(bsOrdemServico.Current as TRegistro_LanServico, null);
                    MessageBox.Show("Ordem de Serviço processada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    afterBuscarOrdem();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.Trim());
                }
        }

        private void bb_estornarProc_Click(object sender, EventArgs e)
        {
            estornarOS();
        }

        private void estornarOS()
        {
            if (bsOrdemServico.Current != null)
            {
                if ((bsOrdemServico.Current as TRegistro_LanServico).St_os.Trim().ToUpper() != "PR")
                {
                    MessageBox.Show("Ordem de serviço selecionada não se encontra processada.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (MessageBox.Show("Confirma estorno do processamento da Ordem Serviço Selecionada?", "Pergunta", MessageBoxButtons.YesNo,
                                   MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    == DialogResult.Yes)
                {
                    try
                    {
                        TCN_LanServico.EstornarProcessarOSOficina(bsOrdemServico.Current as TRegistro_LanServico, null);
                        MessageBox.Show("Estorno realizado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        afterBuscarOrdem();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.Trim());
                    }
                }
            }
        }

        private void TFLocManutencao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F2))
                novoPatri();
            else if (e.KeyCode.Equals(Keys.F10))
                estornarOS();
            else if (e.KeyCode.Equals(Keys.F9))
                processarOS();
            else if (e.KeyCode.Equals(Keys.F7))
                BB_Buscar_Click(sender, new EventArgs());
        }

        private void relatorioPedidosSinteticoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RelatorioOs();
        }

        private void RelatorioOs()
        {
            if (bsOrdemServico.Count > 0)
            {
                using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                {
                    //Buscar pecas das OS
                    for (int i = 0; i < bsOrdemServico.Count; i++)
                        if ((bsOrdemServico[i] as TRegistro_LanServico).lPecas.Count.Equals(0))
                        {
                            //Buscar Pecas/Servicos
                            (bsOrdemServico[i] as TRegistro_LanServico).lPecas =
                                CamadaNegocio.Servicos.TCN_LanServicoPecas.Buscar((bsOrdemServico[i] as TRegistro_LanServico).Id_osstr,
                                                                                  (bsOrdemServico[i] as TRegistro_LanServico).Cd_empresa,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  0,
                                                                                  0,
                                                                                  0,
                                                                                  0,
                                                                                  0,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  false,
                                                                                  0,
                                                                                  null);
                        }
                    FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                    Rel.Altera_Relatorio = Altera_Relatorio;
                    Rel.DTS_Relatorio = bsOrdemServico;
                    Rel.Nome_Relatorio = "FRel_OrdemServico";
                    Rel.NM_Classe = Name;
                    Rel.Modulo = string.Empty;
                    Rel.Ident = "FRel_OrdemServico";
                    fImp.St_enabled_enviaremail = true;
                    fImp.pCd_clifor = string.Empty;
                    fImp.pMensagem = "RELATORIO ORDEM SERVIÇO";

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
                                           "RELATORIO ORDEM SERVIÇO",
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
                                           "RELATORIO ORDEM SERVIÇO",
                                           fImp.pDs_mensagem);
                }
            }
            else
                MessageBox.Show("Não existe ordem serviço para imprimir relatorio.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void listaOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bsOrdemServico.Count > 0)
            {
                using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                {
                    FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                    Rel.Altera_Relatorio = Altera_Relatorio;
                    Rel.DTS_Relatorio = bsOrdemServico;
                    Rel.Nome_Relatorio = "TFLanOrdem_Servico_ListaOS";
                    Rel.NM_Classe = Name;
                    Rel.Modulo = "OSE";
                    Rel.Ident = "TFLanOrdem_Servico_ListaOS";
                    fImp.St_enabled_enviaremail = true;
                    fImp.pCd_clifor = string.Empty;
                    fImp.pMensagem = "RELATORIO LISTA DE OS";

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
                                           "RELATORIO LISTA DE OS",
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
                                           "RELATORIO LISTA DE OS",
                                           fImp.pDs_mensagem);
                }
            }
            else
            {
                MessageBox.Show("Não existe Registros Para Imprimir o Relatório!");
            }
        }

        private void BB_Alterar_Click(object sender, EventArgs e)
        {
            if (bsOrdemServico.Current != null)
            {
                if ((bsOrdemServico.Current as TRegistro_LanServico).St_os.Trim().ToUpper().Equals("CA"))
                {
                    MessageBox.Show("Não é permitido evoluir OS CANCELADA.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if ((bsOrdemServico.Current as TRegistro_LanServico).St_os.Trim().ToUpper().Equals("PR"))
                {
                    MessageBox.Show("Não é permitido evoluir OS PROCESSADA.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                using (TFEvoluirOSServico fEvoluir = new TFEvoluirOSServico())
                {
                    fEvoluir.rOS = bsOrdemServico.Current as TRegistro_LanServico;
                    if (fEvoluir.ShowDialog() == DialogResult.OK)
                        try
                        {
                            TCN_LanServico.Gravar(fEvoluir.rOS, null);
                            bsOrdemServico.ResetCurrentItem();
                            MessageBox.Show("Ordem serviço evoluída com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            }
        }

        private void bsOrdemServico_PositionChanged(object sender, EventArgs e)
        {
            if (bsOrdemServico.Current == null)
                return;


            (bsOrdemServico.Current as TRegistro_LanServico).lEvolucao = TCN_LanServicoEvolucao.Buscar((bsOrdemServico.Current as TRegistro_LanServico).Id_osstr,
                                                                                                       (bsOrdemServico.Current as TRegistro_LanServico).Cd_empresa,
                                                                                                       string.Empty,
                                                                                                       string.Empty,
                                                                                                       string.Empty,
                                                                                                       string.Empty,
                                                                                                       string.Empty,
                                                                                                       string.Empty,
                                                                                                       true,
                                                                                                       0,
                                                                                                       null);
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex.Equals(0))
            {
                BB_Novo.Enabled = true;
                BB_Alterar.Enabled = false;
                bb_estornarProc.Enabled = false;
                bb_processar.Enabled = false;
                toolStripDropDown_Relatorios.Enabled = false;
            }
            else
            {
                BB_Novo.Enabled = false;
                BB_Alterar.Enabled = true;
                bb_estornarProc.Enabled = true;
                bb_processar.Enabled = true;
                toolStripDropDown_Relatorios.Enabled = true;
                if(bsPatrimonio.Current != null)
                {
                    nr_patrimoniobusca.Text = (bsPatrimonio.Current as TRegistro_CadPatrimonio).Nr_patrimonio;
                    afterBuscarOrdem();
                }
            }
        }

        private void gPatrimonio_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gPatrimonio.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsPatrimonio.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new TRegistro_CadPatrimonio());
            TList_CadPatrimonio lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gPatrimonio.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gPatrimonio.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new TList_CadPatrimonio(lP.Find(gPatrimonio.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gPatrimonio.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new TList_CadPatrimonio(lP.Find(gPatrimonio.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gPatrimonio.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsPatrimonio.List as TList_CadPatrimonio).Sort(lComparer);
            bsPatrimonio.ResetBindings(false);
            gPatrimonio.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void bbGrupo_Click(object sender, EventArgs e)
        {
            string vColunas = "a.DS_Grupo|Descrição Grupo Produto|350;" +
                              "a.CD_Grupo|Cód. Grupo|100";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_grupo },
                                    new TCD_CadGrupoProduto(), string.Empty);
        }

        private void cd_grupo_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.CD_Grupo|=|'" + cd_grupo.Text + "'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cd_grupo },
                                    new TCD_CadGrupoProduto());
        }

        private void gOrdemServico_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gOrdemServico.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsOrdemServico.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new TRegistro_LanServico());
            TList_LanServico lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gOrdemServico.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gOrdemServico.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new TList_LanServico(lP.Find(gOrdemServico.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gOrdemServico.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new TList_LanServico(lP.Find(gOrdemServico.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gOrdemServico.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsOrdemServico.List as TList_LanServico).Sort(lComparer);
            bsOrdemServico.ResetBindings(false);
            gOrdemServico.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }
    }
}
