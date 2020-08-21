using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using Utils;
using System.Text;
using System.Windows.Forms;
using FormBusca;
using Utils;

namespace Servicos
{
    public partial class TFAbrirOSServico : Form
    {
        public CamadaDados.Servicos.TRegistro_LanServico rOS
        { get { return bsOrdemServico.Current as CamadaDados.Servicos.TRegistro_LanServico; } }

        public TFAbrirOSServico()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if (pDados.validarCampoObrigatorio())
            {
                if (string.IsNullOrEmpty(CD_Clifor.Text) &&
                    string.IsNullOrEmpty(NM_Clifor.Text))
                {
                    MessageBox.Show("Obrigatorio informar cliente.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (!CD_Clifor.Focus())
                        NM_Clifor.Focus();
                    return;
                }
                this.DialogResult = DialogResult.OK;
            }
        }

        private void ValidarNumeroOs()
        {
            object obj = new CamadaDados.Servicos.TCD_LanServico().BuscarEscalar(
                new Utils.TpBusca[]
                {
                    new Utils.TpBusca()
                    {
                        vNM_Campo = "a.cd_empresa",
                        vOperador = "=",
                        vVL_Busca = "'" + CD_Empresa.Text.Trim() + "'"
                    },
                    new Utils.TpBusca()
                    {
                        vNM_Campo = "a.id_os",
                        vOperador = "=",
                        vVL_Busca = id_os.Value.ToString()
                    }
                }, "1");

            if (obj != null)
            {
                MessageBox.Show("Ja existe uma ordem de serviço com este numero para a empresa " + CD_Empresa.Text.Trim() + ".",
                                "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                id_os.Value = id_os.Minimum;
                id_os.Focus();
            }
        }

        private void InfData()
        {
            try
            {
                object obj = new CamadaDados.Servicos.Cadastros.TCD_TpOrdem().BuscarEscalar(
                    new TpBusca[]
                {
                    new TpBusca()
                    {
                        vNM_Campo = "a.TP_Ordem",
                        vOperador = "=",
                        vVL_Busca = "'" + TP_Ordem.Text.Trim() + "'"  
                    }
                }, "a.ST_InfDtAbertura");

                if (obj.Equals("S"))
                    DT_Abertura.Enabled = true;
                else
                    DT_Abertura.Enabled = false;
            }
            catch { }
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
                    if (!st_servico)
                        BS_Pecas.ResetCurrentItem();
                    else bsServico.ResetCurrentItem();
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
                MessageBox.Show("Não existe ordem Peça/Serviço selecionado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void TotalizarPecasServicos()
        {
            if (bsOrdemServico.Current != null)
            {
                pc_desconto.Value = decimal.Zero;
                pc_acrescimo.Value = decimal.Zero;
                tot_prodservico.Value = (bsOrdemServico.Current as CamadaDados.Servicos.TRegistro_LanServico).lPecas.Sum(p => p.Vl_subtotal);
                tot_desconto.Value = (bsOrdemServico.Current as CamadaDados.Servicos.TRegistro_LanServico).lPecas.Sum(p => p.Vl_desconto);
                tot_acrescimo.Value = (bsOrdemServico.Current as CamadaDados.Servicos.TRegistro_LanServico).lPecas.Sum(p => p.Vl_acrescimo);
                tot_liquido.Value = (bsOrdemServico.Current as CamadaDados.Servicos.TRegistro_LanServico).lPecas.Sum(p => p.Vl_SubTotalLiq);
                if (tot_prodservico.Value > decimal.Zero)
                {
                    pc_desconto.Value = Math.Round(decimal.Divide(decimal.Multiply(tot_desconto.Value, 100), tot_prodservico.Value), 5, MidpointRounding.AwayFromZero);
                    pc_acrescimo.Value = Math.Round(decimal.Divide(decimal.Multiply(tot_acrescimo.Value, 100), tot_prodservico.Value), 5, MidpointRounding.AwayFromZero);
                }
            }
        }

        private void BuscaPecasServicos()
        {
            //Buscar Pecas 
            BS_Pecas.DataSource = (bsOrdemServico.Current as CamadaDados.Servicos.TRegistro_LanServico).lPecas.FindAll(p => !p.St_servicobool);
            //Buscar Servicos
            bsServico.DataSource = (bsOrdemServico.Current as CamadaDados.Servicos.TRegistro_LanServico).lPecas.FindAll(p => p.St_servicobool);
        }

        private void TFAbrirOSServico_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gServico);
            Utils.ShapeGrid.RestoreShape(this, g_Pecas);
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pDados.set_FormatZero();
            //Adicionar nova OS
            bsOrdemServico.AddNew();
            DT_Abertura.Enabled = false;
        }

        private void BB_Empresa_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { CD_Empresa, NM_Empresa }, string.Empty);
        }

        private void CD_Empresa_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + CD_Empresa.Text.Trim() + "'", new Componentes.EditDefault[] { CD_Empresa, NM_Empresa });
        }

        private void BB_TPOrdem_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_tipoordem|Tipo Ordem|200;" +
                              "a.tp_ordem|TP. Ordem|80;" +
                              "b.cd_tabelapreco|Cd. Tabela|80;" +
                              "c.ds_tabelapreco|Tabela Preço|200";
            string vParam = "||(a.tp_os = 'S') or (a.tp_os = 'I');" +
                            "|exists|(select 1 from tb_ose_paramos x " +
                            "           where x.tp_ordem = a.tp_ordem)";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { TP_Ordem, DS_TPOrdem, CD_TabelaPreco, NM_TabelaPreco },
                                            new CamadaDados.Servicos.Cadastros.TCD_TpOrdem(), vParam);
            if (!string.IsNullOrEmpty(TP_Ordem.Text))
            {
                id_os.Enabled = CamadaNegocio.Servicos.TCN_LanServico.SequenciaManual(bsOrdemServico.Current as CamadaDados.Servicos.TRegistro_LanServico, null);
                if (!id_os.Enabled)
                    id_os.Value = id_os.Minimum;
            }
            this.InfData();
        }

        private void TP_Ordem_Leave(object sender, EventArgs e)
        {
            string vParam = "a.tp_ordem|=|" + TP_Ordem.Text + ";" +
                            "||(a.tp_os = 'S') or (a.tp_os = 'I');" +
                            "|exists|(select 1 from tb_ose_paramos x " +
                            "           where x.tp_ordem = a.tp_ordem)";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { TP_Ordem, DS_TPOrdem, CD_TabelaPreco, NM_TabelaPreco },
                                            new CamadaDados.Servicos.Cadastros.TCD_TpOrdem());
            if (!string.IsNullOrEmpty(TP_Ordem.Text))
            {
                id_os.Enabled = CamadaNegocio.Servicos.TCN_LanServico.SequenciaManual(bsOrdemServico.Current as CamadaDados.Servicos.TRegistro_LanServico, null);
                if (!id_os.Enabled)
                    id_os.Value = id_os.Minimum;
            }
            this.InfData();
        }

        private void id_os_Leave(object sender, EventArgs e)
        {
            this.ValidarNumeroOs();
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
                              "a.fone|Fone|60;" +
                              "b.DS_Cidade|Cidade|250;" +
                              "UF|Estado|150";
            string vParam = "a.cd_clifor|=|'" + CD_Clifor.Text.Trim() + "'";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_Endereco, DS_Endereco, DS_Cidade, UF, Fone },
                                                new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco(), vParam);
        }

        private void CD_TabelaPreco_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LEAVE("a.cd_tabelapreco|=|'" + CD_TabelaPreco.Text.Trim() + "'",
                                                new Componentes.EditDefault[] { CD_TabelaPreco, NM_TabelaPreco },
                                                new CamadaDados.Diversos.TCD_CadTbPreco());
        }

        private void BB_TabelaPreco_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_tabelapreco|Tabela Preço|200;" +
                              "a.cd_tabelapreco|Cd. Tabela|80";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_TabelaPreco, NM_TabelaPreco },
                                            new CamadaDados.Diversos.TCD_CadTbPreco(), string.Empty);
        }

        private void DT_Prevista_Leave(object sender, EventArgs e)
        {
            if (DT_Abertura.Data > DT_Prevista.Data)
            {
                MessageBox.Show("Dt.Prevista menor do que a Dt.Abertura!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DT_Prevista.Clear();
                DT_Prevista.Focus();
            }
        }

        private void btn_Insere_Pecas_Click(object sender, EventArgs e)
        {
            this.afterInserirPecas(false);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.afterAlterarPecas(false);
        }

        private void btn_Deleta_Pecas_Click(object sender, EventArgs e)
        {
            this.afterExcluirPecas(false);
        }

        private void TFAbrirOSServico_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
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
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
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

        private void TFAbrirOSServico_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gServico);
            Utils.ShapeGrid.SaveShape(this, g_Pecas);
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

        private void Fone_TextChanged(object sender, EventArgs e)
        {
            if (Fone.Text.SoNumero().Length.Equals(10))
            {
                Fone.Text = "(" + Fone.Text.SoNumero().Substring(0, 2) + ")" + Fone.Text.SoNumero().Substring(2, 4) + "-" + Fone.Text.SoNumero().Substring(6, 4);
                Fone.SelectionStart = Fone.Text.Length;
            }
            else if (Fone.Text.SoNumero().Length.Equals(11))
                if (Fone.Text.SoNumero().Substring(0, 1).Equals("0"))
                {
                    Fone.Text = "(" + Fone.Text.SoNumero().Substring(0, 3) + ")" + Fone.Text.SoNumero().Substring(3, 4) + "-" + Fone.Text.SoNumero().Substring(7, 4);
                    Fone.SelectionStart = Fone.Text.Length;
                }
                else
                {
                    Fone.Text = "(" + Fone.Text.SoNumero().Substring(0, 2) + ")" + Fone.Text.SoNumero().Substring(2, 5) + "-" + Fone.Text.SoNumero().Substring(7, 4);
                    Fone.SelectionStart = Fone.Text.Length;
                }
            else if (Fone.Text.SoNumero().Length.Equals(12))
            {
                Fone.Text = "(" + Fone.Text.SoNumero().Substring(0, 3) + ")" + Fone.Text.SoNumero().Substring(3, 5) + "-" + Fone.Text.SoNumero().Substring(8, 4);
                Fone.SelectionStart = Fone.Text.Length;
            }
        }

        private void CD_Endereco_TextChanged(object sender, EventArgs e)
        {
            DS_Endereco.Enabled = string.IsNullOrEmpty(CD_Endereco.Text);
            DS_Cidade.Enabled = string.IsNullOrEmpty(CD_Endereco.Text);
            UF.Enabled = string.IsNullOrEmpty(CD_Endereco.Text);
            Fone.Enabled = string.IsNullOrEmpty(CD_Endereco.Text);
        }

        

        private void bbCondPagt_Click(object sender, EventArgs e)
        {
            string vParam = string.Empty;
            //Verificar se condicao de pagamento para o vendedor
            object obj = null;
            // if (!string.IsNullOrEmpty(CD_CompVend.Text))
            obj = new CamadaDados.Faturamento.Cadastros.TCD_Vendedor_X_CondPgto().BuscarEscalar(
                    new Utils.TpBusca[]
                        {
                            new Utils.TpBusca()
                            {
                                vNM_Campo = string.Empty,
                                vOperador = "exists",
                                vVL_Busca = "(select 1 from tb_fat_vendedor_x_condpgto x " +
                                            "where x.cd_condpgto = a.cd_condpgto "
                                            //+
                                          //  "and x.cd_vendedor = '" + CD_CompVend.Text.Trim() + "')"
                            }
                        }, "1");
            if (obj == null ? false : obj.ToString().Trim().Equals("1"))
                vParam = "|exists|(select 1 from tb_fat_vendedor_x_condpgto x " +
                         "          where x.cd_condpgto = a.cd_condpgto ";//+
            // "          and x.cd_vendedor = '" + CD_CompVend.Text.Trim() + "')";
            UtilPesquisa.BTN_BUSCA("a.DS_CondPGTO|Condição Pagamento|300;a.QT_Parcelas|Quantidade Parcelas|40;" +
            "a.ST_ComEntrada|Entrada|40;a.QT_DiasDesdobro|Dias Desdobro|40;a.ST_VenctoEmFeriado|Vence em Feriado|40;a.cd_condPGTO|Código|100;a.ST_SolicitarDtVencto|Solicitar Data Vencimento|100"
              , new Componentes.EditDefault[] { cd_condPagto, ds_condPagto/*, Parcelas_Dias_Desdobro, Parcelas_Entrada, Parcelas_Feriado, ST_SolicitarDtVencto */},
              new CamadaDados.Financeiro.Cadastros.TCD_CadCondPgto(), vParam);
            //   CD_CondPGTO_Leave(this, new EventArgs()); 
        }

        private void cd_condPagto_Leave(object sender, EventArgs e)
        {

            string vParam = "CD_CondPGTO|=|'" + cd_condPagto.Text.Trim() + "'";
            object obj = null;
            obj = new CamadaDados.Faturamento.Cadastros.TCD_Vendedor_X_CondPgto().BuscarEscalar(
                    new Utils.TpBusca[]
                        {
                            new Utils.TpBusca()
                            {
                                vNM_Campo = string.Empty,
                                vOperador = "exists",
                                vVL_Busca = "(select 1 from tb_fat_vendedor_x_condpgto x " +
                                            "where x.cd_condpgto = a.cd_condpgto " 
                            }
                        }, "1");
            if (obj == null ? false : obj.ToString().Trim().Equals("1"))
                vParam += ";|exists|(select 1 from tb_fat_vendedor_x_condpgto x " +
                          "             where x.cd_condpgto = a.cd_condpgto ";
            DataRow linha = UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_condPagto, ds_condPagto },
             new CamadaDados.Financeiro.Cadastros.TCD_CadCondPgto());
        }

    }
}
