using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Servicos
{
    public partial class TFLanOSServico : Form
    {
        private bool Altera_Relatorio = false;

        public TFLanOSServico()
        {
            InitializeComponent();
        }

        private void LimparFiltros()
        {
            id_os.Clear();
            nr_osorigem.Clear();
            CD_Empresa.Clear();
            id_tecnico.Clear();
            id_etapa.Clear();
            CD_Clifor.Clear();
            DT_Final.Clear();
            DT_Inic.Clear();
            cck_Todas.Checked = true;
            ST_OS_Aberta.Checked = false;
            ST_OS_Fechada.Checked = false;
            cbProcessada.Checked = false;
            cbCancelada.Checked = false;
            cbExpirada.Checked = false;
            cbRetirada.Checked = false;
        }

        private void afterNovo()
        {
            using (TFAbrirOSServico fOs = new TFAbrirOSServico())
            {
                if(fOs.ShowDialog() == DialogResult.OK)
                    if(fOs.rOS != null)
                        try
                        {
                            //Buscar etapa de abertura da OS
                            CamadaDados.Servicos.Cadastros.TList_EtapaOrdem lEtapa =
                            new CamadaDados.Servicos.Cadastros.TCD_EtapaOrdem().Select(
                                new Utils.TpBusca[]
                            {
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "isnull(a.st_iniciarOS, 'N')",
                                    vOperador = "=",
                                    vVL_Busca = "'S'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = string.Empty,
                                    vOperador = "exists",
                                    vVL_Busca = "(select 1 from tb_ose_tpordem_x_etapa x "+
                                                "where x.id_etapa = a.id_etapa "+
                                                "and x.tp_ordem = " + fOs.rOS.Tp_ordemstr + ")"
                                }
                            }, 1, string.Empty);
                            if (lEtapa.Count > 0)
                            {
                                //Buscar tecnico
                                object obj = new CamadaDados.Financeiro.Cadastros.TCD_CadClifor().BuscarEscalar(
                                                new Utils.TpBusca[]
                                            {
                                                new Utils.TpBusca()
                                                {
                                                    vNM_Campo = "a.loginvendedor",
                                                    vOperador = "=",
                                                    vVL_Busca = "'" + Utils.Parametros.pubLogin.Trim() + "'"
                                                }
                                            }, "a.cd_clifor");
                                fOs.rOS.lEvolucao.Add(
                                    new CamadaDados.Servicos.TRegistro_LanServicoEvolucao()
                                    {
                                        Cd_tecnico = obj != null ? obj.ToString() : string.Empty,
                                        Dt_inicio = fOs.rOS.Dt_abertura,
                                        Id_etapa = lEtapa[0].Id_etapa,
                                        Ds_evolucao = "ETAPA ABERTURA DA OS",
                                        St_envterceiro = lEtapa[0].St_envterceirobool,
                                        St_finalizarOS = lEtapa[0].St_finalizarOSbool,
                                        St_iniciarOS = lEtapa[0].St_iniciarOSbool
                                    });
                            }
                            CamadaNegocio.Servicos.TCN_LanServico.Gravar(fOs.rOS, null);
                            MessageBox.Show("OS Nº" + fOs.rOS.Id_osstr + " gravada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            EnviarEmail();
                            LimparFiltros();
                            id_os.Text = fOs.rOS.Id_osstr;
                            CD_Empresa.Text = fOs.rOS.Cd_empresa;
                            afterBusca();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void EvoluirOS()
        {
            if (bsOS.Current != null)
            {
                if ((bsOS.Current as CamadaDados.Servicos.TRegistro_LanServico).St_os.Trim().ToUpper().Equals("CA"))
                {
                    MessageBox.Show("Não é permitido evoluir OS CANCELADA.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if ((bsOS.Current as CamadaDados.Servicos.TRegistro_LanServico).St_os.Trim().ToUpper().Equals("PR"))
                {
                    MessageBox.Show("Não é permitido evoluir OS PROCESSADA.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                using (TFEvoluirOSServico fEvoluir = new TFEvoluirOSServico())
                {
                    fEvoluir.rOS = bsOS.Current as CamadaDados.Servicos.TRegistro_LanServico;
                    if (fEvoluir.ShowDialog() == DialogResult.OK)
                        try
                        {
                            CamadaNegocio.Servicos.TCN_LanServico.Gravar(fEvoluir.rOS, null);
                            bsOS.ResetCurrentItem();
                            MessageBox.Show("Ordem serviço evoluida com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            EnviarEmail();
                            afterBusca();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            }
        }

        private void afterPrint()
        {
            if (bsOS.Current != null)
            {
                FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                Rel.Altera_Relatorio = Altera_Relatorio;
                BindingSource bs = new BindingSource();
                bs.DataSource = new CamadaDados.Servicos.TList_LanServico() { bsOS.Current as CamadaDados.Servicos.TRegistro_LanServico };
                Rel.DTS_Relatorio = bs;
                
                //Endereco Cliente
                BindingSource bsEnd = new BindingSource();
                if (!string.IsNullOrEmpty((bsOS.Current as CamadaDados.Servicos.TRegistro_LanServico).Cd_clifor) &&
                    !string.IsNullOrEmpty((bsOS.Current as CamadaDados.Servicos.TRegistro_LanServico).Cd_endereco))
                    bsEnd.DataSource = CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Buscar((bsOS.Current as CamadaDados.Servicos.TRegistro_LanServico).Cd_clifor,
                                                                                                 (bsOS.Current as CamadaDados.Servicos.TRegistro_LanServico).Cd_endereco,
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
                else
                {
                    CamadaDados.Financeiro.Cadastros.TList_CadEndereco lEnd = new CamadaDados.Financeiro.Cadastros.TList_CadEndereco();
                    lEnd.Add(new CamadaDados.Financeiro.Cadastros.TRegistro_CadEndereco
                    {
                        Ds_endereco = (bsOS.Current as CamadaDados.Servicos.TRegistro_LanServico).Ds_endereco,
                        DS_Cidade = (bsOS.Current as CamadaDados.Servicos.TRegistro_LanServico).Ds_cidade,
                        UF = (bsOS.Current as CamadaDados.Servicos.TRegistro_LanServico).Sigla_uf,
                        Fone = (bsOS.Current as CamadaDados.Servicos.TRegistro_LanServico).Fone
                    });
                    bsEnd.DataSource = lEnd;
                }
                Rel.Adiciona_DataSource("DTS_ENDCLI", bsEnd);
                Rel.Nome_Relatorio = "FRel_OSServico";
                Rel.NM_Classe = Name;
                Rel.Modulo = string.Empty;
                Rel.Ident = "FRel_OSServico";

                //Endereco Empresa
                BindingSource bsEmp = new BindingSource();
                bsEmp.DataSource = CamadaNegocio.Diversos.TCN_CadEmpresa.Busca((bsOS.Current as CamadaDados.Servicos.TRegistro_LanServico).Cd_empresa,
                                                                               string.Empty,
                                                                               string.Empty,
                                                                               null);
                //Verificar se existe logo configurada para a empresa
                if (bsEmp.Count > 0)
                    if ((bsEmp.Current as CamadaDados.Diversos.TRegistro_CadEmpresa).Img != null)
                        Rel.Parametros_Relatorio.Add("IMAGEM_RELATORIO", (bsEmp.Current as CamadaDados.Diversos.TRegistro_CadEmpresa).Img);
                Rel.Adiciona_DataSource("DTS_EMP", bsEmp);
                using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                {                   
                    fImp.St_enabled_enviaremail = true;
                    fImp.pCd_clifor = (bsOS.Current as CamadaDados.Servicos.TRegistro_LanServico).Cd_clifor;
                    fImp.pMensagem = "ORDEM SERVIÇO";

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
                                           "ORDEM SERVIÇO",
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
                                               "ORDEM SERVIÇO",
                                               fImp.pDs_mensagem);
                }
            }
        }

        private void EnviarEmail()
        {
            if (bsOS.Current != null)
            {
                //Buscar lista de contatos do cliente que esta configurado para receber OS
                CamadaDados.Financeiro.Cadastros.TList_CadContatoCliFor lContato =
                    CamadaNegocio.Financeiro.Cadastros.TCN_CadContatoCliFor.Buscar(string.Empty,
                                                                                   (bsOS.Current as CamadaDados.Servicos.TRegistro_LanServico).Cd_clifor,
                                                                                   string.Empty,
                                                                                   string.Empty,
                                                                                   string.Empty,
                                                                                   string.Empty,
                                                                                   string.Empty,
                                                                                   false,
                                                                                   false,
                                                                                   true,
                                                                                   string.Empty,
                                                                                   0,
                                                                                   null);
                if (lContato.Count > 0)
                {
                    FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                    Rel.Altera_Relatorio = Altera_Relatorio;
                    BindingSource bs = new BindingSource();
                    bs.DataSource = new CamadaDados.Servicos.TList_LanServico() { bsOS.Current as CamadaDados.Servicos.TRegistro_LanServico };
                    Rel.DTS_Relatorio = bs;
                    //Endereco Empresa
                    BindingSource bsEmp = new BindingSource();
                    bsEmp.DataSource = CamadaNegocio.Diversos.TCN_CadEmpresa.Busca((bsOS.Current as CamadaDados.Servicos.TRegistro_LanServico).Cd_empresa,
                                                                                   string.Empty,
                                                                                   string.Empty,
                                                                                   null);
                    //Verificar se existe logo configurada para a empresa
                    if (bsEmp.Count > 0)
                        if ((bsEmp.List[0] as CamadaDados.Diversos.TRegistro_CadEmpresa).Img != null)
                            Rel.Parametros_Relatorio.Add("IMAGEM_RELATORIO", (bsEmp.List[0] as CamadaDados.Diversos.TRegistro_CadEmpresa).Img);
                    Rel.Adiciona_DataSource("DTS_EMP", bsEmp);
                    //Endereco Cliente
                    BindingSource bsEndCli = new BindingSource();
                    bsEndCli.DataSource = CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Buscar((bsOS.Current as CamadaDados.Servicos.TRegistro_LanServico).Cd_clifor,
                                                                                                    (bsOS.Current as CamadaDados.Servicos.TRegistro_LanServico).Cd_endereco,
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
                    Rel.Nome_Relatorio = "FRel_OSServico";
                    Rel.NM_Classe = Name;
                    Rel.Modulo = string.Empty;
                    Rel.Ident = "FRel_OSServico";
                    List<string> dest = new List<string>();
                    if(lContato.Count.Equals(1))
                        lContato.ForEach(p => dest.Add(p.Email));
                    else
                        using (Proc_Commoditties.TFListaContatos fContato = new Proc_Commoditties.TFListaContatos())
                        {
                            fContato.lContato = lContato;
                            if (fContato.ShowDialog() == DialogResult.OK)
                                lContato.FindAll(p => p.St_utilizarContato).ForEach(p => dest.Add(p.Email));
                        }
                    Rel.Gera_Relatorio(string.Empty,
                                       false,
                                       false,
                                       true,
                                       false,
                                       string.Empty,
                                       dest,
                                       null,
                                       "ORDEM SERVIÇO Nº" + (bsOS.Current as CamadaDados.Servicos.TRegistro_LanServico).Id_osstr,
                                       "Email enviado automaticamente.");
                }
            }
        }

        private void afterBusca()
        {
            string status = string.Empty;
            string virg = string.Empty;
            if (ST_OS_Aberta.Checked)
            {
                status = "'AB'";
                virg = ",";
            }
            if (ST_OS_Fechada.Checked)
            {
                status += virg + "'FE'";
                virg = ",";
            }
            if (cbRetirada.Checked)
            {
                status += virg + "'DV'";
                virg = ",";
            }
            if (cbCancelada.Checked)
            {
                status += virg + "'CA'";
                virg = ",";
            }
            if (cbProcessada.Checked)
                status += virg + "'PR'";

            bsOS.DataSource = CamadaNegocio.Servicos.TCN_LanServico.Buscar(string.Empty,
                                                                           CD_Empresa.Text,
                                                                           CD_Clifor.Text,
                                                                           string.Empty,
                                                                           string.Empty,
                                                                           string.Empty,
                                                                           string.Empty,
                                                                           id_os.Text,
                                                                           string.Empty,
                                                                           nr_osorigem.Text,
                                                                           id_tecnico.Text,
                                                                           id_etapa.Text,
                                                                           string.Empty,
                                                                           string.Empty,
                                                                           rbFinalizacao.Checked ? "F" : "A",
                                                                           DT_Inic.Text,
                                                                           DT_Final.Text,
                                                                           status,
                                                                           cck_Baixa.Checked ? "0" : cck_Normal.Checked ? "1" : cck_Alta.Checked ? "2" : string.Empty,
                                                                           false,
                                                                           string.Empty,
                                                                           string.Empty,
                                                                           string.Empty,
                                                                           false,
                                                                           false,
                                                                           cbExpirada.Checked,
                                                                           cbRetirar.Checked,
                                                                           false,
                                                                           0,
                                                                           string.Empty,
                                                                           string.Empty,
                                                                           null);
            vl_total.Value = (bsOS.List as CamadaDados.Servicos.TList_LanServico).Sum(p => p.Vl_subtotalLiq);
            tot_pecas.Value = (bsOS.List as CamadaDados.Servicos.TList_LanServico).Sum(p => p.Vl_pecas);
            tot_servicos.Value = (bsOS.List as CamadaDados.Servicos.TList_LanServico).Sum(p => p.Vl_servico);
            AtualizarLabel();
            bsOS_PositionChanged(this, new EventArgs());
        }

        private void afterExclui()
        {
            if (bsOS.Current != null)
            {
                if ((bsOS.Current as CamadaDados.Servicos.TRegistro_LanServico).St_os.Trim().ToUpper().Equals("CA"))
                {
                    MessageBox.Show("Ordem de serviço ja se encontra cancelada.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if ((bsOS.Current as CamadaDados.Servicos.TRegistro_LanServico).St_os.Trim().ToUpper().Equals("AB") ||
                    (bsOS.Current as CamadaDados.Servicos.TRegistro_LanServico).St_os.Trim().ToUpper().Equals("FE"))
                {
                    if (MessageBox.Show("Confirma exclusão da OS Nº" + (bsOS.Current as CamadaDados.Servicos.TRegistro_LanServico).Id_osstr + "?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                        == DialogResult.Yes)
                    {
                        try
                        {
                            (bsOS.Current as CamadaDados.Servicos.TRegistro_LanServico).St_os = "CA";
                            CamadaNegocio.Servicos.TCN_LanServico.Gravar((bsOS.Current as CamadaDados.Servicos.TRegistro_LanServico), null);
                            MessageBox.Show("Ordem serviço cancelada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            afterBusca();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                    }
                }
                else
                    MessageBox.Show("Permitido cancelar somente ordem serviço com status <ABERTA> ou <FINALIZADA>.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Obrigatorio informar OS para cancelar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ProcessarOS()
        {
            using (TFLan_Fecha_Ordem_Servico fFechar = new TFLan_Fecha_Ordem_Servico())
            {
                if (bsOS.Current != null &&
                   (bsOS.Current as CamadaDados.Servicos.TRegistro_LanServico).St_os.ToUpper().Equals("FE"))
                {
                    fFechar.pCd_empresa = (bsOS.Current as CamadaDados.Servicos.TRegistro_LanServico).Cd_empresa;
                    fFechar.pTp_ordem = (bsOS.Current as CamadaDados.Servicos.TRegistro_LanServico).Tp_ordemstr;
                    fFechar.pCd_clifor = (bsOS.Current as CamadaDados.Servicos.TRegistro_LanServico).Cd_clifor;
                }
                fFechar.ShowDialog();
                afterBusca();
            }
        }
        
        private void EstornarProcessarOs()
        {
            if (bsOS.Current != null)
            {
                if ((bsOS.Current as CamadaDados.Servicos.TRegistro_LanServico).St_os.Trim().ToUpper() != "PR")
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
                        CamadaNegocio.Servicos.TCN_LanServico.EstornarServico(bsOS.Current as CamadaDados.Servicos.TRegistro_LanServico, null);
                        MessageBox.Show("Estorno realizado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        afterBusca();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.Trim());
                    }
                }
            }
        }

        private void faturarPedido()
        {
            if (BS_Pedido.Current != null)
                if ((BS_Pedido.Current as CamadaDados.Faturamento.Pedido.TRegistro_Pedido).ST_Pedido.Trim().ToUpper().Equals("F"))
                {
                    //Verificar se o pedido tem configuracao fiscal para emitir nota
                    if(new CamadaDados.Faturamento.Cadastros.TCD_CadCFGPedidoFiscal().BuscarEscalar(
                            new Utils.TpBusca[]
                            {
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "a.cfg_pedido",
                                    vOperador = "=",
                                    vVL_Busca = "'" + (BS_Pedido.Current as CamadaDados.Faturamento.Pedido.TRegistro_Pedido).CFG_Pedido.Trim() + "'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "a.tp_fiscal",
                                    vOperador = "=",
                                    vVL_Busca = "'NO'"
                                }
                            }, "1") == null)
                    {
                        MessageBox.Show("Não existe configuração fiscal para o tipo de pedido " + (BS_Pedido.Current as CamadaDados.Faturamento.Pedido.TRegistro_Pedido).CFG_Pedido.Trim() + ".",
                                        "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    try
                    {
                        //Buscar itens pedido
                        CamadaNegocio.Faturamento.Pedido.TCN_Pedido.Busca_Pedido_Itens(BS_Pedido.Current as CamadaDados.Faturamento.Pedido.TRegistro_Pedido, false, null);
                        CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento rFat =
                            Proc_Commoditties.TProcessaPedFaturar.ProcessaPedFaturar(BS_Pedido.Current as CamadaDados.Faturamento.Pedido.TRegistro_Pedido, false, decimal.Zero);
                        CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.GravarFaturamento(rFat, null, null);
                        //Se for nota propria e NF-e
                        if (rFat.Tp_nota.Trim().ToUpper().Equals("P") && rFat.Cd_modelo.Trim().Equals("55"))
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
                                                        vVL_Busca = "'" + rFat.Nr_serie + "'"
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
                                                fGerNfe.rNfe = CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.BuscarNF(rFat.Cd_empresa,
                                                                                                                                rFat.Nr_lanctofiscalstr,
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
                                                CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.BuscarNF(rFat.Cd_empresa,
                                                                                                                 rFat.Nr_lanctofiscalstr,
                                                                                                                 null);
                                            NFES.TGerarRPS.CriarArquivoRPS(rNfs.rCfgNfe, new List<CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento>() { rNfs });
                                            MessageBox.Show("NFS-e enviada com sucesso. Aguarde alguns segundos e consulte o status do lote.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                        catch (Exception ex)
                                        { MessageBox.Show("Erro enviar NFS-e: " + ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                                    }
                            }
                        //Encerrar Pedido
                        (BS_Pedido.Current as CamadaDados.Faturamento.Pedido.TRegistro_Pedido).ST_Pedido = "P";
                        (BS_Pedido.Current as CamadaDados.Faturamento.Pedido.TRegistro_Pedido).St_registro = "P";
                        CamadaNegocio.Faturamento.Pedido.TCN_Pedido.Grava_Pedido(BS_Pedido.Current as CamadaDados.Faturamento.Pedido.TRegistro_Pedido, null);
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
                else
                    MessageBox.Show("É permitido faturar somente pedido FECHADO.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void RetirarOs()
        {
            if (bsOS.Current != null)
            {
                if ((bsOS.Current as CamadaDados.Servicos.TRegistro_LanServico).St_os.Trim().ToUpper().Equals("FE"))
                {
                    if ((bsOS.Current as CamadaDados.Servicos.TRegistro_LanServico).lAcessorios.Count > 0)
                        using (TFListaAcessorios fLista = new TFListaAcessorios())
                        {
                            fLista.lAcessorios = (bsOS.Current as CamadaDados.Servicos.TRegistro_LanServico).lAcessorios;
                            fLista.ShowDialog();
                            (bsOS.Current as CamadaDados.Servicos.TRegistro_LanServico).lAcessorios = fLista.lAcessorios;
                        }
                    try
                    {
                        CamadaNegocio.Servicos.TCN_LanServico.DevolverOS(bsOS.Current as CamadaDados.Servicos.TRegistro_LanServico, null);
                        MessageBox.Show("Ordem serviço Retirada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        afterBusca();
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
                else
                    MessageBox.Show("Permitido retirar somente OS FINALIZADA!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void AtualizarLabel()
        {
            //Buscar Total os retirar
            try
            {
                cbRetirar.Text = "Retirar " + new CamadaDados.Servicos.TCD_LanServico().BuscarEscalar(
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
                                                                  "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))"
                                            },
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = "isnull(a.st_os, 'FE')",
                                                vOperador = "=",
                                                vVL_Busca = "'FE'"
                                            },
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = "DATEADD(day, a.dias_retirar, a.dt_finalizada)",
                                                vOperador = "<",
                                                vVL_Busca = "getdate()"
                                            },
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = "a.dias_retirar",
                                                vOperador = ">",
                                                vVL_Busca = "0"
                                            }
                                        }, "count(*)").ToString();
            }
            catch { }

            //Buscar total os expiradas
            try
            {
                cbExpirada.Text = "Expirada " + new CamadaDados.Servicos.TCD_LanServico().BuscarEscalar(
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
                                                                  "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))"
                                            },
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = "isnull(a.st_os, 'AB')",
                                                vOperador = "=",
                                                vVL_Busca = "'AB'"
                                            },
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = "a.dt_previsao",
                                                vOperador = "<",
                                                vVL_Busca = "getdate()"
                                            }
                                        }, "count(*)").ToString();
            }
            catch { }
        }

        private void TFLanOSServico_Load(object sender, EventArgs e)
        {
            Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            //Restaurar posicao do grid
            Utils.ShapeGrid.RestoreShape(this, gOS);
            Utils.ShapeGrid.RestoreShape(this, gEvolucao);
            Utils.ShapeGrid.RestoreShape(this, gHistorico);
            Utils.ShapeGrid.RestoreShape(this, gPecasServicos);
            Utils.ShapeGrid.RestoreShape(this, g_Consulta_Pedido);

            pFiltro.set_FormatZero();
            AtualizarLabel();
        }

        private void BB_Empresa_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { CD_Empresa }, string.Empty);
        }

        private void CD_Empresa_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + CD_Empresa.Text.Trim() + "'", new Componentes.EditDefault[] { CD_Empresa });
        }

        private void BB_Clifor_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { CD_Clifor }, string.Empty);
        }

        private void CD_Clifor_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + CD_Clifor.Text.Trim() + "'", new Componentes.EditDefault[] { CD_Clifor },
                                                    new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void bb_tecnico_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { id_tecnico }, "isnull(a.st_tecnico, 'N')|=|'S'");
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void id_tecnico_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + id_tecnico.Text.Trim() + "';isnull(a.st_tecnico, 'N')|=|'S'",
                                                    new Componentes.EditDefault[] { id_tecnico },
                                                    new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void bb_etapa_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_etapa|Descrição Etapa|200;" +
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

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            afterBusca();
        }

        private void gOS_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
                if (e.ColumnIndex.Equals(0)) 
                {
                    if (e.Value.ToString().Trim().ToUpper().Equals("FINALIZADA"))
                        gOS.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Teal;
                    else if (e.Value.ToString().Trim().ToUpper().Equals("CANCELADA"))
                        gOS.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
                    else if (e.Value.ToString().Trim().ToUpper().Equals("PROCESSADA"))
                        gOS.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Blue;
                    else if (e.Value.ToString().Trim().ToUpper().Equals("EXPIRADA"))
                        gOS.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
                    else if (e.Value.ToString().Trim().ToUpper().Equals("RETIRAR"))
                        gOS.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.DarkRed;
                    else if (e.Value.ToString().Trim().ToUpper().Equals("RETIRADA"))
                        gOS.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Green;
                    else
                        gOS.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                }
        }

        private void gOS_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gOS.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsOS.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new CamadaDados.Servicos.TRegistro_LanServico());
            CamadaDados.Servicos.TList_LanServico lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gOS.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gOS.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new CamadaDados.Servicos.TList_LanServico(lP.Find(gOS.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gOS.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new CamadaDados.Servicos.TList_LanServico(lP.Find(gOS.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gOS.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsOS.List as CamadaDados.Servicos.TList_LanServico).Sort(lComparer);
            bsOS.ResetBindings(false);
            gOS.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void BB_Novo_Click(object sender, EventArgs e)
        {
            afterNovo();
        }

        private void BB_Alterar_Click(object sender, EventArgs e)
        {
            EvoluirOS();
        }

        private void relatorioPedidosSinteticoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            afterPrint();
        }

        private void BB_Excluir_Click(object sender, EventArgs e)
        {
            afterExclui();
        }

        private void bb_processar_Click(object sender, EventArgs e)
        {
            ProcessarOS();
        }

        private void TFLanOSServico_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F2))
                afterNovo();
            else if (e.KeyCode.Equals(Keys.F3))
                EvoluirOS();
            else if (e.KeyCode.Equals(Keys.F5))
                afterExclui();
            else if (e.KeyCode.Equals(Keys.F7))
                afterBusca();
            else if (e.KeyCode.Equals(Keys.F9))
                ProcessarOS();
            else if (e.KeyCode.Equals(Keys.F10))
                EstornarProcessarOs();
            else if (e.KeyCode.Equals(Keys.F11))
                EnviarEmail();
            else if (e.KeyCode.Equals(Keys.F12))
                RetirarOs();
            else if (e.Control && e.KeyCode.Equals(Keys.P))
            {
                MessageBox.Show("Execute o relatorio que deseja alterar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Altera_Relatorio = true;
            }
        }

        private void bsOS_PositionChanged(object sender, EventArgs e)
        {
            if (bsOS.Current != null)
            {
                //Buscar Pecas
                (bsOS.Current as CamadaDados.Servicos.TRegistro_LanServico).lPecas =
                    CamadaNegocio.Servicos.TCN_LanServicoPecas.Buscar((bsOS.Current as CamadaDados.Servicos.TRegistro_LanServico).Id_osstr,
                                                                      (bsOS.Current as CamadaDados.Servicos.TRegistro_LanServico).Cd_empresa,
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
                //Buscar evolucao
                (bsOS.Current as CamadaDados.Servicos.TRegistro_LanServico).lEvolucao =
                    new CamadaDados.Servicos.TCD_LanServicoEvolucao().Select(
                    new Utils.TpBusca[]
                    {
                        new Utils.TpBusca()
                        {
                            vNM_Campo = "a.id_os",
                            vOperador = "=",
                            vVL_Busca = (bsOS.Current as CamadaDados.Servicos.TRegistro_LanServico).Id_osstr
                        },
                        new Utils.TpBusca()
                        {
                            vNM_Campo = "a.cd_empresa",
                            vOperador = "=",
                            vVL_Busca = "'" + (bsOS.Current as CamadaDados.Servicos.TRegistro_LanServico).Cd_empresa.Trim() + "'"
                        }
                    }, 0, string.Empty, "a.dt_inicio desc");
                //Buscar historico
                (bsOS.Current as CamadaDados.Servicos.TRegistro_LanServico).lHistorico =
                    CamadaNegocio.Servicos.TCN_Historico.Buscar((bsOS.Current as CamadaDados.Servicos.TRegistro_LanServico).Id_osstr,
                                                                (bsOS.Current as CamadaDados.Servicos.TRegistro_LanServico).Cd_empresa,
                                                                string.Empty,
                                                                string.Empty,
                                                                null);
                //Buscar Pedidos
                (bsOS.Current as CamadaDados.Servicos.TRegistro_LanServico).lPedido =
                    new CamadaDados.Faturamento.Pedido.TCD_Pedido().Select(
                    new Utils.TpBusca[]
                    {
                        new Utils.TpBusca()
                        {
                            vNM_Campo = string.Empty,
                            vOperador = "exists",
                            vVL_Busca = "(select 1 from tb_ose_servico_x_pedidoitem x " +
                                        "where x.nr_pedido = a.nr_pedido " +
                                        "and x.cd_empresa = '" + (bsOS.Current as CamadaDados.Servicos.TRegistro_LanServico).Cd_empresa.Trim() + "' " +
                                        "and x.id_os = " + (bsOS.Current as CamadaDados.Servicos.TRegistro_LanServico).Id_osstr + ")"
                        }
                    }, 0, string.Empty);
                bsOS.ResetCurrentItem();
            }
        }

        private void bb_faturarPed_Click(object sender, EventArgs e)
        {
            faturarPedido();
        }

        private void bb_estornarProc_Click(object sender, EventArgs e)
        {
            EstornarProcessarOs();
        }

        private void bb_novoHistorico_Click(object sender, EventArgs e)
        {
            if (bsOS.Current != null)
            {
                if ((bsOS.Current as CamadaDados.Servicos.TRegistro_LanServico).St_os.Trim().ToUpper().Equals("PR"))
                {
                    MessageBox.Show("Não é permitido incluir Historico OS PROCESSADA.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                using (TFHistoricoOS fHist = new TFHistoricoOS())
                {
                    if(fHist.ShowDialog() == DialogResult.OK)
                        if(fHist.rHist != null)
                            try
                            {
                                fHist.rHist.Cd_empresa = (bsOS.Current as CamadaDados.Servicos.TRegistro_LanServico).Cd_empresa;
                                fHist.rHist.Id_os = (bsOS.Current as CamadaDados.Servicos.TRegistro_LanServico).Id_os;
                                fHist.rHist.Login = Utils.Parametros.pubLogin;
                                fHist.rHist.Dt_historico = CamadaDados.UtilData.Data_Servidor();
                                CamadaNegocio.Servicos.TCN_Historico.Gravar(fHist.rHist, null);
                                MessageBox.Show("Historico gravada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LimparFiltros();
                                CD_Empresa.Text = fHist.rHist.Cd_empresa;
                                id_os.Text = fHist.rHist.Id_osstr;
                                afterBusca();
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            }
        }

        private void listagemOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bsOS.Count > 0)
            {
                using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                {
                    FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                    Rel.Altera_Relatorio = Altera_Relatorio;
                    Rel.DTS_Relatorio = bsOS;
                    Rel.Nome_Relatorio = Name;
                    Rel.NM_Classe = Name;
                    Rel.Modulo = Tag.ToString().Substring(0, 3);
                    Rel.Ident = "TFLanOSServico_ListaOS";
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
            {
                MessageBox.Show("Não existe Registros Para Imprimir o Relatório!");
            }
        }

        private void bb_email_Click(object sender, EventArgs e)
        {
            EnviarEmail();
        }

        private void bb_retirar_Click(object sender, EventArgs e)
        {
            RetirarOs();
        }

        private void TFLanOSServico_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Salvar posicao do grid
            Utils.ShapeGrid.SaveShape(this, gOS);
            Utils.ShapeGrid.SaveShape(this, gEvolucao);
            Utils.ShapeGrid.SaveShape(this, gHistorico);
            Utils.ShapeGrid.SaveShape(this, gPecasServicos);
            Utils.ShapeGrid.SaveShape(this, g_Consulta_Pedido);
        }
    }
}
