using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using CamadaDados.Servicos;

namespace Servicos
{
    public partial class TFLanOSTarefa : Form
    {
        private bool Altera_Relatorio = false;

        public TFLanOSTarefa()
        {
            InitializeComponent();
        }

        private void LimparFiltros()
        {
            id_os.Clear();
            CD_Empresa.Clear();
            id_tecnico.Clear();
            CD_Clifor.Clear();
            DT_Final.Clear();
            DT_Inic.Clear();
            cck_Todas.Checked = true;
            ST_OS_Aberta.Checked = false;
            ST_OS_Fechada.Checked = false;
        }

        private void afterNovo()
        {
            using (TFAbrirOSTarefa fOs = new TFAbrirOSTarefa())
            {
                if (fOs.ShowDialog() == DialogResult.OK)
                    if (fOs.rOS != null)
                        try
                        {
                            //Buscar etapa de abertura da OS
                            CamadaDados.Servicos.Cadastros.TList_EtapaOrdem lEtapa =
                            new CamadaDados.Servicos.Cadastros.TCD_EtapaOrdem().Select(
                                new Utils.TpBusca[]
                            {
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = string.Empty,
                                    vOperador = "exists",
                                    vVL_Busca = "(select 1 from tb_ose_tpordem_x_etapa x "+
                                                "where x.id_etapa = a.id_etapa "+
                                                "and x.tp_ordem = " + fOs.rOS.Tp_ordemstr + ")"
                                }
                            }, 0, string.Empty);
                            if (lEtapa.Count > 0)
                            {
                                lEtapa.ForEach(p=> 
                                    {
                                        //Buscar Ordem Etapa do Tipo de Ordem
                                        object obj = new CamadaDados.Servicos.Cadastros.TCD_TpOrdem_X_Etapa().BuscarEscalar(
                                                        new Utils.TpBusca[]
                                                        {
                                                            new Utils.TpBusca()
                                                            {
                                                                vNM_Campo = "a.id_etapa",
                                                                vOperador = "=",
                                                                vVL_Busca = p.Id_etapastr
                                                            },
                                                            new Utils.TpBusca()
                                                            {
                                                                vNM_Campo = "a.TP_Ordem",
                                                                vOperador = "=",
                                                                vVL_Busca = fOs.rOS.Tp_ordemstr                                    }
                                                        }, "a.Ordem");
                                        if (!string.IsNullOrEmpty(obj.ToString()))
                                            p.Ordem = Convert.ToDecimal(obj);
                                        else
                                            p.Ordem = fOs.rOS.lEvolucao.Count + 1;

                                        fOs.rOS.lEvolucao.Add(
                                            new CamadaDados.Servicos.TRegistro_LanServicoEvolucao()
                                            {
                                                Dt_inicio = fOs.rOS.Dt_abertura,
                                                Id_etapa = p.Id_etapa,
                                                Ds_evolucao = p.Ds_etapa,
                                                Ordem = p.Ordem,
                                                St_envterceiro = p.St_envterceirobool,
                                                St_finalizarOS = p.St_finalizarOSbool,
                                                St_iniciarOS = p.St_iniciarOSbool
                                            });
                                    });
                            }
                            CamadaNegocio.Servicos.TCN_LanServico.Gravar(fOs.rOS, null);
                            MessageBox.Show("PROJETO Nº" + fOs.rOS.Id_osstr + " gravado com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.LimparFiltros();
                            id_os.Text = fOs.rOS.Id_osstr;
                            CD_Empresa.Text = fOs.rOS.Cd_empresa;
                            this.afterBusca();
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
                    MessageBox.Show("Não é permitido alterar PROJETO CANCELADO!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if ((bsOS.Current as CamadaDados.Servicos.TRegistro_LanServico).St_os.Trim().ToUpper().Equals("PR"))
                {
                    MessageBox.Show("Não é permitido alterar PROJETO PROCESSADO!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                using (TFEvoluirOSTarefa fEvoluir = new TFEvoluirOSTarefa())
                {
                    fEvoluir.rOS = bsOS.Current as CamadaDados.Servicos.TRegistro_LanServico;
                    if (fEvoluir.ShowDialog() == DialogResult.OK)
                        try
                        {
                            CamadaNegocio.Servicos.TCN_LanServico.Gravar(fEvoluir.rOS, null);
                            bsOS.ResetCurrentItem();
                            MessageBox.Show("Projeto Nº " + fEvoluir.rOS.Id_osstr + " alterado com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    this.LimparFiltros();
                    id_os.Text = fEvoluir.rOS.Id_osstr;
                    this.afterBusca();
                }
            }
        }

        private void afterPrint()
        {
            if (bsOS.Current != null)
            {
                using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
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
                    Rel.Nome_Relatorio = "FLan_OSTarefa";
                    Rel.NM_Classe = this.Name;
                    Rel.Modulo = string.Empty;
                    Rel.Ident = "FLan_OSTarefa";
                    fImp.St_enabled_enviaremail = true;
                    fImp.pCd_clifor = (bsOS.Current as CamadaDados.Servicos.TRegistro_LanServico).Cd_clifor;
                    fImp.pMensagem = "PROJETO";

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
                                           "PROJETO",
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
                                               "PROJETO",
                                               fImp.pDs_mensagem);
                }
            }
        }

        private void afterPrintDescritivo()
        {
            if (bsOS.Current != null)
            {
                using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
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
                    Rel.Nome_Relatorio = "FLan_OSTarefa_Descritivo";
                    Rel.NM_Classe = this.Name;
                    Rel.Modulo = string.Empty;
                    Rel.Ident = "FLan_OSTarefa_Descritivo";
                    fImp.St_enabled_enviaremail = true;
                    fImp.pCd_clifor = (bsOS.Current as CamadaDados.Servicos.TRegistro_LanServico).Cd_clifor;
                    fImp.pMensagem = "PROJETO";

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
                                           "PROJETO",
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
                                               "PROJETO",
                                               fImp.pDs_mensagem);
                }
            }
        }

        private void afterBusca()
        {
            int position = bsEvolucao.Position;

            string status = string.Empty;
            string virg = string.Empty;
            if (ST_OS_Aberta.Checked)
            {
                status = "'AB'";
                virg = ",";
            }
            if (ST_OS_Fechada.Checked)
                status += virg + "'FE'";

            bsOS.DataSource = CamadaNegocio.Servicos.TCN_LanServico.Buscar(string.Empty,
                                                                           CD_Empresa.Text,
                                                                           CD_Clifor.Text,
                                                                           string.Empty,
                                                                           string.Empty,
                                                                           string.Empty,
                                                                           string.Empty,
                                                                           id_os.Text,
                                                                           ds_servico.Text,
                                                                           origem.Text,
                                                                           id_tecnico.Text,
                                                                           string.Empty,
                                                                           id_etapa.Text,
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
                                                                           false,
                                                                           false,
                                                                           0,
                                                                           string.Empty,
                                                                           string.Empty,
                                                                           null);
            bsOS_PositionChanged(this, new EventArgs());
            bsOS.ResetCurrentItem();
            bsEvolucao.Position = position;
        }

        private void afterExclui()
        {
            if (bsOS.Current != null)
            {
                if ((bsOS.Current as CamadaDados.Servicos.TRegistro_LanServico).St_os.Trim().ToUpper().Equals("CA"))
                {
                    MessageBox.Show("PROJETO ja se encontra cancelado!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if ((bsOS.Current as CamadaDados.Servicos.TRegistro_LanServico).St_os.Trim().ToUpper().Equals("AB") ||
                    (bsOS.Current as CamadaDados.Servicos.TRegistro_LanServico).St_os.Trim().ToUpper().Equals("FE"))
                {
                    if (MessageBox.Show("Confirma exclusão do PROJETO Nº" + (bsOS.Current as CamadaDados.Servicos.TRegistro_LanServico).Id_osstr + "?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                        == DialogResult.Yes)
                    {
                        try
                        {
                            CamadaNegocio.Servicos.TCN_LanServico.cancelar((bsOS.Current as CamadaDados.Servicos.TRegistro_LanServico), null);
                            MessageBox.Show("Projeto cancelado com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.afterBusca();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                    }
                }
                else
                    MessageBox.Show("Permitido cancelar somente PROJETO com status <ABERTA> ou <FINALIZADA>.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Obrigatorio informar PROJETO para cancelar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void GerarDup()
        {          
            if (bsOS.Current != null)
            {
                if ((bsOS.Current as CamadaDados.Servicos.TRegistro_LanServico).St_os.Trim().ToUpper().Equals("CA"))
                {
                    MessageBox.Show("Não é possivel Gerar Duplicata em Projeto CANCELADO!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (!((bsOS.Current as CamadaDados.Servicos.TRegistro_LanServico).lPecas.Sum(p => p.Vl_SubTotalLiq) > 0))
                {
                    MessageBox.Show("Não existe Valor para gerar Duplicata!\r\nNecessário inserir um SERVIÇO para o Projeto!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                //Buscar CFG TP.Ordem
                CamadaDados.Servicos.Cadastros.TList_OSE_ParamOS lParam =
                    CamadaNegocio.Servicos.Cadastros.TCN_OSE_ParamOS.Buscar((bsOS.Current as CamadaDados.Servicos.TRegistro_LanServico).Tp_ordemstr,
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
                if (!(bsOS.Current as CamadaDados.Servicos.TRegistro_LanServico).St_os.Trim().ToUpper().Equals("CA"))
                {

                    if (new CamadaDados.Servicos.TCD_LanServico().BuscarEscalar(
                        new Utils.TpBusca[]
                    {
                        new Utils.TpBusca()
                        {
                            vNM_Campo = string.Empty,
                            vOperador = "exists",
                            vVL_Busca = "(select 1 from TB_OSE_Duplicata x " +
                                        "inner join TB_FIN_Duplicata y " +
                                        "on x.nr_lancto = y.nr_lancto " +
                                        "where isnull(y.st_registro, 'C') = 'A' " +
                                        "and x.cd_empresa = a.cd_empresa " +
                                        "and x.id_os = '" + (bsOS.Current as CamadaDados.Servicos.TRegistro_LanServico).Id_os + "')"
                        }
                    }, "1") == null)
                    {
                        using (Financeiro.TFLanDuplicata fDuplicata = new Financeiro.TFLanDuplicata())
                        {
                            fDuplicata.vCd_empresa = (bsOS.Current as CamadaDados.Servicos.TRegistro_LanServico).Cd_empresa;
                            fDuplicata.vNm_empresa = (bsOS.Current as CamadaDados.Servicos.TRegistro_LanServico).Nm_empresa;
                            fDuplicata.vCd_clifor = (bsOS.Current as CamadaDados.Servicos.TRegistro_LanServico).Cd_clifor;
                            fDuplicata.vNm_clifor = (bsOS.Current as CamadaDados.Servicos.TRegistro_LanServico).Nm_clifor;
                            fDuplicata.vCd_endereco = (bsOS.Current as CamadaDados.Servicos.TRegistro_LanServico).Cd_endereco;
                            fDuplicata.vDs_endereco = (bsOS.Current as CamadaDados.Servicos.TRegistro_LanServico).Ds_endereco;
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
                                fDuplicata.vVl_documento = (bsOS.Current as CamadaDados.Servicos.TRegistro_LanServico).Vl_subtotalLiq;
                                fDuplicata.vDt_emissao = CamadaDados.UtilData.Data_Servidor().ToString("dd/MM/yyyy");
                                fDuplicata.vNr_docto = "PROJ" + (bsOS.Current as CamadaDados.Servicos.TRegistro_LanServico).Id_osstr;
                            }
                            if (fDuplicata.ShowDialog() == DialogResult.OK)
                            {
                                try
                                {
                                    (bsOS.Current as CamadaDados.Servicos.TRegistro_LanServico).lDup.Add(
                                                            fDuplicata.dsDuplicata.Current as CamadaDados.Financeiro.Duplicata.TRegistro_LanDuplicata);
                                    CamadaNegocio.Servicos.TCN_LanServico.GravaDuplicata(bsOS.Current as CamadaDados.Servicos.TRegistro_LanServico, null);
                                    this.afterBusca();
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
                    else
                    {
                        MessageBox.Show("Não é possivel Gerar Financeiro! Projeto já possui Duplicata Aberta!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Não é possivel Gerar Duplicata em Projeto Cancelado!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
        }

        private void FinalizarTarefa()
        {
            if (bsAtividade.Current != null)
            {
                if ((bsAtividade.Current as TRegistro_LanAtividades).St_registro.ToUpper().Equals("C"))
                {
                    MessageBox.Show("Não é possivel finalizar atividade CONCLUIDA!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                try
                {
                    if (MessageBox.Show("Confirma a conclusão da Atividade Nº " + (bsAtividade.Current as TRegistro_LanAtividades).Id_atividadestr + "?",
                        "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        //Inserir QTD Horas Trabalhadas
                        using (Componentes.TFHoras fQtde = new Componentes.TFHoras())
                        {
                            fQtde.Ds_label = "Horas Trabalhadas";
                            if (fQtde.ShowDialog() == DialogResult.OK)
                            {
                                if (!string.IsNullOrEmpty(fQtde.pHoras))
                                    (bsAtividade.Current as TRegistro_LanAtividades).Horas_trabalhadas = Convert.ToDecimal(fQtde.pHoras.Replace(":", ","));
                            }
                        }
                        //Gravar Finalização
                        (bsAtividade.Current as TRegistro_LanAtividades).St_registro = "C";
                        (bsAtividade.Current as TRegistro_LanAtividades).Dt_Conclusao = CamadaDados.UtilData.Data_Servidor();
                        CamadaNegocio.Servicos.TCN_LanServico.FinalizarAtividade(bsOS.Current as TRegistro_LanServico, null);
                        this.afterBusca();
                    }
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void InserirTarefa()
        {
            if (bsEvolucao.Current != null)
            {
                using (TFTarefa fTarefa = new TFTarefa())
                {
                    if (fTarefa.ShowDialog() == DialogResult.OK)
                        if (fTarefa.rAtividade != null)
                            try
                            {
                                fTarefa.rAtividade.St_registro = "P";
                                (bsEvolucao.Current as TRegistro_LanServicoEvolucao).St_evolucao = "A";
                                (bsEvolucao.Current as TRegistro_LanServicoEvolucao).Dt_final = null;
                                (bsEvolucao.Current as CamadaDados.Servicos.TRegistro_LanServicoEvolucao).lAtividade.Add(fTarefa.rAtividade);
                                CamadaNegocio.Servicos.TCN_LanServicoEvolucao.Gravar(bsEvolucao.Current as CamadaDados.Servicos.TRegistro_LanServicoEvolucao, null);
                                MessageBox.Show("Atividade gravada com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                if (!(bsOS.Current as TRegistro_LanServico).St_os.ToUpper().Equals("AB"))
                                {
                                    (bsOS.Current as CamadaDados.Servicos.TRegistro_LanServico).St_os = "AB";
                                    (bsOS.Current as CamadaDados.Servicos.TRegistro_LanServico).Dt_finalizada = null;
                                    CamadaNegocio.Servicos.TCN_LanServico.Gravar(bsOS.Current as CamadaDados.Servicos.TRegistro_LanServico, null);
                                }
                                this.afterBusca();
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            }
        }

        private void AlterarTarefa()
        {
            if (bsAtividade.Current != null)
            {
                if ((bsAtividade.Current as TRegistro_LanAtividades).St_registro.ToUpper().Equals("C"))
                {
                    (bsAtividade.Current as TRegistro_LanAtividades).St_registro = "P";
                    (bsAtividade.Current as TRegistro_LanAtividades).Dt_Conclusao = null;
                    CamadaNegocio.Servicos.TCN_LanServico.ReabrirAtividade(bsOS.Current as TRegistro_LanServico, null);
                }
                using (TFTarefa fTarefa = new TFTarefa())
                {
                    fTarefa.rAtividade = (bsAtividade.Current as TRegistro_LanAtividades);
                    if (fTarefa.ShowDialog() == DialogResult.OK)
                        if (fTarefa.rAtividade != null)
                            try
                            {
                                (bsEvolucao.Current as CamadaDados.Servicos.TRegistro_LanServicoEvolucao).lAtividade.Add(fTarefa.rAtividade);
                                CamadaNegocio.Servicos.TCN_LanServicoEvolucao.Gravar(bsEvolucao.Current as TRegistro_LanServicoEvolucao, null);
                                MessageBox.Show("Atividade Alterada com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.afterBusca();
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            }
        }

        private void ExcluirTarefa()
        {
            if (bsAtividade.Current != null)
            {
                if ((bsAtividade.Current as TRegistro_LanAtividades).St_registro.ToUpper().Equals("C"))
                {
                    MessageBox.Show("Não é possivel excluir atividade CONCLUIDA!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (MessageBox.Show("Confirma exclusão da Atividade Nº" + (bsAtividade.Current as TRegistro_LanAtividades).Id_atividadestr + "?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    == DialogResult.Yes)
                    try
                    {
                        (bsEvolucao.Current as TRegistro_LanServicoEvolucao).lAtividadeDel.Add((bsAtividade.Current as TRegistro_LanAtividades));
                        bsAtividade.RemoveCurrent();
                        CamadaNegocio.Servicos.TCN_LanServicoEvolucao.Gravar((bsEvolucao.Current as TRegistro_LanServicoEvolucao), null);
                        MessageBox.Show("Atividade excluida com Sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.afterBusca();
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            }
        }

        private void ImageShow()
        {
            if (bsImagens.Current != null)
            {
                if ((bsImagens.Current as CamadaDados.Servicos.Cadastros.TRegistro_Imagens).Foto_imagem != null)
                {
                    //Criar Form
                    Form fImagem = new Form();
                    fImagem.Size = new Size(1040, 720);
                    fImagem.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                    fImagem.ShowInTaskbar = false;
                    fImagem.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
                    fImagem.MinimizeBox = false;
                    fImagem.FormBorderStyle = FormBorderStyle.Fixed3D;
                    fImagem.Text = "Visualizador de IMAGENS -  Aliance.Net";

                    //Criar Panel
                    Panel panel = new Panel();
                    panel.Dock = DockStyle.Fill;
                    //Criar PictureBox
                    PictureBox img = new PictureBox();
                    this.bindingNavigator3.Dock = System.Windows.Forms.DockStyle.Bottom;
                    bindingNavigator3.BindingSource = this.bsImagens;
                    fImagem.Controls.Add(panel);
                    panel.Controls.Add(img);
                    panel.Controls.Add(this.bindingNavigator3);
                    img.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                    img.Dock = DockStyle.Fill;
                    img.SizeMode = PictureBoxSizeMode.StretchImage;
                    img.DataBindings.Add(new System.Windows.Forms.Binding("Image", this.bsImagens, "Foto_imagem", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
                    fImagem.ShowDialog();
                }
                else
                    try { System.Diagnostics.Process.Start((bsImagens.Current as CamadaDados.Servicos.Cadastros.TRegistro_Imagens).Ds_imagem.Trim()); }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.Trim(),"Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
            }
        }

        private void InserirPath()
        {
            try
            {
                using (FolderBrowserDialog fFile = new FolderBrowserDialog())
                {
                    if (fFile.ShowDialog() == DialogResult.OK)
                        if (!string.IsNullOrEmpty(fFile.SelectedPath))
                        {
                            (bsOS.Current as CamadaDados.Servicos.TRegistro_LanServico).lImagens.Add(new CamadaDados.Servicos.Cadastros.TRegistro_Imagens()
                            {
                                Id_osstr = (bsOS.Current as CamadaDados.Servicos.TRegistro_LanServico).Id_osstr,
                                Cd_empresa = (bsOS.Current as CamadaDados.Servicos.TRegistro_LanServico).Cd_empresa,
                                Ds_imagem = fFile.SelectedPath.Trim()
                            });

                            //Gravar OS
                            CamadaNegocio.Servicos.TCN_LanServico.Gravar(bsOS.Current as CamadaDados.Servicos.TRegistro_LanServico, null);
                            MessageBox.Show("Path Anexo gravado com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            bsOS.ResetCurrentItem();
                        }
                }
            }
            catch (Exception ex)
            { MessageBox.Show("Erro localizar anexo: " + ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void ExcluirAnexo()
        {
            if (bsOS.Current != null)
            {
                if (bsImagens.Current == null)
                {
                    MessageBox.Show("Obrigatorio selecionar imagem para excluir!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (MessageBox.Show("Imagem selecionada: " + (bsImagens.Current as CamadaDados.Servicos.Cadastros.TRegistro_Imagens).Id_imagemstr.Trim() + "-" +
                                                                (bsImagens.Current as CamadaDados.Servicos.Cadastros.TRegistro_Imagens).Ds_imagem.Trim() +
                                    "\r\n\r\nConfirma exclusão?", "Pergunta", MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    //Adicionar item na lista a ser excluido
                    (bsOS.Current as CamadaDados.Servicos.TRegistro_LanServico).lImagensDel.Add(
                        bsImagens.Current as CamadaDados.Servicos.Cadastros.TRegistro_Imagens);
                    //Excluir item do grid
                    (bsOS.Current as CamadaDados.Servicos.TRegistro_LanServico).lImagens.Remove(
                        bsImagens.Current as CamadaDados.Servicos.Cadastros.TRegistro_Imagens);

                    //Gravar OS
                    CamadaNegocio.Servicos.TCN_LanServico.Gravar(bsOS.Current as CamadaDados.Servicos.TRegistro_LanServico, null);
                    bsOS.ResetCurrentItem();
                    MessageBox.Show("Anexo excluído com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void VisualizarLocalizacao()
        {
            if (bsOS.Current != null)
            {
                //Buscar Endereço
                CamadaDados.Financeiro.Cadastros.TList_CadEndereco lEnd =
                    new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco().Select(
                new Utils.TpBusca[]
            {
                new Utils.TpBusca()
                {
                    vNM_Campo = "a.cd_clifor",
                    vOperador = "=",
                    vVL_Busca = "'" + (bsOS.Current as CamadaDados.Servicos.TRegistro_LanServico).Cd_clifor.Trim() + "'"
                },
                new Utils.TpBusca()
                {
                    vNM_Campo = "a.cd_endereco",
                    vOperador = "=",
                    vVL_Busca = "'" + (bsOS.Current as CamadaDados.Servicos.TRegistro_LanServico).Cd_endereco.Trim() + "'"
                }
            }, 1, string.Empty);

                string location = string.Empty;
                if (lEnd.Count > 0 && !string.IsNullOrEmpty(lEnd[0].Latitude) && !string.IsNullOrEmpty(lEnd[0].Longitude))
                {
                    location = lEnd[0].Latitude + "," + lEnd[0].Longitude;
                    //Criar Componentes
                    Form fMap = new Form();
                    fMap.Text = "Google Maps";
                    fMap.Icon = this.Icon;
                    fMap.WindowState = FormWindowState.Maximized;
                    fMap.StartPosition = FormStartPosition.CenterScreen;
                    Panel panel = new Panel();
                    panel.Dock = DockStyle.Fill;
                    WebBrowser map = new WebBrowser();
                    map.Dock = DockStyle.Fill;
                    fMap.Controls.Add(panel);
                    panel.Controls.Add(map);
                    map.Url = new Uri("https://maps.google.com/maps?saddr=" + location + "&output");
                    fMap.ShowDialog();
                }
                else
                    MessageBox.Show("Obrigatório cadastrar latitude e longitude para visualizar a localização!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }          
        }

        private void afterInserirPecas(bool st_servico)
        {
            if (bsOS.Current != null)
            {
                using (TFLan_Pecas_Ordem_Servico fPecas = new TFLan_Pecas_Ordem_Servico())
                {
                    fPecas.CD_Empresa = (bsOS.Current as CamadaDados.Servicos.TRegistro_LanServico).Cd_empresa;
                    fPecas.Nm_empresa = (bsOS.Current as CamadaDados.Servicos.TRegistro_LanServico).Nm_empresa;
                    fPecas.CD_TabelaPreco =  (bsOS.Current as CamadaDados.Servicos.TRegistro_LanServico).Cd_tabelapreco;
                    fPecas.St_garantia = false;
                    fPecas.pSt_servico = st_servico;
                    if (st_servico && (bsOS.Current as CamadaDados.Servicos.TRegistro_LanServico).lPecas.Exists(p => !string.IsNullOrEmpty(p.Cd_tecnico) && p.St_servicobool))
                    {
                        fPecas.Cd_tecnico = (bsOS.Current as CamadaDados.Servicos.TRegistro_LanServico).lPecas.LastOrDefault(p => !string.IsNullOrEmpty(p.Cd_tecnico) && p.St_servicobool).Cd_tecnico;
                        fPecas.Nm_tecnico = (bsOS.Current as CamadaDados.Servicos.TRegistro_LanServico).lPecas.LastOrDefault(p => !string.IsNullOrEmpty(p.Cd_tecnico) && p.St_servicobool).Nm_tecnico;
                    }
                    else if (!st_servico && (bsOS.Current as CamadaDados.Servicos.TRegistro_LanServico).lPecas.Exists(p => !string.IsNullOrEmpty(p.Cd_tecnico) && p.St_servicobool == false))
                    {
                        fPecas.Cd_tecnico = (bsOS.Current as CamadaDados.Servicos.TRegistro_LanServico).lPecas.LastOrDefault(p => !string.IsNullOrEmpty(p.Cd_tecnico) && p.St_servicobool == false).Cd_tecnico;
                        fPecas.Nm_tecnico = (bsOS.Current as CamadaDados.Servicos.TRegistro_LanServico).lPecas.LastOrDefault(p => !string.IsNullOrEmpty(p.Cd_tecnico) && p.St_servicobool == false).Nm_tecnico;
                    }
                    if (fPecas.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            //Inserir novo registro
                            fPecas.rPeca.Cd_empresa = (bsOS.Current as CamadaDados.Servicos.TRegistro_LanServico).Cd_empresa;
                            fPecas.rPeca.Id_osstr = (bsOS.Current as CamadaDados.Servicos.TRegistro_LanServico).Id_osstr;
                            (bsOS.Current as CamadaDados.Servicos.TRegistro_LanServico).lPecas.Add(fPecas.rPeca);
                            CamadaNegocio.Servicos.TCN_LanServicoPecas.Gravar(fPecas.rPeca, null);
                            this.TotalizarPecasServicos();
                            bsOS_PositionChanged(this, new EventArgs());
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
                if (!st_servico && BS_Pecas.Current == null)
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
                    fPeca.CD_Empresa = CD_Empresa.Text;
                    fPeca.Nm_empresa = (bsOS.Current as CamadaDados.Servicos.TRegistro_LanServico).Nm_empresa;
                    fPeca.CD_TabelaPreco = (bsOS.Current as CamadaDados.Servicos.TRegistro_LanServico).Cd_tabelapreco;
                    fPeca.St_alterar = true;
                    fPeca.pSt_servico = st_servico;
                    CamadaDados.Servicos.TRegistro_LanServicosPecas rPeca = new CamadaDados.Servicos.TRegistro_LanServicosPecas();
                    if (!st_servico)
                    {
                        fPeca.rPeca = BS_Pecas.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas;
                        rPeca.Cd_produto = (BS_Pecas.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas).Cd_produto;
                        rPeca.Ds_produto = (BS_Pecas.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas).Ds_produto;
                        rPeca.Ds_unidproduto = (BS_Pecas.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas).Ds_unidproduto;
                        rPeca.Sigla_unidproduto = (BS_Pecas.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas).Sigla_unidproduto;
                        rPeca.Cd_local = (BS_Pecas.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas).Cd_local;
                        rPeca.Ds_local = (BS_Pecas.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas).Ds_local;
                        rPeca.Id_evolucao = (BS_Pecas.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas).Id_evolucao;
                        rPeca.Ds_observacao = (BS_Pecas.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas).Ds_observacao;
                        rPeca.Quantidade = (BS_Pecas.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas).Quantidade;
                        rPeca.Vl_desconto = (BS_Pecas.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas).Vl_desconto;
                        rPeca.Vl_acrescimo = (BS_Pecas.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas).Vl_acrescimo;
                        rPeca.Vl_subtotal = (BS_Pecas.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas).Vl_subtotal;
                        rPeca.Vl_SubTotalLiq = (BS_Pecas.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas).Vl_SubTotalLiq;
                        rPeca.Vl_unitario = (BS_Pecas.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas).Vl_unitario;
                        rPeca.St_atendimentogarantiabool = (BS_Pecas.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas).St_atendimentogarantiabool;
                    }
                    else
                    {
                        fPeca.rPeca = (bsServico.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas);
                        rPeca.Cd_produto = (bsServico.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas).Cd_produto;
                        rPeca.Ds_produto = (bsServico.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas).Ds_produto;
                        rPeca.Ds_unidproduto = (bsServico.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas).Ds_unidproduto;
                        rPeca.Sigla_unidproduto = (bsServico.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas).Sigla_unidproduto;
                        rPeca.Cd_local = (bsServico.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas).Cd_local;
                        rPeca.Ds_local = (bsServico.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas).Ds_local;
                        rPeca.Id_evolucao = (bsServico.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas).Id_evolucao;
                        rPeca.Ds_observacao = (bsServico.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas).Ds_observacao;
                        rPeca.Quantidade = (bsServico.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas).Quantidade;
                        rPeca.Vl_desconto = (bsServico.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas).Vl_desconto;
                        rPeca.Vl_acrescimo = (bsServico.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas).Vl_acrescimo;
                        rPeca.Vl_subtotal = (bsServico.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas).Vl_subtotal;
                        rPeca.Vl_SubTotalLiq = (bsServico.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas).Vl_SubTotalLiq;
                        rPeca.Vl_unitario = (bsServico.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas).Vl_unitario;
                        rPeca.St_atendimentogarantiabool = (bsServico.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas).St_atendimentogarantiabool;
                    }
                    if (fPeca.ShowDialog() != DialogResult.OK)
                    {
                        if (!st_servico)
                        {
                            (BS_Pecas.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas).Cd_produto = rPeca.Cd_produto;
                            (BS_Pecas.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas).Ds_produto = rPeca.Ds_produto;
                            (BS_Pecas.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas).Ds_unidproduto = rPeca.Ds_unidproduto;
                            (BS_Pecas.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas).Sigla_unidproduto = rPeca.Sigla_unidproduto;
                            (BS_Pecas.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas).Cd_local = rPeca.Cd_local;
                            (BS_Pecas.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas).Ds_local = rPeca.Ds_local;
                            (BS_Pecas.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas).Id_evolucao = rPeca.Id_evolucao;
                            (BS_Pecas.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas).Ds_observacao = rPeca.Ds_observacao;
                            (BS_Pecas.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas).Quantidade = rPeca.Quantidade;
                            (BS_Pecas.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas).Vl_desconto = rPeca.Vl_desconto;
                            (BS_Pecas.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas).Vl_acrescimo = rPeca.Vl_acrescimo;
                            (BS_Pecas.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas).Vl_subtotal = rPeca.Vl_subtotal;
                            (BS_Pecas.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas).Vl_SubTotalLiq = rPeca.Vl_SubTotalLiq;
                            (BS_Pecas.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas).Vl_unitario = rPeca.Vl_unitario;
                            (BS_Pecas.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas).St_atendimentogarantiabool = rPeca.St_atendimentogarantiabool;
                        }
                        else
                        {
                            (bsServico.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas).Cd_produto = rPeca.Cd_produto;
                            (bsServico.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas).Ds_produto = rPeca.Ds_produto;
                            (bsServico.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas).Ds_unidproduto = rPeca.Ds_unidproduto;
                            (bsServico.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas).Sigla_unidproduto = rPeca.Sigla_unidproduto;
                            (bsServico.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas).Cd_local = rPeca.Cd_local;
                            (bsServico.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas).Ds_local = rPeca.Ds_local;
                            (bsServico.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas).Id_evolucao = rPeca.Id_evolucao;
                            (bsServico.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas).Ds_observacao = rPeca.Ds_observacao;
                            (bsServico.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas).Quantidade = rPeca.Quantidade;
                            (bsServico.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas).Vl_desconto = rPeca.Vl_desconto;
                            (bsServico.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas).Vl_acrescimo = rPeca.Vl_acrescimo;
                            (bsServico.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas).Vl_subtotal = rPeca.Vl_subtotal;
                            (bsServico.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas).Vl_SubTotalLiq = rPeca.Vl_SubTotalLiq;
                            (bsServico.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas).Vl_unitario = rPeca.Vl_unitario;
                            (bsServico.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas).St_atendimentogarantiabool = rPeca.St_atendimentogarantiabool;
                        }
                    }
                    try
                    {
                        if (!st_servico)
                        {
                            CamadaNegocio.Servicos.TCN_LanServicoPecas.Gravar(BS_Pecas.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas, null);
                            this.TotalizarPecasServicos();
                            BS_Pecas.ResetCurrentItem();
                        }
                        else
                        {
                            CamadaNegocio.Servicos.TCN_LanServicoPecas.Gravar(bsServico.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas, null);
                            this.TotalizarPecasServicos();
                            bsServico.ResetCurrentItem();
                        }
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            }
            else
                MessageBox.Show("Não existe peça(serviço) selecionado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void afterExcluirPecas(bool st_servico)
        {
            if (bsOS.Current != null)
            {
                if (!st_servico)
                {
                    if (BS_Pecas.Current == null)
                    {
                        MessageBox.Show("Obrigatorio selecionar peça para excluir.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if (MessageBox.Show("Peça/serviço selecionado: " + (BS_Pecas.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas).Cd_produto.Trim() + "-" +
                                                                    (BS_Pecas.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas).Ds_produto.Trim() +
                                        "\r\n\r\nConfirma exclusão?", "Pergunta", MessageBoxButtons.YesNo,
                                        MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    try
                    {
                        //Adicionar item na lista a ser excluido
                        CamadaNegocio.Servicos.TCN_LanServicoPecas.Excluir(BS_Pecas.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas, null);
                        bsOS_PositionChanged(this, new EventArgs());
                        this.TotalizarPecasServicos();
                    }
                        catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
                else
                {
                    if (bsServico.Current == null)
                    {
                        MessageBox.Show("Obrigatorio selecionar serviço para excluir.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if (MessageBox.Show("Peça/serviço selecionado: " + (bsServico.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas).Cd_produto.Trim() + "-" +
                                                                    (bsServico.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas).Ds_produto.Trim() +
                                        "\r\n\r\nConfirma exclusão?", "Pergunta", MessageBoxButtons.YesNo,
                                        MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    try
                    {
                        //Adicionar item na lista a ser excluido
                        CamadaNegocio.Servicos.TCN_LanServicoPecas.Excluir(bsServico.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas, null);
                        bsOS_PositionChanged(this, new EventArgs());
                        this.TotalizarPecasServicos();
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            }
            else
                MessageBox.Show("Não existe ordem Peça/Serviço selecionado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void TotalizarPecasServicos()
        {
            if (bsOS.Current != null)
            {
                //Total Peças
                tot_custoFat.Text = (bsOS.Current as CamadaDados.Servicos.TRegistro_LanServico).lPecas.FindAll(p => 
                    !p.St_servicobool).Sum(p => (p.Quantidade - p.SaldoFaturar) * p.Vl_custo).ToString("N2", new System.Globalization.CultureInfo("pt-BR"));
                tot_liqfaturado.Text = (bsOS.Current as CamadaDados.Servicos.TRegistro_LanServico).lPecas.FindAll(p =>
                    !p.St_servicobool).Sum(p => ((p.Quantidade - p.SaldoFaturar) * p.Vl_unitario) - p.Vl_desconto + p.Vl_acrescimo).ToString("N2", new System.Globalization.CultureInfo("pt-BR"));
                tot_custo.Text = (bsOS.Current as CamadaDados.Servicos.TRegistro_LanServico).lPecas.FindAll(p =>
                    !p.St_servicobool).Sum(p => p.Vl_custo * p.Quantidade).ToString("N2", new System.Globalization.CultureInfo("pt-BR")); ;
                tot_liquido.Text = (bsOS.Current as CamadaDados.Servicos.TRegistro_LanServico).lPecas.FindAll(p =>
                    !p.St_servicobool).Sum(p => p.Vl_SubTotalLiq).ToString("N2", new System.Globalization.CultureInfo("pt-BR"));
                //Total Serviços
                tot_servico.Text = (bsOS.Current as CamadaDados.Servicos.TRegistro_LanServico).lPecas.FindAll(p =>
                    p.St_servicobool).Sum(p => p.Vl_SubTotalLiq).ToString("N2", new System.Globalization.CultureInfo("pt-BR"));
            }
        }

        private void TFLanOSTarefa_Load(object sender, EventArgs e)
        {
            tlpAnexo.ColumnStyles[2] = new ColumnStyle(SizeType.Absolute, 0);
            tlpAnexo.ColumnStyles[1] = new ColumnStyle(SizeType.Absolute, 0);
            tsOrganizar.Visible = false;
            bb_organizar.Text = "ORGANIZAR";
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            //Restaurar posicao do grid
            Utils.ShapeGrid.RestoreShape(this, gOS);
            Utils.ShapeGrid.RestoreShape(this, gEvolucao);
            Utils.ShapeGrid.RestoreShape(this, gProduto);
            Utils.ShapeGrid.RestoreShape(this, gServico);
            Utils.ShapeGrid.RestoreShape(this, gTarefa);

            pFiltro.set_FormatZero();
            //Permitir visualizar dados financeiros
            bool st_fin = CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin, "PERMITIR VISUALIZAR DETALHES FINANCEIRO", null);
            if (!st_fin)
            {
                tcDetalhes.TabPages.Remove(tpDuplicata);
                tcDetalhes.TabPages.Remove(tpServico);
                tcDetalhes.TabPages.Remove(tpPecas);
                bb_gerarDup.Visible = false;
            }
            //Permitir Cancelar Ordem Serviço
            bool st_cancelar = CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin, "PERMITIR CANCELAR ORDEM SERVICO", null);
            if (!st_cancelar)
            {
                BB_Excluir.Visible = false;
                excluirTarefas.Visible = false;
            }
        }

        private void BB_Novo_Click(object sender, EventArgs e)
        {
            this.afterNovo();
        }

        private void BB_Alterar_Click(object sender, EventArgs e)
        {
            this.EvoluirOS();
        }

        private void BB_Excluir_Click(object sender, EventArgs e)
        {
            this.afterExclui();
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            this.afterBusca();
        }

        private void bb_gerarDup_Click(object sender, EventArgs e)
        {
            this.GerarDup();
        }

        private void CD_Empresa_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + CD_Empresa.Text.Trim() + "'", new Componentes.EditDefault[] { CD_Empresa });
        }

        private void BB_Empresa_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { CD_Empresa }, string.Empty);
        }

        private void CD_Clifor_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + CD_Clifor.Text.Trim() + "';" +
                                                    "isnull(a.st_fornecedor, 'N')|<>|'S';" +
                                                    "isnull(a.ST_Funcionarios, 'N')|<>|'S';" +
                                                    "isnull(a.st_representante, 'N')|<>|'S';" +
                                                    "isnull(a.st_transportadora, 'N')|<>|'S'",
                                                    new Componentes.EditDefault[] { CD_Clifor },
                                                    new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void BB_Clifor_Click(object sender, EventArgs e)
        {
            string vParam = "isnull(a.st_fornecedor, 'N')|<>|'S';" +
                         "isnull(a.ST_Funcionarios, 'N')|<>|'S';" +
                         "isnull(a.st_representante, 'N')|<>|'S';" +
                         "isnull(a.st_transportadora, 'N')|<>|'S'";
            FormBusca.UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { CD_Clifor }, vParam);
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

        private void id_tecnico_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + id_tecnico.Text.Trim() + "';isnull(a.st_tecnico, 'N')|=|'S'",
                                                    new Componentes.EditDefault[] { id_tecnico },
                                                    new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void bb_tecnico_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { id_tecnico }, "isnull(a.st_tecnico, 'N')|=|'S'");
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
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
                //Buscar Ficha Tecnica
                (bsOS.Current as CamadaDados.Servicos.TRegistro_LanServico).lPecas.ForEach(p =>
                    p.lFichaTecOS = CamadaNegocio.Servicos.TCN_FichaTecOS.Buscar(p.Cd_empresa,
                                                                                 p.Id_osstr,
                                                                                 p.Id_pecastr,
                                                                                 string.Empty,
                                                                                 null));
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
                    }, 0, string.Empty, "a.ordem");

                //Buscar Atividades
                (bsOS.Current as CamadaDados.Servicos.TRegistro_LanServico).lEvolucao.ForEach(p =>
                    p.lAtividade = CamadaNegocio.Servicos.TCN_LanAtividades.Buscar(p.Id_osstr,
                                                                                   p.Cd_empresa,
                                                                                   p.Id_evolucaostr,
                                                                                   string.Empty,
                                                                                   string.Empty,
                                                                                   string.Empty,
                                                                                   string.Empty,
                                                                                   string.Empty,
                                                                                   string.Empty,
                                                                                   string.Empty,
                                                                                   string.Empty,
                                                                                   null));

                //Buscar Imagens
                (bsOS.Current as CamadaDados.Servicos.TRegistro_LanServico).lImagens =
                    CamadaNegocio.Servicos.Cadastros.TCN_Imagens.Buscar((bsOS.Current as CamadaDados.Servicos.TRegistro_LanServico).Id_osstr,
                                                                          (bsOS.Current as CamadaDados.Servicos.TRegistro_LanServico).Cd_empresa,
                                                                            null);

                //Buscar Duplicata
                (bsOS.Current as CamadaDados.Servicos.TRegistro_LanServico).lDup =
                    CamadaNegocio.Servicos.TCN_LanServico_X_Duplicata.BuscarDup((bsOS.Current as CamadaDados.Servicos.TRegistro_LanServico).Cd_empresa,
                                                                             (bsOS.Current as CamadaDados.Servicos.TRegistro_LanServico).Id_osstr,
                                                                             null);
                //Buscar Pecas 
                BS_Pecas.DataSource = (bsOS.Current as CamadaDados.Servicos.TRegistro_LanServico).lPecas.FindAll(p => p.St_servicobool == false);

                //Buscar Servicos
                bsServico.DataSource = (bsOS.Current as CamadaDados.Servicos.TRegistro_LanServico).lPecas.FindAll(p => p.St_servicobool);
                this.TotalizarPecasServicos();
                bsImagens_PositionChanged(this, new EventArgs());
                bsOS.ResetCurrentItem();
            }
            else
            {
                BS_Pecas.DataSource = null;
                bsServico.DataSource = null;
            }
        }

        private void TFLanOSTarefa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F2))
                this.afterNovo();
            else if (e.KeyCode.Equals(Keys.F3))
                this.EvoluirOS();
            else if (e.KeyCode.Equals(Keys.F5))
                this.afterExclui();
            else if (e.KeyCode.Equals(Keys.F7))
                this.afterBusca();
            else if (e.KeyCode.Equals(Keys.F8))
                this.GerarDup();
            else if (e.KeyCode.Equals(Keys.F9))
                this.VisualizarLocalizacao();
            else if (tcDetalhes.SelectedTab.Equals(tpEvolucao) && e.KeyCode.Equals(Keys.F4))
                this.FinalizarTarefa();
            else if (tcDetalhes.SelectedTab.Equals(tpEvolucao) && e.Control && e.KeyCode.Equals(Keys.F10))
                this.InserirTarefa();
            else if (tcDetalhes.SelectedTab.Equals(tpEvolucao) && e.Control && e.KeyCode.Equals(Keys.F11))
                this.AlterarTarefa();
            else if (tcDetalhes.SelectedTab.Equals(tpEvolucao) && e.Control && e.KeyCode.Equals(Keys.F12))
                this.ExcluirTarefa();
            else if (tcDetalhes.SelectedTab.Equals(tpImagem) && e.KeyCode.Equals(Keys.Right))
                this.InserirPath();
            else if (tcDetalhes.SelectedTab.Equals(tpImagem) && e.Control && e.KeyCode.Equals(Keys.F12))
                this.ExcluirAnexo();
            else if (tcDetalhes.SelectedTab.Equals(tpServico) && e.Control && e.KeyCode.Equals(Keys.F10))
                this.afterInserirPecas(true);
            else if (tcDetalhes.SelectedTab.Equals(tpServico) && e.Control && e.KeyCode.Equals(Keys.F11))
                this.afterAlterarPecas(true);
            else if (tcDetalhes.SelectedTab.Equals(tpServico) && e.Control && e.KeyCode.Equals(Keys.F12))
                this.afterExcluirPecas(true);
            else if (tcDetalhes.SelectedTab.Equals(tpPecas) && e.Control && e.KeyCode.Equals(Keys.F10))
                this.afterInserirPecas(false);
            else if (tcDetalhes.SelectedTab.Equals(tpPecas) && e.Control && e.KeyCode.Equals(Keys.F11))
                this.afterAlterarPecas(false);
            else if (tcDetalhes.SelectedTab.Equals(tpPecas) && e.Control && e.KeyCode.Equals(Keys.F12))
                this.afterExcluirPecas(false);
            else if (e.Control && e.KeyCode.Equals(Keys.P))
            {
                MessageBox.Show("Execute o relatorio que deseja alterar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Altera_Relatorio = true;
            }
        }

        private void TFLanOSTarefa_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Salvar posição no grid
            Utils.ShapeGrid.SaveShape(this, gOS);
            Utils.ShapeGrid.SaveShape(this, gProduto);
            Utils.ShapeGrid.SaveShape(this, gEvolucao);
            Utils.ShapeGrid.SaveShape(this, gServico);
            Utils.ShapeGrid.SaveShape(this, gTarefa);
        }

        private void gOS_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
                if (e.ColumnIndex.Equals(0))
                {
                    if (e.Value.ToString().Trim().ToUpper().Equals("FINALIZADA"))
                        gOS.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Green;
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

        private void gEvolucao_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
                if (e.ColumnIndex.Equals(0))
                {
                    if (e.Value.ToString().Trim().ToUpper().Equals("ENCERRADA"))
                        gEvolucao.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Green;
                    else
                        gEvolucao.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                }
        }

        private void gTarefa_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
                if (e.ColumnIndex.Equals(0))
                {
                    if (e.Value.ToString().Trim().ToUpper().Equals("CONCLUÍDA"))
                        gTarefa.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Green;
                    else
                        gTarefa.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                }
        }

        private void FinalizarTarefa_Click(object sender, EventArgs e)
        {
            this.FinalizarTarefa();
        }

        private void InserirTarefas_Click(object sender, EventArgs e)
        {
            this.InserirTarefa();
        }

        private void AlterarTarefas_Click(object sender, EventArgs e)
        {
            this.AlterarTarefa();
        }

        private void excluirTarefas_Click(object sender, EventArgs e)
        {
            this.ExcluirTarefa();
        }

        private void bsEvolucao_PositionChanged(object sender, EventArgs e)
        {
            //if (bsEvolucao.Current != null)
            //{
            //    //Buscar Atividades
            //    (bsEvolucao.Current as CamadaDados.Servicos.TRegistro_LanServicoEvolucao).lAtividade =
            //    CamadaNegocio.Servicos.TCN_LanAtividades.Buscar((bsEvolucao.Current as CamadaDados.Servicos.TRegistro_LanServicoEvolucao).Id_osstr,
            //                                                                             (bsEvolucao.Current as CamadaDados.Servicos.TRegistro_LanServicoEvolucao).Cd_empresa,
            //                                                                             (bsEvolucao.Current as CamadaDados.Servicos.TRegistro_LanServicoEvolucao).Id_evolucaostr,
            //                                                                             string.Empty,
            //                                                                             string.Empty,
            //                                                                             string.Empty,
            //                                                                             null);
            //    bsEvolucao.ResetCurrentItem();
            //}
        }

        private void gImagem_DoubleClick(object sender, EventArgs e)
        {
            this.ImageShow();
        }

        private void ptbImagem_DoubleClick(object sender, EventArgs e)
        {
            this.ImageShow();
        }

        private void relatorioPedidosSinteticoToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
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
                    Rel.Nome_Relatorio = "TFLanOSTarefa_ListaOS";
                    Rel.NM_Classe = this.Name;
                    Rel.Modulo = "OSE";
                    Rel.Ident = "TFLanOSTarefa_ListaOS";
                    fImp.St_enabled_enviaremail = true;
                    fImp.pCd_clifor = string.Empty;
                    fImp.pMensagem = "RELATORIO LISTA DE PROJETOS";

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
                                           "RELATORIO LISTA DE PROJETOS",
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
                                               "RELATORIO LISTA DE PROJETOS",
                                               fImp.pDs_mensagem);
                }
            }
            else
            {
                MessageBox.Show("Não existe Registros Para Imprimir o Relatório!");
            }
        }

        private void bb_inserirCaminho_Click(object sender, EventArgs e)
        {
            this.InserirPath();
        }

        private void bb_excluirCaminho_Click(object sender, EventArgs e)
        {
            this.ExcluirAnexo();
        }

        private void bsImagens_PositionChanged(object sender, EventArgs e)
        {
            try
            {
                if (bsImagens.Current != null)
                {
                    if ((bsImagens.Current as CamadaDados.Servicos.Cadastros.TRegistro_Imagens).Foto_imagem != null)
                    {
                        tlpAnexo.ColumnStyles[2] = new ColumnStyle(SizeType.Absolute, 460);
                        tlpAnexo.ColumnStyles[1] = new ColumnStyle(SizeType.Absolute, 0);
                    }
                    else
                    {
                        tlpAnexo.ColumnStyles[2] = new ColumnStyle(SizeType.Absolute, 0);
                        tlpAnexo.ColumnStyles[1] = new ColumnStyle(SizeType.Absolute, 460);
                        lView.Clear();
                        //Marca o diretório a ser listado
                        DirectoryInfo diretorio = new DirectoryInfo((bsImagens.Current as CamadaDados.Servicos.Cadastros.TRegistro_Imagens).Ds_imagem.Trim());
                        //Executa função GetFile(Lista os arquivos desejados de acordo com o parametro)
                        FileInfo[] Arquivos = diretorio.GetFiles("*.*");

                        //Começamos a listar os arquivos
                        foreach (FileInfo fileinfo in Arquivos)
                        {
                            lView.Items.Add(fileinfo.ToString());
                        }
                    }
                    bsImagens.ResetCurrentItem();
                }
                else
                {
                    tlpAnexo.ColumnStyles[2] = new ColumnStyle(SizeType.Absolute, 0);
                    tlpAnexo.ColumnStyles[1] = new ColumnStyle(SizeType.Absolute, 0);
                }
            }
            catch 
            { }
        }

        private void lView_DoubleClick(object sender, EventArgs e)
        {
            if (bsImagens.Current != null && lView.Items.Count > 0)
            {
                try
                {
                    System.Diagnostics.Process.Start((bsImagens.Current as CamadaDados.Servicos.Cadastros.TRegistro_Imagens).Ds_imagem.Trim() + "\\" +
                        lView.FocusedItem.Text);
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void bb_visualizarMapa_Click(object sender, EventArgs e)
        {
            this.VisualizarLocalizacao();
        }

        private void gTarefa_DoubleClick(object sender, EventArgs e)
        {
            if (bsAtividade.Current != null)
            {
                using (TFTarefa fTarefa = new TFTarefa())
                    try
                    {
                        fTarefa.St_visualizar = true;
                        fTarefa.Size = new Size(736, 340 - 43);
                        fTarefa.rAtividade = bsAtividade.Current as CamadaDados.Servicos.TRegistro_LanAtividades;
                        fTarefa.ShowDialog();
                    }
                    finally
                    {
                        fTarefa.Dispose();
                    }
            }
        }

        private void bb_cima_Click(object sender, EventArgs e)
        {
            if (bsEvolucao.Position > 0)
                try
                {
                    int position = bsEvolucao.Position;
                    (bsEvolucao.Current as CamadaDados.Servicos.TRegistro_LanServicoEvolucao).Ordem -= 1;
                    CamadaNegocio.Servicos.TCN_LanServicoEvolucao.OrganizarEtapas(bsEvolucao.Current as CamadaDados.Servicos.TRegistro_LanServicoEvolucao, null);
                    (bsEvolucao[position - 1] as CamadaDados.Servicos.TRegistro_LanServicoEvolucao).Ordem += 1;
                    CamadaNegocio.Servicos.TCN_LanServicoEvolucao.OrganizarEtapas(bsEvolucao[position - 1] as CamadaDados.Servicos.TRegistro_LanServicoEvolucao, null);
                    bsOS_PositionChanged(this, new EventArgs());
                    bsEvolucao.Position = position - 1;
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }

        }

        private void bb_baixo_Click(object sender, EventArgs e)
        {
            if (bsEvolucao.Position < bsEvolucao.Count - 1)
                try
                {
                    int position = bsEvolucao.Position;
                    (bsEvolucao.Current as CamadaDados.Servicos.TRegistro_LanServicoEvolucao).Ordem += 1;
                    CamadaNegocio.Servicos.TCN_LanServicoEvolucao.OrganizarEtapas(bsEvolucao.Current as CamadaDados.Servicos.TRegistro_LanServicoEvolucao, null);
                    (bsEvolucao[position + 1] as CamadaDados.Servicos.TRegistro_LanServicoEvolucao).Ordem -= 1;
                    CamadaNegocio.Servicos.TCN_LanServicoEvolucao.OrganizarEtapas(bsEvolucao[position + 1] as CamadaDados.Servicos.TRegistro_LanServicoEvolucao, null);
                    bsOS_PositionChanged(this, new EventArgs());
                    bsEvolucao.Position = position + 1;
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void bb_organizar_Click(object sender, EventArgs e)
        {
            if (tsOrganizar.Visible == false)
            {
                bb_organizar.Text = "CONCLUIR";
                tsOrganizar.Visible = true;
            }
            else
            {
                bb_organizar.Text = "ORGANIZAR";
                tsOrganizar.Visible = false;
            }
        }

        private void comDescriçãoDasAtividadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.afterPrintDescritivo();
        }

        private void semDescriçãoDasAtividadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.afterPrint();
        }

        private void miNFPecas_Click(object sender, EventArgs e)
        {
            if (bsOS.Current != null)
            {
                using (TFItensFaturar fFaturar = new TFItensFaturar())
                {
                    fFaturar.St_servico = false;
                    fFaturar.pCd_clifor = (bsOS.Current as TRegistro_LanServico).Cd_clifor;
                    fFaturar.pCd_empresa = (bsOS.Current as TRegistro_LanServico).Cd_empresa;
                    if (fFaturar.ShowDialog() == DialogResult.OK)
                        if (fFaturar.lItemOS.Count > 0)
                        {
                            CamadaDados.Servicos.Cadastros.TList_OSE_ParamOS lParam =
                            CamadaNegocio.Servicos.Cadastros.TCN_OSE_ParamOS.Buscar((bsOS.Current as TRegistro_LanServico).Tp_ordemstr,
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
                            CamadaDados.Faturamento.Pedido.TRegistro_Pedido rPed = null;
                            try
                            {
                                Proc_Commoditties.TProcessaPedidoOS.GerarPedidoPecas(ref rPed,
                                                                                             null,
                                                                                             fFaturar.lItemOS,
                                                                                             lParam[0]);
                                //Buscar Endereco clifor
                                object obj_end = new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco().BuscarEscalar(
                                                    new Utils.TpBusca[]
                                    {
                                        new Utils.TpBusca()
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
                }
            }
        }

        private void btn_inserirPecas_Click(object sender, EventArgs e)
        {
            this.afterInserirPecas(false);
        }

        private void btn_alterarPecas_Click(object sender, EventArgs e)
        {
            this.afterAlterarPecas(false);
        }

        private void btn_deletarPecas_Click(object sender, EventArgs e)
        {
            this.afterExcluirPecas(false);
        }

        private void bb_inserirServicos_Click(object sender, EventArgs e)
        {
            this.afterInserirPecas(true);
        }

        private void bb_alterarServicos_Click(object sender, EventArgs e)
        {
            this.afterAlterarPecas(true);
        }

        private void bb_excluirServicos_Click(object sender, EventArgs e)
        {
            this.afterExcluirPecas(true);
        }
    }
}
