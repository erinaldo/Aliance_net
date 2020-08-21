using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Servicos
{
    public partial class TFEvoluirOSServico : Form
    {
        public CamadaDados.Servicos.TRegistro_LanServico rOS
        { get; set; }

        public TFEvoluirOSServico()
        {
            InitializeComponent();
        }

        private void BuscarEndereco()
        {
            if (!string.IsNullOrEmpty(CD_Clifor.Text))
            {
                CamadaDados.Financeiro.Cadastros.TList_CadEndereco lEnd =
                    CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Buscar(CD_Clifor.Text,
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
                                                                              string.Empty,
                                                                              1,
                                                                              null);
                if (lEnd.Count > 0)
                {
                    CD_Endereco.Text = lEnd[0].Cd_endereco;
                    DS_Endereco.Text = lEnd[0].Ds_endereco;
                    DS_Cidade.Text = lEnd[0].DS_Cidade;
                    UF.Text = lEnd[0].UF;
                }
            }
        }

        private void afterInserirEvolucao()
        {
            if (bsOrdemServico.Current != null)
            {
                CamadaDados.Servicos.TRegistro_LanServicoEvolucao regEvolucao = null;
                if ((bsOrdemServico.Current as CamadaDados.Servicos.TRegistro_LanServico).lEvolucao.Count > 0)
                    regEvolucao = (bsOrdemServico.Current as CamadaDados.Servicos.TRegistro_LanServico).lEvolucao.OrderByDescending(p => p.Dt_inicio).Take(1).ToList()[0];
                bool st_loteprocessado = false;
                if (regEvolucao != null)
                    if (regEvolucao.St_envterceiro)
                    {
                        object obj = new CamadaDados.Servicos.TCD_Lote_X_Servicos().BuscarEscalar(
                                        new Utils.TpBusca[]
                                        {
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = "c.id_os",
                                                vOperador = "=",
                                                vVL_Busca = (bsOrdemServico.Current as CamadaDados.Servicos.TRegistro_LanServico).Id_os.ToString()

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
                                new Utils.TpBusca[]
                                {
                                    new Utils.TpBusca()
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
                    fEvolucao.TP_Ordem = (bsOrdemServico.Current as CamadaDados.Servicos.TRegistro_LanServico).Tp_ordemstr;
                    if (regEvolucao != null)
                        fEvolucao.Etapa_atual = regEvolucao.Id_etapastr;
                    if (fEvolucao.ShowDialog() == DialogResult.OK)
                    {
                        (bsOrdemServico.Current as CamadaDados.Servicos.TRegistro_LanServico).lEvolucao.ForEach(p =>
                        {
                            p.St_evolucao = "E";
                            p.Dt_final = CamadaDados.UtilData.Data_Servidor();
                            p.Cd_tecnico = string.IsNullOrEmpty(p.Cd_tecnico) ? fEvolucao.rEvolucao.Cd_tecnico : p.Cd_tecnico;
                        });
                        CamadaDados.Servicos.Cadastros.TList_EtapaOrdem lEtapa =
                            CamadaNegocio.Servicos.Cadastros.TCN_EtapaOrdem.Buscar(fEvolucao.rEvolucao.Id_etapa.Value.ToString(),
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
                                    fLote.Cd_empresa = (bsOrdemServico.Current as CamadaDados.Servicos.TRegistro_LanServico).Cd_empresa;
                                    if (fLote.ShowDialog() == DialogResult.OK)
                                        if (fLote.rLote != null)
                                            (bsOrdemServico.Current as CamadaDados.Servicos.TRegistro_LanServico).rLoteServico =
                                                new CamadaDados.Servicos.TRegistro_Lote_X_Servicos()
                                                {
                                                    Cd_empresa = fLote.rLote.Cd_empresa,
                                                    Id_lote = fLote.rLote.Id_lote,
                                                    Id_os = (bsOrdemServico.Current as CamadaDados.Servicos.TRegistro_LanServico).Id_os
                                                };
                                }
                            }
                        //Verificar se a etapa e de finalizacao
                        if (fEvolucao.rEvolucao.St_finalizarOS)
                        {
                            (bsOrdemServico.Current as CamadaDados.Servicos.TRegistro_LanServico).St_os = "FE";
                            (bsOrdemServico.Current as CamadaDados.Servicos.TRegistro_LanServico).Dt_finalizada = DateTime.Now;
                        }
                        //Inserir novo registro
                        (bsOrdemServico.Current as CamadaDados.Servicos.TRegistro_LanServico).lEvolucao.Add(
                            fEvolucao.rEvolucao);
                        bsOrdemServico.ResetCurrentItem();
                    }
                }
            }
            else
                MessageBox.Show("Não existe ordem de serviço selecionada.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void afterAlterarEvolucao()
        {
            if (bsOrdemServico.Current != null)
            {
                if (bsEvolucao.Current == null)
                {
                    MessageBox.Show("Obrigatorio selecionar etapa para alterar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if ((bsEvolucao.Current as CamadaDados.Servicos.TRegistro_LanServicoEvolucao).St_evolucao == "E")
                {
                    MessageBox.Show("Não é permitido alterar etapa encerrada.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                using (TFLan_Evolucao_Ordem_Servico fEvolucao = new TFLan_Evolucao_Ordem_Servico())
                {
                    fEvolucao.St_altera = true;
                    fEvolucao.TP_Ordem = (bsOrdemServico.Current as CamadaDados.Servicos.TRegistro_LanServico).Tp_ordemstr;
                    fEvolucao.Etapa_atual = (bsEvolucao.Current as CamadaDados.Servicos.TRegistro_LanServicoEvolucao).Id_etapastr;
                    fEvolucao.rEvolucao = (bsEvolucao.Current as CamadaDados.Servicos.TRegistro_LanServicoEvolucao);
                    string cd_tecnico = (bsEvolucao.Current as CamadaDados.Servicos.TRegistro_LanServicoEvolucao).Cd_tecnico;
                    string nm_tecnico = (bsEvolucao.Current as CamadaDados.Servicos.TRegistro_LanServicoEvolucao).NM_Tecnico;
                    string ds_evolucao = (bsEvolucao.Current as CamadaDados.Servicos.TRegistro_LanServicoEvolucao).Ds_evolucao;
                    DateTime? dt_ini = (bsEvolucao.Current as CamadaDados.Servicos.TRegistro_LanServicoEvolucao).Dt_inicio;
                    DateTime? dt_prev = (bsEvolucao.Current as CamadaDados.Servicos.TRegistro_LanServicoEvolucao).Dt_previstatermino;
                    if (fEvolucao.ShowDialog() != DialogResult.OK)
                    {
                        (bsEvolucao.Current as CamadaDados.Servicos.TRegistro_LanServicoEvolucao).Cd_tecnico = cd_tecnico;
                        (bsEvolucao.Current as CamadaDados.Servicos.TRegistro_LanServicoEvolucao).NM_Tecnico = nm_tecnico;
                        (bsEvolucao.Current as CamadaDados.Servicos.TRegistro_LanServicoEvolucao).Ds_evolucao = ds_evolucao;
                        (bsEvolucao.Current as CamadaDados.Servicos.TRegistro_LanServicoEvolucao).Dt_inicio = dt_ini;
                        (bsEvolucao.Current as CamadaDados.Servicos.TRegistro_LanServicoEvolucao).Dt_previstatermino = dt_prev;

                        bsOrdemServico.ResetCurrentItem();
                    }
                }
            }
            else
                MessageBox.Show("Não existe ordem de serviço selecionada.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void afterInserirPecas(bool st_servico)
        {
            if (bsOrdemServico.Current != null)
            {
                using (TFLan_Pecas_Ordem_Servico fPecas = new TFLan_Pecas_Ordem_Servico())
                {
                    fPecas.CD_Empresa = CD_Empresa.Text;
                    fPecas.Nm_empresa = NM_Empresa.Text;
                    fPecas.CD_TabelaPreco = CD_TabelaPreco.Text;
                    fPecas.St_garantia = false;
                    fPecas.pSt_servico = st_servico;
                    if (st_servico && (bsOrdemServico.Current as CamadaDados.Servicos.TRegistro_LanServico).lPecas.Exists(p => !string.IsNullOrEmpty(p.Cd_tecnico) && p.St_servicobool))
                    {
                        fPecas.Cd_tecnico = (bsOrdemServico.Current as CamadaDados.Servicos.TRegistro_LanServico).lPecas.LastOrDefault(p => !string.IsNullOrEmpty(p.Cd_tecnico) && p.St_servicobool).Cd_tecnico;
                        fPecas.Nm_tecnico = (bsOrdemServico.Current as CamadaDados.Servicos.TRegistro_LanServico).lPecas.LastOrDefault(p => !string.IsNullOrEmpty(p.Cd_tecnico) && p.St_servicobool).Nm_tecnico;
                    }
                    else if (!st_servico && (bsOrdemServico.Current as CamadaDados.Servicos.TRegistro_LanServico).lPecas.Exists(p => !string.IsNullOrEmpty(p.Cd_tecnico) && p.St_servicobool == false))
                    {
                        fPecas.Cd_tecnico = (bsOrdemServico.Current as CamadaDados.Servicos.TRegistro_LanServico).lPecas.LastOrDefault(p => !string.IsNullOrEmpty(p.Cd_tecnico) && p.St_servicobool == false).Cd_tecnico;
                        fPecas.Nm_tecnico = (bsOrdemServico.Current as CamadaDados.Servicos.TRegistro_LanServico).lPecas.LastOrDefault(p => !string.IsNullOrEmpty(p.Cd_tecnico) && p.St_servicobool == false).Nm_tecnico;
                    }
                    if (fPecas.ShowDialog() == DialogResult.OK)
                    {
                        if (!st_servico)
                        {
                            //Se existir um registro para o produto, exclui
                            if ((!fPecas.rPeca.Cd_produto.Equals(string.Empty)) && (bsOrdemServico.Current as CamadaDados.Servicos.TRegistro_LanServico).lPecas.Exists(p => p.Cd_produto.Trim().Equals(fPecas.rPeca.Cd_produto.Trim())))
                            {
                                (bsOrdemServico.Current as CamadaDados.Servicos.TRegistro_LanServico).lPecas.Find(p => p.Cd_produto.Trim().Equals(fPecas.rPeca.Cd_produto.Trim())).Quantidade = fPecas.rPeca.Quantidade;
                                (bsOrdemServico.Current as CamadaDados.Servicos.TRegistro_LanServico).lPecas.Find(p => p.Cd_produto.Trim().Equals(fPecas.rPeca.Cd_produto.Trim())).Vl_unitario = fPecas.rPeca.Vl_unitario;
                                (bsOrdemServico.Current as CamadaDados.Servicos.TRegistro_LanServico).lPecas.Find(p => p.Cd_produto.Trim().Equals(fPecas.rPeca.Cd_produto.Trim())).Vl_subtotal = fPecas.rPeca.Vl_subtotal;
                                (bsOrdemServico.Current as CamadaDados.Servicos.TRegistro_LanServico).lPecas.Find(p => p.Cd_produto.Trim().Equals(fPecas.rPeca.Cd_produto.Trim())).Vl_desconto = fPecas.rPeca.Vl_desconto;
                                (bsOrdemServico.Current as CamadaDados.Servicos.TRegistro_LanServico).lPecas.Find(p => p.Cd_produto.Trim().Equals(fPecas.rPeca.Cd_produto.Trim())).Vl_SubTotalLiq = fPecas.rPeca.Vl_SubTotalLiq;
                                bsOrdemServico.ResetCurrentItem();
                                this.TotalizarPecasServicos();
                            }
                            else
                            {
                                //Inserir novo registro
                                (bsOrdemServico.Current as CamadaDados.Servicos.TRegistro_LanServico).lPecas.Add(fPecas.rPeca);
                                this.BuscaPecasServicos();
                                bsOrdemServico.ResetCurrentItem();
                                this.TotalizarPecasServicos();
                            }
                        }
                        else
                        {
                            //Se existir um registro para o produto, exclui
                            if ((!fPecas.rPeca.Cd_produto.Equals(string.Empty)) && (bsOrdemServico.Current as CamadaDados.Servicos.TRegistro_LanServico).lServico.Exists(p => p.Cd_produto.Trim().Equals(fPecas.rPeca.Cd_produto.Trim())))
                            {
                                (bsOrdemServico.Current as CamadaDados.Servicos.TRegistro_LanServico).lServico.Find(p => p.Cd_produto.Trim().Equals(fPecas.rPeca.Cd_produto.Trim())).Quantidade = fPecas.rPeca.Quantidade;
                                (bsOrdemServico.Current as CamadaDados.Servicos.TRegistro_LanServico).lServico.Find(p => p.Cd_produto.Trim().Equals(fPecas.rPeca.Cd_produto.Trim())).Vl_unitario = fPecas.rPeca.Vl_unitario;
                                (bsOrdemServico.Current as CamadaDados.Servicos.TRegistro_LanServico).lServico.Find(p => p.Cd_produto.Trim().Equals(fPecas.rPeca.Cd_produto.Trim())).Vl_subtotal = fPecas.rPeca.Vl_subtotal;
                                (bsOrdemServico.Current as CamadaDados.Servicos.TRegistro_LanServico).lServico.Find(p => p.Cd_produto.Trim().Equals(fPecas.rPeca.Cd_produto.Trim())).Vl_desconto = fPecas.rPeca.Vl_desconto;
                                (bsOrdemServico.Current as CamadaDados.Servicos.TRegistro_LanServico).lServico.Find(p => p.Cd_produto.Trim().Equals(fPecas.rPeca.Cd_produto.Trim())).Vl_SubTotalLiq = fPecas.rPeca.Vl_SubTotalLiq;
                                this.TotalizarPecasServicos();
                            }
                            else
                            {
                                //Inserir novo registro
                                (bsOrdemServico.Current as CamadaDados.Servicos.TRegistro_LanServico).lPecas.Add(fPecas.rPeca);
                                this.BuscaPecasServicos();
                                bsOrdemServico.ResetCurrentItem();
                                bsServico.ResetCurrentItem();
                                this.TotalizarPecasServicos();
                            }
                        }
                    }
                }
            }
            else
                MessageBox.Show("Não existe ordem de serviço selecionada.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void afterAlterarPecas(bool st_servico)
        {
            if (bsOrdemServico.Current != null)
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
                    fPeca.Nm_empresa = NM_Empresa.Text;
                    fPeca.CD_TabelaPreco = CD_TabelaPreco.Text;
                    fPeca.St_alterar = true;
                    fPeca.pSt_servico = st_servico;
                    CamadaDados.Servicos.TRegistro_LanServicosPecas rPecaServicos = new CamadaDados.Servicos.TRegistro_LanServicosPecas();
                    if (!st_servico)
                    {
                        rPecaServicos = (BS_Pecas.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas);
                        fPeca.rPeca = rPecaServicos;
                    }
                    else
                    {
                        rPecaServicos = (bsServico.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas);
                        fPeca.rPeca = rPecaServicos;
                    }
                    CamadaDados.Servicos.TRegistro_LanServicosPecas rPeca = new CamadaDados.Servicos.TRegistro_LanServicosPecas();
                    rPeca.Cd_produto = rPecaServicos.Cd_produto;
                    rPeca.Ds_produto = rPecaServicos.Ds_produto;
                    rPeca.Ds_unidproduto = rPecaServicos.Ds_unidproduto;
                    rPeca.Sigla_unidproduto = rPecaServicos.Sigla_unidproduto;
                    rPeca.Cd_local = rPecaServicos.Cd_local;
                    rPeca.Ds_local = rPecaServicos.Ds_local;
                    rPeca.Id_evolucao = rPecaServicos.Id_evolucao;
                    rPeca.Ds_observacao = rPecaServicos.Ds_observacao;
                    rPeca.Quantidade = rPecaServicos.Quantidade;
                    rPeca.Vl_desconto = rPecaServicos.Vl_desconto;
                    rPeca.Vl_subtotal = rPecaServicos.Vl_subtotal;
                    rPeca.Vl_SubTotalLiq = rPecaServicos.Vl_SubTotalLiq;
                    rPeca.Vl_unitario = rPecaServicos.Vl_unitario;
                    rPeca.St_atendimentogarantiabool = rPecaServicos.St_atendimentogarantiabool;
                    if (fPeca.ShowDialog() != DialogResult.OK)
                    {
                        rPecaServicos.Cd_produto = rPeca.Cd_produto;
                        rPecaServicos.Ds_produto = rPeca.Ds_produto;
                        rPecaServicos.Ds_unidproduto = rPeca.Ds_unidproduto;
                        rPecaServicos.Sigla_unidproduto = rPeca.Sigla_unidproduto;
                        rPecaServicos.Cd_local = rPeca.Cd_local;
                        rPecaServicos.Ds_local = rPeca.Ds_local;
                        rPecaServicos.Id_evolucao = rPeca.Id_evolucao;
                        rPecaServicos.Ds_observacao = rPeca.Ds_observacao;
                        rPecaServicos.Quantidade = rPeca.Quantidade;
                        rPecaServicos.Vl_desconto = rPeca.Vl_desconto;
                        rPecaServicos.Vl_subtotal = rPeca.Vl_subtotal;
                        rPecaServicos.Vl_SubTotalLiq = rPeca.Vl_SubTotalLiq;
                        rPecaServicos.Vl_unitario = rPeca.Vl_unitario;
                        rPecaServicos.St_atendimentogarantiabool = rPeca.St_atendimentogarantiabool;

                        if (!st_servico)
                            (bsOrdemServico.Current as CamadaDados.Servicos.TRegistro_LanServico).lPecas.Add(rPecaServicos);
                        else
                            (bsOrdemServico.Current as CamadaDados.Servicos.TRegistro_LanServico).lServico.Add(rPecaServicos);

                        bsOrdemServico.ResetCurrentItem();
                    }
                    this.TotalizarPecasServicos();
                }
            }
            else
                MessageBox.Show("Não existe peça(serviço) selecionado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void afterExcluirPecas(bool st_servico)
        {
            if (bsOrdemServico.Current != null)
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
                    {
                        //Adicionar item na lista a ser excluido
                        (bsOrdemServico.Current as CamadaDados.Servicos.TRegistro_LanServico).Deleta_lPecas.Add(
                            BS_Pecas.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas);
                        //Excluir item do grid
                        (bsOrdemServico.Current as CamadaDados.Servicos.TRegistro_LanServico).lPecas.Remove(
                            BS_Pecas.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas);
                        bsOrdemServico.ResetCurrentItem();
                        this.BuscaPecasServicos();
                        this.TotalizarPecasServicos();
                    }
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
                    {
                        //Adicionar item na lista a ser excluido
                        (bsOrdemServico.Current as CamadaDados.Servicos.TRegistro_LanServico).Deleta_lServico.Add(
                            bsServico.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas);
                        //Excluir item do grid
                        (bsOrdemServico.Current as CamadaDados.Servicos.TRegistro_LanServico).lPecas.Remove(
                            bsServico.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas);
                        bsOrdemServico.ResetCurrentItem();
                        this.BuscaPecasServicos();
                        this.TotalizarPecasServicos();
                    }
                }
            }
            else
                MessageBox.Show("Não existe ordem serviço selecionado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void TotalizarPecasServicos()
        {
            if (bsOrdemServico.Current != null)
            {
                if (tcCentral.SelectedTab.Equals(tpServico))
                {
                    tot_prodservico.Value = (bsOrdemServico.Current as CamadaDados.Servicos.TRegistro_LanServico).lPecas.Where(p => p.St_servicobool).Sum(p => p.Vl_subtotal);
                    tot_desconto.Value = (bsOrdemServico.Current as CamadaDados.Servicos.TRegistro_LanServico).lPecas.Where(p => p.St_servicobool).Sum(p => p.Vl_desconto);
                    tot_acrescimo.Value = (bsOrdemServico.Current as CamadaDados.Servicos.TRegistro_LanServico).lPecas.Where(p => p.St_servicobool).Sum(p => p.Vl_acrescimo);
                    tot_liquido.Value = (bsOrdemServico.Current as CamadaDados.Servicos.TRegistro_LanServico).lPecas.Where(p => p.St_servicobool).Sum(p => p.Vl_SubTotalLiq);
                }
                else if (tcCentral.SelectedTab.Equals(tpPecas))
                {
                    tot_prodservico.Value = (bsOrdemServico.Current as CamadaDados.Servicos.TRegistro_LanServico).lPecas.Where(p => !p.St_servicobool).Sum(p => p.Vl_subtotal);
                    tot_desconto.Value = (bsOrdemServico.Current as CamadaDados.Servicos.TRegistro_LanServico).lPecas.Where(p => !p.St_servicobool).Sum(p => p.Vl_desconto);
                    tot_acrescimo.Value = (bsOrdemServico.Current as CamadaDados.Servicos.TRegistro_LanServico).lPecas.Where(p => !p.St_servicobool).Sum(p => p.Vl_acrescimo);
                    tot_liquido.Value = (bsOrdemServico.Current as CamadaDados.Servicos.TRegistro_LanServico).lPecas.Where(p => !p.St_servicobool).Sum(p => p.Vl_SubTotalLiq);
                }
                else
                {
                    tot_prodservico.Value = (bsOrdemServico.Current as CamadaDados.Servicos.TRegistro_LanServico).lPecas.Sum(p => p.Vl_subtotal);
                    tot_desconto.Value = (bsOrdemServico.Current as CamadaDados.Servicos.TRegistro_LanServico).lPecas.Sum(p => p.Vl_desconto);
                    tot_acrescimo.Value = (bsOrdemServico.Current as CamadaDados.Servicos.TRegistro_LanServico).lPecas.Sum(p => p.Vl_acrescimo);
                    tot_liquido.Value = (bsOrdemServico.Current as CamadaDados.Servicos.TRegistro_LanServico).lPecas.Sum(p => p.Vl_SubTotalLiq);
                }
            }
        }

        private void afterInserirHistorico()
        {
            using (TFHistoricoOS fHist = new TFHistoricoOS())
            {
                if (fHist.ShowDialog() == DialogResult.OK)
                {
                    (bsOrdemServico.Current as CamadaDados.Servicos.TRegistro_LanServico).lHistorico.Add(fHist.rHist);
                    bsOrdemServico.ResetCurrentItem();
                }
            }
        }

        private void BuscaPecasServicos()
        {
            //Buscar Pecas 
            BS_Pecas.DataSource = (bsOrdemServico.Current as CamadaDados.Servicos.TRegistro_LanServico).lPecas.FindAll(p => p.St_servicobool == false);

            //Buscar Servicos
            bsServico.DataSource = (bsOrdemServico.Current as CamadaDados.Servicos.TRegistro_LanServico).lPecas.FindAll(p => p.St_servicobool);

        }

        private void TFEvoluirOSServico_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, g_Pecas);
            Utils.ShapeGrid.RestoreShape(this, gServico);
            Utils.ShapeGrid.RestoreShape(this, gEvolucao);
            Utils.ShapeGrid.RestoreShape(this, gHistorico);
            pOS.set_FormatZero();
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            bsOrdemServico.DataSource = new CamadaDados.Servicos.TList_LanServico() { rOS };
            this.BuscaPecasServicos();
            this.TotalizarPecasServicos();
            CD_Endereco.Enabled = !string.IsNullOrEmpty(CD_Endereco.Text);
            BB_Endereco.Enabled = !string.IsNullOrEmpty(CD_Endereco.Text);
        }

        private void CD_Clifor_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + CD_Clifor.Text.Trim() + "'",
                                                    new Componentes.EditDefault[] { CD_Clifor, NM_Clifor },
                                                    new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
            if (!string.IsNullOrEmpty(CD_Clifor.Text))
            {
                //Buscar endereco
                this.BuscarEndereco();
                NM_Clifor.Enabled = false;
                CD_Endereco.Enabled = true;
                BB_Endereco.Enabled = true;
                DS_Endereco.Enabled = false;
                DS_Cidade.Enabled = false;
                UF.Enabled = false;
                Fone.Enabled = false;
            }
            else
            {
                NM_Clifor.Enabled = true;
                CD_Endereco.Enabled = false;
                BB_Endereco.Enabled = false;
                DS_Endereco.Enabled = true;
                DS_Cidade.Enabled = true;
                UF.Enabled = true;
                Fone.Enabled = true;
                CD_Endereco.Clear();
                DS_Endereco.Clear();
                DS_Cidade.Clear();
                UF.Clear();
                Fone.Clear();
            }
        }

        private void BB_Clifor_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { CD_Clifor, NM_Clifor }, string.Empty);
            if (!string.IsNullOrEmpty(CD_Clifor.Text))
            {
                //Buscar endereco
                this.BuscarEndereco();
                NM_Clifor.Enabled = false;
                CD_Endereco.Enabled = true;
                BB_Endereco.Enabled = true;
                DS_Endereco.Enabled = false;
                DS_Cidade.Enabled = false;
                UF.Enabled = false;
                Fone.Enabled = false;
            }
            else
            {
                NM_Clifor.Enabled = true;
                CD_Endereco.Enabled = false;
                BB_Endereco.Enabled = false;
                DS_Endereco.Enabled = true;
                DS_Cidade.Enabled = true;
                UF.Enabled = true;
                Fone.Enabled = true;
                CD_Endereco.Clear();
                DS_Endereco.Clear();
                DS_Cidade.Clear();
                UF.Clear();
                Fone.Clear();
            }
        }

        private void bb_cadclifor_Click(object sender, EventArgs e)
        {
            using (Financeiro.Cadastros.TFCadCliforResumido fClifor = new Financeiro.Cadastros.TFCadCliforResumido())
            {
                if (fClifor.ShowDialog() == DialogResult.OK)
                    try
                    {
                        CamadaNegocio.Financeiro.Cadastros.TCN_CadClifor.Gravar(fClifor.rClifor, null);
                        MessageBox.Show("Cliente cadastrado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CD_Clifor.Text = fClifor.rClifor.Cd_clifor;
                        NM_Clifor.Text = fClifor.rClifor.Nm_clifor;
                        CD_Endereco.Text = fClifor.rClifor.lEndereco[0].Cd_endereco;
                        DS_Endereco.Text = fClifor.rClifor.lEndereco[0].Ds_endereco;
                        DS_Cidade.Text = fClifor.rClifor.lEndereco[0].DS_Cidade;
                        UF.Text = fClifor.rClifor.lEndereco[0].UF;
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void CD_Endereco_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_clifor|=|'" + CD_Clifor.Text.Trim() + "';" +
                            "a.cd_endereco|=|'" + CD_Endereco.Text.Trim() + "'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { CD_Endereco, DS_Endereco, DS_Cidade, UF, Fone },
                                                new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco());
        }

        private void BB_Endereco_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_endereco|Endereco|150;" +
                              "a.cd_endereco|Código Endereço|80;" +
                              "a.Fone|Fone|60;" +
                              "b.DS_Cidade|Cidade|250;" +
                              "UF|Estado|150";
            string vParam = "a.cd_clifor|=|'" + CD_Clifor.Text.Trim() + "'";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_Endereco, DS_Endereco, DS_Cidade, UF, Fone },
                                                new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco(), vParam);
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btn_Inserir_Item_Click(object sender, EventArgs e)
        {
            this.afterInserirEvolucao();
        }

        private void BB_Alterar_Item_Click(object sender, EventArgs e)
        {
            this.afterAlterarEvolucao();
        }

        private void btn_Insere_Pecas_Click(object sender, EventArgs e)
        {
            this.afterInserirPecas(false);
        }

        private void bb_alterar_pecas_Click(object sender, EventArgs e)
        {
            this.afterAlterarPecas(false);
        }

        private void btn_Deleta_Pecas_Click(object sender, EventArgs e)
        {
            this.afterExcluirPecas(false);
        }

        private void TFEvoluirOSServico_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.DialogResult = DialogResult.OK;
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
            else if (tcCentral.SelectedTab.Equals(tpEvolucao) && e.Control && e.KeyCode.Equals(Keys.F10))
                this.afterInserirEvolucao();
            else if (tcCentral.SelectedTab.Equals(tpEvolucao) && e.Control && e.KeyCode.Equals(Keys.F11))
                this.afterAlterarEvolucao();
            else if (tcCentral.SelectedTab.Equals(tpPecas) && e.Control && e.KeyCode.Equals(Keys.F10))
                this.afterInserirPecas(false);
            else if (tcCentral.SelectedTab.Equals(tpPecas) && e.Control && e.KeyCode.Equals(Keys.F11))
                this.afterAlterarPecas(false);
            else if (tcCentral.SelectedTab.Equals(tpPecas) && e.Control && e.KeyCode.Equals(Keys.F12))
                this.afterExcluirPecas(false);
            else if (tcCentral.SelectedTab.Equals(tpServico) && e.Control && e.KeyCode.Equals(Keys.F10))
                this.afterInserirPecas(true);
            else if (tcCentral.SelectedTab.Equals(tpServico) && e.Control && e.KeyCode.Equals(Keys.F11))
                this.afterAlterarPecas(true);
            else if (tcCentral.SelectedTab.Equals(tpServico) && e.Control && e.KeyCode.Equals(Keys.F12))
                this.afterExcluirPecas(true);
            else if (tcCentral.SelectedTab.Equals(tpHistorico) && e.Control && e.KeyCode.Equals(Keys.F10))
                this.afterInserirHistorico();
        }

        private void bb_inserirHistorico_Click(object sender, EventArgs e)
        {
            this.afterInserirHistorico();
        }

        private void InserirServicos_Click(object sender, EventArgs e)
        {
            this.afterInserirPecas(true);
        }

        private void AlterarServicos_Click(object sender, EventArgs e)
        {
            this.afterAlterarPecas(true);
        }

        private void excluirServicos_Click(object sender, EventArgs e)
        {
            this.afterExcluirPecas(true);
        }

        private void TFEvoluirOSServico_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, g_Pecas);
            Utils.ShapeGrid.SaveShape(this, gServico);
            Utils.ShapeGrid.SaveShape(this, gEvolucao);
            Utils.ShapeGrid.SaveShape(this, gHistorico);
        }

        private void pc_desconto_Leave(object sender, EventArgs e)
        {
            (bsOrdemServico.Current as CamadaDados.Servicos.TRegistro_LanServico).Pc_desconto = pc_desconto.Value;
            CamadaNegocio.Servicos.TCN_LanServico.RateiaDescontoItens(bsOrdemServico.Current as CamadaDados.Servicos.TRegistro_LanServico, true);
            this.TotalizarPecasServicos();
        }

        private void tot_desconto_Leave(object sender, EventArgs e)
        {
            (bsOrdemServico.Current as CamadaDados.Servicos.TRegistro_LanServico).Vl_desconto = tot_desconto.Value;
            CamadaNegocio.Servicos.TCN_LanServico.RateiaDescontoItens(bsOrdemServico.Current as CamadaDados.Servicos.TRegistro_LanServico, false);
            this.TotalizarPecasServicos();
        }

        private void pc_acrescimo_Leave(object sender, EventArgs e)
        {
            (bsOrdemServico.Current as CamadaDados.Servicos.TRegistro_LanServico).Pc_acrescimo = pc_acrescimo.Value;
            CamadaNegocio.Servicos.TCN_LanServico.RateiaAcrescimoItens(bsOrdemServico.Current as CamadaDados.Servicos.TRegistro_LanServico, true);
            this.TotalizarPecasServicos();
        }

        private void tot_acrescimo_Leave(object sender, EventArgs e)
        {
            (bsOrdemServico.Current as CamadaDados.Servicos.TRegistro_LanServico).Vl_acrescimo = tot_acrescimo.Value;
            CamadaNegocio.Servicos.TCN_LanServico.RateiaAcrescimoItens(bsOrdemServico.Current as CamadaDados.Servicos.TRegistro_LanServico, false);
            this.TotalizarPecasServicos();
        }
    }
}
