using System;
using System.Windows.Forms;
using CamadaDados.Empreendimento;
using CamadaDados.Empreendimento.Cadastro;
using CamadaNegocio.Empreendimento;
using Utils;
using CamadaNegocio.Empreendimento.Cadastro;


namespace Empreendimento
{
    public partial class FLanProjeto : Form
    {
        public FLanProjeto()
        {
            InitializeComponent();
        }

        private void bb_clifor_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_clifor }, string.Empty);
        }

        private void cd_clifor_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + cd_clifor.Text.Trim() + "'",
                new Componentes.EditDefault[] { cd_clifor }, new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void LimparFiltros()
        {
            cd_empresa.Clear();
            id_orcamento.Clear();
            nr_versao.Clear();
            cd_clifor.Clear();
        }

        private void afterNovo()
        {
            using (TFOrcamento fOrcamento = new TFOrcamento())
            {
                if (fOrcamento.ShowDialog() == DialogResult.OK)
                    if (fOrcamento.rOrcamento != null)
                        try
                        {
                            TList_CadDespesa lDespesa = TCN_CadDespesa.Busca(string.Empty, string.Empty, null);
                            lDespesa.ForEach(p =>
                            {
                                TRegistro_Despesas desp = new TRegistro_Despesas();
                                desp.Id_despesastr = p.Id_despesastr;
                                desp.Cd_empresa = fOrcamento.rOrcamento.Cd_empresa;
                                desp.Nr_versao = fOrcamento.rOrcamento.Nr_versao;
                                desp.Id_orcamentostr = fOrcamento.rOrcamento.Id_orcamentostr;
                                fOrcamento.rOrcamento.lDespesas.Add(desp);
                            });
                            TCN_Orcamento.Evoluir(fOrcamento.rOrcamento, null);
                            MessageBox.Show("Orçamento gravado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LimparFiltros();
                            cd_empresa.Text = fOrcamento.rOrcamento.Cd_empresa;
                            id_orcamento.Text = fOrcamento.rOrcamento.Id_orcamentostr;
                            nr_versao.Text = fOrcamento.rOrcamento.Nr_versaostr;
                            afterBusca();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void afterAltera()
        {
            if (bsOrcamento.Current != null)
            {
                if (!(bsOrcamento.Current as TRegistro_Orcamento).St_registro.Trim().ToUpper().Equals("A") &&
                    !(bsOrcamento.Current as TRegistro_Orcamento).St_registro.Trim().ToUpper().Equals("N"))
                {
                    MessageBox.Show("Permitido alterar somente orçamento ABERTO.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                using (TFOrcamento fOrc = new TFOrcamento())
                {
                    fOrc.rOrcamento = bsOrcamento.Current as TRegistro_Orcamento;
                    if (fOrc.ShowDialog() == DialogResult.OK)
                        try
                        {
                            TCN_Orcamento.Evoluir(fOrc.rOrcamento, null);
                            MessageBox.Show("Orçamento alterado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    LimparFiltros();
                    cd_empresa.Text = fOrc.rOrcamento.Cd_empresa;
                    id_orcamento.Text = fOrc.rOrcamento.Id_orcamentostr;
                    nr_versao.Text = fOrc.rOrcamento.Nr_versaostr;
                    afterBusca();
                }
            }
        }

        private void afterExclui()
        {
            if (bsOrcamento.Current != null)
            {
                if (!(bsOrcamento.Current as TRegistro_Orcamento).St_registro.Trim().ToUpper().Equals("A") &&
                    !(bsOrcamento.Current as TRegistro_Orcamento).St_registro.Trim().ToUpper().Equals("N") &&
                    !(bsOrcamento.Current as TRegistro_Orcamento).St_registro.Trim().ToUpper().Equals("P"))
                {
                    MessageBox.Show("Permitido alterar somente orçamento ABERTO, em NEGOCIAÇÃO ou PROCESSADO.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if ((bsOrcamento.Current as TRegistro_Orcamento).St_registro.Trim().ToUpper().Equals("P"))
                    if (new TCD_Orcamento().BuscarEscalar(
                        new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = "a.cd_empresa",
                                vOperador = "=",
                                vVL_Busca = "'" + (bsOrcamento.Current as TRegistro_Orcamento).Cd_empresa.Trim() + "'"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "a.id_orc",
                                vOperador = "=",
                                vVL_Busca = (bsOrcamento.Current as TRegistro_Orcamento).Id_orcamentostr
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "a.nr_versaoorc",
                                vOperador = "=",
                                vVL_Busca = (bsOrcamento.Current as TRegistro_Orcamento).Nr_versaostr
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "isnull(a.st_registro, 'A')",
                                vOperador = "<>",
                                vVL_Busca = "'C'"
                            }
                        }, "1") != null)
                    {
                        MessageBox.Show("Não é permitido CANCELAR orçamento PROCESSADO com PROJETO ATIVO.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                if (MessageBox.Show("Confirma CANCELAMENTO do orçamento corrente?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                     MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    try
                    {
                        TCN_Orcamento.Cancelar(bsOrcamento.Current as TRegistro_Orcamento, null);
                        MessageBox.Show("Orçamento CANCELADO com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        (bsOrcamento.Current as TRegistro_Orcamento).St_registro = "C";
                        bsOrcamento.ResetCurrentItem();
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void afterBusca()
        {

            TpBusca[] filtro = new TpBusca[1];
            filtro[0].vNM_Campo = "a.st_registro";
            filtro[0].vOperador = "=";
            filtro[0].vVL_Busca = "'T'";

            if (!string.IsNullOrEmpty(cd_empresa.Text))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + cd_empresa.Text.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(id_orcamento.Text))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_orc";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + id_orcamento.Text.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(nr_projeto.Text))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_orcamento";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + nr_projeto.Text.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(nr_versao.Text))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_versao";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + nr_versao.Text.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(cd_clifor.Text))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_clifor";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + cd_clifor.Text.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(dt_ini.Text.SoNumero()))
                Estruturas.CriarParametro(ref filtro, "convert(datetime, floor(convert(decimal(30,10), " + (rbDtOrcamento.Checked ? "a.dt_orcamento" : "a.dt_entregaproposta") + ")))",
                                          "'" + DateTime.Parse(dt_ini.Text).ToString("yyyyMMdd") + "'", ">=");
            if (!string.IsNullOrEmpty(dt_fin.Text.SoNumero()))
                Estruturas.CriarParametro(ref filtro, "convert(datetime, floor(convert(decimal(30,10), " + (rbDtOrcamento.Checked ? "a.dt_orcamento" : "a.dt_entregaproposta") + ")))",
                                          "'" + DateTime.Parse(dt_fin.Text).ToString("yyyyMMdd") + "'", "<=");

            bsOrcamento.DataSource = new TCD_Orcamento().Select(filtro, 100, string.Empty);
            bsOrcamento.ResetCurrentItem();
        }

        private void OtimizarOrcamento()
        {
            if (MessageBox.Show("Deseja gerar nova versão do orçamento?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                           MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                if (bsOrcamento.Current != null)
                {
                    if ((bsOrcamento.Current as TRegistro_Orcamento).St_registro.Trim().ToUpper().Equals("N"))
                    {
                        //Verificar se orçamento possui versão em Aberto 
                        if (new TCD_Orcamento().BuscarEscalar(
                            new TpBusca[]
                            {
                            new TpBusca()
                            {
                                vNM_Campo = "a.cd_empresa",
                                vOperador = "=",
                                vVL_Busca = "'" + (bsOrcamento.Current as TRegistro_Orcamento).Cd_empresa.Trim() + "'"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "a.id_orcamento",
                                vOperador = "=",
                                vVL_Busca = (bsOrcamento.Current as TRegistro_Orcamento).Id_orcamentostr
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "isnull(a.st_registro, 'A')",
                                vOperador = "=",
                                vVL_Busca = "'A'"
                            }
                            }, "1") != null)
                        {
                            MessageBox.Show("Orçamento possui versão disponivel para OTIMIZAR.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        string ds_tarefa = string.Empty;
                        using (TFTarefas fTarefa = new TFTarefas())
                        {
                            if (fTarefa.ShowDialog() == DialogResult.OK)
                                ds_tarefa = fTarefa.pDs_tarefa;
                        }
                        try
                        {
                            TRegistro_Orcamento aux = TCN_Orcamento.GerarNovaVersao(bsOrcamento.Current as TRegistro_Orcamento, ds_tarefa, null);
                            MessageBox.Show("Nova versão gerada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LimparFiltros();
                            cd_empresa.Text = aux.Cd_empresa;
                            id_orcamento.Text = aux.Id_orcamentostr;
                            nr_versao.Text = aux.Nr_versaostr;
                            // cbAberto.Checked = true;
                            afterBusca();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    }
                    else MessageBox.Show("Permitido otimizar somente orçamento que estiver em NEGOCIAÇÃO.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Selecione um orcamento!", "Orçamento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { cd_empresa }, string.Empty);
        }

        private void cd_empresa_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "'", new Componentes.EditDefault[] { cd_empresa });
        }

        private void BB_Novo_Click(object sender, EventArgs e)
        {
            afterNovo();
        }

        private void BB_Alterar_Click(object sender, EventArgs e)
        {
            afterAltera();
        }

        private void buscaOrcCompleto()
        {
            if ((bsOrcamento.Current as TRegistro_Orcamento) != null)
            {
                (bsOrcamento.Current as TRegistro_Orcamento).lOrcProjeto =
                        TCN_OrcProjeto.Buscar((bsOrcamento.Current as TRegistro_Orcamento).Cd_empresa,
                                              (bsOrcamento.Current as TRegistro_Orcamento).Id_orcamentostr,
                                              (bsOrcamento.Current as TRegistro_Orcamento).Nr_versaostr,
                                              string.Empty,
                                              string.Empty,
                                              null);
                (bsOrcamento.Current as TRegistro_Orcamento).lOrcProjeto.ForEach(p =>
                {
                    p.lFicha =
                            TCN_FichaTec.Buscar(p.Cd_empresa,
                                                p.Id_orcamentostr,
                                                p.Nr_versaostr,
                                                p.Id_projetostr,
                                                p.Id_registrostr,
                                                string.Empty,
                                                null);

                });
                //Buscar Despesas
                (bsOrcamento.Current as TRegistro_Orcamento).lDespesas =
                    TCN_Despesas.Buscar((bsOrcamento.Current as TRegistro_Orcamento).Cd_empresa,
                                        (bsOrcamento.Current as TRegistro_Orcamento).Id_orcamentostr,
                                        (bsOrcamento.Current as TRegistro_Orcamento).Nr_versaostr,
                                        string.Empty,
                                        string.Empty,
                                        null);
                //Buscar Tarefas
                (bsOrcamento.Current as TRegistro_Orcamento).lTarefas =
                    TCN_Tarefas.Buscar((bsOrcamento.Current as TRegistro_Orcamento).Cd_empresa,
                                        (bsOrcamento.Current as TRegistro_Orcamento).Id_orcamentostr,
                                        (bsOrcamento.Current as TRegistro_Orcamento).Nr_versaostr,
                                        null);
                //Buscar mao obra
                (bsOrcamento.Current as TRegistro_Orcamento).lMaoObra =
                    TCN_CadMaoObra.Busca(
                                        (bsOrcamento.Current as TRegistro_Orcamento).Id_orcamentostr,
                                        (bsOrcamento.Current as TRegistro_Orcamento).Nr_versaostr,
                                        (bsOrcamento.Current as TRegistro_Orcamento).Cd_empresa,
                                        string.Empty,
                                        null);
                //Buscar encargos
                (bsOrcamento.Current as TRegistro_Orcamento).lOEncargo =
                    TCN_OrcamentoEncargo.Buscar(
                                        string.Empty,
                                        (bsOrcamento.Current as TRegistro_Orcamento).Cd_empresa,
                                        (bsOrcamento.Current as TRegistro_Orcamento).Nr_versaostr,
                                        (bsOrcamento.Current as TRegistro_Orcamento).Id_orcamentostr,
                                        null);
            }
        }
        private void BB_Excluir_Click(object sender, EventArgs e)
        {
            afterExclui();
        }

        private void bbBuscar_Click(object sender, EventArgs e)
        {
            afterBusca();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if ((bsOrcamento.Current) != null)
            {
                if ((bsOrcamento.Current as TRegistro_Orcamento).St_registro.Equals("T"))
                {
                    if (CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Parametros.pubLogin, "VISAO PROJETISTA", null))
                    {
                        if (MessageBox.Show("Orcamento está em " + (bsOrcamento.Current as TRegistro_Orcamento).Status + ", Deseja finalizar o projeto e evoluir para execução?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                         MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                            try
                            {
                                bsOrcamento_PositionChanged(this, new EventArgs());
                                TList_FichaTec lficha = new TList_FichaTec();

                                //valida
                                TList_CadCFGEmpreendimento lcfg = new TCD_CadCFGEmpreendimento().Select(
                                            new TpBusca[]
                                            {
                                                new TpBusca()
                                                {
                                                    vNM_Campo = "a.cd_empresa",
                                                    vOperador = "=",
                                                    vVL_Busca = (bsOrcamento.Current as TRegistro_Orcamento).Cd_empresa
                                                }
                                            }, 1, string.Empty);
                                if (string.IsNullOrEmpty(lcfg[0].tp_requisicao) || string.IsNullOrEmpty(lcfg[0].tp_requisicaodir))
                                {
                                    MessageBox.Show("Favor corrigir a configuração do empreendimento!\n (Tipo Requisição)", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                                (bsOrcamento.Current as TRegistro_Orcamento).lOrcProjeto.ForEach(o =>
                                {
                                    o.lFicha.ForEach(p =>
                                    {
                                        if (p.Tot_saldo < p.Quantidade)
                                        {
                                            p.st_agregar = true;
                                            p.quantidade_agregar = p.Quantidade;
                                        }
                                    });
                                });

                                TList_FichaTec lista_nao_cadastrados = new TList_FichaTec();
                                bool lista = false;
                                (bsOrcamento.Current as TRegistro_Orcamento).lOrcProjeto.ForEach(o =>
                                {
                                    o.lFicha.ForEach(p =>
                                    {
                                        if (string.IsNullOrEmpty(p.Cd_produto))
                                        {
                                            lista_nao_cadastrados.Add(p);
                                            lista = true;
                                        }
                                    });
                                });

                                if (lista)
                                    using (FListCadProd ls = new FListCadProd())
                                    {
                                        ls.rLItens = lista_nao_cadastrados;
                                        if (ls.ShowDialog() == DialogResult.OK)
                                        {
                                            (bsOrcamento.Current as TRegistro_Orcamento).lOrcProjeto.ForEach(o =>
                                            {
                                                o.lFicha.ForEach(p =>
                                                {
                                                    ls.rLItens.ForEach(i =>
                                                    {
                                                        if (p.Ds_produto.Equals(i.Ds_produto))
                                                        {
                                                            p.Cd_produto = i.Cd_produto;
                                                            CamadaNegocio.Empreendimento.TCN_FichaTec.Gravar(p, null);
                                                        }
                                                    });
                                                });
                                            });
                                            bsOrcamento.ResetCurrentItem();
                                        }
                                        else
                                            return;
                                    }

                                using (FRequisicaoCompra comp = new FRequisicaoCompra())
                                {//Buscar Atividades
                                    TRegistro_Orcamento orc = new TRegistro_Orcamento();
                                    orc = (bsOrcamento.Current as TRegistro_Orcamento);
                                    orc.lOrcProjeto =
                                        TCN_OrcProjeto.Buscar((bsOrcamento.Current as TRegistro_Orcamento).Cd_empresa,
                                                              (bsOrcamento.Current as TRegistro_Orcamento).Id_orcamentostr,
                                                              (bsOrcamento.Current as TRegistro_Orcamento).Nr_versaostr,
                                                              string.Empty,
                                                              string.Empty,
                                                              null);
                                    orc.lOrcProjeto.ForEach(p =>
                                    {
                                        TpBusca[] filtro = new TpBusca[0];
                                        if (!string.IsNullOrEmpty(p.Cd_empresa))
                                        {
                                            Array.Resize(ref filtro, filtro.Length + 1);
                                            filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                                            filtro[filtro.Length - 1].vOperador = "=";
                                            filtro[filtro.Length - 1].vVL_Busca = "'" + p.Cd_empresa.Trim() + "'";
                                        }
                                        if (!string.IsNullOrEmpty(p.Id_orcamentostr))
                                        {
                                            Array.Resize(ref filtro, filtro.Length + 1);
                                            filtro[filtro.Length - 1].vNM_Campo = "a.id_orcamento";
                                            filtro[filtro.Length - 1].vOperador = "=";
                                            filtro[filtro.Length - 1].vVL_Busca = p.Id_orcamentostr;
                                        }
                                        if (!string.IsNullOrEmpty(p.Nr_versaostr))
                                        {
                                            Array.Resize(ref filtro, filtro.Length + 1);
                                            filtro[filtro.Length - 1].vNM_Campo = "a.nr_versao";
                                            filtro[filtro.Length - 1].vOperador = "=";
                                            filtro[filtro.Length - 1].vVL_Busca = p.Nr_versaostr;
                                        }
                                        if (!string.IsNullOrEmpty(p.Id_projetostr))
                                        {
                                            Array.Resize(ref filtro, filtro.Length + 1);
                                            filtro[filtro.Length - 1].vNM_Campo = "a.id_atividade";
                                            filtro[filtro.Length - 1].vOperador = "=";
                                            filtro[filtro.Length - 1].vVL_Busca = p.Id_projetostr;
                                        }
                                        if (!string.IsNullOrEmpty(p.Id_registrostr))
                                        {
                                            Array.Resize(ref filtro, filtro.Length + 1);
                                            filtro[filtro.Length - 1].vNM_Campo = "a.Id_Registro";
                                            filtro[filtro.Length - 1].vOperador = "=";
                                            filtro[filtro.Length - 1].vVL_Busca = p.Id_registrostr;
                                        }
                                        
                                        Array.Resize(ref filtro, filtro.Length + 1);
                                        filtro[filtro.Length - 1].vOperador = "not exists ";
                                        filtro[filtro.Length - 1].vVL_Busca = " (select 1 from TB_EMP_CompraEmpreendimento x " +
                                                                              "where a.id_orcamento = x.id_orcamento and a.nr_versao = x.nr_versao " +
                                                                              "and a.ID_Atividade = x.ID_Atividade and a.ID_Ficha = x.ID_Ficha " +
                                                                              "and a.ID_Registro = x.ID_Registro and a.cd_empresa = x.cd_empresa) ";



                                        p.lFicha = new TCD_FichaTec().Select(filtro, 0, string.Empty);
                                    });
                                    comp.rOrcamento = orc;
                                    if (comp.ShowDialog() == DialogResult.OK)
                                    {
                                        lficha = comp.objetoItens.lFicha;
                                        //(bsOrcamento.Current as TRegistro_Orcamento) = comp.rOrcamento;
                                        (bsOrcamento.Current as TRegistro_Orcamento).St_registro = "E";
                                        TList_FichaTec lficha2 = new TList_FichaTec();
                                        lficha.ForEach(p =>
                                        {
                                            if (p.st_agregar)
                                                lficha2.Add(p);
                                        });
                                        TCN_Orcamento.GravarOrcReq((bsOrcamento.Current as TRegistro_Orcamento), lficha2, null);

                                        // MessageBox.Show("Orçamento gravado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        LimparFiltros();
                                        //cbHomologacao.Checked = true;
                                        afterBusca();
                                        MessageBox.Show("Orçamento está aguardando em execução.", "Orçamento", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    }
                                }
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    }
                    else
                        MessageBox.Show("Usuário não tem permissão de projetista para esta evolução.", "Orçamento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Selecione um orcamento!", "Orçamento", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void bbbOrcamento_Click(object sender, EventArgs e)
        {
            if (bsOrcamento.Current != null)
            {
                bool flag = true;
                string mensagem = string.Empty;
                if ((bsOrcamento.Current as TRegistro_Orcamento).St_registro.Equals("A") || (bsOrcamento.Current as TRegistro_Orcamento).St_registro.Equals("O")
                    || (bsOrcamento.Current as TRegistro_Orcamento).St_registro.Equals("T") || (bsOrcamento.Current as TRegistro_Orcamento).St_registro.Equals("J"))
                {
                    if ((bsOrcamento.Current as TRegistro_Orcamento).St_registro.Equals("A") || (bsOrcamento.Current as TRegistro_Orcamento).St_registro.Equals("O"))
                    {
                        flag = (CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Parametros.pubLogin, "VISAO ORCAMENTISTA", null));
                        mensagem = "Não tem permissão para otimizar o orcamento como orcamentista.";
                    }
                    if ((bsOrcamento.Current as TRegistro_Orcamento).St_registro.Equals("T") || (bsOrcamento.Current as TRegistro_Orcamento).St_registro.Equals("J"))
                    {
                        flag = (CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Parametros.pubLogin, "VISAO PROJETISTA", null));
                        mensagem = "Não tem permissão para otimizar o orcamento como projetista.";
                    }
                    if (flag)
                    {
                        using (TFLan_EvoluirOrcamento orc = new TFLan_EvoluirOrcamento())
                        {
                            orc.rOrcamento = (bsOrcamento.Current as TRegistro_Orcamento);
                            orc.projetista = true;
                            if (orc.ShowDialog() == DialogResult.OK)
                                try
                                {
                                    if ((bsOrcamento.Current as TRegistro_Orcamento).St_registro.Equals("A") || (bsOrcamento.Current as TRegistro_Orcamento).St_registro.Equals("O"))
                                        (bsOrcamento.Current as TRegistro_Orcamento).St_registro = "O";

                                    TCN_Orcamento.Evoluir(orc.rOrcamento, null);
                                    MessageBox.Show("Projeto gravado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    afterBusca();
                                }
                                catch (Exception ex)
                                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                        }
                    }
                    else
                        MessageBox.Show(mensagem, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Apenas Orçamento em requisição.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Selecione um orcamento!", "Orçamento", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void FLanProjeto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F7))
                afterBusca();
            else if (e.KeyCode.Equals(Keys.F8) && toolStripButton3.Visible)
                toolStripButton3_Click(this, new EventArgs());
            else if (e.KeyCode.Equals(Keys.F11))
                bbbOrcamento_Click(this, new EventArgs());
        }

        private void FLanProjeto_Load(object sender, EventArgs e)
        {
            Icon = ResourcesUtils.TecnoAliance_ICO;
            pFiltro.set_FormatZero();

            if ((CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Parametros.pubLogin, "VISAO PROJETISTA", null)))
                toolStripButton3.Visible = true;
            else
                toolStripButton3.Visible = false;

        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bsOrcamento_PositionChanged(object sender, EventArgs e)
        {

            if (bsOrcamento.Current != null)
            {
                //Buscar Atividades
                (bsOrcamento.Current as TRegistro_Orcamento).lOrcProjeto =
                    TCN_OrcProjeto.Buscar((bsOrcamento.Current as TRegistro_Orcamento).Cd_empresa,
                                          (bsOrcamento.Current as TRegistro_Orcamento).Id_orcamentostr,
                                          (bsOrcamento.Current as TRegistro_Orcamento).Nr_versaostr,
                                          string.Empty,
                                          string.Empty,
                                          null);
                (bsOrcamento.Current as TRegistro_Orcamento).lOrcProjeto.ForEach(p =>
                {
                    p.lFicha = TCN_FichaTec.Buscar((bsOrcamento.Current as TRegistro_Orcamento).Cd_empresa,
                                          (bsOrcamento.Current as TRegistro_Orcamento).Id_orcamentostr,
                                          (bsOrcamento.Current as TRegistro_Orcamento).Nr_versaostr,
                                          p.Id_projetostr, string.Empty, string.Empty, null);
                });

                bsOrcamento.ResetCurrentItem();
            }
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            if (bsOrcamento.Current == null)
                return;

            using (FRequisicaoCompra comp = new FRequisicaoCompra())
            {//Buscar Atividades
                TRegistro_Orcamento orc = new TRegistro_Orcamento();
                orc = (bsOrcamento.Current as TRegistro_Orcamento);
                orc.lOrcProjeto =
                    TCN_OrcProjeto.Buscar((bsOrcamento.Current as TRegistro_Orcamento).Cd_empresa,
                                          (bsOrcamento.Current as TRegistro_Orcamento).Id_orcamentostr,
                                          (bsOrcamento.Current as TRegistro_Orcamento).Nr_versaostr,
                                          string.Empty,
                                          string.Empty,
                                          null);
                orc.lOrcProjeto.ForEach(p =>
                {
                    TpBusca[] filtro = new TpBusca[0];
                    if (!string.IsNullOrEmpty(p.Cd_empresa))
                    {
                        Array.Resize(ref filtro, filtro.Length + 1);
                        filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                        filtro[filtro.Length - 1].vOperador = "=";
                        filtro[filtro.Length - 1].vVL_Busca = "'" + p.Cd_empresa.Trim() + "'";
                    }
                    if (!string.IsNullOrEmpty(p.Id_orcamentostr))
                    {
                        Array.Resize(ref filtro, filtro.Length + 1);
                        filtro[filtro.Length - 1].vNM_Campo = "a.id_orcamento";
                        filtro[filtro.Length - 1].vOperador = "=";
                        filtro[filtro.Length - 1].vVL_Busca = p.Id_orcamentostr;
                    }
                    if (!string.IsNullOrEmpty(p.Nr_versaostr))
                    {
                        Array.Resize(ref filtro, filtro.Length + 1);
                        filtro[filtro.Length - 1].vNM_Campo = "a.nr_versao";
                        filtro[filtro.Length - 1].vOperador = "=";
                        filtro[filtro.Length - 1].vVL_Busca = p.Nr_versaostr;
                    }
                    if (!string.IsNullOrEmpty(p.Id_projetostr))
                    {
                        Array.Resize(ref filtro, filtro.Length + 1);
                        filtro[filtro.Length - 1].vNM_Campo = "a.id_atividade";
                        filtro[filtro.Length - 1].vOperador = "=";
                        filtro[filtro.Length - 1].vVL_Busca = p.Id_projetostr;
                    }
                    if (!string.IsNullOrEmpty(p.Id_registrostr))
                    {
                        Array.Resize(ref filtro, filtro.Length + 1);
                        filtro[filtro.Length - 1].vNM_Campo = "a.Id_Registro";
                        filtro[filtro.Length - 1].vOperador = "=";
                        filtro[filtro.Length - 1].vVL_Busca = p.Id_registrostr;
                    }

                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[filtro.Length - 1].vOperador = "not exists ";
                    filtro[filtro.Length - 1].vVL_Busca = " (select 1 from TB_EMP_CompraEmpreendimento x " +
                                                          "where a.id_orcamento = x.id_orcamento and a.nr_versao = x.nr_versao " +
                                                          "and a.ID_Atividade = x.ID_Atividade and a.ID_Ficha = x.ID_Ficha " +
                                                          "and a.ID_Registro = x.ID_Registro and a.cd_empresa = x.cd_empresa) ";



                    p.lFicha = new TCD_FichaTec().Select(filtro, 0, string.Empty);
                });
                comp.rOrcamento = orc;
                if (comp.ShowDialog() == DialogResult.OK)
                {
                    TList_FichaTec lficha = new TList_FichaTec();
                    lficha = comp.objetoItens.lFicha;
                    //(bsOrcamento.Current as TRegistro_Orcamento).St_registro = "E";
                    TList_FichaTec lficha2 = new TList_FichaTec();
                    lficha.ForEach(p =>
                    {
                        if (p.st_agregar)
                            lficha2.Add(p);
                    });

                    try
                    {
                        TCN_Orcamento.GravarOrcReq((bsOrcamento.Current as TRegistro_Orcamento), lficha2, null);
                        MessageBox.Show("Requisição de compra gravada com sucesso.", "Informativo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LimparFiltros();
                        afterBusca();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
            }
        }
    }
}
