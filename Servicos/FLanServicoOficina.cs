using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CamadaDados.Servicos;
using CamadaNegocio.Servicos;

namespace Servicos
{
    public partial class TFLanServicoOficina : Form
    {
        private bool Altera_Relatorio = false;

        public TFLanServicoOficina()
        {
            InitializeComponent();
        }

        private void LimparFiltros()
        {
            id_osbusca.Clear();
            CD_Empresa_Busca.Clear();
            CD_Clifor_Busca.Clear();
            id_tecnico.Clear();
            id_etapa.Clear();
            placaveiculo.Clear();
            rbAbertura.Checked = true;
            DT_Final.Clear();
            DT_Inic.Clear();
            cck_Todas.Checked = true;
            ST_OS_Aberta.Checked = false;
            ST_OS_Cancelada.Checked = false;
            ST_OS_Fechada.Checked = false;
            cbProcessada.Checked = false;
        }

        private void afterNovo()
        {
            using (TFServicoOficina fOs = new TFServicoOficina())
            {
                if(fOs.ShowDialog() == DialogResult.OK)
                    try
                    {
                        CamadaNegocio.Servicos.TCN_LanServico.Gravar(fOs.rOS, null);
                        MessageBox.Show("Ordem serviço aberta com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.LimparFiltros();
                        id_osbusca.Text = fOs.rOS.Id_osstr;
                        this.afterBusca();
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void afterExclui()
        {
            if (bsOrdemServico.Current != null)
            {
                if ((bsOrdemServico.Current as CamadaDados.Servicos.TRegistro_LanServico).St_os.Trim().ToUpper().Equals("CA"))
                {
                    MessageBox.Show("Ordem de serviço ja se encontra cancelada.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if ((bsOrdemServico.Current as CamadaDados.Servicos.TRegistro_LanServico).St_os.Trim().ToUpper().Equals("AB") ||
                    (bsOrdemServico.Current as CamadaDados.Servicos.TRegistro_LanServico).St_os.Trim().ToUpper().Equals("FE"))
                {
                    if (MessageBox.Show("Confirma exclusão da OS Nº" + (bsOrdemServico.Current as CamadaDados.Servicos.TRegistro_LanServico).Id_osstr + "?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                        == DialogResult.Yes)
                    {
                        try
                        {
                            CamadaNegocio.Servicos.TCN_LanServico.cancelar(bsOrdemServico.Current as CamadaDados.Servicos.TRegistro_LanServico, null);
                            MessageBox.Show("Ordem serviço cancelada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.LimparFiltros();
                            id_osbusca.Text = (bsOrdemServico.Current as CamadaDados.Servicos.TRegistro_LanServico).Id_osstr;
                            this.afterBusca();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                    }
                }
                else
                    MessageBox.Show("Permitido cancelar somente ordem serviço com status <ABERTA> ou <FINALIZADA>.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Obrigatorio selecionar ordem serviço para cancelar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void EvoluirOS()
        {
            if (bsOrdemServico.Current != null)
            {
                if ((bsOrdemServico.Current as CamadaDados.Servicos.TRegistro_LanServico).St_os.Trim().ToUpper().Equals("CA"))
                {
                    MessageBox.Show("Não é permitido evoluir OS CANCELADA.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if ((bsOrdemServico.Current as CamadaDados.Servicos.TRegistro_LanServico).St_os.Trim().ToUpper().Equals("PR"))
                {
                    MessageBox.Show("Não é permitido evoluir OS PROCESSADA.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if ((bsOrdemServico.Current as CamadaDados.Servicos.TRegistro_LanServico).St_os.Trim().ToUpper().Equals("DV"))
                {
                    MessageBox.Show("Não é permitido evoluir OS DEVOLVIDA.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                using (TFEvoluirOSOficina fEvoluir = new TFEvoluirOSOficina())
                {
                    fEvoluir.rOS = bsOrdemServico.Current as TRegistro_LanServico;
                    if(fEvoluir.ShowDialog() == DialogResult.OK)
                        try
                        {
                            CamadaNegocio.Servicos.TCN_LanServico.Gravar(fEvoluir.rOS, null);
                            MessageBox.Show("Ordem serviço evoluida com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    this.LimparFiltros();
                    id_osbusca.Text = fEvoluir.rOS.Id_osstr;
                    this.afterBusca();
                }
            }
        }

        private void afterBusca()
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
            else if (rbDevolucao.Checked)
                tp_data = "D";
            bsOrdemServico.DataSource =
                CamadaNegocio.Servicos.TCN_LanServico.Buscar(string.Empty,
                                                             CD_Empresa_Busca.Text,
                                                             CD_Clifor_Busca.Text,
                                                             string.Empty,
                                                             string.Empty,
                                                             string.Empty,
                                                             string.Empty,
                                                             id_osbusca.Text,
                                                             string.Empty,
                                                             string.Empty,
                                                             id_tecnico.Text,
                                                             id_etapa.Text,
                                                             string.Empty,
                                                             string.Empty,
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
                                                             null);
            bsOrdemServico_PositionChanged(this, new EventArgs());
        }

        private void afterPrint()
        {
            if (bsOrdemServico.Current != null)
                using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                {
                    FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                    Rel.Altera_Relatorio = Altera_Relatorio;
                    BindingSource bs = new BindingSource();
                    bs.DataSource = new CamadaDados.Servicos.TList_LanServico() { bsOrdemServico.Current as CamadaDados.Servicos.TRegistro_LanServico };
                    Rel.DTS_Relatorio = bs;
                    //Endereco Empresa
                    BindingSource bsEmp = new BindingSource();
                    bsEmp.DataSource = CamadaNegocio.Diversos.TCN_CadEmpresa.Busca((bsOrdemServico.Current as CamadaDados.Servicos.TRegistro_LanServico).Cd_empresa,
                                                                                   string.Empty,
                                                                                   string.Empty,
                                                                                   null);
                    Rel.Adiciona_DataSource("DTS_EMP", bsEmp);
                    //Endereco Cliente
                    BindingSource bsEndCli = new BindingSource();
                    bsEndCli.DataSource = CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Buscar((bsOrdemServico.Current as CamadaDados.Servicos.TRegistro_LanServico).Cd_clifor,
                                                                                                    (bsOrdemServico.Current as CamadaDados.Servicos.TRegistro_LanServico).Cd_endereco,
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
                    Rel.Adiciona_DataSource("DTS_ENDCLI", bsEndCli);
                    Rel.Nome_Relatorio = "FRel_OSOficina";
                    Rel.NM_Classe = this.Name;
                    Rel.Modulo = string.Empty;
                    Rel.Ident = "FRel_OSOficina";
                    fImp.St_enabled_enviaremail = true;
                    fImp.pCd_clifor = string.Empty;
                    fImp.pMensagem = "ORDEM SERVIÇO OFICINA";

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
                                           "ORDEM SERVIÇO OFICINA",
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
                                               "ORDEM SERVIÇO OFICINA",
                                               fImp.pDs_mensagem);
                }
        }

        private void ProcessarOs()
        {
            if (bsOrdemServico.Current != null)
                if ((bsOrdemServico.Current as CamadaDados.Servicos.TRegistro_LanServico).St_os.Trim().ToUpper().Equals("FE"))
                {
                    if(MessageBox.Show("Confirma processamento OS Nº" + (bsOrdemServico.Current as CamadaDados.Servicos.TRegistro_LanServico).Id_osstr + "?",
                        "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                        == DialogResult.Yes)
                        try
                        {
                            List<CamadaDados.Faturamento.Pedido.TRegistro_Pedido> lPed =
                            Proc_Commoditties.TProcessaPedidoOS.ProcessarOS(new List<CamadaDados.Servicos.TRegistro_LanServico> { bsOrdemServico.Current as CamadaDados.Servicos.TRegistro_LanServico });
                            CamadaNegocio.Servicos.TCN_LanServico.ProcessarServico(new List<TRegistro_LanServico>() { bsOrdemServico.Current as CamadaDados.Servicos.TRegistro_LanServico }, lPed, null);
                            if (MessageBox.Show("Ordem serviço processada com sucesso.\r\n" +
                                                "Deseja gerar faturamento agora?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                                                MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                            {
                                try
                                {
                                    ////Gerar nota fiscal dos pedidos
                                    lPed.ForEach(p =>
                                        {
                                            p = CamadaNegocio.Faturamento.Pedido.TCN_Pedido.Busca_Registro_Pedido(p.Nr_pedido.ToString(), null);
                                            //Buscar itens pedido
                                            CamadaNegocio.Faturamento.Pedido.TCN_Pedido.Busca_Pedido_Itens(p, false, null);
                                            //Buscar financeiro pedido
                                            p.Pedidos_DT_Vencto = CamadaNegocio.Faturamento.Pedido.TCN_LanPedido_DT_Vencto.Busca(p.Nr_pedido, null);
                                            CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento rNf =
                                            Proc_Commoditties.TProcessaPedFaturar.ProcessaPedFaturar(p, false, decimal.Zero);
                                            //Gravar Nota Fiscal
                                            CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.GravarFaturamento(rNf, null, null);
                                            //Imprimir Nota Fiscal
                                            //Se for nota propria e NF-e
                                            if (rNf.Tp_nota.Trim().ToUpper().Equals("P"))
                                                if (rNf.Cd_modelo.Trim().Equals("55"))
                                                {
                                                    if (MessageBox.Show("Deseja enviar NF-e para a receita agora?", "Pergunta", MessageBoxButtons.YesNo,
                                                         MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                                                    {
                                                        //Verificar se é nota de produto ou mista
                                                        object obj = new CamadaDados.Faturamento.Cadastros.TCD_CadSerieNF().BuscarEscalar(
                                                                        new Utils.TpBusca[]
                                                                {
                                                                    new Utils.TpBusca()
                                                                    {
                                                                        vNM_Campo = "a.nr_serie",
                                                                        vOperador = "=",
                                                                        vVL_Busca = "'" + rNf.Nr_serie.Trim() + "'"
                                                                    }
                                                                }, "a.tp_serie");
                                                        if (obj != null)
                                                            if (obj.ToString().Trim().ToUpper().Equals("P") ||
                                                                obj.ToString().Trim().ToUpper().Equals("M"))
                                                            {
                                                                try
                                                                {
                                                                    using (srvNFE.TFGerenciarNFe fGerNfe = new srvNFE.TFGerenciarNFe())
                                                                    {
                                                                        fGerNfe.rNfe = CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.BuscarNF(rNf.Cd_empresa, 
                                                                                                                                                        rNf.Nr_lanctofiscalstr,
                                                                                                                                                        null);
                                                                        fGerNfe.ShowDialog();
                                                                    }
                                                                }
                                                                catch (Exception ex)
                                                                { MessageBox.Show("Erro enviar NF-e: " + ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                                                            }
                                                            else if (obj.ToString().Trim().ToUpper().Equals("S"))
                                                            {
                                                                try
                                                                {
                                                                    CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento rNfs =
                                                                        CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.BuscarNF(rNf.Cd_empresa, 
                                                                                                                                         rNf.Nr_lanctofiscalstr,
                                                                                                                                         null);
                                                                    NFES.TGerarRPS.CriarArquivoRPS(rNfs.rCfgNfe, new List<CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento>() { rNfs });
                                                                    MessageBox.Show("NFS-e enviada com sucesso. Aguarde alguns segundos e consulte o status do lote.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                                }
                                                                catch (Exception ex)
                                                                { MessageBox.Show("Erro enviar NFS-e: " + ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                                                            }
                                                    }
                                                }
                                                else
                                                    //Chamar tela de impressao para a nota fiscal
                                                    //somente se for nota propria
                                                    using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                                                    {
                                                        fImp.St_enabled_enviaremail = true;
                                                        fImp.pCd_clifor = rNf.Cd_clifor;
                                                        fImp.pMensagem = "NOTA FISCAL Nº" + rNf.Nr_notafiscal.ToString();
                                                        if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                                                        {
                                                            FormRelPadrao.LayoutNotaFiscal Relatorio = new FormRelPadrao.LayoutNotaFiscal();
                                                            Relatorio.Imprime_NF(rNf,
                                                                                fImp.pSt_imprimir,
                                                                                fImp.pSt_visualizar,
                                                                                fImp.pSt_enviaremail,
                                                                                fImp.pDestinatarios,
                                                                                "NOTA FISCAL Nº " + rNf.Nr_notafiscal.ToString(),
                                                                                fImp.pMensagem);
                                                        }
                                                    }
                                        });
                                }
                                catch(Exception ex)
                                {
                                    throw new Exception("Erro gerar Nota Fiscal.\r\n" + ex.Message.Trim() + "\r\n" +
                                                        "Efetue as correções necessarias e proceda ao faturamento\r\n" +
                                                        "dos pedidos gerados pelo processamento da OS");
                                }
                            }
                            this.LimparFiltros();
                            id_osbusca.Text = (bsOrdemServico.Current as CamadaDados.Servicos.TRegistro_LanServico).Id_osstr;
                            this.afterBusca();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
                else
                    MessageBox.Show("Permitido processar somente OS FINALIZADA.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void EstornarProcessarOs()
        {
            if (bsOrdemServico.Current != null)
            {
                if ((bsOrdemServico.Current as CamadaDados.Servicos.TRegistro_LanServico).St_os.Trim().ToUpper() != "PR")
                {
                    MessageBox.Show("Ordem de serviço selecionada não se encontra PROCESSADA.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (MessageBox.Show("Confirma estorno do processamento da Ordem Serviço Selecionada?", "Pergunta", MessageBoxButtons.YesNo,
                                   MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    == DialogResult.Yes)
                {
                    try
                    {
                        TCN_LanServico.EstornarProcessarOSOficina(bsOrdemServico.Current as CamadaDados.Servicos.TRegistro_LanServico, null);
                        MessageBox.Show("Estorno realizado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.LimparFiltros();
                        id_osbusca.Text = (bsOrdemServico.Current as CamadaDados.Servicos.TRegistro_LanServico).Id_osstr;
                        this.afterBusca();
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim()); }
                }
            }
        }

        private void DevolverOs()
        {
            if (bsOrdemServico.Current != null)
                if ((bsOrdemServico.Current as TRegistro_LanServico).St_os.Trim().ToUpper().Equals("PR"))
                {
                    using (Parametros.Diversos.TFRegraUsuario fUser = new Parametros.Diversos.TFRegraUsuario())
                    {
                        fUser.Ds_regraespecial = "PERMITIR DEVOLUCAO ORDEM SERVICO";
                        if (fUser.ShowDialog() == DialogResult.OK)
                        {
                            (bsOrdemServico.Current as TRegistro_LanServico).Logindevolucao = fUser.Login;
                            if ((bsOrdemServico.Current as TRegistro_LanServico).lAcessorios.Count > 0)
                                using (TFListaAcessorios fLista = new TFListaAcessorios())
                                {
                                    fLista.lAcessorios = (bsOrdemServico.Current as TRegistro_LanServico).lAcessorios;
                                    fLista.ShowDialog();
                                    (bsOrdemServico.Current as TRegistro_LanServico).lAcessorios = fLista.lAcessorios;
                                }
                            try
                            {
                                CamadaNegocio.Servicos.TCN_LanServico.DevolverOS(bsOrdemServico.Current as TRegistro_LanServico, null);
                                MessageBox.Show("Ordem serviço devolvida com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.LimparFiltros();
                                id_osbusca.Text = (bsOrdemServico.Current as TRegistro_LanServico).Id_osstr;
                                this.afterBusca();
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                        }
                    }
                }
                else
                    MessageBox.Show("Permitido devolver somente OS PROCESSADA.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void TFLanServicoAutoCenter_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, g_Pecas);
            Utils.ShapeGrid.RestoreShape(this, gOS);
            Utils.ShapeGrid.RestoreShape(this, dataGridDefault1);
            Utils.ShapeGrid.RestoreShape(this, dataGridDefault2);
            Utils.ShapeGrid.RestoreShape(this, dataGridDefault3);
            Utils.ShapeGrid.RestoreShape(this, dataGridDefault4);
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pFiltro.set_FormatZero();
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

        private void bsOrdemServico_PositionChanged(object sender, EventArgs e)
        {
            if (bsOrdemServico.Current != null)
            {
                //Buscar acessorios
                (bsOrdemServico.Current as CamadaDados.Servicos.TRegistro_LanServico).lAcessorios =
                    CamadaNegocio.Servicos.TCN_Acessorios.Buscar((bsOrdemServico.Current as CamadaDados.Servicos.TRegistro_LanServico).Id_osstr,
                                                                 (bsOrdemServico.Current as CamadaDados.Servicos.TRegistro_LanServico).Cd_empresa,
                                                                 string.Empty,
                                                                 string.Empty,
                                                                 0,
                                                                 string.Empty,
                                                                 null);
                //Buscar evolucao OS
                (bsOrdemServico.Current as CamadaDados.Servicos.TRegistro_LanServico).lEvolucao =
                    CamadaNegocio.Servicos.TCN_LanServicoEvolucao.Buscar((bsOrdemServico.Current as CamadaDados.Servicos.TRegistro_LanServico).Id_osstr,
                                                                         (bsOrdemServico.Current as CamadaDados.Servicos.TRegistro_LanServico).Cd_empresa,
                                                                         string.Empty,
                                                                         string.Empty,
                                                                         string.Empty,
                                                                         string.Empty,
                                                                         string.Empty,
                                                                         string.Empty,
                                                                         false,
                                                                         0,
                                                                         null);
                //Buscar pecas/servicos OS
                (bsOrdemServico.Current as CamadaDados.Servicos.TRegistro_LanServico).lPecas =
                    CamadaNegocio.Servicos.TCN_LanServicoPecas.Buscar((bsOrdemServico.Current as CamadaDados.Servicos.TRegistro_LanServico).Id_osstr,
                                                                      (bsOrdemServico.Current as CamadaDados.Servicos.TRegistro_LanServico).Cd_empresa,
                                                                      string.Empty,
                                                                      string.Empty,
                                                                      string.Empty,
                                                                      decimal.Zero,
                                                                      decimal.Zero,
                                                                      decimal.Zero,
                                                                      decimal.Zero,
                                                                      decimal.Zero,
                                                                      string.Empty,
                                                                      string.Empty,
                                                                      false,
                                                                      0,
                                                                      null);
                //Buscar Historico OS
                (bsOrdemServico.Current as CamadaDados.Servicos.TRegistro_LanServico).lHistorico =
                    CamadaNegocio.Servicos.TCN_Historico.Buscar((bsOrdemServico.Current as CamadaDados.Servicos.TRegistro_LanServico).Id_osstr,
                                                                (bsOrdemServico.Current as CamadaDados.Servicos.TRegistro_LanServico).Cd_empresa,
                                                                string.Empty,
                                                                string.Empty,
                                                                null);
                //Buscar Fotos OS
                (bsOrdemServico.Current as CamadaDados.Servicos.TRegistro_LanServico).lImagens =
                    CamadaNegocio.Servicos.Cadastros.TCN_Imagens.Buscar((bsOrdemServico.Current as CamadaDados.Servicos.TRegistro_LanServico).Id_osstr,
                                                                        (bsOrdemServico.Current as CamadaDados.Servicos.TRegistro_LanServico).Cd_empresa,
                                                                        null);
                bsOrdemServico.ResetCurrentItem();
            }
        }

        private void BB_Empresa_Busca_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { CD_Empresa_Busca }, string.Empty);
        }

        private void CD_Empresa_Busca_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + CD_Empresa_Busca.Text.Trim() + "'",
                                                     new Componentes.EditDefault[] { CD_Empresa_Busca });
        }

        private void BB_Clifor_Busca_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { CD_Clifor_Busca }, string.Empty);
        }

        private void CD_Clifor_Busca_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + CD_Clifor_Busca.Text.Trim() + "'",
                                                    new Componentes.EditDefault[] { CD_Clifor_Busca },
                                                    new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void bb_tecnico_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { id_tecnico }, "isnull(a.st_tecnico, 'N')|=|'S'");
        }

        private void id_tecnico_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + id_tecnico.Text.Trim() + "';isnull(a.st_tecnico, 'N')|=|'S'",
                                                    new Componentes.EditDefault[] { id_tecnico },
                                                    new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void bb_etapa_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_etapa|Etapa OS|200;" +
                              "a.id_etapa|Id. Etapa|80";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { id_etapa },
                                                new CamadaDados.Servicos.Cadastros.TCD_EtapaOrdem(), string.Empty);
        }

        private void id_etapa_Leave(object sender, EventArgs e)
        {
            string vParam = "a.id_etapa|=|" + id_etapa.Text;
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { id_etapa },
                                                new CamadaDados.Servicos.Cadastros.TCD_EtapaOrdem());
        }

        private void BB_Alterar_Click(object sender, EventArgs e)
        {
            this.EvoluirOS();
        }

        private void BB_Excluir_Click(object sender, EventArgs e)
        {
            this.afterExclui();
        }

        private void BB_ProcessarOS_Click(object sender, EventArgs e)
        {
            this.ProcessarOs();
        }

        private void TFLanServicoOficina_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F2))
                this.afterNovo();
            else if (e.KeyCode.Equals(Keys.F3))
                this.EvoluirOS();
            else if (e.KeyCode.Equals(Keys.F5))
                this.afterExclui();
            else if (e.KeyCode.Equals(Keys.F7))
                this.afterBusca();
            else if (e.KeyCode.Equals(Keys.F10))
                this.ProcessarOs();
            else if (e.KeyCode.Equals(Keys.F11))
                this.EstornarProcessarOs();
            else if (e.KeyCode.Equals(Keys.F12))
                this.DevolverOs();
            else if (e.Control && e.KeyCode.Equals(Keys.P))
            {
                this.Altera_Relatorio = true;
                MessageBox.Show("Execute o relatorio que deseja alterar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void gOS_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gOS.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsOrdemServico.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new TRegistro_LanServico());
            TList_LanServico lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gOS.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gOS.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new TList_LanServico(lP.Find(gOS.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gOS.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new TList_LanServico(lP.Find(gOS.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gOS.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsOrdemServico.List as TList_LanServico).Sort(lComparer);
            bsOrdemServico.ResetBindings(false);
            gOS.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void gOS_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
                if (e.ColumnIndex == 0)
                {
                    if (e.Value.ToString().Trim().ToUpper().Equals("FINALIZADA"))
                        gOS.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Teal;
                    else if (e.Value.ToString().Trim().ToUpper().Equals("CANCELADA"))
                        gOS.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
                    else if (e.Value.ToString().Trim().ToUpper().Equals("PROCESSADA"))
                        gOS.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Blue;
                    else if (e.Value.ToString().Trim().ToUpper().Equals("DEVOLVIDA"))
                        gOS.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Green;
                    else
                        gOS.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                }
        }

        private void bb_devolver_Click(object sender, EventArgs e)
        {
            this.DevolverOs();
        }

        private void bb_estornar_Click(object sender, EventArgs e)
        {
            this.EstornarProcessarOs();
        }

        private void miVisualizarOS_Click(object sender, EventArgs e)
        {
            this.afterPrint();
        }

        private void TFLanServicoOficina_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, g_Pecas);
            Utils.ShapeGrid.SaveShape(this, gOS);
            Utils.ShapeGrid.SaveShape(this, dataGridDefault1);
            Utils.ShapeGrid.SaveShape(this, dataGridDefault2);
            Utils.ShapeGrid.SaveShape(this, dataGridDefault3);
            Utils.ShapeGrid.SaveShape(this, dataGridDefault4);
        }
    }
}
