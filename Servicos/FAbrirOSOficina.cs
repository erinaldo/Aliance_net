using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Utils;

namespace Servicos
{
    public partial class TFServicoOficina : Form
    {
        public CamadaDados.Servicos.TRegistro_LanServico rOS
        { get { return bsOrdemServico.Current as CamadaDados.Servicos.TRegistro_LanServico; } }

        public TFServicoOficina()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if (pOs.validarCampoObrigatorio())
            {
                if (string.IsNullOrEmpty(CD_Clifor.Text) &&
                    string.IsNullOrEmpty(NM_Clifor.Text))
                {
                    MessageBox.Show("Obrigatorio informar cliente.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (!CD_Clifor.Focus())
                        NM_Clifor.Focus();
                    return;
                }
                DialogResult = DialogResult.OK;
            }
        }

        private void ValidarNumeroOs()
        {
            object obj = new CamadaDados.Servicos.TCD_LanServico().BuscarEscalar(
                new TpBusca[]
                {
                    new TpBusca()
                    {
                        vNM_Campo = "a.cd_empresa",
                        vOperador = "=",
                        vVL_Busca = "'" + cbEmpresa.SelectedValue.ToString() + "'"
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "a.id_os",
                        vOperador = "=",
                        vVL_Busca = id_os.Value.ToString()
                    }
                }, "1");

                if (obj != null)
                {
                    MessageBox.Show("Ja existe uma ordem de serviço com este numero para a empresa " + cbEmpresa.SelectedValue.ToString() + ".",
                                    "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    id_os.Value = id_os.Minimum;
                    id_os.Focus();
                }
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

        private void BuscarVeiculoCliente()
        {
            if (!string.IsNullOrEmpty(CD_Clifor.Text))
            {
                CamadaDados.Servicos.Cadastros.TList_VeiculoCliente lVeic =
                    CamadaNegocio.Servicos.Cadastros.TCN_VeiculoCliente.Buscar(CD_Clifor.Text,
                                                                               string.Empty,
                                                                               string.Empty,
                                                                               string.Empty,
                                                                               string.Empty,
                                                                               "'A'",
                                                                               null);
                if (lVeic.Count > 0)
                {
                    if (lVeic.Count.Equals(1))
                    {
                        placaveiculo.Text = lVeic[0].Placaveiculo;
                        ds_veiculo.Text = lVeic[0].Ds_veiculo;
                        ds_marca.Text = lVeic[0].Ds_marca;
                        ds_obsveiculo.Text = lVeic[0].Ds_observacao;

                        placaveiculo.Enabled = false;
                        ds_veiculo.Enabled = false;
                        ds_marca.Enabled = false;
                        ds_obsveiculo.Enabled = false;
                    }
                    else
                        using (TFListaVeiculoCliente fLista = new TFListaVeiculoCliente())
                        {
                            fLista.lVeiculo = lVeic;
                            if (fLista.ShowDialog() == DialogResult.OK)
                                if (fLista.lVeiculo.Exists(p => p.St_processar))
                                {
                                    placaveiculo.Text = fLista.lVeiculo.Find(p => p.St_processar).Placaveiculo;
                                    ds_veiculo.Text = fLista.lVeiculo.Find(p => p.St_processar).Ds_veiculo;
                                    ds_marca.Text = fLista.lVeiculo.Find(p => p.St_processar).Ds_marca;
                                    ds_obsveiculo.Text = fLista.lVeiculo.Find(p => p.St_processar).Ds_observacao;

                                    placaveiculo.Enabled = false;
                                    ds_veiculo.Enabled = false;
                                    ds_marca.Enabled = false;
                                    ds_obsveiculo.Enabled = false;
                                }
                                else
                                {
                                    placaveiculo.Enabled = true;
                                    ds_veiculo.Enabled = true;
                                    ds_marca.Enabled = true;
                                    ds_obsveiculo.Enabled = true;
                                }
                        }
                }
                else
                {
                    placaveiculo.Enabled = true;
                    ds_veiculo.Enabled = true;
                    ds_marca.Enabled = true;
                    ds_obsveiculo.Enabled = true;
                }
            }
        }

        private void afterInserirPecas(bool st_servico)
        {
            if (bsOrdemServico.Current != null)
            {
                using (TFLan_Pecas_Ordem_Servico fPecas = new TFLan_Pecas_Ordem_Servico())
                {
                    fPecas.CD_Empresa = (cbEmpresa.SelectedItem as CamadaDados.Diversos.TRegistro_CadEmpresa).Cd_empresa;
                    fPecas.Nm_empresa = (cbEmpresa.SelectedItem as CamadaDados.Diversos.TRegistro_CadEmpresa).Nm_empresa;
                    fPecas.Cd_clifor = (bsOrdemServico.Current as CamadaDados.Servicos.TRegistro_LanServico).Cd_clifor;
                    fPecas.CD_TabelaPreco = CD_TabelaPreco.Text;
                    fPecas.St_acrescbasedesc = cbTpOrdem.SelectedItem != null ? (cbTpOrdem.SelectedItem as CamadaDados.Servicos.Cadastros.TRegistro_OSE_ParamOS).St_acrescbasedescbool : false;
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
                                TotalizarPecasServicos();
                            }
                            else
                            {
                                //Inserir novo registro
                                (bsOrdemServico.Current as CamadaDados.Servicos.TRegistro_LanServico).lPecas.Add(fPecas.rPeca);
                                BuscaPecasServicos();
                                bsOrdemServico.ResetCurrentItem();
                                TotalizarPecasServicos();
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
                                TotalizarPecasServicos();
                            }
                            else
                            {
                                //Inserir novo registro
                                (bsOrdemServico.Current as CamadaDados.Servicos.TRegistro_LanServico).lPecas.Add(fPecas.rPeca);
                                BuscaPecasServicos();
                                bsOrdemServico.ResetCurrentItem();
                                bsServico.ResetCurrentItem();
                                TotalizarPecasServicos();
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
                    fPeca.CD_Empresa = (cbEmpresa.SelectedItem as CamadaDados.Diversos.TRegistro_CadEmpresa).Cd_empresa;
                    fPeca.Nm_empresa = (cbEmpresa.SelectedItem as CamadaDados.Diversos.TRegistro_CadEmpresa).Nm_empresa;
                    fPeca.CD_TabelaPreco = CD_TabelaPreco.Text;
                    fPeca.St_acrescbasedesc = cbTpOrdem.SelectedItem != null ? (cbTpOrdem.SelectedItem as CamadaDados.Servicos.Cadastros.TRegistro_OSE_ParamOS).St_acrescbasedescbool : false;
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
                    TotalizarPecasServicos();
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
                        BuscaPecasServicos();
                        TotalizarPecasServicos();
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
                        BuscaPecasServicos();
                        TotalizarPecasServicos();
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
                if (tcCentral.SelectedTab.Equals(tpServicos))
                {
                     //Total Serviços
                    pc_desconto.Value = decimal.Zero;
                    tot_prodservico.Value = (bsOrdemServico.Current as CamadaDados.Servicos.TRegistro_LanServico).lPecas.FindAll(p=> p.St_servicobool).Sum(p => p.Vl_subtotal);
                    tot_desconto.Value = (bsOrdemServico.Current as CamadaDados.Servicos.TRegistro_LanServico).lPecas.FindAll(p => p.St_servicobool).Sum(p => p.Vl_desconto);
                    tot_acrescimo.Value = (bsOrdemServico.Current as CamadaDados.Servicos.TRegistro_LanServico).lPecas.FindAll(p => p.St_servicobool).Sum(p => p.Vl_acrescimo);
                    tot_liquido.Value = (bsOrdemServico.Current as CamadaDados.Servicos.TRegistro_LanServico).lPecas.FindAll(p => p.St_servicobool).Sum(p => p.Vl_SubTotalLiq);
                    if (tot_prodservico.Value > decimal.Zero)
                    {
                        pc_desconto.Value = tot_desconto.Value * 100 / tot_prodservico.Value;
                        pc_acrescimo.Value = tot_acrescimo.Value * 100 / tot_prodservico.Value;
                    }
                } 
                else
                {
                    //Total Peças
                    pc_desconto.Value = decimal.Zero;
                    tot_prodservico.Value = (bsOrdemServico.Current as CamadaDados.Servicos.TRegistro_LanServico).lPecas.FindAll(p=> !p.St_servicobool).Sum(p => p.Vl_subtotal);
                    tot_desconto.Value = (bsOrdemServico.Current as CamadaDados.Servicos.TRegistro_LanServico).lPecas.FindAll(p => !p.St_servicobool).Sum(p => p.Vl_desconto);
                    tot_acrescimo.Value = (bsOrdemServico.Current as CamadaDados.Servicos.TRegistro_LanServico).lPecas.FindAll(p => !p.St_servicobool).Sum(p => p.Vl_acrescimo);
                    tot_liquido.Value = (bsOrdemServico.Current as CamadaDados.Servicos.TRegistro_LanServico).lPecas.FindAll(p => !p.St_servicobool).Sum(p => p.Vl_SubTotalLiq);
                    if (tot_prodservico.Value > decimal.Zero)
                    {
                        pc_desconto.Value = tot_desconto.Value * 100 / tot_prodservico.Value;
                        pc_acrescimo.Value = tot_acrescimo.Value * 100 / tot_prodservico.Value;
                    }
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

        private void TFServicoOficina_Load(object sender, EventArgs e)
        {
            ShapeGrid.RestoreShape(this, gPecas);
            Icon = ResourcesUtils.TecnoAliance_ICO;
            pOs.set_FormatZero();
            //Adicionar nova OS
            bsOrdemServico.AddNew();
            cbEmpresa.DataSource = new CamadaDados.Diversos.TCD_CadEmpresa().Select(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = string.Empty,
                                            vOperador = "exists",
                                            vVL_Busca = "(select 1 from tb_div_usuario_x_empresa x " +
                                                        "where x.cd_empresa = a.cd_empresa " +
                                                        "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                                        "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                                        "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))"
                                        }
                                    }, 0, string.Empty);
            cbEmpresa.DisplayMember = "NM_Empresa";
            cbEmpresa.ValueMember = "CD_Empresa";
            //Tipo Ordem
            cbTpOrdem.DataSource = new CamadaDados.Servicos.Cadastros.TCD_OSE_ParamOS().Select(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = "b.tp_os",
                                            vOperador = "=",
                                            vVL_Busca = "'O'"
                                        }
                                    }, 0, string.Empty);
            cbTpOrdem.DisplayMember = "ds_tipoordem";
            cbTpOrdem.ValueMember = "tp_ordem";
        }
        
        private void id_os_Leave(object sender, EventArgs e)
        {
            ValidarNumeroOs();
        }

        private void BB_Clifor_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { CD_Clifor, NM_Clifor }, string.Empty);
            if (!string.IsNullOrEmpty(CD_Clifor.Text))
            {
                //Buscar endereco
                BuscarEndereco();
                //Buscar veiculo cliente
                BuscarVeiculoCliente();
                NM_Clifor.Enabled = false;
                CD_Endereco.Enabled = true;
                BB_Endereco.Enabled = true;
                DS_Endereco.Enabled = false;
                DS_Cidade.Enabled = false;
                UF.Enabled = false;
            }
            else
            {
                NM_Clifor.Enabled = true;
                CD_Endereco.Enabled = false;
                BB_Endereco.Enabled = false;
                DS_Endereco.Enabled = true;
                DS_Cidade.Enabled = true;
                UF.Enabled = true;
                CD_Endereco.Clear();
                DS_Endereco.Clear();
                DS_Cidade.Clear();
                UF.Clear();
                placaveiculo.Clear();
                ds_veiculo.Clear();
                ds_marca.Clear();
                ds_obsveiculo.Clear();
                placaveiculo.Enabled = true;
                ds_veiculo.Enabled = true;
                ds_marca.Enabled = true;
                ds_obsveiculo.Enabled = true;
            }
        }

        private void CD_Clifor_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + CD_Clifor.Text.Trim() + "'",
                                                    new Componentes.EditDefault[] { CD_Clifor, NM_Clifor },
                                                    new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
            if (!string.IsNullOrEmpty(CD_Clifor.Text))
            {
                //Buscar endereco
                BuscarEndereco();
                //Buscar veiculo cliente
                BuscarVeiculoCliente();
                NM_Clifor.Enabled = false;
                CD_Endereco.Enabled = true;
                BB_Endereco.Enabled = true;
                DS_Endereco.Enabled = false;
                DS_Cidade.Enabled = false;
                UF.Enabled = false;
            }
            else
            {
                NM_Clifor.Enabled = true;
                CD_Endereco.Enabled = false;
                BB_Endereco.Enabled = false;
                DS_Endereco.Enabled = true;
                DS_Cidade.Enabled = true;
                UF.Enabled = true;
                CD_Endereco.Clear();
                DS_Endereco.Clear();
                DS_Cidade.Clear();
                UF.Clear();
                placaveiculo.Clear();
                ds_veiculo.Clear();
                ds_marca.Clear();
                ds_obsveiculo.Clear();
                placaveiculo.Enabled = true;
                ds_veiculo.Enabled = true;
                ds_marca.Enabled = true;
                ds_obsveiculo.Enabled = true;
            }
        }

        private void BB_TabelaPreco_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_tabelapreco|Tabela Preço|200;" +
                              "a.cd_tabelapreco|Cd. Tabela|80";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_TabelaPreco, NM_TabelaPreco },
                                            new CamadaDados.Diversos.TCD_CadTbPreco(), string.Empty);
        }

        private void CD_TabelaPreco_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LEAVE("a.cd_tabelapreco|=|'" + CD_TabelaPreco.Text.Trim() + "'",
                                                new Componentes.EditDefault[] { CD_TabelaPreco, NM_TabelaPreco },
                                                new CamadaDados.Diversos.TCD_CadTbPreco());
        }

        private void BB_Endereco_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_endereco|Endereco|150;" +
                              "a.cd_endereco|Código Endereço|80;" +
                              "b.DS_Cidade|Cidade|250;" +
                              "UF|Estado|150";
            string vParam = "a.cd_clifor|=|'" + CD_Clifor.Text.Trim() + "'";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_Endereco, DS_Endereco, DS_Cidade, UF },
                                                new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco(), vParam);
        }

        private void CD_Endereco_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_clifor|=|'" + CD_Clifor.Text.Trim() + "';" +
                            "a.cd_endereco|=|'" + CD_Endereco.Text.Trim() + "'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { CD_Endereco, DS_Endereco, DS_Cidade, UF },
                                                new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco());
        }

        private void placaveiculo_Leave(object sender, EventArgs e)
        {
            CamadaDados.Servicos.Cadastros.TList_VeiculoCliente
             placa = new CamadaDados.Servicos.Cadastros.TCD_VeiculoCliente().Select(
                new TpBusca[]
                {
                    new TpBusca()
                    {
                        vNM_Campo = "a.PlacaVeiculo",
                        vOperador = "=",
                        vVL_Busca = "'" + placaveiculo.Text.Trim() + "'"
                    }
                },1, string.Empty);
            if (placa.Count > 0)
            {
                placaveiculo.Text = placa[0].Placaveiculo;
                ds_veiculo.Text = placa[0].Ds_veiculo;
                ds_marca.Text = placa[0].Ds_marca;
                ds_obsveiculo.Text = placa[0].Ds_observacao;
                if (placa.Count > 0)
                {
                    if (!string.IsNullOrEmpty(CD_Clifor.Text))
                        if ((CD_Clifor.Text != placa[0].Cd_clifor) && (!string.IsNullOrEmpty(placa[0].Cd_clifor)))
                            if (MessageBox.Show("O Cliente da placa é diferente da cliente da OS! \r\nDeseja alterar o Cliente da OS corrente?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                            {
                                CD_Clifor.Text = placa[0].Cd_clifor;
                                NM_Clifor.Text = placa[0].Nm_clifor;
                                BuscarEndereco();
                            }
                    placaveiculo.Enabled = false;
                    ds_veiculo.Enabled = false;
                    ds_marca.Enabled = false;
                    ds_obsveiculo.Enabled = false;
                }
            }
        }

        private void bb_placa_Click(object sender, EventArgs e)
        {
            string vColunas = "a.placaveiculo|Placa|80;" +
                              "a.ds_veiculo|Veiculo|200;" +
                              "a.ds_marca|Marca|200;" +
                              "a.ds_observacao|OBS|200";
            string vParam = "isnull(a.st_registro, 'A')|<>|'C'";
            DataRowView linha =  FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { placaveiculo, ds_veiculo, ds_marca, ds_obsveiculo },
                new CamadaDados.Servicos.Cadastros.TCD_VeiculoCliente(),
               vParam);
            if (linha != null)
            {
                if (!string.IsNullOrEmpty(CD_Clifor.Text))
                if ((CD_Clifor.Text != linha["cd_clifor"].ToString())&& (!string.IsNullOrEmpty(linha["cd_clifor"].ToString())))
                    if (MessageBox.Show("O Cliente da placa é diferente da cliente da OS! \r\nDeseja alterar o Cliente da OS corrente?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        CD_Clifor.Text = linha["cd_clifor"].ToString();
                        NM_Clifor.Text = linha["nm_clifor"].ToString();
                        BuscarEndereco();
                    }
                placaveiculo.Enabled = false;
                ds_veiculo.Enabled = false;
                ds_marca.Enabled = false;
                ds_obsveiculo.Enabled = false;
            }
        }

        private void BB_Acessorios_Click(object sender, EventArgs e)
        {
            if ((bsOrdemServico.Current != null) &&
                (!string.IsNullOrEmpty(Add_ListaAcessorios.Text)))
            {
                if (!(bsOrdemServico.Current as CamadaDados.Servicos.TRegistro_LanServico).lAcessorios.Exists(p => p.Ds_acessorio.Trim().ToUpper().Equals(Add_ListaAcessorios.Text.Trim().ToUpper())))
                {
                    (bsOrdemServico.Current as CamadaDados.Servicos.TRegistro_LanServico).lAcessorios.Add(
                        new CamadaDados.Servicos.TRegistro_Acessorios()
                        {
                            Ds_acessorio = Add_ListaAcessorios.Text.Trim()
                        });
                    Add_ListaAcessorios.Clear();
                    bsOrdemServico.ResetCurrentItem();
                }
            }
        }

        private void BB_Del_Acessorios_Click(object sender, EventArgs e)
        {
            if (bsAcessorios.Current != null)
            {
                if (MessageBox.Show("Confirma exclusão do acessorio selecionado?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    (bsOrdemServico.Current as CamadaDados.Servicos.TRegistro_LanServico).lAcessoriosDel.Add(
                        bsAcessorios.Current as CamadaDados.Servicos.TRegistro_Acessorios);
                    bsAcessorios.RemoveCurrent();
                }
            }
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            afterGrava();
        }

        private void TFServicoOficina_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                DialogResult = DialogResult.Cancel;
            else if (tcCentral.SelectedTab.Equals(tpPecas) && e.Control && e.KeyCode.Equals(Keys.F10))
                afterInserirPecas(false);
            else if (tcCentral.SelectedTab.Equals(tpPecas) && e.Control && e.KeyCode.Equals(Keys.F11))
                afterAlterarPecas(false);
            else if (tcCentral.SelectedTab.Equals(tpPecas) && e.Control && e.KeyCode.Equals(Keys.F12))
                afterExcluirPecas(false);
            else if (tcCentral.SelectedTab.Equals(tpServicos) && e.Control && e.KeyCode.Equals(Keys.F10))
                afterInserirPecas(true);
            else if (tcCentral.SelectedTab.Equals(tpServicos) && e.Control && e.KeyCode.Equals(Keys.F11))
                afterAlterarPecas(true);
            else if (tcCentral.SelectedTab.Equals(tpServicos) && e.Control && e.KeyCode.Equals(Keys.F12))
                afterExcluirPecas(true);
        }

        private void bb_addveiculo_Click(object sender, EventArgs e)
        {
            placaveiculo.Enabled = true;
            placaveiculo.Clear();
            ds_veiculo.Enabled = true;
            ds_veiculo.Clear();
            ds_marca.Enabled = true;
            ds_marca.Clear();
            ds_obsveiculo.Enabled = true;
            ds_obsveiculo.Clear();

            placaveiculo.Focus();
        }

        private void bb_cadclifor_Click(object sender, EventArgs e)
        {
            using (Financeiro.Cadastros.TFCadCliforResumido fClifor = new Financeiro.Cadastros.TFCadCliforResumido())
            {
                if(fClifor.ShowDialog() == DialogResult.OK)
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

        private void btn_Insere_Pecas_Click(object sender, EventArgs e)
        {
            afterInserirPecas(false);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            afterAlterarPecas(false);
        }

        private void btn_Deleta_Pecas_Click(object sender, EventArgs e)
        {
            afterExcluirPecas(false);
        }

        private void bb_inserirServicos_Click(object sender, EventArgs e)
        {
            afterInserirPecas(true);
        }

        private void bb_alterarServicos_Click(object sender, EventArgs e)
        {
            afterAlterarPecas(true);
        }

        private void bb_excluirServicos_Click(object sender, EventArgs e)
        {
            afterExcluirPecas(true);
        }

        private void TFServicoOficina_FormClosing(object sender, FormClosingEventArgs e)
        {
            ShapeGrid.SaveShape(this, gPecas);
        }

        private void pc_desconto_Leave(object sender, EventArgs e)
        {
            (bsOrdemServico.Current as CamadaDados.Servicos.TRegistro_LanServico).Pc_desconto = pc_desconto.Value;
            CamadaNegocio.Servicos.TCN_LanServico.RateiaDescontoItens(bsOrdemServico.Current as CamadaDados.Servicos.TRegistro_LanServico, true);
            TotalizarPecasServicos();
        }

        private void tot_desconto_Leave(object sender, EventArgs e)
        {
            (bsOrdemServico.Current as CamadaDados.Servicos.TRegistro_LanServico).Vl_desconto = tot_desconto.Value;
            CamadaNegocio.Servicos.TCN_LanServico.RateiaDescontoItens(bsOrdemServico.Current as CamadaDados.Servicos.TRegistro_LanServico, false);
            TotalizarPecasServicos();
        }

        private void tcCentral_Selected(object sender, TabControlEventArgs e)
        {
            TotalizarPecasServicos();
        }

        private void pc_acrescimo_Leave(object sender, EventArgs e)
        {
            (bsOrdemServico.Current as CamadaDados.Servicos.TRegistro_LanServico).Pc_acrescimo = pc_acrescimo.Value;
            CamadaNegocio.Servicos.TCN_LanServico.RateiaAcrescimoItens(bsOrdemServico.Current as CamadaDados.Servicos.TRegistro_LanServico, true);
            TotalizarPecasServicos();
        }

        private void tot_acrescimo_Leave(object sender, EventArgs e)
        {
            (bsOrdemServico.Current as CamadaDados.Servicos.TRegistro_LanServico).Vl_acrescimo = tot_acrescimo.Value;
            CamadaNegocio.Servicos.TCN_LanServico.RateiaAcrescimoItens(bsOrdemServico.Current as CamadaDados.Servicos.TRegistro_LanServico, false);
            TotalizarPecasServicos();
        }

        private void cbTpOrdem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbTpOrdem.SelectedItem != null)
            {
                id_os.Enabled = CamadaNegocio.Servicos.TCN_LanServico.SequenciaManual(bsOrdemServico.Current as CamadaDados.Servicos.TRegistro_LanServico, null);
                if (!id_os.Enabled)
                    id_os.Value = id_os.Minimum;
            }
        }
    }
}
