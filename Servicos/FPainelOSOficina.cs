using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CamadaDados.Servicos;
using CamadaNegocio.Servicos;
using CamadaDados.Servicos.Cadastros;
using Utils;
using CamadaNegocio.Servicos.Cadastros;

namespace Servicos
{
    public partial class TFPainelOSOficina : Form
    {
        private bool Altera_Relatorio = false;

        public TFPainelOSOficina()
        {
            InitializeComponent();
        }

        private void afterNovo()
        {
            using (TFServicoOficina fOs = new TFServicoOficina())
            {
                if (fOs.ShowDialog() == DialogResult.OK)
                    try
                    {
                        //Buscar etapa de abertura da OS
                        TList_EtapaOrdem lEtapa =
                        new TCD_EtapaOrdem().Select(
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
                                                "and x.tp_ordem = " + fOs.rOS.Tp_ordemstr + ")"
                                }
                            }, 1, string.Empty);
                        if (lEtapa.Count > 0)
                        {
                            //Buscar tecnico
                            object obj = new CamadaDados.Financeiro.Cadastros.TCD_CadClifor().BuscarEscalar(
                                            new TpBusca[]
                                            {
                                                new TpBusca()
                                                {
                                                    vNM_Campo = "a.loginvendedor",
                                                    vOperador = "=",
                                                    vVL_Busca = "'" + Utils.Parametros.pubLogin.Trim() + "'"
                                                }
                                            }, "a.cd_clifor");
                            fOs.rOS.lEvolucao.Add(
                                new TRegistro_LanServicoEvolucao()
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
                        TCN_LanServico.Gravar(fOs.rOS, null);
                        MessageBox.Show("Ordem serviço aberta com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        afterPrint(fOs.rOS.Id_osstr, fOs.rOS.Cd_empresa);
                        afterBusca();
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void afterBusca()
        {
            if (cbEtapaOrdem.SelectedItem != null)
            {
                string st = string.Empty;
                string virg = string.Empty;
                if (cbFinalizada.Checked)
                {
                    st = "'FE'";
                    virg = ",";
                }
                if (cbcancelado.Checked)
                {
                    st = "'CA'";
                    virg = ",";
                }
                if (cbProcessada.Checked)
                    st += virg + "'PR'";
                bsOS.DataSource = TCN_LanServico.Buscar(string.Empty,
                                                        string.Empty,
                                                        string.Empty,
                                                        nm_clifor.Text,
                                                        string.Empty,
                                                        string.Empty,
                                                        placa.Text,
                                                        id_os.Text,
                                                        string.Empty,
                                                        string.Empty,
                                                        string.Empty,
                                                        !cbcancelado.Checked ? (cbEtapaOrdem.SelectedItem as TRegistro_EtapaOrdem).Id_etapastr
                                                            : string.Empty,
                                                        string.Empty,
                                                        string.Empty,
                                                        string.Empty,
                                                        string.Empty,
                                                        string.Empty,
                                                        st,
                                                        string.Empty,
                                                        false,
                                                        string.Empty,
                                                        string.Empty,
                                                        string.Empty,
                                                        false,
                                                        false,
                                                        false,
                                                        false,
                                                        true,
                                                        Convert.ToInt32(Top.Value),
                                                        string.Empty,
                                                        "a.dt_abertura desc",
                                                        null);
                bsOS_PositionChanged(this, new EventArgs());
            }
        }

        private void afterExclui()
        {
            if(bsOS.Current != null)
            {
                if ((bsOS.Current as TRegistro_LanServico).St_os.Trim().ToUpper().Equals("CA"))
                {
                    MessageBox.Show("Ordem de serviço ja se encontra cancelada.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if ((bsOS.Current as TRegistro_LanServico).St_os.Trim().ToUpper().Equals("AB") ||
                    (bsOS.Current as TRegistro_LanServico).St_os.Trim().ToUpper().Equals("FE"))
                {
                    if (MessageBox.Show("Confirma exclusão da OS Nº" + (bsOS.Current as TRegistro_LanServico).Id_osstr + "?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                        == DialogResult.Yes)
                    {
                        try
                        {
                            TCN_LanServico.cancelar((bsOS.Current as TRegistro_LanServico), null);
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

        private void afterPrint(string Id_os,
                                string Cd_empresa)
        {
            TRegistro_LanServico rOs = null;
            if (!string.IsNullOrEmpty(Id_os))
                rOs = TCN_LanServico.Buscar(string.Empty,
                                            Cd_empresa,
                                            string.Empty,
                                            string.Empty,
                                            string.Empty,
                                            string.Empty,
                                            string.Empty,
                                            Id_os,
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
                                            false,
                                            string.Empty,
                                            string.Empty,
                                            string.Empty,
                                            false,
                                            false,
                                            false,
                                            false,
                                            true,
                                            1,
                                            string.Empty,
                                            string.Empty,
                                            null)[0];
            else if (bsOS.Current != null)
                rOs = bsOS.Current as TRegistro_LanServico;
            if(rOs != null)
            {
                using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                {
                    FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                    Rel.Altera_Relatorio = Altera_Relatorio;
                    BindingSource bs = new BindingSource();
                    bs.DataSource = new TList_LanServico() { rOs };
                    Rel.DTS_Relatorio = bs;
                    //Endereco Empresa
                    BindingSource bsEmp = new BindingSource();
                    bsEmp.DataSource = CamadaNegocio.Diversos.TCN_CadEmpresa.Busca(rOs.Cd_empresa,
                                                                                   string.Empty,
                                                                                   string.Empty,
                                                                                   null);
                    //Verificar se existe logo configurada para a empresa
                    if (bsEmp.Count > 0)
                        if((bsEmp.List[0] as CamadaDados.Diversos.TRegistro_CadEmpresa).Img != null)
                            Rel.Parametros_Relatorio.Add("IMAGEM_RELATORIO", (bsEmp.List[0] as CamadaDados.Diversos.TRegistro_CadEmpresa).Img);
                    //Verificar tipo de impressão configurado para o terminal
                    object obj = new CamadaDados.Diversos.TCD_CadTerminal().BuscarEscalar(
                                    new TpBusca[]
                                    {
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "a.cd_terminal",
                                            vOperador = "=",
                                            vVL_Busca = "'" + Utils.Parametros.pubTerminal.Trim() + "'"
                                        }
                                    }, "a.tp_impos");
                    Rel.Adiciona_DataSource("DTS_EMP", bsEmp);
                    Rel.Nome_Relatorio = obj == null ? "FRel_OSOficina" : obj.ToString().Trim().ToUpper().Equals("R") ? "FRel_OSOficina_Reduzida" : "FRel_OSOficina";
                    Rel.NM_Classe = "TFLanServicoOficina";
                    Rel.Modulo = string.Empty;
                    Rel.Ident = obj == null ? "FRel_OSOficina" : obj.ToString().Trim().ToUpper().Equals("R") ? "FRel_OSOficina_Reduzida" : "FRel_OSOficina";
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
        }

        private void RelatorioOs()
        {
            if (bsOS.Count > 0)
            {
                using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                {
                    //Buscar pecas das OS
                    for (int i = 0; i < bsOS.Count; i++)
                        if ((bsOS[i] as TRegistro_LanServico).lPecas.Count.Equals(0))
                        {
                            //Buscar Pecas/Servicos
                            (bsOS[i] as TRegistro_LanServico).lPecas =
                                TCN_LanServicoPecas.Buscar((bsOS[i] as TRegistro_LanServico).Id_osstr,
                                                            (bsOS[i] as TRegistro_LanServico).Cd_empresa,
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
                    Rel.DTS_Relatorio = bsOS;
                    Rel.Nome_Relatorio = "FRel_OrdemServico";
                    Rel.NM_Classe = "TFLan_Ordem_Servico";
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

        private void CorrigirOS()
        {
            if (bsOS.Current != null)
            {
                if ((bsOS.Current as TRegistro_LanServico).St_os.Trim().ToUpper().Equals("CA"))
                {
                    MessageBox.Show("Não é permitido evoluir OS CANCELADA.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if ((bsOS.Current as TRegistro_LanServico).St_os.Trim().ToUpper().Equals("PR"))
                {
                    MessageBox.Show("Não é permitido evoluir OS PROCESSADA.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if ((bsOS.Current as TRegistro_LanServico).St_os.Trim().ToUpper().Equals("DV"))
                {
                    MessageBox.Show("Não é permitido evoluir OS DEVOLVIDA.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                using (TFEvoluirOSOficina fEvoluir = new TFEvoluirOSOficina())
                {
                    fEvoluir.rOS = bsOS.Current as TRegistro_LanServico;
                    if(fEvoluir.ShowDialog() == DialogResult.OK)
                        try
                        {
                            TCN_LanServico.Gravar(fEvoluir.rOS, null);
                            MessageBox.Show("OS corrigida com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    afterBusca();
                }
            }
        }

        private void EvoluirOS()
        {
            if(bsOS.Current != null)
            {
                TRegistro_LanServico rOS = bsOS.Current as TRegistro_LanServico;
                if (rOS.St_os.Trim().ToUpper().Equals("CA"))
                {
                    MessageBox.Show("Não é permitido evoluir OS CANCELADA.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (rOS.St_os.Trim().ToUpper().Equals("PR"))
                {
                    MessageBox.Show("Não é permitido evoluir OS PROCESSADA.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (rOS.St_os.Trim().ToUpper().Equals("DV"))
                {
                    MessageBox.Show("Não é permitido evoluir OS DEVOLVIDA.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                TRegistro_LanServicoEvolucao regEvolucao = null;
                if (rOS.lEvolucao.Count > 0)
                    regEvolucao = rOS.lEvolucao.OrderByDescending(p => p.Dt_inicio).Take(1).ToList()[0];
                bool st_loteprocessado = false;
                if (regEvolucao != null)
                    if (regEvolucao.St_envterceiro)
                    {
                        object obj = new TCD_Lote_X_Servicos().BuscarEscalar(
                                        new TpBusca[]
                                        {
                                            new TpBusca()
                                            {
                                                vNM_Campo = "c.id_os",
                                                vOperador = "=",
                                                vVL_Busca = rOS.Id_os.ToString()

                                            }
                                        }, "b.st_registro");
                        if (obj != null)
                        {
                            if (obj.ToString().Trim().ToUpper().Equals("A"))
                            {
                                if (!(MessageBox.Show("Ordem serviço esta amarrada a um lote que ainda não foi enviado.\r\n" +
                                                   "O lançamento de uma nova evolução ira desamarrar a ordem de serviço do lote.\r\r\r\n" +
                                                   "Deseja continuar?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                                    == DialogResult.Yes))
                                    return;
                            }
                            else
                                st_loteprocessado = true;
                        }
                        else
                            if (!(MessageBox.Show("Ordem de serviço não foi enviada para fornecedor.\r\n" +
                                            "Deseja continuar?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                                            == DialogResult.Yes))
                                return;
                        //Verificar se o lote esta processado
                        if (st_loteprocessado)
                        {
                            //Verificar se existe alguma nota de retorno para a os
                            obj = new CamadaDados.Faturamento.NotaFiscal.TCD_LanFaturamento_Item().BuscarEscalar(
                                new TpBusca[]
                                {
                                    new TpBusca()
                                    {
                                        vNM_Campo = string.Empty,
                                        vOperador = "exists",
                                        vVL_Busca = "(select 1 from tb_ose_lote x "+
                                                     "inner join tb_ose_lote_x_servico y "+
                                                     "on x.cd_empresa = y.cd_empresa "+
                                                     "and x.id_lote = y.id_lote "+
                                                     "inner join tb_ose_servico z "+
                                                     "on y.cd_empresa = z.cd_empresa "+
                                                     "and y.id_os = z.id_os "+
                                                     "where x.nr_pedido = a.nr_pedido "+
                                                     "and z.cd_produtoos = a.cd_produto "+
                                                     "and nf.tp_movimento = 'E' "+
                                                     "and isnull(nf.st_registro, 'A') <> 'C')"
                                    }
                                }, "nf.nr_notafiscal");
                            if (obj == null)
                            {
                                if (!(MessageBox.Show("Não existe nota de devolução do produto desta ordem de serviço.\r\n" +
                                                "Deseja alterar etapa evolução mesmo assim?", "Pergunta",
                                                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                                    == DialogResult.Yes))
                                    return;
                            }
                            else
                                MessageBox.Show("Nota Fiscal de retorno Nº " + obj.ToString().Trim() + ".", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                using (TFLan_Evolucao_Ordem_Servico fEvolucao = new TFLan_Evolucao_Ordem_Servico())
                {
                    fEvolucao.TP_Ordem = rOS.Tp_ordemstr;
                    if (regEvolucao != null)
                        fEvolucao.Etapa_atual = regEvolucao.Id_etapastr;
                    if (fEvolucao.ShowDialog() == DialogResult.OK)
                    {
                        TList_EtapaOrdem lEtapa = TCN_EtapaOrdem.Buscar(fEvolucao.rEvolucao.Id_etapa.Value.ToString(),
                                                                        string.Empty,
                                                                        null);
                        if (lEtapa.Count > 0)
                        {
                            fEvolucao.rEvolucao.St_iniciarOS = lEtapa[0].St_iniciarOSbool;
                            fEvolucao.rEvolucao.St_finalizarOS = lEtapa[0].St_finalizarOSbool;
                            fEvolucao.rEvolucao.St_envterceiro = lEtapa[0].St_envterceirobool;
                            if (fEvolucao.rEvolucao.St_finalizarOS)
                            {
                                fEvolucao.rEvolucao.St_evolucao = "E";
                                fEvolucao.rEvolucao.Dt_final = CamadaDados.UtilData.Data_Servidor();
                            }
                        }
                        //Verificar se a etapa que esta sendo inserida nao e de Envio para terceiro
                        if (fEvolucao.rEvolucao.St_envterceiro)
                            if (MessageBox.Show("Evolução exige envio da ordem serviço para fornecedor.\r\n" +
                                               "Deseja amarrar ordem a um lote ja existente?",
                                               "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                                               == DialogResult.Yes)
                            {
                                using (TFLanLoteAberto fLote = new TFLanLoteAberto())
                                {
                                    fLote.Cd_empresa = rOS.Cd_empresa;
                                    if (fLote.ShowDialog() == DialogResult.OK)
                                        if (fLote.rLote != null)
                                            rOS.rLoteServico =
                                                new TRegistro_Lote_X_Servicos()
                                                {
                                                    Cd_empresa = fLote.rLote.Cd_empresa,
                                                    Id_lote = fLote.rLote.Id_lote,
                                                    Id_os = rOS.Id_os
                                                };
                                }
                            }
                        //Verificar se a etapa e de finalizacao
                        if (fEvolucao.rEvolucao.St_finalizarOS)
                            rOS.St_os = "FE";
                        //Inserir novo registro
                        rOS.lEvolucao.Add(
                            fEvolucao.rEvolucao);
                        try
                        {
                            TCN_LanServico.Gravar(rOS, null);
                            if (rOS.St_os.Trim().ToUpper().Equals("FE"))
                                if (MessageBox.Show("Ordem serviço FINALIZADA com sucesso.\r\n" +
                                                   "Deseja PROCESSAR a mesma?", "Mensagem", MessageBoxButtons.YesNo,
                                                   MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                                {
                                    object obj = new TCD_TpOrdem().BuscarEscalar(
                                                    new TpBusca[]
                                                    {
                                                        new TpBusca()
                                                        {
                                                            vNM_Campo = "a.tp_ordem",
                                                            vOperador = "=",
                                                            vVL_Busca = rOS.Tp_ordemstr

                                                        }
                                                    }, "isnull(a.tp_faturamento, 'P')");
                                    if (obj.ToString().Trim().ToUpper().Equals("D"))//Duplicata
                                    {
                                        if (string.IsNullOrEmpty(rOS.Cd_clifor))
                                        {
                                            MessageBox.Show("Não é permitido PROCESSAR OS sem cliente.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            return;
                                        }
                                        //Buscar CFG TP.Ordem
                                        TList_OSE_ParamOS lParam =
                                            TCN_OSE_ParamOS.Buscar(rOS.Tp_ordemstr,
                                                                    string.Empty,
                                                                    string.Empty,
                                                                    string.Empty,
                                                                    string.Empty,
                                                                    string.Empty,
                                                                    string.Empty,
                                                                    string.Empty,
                                                                    string.Empty,
                                                                    1,
                                                                    string.Empty,
                                                                    null);
                                        if (lParam.Count.Equals(decimal.Zero))
                                        {
                                            MessageBox.Show("Não existe configuração para o tipo de ordem " + rOS.Tp_ordemstr,
                                                "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            return;
                                        }
                                        using (Financeiro.TFLanDuplicata fDuplicata = new Financeiro.TFLanDuplicata())
                                        {
                                            fDuplicata.vCd_empresa = (bsOS.Current as TRegistro_LanServico).Cd_empresa;
                                            fDuplicata.vNm_empresa = (bsOS.Current as TRegistro_LanServico).Nm_empresa;
                                            fDuplicata.vCd_clifor = (bsOS.Current as TRegistro_LanServico).Cd_clifor;
                                            fDuplicata.vNm_clifor = (bsOS.Current as TRegistro_LanServico).Nm_clifor;
                                            fDuplicata.vCd_endereco = (bsOS.Current as TRegistro_LanServico).Cd_endereco;
                                            fDuplicata.vDs_endereco = (bsOS.Current as TRegistro_LanServico).Ds_endereco;
                                            fDuplicata.vSt_ecf = true;
                                            if (lParam.Count > 0)
                                            {
                                                fDuplicata.vTp_docto = lParam[0].Tp_doctostr;
                                                fDuplicata.vDs_tpdocto = lParam[0].Ds_tpdocto;
                                                fDuplicata.vTp_duplicata = lParam[0].Tp_duplicata;
                                                fDuplicata.vDs_tpduplicata = lParam[0].Ds_tpduplicata;
                                                fDuplicata.vTp_mov = "R";
                                                fDuplicata.vCd_historico = lParam[0].Cd_historico;
                                                fDuplicata.vDs_historico = lParam[0].Ds_historico;
                                                fDuplicata.vCd_moeda = lParam[0].Cd_moeda;
                                                fDuplicata.vDs_moeda = lParam[0].Ds_moeda;
                                                fDuplicata.vVl_documento = (bsOS.Current as TRegistro_LanServico).Vl_subtotalLiq -
                                                                            (bsOS.Current as TRegistro_LanServico).Vl_garantia;
                                                fDuplicata.vDt_emissao = CamadaDados.UtilData.Data_Servidor().ToString("dd/MM/yyyy");
                                                fDuplicata.vNr_docto = "OS" + (bsOS.Current as TRegistro_LanServico).Id_osstr;
                                            }
                                            if (fDuplicata.ShowDialog() == DialogResult.OK)
                                            {
                                                try
                                                {
                                                    (bsOS.Current as TRegistro_LanServico).lDup.Add(
                                                                            fDuplicata.dsDuplicata.Current as CamadaDados.Financeiro.Duplicata.TRegistro_LanDuplicata);
                                                    TCN_LanServico.ProcessarOSOficina(bsOS.Current as TRegistro_LanServico, null);
                                                    MessageBox.Show("Ordem serviço processada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                    //Imprimir Boleto
                                                    CamadaDados.Financeiro.Bloqueto.blListaTitulo lBloqueto =
                                                        new CamadaDados.Financeiro.Bloqueto.TCD_Titulo().Select(
                                                        new TpBusca[]
                                                {
                                                    new TpBusca()
                                                    {
                                                        vNM_Campo = string.Empty,
                                                        vOperador = "exists",
                                                        vVL_Busca = "(select 1 from TB_OSE_Duplicata x " +
                                                                    "where x.cd_empresa = a.cd_empresa " +
                                                                    "and x.nr_lancto = a.nr_lancto " +
                                                                    "and x.cd_empresa = '" + (bsOS.Current as TRegistro_LanServico).Cd_empresa.Trim() + "' " +
                                                                    "and x.id_os = " + (bsOS.Current as TRegistro_LanServico).Id_osstr + ")"
                                                    }
                                                }, 0, string.Empty);
                                                    if (lBloqueto.Count > 0)
                                                        //Chamar tela de impressao para o bloqueto
                                                        using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                                                        {
                                                            fImp.St_enabled_enviaremail = true;
                                                            fImp.pCd_clifor = lBloqueto[0].Cd_sacado;
                                                            fImp.pMensagem = "BOLETO(S) ORDEM SERVIÇO Nº" + (bsOS.Current as TRegistro_LanServico).Id_osstr;
                                                            if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                                                                FormRelPadrao.TCN_LayoutBloqueto.Imprime_Bloqueto(false,
                                                                                                                  lBloqueto,
                                                                                                                  fImp.pSt_imprimir,
                                                                                                                  fImp.pSt_visualizar,
                                                                                                                  fImp.pSt_enviaremail,
                                                                                                                  fImp.pSt_exportPdf,
                                                                                                                  fImp.Path_exportPdf,
                                                                                                                  fImp.pDestinatarios,
                                                                                                                  "BOLETO(S) VENDA RAPIDA Nº " + (bsOS.Current as TRegistro_LanServico).Id_osstr,
                                                                                                                  fImp.pDs_mensagem,
                                                                                                                  false);
                                                        }
                                                    else
                                                    {
                                                        CamadaDados.Financeiro.Duplicata.TList_RegLanParcela lParcelas =
                                                                new CamadaDados.Financeiro.Duplicata.TCD_LanParcela().Select(
                                                                new TpBusca[]
                                                        {
                                                            new TpBusca()
                                                            {
                                                                vNM_Campo = string.Empty,
                                                                vOperador = "exists",
                                                                vVL_Busca = "(select 1 from TB_OSE_Duplicata x " +
                                                                            "where x.cd_empresa = a.cd_empresa " +
                                                                            "and x.nr_lancto = a.nr_lancto " +
                                                                            "and x.cd_empresa = '" + (bsOS.Current as TRegistro_LanServico).Cd_empresa.Trim() + "' " +
                                                                            "and x.id_os = " + (bsOS.Current as TRegistro_LanServico).Id_osstr + ")"
                                                            }
                                                        }, 0, string.Empty, string.Empty, string.Empty);
                                                        if (lParcelas.Count > 0)
                                                            using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                                                            {

                                                                fImp.St_enabled_enviaremail = true;
                                                                fImp.pCd_clifor = lParcelas[0].Cd_clifor;
                                                                fImp.pMensagem = "DUPLICATAS DO DOCUMENTO Nº" + lParcelas[0].Nr_docto;
                                                                if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                                                                    FormRelPadrao.TCN_LayoutDuplicata.Imprime_Duplicata(false,
                                                                                                                        lParcelas,
                                                                                                                        null,
                                                                                                                        null,
                                                                                                                        fImp.pSt_imprimir,
                                                                                                                        fImp.pSt_visualizar,
                                                                                                                        fImp.pSt_exportPdf,
                                                                                                                        fImp.Path_exportPdf,
                                                                                                                        fImp.pSt_enviaremail,
                                                                                                                        fImp.pDestinatarios,
                                                                                                                        "DUPLICATAS(S) DO DOCUMENTO Nº " + lParcelas[0].Nr_docto,
                                                                                                                        fImp.pDs_mensagem);
                                                            }
                                                    }
                                                }
                                                catch (Exception ex)
                                                {
                                                    MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                }
                                            }
                                            else
                                            {
                                                MessageBox.Show("Obrigatorio informar Financeiro para Gerar Duplicata!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                return;
                                            }
                                        }
                                    }
                                    else if (obj.ToString().Trim().ToUpper().Equals("V"))
                                    {
                                        CamadaDados.Faturamento.PDV.TRegistro_PreVenda rPreVenda = null;
                                        try
                                        {
                                            rPreVenda = Proc_Commoditties.TProcessarOS.ProcessarOSServico(bsOS.Current as TRegistro_LanServico);
                                            TCN_LanServico.ProcessarOSPreVenda(bsOS.Current as TRegistro_LanServico, rPreVenda, null, null);
                                            //Buscar dados PDV
                                            CamadaDados.Faturamento.Cadastros.TList_PontoVenda lPdv =
                                                CamadaNegocio.Faturamento.Cadastros.TCN_PontoVenda.Buscar(string.Empty,
                                                                                                          string.Empty,
                                                                                                          Utils.Parametros.pubTerminal,
                                                                                                          string.Empty,
                                                                                                          null);
                                            if (lPdv.Count.Equals(0))
                                            {
                                                MessageBox.Show("Não existe PDV cadastrado para o terminal " + Utils.Parametros.pubTerminal,
                                                                "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                return;
                                            }
                                            //Verificar se existe caixa aberto para realizar venda
                                            CamadaDados.Faturamento.PDV.TList_CaixaPDV lCaixa =
                                                new CamadaDados.Faturamento.PDV.TCD_CaixaPDV().Select(
                                                        new TpBusca[]
                                                {
                                                    new TpBusca()
                                                    {
                                                        vNM_Campo = "a.login",
                                                        vOperador = "=",
                                                        vVL_Busca = "'" + Utils.Parametros.pubLogin + "'"
                                                    },
                                                    new TpBusca()
                                                    {
                                                        vNM_Campo = "isnull(a.st_registro, 'A')",
                                                        vOperador = "=",
                                                        vVL_Busca = "'A'"
                                                    }
                                                }, 1, string.Empty);
                                            if (lCaixa.Count > 0)
                                            {
                                                CamadaDados.Faturamento.Cadastros.TList_CFGCupomFiscal lCfg =
                                                    CamadaNegocio.Faturamento.Cadastros.TCN_CFGCupomFiscal.Buscar(rPreVenda.Cd_empresa, null);
                                                if (lCfg.Count.Equals(0))
                                                    throw new Exception("Não existe configuração para realizar venda na empresa + " + rPreVenda.Cd_empresa.Trim() + ".");
                                                CamadaDados.Faturamento.PDV.TRegistro_VendaRapida rCupom = new CamadaDados.Faturamento.PDV.TRegistro_VendaRapida();
                                                rCupom.Cd_tabelapreco = rPreVenda.Cd_tabelaPreco;
                                                rCupom.Cd_vend = rPreVenda.Cd_vendedor;
                                                rCupom.Cd_empresa = rPreVenda.Cd_empresa;
                                                rCupom.Cd_clifor = rPreVenda.Cd_clifor;
                                                rCupom.Nm_clifor = rPreVenda.Nm_clifor;
                                                rCupom.Id_pessoa = rPreVenda.Id_pessoa;
                                                rCupom.Cd_cliforInd = rPreVenda.Cd_cliforInd;
                                                rCupom.Cd_endereco = rPreVenda.Cd_endereco;
                                                rCupom.Ds_observacao = rPreVenda.Ds_observacao;
                                                rCupom.Id_pdv = lPdv[0].Id_pdv;
                                                object obj_sessao = new CamadaDados.Faturamento.PDV.TCD_Sessao().BuscarEscalar(
                                                                        new TpBusca[]
                                                                {
                                                                    new TpBusca()
                                                                    {
                                                                        vNM_Campo = "a.id_pdv",
                                                                        vOperador = "=",
                                                                        vVL_Busca = rCupom.Id_pdvstr
                                                                    },
                                                                    new TpBusca()
                                                                    {
                                                                        vNM_Campo = "a.login",
                                                                        vOperador = "=",
                                                                        vVL_Busca = "'" + Utils.Parametros.pubLogin.Trim() + "'"
                                                                    },
                                                                    new TpBusca()
                                                                    {
                                                                        vNM_Campo = "isnull(a.st_registro, 'A')",
                                                                        vOperador = "=",
                                                                        vVL_Busca = "'A'"
                                                                    }
                                                                }, "a.id_sessao");
                                                if (obj_sessao != null)
                                                    rCupom.Id_sessaostr = obj_sessao.ToString();
                                                else
                                                    rCupom.Id_sessaostr = CamadaNegocio.Faturamento.PDV.TCN_Sessao.AbrirSessao(new CamadaDados.Faturamento.PDV.TRegistro_Sessao()
                                                    {
                                                        Dt_abertura = DateTime.Now,
                                                        Id_pdv = lPdv[0].Id_pdv,
                                                        Login = Utils.Parametros.pubLogin,
                                                    }, null);
                                                //Buscar Itens PreVenda
                                                rPreVenda.lItens = CamadaNegocio.Faturamento.PDV.TCN_ItensPreVenda.Buscar(rPreVenda.Cd_empresa,
                                                                                                                          rPreVenda.Id_prevendastr,
                                                                                                                          string.Empty,
                                                                                                                          string.Empty,
                                                                                                                          true,
                                                                                                                          null);
                                                rPreVenda.lItens.ForEach(p =>
                                                {
                                                    rCupom.lItem.Add(
                                                            new CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item()
                                                            {
                                                                Cd_produto = p.Cd_produto,
                                                                Ds_produto = p.Ds_produto,
                                                                Sigla_unidade = p.Sigla_unidade,
                                                                Cd_local = lCfg[0].Cd_local,
                                                                Ds_local = lCfg[0].Ds_local,
                                                                Cd_grupo = p.Cd_grupo,
                                                                Cd_tabelapreco = p.Cd_tabelaPreco,
                                                                Cd_vendedor = rPreVenda.Cd_vendedor,
                                                                Quantidade = p.Quantidade,
                                                                Vl_unitario = p.Vl_unitario,
                                                                Vl_subtotal = p.Quantidade * p.Vl_unitario,
                                                                Vl_desconto = p.Vl_desconto,
                                                                Vl_acrescimo = p.Vl_acrescimo,
                                                                Vl_juro_fin = p.Vl_juro_fin,
                                                                Vl_frete = p.Vl_frete,
                                                                rItemPreVenda = p
                                                            });
                                                    rCupom.Vl_cupom += (p.Quantidade * p.Vl_unitario) + p.Vl_acrescimo + p.Vl_juro_fin + p.Vl_frete - p.Vl_desconto;
                                                });
                                                using (PDV.TFFecharCupom fFechar = new PDV.TFFecharCupom())
                                                {
                                                    fFechar.rCupom = rCupom;
                                                    fFechar.pCd_empresa = rCupom.Cd_empresa;
                                                    fFechar.pCd_clifor = rCupom.Cd_clifor;
                                                    fFechar.pNm_clifor = rCupom.Nm_clifor;
                                                    fFechar.rCfg = lCfg[0];
                                                    fFechar.pVl_receber = rCupom.Vl_cupom;
                                                    fFechar.lPdv = lPdv;
                                                    fFechar.LoginPDV = Utils.Parametros.pubLogin;
                                                    if (fFechar.ShowDialog() == DialogResult.OK)
                                                        if (fFechar.lPortador != null)
                                                            rCupom.lPortador = fFechar.lPortador;
                                                        else
                                                            throw new Exception("Obrigatório informar portador para finalizar venda.");
                                                    else
                                                        throw new Exception("Obrigatório informar portador para finalizar venda.");
                                                }
                                                ThreadEspera tEsperaDev = new ThreadEspera("Inicio processo gravar venda rapida...");
                                                try
                                                {
                                                    CamadaNegocio.Faturamento.PDV.TCN_VendaRapida.GravarVendaRapida(rCupom,
                                                                                                                    null,
                                                                                                                    null,
                                                                                                                    null);
                                                    MessageBox.Show("OS Processada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                    if (rCupom.lPortador.Exists(p => p.Tp_portadorpdv.Trim().ToUpper().Equals("P")))
                                                    {
                                                        //Se gerou boleto imprimir boletos
                                                        CamadaDados.Financeiro.Bloqueto.blListaTitulo lBloqueto =
                                                            new CamadaDados.Financeiro.Bloqueto.TCD_Titulo().Select(
                                                                new TpBusca[]
                                                        {
                                                            new TpBusca()
                                                            {
                                                                vNM_Campo = string.Empty,
                                                                vOperador = "exists",
                                                                vVL_Busca = "(select 1 from TB_PDV_CupomFiscal_X_Duplicata x " +
                                                                            "where x.cd_empresa = a.cd_empresa " +
                                                                            "and x.Nr_Lancto = a.Nr_Lancto " +
                                                                            "and x.cd_empresa = '" + rCupom.Cd_empresa.Trim() + "' " +
                                                                            "and x.id_cupom = " + rCupom.Id_vendarapidastr + ")"
                                                            }
                                                        }, 0, string.Empty);
                                                        if (lBloqueto.Count > 0)
                                                            //Chamar tela de impressao para o bloqueto
                                                            using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                                                            {
                                                                fImp.St_enabled_enviaremail = true;
                                                                fImp.pCd_clifor = rCupom.Cd_clifor;
                                                                fImp.pMensagem = "BOLETOS OS Nº" + rOS.Id_osstr;
                                                                if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                                                                    FormRelPadrao.TCN_LayoutBloqueto.Imprime_Bloqueto(false,
                                                                                                                      lBloqueto,
                                                                                                                      fImp.pSt_imprimir,
                                                                                                                      fImp.pSt_visualizar,
                                                                                                                      fImp.pSt_enviaremail,
                                                                                                                      fImp.pSt_exportPdf,
                                                                                                                      fImp.Path_exportPdf,
                                                                                                                      fImp.pDestinatarios,
                                                                                                                      "BOLETOS OS Nº" + rOS.Id_osstr,
                                                                                                                      fImp.pDs_mensagem,
                                                                                                                      false);
                                                            }
                                                        else
                                                        {
                                                            //Se gerou duplicata imprimir confissão divida
                                                            CamadaDados.Financeiro.Duplicata.TList_RegLanParcela lParc =
                                                                new CamadaDados.Financeiro.Duplicata.TCD_LanParcela().Select(
                                                                new TpBusca[]
                                                        {
                                                            new TpBusca()
                                                            {
                                                                vNM_Campo = string.Empty,
                                                                vOperador = "exists",
                                                                vVL_Busca = "(select 1 from TB_PDV_CupomFiscal_X_Duplicata x " +
                                                                            "where x.cd_empresa = a.cd_empresa " +
                                                                            "and x.Nr_Lancto = a.Nr_Lancto " +
                                                                            "and x.cd_empresa = '" + rCupom.Cd_empresa.Trim() + "' " +
                                                                            "and x.id_cupom = " + rCupom.Id_vendarapidastr + ")"
                                                            }
                                                        }, 1, string.Empty, "a.dt_vencto", string.Empty);
                                                            if (lParc.Count > 0)
                                                            {
                                                                FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                                                                BindingSource bs = new BindingSource();
                                                                bs.DataSource = new TList_LanServico() { rOS };
                                                                Rel.DTS_Relatorio = bs;
                                                                //DTS Cupom
                                                                BindingSource dts = new BindingSource();
                                                                dts.DataSource = CamadaNegocio.Faturamento.PDV.TCN_VendaRapida_Item.Buscar(rCupom.Id_vendarapidastr,
                                                                                                                                           rCupom.Cd_empresa,
                                                                                                                                           false,
                                                                                                                                           string.Empty,
                                                                                                                                           null);
                                                                Rel.Adiciona_DataSource("DTS_ITENS", dts);
                                                                //Buscar Empresa
                                                                BindingSource bsEmpresa = new BindingSource();
                                                                bsEmpresa.DataSource = CamadaNegocio.Diversos.TCN_CadEmpresa.Busca(rCupom.Cd_empresa,
                                                                                                                                   string.Empty,
                                                                                                                                   string.Empty,
                                                                                                                                   null);
                                                                Rel.Adiciona_DataSource("DTS_EMP", bsEmpresa);
                                                                //Buscar Cliente Cupom 
                                                                if (string.IsNullOrEmpty(rCupom.Cd_clifor))
                                                                {
                                                                    CamadaDados.Financeiro.Cadastros.TRegistro_CadClifor rClifor =
                                                                        CamadaNegocio.Financeiro.Cadastros.TCN_CadClifor.Busca_Clifor_Codigo(rCupom.Cd_clifor, null);
                                                                    Rel.Parametros_Relatorio.Add("NM_CLIENTE", rClifor.Nm_clifor);
                                                                    Rel.Parametros_Relatorio.Add("CPF_CLIENTE", rClifor.Tp_pessoa.Trim().ToUpper().Equals("F") ? rClifor.Nr_cpf : rClifor.Nr_cgc);
                                                                }
                                                                else
                                                                {
                                                                    Rel.Parametros_Relatorio.Add("NM_CLIENTE", rCupom.Nm_clifor);
                                                                    Rel.Parametros_Relatorio.Add("CPF_CLIENTE", rCupom.Nr_cgccpf);
                                                                }
                                                                if (string.IsNullOrEmpty(rCupom.Ds_endereco))
                                                                {
                                                                    CamadaDados.Financeiro.Cadastros.TList_CadEndereco lEnd =
                                                                    CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Buscar(rCupom.Cd_clifor,
                                                                                                                              rCupom.Cd_endereco,
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
                                                                    Rel.Parametros_Relatorio.Add("ENDERECO", lEnd[0].Ds_endereco.Trim() + ", " + lEnd[0].Numero.Trim() + ", " + lEnd[0].Bairro.Trim() + ", " + lEnd[0].DS_Cidade.Trim() + ", " + lEnd[0].UF.Trim());
                                                                }
                                                                else Rel.Parametros_Relatorio.Add("ENDERECO", rCupom.Ds_endereco.Trim());
                                                                //Buscar Valor Pago
                                                                decimal vl_pago = decimal.Zero;
                                                                List<CamadaDados.Faturamento.PDV.TRegistro_MovCaixa> lPag = new CamadaDados.Faturamento.PDV.TCD_CaixaPDV().SelectMovCaixa(
                                                                                                                                new TpBusca[]
                                                                                                                        {
                                                                                                                            new TpBusca()
                                                                                                                            {
                                                                                                                                vNM_Campo = "a.cd_empresa",
                                                                                                                                vOperador = "=",
                                                                                                                                vVL_Busca = "'" + rCupom.Cd_empresa.Trim() + "'"
                                                                                                                            },
                                                                                                                            new TpBusca()
                                                                                                                            {
                                                                                                                                vNM_Campo = "a.id_cupom",
                                                                                                                                vOperador = "=",
                                                                                                                                vVL_Busca = rCupom.Id_vendarapidastr
                                                                                                                            }
                                                                                                                        }, string.Empty);
                                                                if (lPag.Count > 0)
                                                                    vl_pago = lPag.Sum(p => p.Vl_recebidoliq);
                                                                vl_pago += lParc.Sum(p => p.Vl_liquidado);
                                                                Rel.Parametros_Relatorio.Add("VL_PAGO", vl_pago);
                                                                Rel.Parametros_Relatorio.Add("VL_PAGAR", lParc.Sum(p => p.Vl_atual));
                                                                BindingSource bsParc = new BindingSource();
                                                                bsParc.DataSource = lParc;
                                                                Rel.Adiciona_DataSource("PARC", bsParc);
                                                                Rel.Nome_Relatorio = "CONFISSAO_DIVIDA_OS";
                                                                Rel.NM_Classe = "TFPainelOSOficina";
                                                                Rel.Modulo = "OSE";
                                                                Rel.Ident = "CONFISSAO_DIVIDA_OS";
                                                                //Verificar se existe Impressora padrão para o PDV
                                                                obj = new CamadaDados.Faturamento.Cadastros.TCD_PontoVenda().BuscarEscalar(
                                                                        new TpBusca[]
                                                                {
                                                                    new TpBusca()
                                                                    {
                                                                        vNM_Campo = "a.cd_terminal",
                                                                        vOperador = "=",
                                                                        vVL_Busca = "'" + Utils.Parametros.pubTerminal.Trim() + "'"
                                                                    }
                                                                }, "a.impressorapadrao");
                                                                string print = obj == null ? string.Empty : obj.ToString();
                                                                if (string.IsNullOrEmpty(print))
                                                                    using (Parametros.Diversos.TFListaImpressoras fLista = new Parametros.Diversos.TFListaImpressoras())
                                                                    {
                                                                        if (fLista.ShowDialog() == DialogResult.OK)
                                                                            if (!string.IsNullOrEmpty(fLista.Impressora))
                                                                                print = fLista.Impressora;

                                                                    }
                                                                //Imprimir
                                                                Rel.ImprimiGraficoReduzida(print, !string.IsNullOrEmpty(print), string.IsNullOrEmpty(print), null, string.Empty, string.Empty, 1);
                                                            }
                                                        }
                                                    }
                                                }
                                                catch (Exception ex)
                                                { throw new Exception(ex.Message.Trim()); }
                                                finally
                                                {
                                                    tEsperaDev.Fechar();
                                                    tEsperaDev = null;
                                                }
                                            }
                                            else
                                                throw new Exception("Não existe caixa aberto para faturar venda.");
                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            TCN_LanServico.EstornarProcessarOSOficina(rOS, null);
                                        }
                                    }
                                    else
                                    {
                                        CamadaDados.Faturamento.Pedido.TRegistro_Pedido rPedGarantia = null;
                                        CamadaDados.Faturamento.PDV.TRegistro_PreVenda rPreVenda =
                                            Proc_Commoditties.TProcessarOS.ProcessarOSPeca(rOS, ref rPedGarantia);
                                        TCN_LanServico.ProcessarOSPreVenda(rOS, rPreVenda, rPedGarantia, null);
                                        MessageBox.Show("Ordem serviço processada com sucesso.", "Pergunta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        if (rPedGarantia != null)
                                        {
                                            //Buscar pedido
                                            rPedGarantia = CamadaNegocio.Faturamento.Pedido.TCN_Pedido.Busca_Registro_Pedido(rPedGarantia.Nr_pedido.ToString(), null);
                                            //Buscar itens pedido
                                            CamadaNegocio.Faturamento.Pedido.TCN_Pedido.Busca_Pedido_Itens(rPedGarantia, false, null);
                                            //Gerar Nota Fiscal
                                            CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento rFat =
                                                Proc_Commoditties.TProcessaPedFaturar.ProcessaPedFaturar(rPedGarantia, false, decimal.Zero);
                                            //Gravar Nota Fiscal
                                            CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.GravarFaturamento(rFat, null, null);
                                            if (rFat.Cd_modelo.Trim().Equals("55"))
                                            {
                                                if (MessageBox.Show("Deseja enviar NF-e para a receita agora?", "Pergunta", MessageBoxButtons.YesNo,
                                                     MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
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
                                            }
                                        }
                                    }
                                }
                            afterBusca();
                            //Imprimir OS
                            afterPrint(rOS.Id_osstr, rOS.Cd_empresa);
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    }
                }
            }
        }

        private void ProcessarOs()
        {
            if(bsOS.Current != null)
            {
                if ((bsOS.Current as TRegistro_LanServico).St_os.Trim().ToUpper().Equals("FE"))
                {
                    if (MessageBox.Show("Confirma processamento OS Nº" + (bsOS.Current as TRegistro_LanServico).Id_osstr + "?",
                        "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                        == DialogResult.Yes)
                        try
                        {
                            object obj = new TCD_TpOrdem().BuscarEscalar(
                                            new TpBusca[]
                                            {
                                                new TpBusca()
                                                {
                                                    vNM_Campo = "a.tp_ordem",
                                                    vOperador = "=",
                                                    vVL_Busca = (bsOS.Current as TRegistro_LanServico).Tp_ordemstr

                                                }
                                            }, "isnull(a.tp_faturamento, 'P')");
                            if (obj.ToString().Trim().ToUpper().Equals("D"))//Duplicata
                            {
                                if (string.IsNullOrEmpty((bsOS.Current as TRegistro_LanServico).Cd_clifor))
                                {
                                    MessageBox.Show("Não é permitido PROCESSAR OS sem cliente.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                                //Buscar CFG TP.Ordem
                                TList_OSE_ParamOS lParam =
                                    TCN_OSE_ParamOS.Buscar((bsOS.Current as TRegistro_LanServico).Tp_ordemstr,
                                                            string.Empty,
                                                            string.Empty,
                                                            string.Empty,
                                                            string.Empty,
                                                            string.Empty,
                                                            string.Empty,
                                                            string.Empty,
                                                            string.Empty,
                                                            1,
                                                            string.Empty,
                                                            null);
                                if (lParam.Count.Equals(decimal.Zero))
                                {
                                    MessageBox.Show("Não existe configuração para o tipo de ordem " + (bsOS.Current as TRegistro_LanServico).Tp_ordemstr,
                                        "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                                using (Financeiro.TFLanDuplicata fDuplicata = new Financeiro.TFLanDuplicata())
                                {
                                    fDuplicata.vCd_empresa = (bsOS.Current as TRegistro_LanServico).Cd_empresa;
                                    fDuplicata.vNm_empresa = (bsOS.Current as TRegistro_LanServico).Nm_empresa;
                                    fDuplicata.vCd_clifor = (bsOS.Current as TRegistro_LanServico).Cd_clifor;
                                    fDuplicata.vNm_clifor = (bsOS.Current as TRegistro_LanServico).Nm_clifor;
                                    fDuplicata.vCd_endereco = (bsOS.Current as TRegistro_LanServico).Cd_endereco;
                                    fDuplicata.vDs_endereco = (bsOS.Current as TRegistro_LanServico).Ds_endereco;
                                    fDuplicata.vSt_ecf = true;
                                    if (lParam.Count > 0)
                                    {
                                        fDuplicata.vTp_docto = lParam[0].Tp_doctostr;
                                        fDuplicata.vDs_tpdocto = lParam[0].Ds_tpdocto;
                                        fDuplicata.vTp_duplicata = lParam[0].Tp_duplicata;
                                        fDuplicata.vDs_tpduplicata = lParam[0].Ds_tpduplicata;
                                        fDuplicata.vTp_mov = "R";
                                        fDuplicata.vCd_historico = lParam[0].Cd_historico;
                                        fDuplicata.vDs_historico = lParam[0].Ds_historico;
                                        fDuplicata.vCd_moeda = lParam[0].Cd_moeda;
                                        fDuplicata.vDs_moeda = lParam[0].Ds_moeda;
                                        fDuplicata.vVl_documento = (bsOS.Current as TRegistro_LanServico).Vl_subtotalLiq -
                                                                    (bsOS.Current as TRegistro_LanServico).Vl_garantia;
                                        fDuplicata.vDt_emissao = CamadaDados.UtilData.Data_Servidor().ToString("dd/MM/yyyy");
                                        fDuplicata.vNr_docto = "OS" + (bsOS.Current as TRegistro_LanServico).Id_osstr;
                                    }
                                    if (fDuplicata.ShowDialog() == DialogResult.OK)
                                    {
                                        try
                                        {
                                            (bsOS.Current as TRegistro_LanServico).lDup.Add(
                                                                    fDuplicata.dsDuplicata.Current as CamadaDados.Financeiro.Duplicata.TRegistro_LanDuplicata);
                                            TCN_LanServico.ProcessarOSOficina(bsOS.Current as TRegistro_LanServico, null);
                                            MessageBox.Show("Ordem serviço processada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            //Imprimir Boleto
                                            CamadaDados.Financeiro.Bloqueto.blListaTitulo lBloqueto =
                                                new CamadaDados.Financeiro.Bloqueto.TCD_Titulo().Select(
                                                new TpBusca[]
                                                {
                                                    new TpBusca()
                                                    {
                                                        vNM_Campo = string.Empty,
                                                        vOperador = "exists",
                                                        vVL_Busca = "(select 1 from TB_OSE_Duplicata x " +
                                                                    "where x.cd_empresa = a.cd_empresa " +
                                                                    "and x.nr_lancto = a.nr_lancto " +
                                                                    "and x.cd_empresa = '" + (bsOS.Current as TRegistro_LanServico).Cd_empresa.Trim() + "' " +
                                                                    "and x.id_os = " + (bsOS.Current as TRegistro_LanServico).Id_osstr + ")"
                                                    }
                                                }, 0, string.Empty);
                                            if (lBloqueto.Count > 0)
                                                //Chamar tela de impressao para o bloqueto
                                                using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                                                {
                                                    fImp.St_enabled_enviaremail = true;
                                                    fImp.pCd_clifor = lBloqueto[0].Cd_sacado;
                                                    fImp.pMensagem = "BOLETO(S) ORDEM SERVIÇO Nº" + (bsOS.Current as TRegistro_LanServico).Id_osstr;
                                                    if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                                                        FormRelPadrao.TCN_LayoutBloqueto.Imprime_Bloqueto(false,
                                                                                                          lBloqueto,
                                                                                                          fImp.pSt_imprimir,
                                                                                                          fImp.pSt_visualizar,
                                                                                                          fImp.pSt_enviaremail,
                                                                                                          fImp.pSt_exportPdf,
                                                                                                          fImp.Path_exportPdf,
                                                                                                          fImp.pDestinatarios,
                                                                                                          "BOLETO(S) VENDA RAPIDA Nº " + (bsOS.Current as TRegistro_LanServico).Id_osstr,
                                                                                                          fImp.pDs_mensagem,
                                                                                                          false);
                                                }
                                            else
                                            {
                                                CamadaDados.Financeiro.Duplicata.TList_RegLanParcela lParcelas =
                                                        new CamadaDados.Financeiro.Duplicata.TCD_LanParcela().Select(
                                                        new TpBusca[]
                                                        {
                                                            new TpBusca()
                                                            {
                                                                vNM_Campo = string.Empty,
                                                                vOperador = "exists",
                                                                vVL_Busca = "(select 1 from TB_OSE_Duplicata x " +
                                                                            "where x.cd_empresa = a.cd_empresa " +
                                                                            "and x.nr_lancto = a.nr_lancto " +
                                                                            "and x.cd_empresa = '" + (bsOS.Current as TRegistro_LanServico).Cd_empresa.Trim() + "' " +
                                                                            "and x.id_os = " + (bsOS.Current as TRegistro_LanServico).Id_osstr + ")"
                                                            }
                                                        }, 0, string.Empty, string.Empty, string.Empty);
                                                if (lParcelas.Count > 0)
                                                    using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                                                    {

                                                        fImp.St_enabled_enviaremail = true;
                                                        fImp.pCd_clifor = lParcelas[0].Cd_clifor;
                                                        fImp.pMensagem = "DUPLICATAS DO DOCUMENTO Nº" + lParcelas[0].Nr_docto;
                                                        if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                                                            FormRelPadrao.TCN_LayoutDuplicata.Imprime_Duplicata(false,
                                                                                                                lParcelas,
                                                                                                                null,
                                                                                                                null,
                                                                                                                fImp.pSt_imprimir,
                                                                                                                fImp.pSt_visualizar,
                                                                                                                fImp.pSt_exportPdf,
                                                                                                                fImp.Path_exportPdf,
                                                                                                                fImp.pSt_enviaremail,
                                                                                                                fImp.pDestinatarios,
                                                                                                                "DUPLICATAS(S) DO DOCUMENTO Nº " + lParcelas[0].Nr_docto,
                                                                                                                fImp.pDs_mensagem);
                                                    }
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Obrigatorio informar Financeiro para Gerar Duplicata!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        return;
                                    }
                                }
                            }
                            else if (obj.ToString().Trim().ToUpper().Equals("V"))
                            {
                                CamadaDados.Faturamento.PDV.TRegistro_PreVenda rPreVenda = null;
                                try
                                {
                                    rPreVenda = Proc_Commoditties.TProcessarOS.ProcessarOSServico(bsOS.Current as TRegistro_LanServico);
                                    TCN_LanServico.ProcessarOSPreVenda(bsOS.Current as TRegistro_LanServico, rPreVenda, null, null);
                                    //Buscar dados PDV
                                    CamadaDados.Faturamento.Cadastros.TList_PontoVenda lPdv =
                                        CamadaNegocio.Faturamento.Cadastros.TCN_PontoVenda.Buscar(string.Empty,
                                                                                                  string.Empty,
                                                                                                  Utils.Parametros.pubTerminal,
                                                                                                  string.Empty,
                                                                                                  null);
                                    if (lPdv.Count.Equals(0))
                                    {
                                        MessageBox.Show("Não existe PDV cadastrado para o terminal " + Utils.Parametros.pubTerminal,
                                                        "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        return;
                                    }
                                    //Verificar se existe caixa aberto para realizar venda
                                    CamadaDados.Faturamento.PDV.TList_CaixaPDV lCaixa =
                                        new CamadaDados.Faturamento.PDV.TCD_CaixaPDV().Select(
                                                new TpBusca[]
                                                {
                                                    new TpBusca()
                                                    {
                                                        vNM_Campo = "a.login",
                                                        vOperador = "=",
                                                        vVL_Busca = "'" + Utils.Parametros.pubLogin + "'"
                                                    },
                                                    new TpBusca()
                                                    {
                                                        vNM_Campo = "isnull(a.st_registro, 'A')",
                                                        vOperador = "=",
                                                        vVL_Busca = "'A'"
                                                    }
                                                }, 1, string.Empty);
                                    if (lCaixa.Count > 0)
                                    {
                                        CamadaDados.Faturamento.Cadastros.TList_CFGCupomFiscal lCfg =
                                            CamadaNegocio.Faturamento.Cadastros.TCN_CFGCupomFiscal.Buscar(rPreVenda.Cd_empresa, null);
                                        if (lCfg.Count.Equals(0))
                                            throw new Exception("Não existe configuração para realizar venda na empresa + " + rPreVenda.Cd_empresa.Trim() + ".");
                                        CamadaDados.Faturamento.PDV.TRegistro_VendaRapida rCupom = new CamadaDados.Faturamento.PDV.TRegistro_VendaRapida();
                                        rCupom.Cd_tabelapreco = rPreVenda.Cd_tabelaPreco;
                                        rCupom.Cd_vend = rPreVenda.Cd_vendedor;
                                        rCupom.Cd_empresa = rPreVenda.Cd_empresa;
                                        rCupom.Cd_clifor = rPreVenda.Cd_clifor;
                                        rCupom.Nm_clifor = rPreVenda.Nm_clifor;
                                        rCupom.Id_pessoa = rPreVenda.Id_pessoa;
                                        rCupom.Cd_cliforInd = rPreVenda.Cd_cliforInd;
                                        rCupom.Cd_endereco = rPreVenda.Cd_endereco;
                                        rCupom.Ds_observacao = rPreVenda.Ds_observacao;
                                        rCupom.Id_pdv = lPdv[0].Id_pdv;
                                        object obj_sessao = new CamadaDados.Faturamento.PDV.TCD_Sessao().BuscarEscalar(
                                                                new TpBusca[]
                                                                {
                                                                    new TpBusca()
                                                                    {
                                                                        vNM_Campo = "a.id_pdv",
                                                                        vOperador = "=",
                                                                        vVL_Busca = rCupom.Id_pdvstr
                                                                    },
                                                                    new TpBusca()
                                                                    {
                                                                        vNM_Campo = "a.login",
                                                                        vOperador = "=",
                                                                        vVL_Busca = "'" + Utils.Parametros.pubLogin.Trim() + "'"
                                                                    },
                                                                    new TpBusca()
                                                                    {
                                                                        vNM_Campo = "isnull(a.st_registro, 'A')",
                                                                        vOperador = "=",
                                                                        vVL_Busca = "'A'"
                                                                    }
                                                                }, "a.id_sessao");
                                        if (obj_sessao != null)
                                            rCupom.Id_sessaostr = obj_sessao.ToString();
                                        else
                                            rCupom.Id_sessaostr = CamadaNegocio.Faturamento.PDV.TCN_Sessao.AbrirSessao(new CamadaDados.Faturamento.PDV.TRegistro_Sessao()
                                            {
                                                Dt_abertura = DateTime.Now,
                                                Id_pdv = lPdv[0].Id_pdv,
                                                Login = Utils.Parametros.pubLogin,
                                            }, null);
                                        //Buscar Itens PreVenda
                                        rPreVenda.lItens = CamadaNegocio.Faturamento.PDV.TCN_ItensPreVenda.Buscar(rPreVenda.Cd_empresa,
                                                                                                                  rPreVenda.Id_prevendastr,
                                                                                                                  string.Empty,
                                                                                                                  string.Empty,
                                                                                                                  true,
                                                                                                                  null);
                                        rPreVenda.lItens.ForEach(p =>
                                        {
                                            rCupom.lItem.Add(
                                                    new CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item()
                                                    {
                                                        Cd_produto = p.Cd_produto,
                                                        Ds_produto = p.Ds_produto,
                                                        Sigla_unidade = p.Sigla_unidade,
                                                        Cd_local = lCfg[0].Cd_local,
                                                        Ds_local = lCfg[0].Ds_local,
                                                        Cd_grupo = p.Cd_grupo,
                                                        Cd_tabelapreco = p.Cd_tabelaPreco,
                                                        Cd_vendedor = rPreVenda.Cd_vendedor,
                                                        Quantidade = p.Quantidade,
                                                        Vl_unitario = p.Vl_unitario,
                                                        Vl_subtotal = p.Quantidade * p.Vl_unitario,
                                                        Vl_desconto = p.Vl_desconto,
                                                        Vl_acrescimo = p.Vl_acrescimo,
                                                        Vl_juro_fin = p.Vl_juro_fin,
                                                        Vl_frete = p.Vl_frete,
                                                        rItemPreVenda = p
                                                    });
                                            rCupom.Vl_cupom += (p.Quantidade * p.Vl_unitario) + p.Vl_acrescimo + p.Vl_juro_fin + p.Vl_frete - p.Vl_desconto;
                                        });
                                        using (PDV.TFFecharCupom fFechar = new PDV.TFFecharCupom())
                                        {
                                            fFechar.rCupom = rCupom;
                                            fFechar.pCd_empresa = rCupom.Cd_empresa;
                                            fFechar.pCd_clifor = rCupom.Cd_clifor;
                                            fFechar.pNm_clifor = rCupom.Nm_clifor;
                                            fFechar.rCfg = lCfg[0];
                                            fFechar.pVl_receber = rCupom.Vl_cupom;
                                            fFechar.lPdv = lPdv;
                                            fFechar.LoginPDV = Utils.Parametros.pubLogin;
                                            if (fFechar.ShowDialog() == DialogResult.OK)
                                                if (fFechar.lPortador != null)
                                                    rCupom.lPortador = fFechar.lPortador;
                                                else
                                                    throw new Exception("Obrigatório informar portador para finalizar venda.");
                                            else
                                                throw new Exception("Obrigatório informar portador para finalizar venda.");
                                        }
                                        ThreadEspera tEsperaDev = new ThreadEspera("Inicio processo gravar venda rapida...");
                                        try
                                        {
                                            CamadaNegocio.Faturamento.PDV.TCN_VendaRapida.GravarVendaRapida(rCupom,
                                                                                                            null,
                                                                                                            null,
                                                                                                            null);
                                            MessageBox.Show("OS Processada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            if (rCupom.lPortador.Exists(p => p.Tp_portadorpdv.Trim().ToUpper().Equals("P")))
                                            {
                                                //Se gerou boleto imprimir boletos
                                                CamadaDados.Financeiro.Bloqueto.blListaTitulo lBloqueto =
                                                    new CamadaDados.Financeiro.Bloqueto.TCD_Titulo().Select(
                                                        new TpBusca[]
                                                        {
                                                            new TpBusca()
                                                            {
                                                                vNM_Campo = string.Empty,
                                                                vOperador = "exists",
                                                                vVL_Busca = "(select 1 from TB_PDV_CupomFiscal_X_Duplicata x " +
                                                                            "where x.cd_empresa = a.cd_empresa " +
                                                                            "and x.Nr_Lancto = a.Nr_Lancto " +
                                                                            "and x.cd_empresa = '" + rCupom.Cd_empresa.Trim() + "' " +
                                                                            "and x.id_cupom = " + rCupom.Id_vendarapidastr + ")"
                                                            }
                                                        }, 0, string.Empty);
                                                if (lBloqueto.Count > 0)
                                                    //Chamar tela de impressao para o bloqueto
                                                    using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                                                    {
                                                        fImp.St_enabled_enviaremail = true;
                                                        fImp.pCd_clifor = rCupom.Cd_clifor;
                                                        fImp.pMensagem = "BOLETOS OS Nº" + (bsOS.Current as TRegistro_LanServico).Id_osstr;
                                                        if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                                                            FormRelPadrao.TCN_LayoutBloqueto.Imprime_Bloqueto(false,
                                                                                                              lBloqueto,
                                                                                                              fImp.pSt_imprimir,
                                                                                                              fImp.pSt_visualizar,
                                                                                                              fImp.pSt_enviaremail,
                                                                                                              fImp.pSt_exportPdf,
                                                                                                              fImp.Path_exportPdf,
                                                                                                              fImp.pDestinatarios,
                                                                                                              "BOLETOS OS Nº" + (bsOS.Current as TRegistro_LanServico).Id_osstr,
                                                                                                              fImp.pDs_mensagem,
                                                                                                              false);
                                                    }
                                                else
                                                {
                                                    //Se gerou duplicata imprimir confissão divida
                                                    CamadaDados.Financeiro.Duplicata.TList_RegLanParcela lParc =
                                                        new CamadaDados.Financeiro.Duplicata.TCD_LanParcela().Select(
                                                        new TpBusca[]
                                                        {
                                                            new TpBusca()
                                                            {
                                                                vNM_Campo = string.Empty,
                                                                vOperador = "exists",
                                                                vVL_Busca = "(select 1 from TB_PDV_CupomFiscal_X_Duplicata x " +
                                                                            "where x.cd_empresa = a.cd_empresa " +
                                                                            "and x.Nr_Lancto = a.Nr_Lancto " +
                                                                            "and x.cd_empresa = '" + rCupom.Cd_empresa.Trim() + "' " +
                                                                            "and x.id_cupom = " + rCupom.Id_vendarapidastr + ")"
                                                            }
                                                        }, 1, string.Empty, "a.dt_vencto", string.Empty);
                                                    if (lParc.Count > 0)
                                                    {
                                                        FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                                                        BindingSource bs = new BindingSource();
                                                        bs.DataSource = new TList_LanServico() { bsOS.Current as TRegistro_LanServico };
                                                        Rel.DTS_Relatorio = bs;
                                                        //DTS Cupom
                                                        BindingSource dts = new BindingSource();
                                                        dts.DataSource = CamadaNegocio.Faturamento.PDV.TCN_VendaRapida_Item.Buscar(rCupom.Id_vendarapidastr,
                                                                                                                                   rCupom.Cd_empresa,
                                                                                                                                   false,
                                                                                                                                   string.Empty,
                                                                                                                                   null);
                                                        Rel.Adiciona_DataSource("DTS_ITENS", dts);
                                                        //Buscar Empresa
                                                        BindingSource bsEmpresa = new BindingSource();
                                                        bsEmpresa.DataSource = CamadaNegocio.Diversos.TCN_CadEmpresa.Busca(rCupom.Cd_empresa,
                                                                                                                           string.Empty,
                                                                                                                           string.Empty,
                                                                                                                           null);
                                                        Rel.Adiciona_DataSource("DTS_EMP", bsEmpresa);
                                                        //Buscar Cliente Cupom 
                                                        if (string.IsNullOrEmpty(rCupom.Cd_clifor))
                                                        {
                                                            CamadaDados.Financeiro.Cadastros.TRegistro_CadClifor rClifor =
                                                                CamadaNegocio.Financeiro.Cadastros.TCN_CadClifor.Busca_Clifor_Codigo(rCupom.Cd_clifor, null);
                                                            Rel.Parametros_Relatorio.Add("NM_CLIENTE", rClifor.Nm_clifor);
                                                            Rel.Parametros_Relatorio.Add("CPF_CLIENTE", rClifor.Tp_pessoa.Trim().ToUpper().Equals("F") ? rClifor.Nr_cpf : rClifor.Nr_cgc);
                                                        }
                                                        else
                                                        {
                                                            Rel.Parametros_Relatorio.Add("NM_CLIENTE", rCupom.Nm_clifor);
                                                            Rel.Parametros_Relatorio.Add("CPF_CLIENTE", rCupom.Nr_cgccpf);
                                                        }
                                                        if (string.IsNullOrEmpty(rCupom.Ds_endereco))
                                                        {
                                                            CamadaDados.Financeiro.Cadastros.TList_CadEndereco lEnd =
                                                            CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Buscar(rCupom.Cd_clifor,
                                                                                                                      rCupom.Cd_endereco,
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
                                                            Rel.Parametros_Relatorio.Add("ENDERECO", lEnd[0].Ds_endereco.Trim() + ", " + lEnd[0].Numero.Trim() + ", " + lEnd[0].Bairro.Trim() + ", " + lEnd[0].DS_Cidade.Trim() + ", " + lEnd[0].UF.Trim());
                                                        }
                                                        else Rel.Parametros_Relatorio.Add("ENDERECO", rCupom.Ds_endereco.Trim());
                                                        //Buscar Valor Pago
                                                        decimal vl_pago = decimal.Zero;
                                                        List<CamadaDados.Faturamento.PDV.TRegistro_MovCaixa> lPag = new CamadaDados.Faturamento.PDV.TCD_CaixaPDV().SelectMovCaixa(
                                                                                                                        new TpBusca[]
                                                                                                                        {
                                                                                                                            new TpBusca()
                                                                                                                            {
                                                                                                                                vNM_Campo = "a.cd_empresa",
                                                                                                                                vOperador = "=",
                                                                                                                                vVL_Busca = "'" + rCupom.Cd_empresa.Trim() + "'"
                                                                                                                            },
                                                                                                                            new TpBusca()
                                                                                                                            {
                                                                                                                                vNM_Campo = "a.id_cupom",
                                                                                                                                vOperador = "=",
                                                                                                                                vVL_Busca = rCupom.Id_vendarapidastr
                                                                                                                            }
                                                                                                                        }, string.Empty);
                                                        if (lPag.Count > 0)
                                                            vl_pago = lPag.Sum(p => p.Vl_recebidoliq);
                                                        vl_pago += lParc.Sum(p => p.Vl_liquidado);
                                                        Rel.Parametros_Relatorio.Add("VL_PAGO", vl_pago);
                                                        Rel.Parametros_Relatorio.Add("VL_PAGAR", lParc.Sum(p => p.Vl_atual));
                                                        BindingSource bsParc = new BindingSource();
                                                        bsParc.DataSource = lParc;
                                                        Rel.Adiciona_DataSource("PARC", bsParc);
                                                        Rel.Nome_Relatorio = "CONFISSAO_DIVIDA_OS";
                                                        Rel.NM_Classe = "TFPainelOSOficina";
                                                        Rel.Modulo = "OSE";
                                                        Rel.Ident = "CONFISSAO_DIVIDA_OS";
                                                        //Verificar se existe Impressora padrão para o PDV
                                                        obj = new CamadaDados.Faturamento.Cadastros.TCD_PontoVenda().BuscarEscalar(
                                                                new TpBusca[]
                                                                {
                                                                    new TpBusca()
                                                                    {
                                                                        vNM_Campo = "a.cd_terminal",
                                                                        vOperador = "=",
                                                                        vVL_Busca = "'" + Utils.Parametros.pubTerminal.Trim() + "'"
                                                                    }
                                                                }, "a.impressorapadrao");
                                                        string print = obj == null ? string.Empty : obj.ToString();
                                                        if (string.IsNullOrEmpty(print))
                                                            using (Parametros.Diversos.TFListaImpressoras fLista = new Parametros.Diversos.TFListaImpressoras())
                                                            {
                                                                if (fLista.ShowDialog() == DialogResult.OK)
                                                                    if (!string.IsNullOrEmpty(fLista.Impressora))
                                                                        print = fLista.Impressora;

                                                            }
                                                        //Imprimir
                                                        Rel.ImprimiGraficoReduzida(print, !string.IsNullOrEmpty(print), string.IsNullOrEmpty(print), null, string.Empty, string.Empty, 1);
                                                    }
                                                }
                                            }
                                            afterBusca();
                                        }
                                        catch (Exception ex)
                                        { throw new Exception(ex.Message.Trim()); }
                                        finally
                                        {
                                            tEsperaDev.Fechar();
                                            tEsperaDev = null;
                                        }
                                    }
                                    else
                                        throw new Exception("Não existe caixa aberto para faturar venda.");
                                }
                                catch (Exception ex)
                                { 
                                    MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    TCN_LanServico.EstornarProcessarOSOficina(bsOS.Current as TRegistro_LanServico, null);
                                    afterBusca();
                                }
                            }
                            else
                            {
                                CamadaDados.Faturamento.Pedido.TRegistro_Pedido rPedGarantia = null;
                                CamadaDados.Faturamento.PDV.TRegistro_PreVenda rPreVenda =
                                    Proc_Commoditties.TProcessarOS.ProcessarOSPeca(bsOS.Current as TRegistro_LanServico, ref rPedGarantia);
                                TCN_LanServico.ProcessarOSPreVenda(bsOS.Current as TRegistro_LanServico, rPreVenda, rPedGarantia, null);
                                MessageBox.Show("Ordem serviço processada com sucesso.", "Pergunta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                if (rPedGarantia != null)
                                {
                                    //Buscar pedido
                                    rPedGarantia = CamadaNegocio.Faturamento.Pedido.TCN_Pedido.Busca_Registro_Pedido(rPedGarantia.Nr_pedido.ToString(), null);
                                    //Buscar itens pedido
                                    CamadaNegocio.Faturamento.Pedido.TCN_Pedido.Busca_Pedido_Itens(rPedGarantia, false, null);
                                    //Gerar Nota Fiscal
                                    CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento rFat =
                                        Proc_Commoditties.TProcessaPedFaturar.ProcessaPedFaturar(rPedGarantia, false, decimal.Zero);
                                    //Gravar Nota Fiscal
                                    CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.GravarFaturamento(rFat, null, null);
                                    if (rFat.Cd_modelo.Trim().Equals("55"))
                                    {
                                        if (MessageBox.Show("Deseja enviar NF-e para a receita agora?", "Pergunta", MessageBoxButtons.YesNo,
                                             MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
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
                                    }
                                }
                            }
                            afterBusca();                                        
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
                else
                    MessageBox.Show("Permitido processar somente OS FINALIZADA.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void FecharVenda(CamadaDados.Faturamento.PDV.TRegistro_VendaRapida rVenda,
                                 CamadaDados.Faturamento.Cadastros.TRegistro_CFGCupomFiscal rCfg,
                                 ThreadEspera tEspera)
        {
            
            //Busca cupom gravado
            CamadaDados.Faturamento.PDV.TList_VendaRapida lCupom =
                        CamadaNegocio.Faturamento.PDV.TCN_VendaRapida.Buscar(rVenda.Id_vendarapidastr,
                                                                             rVenda.Cd_empresa,
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
                                                                             string.Empty,
                                                                             1,
                                                                             null);
            lCupom.ForEach(p => p.lItem = CamadaNegocio.Faturamento.PDV.TCN_VendaRapida_Item.Buscar(p.Id_vendarapidastr,
                                                                                                    p.Cd_empresa,
                                                                                                    false,
                                                                                                    string.Empty,
                                                                                                    null));
            lCupom[0].lPortador = rVenda.lPortador;
            CamadaDados.Diversos.TList_CadTerminal lTerminal =
             new CamadaDados.Diversos.TCD_CadTerminal().Select(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.cd_terminal",
                                            vOperador = "=",
                                            vVL_Busca = "'" + Utils.Parametros.pubTerminal.Trim() + "'"
                                        }
                                    }, 1, string.Empty);
            
            
            if (lCupom[0].lPortador.Exists(p => p.lDup.Count > 0))
            {
                //Imprimir Boleto
                CamadaDados.Financeiro.Bloqueto.blListaTitulo lBloqueto =
                    new CamadaDados.Financeiro.Bloqueto.TCD_Titulo().Select(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = string.Empty,
                            vOperador = "exists",
                            vVL_Busca = "(select 1 from tb_pdv_cupomfiscal_x_duplicata x " +
                                        "where x.cd_empresa = a.cd_empresa " +
                                        "and x.nr_lancto = a.nr_lancto " +
                                        "and x.cd_empresa = '" + lCupom[0].Cd_empresa.Trim() + "' " +
                                        "and x.id_cupom = " + lCupom[0].Id_vendarapidastr + ")"
                        }
                    }, 0, string.Empty);
                if (lBloqueto.Count > 0)
                    //Chamar tela de impressao para o bloqueto
                    using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                    {
                        fImp.St_enabled_enviaremail = true;
                        fImp.pCd_clifor = lBloqueto[0].Cd_sacado;
                        fImp.pMensagem = "BOLETO(S) VENDA RAPIDA Nº" + lCupom[0].Id_vendarapidastr;
                        if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                            FormRelPadrao.TCN_LayoutBloqueto.Imprime_Bloqueto(false,
                                                                              lBloqueto,
                                                                              fImp.pSt_imprimir,
                                                                              fImp.pSt_visualizar,
                                                                              fImp.pSt_enviaremail,
                                                                              fImp.pSt_exportPdf,
                                                                              fImp.Path_exportPdf,
                                                                              fImp.pDestinatarios,
                                                                              "BOLETO(S) VENDA RAPIDA Nº " + lCupom[0].Id_vendarapidastr,
                                                                              fImp.pDs_mensagem,
                                                                              false);
                    }
                else
                {
                    CamadaDados.Financeiro.Duplicata.TList_RegLanParcela lParcelas =
                            new CamadaDados.Financeiro.Duplicata.TCD_LanParcela().Select(
                            new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = string.Empty,
                                    vOperador = "exists",
                                    vVL_Busca = "(select 1 from tb_pdv_cupomfiscal_x_duplicata x " +
                                                "where x.cd_empresa = a.cd_empresa " +
                                                "and x.nr_lancto = a.nr_lancto " +
                                                "and x.cd_empresa = '" + lCupom[0].Cd_empresa.Trim() + "' " +
                                                "and x.id_cupom = " + lCupom[0].Id_vendarapidastr + ")"
                                }
                            }, 0, string.Empty, string.Empty, string.Empty);
                    if (lParcelas.Count > 0)
                        using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                        {

                            fImp.St_enabled_enviaremail = true;
                            fImp.pCd_clifor = lParcelas[0].Cd_clifor;
                            if (CamadaNegocio.ConfigGer.TCN_CadParamGer.BuscaVL_Bool("ST_CARNE",
                                                                         lParcelas[0].Cd_empresa,
                                                                         null).Trim().ToUpper().Equals("S"))
                            {
                                //Verificar se tipo de documento gera Duplicata

                                //Buscar dados Empresa
                                CamadaDados.Diversos.TList_CadEmpresa lEmpresa =
                                    CamadaNegocio.Diversos.TCN_CadEmpresa.Busca(lParcelas[0].Cd_empresa,
                                                                                string.Empty,
                                                                                string.Empty,
                                                                                null);
                                //Buscar dados do sacado
                                CamadaDados.Financeiro.Cadastros.TList_CadClifor lSacado =
                                    CamadaNegocio.Financeiro.Cadastros.TCN_CadClifor.Busca_Clifor(lParcelas[0].Cd_clifor,
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
                                                                                                  0,
                                                                                                  null);
                                //Buscar endereco sacado
                                if (lSacado.Count > 0)
                                    lSacado[0].lEndereco =
                                        CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Buscar(lParcelas[0].Cd_clifor,
                                                                                                  lParcelas[0].Cd_endereco,
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
                                                                                                  0,
                                                                                                  null);

                                FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();

                                //Buscar Duplicata
                                CamadaDados.Financeiro.Duplicata.TList_RegLanDuplicata lDup =
                                    new CamadaDados.Financeiro.Duplicata.TCD_LanDuplicata().Select(
                                        new TpBusca[]
                                        {
                                            new TpBusca()
                                            {
                                                vNM_Campo = "a.cd_empresa",
                                                vOperador = "=",
                                                vVL_Busca = "'" + lParcelas[0].Cd_empresa.Trim() + "'"
                                            },
                                            new TpBusca()
                                            {
                                                vNM_Campo = "a.nr_lancto",
                                                vOperador = "=",
                                                vVL_Busca = lParcelas[0].Nr_lanctostr
                                            }
                                        }, 0, string.Empty);
                                //Duplicata
                                BindingSource bs = new BindingSource();
                                bs.DataSource = lDup;
                                Rel.DTS_Relatorio = bs;
                                //Verificar se existe logo configurada para a empresa
                                if (lEmpresa.Count > 0)
                                    if (lEmpresa[0].Img != null)
                                        Rel.Parametros_Relatorio.Add("IMAGEM_RELATORIO", lEmpresa[0].Img);
                                //Empresa
                                BindingSource bs_emp = new BindingSource();
                                bs_emp.DataSource = lEmpresa;
                                Rel.Adiciona_DataSource("DTS_EMP", bs_emp);
                                //Parcelas
                                BindingSource bs_parc = new BindingSource();
                                bs_parc.DataSource = lParcelas;
                                Rel.Adiciona_DataSource("DTS_PARC", bs_parc);
                                //Sacado
                                BindingSource bs_sacado = new BindingSource();
                                bs_sacado.DataSource = lSacado;
                                Rel.Adiciona_DataSource("DTS_SACADO", bs_sacado);

                                Rel.Nome_Relatorio = "FRel_CarneDup";
                                Rel.NM_Classe = "TFDuplicata";
                                Rel.Modulo = "FIN";
                                Rel.Ident = "FRel_CarneDup";
                                fImp.St_enabled_enviaremail = true;
                                fImp.pMensagem = "CARNÊ DUPLICATAS(S) DO DOCUMENTO Nº " + lParcelas[0].Nr_docto;

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
                                                       "CARNÊ DUPLICATAS(S) DO DOCUMENTO Nº " + lParcelas[0].Nr_docto,
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
                                                           "CARNÊ DUPLICATAS(S) DO DOCUMENTO Nº " + lParcelas[0].Nr_docto,
                                                           fImp.pDs_mensagem);
                            }
                            else
                            {
                                fImp.pMensagem = "DUPLICATAS DO DOCUMENTO Nº" + lParcelas[0].Nr_docto;
                                if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                                    FormRelPadrao.TCN_LayoutDuplicata.Imprime_Duplicata(false,
                                                                                        lParcelas,
                                                                                        null,
                                                                                        null,
                                                                                        fImp.pSt_imprimir,
                                                                                        fImp.pSt_visualizar,
                                                                                        fImp.pSt_exportPdf,
                                                                                        fImp.Path_exportPdf,
                                                                                        fImp.pSt_enviaremail,
                                                                                        fImp.pDestinatarios,
                                                                                        "DUPLICATAS(S) DO DOCUMENTO Nº " + lParcelas[0].Nr_docto,
                                                                                        fImp.pDs_mensagem);
                            }
                        }
                }
            }
        }

        private void EstornarProcessarOs()
        {
            if(bsOS.Current != null)
            {
                if ((bsOS.Current as TRegistro_LanServico).St_os.Trim().ToUpper() != "PR")
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
                        TCN_LanServico.EstornarProcessarOSOficina(bsOS.Current as TRegistro_LanServico, null);
                        MessageBox.Show("Estorno realizado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        afterBusca();
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim()); }
                }
            }
        }

        private void DevolverOs()
        {
            if(bsOS.Current != null)
            {
                if ((bsOS.Current as TRegistro_LanServico).St_os.Trim().ToUpper().Equals("PR"))
                {
                    using (Parametros.Diversos.TFRegraUsuario fUser = new Parametros.Diversos.TFRegraUsuario())
                    {
                        fUser.Ds_regraespecial = "PERMITIR DEVOLUCAO ORDEM SERVICO";
                        if (fUser.ShowDialog() == DialogResult.OK)
                        {
                            (bsOS.Current as TRegistro_LanServico).Logindevolucao = fUser.Login;
                            if ((bsOS.Current as TRegistro_LanServico).lAcessorios.Count > 0)
                                using (TFListaAcessorios fLista = new TFListaAcessorios())
                                {
                                    fLista.lAcessorios = (bsOS.Current as TRegistro_LanServico).lAcessorios;
                                    fLista.ShowDialog();
                                    (bsOS.Current as TRegistro_LanServico).lAcessorios = fLista.lAcessorios;
                                }
                            try
                            {
                                TCN_LanServico.DevolverOS(bsOS.Current as TRegistro_LanServico, null);
                                MessageBox.Show("Ordem serviço devolvida com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                        }
                    }
                }
                else
                    MessageBox.Show("Permitido devolver somente OS PROCESSADA.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void TotPecasServicos()
        {
            tot_pecas.Value = (bsOS.Current as TRegistro_LanServico).lPecas.FindAll(p => p.St_servicobool == false).Sum(p => p.Vl_SubTotalLiq);
            tot_servico.Value = (bsOS.Current as TRegistro_LanServico).lPecas.FindAll(p => p.St_servicobool).Sum(p => p.Vl_SubTotalLiq);
            tot_os.Value = (bsOS.Current as TRegistro_LanServico).lPecas.Sum(p => p.Vl_SubTotalLiq);
        }

        private void AgruparOSNF(bool st_servico)
        {
            using (TFItensFaturar fFaturar = new TFItensFaturar())
            {
                fFaturar.St_servico = st_servico;
                if (fFaturar.ShowDialog() == DialogResult.OK)
                    if (fFaturar.lItemOS.Count > 0)
                    {
                        TList_OSE_ParamOS lParam =
                        TCN_OSE_ParamOS.Buscar((bsOS.Current as TRegistro_LanServico).Tp_ordemstr,
                                                string.Empty,
                                                string.Empty,
                                                string.Empty,
                                                string.Empty,
                                                string.Empty,
                                                string.Empty,
                                                string.Empty,
                                                string.Empty,
                                                0,
                                                string.Empty,
                                                null);
                        if (lParam.Count.Equals(0))
                        {
                            MessageBox.Show("Não existe parametro para o tipo de OS.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        if (string.IsNullOrEmpty(lParam[0].Cfg_pedido_servico))
                        {
                            MessageBox.Show("Não existe tipo pedido serviço configurado para o tipo de OS.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        CamadaDados.Faturamento.Pedido.TRegistro_Pedido rPed = null;
                        try
                        {
                            if (!st_servico)
                            {
                                Proc_Commoditties.TProcessaPedidoOS.GerarPedidoPecas(ref rPed,
                                                                                         null,
                                                                                         fFaturar.lItemOS,
                                                                                         lParam[0]);
                            }
                            else
                            {
                                Proc_Commoditties.TProcessaPedidoOS.GerarPedidoServico(ref rPed,
                                                                                      null,
                                                                                      fFaturar.lItemOS,
                                                                                      lParam[0]);
                            }
                            //Buscar Endereco clifor
                            object obj_end = new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco().BuscarEscalar(
                                                new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.cd_clifor",
                                            vOperador = "=",
                                            vVL_Busca = "'" + fFaturar.pCd_clifor.Trim() + "'"
                                        }
                                    }, "a.cd_endereco");
                            if (obj_end == null)
                                throw new Exception("Cliente " + fFaturar.pCd_clifor.Trim() + " não possui endereço cadastrado.");
                            //Finalizar Geração Pedido
                            rPed.CD_Empresa = fFaturar.lItemOS[0].Cd_empresa;
                            rPed.CD_Clifor = fFaturar.pCd_clifor;
                            rPed.CD_Endereco = obj_end.ToString();
                            CamadaNegocio.Faturamento.Pedido.TCN_Pedido.Grava_Pedido(rPed, null);
                            //Buscar pedido
                            rPed = CamadaNegocio.Faturamento.Pedido.TCN_Pedido.Busca_Registro_Pedido(rPed.Nr_pedido.ToString(), null);
                            //Buscar itens pedido
                            CamadaNegocio.Faturamento.Pedido.TCN_Pedido.Busca_Pedido_Itens(rPed, false, null);
                            //Gerar Nota Fiscal
                            CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento rFat =
                                Proc_Commoditties.TProcessaPedFaturar.ProcessaPedFaturar(rPed, false, decimal.Zero);
                            //Gravar Nota Fiscal
                            CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.GravarFaturamento(rFat, null, null);
                            if (!st_servico)
                                using (srvNFE.TFGerenciarNFe fGerNfe = new srvNFE.TFGerenciarNFe())
                                {
                                    fGerNfe.rNfe = CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.BuscarNF(rFat.Cd_empresa,
                                                                                                                    rFat.Nr_lanctofiscalstr,
                                                                                                                    null);
                                    fGerNfe.ShowDialog();
                                }
                            else
                                try
                                {
                                    CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento rNf =
                                    CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.BuscarNF(rFat.Cd_empresa,
                                                                                                     rFat.Nr_lanctofiscalstr,
                                                                                                     null);
                                    NFES.TGerarRPS.CriarArquivoRPS(rNf.rCfgNfe, new List<CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento>() { rNf });
                                    MessageBox.Show("NFS-e enviada com sucesso. Aguarde alguns segundos e consulte o status do lote.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                catch (Exception ex)
                                { MessageBox.Show("Erro enviar NFS-e: " + ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                        }
                        catch (Exception ex)
                        {
                            if (rPed != null)
                                CamadaNegocio.Faturamento.Pedido.TCN_Pedido.Deleta_Pedido(rPed, null);
                            MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
            }
        }

        private void afterInserirPecas(bool st_servico)
        {
            if (bsOS.Current != null)
            {
                if ((bsOS.Current as TRegistro_LanServico).St_os.Trim().ToUpper().Equals("CA"))
                {
                    MessageBox.Show("Não é permitido evoluir OS CANCELADA.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if ((bsOS.Current as TRegistro_LanServico).St_os.Trim().ToUpper().Equals("PR"))
                {
                    MessageBox.Show("Não é permitido evoluir OS PROCESSADA.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if ((bsOS.Current as TRegistro_LanServico).St_os.Trim().ToUpper().Equals("DV"))
                {
                    MessageBox.Show("Não é permitido evoluir OS DEVOLVIDA.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                using (TFLan_Pecas_Ordem_Servico fPecas = new TFLan_Pecas_Ordem_Servico())
                {
                    fPecas.CD_Empresa = (bsOS.Current as TRegistro_LanServico).Cd_empresa;
                    fPecas.Nm_empresa = (bsOS.Current as TRegistro_LanServico).Nm_empresa;
                    fPecas.Cd_clifor = (bsOS.Current as TRegistro_LanServico).Cd_clifor;
                    fPecas.CD_TabelaPreco = (bsOS.Current as TRegistro_LanServico).Cd_tabelapreco;
                    fPecas.St_acrescbasedesc = (bsOS.Current as TRegistro_LanServico).St_acrescbasedesc;
                    fPecas.St_garantia = false;
                    fPecas.pSt_servico = st_servico;
                    if (st_servico && (bsOS.Current as TRegistro_LanServico).lPecas.Exists(p => !string.IsNullOrEmpty(p.Cd_tecnico) && p.St_servicobool))
                    {
                        fPecas.Cd_tecnico = (bsOS.Current as TRegistro_LanServico).lPecas.LastOrDefault(p => !string.IsNullOrEmpty(p.Cd_tecnico) && p.St_servicobool).Cd_tecnico;
                        fPecas.Nm_tecnico = (bsOS.Current as TRegistro_LanServico).lPecas.LastOrDefault(p => !string.IsNullOrEmpty(p.Cd_tecnico) && p.St_servicobool).Nm_tecnico;
                    }
                    else if (!st_servico && (bsOS.Current as TRegistro_LanServico).lPecas.Exists(p => !string.IsNullOrEmpty(p.Cd_tecnico) && p.St_servicobool == false))
                    {
                        fPecas.Cd_tecnico = (bsOS.Current as TRegistro_LanServico).lPecas.LastOrDefault(p => !string.IsNullOrEmpty(p.Cd_tecnico) && p.St_servicobool == false).Cd_tecnico;
                        fPecas.Nm_tecnico = (bsOS.Current as TRegistro_LanServico).lPecas.LastOrDefault(p => !string.IsNullOrEmpty(p.Cd_tecnico) && p.St_servicobool == false).Nm_tecnico;
                    }
                    if (fPecas.ShowDialog() == DialogResult.OK)
                    {
                        if(fPecas.rPeca != null)
                            try
                            {
                                fPecas.rPeca.Cd_empresa = (bsOS.Current as TRegistro_LanServico).Cd_empresa;
                                fPecas.rPeca.Id_os = (bsOS.Current as TRegistro_LanServico).Id_os;
                                TCN_LanServicoPecas.Gravar(fPecas.rPeca, null);
                                afterBusca();
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    }
                }
            }
            else
                MessageBox.Show("Não existe ordem de serviço selecionada.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        
        private void afterAlterarPecas(bool st_servico)
        {
            if (bsOS.Current != null)
            {
                if ((bsOS.Current as TRegistro_LanServico).St_os.Trim().ToUpper().Equals("CA"))
                {
                    MessageBox.Show("Não é permitido evoluir OS CANCELADA.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if ((bsOS.Current as TRegistro_LanServico).St_os.Trim().ToUpper().Equals("PR"))
                {
                    MessageBox.Show("Não é permitido evoluir OS PROCESSADA.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if ((bsOS.Current as TRegistro_LanServico).St_os.Trim().ToUpper().Equals("DV"))
                {
                    MessageBox.Show("Não é permitido evoluir OS DEVOLVIDA.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (!st_servico && bsPecas.Current == null)
                {
                    MessageBox.Show("Obrigatorio selecionar peça para alterar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (st_servico && bsServico.Current == null)
                {
                    MessageBox.Show("Obrigatorio selecionar Serviço para alterar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                using (TFLan_Pecas_Ordem_Servico fPeca = new TFLan_Pecas_Ordem_Servico())
                {
                    fPeca.CD_Empresa = (bsOS.Current as TRegistro_LanServico).Cd_empresa;
                    fPeca.Nm_empresa = (bsOS.Current as TRegistro_LanServico).Nm_empresa;
                    fPeca.CD_TabelaPreco = (bsOS.Current as TRegistro_LanServico).Cd_tabelapreco;
                    fPeca.St_acrescbasedesc = (bsOS.Current as TRegistro_LanServico).St_acrescbasedesc;
                    fPeca.St_alterar = true;
                    fPeca.pSt_servico = st_servico;
                    fPeca.rPeca = st_servico ? bsServico.Current as TRegistro_LanServicosPecas : bsPecas.Current as TRegistro_LanServicosPecas;
                    if (fPeca.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            TCN_LanServicoPecas.Gravar(fPeca.rPeca, null);
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    }
                    afterBusca();
                }
            }
            else
                MessageBox.Show("Não existe peça(serviço) selecionado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        
        private void afterExcluirPecas(bool st_servico)
        {
            if (bsOS.Current != null)
            {
                if ((bsOS.Current as TRegistro_LanServico).St_os.Trim().ToUpper().Equals("CA"))
                {
                    MessageBox.Show("Não é permitido evoluir OS CANCELADA.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if ((bsOS.Current as TRegistro_LanServico).St_os.Trim().ToUpper().Equals("PR"))
                {
                    MessageBox.Show("Não é permitido evoluir OS PROCESSADA.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if ((bsOS.Current as TRegistro_LanServico).St_os.Trim().ToUpper().Equals("DV"))
                {
                    MessageBox.Show("Não é permitido evoluir OS DEVOLVIDA.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (!st_servico)
                {
                    if (bsPecas.Current == null)
                    {
                        MessageBox.Show("Obrigatorio selecionar peça para excluir.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if (MessageBox.Show("Peça selecionada: " + (bsPecas.Current as TRegistro_LanServicosPecas).Cd_produto.Trim() + "-" +
                                                                    (bsPecas.Current as TRegistro_LanServicosPecas).Ds_produto.Trim() +
                                        "\r\n\r\nConfirma exclusão?", "Pergunta", MessageBoxButtons.YesNo,
                                        MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        try
                        {
                            TCN_LanServicoPecas.Excluir(bsPecas.Current as TRegistro_LanServicosPecas, null);
                            afterBusca();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    }
                }
                else
                {
                    if (bsServico.Current == null)
                    {
                        MessageBox.Show("Obrigatorio selecionar serviço para excluir.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if (MessageBox.Show("Serviço selecionado: " + (bsServico.Current as TRegistro_LanServicosPecas).Cd_produto.Trim() + "-" +
                                                                    (bsServico.Current as TRegistro_LanServicosPecas).Ds_produto.Trim() +
                                        "\r\n\r\nConfirma exclusão?", "Pergunta", MessageBoxButtons.YesNo,
                                        MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        try
                        {
                            TCN_LanServicoPecas.Excluir(bsServico.Current as TRegistro_LanServicosPecas, null);
                            bsOS_PositionChanged(this, new EventArgs());
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    }
                }
            }
            else
                MessageBox.Show("Não existe ordem serviço selecionada.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void afterInserirHistorico()
        {
            if (bsOS.Current != null)
            {
                if ((bsOS.Current as TRegistro_LanServico).St_os.Trim().ToUpper().Equals("CA"))
                {
                    MessageBox.Show("Não é permitido evoluir OS CANCELADA.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if ((bsOS.Current as TRegistro_LanServico).St_os.Trim().ToUpper().Equals("PR"))
                {
                    MessageBox.Show("Não é permitido evoluir OS PROCESSADA.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if ((bsOS.Current as TRegistro_LanServico).St_os.Trim().ToUpper().Equals("DV"))
                {
                    MessageBox.Show("Não é permitido evoluir OS DEVOLVIDA.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                using (TFHistoricoOS fHist = new TFHistoricoOS())
                {
                    if (fHist.ShowDialog() == DialogResult.OK)
                        if (fHist.rHist != null)
                            try
                            {
                                fHist.rHist.Cd_empresa = (bsOS.Current as TRegistro_LanServico).Cd_empresa;
                                fHist.rHist.Id_os = (bsOS.Current as TRegistro_LanServico).Id_os;
                                TCN_Historico.Gravar(fHist.rHist, null);
                                afterBusca();
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            }
        }

        private void afterInserirFoto()
        {
            if (bsOS.Current != null)
            {
                if ((bsOS.Current as TRegistro_LanServico).St_os.Trim().ToUpper().Equals("CA"))
                {
                    MessageBox.Show("Não é permitido evoluir OS CANCELADA.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if ((bsOS.Current as TRegistro_LanServico).St_os.Trim().ToUpper().Equals("PR"))
                {
                    MessageBox.Show("Não é permitido evoluir OS PROCESSADA.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if ((bsOS.Current as TRegistro_LanServico).St_os.Trim().ToUpper().Equals("DV"))
                {
                    MessageBox.Show("Não é permitido evoluir OS DEVOLVIDA.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                using (TFFotosOS fFoto = new TFFotosOS())
                {
                    if (fFoto.ShowDialog() == DialogResult.OK)
                        if(fFoto.rFoto != null)
                            try
                            {
                                fFoto.rFoto.Cd_empresa = (bsOS.Current as TRegistro_LanServico).Cd_empresa;
                                fFoto.rFoto.Id_os = (bsOS.Current as TRegistro_LanServico).Id_os;
                                TCN_Imagens.Gravar(fFoto.rFoto, null);
                                afterBusca();
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            }
        }

        private void afterExcluirFoto()
        {
            if (bsOS.Current != null)
            {
                if ((bsOS.Current as TRegistro_LanServico).St_os.Trim().ToUpper().Equals("CA"))
                {
                    MessageBox.Show("Não é permitido evoluir OS CANCELADA.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if ((bsOS.Current as TRegistro_LanServico).St_os.Trim().ToUpper().Equals("PR"))
                {
                    MessageBox.Show("Não é permitido evoluir OS PROCESSADA.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if ((bsOS.Current as TRegistro_LanServico).St_os.Trim().ToUpper().Equals("DV"))
                {
                    MessageBox.Show("Não é permitido evoluir OS DEVOLVIDA.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (bsImagens.Current != null)
                    if (MessageBox.Show("Confirma exclusão da foto selecionada?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                        == DialogResult.Yes)
                        try
                        {
                            TCN_Imagens.Excluir(bsImagens.Current as TRegistro_Imagens, null);
                            afterBusca();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void TFPainelOSOficina_Load(object sender, EventArgs e)
        {
            ShapeGrid.RestoreShape(this, gOS);
            ShapeGrid.RestoreShape(this, dataGridDefault1);
            ShapeGrid.RestoreShape(this, gServico);
            Icon = ResourcesUtils.TecnoAliance_ICO;
            //Preencer combobox empresa
            cbEmpresa.DataSource = new CamadaDados.Diversos.TCD_CadEmpresa().Select(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = string.Empty,
                                            vOperador = "EXISTS",
                                            vVL_Busca = "(select 1 from tb_div_usuario_x_empresa x " +
                                                        "where x.cd_empresa = a.cd_empresa " +
                                                        "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                                        "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                                        "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))"

                                        }
                                    }, 0, string.Empty);
            cbEmpresa.DisplayMember = "NM_Empresa";
            cbEmpresa.ValueMember = "CD_Empresa";
            if ((cbEmpresa.DataSource as CamadaDados.Diversos.TList_CadEmpresa).Count > 0)
                cbEmpresa.SelectedIndex = 0;
            else
            {
                Close();
                return;
            }
            //Preencher combobox etapas
            cbEtapaOrdem.DataSource = new TCD_EtapaOrdem().Select(
                                        new TpBusca[]
                                        {
                                            new TpBusca()
                                            {
                                                vNM_Campo = string.Empty,
                                                vOperador = "exists",
                                                vVL_Busca = "(select 1 from tb_ose_tpordem_x_etapa x " +
                                                            "inner join tb_ose_tpordem y " +
                                                            "on x.tp_ordem = y.tp_ordem " +
                                                            "where x.id_etapa = a.id_etapa "+
                                                            "and y.tp_os = 'O')"
                                            }
                                        }, 0, string.Empty);
            cbEtapaOrdem.DisplayMember = "ds_etapa";
            cbEtapaOrdem.ValueMember = "id_etapa";
            //Preencher campo Top
            Top.Value = CamadaNegocio.ConfigGer.TCN_CadParamGer.BuscaVlNumerico("TOPMAX_CONSULTA", null);
            if (Top.Value.Equals(decimal.Zero))
                Top.Value = 15;
            //Habilitar opcoes usuario
            bb_abrirOS.Enabled = CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin, "PERMITIR ABRIR ORDEM SERVICO", null);
            bb_evoluirOS.Enabled = CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin, "PERMITIR EVOLUIR ORDEM SERVICO", null);
            bb_cancelarOS.Enabled = CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin, "PERMITIR CANCELAR ORDEM SERVICO", null);
            bb_processarOS.Enabled = CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin, "PERMITIR PROCESSAR ORDEM SERVICO", null);
            bb_estornarProc.Enabled = CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin, "PERMITIR ESTORNAR PROCESSAMENTO OS", null);
        }

        private void cbEtapaOrdem_SelectedIndexChanged(object sender, EventArgs e)
        {
            afterBusca();
        }

        private void TFPainelOSOficina_KeyDown(object sender, KeyEventArgs e)
        {
            if (bb_abrirOS.Enabled && e.KeyCode.Equals(Keys.F2))
                afterNovo();
            else if (e.KeyCode.Equals(Keys.F3))
                CorrigirOS();
            else if (bb_evoluirOS.Enabled && e.KeyCode.Equals(Keys.F4))
                EvoluirOS();
            else if (bb_cancelarOS.Enabled && e.KeyCode.Equals(Keys.F5))
                afterExclui();
            else if (e.KeyCode.Equals(Keys.F7))
                afterBusca();
            else if (e.KeyCode.Equals(Keys.F8))
                afterPrint(string.Empty, string.Empty);
            else if (bb_processarOS.Enabled && e.KeyCode.Equals(Keys.F10))
                ProcessarOs();
            else if (bb_estornarProc.Enabled && e.KeyCode.Equals(Keys.F11))
                EstornarProcessarOs();
            else if (e.KeyCode.Equals(Keys.F12))
                DevolverOs();
            else if (e.Control && e.KeyCode.Equals(Keys.F4))
                Close();
            else if (e.Control && e.KeyCode.Equals(Keys.P))
            {
                Altera_Relatorio = true;
                MessageBox.Show("Execute o relatorio que deseja alterar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
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
                    else if (e.Value.ToString().Trim().ToUpper().Equals("RETIRADA"))
                        gOS.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Green;
                    else
                        gOS.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                }
        }

        private void cbFinalizada_Click(object sender, EventArgs e)
        {
            afterBusca();
        }

        private void cbProcessada_Click(object sender, EventArgs e)
        {
            afterBusca();
        }

        private void bb_clifor_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { nm_clifor }, string.Empty);
        }

        private void bb_buscar_Click(object sender, EventArgs e)
        {
            afterBusca();
        }

        private void TFPainelOSOficina_FormClosing(object sender, FormClosingEventArgs e)
        {
            ShapeGrid.SaveShape(this, gOS);
            ShapeGrid.SaveShape(this, dataGridDefault1);
            ShapeGrid.SaveShape(this, gServico);
        }

        private void gOS_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gOS.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsOS.Count < 1)
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
            (bsOS.List as TList_LanServico).Sort(lComparer);
            bsOS.ResetBindings(false);
            gOS.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void bsOS_PositionChanged(object sender, EventArgs e)
        {
            if (bsOS.Current != null)
            {
                (bsOS.Current as TRegistro_LanServico).lPecas =
                    TCN_LanServicoPecas.Buscar((bsOS.Current as TRegistro_LanServico).Id_osstr,
                                                (bsOS.Current as TRegistro_LanServico).Cd_empresa,
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
                //Buscar Pecas 
                bsPecas.DataSource = (bsOS.Current as TRegistro_LanServico).lPecas.FindAll(p => p.St_servicobool == false);

                //Buscar Servicos
                bsServico.DataSource = (bsOS.Current as TRegistro_LanServico).lPecas.FindAll(p => p.St_servicobool);
                TotPecasServicos();
                bsOS.ResetCurrentItem();
            }
            else
            {
                bsPecas.DataSource = null;
                bsServico.DataSource = null;
            }

        }

        private void gOS_DoubleClick(object sender, EventArgs e)
        {
            EvoluirOS();
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bb_retirarOS_Click(object sender, EventArgs e)
        {
            DevolverOs();
        }

        private void bb_estornarProc_Click(object sender, EventArgs e)
        {
            EstornarProcessarOs();
        }

        private void bb_processarOS_Click(object sender, EventArgs e)
        {
            ProcessarOs();
        }

        private void bb_cancelarOS_Click(object sender, EventArgs e)
        {
            afterExclui();
        }

        private void bb_evoluirOS_Click(object sender, EventArgs e)
        {
            EvoluirOS();
        }

        private void bb_abrirOS_Click(object sender, EventArgs e)
        {
            afterNovo();
        }

        private void miNFPecas_Click(object sender, EventArgs e)
        {
            if (bsOS.Current != null)
            {
                if (MessageBox.Show("Deseja Faturar essa OS corrente?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    == DialogResult.No)
                    AgruparOSNF(false);
                else
                {
                    if ((bsOS.Current as TRegistro_LanServico).St_os.Trim().ToUpper().Equals("PR"))
                    {
                        object obj = new CamadaDados.Faturamento.NotaFiscal.TCD_LanFaturamento().BuscarEscalar(
                                        new TpBusca[]
                                        {
                                            new TpBusca()
                                            {
                                                vNM_Campo = "isnull(a.st_registro, 'A')",
                                                vOperador = "<>",
                                                vVL_Busca = "'C'"
                                            },
                                            new TpBusca()
                                            {
                                                vNM_Campo = string.Empty,
                                                vOperador = "exists",
                                                vVL_Busca = "(select 1 from tb_fat_notafiscal_item x " +
                                                            "inner join TB_OSE_Servico_X_PedidoItem y " +
                                                            "on x.nr_pedido = y.nr_pedido " +
                                                            "and x.cd_produto = y.cd_produto " +
                                                            "and x.id_pedidoitem = y.id_pedidoitem " +
                                                            "where x.cd_empresa = a.cd_empresa " +
                                                            "and x.nr_lanctofiscal = a.nr_lanctofiscal " +
                                                            "and y.tp_pedido = 'IT' " +
                                                            "and y.cd_empresa = '" + (bsOS.Current as TRegistro_LanServico).Cd_empresa.Trim() + "' " +
                                                            "and y.id_os = " + (bsOS.Current as TRegistro_LanServico).Id_osstr + ")"
                                            }
                                        }, "a.nr_notafiscal");
                        if (obj != null)
                        {
                            MessageBox.Show("Peças ordem serviço ja foram faturadas. Nota Fiscal Nº" + obj.ToString(), "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        TList_OSE_ParamOS lParam =
                        TCN_OSE_ParamOS.Buscar((bsOS.Current as TRegistro_LanServico).Tp_ordemstr,
                                                string.Empty,
                                                string.Empty,
                                                string.Empty,
                                                string.Empty,
                                                string.Empty,
                                                string.Empty,
                                                string.Empty,
                                                string.Empty,
                                                0,
                                                string.Empty,
                                                null);
                        if (lParam.Count.Equals(0))
                        {
                            MessageBox.Show("Não existe parametro para o tipo de OS.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        if (string.IsNullOrEmpty(lParam[0].Cfg_pedido_item))
                        {
                            MessageBox.Show("Não existe tipo pedido configurado para o tipo de OS.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        CamadaDados.Faturamento.Pedido.TRegistro_Pedido rPed = null;
                        try
                        {
                            CamadaDados.Faturamento.Pedido.TList_Pedido lPed =
                            new CamadaDados.Faturamento.Pedido.TCD_Pedido().Select(
                                new TpBusca[]
                                {
                                    new TpBusca()
                                    {
                                        vNM_Campo = "isnull(a.st_registro, 'A')",
                                        vOperador = "<>",
                                        vVL_Busca = "'C'"
                                    },
                                    new TpBusca()
                                    {
                                        vNM_Campo = string.Empty,
                                        vOperador = "exists",
                                        vVL_Busca = "(select 1 from TB_OSE_Servico_X_PedidoItem x " +
                                                    "where x.nr_pedido = a.nr_pedido " +
                                                    "and x.tp_pedido = 'IT' " +
                                                    "and x.cd_empresa = '" + (bsOS.Current as TRegistro_LanServico).Cd_empresa.Trim() + "' " +
                                                    "and x.id_os = " + (bsOS.Current as TRegistro_LanServico).Id_osstr + ")"
                                    }
                                }, 1, string.Empty);
                            if (lPed.Count > 0)
                                rPed = lPed[0];
                            else
                            {
                                TList_LanServicosPecas lPecas =
                                    new TCD_LanServicosPecas().Select(
                                    new TpBusca[]
                                {
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.cd_empresa",
                                        vOperador = "=",
                                        vVL_Busca = "'" + (bsOS.Current as TRegistro_LanServico).Cd_empresa.Trim() + "'"
                                    },
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.id_os",
                                        vOperador = "=",
                                        vVL_Busca = (bsOS.Current as TRegistro_LanServico).Id_osstr
                                    },
                                    new TpBusca()
                                    {
                                        vNM_Campo = "isnull(tp.st_servico, 'N')",
                                        vOperador = "<>",
                                        vVL_Busca = "'S'"
                                    },
                                    new TpBusca()
                                    {
                                        vNM_Campo = "isnull(a.ST_AtendimentoGarantia, 'N')",
                                        vOperador = "<>",
                                        vVL_Busca = "'S'"
                                    }
                                }, 0, string.Empty, string.Empty);
                                if (lPecas.Count.Equals(0))
                                {
                                    MessageBox.Show("Não existe peças disponivel para faturar na OS.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                                Proc_Commoditties.TProcessaPedidoOS.GerarPedidoPecas(ref rPed,
                                                                                     bsOS.Current as TRegistro_LanServico,
                                                                                     lPecas,
                                                                                     lParam[0]);
                            }
                            CamadaNegocio.Faturamento.Pedido.TCN_Pedido.Grava_Pedido(rPed, null);
                            //Buscar pedido
                            rPed = CamadaNegocio.Faturamento.Pedido.TCN_Pedido.Busca_Registro_Pedido(rPed.Nr_pedido.ToString(), null);
                            //Buscar itens pedido
                            CamadaNegocio.Faturamento.Pedido.TCN_Pedido.Busca_Pedido_Itens(rPed, false, null);
                            //Gerar Nota Fiscal
                            CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento rFat =
                                Proc_Commoditties.TProcessaPedFaturar.ProcessaPedFaturar(rPed, false, decimal.Zero);
                            //Gravar Nota Fiscal
                            CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.GravarFaturamento(rFat, null, null);
                            using (srvNFE.TFGerenciarNFe fGerNfe = new srvNFE.TFGerenciarNFe())
                            {
                                fGerNfe.rNfe = CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.BuscarNF(rFat.Cd_empresa,
                                                                                                                rFat.Nr_lanctofiscalstr,
                                                                                                                null);
                                fGerNfe.ShowDialog();
                            }
                        }
                        catch (Exception ex)
                        {
                            if (rPed != null)
                                CamadaNegocio.Faturamento.Pedido.TCN_Pedido.Deleta_Pedido(rPed, null);
                            MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else MessageBox.Show("Permitido Faturar somente ordem serviço PROCESSADA.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void listaDeOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RelatorioOs();
        }

        private void ordemServiçoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            afterPrint(string.Empty, string.Empty);
        }

        private void miNFGarantia_Click(object sender, EventArgs e)
        {
            if (bsOS.Current != null)
                if ((bsOS.Current as TRegistro_LanServico).St_os.Trim().ToUpper().Equals("PR"))
                {
                    object obj = new CamadaDados.Faturamento.NotaFiscal.TCD_LanFaturamento().BuscarEscalar(
                                    new TpBusca[]
                                        {
                                            new TpBusca()
                                            {
                                                vNM_Campo = "isnull(a.st_registro, 'A')",
                                                vOperador = "<>",
                                                vVL_Busca = "'C'"
                                            },
                                            new TpBusca()
                                            {
                                                vNM_Campo = string.Empty,
                                                vOperador = "exists",
                                                vVL_Busca = "(select 1 from tb_fat_notafiscal_item x " +
                                                            "inner join TB_OSE_Servico_X_PedidoItem y " +
                                                            "on x.nr_pedido = y.nr_pedido " +
                                                            "and x.cd_produto = y.cd_produto " +
                                                            "and x.id_pedidoitem = y.id_pedidoitem " +
                                                            "where x.cd_empresa = a.cd_empresa " +
                                                            "and x.nr_lanctofiscal = a.nr_lanctofiscal " +
                                                            "and y.tp_pedido = 'GR' " +
                                                            "and y.cd_empresa = '" + (bsOS.Current as TRegistro_LanServico).Cd_empresa.Trim() + "' " +
                                                            "and y.id_os = " + (bsOS.Current as TRegistro_LanServico).Id_osstr + ")"
                                            }
                                        }, "a.nr_notafiscal");
                    if (obj != null)
                    {
                        MessageBox.Show("Peças em garantia ordem serviço ja foram faturadas. Nota Fiscal Nº" + obj.ToString(), "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    TList_OSE_ParamOS lParam =
                    TCN_OSE_ParamOS.Buscar((bsOS.Current as TRegistro_LanServico).Tp_ordemstr,
                                            string.Empty,
                                            string.Empty,
                                            string.Empty,
                                            string.Empty,
                                            string.Empty,
                                            string.Empty,
                                            string.Empty,
                                            string.Empty,
                                            0,
                                            string.Empty,
                                            null);
                    if (lParam.Count.Equals(0))
                    {
                        MessageBox.Show("Não existe parametro para o tipo de OS.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if (string.IsNullOrEmpty(lParam[0].Cfg_pedido_garantia))
                    {
                        MessageBox.Show("Não existe tipo pedido garantia configurado para o tipo de OS.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    CamadaDados.Faturamento.Pedido.TRegistro_Pedido rPed = null;
                    try
                    {
                        CamadaDados.Faturamento.Pedido.TList_Pedido lPed =
                        new CamadaDados.Faturamento.Pedido.TCD_Pedido().Select(
                            new TpBusca[]
                                {
                                    new TpBusca()
                                    {
                                        vNM_Campo = "isnull(a.st_registro, 'A')",
                                        vOperador = "<>",
                                        vVL_Busca = "'C'"
                                    },
                                    new TpBusca()
                                    {
                                        vNM_Campo = string.Empty,
                                        vOperador = "exists",
                                        vVL_Busca = "(select 1 from TB_OSE_Servico_X_PedidoItem x " +
                                                    "where x.nr_pedido = a.nr_pedido " +
                                                    "and x.tp_pedido = 'GR' " +
                                                    "and x.cd_empresa = '" + (bsOS.Current as TRegistro_LanServico).Cd_empresa.Trim() + "' " +
                                                    "and x.id_os = " + (bsOS.Current as TRegistro_LanServico).Id_osstr + ")"
                                    }
                                }, 1, string.Empty);
                        if (lPed.Count > 0)
                            rPed = lPed[0];
                        else
                        {
                            TList_LanServicosPecas lPecas =
                                new TCD_LanServicosPecas().Select(
                                new TpBusca[]
                                {
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.cd_empresa",
                                        vOperador = "=",
                                        vVL_Busca = "'" + (bsOS.Current as TRegistro_LanServico).Cd_empresa.Trim() + "'"
                                    },
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.id_os",
                                        vOperador = "=",
                                        vVL_Busca = (bsOS.Current as TRegistro_LanServico).Id_osstr
                                    },
                                    new TpBusca()
                                    {
                                        vNM_Campo = "isnull(tp.st_servico, 'N')",
                                        vOperador = "<>",
                                        vVL_Busca = "'S'"
                                    },
                                    new TpBusca()
                                    {
                                        vNM_Campo = "isnull(a.ST_AtendimentoGarantia, 'N')",
                                        vOperador = "=",
                                        vVL_Busca = "'S'"
                                    }
                                }, 0, string.Empty, string.Empty);
                            if (lPecas.Count.Equals(0))
                            {
                                MessageBox.Show("Não existe peça em garantia para faturar na ordem serviço.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                            Proc_Commoditties.TProcessaPedidoOS.GerarPedidoGarantia(ref rPed,
                                                                                    bsOS.Current as TRegistro_LanServico,
                                                                                    lPecas,
                                                                                    lParam[0]);
                        }
                        CamadaNegocio.Faturamento.Pedido.TCN_Pedido.Grava_Pedido(rPed, null);
                        //Buscar pedido
                        rPed = CamadaNegocio.Faturamento.Pedido.TCN_Pedido.Busca_Registro_Pedido(rPed.Nr_pedido.ToString(), null);
                        //Buscar itens pedido
                        CamadaNegocio.Faturamento.Pedido.TCN_Pedido.Busca_Pedido_Itens(rPed, false, null);
                        //Gerar Nota Fiscal
                        CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento rFat =
                            Proc_Commoditties.TProcessaPedFaturar.ProcessaPedFaturar(rPed, false, decimal.Zero);
                        //Gravar Nota Fiscal
                        CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.GravarFaturamento(rFat, null, null);
                        using (srvNFE.TFGerenciarNFe fGerNfe = new srvNFE.TFGerenciarNFe())
                        {
                            fGerNfe.rNfe = CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.BuscarNF(rFat.Cd_empresa,
                                                                                                            rFat.Nr_lanctofiscalstr,
                                                                                                            null);
                            fGerNfe.ShowDialog();
                        }
                    }
                    catch (Exception ex)
                    {
                        if (rPed != null)
                            CamadaNegocio.Faturamento.Pedido.TCN_Pedido.Deleta_Pedido(rPed, null);
                        MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else MessageBox.Show("Permitido Faturar somente ordem serviço PROCESSADA.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void miNFServico_Click(object sender, EventArgs e)
        {
            if (bsOS.Current != null)
                if (MessageBox.Show("Deseja Faturar essa OS corrente?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    == DialogResult.No)
                    AgruparOSNF(true);
                else
                {
                    if ((bsOS.Current as TRegistro_LanServico).St_os.Trim().ToUpper().Equals("PR"))
                    {
                        object obj = new CamadaDados.Faturamento.NotaFiscal.TCD_LanFaturamento().BuscarEscalar(
                                        new TpBusca[]
                                        {
                                            new TpBusca()
                                            {
                                                vNM_Campo = "isnull(a.st_registro, 'A')",
                                                vOperador = "<>",
                                                vVL_Busca = "'C'"
                                            },
                                            new TpBusca()
                                            {
                                                vNM_Campo = string.Empty,
                                                vOperador = "exists",
                                                vVL_Busca = "(select 1 from tb_fat_notafiscal_item x " +
                                                            "inner join TB_OSE_Servico_X_PedidoItem y " +
                                                            "on x.nr_pedido = y.nr_pedido " +
                                                            "and x.cd_produto = y.cd_produto " +
                                                            "and x.id_pedidoitem = y.id_pedidoitem " +
                                                            "where x.cd_empresa = a.cd_empresa " +
                                                            "and x.nr_lanctofiscal = a.nr_lanctofiscal " +
                                                            "and y.tp_pedido = 'SV' " +
                                                            "and y.cd_empresa = '" + (bsOS.Current as TRegistro_LanServico).Cd_empresa.Trim() + "' " +
                                                            "and y.id_os = " + (bsOS.Current as TRegistro_LanServico).Id_osstr + ")"
                                            }
                                        }, "a.nr_notafiscal");
                        if (obj != null)
                        {
                            MessageBox.Show("SERVIÇOS da ordem serviço ja foram faturados. Nota Fiscal Nº" + obj.ToString(), "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        TList_OSE_ParamOS lParam =
                        TCN_OSE_ParamOS.Buscar((bsOS.Current as TRegistro_LanServico).Tp_ordemstr,
                                                                                string.Empty,
                                                                                string.Empty,
                                                                                string.Empty,
                                                                                string.Empty,
                                                                                string.Empty,
                                                                                string.Empty,
                                                                                string.Empty,
                                                                                string.Empty,
                                                                                0,
                                                                                string.Empty,
                                                                                null);
                        if (lParam.Count.Equals(0))
                        {
                            MessageBox.Show("Não existe parametro para o tipo de OS.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        if (string.IsNullOrEmpty(lParam[0].Cfg_pedido_servico))
                        {
                            MessageBox.Show("Não existe tipo pedido serviço configurado para o tipo de OS.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        CamadaDados.Faturamento.Pedido.TRegistro_Pedido rPed = null;
                        try
                        {
                            CamadaDados.Faturamento.Pedido.TList_Pedido lPed =
                            new CamadaDados.Faturamento.Pedido.TCD_Pedido().Select(
                                new TpBusca[]
                                {
                                    new TpBusca()
                                    {
                                        vNM_Campo = "isnull(a.st_registro, 'A')",
                                        vOperador = "<>",
                                        vVL_Busca = "'C'"
                                    },
                                    new TpBusca()
                                    {
                                        vNM_Campo = string.Empty,
                                        vOperador = "exists",
                                        vVL_Busca = "(select 1 from TB_OSE_Servico_X_PedidoItem x " +
                                                    "where x.nr_pedido = a.nr_pedido " +
                                                    "and x.tp_pedido = 'SV' " +
                                                    "and x.cd_empresa = '" + (bsOS.Current as TRegistro_LanServico).Cd_empresa.Trim() + "' " +
                                                    "and x.id_os = " + (bsOS.Current as TRegistro_LanServico).Id_osstr + ")"
                                    }
                                }, 1, string.Empty);
                            if (lPed.Count > 0)
                                rPed = lPed[0];
                            else
                            {
                                TList_LanServicosPecas lServico =
                                    new TCD_LanServicosPecas().Select(
                                    new TpBusca[]
                                {
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.cd_empresa",
                                        vOperador = "=",
                                        vVL_Busca = "'" + (bsOS.Current as TRegistro_LanServico).Cd_empresa.Trim() + "'"
                                    },
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.id_os",
                                        vOperador = "=",
                                        vVL_Busca = (bsOS.Current as TRegistro_LanServico).Id_osstr
                                    },
                                    new TpBusca()
                                    {
                                        vNM_Campo = "isnull(tp.st_servico, 'N')",
                                        vOperador = "=",
                                        vVL_Busca = "'S'"
                                    },
                                    new TpBusca()
                                    {
                                        vNM_Campo = "isnull(a.ST_AtendimentoGarantia, 'N')",
                                        vOperador = "<>",
                                        vVL_Busca = "'S'"
                                    }
                                }, 0, string.Empty, string.Empty);
                                if (lServico.Count.Equals(0))
                                {
                                    MessageBox.Show("Não existe serviço para faturar no ordem de serviço.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                                Proc_Commoditties.TProcessaPedidoOS.GerarPedidoServico(ref rPed,
                                                                                       bsOS.Current as TRegistro_LanServico,
                                                                                       lServico,
                                                                                       lParam[0]);
                            }
                            CamadaNegocio.Faturamento.Pedido.TCN_Pedido.Grava_Pedido(rPed, null);
                            //Buscar pedido
                            rPed = CamadaNegocio.Faturamento.Pedido.TCN_Pedido.Busca_Registro_Pedido(rPed.Nr_pedido.ToString(), null);
                            //Buscar itens pedido
                            CamadaNegocio.Faturamento.Pedido.TCN_Pedido.Busca_Pedido_Itens(rPed, false, null);
                            //Gerar Nota Fiscal
                            CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento rFat =
                                Proc_Commoditties.TProcessaPedFaturar.ProcessaPedFaturar(rPed, false, decimal.Zero);
                            //Gravar Nota Fiscal
                            CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.GravarFaturamento(rFat, null, null);
                            try
                            {
                                CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento rNf =
                                CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.BuscarNF(rFat.Cd_empresa,
                                                                                                 rFat.Nr_lanctofiscalstr,
                                                                                                 null);
                                NFES.TGerarRPS.CriarArquivoRPS(rNf.rCfgNfe, new List<CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento>() { rNf });
                                MessageBox.Show("NFS-e enviada com sucesso. Aguarde alguns segundos e consulte o status do lote.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            catch (Exception ex)
                            { MessageBox.Show("Erro enviar NFS-e: " + ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                        }
                        catch (Exception ex)
                        {
                            if (rPed != null)
                                CamadaNegocio.Faturamento.Pedido.TCN_Pedido.Deleta_Pedido(rPed, null);
                            MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else MessageBox.Show("Permitido Faturar somente ordem serviço PROCESSADA.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
        }

        private void nFCePeçasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bsOS.Current != null)
            {
                if ((bsOS.Current as TRegistro_LanServico).St_os.Trim().ToUpper().Equals("PR"))
                {
                    if (MessageBox.Show("Confirma faturamento da OS Corrente?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                        == DialogResult.Yes)
                    {
                        //Verificar se ja nao esta faturada
                        object obj = new CamadaDados.Faturamento.NotaFiscal.TCD_LanFaturamento().BuscarEscalar(
                                        new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = "isnull(a.st_registro, 'A')",
                                            vOperador = "<>",
                                            vVL_Busca = "'C'"
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = string.Empty,
                                            vOperador = "exists",
                                            vVL_Busca = "(select 1 from tb_fat_notafiscal_item x " +
                                                        "inner join TB_OSE_Servico_X_PedidoItem y " +
                                                        "on x.nr_pedido = y.nr_pedido " +
                                                        "and x.cd_produto = y.cd_produto " +
                                                        "and x.id_pedidoitem = y.id_pedidoitem " +
                                                        "where x.cd_empresa = a.cd_empresa " +
                                                        "and x.nr_lanctofiscal = a.nr_lanctofiscal " +
                                                        "and y.tp_pedido = 'IT' " +
                                                        "and y.cd_empresa = '" + (bsOS.Current as TRegistro_LanServico).Cd_empresa.Trim() + "' " +
                                                        "and y.id_os = " + (bsOS.Current as TRegistro_LanServico).Id_osstr + ")"
                                        }
                                    }, "a.nr_notafiscal");
                        if (obj != null)
                        {
                            MessageBox.Show("Peças da ordem serviço ja foram faturadas. Nota Fiscal Nº" + obj.ToString(), "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        obj = new CamadaDados.Faturamento.PDV.TCD_NFCe().BuscarEscalar(
                                new TpBusca[]
                                {
                                    new TpBusca()
                                    {
                                        vNM_Campo = "isnull(a.st_registro, 'A')",
                                        vOperador = "<>",
                                        vVL_Busca = "'C'"
                                    },
                                    new TpBusca()
                                    {
                                        vNM_Campo = string.Empty,
                                        vOperador = "exists",
                                        vVL_Busca = "(select 1 from tb_ose_pecas_x_nfce x " +
                                                    "where x.cd_empresa = a.cd_empresa " +
                                                    "and x.id_cupom = a.id_cupom " +
                                                    "and x.cd_empresa = '" + (bsOS.Current as TRegistro_LanServico).Cd_empresa.Trim() + "' " +
                                                    "and x.id_os = " + (bsOS.Current as TRegistro_LanServico).Id_osstr + ")"
                                    }
                                }, "a.nr_nfce");
                        if (obj != null)
                        {
                            MessageBox.Show("Peças da ordem serviço ja foram faturadas. NFC-e Nº" + obj.ToString(), "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        try
                        {
                            CamadaDados.Faturamento.PDV.TRegistro_NFCe rNFCe = new PDV.TGerenciarCupom().GerarNFCe(bsOS.Current as TRegistro_LanServico);
                            if (rNFCe != null)
                                if (!rNFCe.St_contingencia)
                                    using (NFCe.TFGerenciarNFCe fGerNfe = new NFCe.TFGerenciarNFCe())
                                    {
                                        fGerNfe.rNFCe = CamadaNegocio.Faturamento.PDV.TCN_NFCe.BuscarNFCe(rNFCe.Cd_empresa,
                                                                                                          rNFCe.Id_nfcestr,
                                                                                                          null);
                                        fGerNfe.ShowDialog();
                                    }
                                else
                                {
                                    FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                                    Rel.Altera_Relatorio = Altera_Relatorio;
                                    BindingSource dts = new BindingSource();
                                    dts.DataSource = new CamadaDados.Faturamento.PDV.TList_NFCe_Item();
                                    Rel.DTS_Relatorio = dts;// bsItens;
                                    //DTS Cupom
                                    BindingSource bsNFCe = new BindingSource();
                                    bsNFCe.DataSource = CamadaNegocio.Faturamento.PDV.TCN_NFCe.Buscar(rNFCe.Id_nfcestr,
                                                                                                      string.Empty,
                                                                                                      rNFCe.Cd_empresa,
                                                                                                      string.Empty,
                                                                                                      string.Empty,
                                                                                                      string.Empty,
                                                                                                      string.Empty,
                                                                                                      decimal.Zero,
                                                                                                      decimal.Zero,
                                                                                                      string.Empty,
                                                                                                      string.Empty,
                                                                                                      string.Empty,
                                                                                                      string.Empty,
                                                                                                      false,
                                                                                                      string.Empty,
                                                                                                      string.Empty,
                                                                                                      1,
                                                                                                      null);
                                    (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).lItem =
                                        CamadaNegocio.Faturamento.PDV.TCN_NFCe_Item.Buscar((bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).Id_nfcestr,
                                                                                           (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).Cd_empresa,
                                                                                           string.Empty,
                                                                                           null);
                                    NFCe.TGerarQRCode.GerarQRCode2(bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe);
                                    Rel.Adiciona_DataSource("DTS_NFCE", bsNFCe);
                                    //Buscar Empresa
                                    BindingSource bsEmpresa = new BindingSource();
                                    bsEmpresa.DataSource = CamadaNegocio.Diversos.TCN_CadEmpresa.Busca(rNFCe.Cd_empresa,
                                                                                                        string.Empty,
                                                                                                        string.Empty,
                                                                                                        null);
                                    Rel.Adiciona_DataSource("DTS_EMP", bsEmpresa);
                                    //Forma Pagamento
                                    BindingSource bsPagto = new BindingSource();
                                    List<CamadaDados.Faturamento.PDV.TRegistro_MovCaixa> lPagto = new List<CamadaDados.Faturamento.PDV.TRegistro_MovCaixa>()
                                {
                                   new CamadaDados.Faturamento.PDV.TRegistro_MovCaixa()
                                   {
                                       Tp_portador = "05",
                                       Vl_recebido = (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).Vl_cupom
                                   }
                                };
                                    bsPagto.DataSource = lPagto;
                                    Rel.Adiciona_DataSource("DTS_PAGTO", bsPagto);
                                    //Parametros
                                    Rel.Parametros_Relatorio.Add("TOT_IMP_APROX", (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).lItem.Sum(p => p.Vl_imposto_Aprox));
                                    Rel.Parametros_Relatorio.Add("QTD_ITENS", (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).lItem.Count);
                                    Rel.Parametros_Relatorio.Add("TOT_SUBTOTAL", (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).lItem.Sum(p => p.Vl_subtotal));
                                    Rel.Parametros_Relatorio.Add("TOT_ACRESCIMO", (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).lItem.Sum(p => p.Vl_acrescimo));
                                    Rel.Parametros_Relatorio.Add("TOT_DESCONTO", (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).lItem.Sum(p => p.Vl_desconto));
                                    Rel.Parametros_Relatorio.Add("ST_VIAEMPRESA", "N");
                                    obj = new CamadaDados.Faturamento.NFCe.TCD_LoteNFCe().BuscarEscalar(
                                            new TpBusca[]
                                {
                                    new TpBusca()
                                    {
                                        vNM_Campo = string.Empty,
                                        vOperador = "exists",
                                        vVL_Busca = "(select 1 from TB_FAT_Lote_X_NFCe x " +
                                                    "where x.cd_empresa = a.cd_empresa " +
                                                    "and x.id_lote = a.id_lote " +
                                                    "and x.status = '100')"
                                    }
                                }, "a.tp_ambiente");
                                    Rel.Parametros_Relatorio.Add("TP_AMBIENTE", obj == null ? string.Empty : obj.ToString());
                                    Rel.Nome_Relatorio = "DANFE_NFCE";
                                    Rel.NM_Classe = "TFConsultaFrenteCaixa";
                                    Rel.Modulo = "FAT";
                                    Rel.Ident = "DANFE_NFCE";
                                    if (CamadaNegocio.ConfigGer.TCN_CadParamGer.BuscaVlBool("ST_IMP_DANFE_NFCE_DETALHADA", null))
                                    {
                                        BindingSource bsItens = new BindingSource();
                                        bsItens.DataSource = (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).lItem;
                                        Rel.DTS_Relatorio = bsItens;
                                    }
                                    if ((bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).Id_contingencia.HasValue)
                                        if (Rel.Parametros_Relatorio.ContainsKey("ST_VIAEMPRESA"))
                                            Rel.Parametros_Relatorio["ST_VIAEMPRESA"] = "S";
                                        else
                                            Rel.Parametros_Relatorio.Add("ST_VIAEMPRESA", "S");
                                    //Verificar se existe Impressora padrão para o PDV
                                    obj = new CamadaDados.Faturamento.Cadastros.TCD_PontoVenda().BuscarEscalar(
                                            new TpBusca[]
                                {
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.cd_terminal",
                                        vOperador = "=",
                                        vVL_Busca = "'" + Utils.Parametros.pubTerminal.Trim() + "'"
                                    }
                                }, "a.impressorapadrao");
                                    string print = obj == null ? string.Empty : obj.ToString();
                                    if (string.IsNullOrEmpty(print))
                                        using (Parametros.Diversos.TFListaImpressoras fLista = new Parametros.Diversos.TFListaImpressoras())
                                        {
                                            if (fLista.ShowDialog() == DialogResult.OK)
                                                if (!string.IsNullOrEmpty(fLista.Impressora))
                                                    print = fLista.Impressora;
                                        }
                                    //Imprimir
                                    if (!string.IsNullOrEmpty(print))
                                    {
                                        Rel.ImprimiGraficoReduzida(print,
                                                                   true,
                                                                   false,
                                                                   null,
                                                                   string.Empty,
                                                                   string.Empty,
                                                                   1);
                                        if ((bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).Id_contingencia.HasValue &&
                                            rNFCe.rCfgNFCe.Tp_ambiente_nfce.Equals(1))
                                            Rel.ImprimiGraficoReduzida(print,
                                                                       true,
                                                                       false,
                                                                       null,
                                                                       string.Empty,
                                                                       string.Empty,
                                                                       1);
                                    }
                                }
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    }
                }
                else MessageBox.Show("Permitido Faturar somente ordem serviço PROCESSADA.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void reimprimirConfissãoDividaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bsOS.Current != null)
                if ((bsOS.Current as TRegistro_LanServico).St_os.Trim().ToUpper().Equals("PR"))
                {
                    //Se gerou duplicata imprimir confissão divida
                    CamadaDados.Financeiro.Duplicata.TList_RegLanParcela lParc =
                        new CamadaDados.Financeiro.Duplicata.TCD_LanParcela().Select(
                        new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = string.Empty,
                                vOperador = "exists",
                                vVL_Busca = "(select 1 from TB_PDV_CupomFiscal_X_Duplicata x " +
                                            "inner join TB_PDV_PreVenda_X_VendaRapida y " +
                                            "on x.CD_Empresa = y.CD_Empresa " +
                                            "and x.Id_Cupom = y.Id_Cupom " +
                                            "inner join tb_ose_pecas_x_prevenda z " +
                                            "on y.cd_empresa = z.cd_empresa " +
                                            "and y.id_prevenda = z.id_prevenda " +
                                            "where x.cd_empresa = a.cd_empresa " +
                                            "and x.Nr_Lancto = a.Nr_Lancto " +
                                            "and z.cd_empresa = '" + (bsOS.Current as TRegistro_LanServico).Cd_empresa.Trim() + "' " +
                                            "and z.id_os = " + (bsOS.Current as TRegistro_LanServico).Id_osstr + ")"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = string.Empty,
                                vOperador = "not exists",
                                vVL_Busca = "(select 1 from TB_COB_Titulo x " +
                                            "where x.cd_empresa = a.cd_empresa " +
                                            "and x.nr_lancto = a.nr_lancto " +
                                            "and x.cd_parcela = a.cd_parcela " +
                                            "and isnull(x.st_registro, 'A') <> 'C')"
                            }
                        }, 1, string.Empty, "a.dt_vencto", string.Empty);
                    if (lParc.Count > 0)
                    {
                        FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                        BindingSource bs = new BindingSource();
                        bs.DataSource = new TList_LanServico() { bsOS.Current as TRegistro_LanServico };
                        Rel.DTS_Relatorio = bs;
                        //DTS Cupom
                        BindingSource dts = new BindingSource();
                        dts.DataSource = new CamadaDados.Faturamento.PDV.TCD_VendaRapida_Item().Select(
                                            new TpBusca[]
                                            {
                                                new TpBusca()
                                                {
                                                    vNM_Campo = "isnull(cf.st_registro, 'A')",
                                                    vOperador = "<>",
                                                    vVL_Busca = "'C'"
                                                },
                                                new TpBusca()
                                                {
                                                    vNM_Campo = string.Empty,
                                                    vOperador = "exists",
                                                    vVL_Busca = "(select 1 from tb_pdv_prevenda_x_vendarapida x " +
                                                                "inner join tb_ose_pecas_x_prevenda y " +
                                                                "on x.cd_empresa = y.cd_empresa " +
                                                                "and x.id_prevenda = y.id_prevenda " +
                                                                "and x.id_itemprevenda = y.id_itemprevenda " +
                                                                "where x.cd_empresa = a.cd_empresa " +
                                                                "and x.id_cupom = a.id_cupom " +
                                                                "and y.cd_empresa = '" + (bsOS.Current as TRegistro_LanServico).Cd_empresa.Trim() + "' " +
                                                                "and y.id_os = " + (bsOS.Current as TRegistro_LanServico).Id_osstr + ")"
                                                }
                                            }, 0, string.Empty, string.Empty);
                        Rel.Adiciona_DataSource("DTS_ITENS", dts);
                        //Buscar Empresa
                        BindingSource bsEmpresa = new BindingSource();
                        bsEmpresa.DataSource = CamadaNegocio.Diversos.TCN_CadEmpresa.Busca((bsOS.Current as TRegistro_LanServico).Cd_empresa,
                                                                                           string.Empty,
                                                                                           string.Empty,
                                                                                           null);
                        Rel.Adiciona_DataSource("DTS_EMP", bsEmpresa);
                        //Buscar Cliente Cupom 
                        if (string.IsNullOrEmpty((bsOS.Current as TRegistro_LanServico).Cd_clifor))
                        {
                            CamadaDados.Financeiro.Cadastros.TRegistro_CadClifor rClifor =
                                CamadaNegocio.Financeiro.Cadastros.TCN_CadClifor.Busca_Clifor_Codigo((bsOS.Current as TRegistro_LanServico).Cd_clifor, null);
                            Rel.Parametros_Relatorio.Add("NM_CLIENTE", rClifor.Nm_clifor);
                            Rel.Parametros_Relatorio.Add("CPF_CLIENTE", rClifor.Tp_pessoa.Trim().ToUpper().Equals("F") ? rClifor.Nr_cpf : rClifor.Nr_cgc);
                        }
                        else
                        {
                            Rel.Parametros_Relatorio.Add("NM_CLIENTE", (bsOS.Current as TRegistro_LanServico).Nm_clifor);
                            Rel.Parametros_Relatorio.Add("CPF_CLIENTE", (bsOS.Current as TRegistro_LanServico).Nr_cnpj_cpf);
                        }
                        if (string.IsNullOrEmpty((bsOS.Current as TRegistro_LanServico).Ds_endereco))
                        {
                            CamadaDados.Financeiro.Cadastros.TList_CadEndereco lEnd =
                            CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Buscar((bsOS.Current as TRegistro_LanServico).Cd_clifor,
                                                                                      (bsOS.Current as TRegistro_LanServico).Cd_endereco,
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
                            Rel.Parametros_Relatorio.Add("ENDERECO", lEnd[0].Ds_endereco.Trim() + ", " + lEnd[0].Numero.Trim() + ", " + lEnd[0].Bairro.Trim() + ", " + lEnd[0].DS_Cidade.Trim() + ", " + lEnd[0].UF.Trim());
                        }
                        else Rel.Parametros_Relatorio.Add("ENDERECO", (bsOS.Current as TRegistro_LanServico).Ds_endereco.Trim());
                        //Buscar Valor Pago
                        decimal vl_pago = decimal.Zero;
                        List<CamadaDados.Faturamento.PDV.TRegistro_MovCaixa> lPag = new CamadaDados.Faturamento.PDV.TCD_CaixaPDV().SelectMovCaixa(
                                                                                        new TpBusca[]
                                                                                        {
                                                                                            new TpBusca()
                                                                                            {
                                                                                                vNM_Campo = string.Empty,
                                                                                                vOperador = "exists",
                                                                                                vVL_Busca = "(select 1 from tb_pdv_prevenda_x_vendarapida x " +
                                                                                                            "inner join tb_ose_pecas_x_prevenda y " +
                                                                                                            "on x.cd_empresa = y.cd_empresa " +
                                                                                                            "and x.id_prevenda = y.id_prevenda " +
                                                                                                            "and x.id_itemprevenda = y.id_itemprevenda " +
                                                                                                            "where x.cd_empresa = a.cd_empresa " +
                                                                                                            "and x.id_cupom = a.id_cupom " +
                                                                                                            "and y.cd_empresa = '" + (bsOS.Current as TRegistro_LanServico).Cd_empresa.Trim() + "' " +
                                                                                                            "and y.id_os = " + (bsOS.Current as TRegistro_LanServico).Id_osstr + ")"
                                                                                            }
                                                                                        }, string.Empty);
                        if (lPag.Count > 0)
                            vl_pago = lPag.Sum(p => p.Vl_recebidoliq);
                        vl_pago += lParc.Sum(p => p.Vl_liquidado);
                        Rel.Parametros_Relatorio.Add("VL_PAGO", vl_pago);
                        Rel.Parametros_Relatorio.Add("VL_PAGAR", lParc.Sum(p => p.Vl_atual));
                        BindingSource bsParc = new BindingSource();
                        bsParc.DataSource = lParc;
                        Rel.Adiciona_DataSource("PARC", bsParc);
                        Rel.Nome_Relatorio = "CONFISSAO_DIVIDA_OS";
                        Rel.NM_Classe = "TFPainelOSOficina";
                        Rel.Modulo = "OSE";
                        Rel.Ident = "CONFISSAO_DIVIDA_OS";
                        //Verificar se existe Impressora padrão para o PDV
                        object obj = new CamadaDados.Faturamento.Cadastros.TCD_PontoVenda().BuscarEscalar(
                                        new TpBusca[]
                                        {
                                            new TpBusca()
                                            {
                                                vNM_Campo = "a.cd_terminal",
                                                vOperador = "=",
                                                vVL_Busca = "'" + Utils.Parametros.pubTerminal.Trim() + "'"
                                            }
                                        }, "a.impressorapadrao");
                        string print = obj == null ? string.Empty : obj.ToString();
                        if (string.IsNullOrEmpty(print))
                            using (Parametros.Diversos.TFListaImpressoras fLista = new Parametros.Diversos.TFListaImpressoras())
                            {
                                if (fLista.ShowDialog() == DialogResult.OK)
                                    if (!string.IsNullOrEmpty(fLista.Impressora))
                                        print = fLista.Impressora;

                            }
                        //Imprimir
                        Rel.ImprimiGraficoReduzida(print, !string.IsNullOrEmpty(print), string.IsNullOrEmpty(print), null, string.Empty, string.Empty, 1);
                    }
                    else MessageBox.Show("Não existe parcela disponivel para gerar confissão divida.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else MessageBox.Show("Permitido gerar confissão divida somente de OS PROCESSADA.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else MessageBox.Show("Necessario selecionar OS para imprimir confissão divida.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void excluirServicos_Click(object sender, EventArgs e)
        {
            afterExcluirPecas(true);
        }

        private void btn_Deleta_Pecas_Click(object sender, EventArgs e)
        {
            afterExcluirPecas(false);
        }

        private void btn_Insere_Pecas_Click(object sender, EventArgs e)
        {
            afterInserirPecas(false);
        }

        private void InserirServicos_Click(object sender, EventArgs e)
        {
            afterInserirPecas(true);
        }

        private void AlterarServicos_Click(object sender, EventArgs e)
        {
            afterAlterarPecas(true);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            afterAlterarPecas(false);
        }

        private void bbHistorico_Click(object sender, EventArgs e)
        {
            afterInserirHistorico();
        }

        private void bb_inserirfotos_Click(object sender, EventArgs e)
        {
            afterInserirFoto();
        }

        private void bb_excluirfotos_Click(object sender, EventArgs e)
        {
            afterExcluirFoto();
        }

        private void bbCorrigir_Click(object sender, EventArgs e)
        {
            CorrigirOS();
        }
    }
}
