using System;
using System.Drawing;
using System.Linq;
using CamadaDados.Faturamento.Pedido;
using System.Windows.Forms;
using FormBusca;
using Utils;
using CamadaNegocio.Diversos;
using CamadaDados.Financeiro.Cadastros;
using CamadaNegocio.Faturamento.Pedido;
using CamadaDados.Faturamento.Cadastros;
using Componentes;
using CamadaNegocio.Financeiro.Cadastros;
using System.Data;
using CamadaDados.Diversos;
using FormRelPadrao;
using CamadaDados.Faturamento.Orcamento;
using System.ComponentModel;
using CamadaDados.Fiscal;

namespace Faturamento
{
    public partial class TFLan_Proposta : Form
    {
        private bool st_estornar = false;
        private bool st_estornarProcess = false;
        private bool Altera_Relatorio = false;
        private Form fEditar
        { get; set; }

        public TFLan_Proposta()
        {
            InitializeComponent();
        }

        private void LimparFitros()
        {
            nr_orcamento.Clear();
            nm_clifor.Clear();
            ds_endereco.Clear();
            DT_Final.Clear();
            DT_Inicial.Clear();
            cbAberto.Checked = false;
            cbCancelado.Checked = false;
            cbAprovada.Checked = false;
        }

        private void afterNovo()
        {
            using (TFProposta fOrcamento = new TFProposta())
            {
                fOrcamento.Text = "NOVA PROPOSTA";
                if (fOrcamento.ShowDialog() == DialogResult.OK)
                    if (fOrcamento.rOrcamento != null)
                    {
                        try
                        {
                            CamadaNegocio.Faturamento.Orcamento.TCN_Orcamento.Gravar(fOrcamento.rOrcamento, null);
                            MessageBox.Show("Proposta gravada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LimparFitros();
                            nr_orcamento.Text = fOrcamento.rOrcamento.Nr_orcamentostr;
                            afterBusca();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
            }
        }

        private void afterExclui()
        {
            if (bsOrcamento.Current != null)
            {
                if (!(bsOrcamento.Current as TRegistro_Orcamento).St_registro.Trim().ToUpper().Equals("CA"))
                {
                    if ((bsOrcamento.Current as TRegistro_Orcamento).St_registro.Trim().ToUpper().Equals("FT"))
                    {
                        MessageBox.Show("Não é permitido excluir proposta FATURADA.\r\n" +
                                        "Necessario antes estornar o faturamento da proposta.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    //motivo do cancelamento
                    InputBox iB = new InputBox();
                    iB.Text = "Motivo do cancelamento";
                    (bsOrcamento.Current as TRegistro_Orcamento).MotivoCanc = iB.ShowDialog();
                    if (string.IsNullOrEmpty((bsOrcamento.Current as TRegistro_Orcamento).MotivoCanc))
                    {
                        MessageBox.Show("Obrigatório informar motivo do cancelamento.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    try
                    {
                        CamadaNegocio.Faturamento.Orcamento.TCN_Orcamento.CancelarOrcamento(bsOrcamento.Current as TRegistro_Orcamento, null);
                        MessageBox.Show("Proposta cancelada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LimparFitros();
                        cbAberto.Checked = true;
                        afterBusca();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    if (!st_estornar)
                        using (Parametros.Diversos.TFRegraUsuario fRegra = new Parametros.Diversos.TFRegraUsuario())
                        {
                            fRegra.Ds_regraespecial = "PERMITIR ESTORNAR CANCELAMENTO PROPOSTA";
                            fRegra.Login = Utils.Parametros.pubLogin;
                            if (fRegra.ShowDialog() == DialogResult.OK)
                                st_estornar = true;
                        }
                    if (st_estornar)
                    {
                        if (MessageBox.Show("Confirma o estorno do cancelamento da PROPOSTA Nº " +
                            (bsOrcamento.Current as TRegistro_Orcamento).Nr_orcamentostr + "?", "Pergunta",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                            try
                            {
                                (bsOrcamento.Current as TRegistro_Orcamento).St_registro = "AB";
                                CamadaNegocio.Faturamento.Orcamento.TCN_Orcamento.Gravar(bsOrcamento.Current as TRegistro_Orcamento, null);
                                MessageBox.Show("Cancelamento estornado com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LimparFitros();
                                nr_orcamento.Text = (bsOrcamento.Current as TRegistro_Orcamento).Nr_orcamentostr;
                                afterBusca();
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    }
                }
            }
            else
                MessageBox.Show("Obrigatorio selecionar proposta para excluir.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void afterAltera()
        {
            if (bsOrcamento.Current != null)
            { 
                bool st_editar = true;
                if (((bsOrcamento.Current as TRegistro_Orcamento).rPedido.Cd_vendedor.Trim() != string.Empty) &&
                    (Utils.Parametros.pubLogin.Trim().ToUpper() != "MASTER") &&
                    (Utils.Parametros.pubLogin.Trim().ToUpper() != "DESENV"))
                {
                    if (!TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin, "PERMITIR ALTERAR PEDIDO OUTROS VENDEDORES", null))
                    {
                        //Verificar se o login atual e igual ao login do cadastro de vendedor
                        object obj = new TCD_CadClifor().BuscarEscalar(
                            new TpBusca[]
                        {
                                new TpBusca()
                                {
                                    vNM_Campo = "a.loginvendedor",
                                    vOperador = "=",
                                    vVL_Busca = "'" + Utils.Parametros.pubLogin.Trim().ToUpper() + "'"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = "a.cd_clifor",
                                    vOperador = "=",
                                    vVL_Busca = (bsOrcamento.Current as TRegistro_Orcamento).rPedido.Cd_vendedor
                                }
                        }, "1");
                        if (obj == null)
                            st_editar = false;
                    }
                }
                if ((bsOrcamento.Current as TRegistro_Orcamento).Nr_pedidovenda != null)
                {
                    if (!TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin, "PERMITIR ALTERAR ORÇAMENTO PROCESSADO", null))
                    {
                        MessageBox.Show("Usuário não possui permissão para alterar Orçamento processado!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if (((bsOrcamento.Current as TRegistro_Orcamento).rPedido.ST_Pedido == "F" ||
                   (bsOrcamento.Current as TRegistro_Orcamento).rPedido.ST_Pedido == "P") &&
                   TCN_Pedido.Verifica_Disponibilidade_Pedido((bsOrcamento.Current as TRegistro_Orcamento).rPedido.Nr_pedido.ToString()))
                        st_editar = false;
                }
                if ((bsOrcamento.Current as TRegistro_Orcamento).St_registro.Trim().ToUpper().Equals("CA"))
                {
                    MessageBox.Show("Não é permitido alterar proposta CANCELADA.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                using (TFProposta fOrc = new TFProposta())
                {
                    (bsOrcamento.Current as TRegistro_Orcamento).lItens.ForEach(p => p.lFichaTec = CamadaNegocio.Faturamento.Orcamento.TCN_FichaTecOrcItem.Buscar(p.Nr_orcamento.Value.ToString(), p.Id_item.Value.ToString(), string.Empty, null));
                    fOrc.rOrcamento = (bsOrcamento.Current as TRegistro_Orcamento);
                    fOrc.St_editar = st_editar;
                    if (fOrc.ShowDialog() == DialogResult.OK)
                    {
                        if (fOrc.rOrcamento != null)
                        {
                            try
                            {
                                CamadaNegocio.Faturamento.Orcamento.TCN_Orcamento.Gravar(fOrc.rOrcamento, null);
                                MessageBox.Show("Proposta alterada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    LimparFitros();
                    nr_orcamento.Text = fOrc.rOrcamento.Nr_orcamentostr;
                    afterBusca();
                }
            }
            else
                MessageBox.Show("Necessario selecionar proposta para alterar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void afterBusca()
        {
            string cond = string.Empty;
            string virg = string.Empty;
            if (cbAberto.Checked)
            {
                cond = "'AB'";
                virg = ",";
            }
            if (cbCancelado.Checked)
            {
                cond += virg + "'CA'";
                virg = ",";
            }
            if (cbAprovada.Checked)
            {
                cond += "'PA'";
                virg = ",";
            }
            if (cbFechada.Checked)
            {
                cond += "'PF'";
                virg = ",";
            }
            bsOrcamento.DataSource = CamadaNegocio.Faturamento.Orcamento.TCN_Orcamento.Buscar(nr_orcamento.Text,
                                                                                              (cbEmpresa.SelectedValue != null ? cbEmpresa.SelectedValue.ToString() : string.Empty),
                                                                                              string.Empty,
                                                                                              cd_vendedor.Text,
                                                                                              cd_representante.Text,
                                                                                              string.Empty,
                                                                                              Cd_produto.Text,
                                                                                              nm_clifor.Text,
                                                                                              ds_endereco.Text,
                                                                                              CD_UF.Text,
                                                                                              DT_Inicial.Text,
                                                                                              DT_Final.Text,
                                                                                              VL_Inicial.Value,
                                                                                              VL_Final.Value,
                                                                                              string.Empty,
                                                                                              cond,
                                                                                              "N",
                                                                                              string.Empty,
                                                                                              false,
                                                                                              false,
                                                                                              string.Empty,
                                                                                              string.Empty, 
                                                                                              true,
                                                                                              cbAbaixoCusto.Checked,
                                                                                              null);
            bsOrcamento_PositionChanged(this, new EventArgs());
            TotalProjEspeciais();
        }

        private void TotalizarOrcamento()
        {
            if (bsOrcamento.Current != null)
            {
                tot_subtotal.Value = (bsOrcamento.Current as TRegistro_Orcamento).lItens.Sum(p => p.Vl_subtotal);
                tot_desconto.Value = (bsOrcamento.Current as TRegistro_Orcamento).lItens.Sum(p => p.Vl_desconto);
                tot_frete.Value = (bsOrcamento.Current as TRegistro_Orcamento).lItens.Sum(p => p.Vl_frete);
                tot_juro.Value = (bsOrcamento.Current as TRegistro_Orcamento).lItens.Sum(p => p.Vl_acrescimo);
                tot_juro_fin.Value = (bsOrcamento.Current as TRegistro_Orcamento).lItens.Sum(p => p.Vl_juro_fin);
                tot_liquido.Value = (bsOrcamento.Current as TRegistro_Orcamento).lItens.Sum(p => p.Vl_subtotalliq) +
                                    (bsOrcamento.Current as TRegistro_Orcamento).Vl_impostosomar -
                                    (bsOrcamento.Current as TRegistro_Orcamento).Vl_impostosubtrair;
            }
        }

        private void ProcessarOrcamento()
        {
            if (bsOrcamento.Current != null)
            {
                if (!TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin, "PERMITIR PROCESSAR ORÇAMENTO", null))
                {
                    MessageBox.Show("Usuário não tem acesso para processar proposta!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if ((bsOrcamento.Current as TRegistro_Orcamento).St_registro.Trim().ToUpper().Equals("CA"))
                {
                    MessageBox.Show("Não é permitido processar proposta CANCELADA.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if ((bsOrcamento.Current as TRegistro_Orcamento).St_registro.Trim().ToUpper().Equals("FT"))
                {
                    MessageBox.Show("Proposta ja se encontra processada.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (string.IsNullOrEmpty((bsOrcamento.Current as TRegistro_Orcamento).Cd_clifor))
                {
                    MessageBox.Show("Não é permitido processar proposta sem cliente cadastrado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (string.IsNullOrEmpty((bsOrcamento.Current as TRegistro_Orcamento).Cd_endereco))
                {
                    MessageBox.Show("Não é permitido processar proposta sem endereço cadastrado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if ((bsOrcamento.Current as TRegistro_Orcamento).lItens.Count < 1)
                {
                    MessageBox.Show("Não é permitido processar proposta sem itens.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if ((bsOrcamento.Current as TRegistro_Orcamento).lItens.Exists(p => string.IsNullOrEmpty(p.Cd_produto)))
                {
                    MessageBox.Show("Não é permitido processar proposta com produto sem cadastro.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (!bloqueioCredito())
                {
                    MessageBox.Show("Cliente possui restrição de crédito.\r\n" +
                                   "Financeiro não poderá ser gravado.", "Mensagem", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    return;
                }
                if (!string.IsNullOrEmpty((bsOrcamento.Current as TRegistro_Orcamento).Cd_representante) &&
                    (bsOrcamento.Current as TRegistro_Orcamento).Pc_comrep.Equals(decimal.Zero))
                    if (MessageBox.Show("proposta possui representante com % COMISSÃO ZERADO.\r\n" +
                                       "Confirma processamento da proposta?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) != DialogResult.Yes)
                        return;
                TList_CFGOrcamento lCfg =
                    CamadaNegocio.Faturamento.Cadastros.TCN_CFGOrcamento.Buscar((bsOrcamento.Current as TRegistro_Orcamento).Cd_empresa,
                                                                                string.Empty,
                                                                                string.Empty,
                                                                                null);
                if (lCfg.Count.Equals(0))
                {
                    MessageBox.Show("Não existe configuração para processar proposta na empresa " + (bsOrcamento.Current as TRegistro_Orcamento).Cd_empresa,
                        "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if ((bsOrcamento.Current as TRegistro_Orcamento).lItens.Exists(p => (!p.St_servicobool) && string.IsNullOrEmpty(p.Cd_local)))
                {
                    MessageBox.Show("Não é permitido processar orçamento sem informar local de armazenagem para os itens.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if((bsOrcamento.Current as TRegistro_Orcamento).lItens.Exists(p=> p.St_projespecialbool && p.Vl_unitario.Equals(decimal.Zero)))
                {
                    MessageBox.Show("Não é permitido processar orçamento com item PROJETO ESPECIAL sem informar o valor de venda.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (MessageBox.Show("Confirma processamento da proposta selecionada?", "Pergunta", MessageBoxButtons.YesNo,
                     MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    string msg = this.VerificarSaldoEstoque();
                    if (!string.IsNullOrEmpty(msg))
                        if (MessageBox.Show(msg.Trim() + "\r\n" +
                                           "Confirma processamento mesmo assim?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                            != DialogResult.Yes)
                            return;
                    try
                    {
                        ////Mudar Representante
                        //DataRowView linha = UtilPesquisa.BTN_BuscaClifor(null, "isnull(a.st_representante, 'N')|=|'S'");
                        //if (linha != null)
                        //    (bsOrcamento.Current as TRegistro_Orcamento).Cd_representante = linha["cd_clifor"].ToString();
                        CamadaNegocio.Faturamento.Orcamento.TCN_Orcamento.ProcessarOrcamento(bsOrcamento.Current as TRegistro_Orcamento, lCfg[0], null);
                        MessageBox.Show("Proposta processada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LimparFitros();
                        nr_orcamento.Text = (bsOrcamento.Current as TRegistro_Orcamento).Nr_orcamentostr;
                        afterBusca();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
                MessageBox.Show("Necessario selecionar proposta para processar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void EstornarProcess()
        {
            if (bsOrcamento.Current != null)
            {
                if (((bsOrcamento.Current as TRegistro_Orcamento).rPedido.Nr_pedido == 0))
                {
                    MessageBox.Show("Não é possível estornar proposta que não foi processada!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (!st_estornarProcess)
                    using (Parametros.Diversos.TFRegraUsuario fRegra = new Parametros.Diversos.TFRegraUsuario())
                    {
                        fRegra.Ds_regraespecial = "PERMITIR CANCELAR PEDIDO";
                        fRegra.Login = Utils.Parametros.pubLogin;
                        if (fRegra.ShowDialog() == DialogResult.OK)
                            st_estornarProcess = true;
                    }
                if (st_estornarProcess)
                {
                    //motivo do cancelamento
                    InputBox iB = new InputBox();
                    iB.Text = "Motivo do cancelamento";
                    (bsOrcamento.Current as TRegistro_Orcamento).rPedido.dsCancelmento = iB.ShowDialog();
                    if (string.IsNullOrEmpty((bsOrcamento.Current as TRegistro_Orcamento).rPedido.dsCancelmento))
                    {
                        MessageBox.Show("Obrigatório informar descrição", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if (TCN_Pedido.Verifica_Disponibilidade_Pedido((bsOrcamento.Current as TRegistro_Orcamento).rPedido.Nr_pedido.ToString()))
                    {
                        MessageBox.Show("Não é permitido estornar uma proposta que tenha FATURAMENTO!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    //Verificar se pedido possui duplicata ativa
                    if (new CamadaDados.Financeiro.Duplicata.TCD_LanDuplicata().BuscarEscalar(
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
                                    vVL_Busca = "(select 1 from tb_fat_pedido_x_duplicata x " +
                                                "where x.cd_empresa = a.cd_empresa " +
                                                "and x.nr_lancto = a.nr_lancto " +
                                                "and x.nr_pedido = " + (bsOrcamento.Current as TRegistro_Orcamento).rPedido.Nr_pedido.ToString() + ")"
                                }
                        }, "1") != null)
                    {
                        MessageBox.Show("Pedido possui duplicata em aberto.\r\n" +
                                        "Entre em contato com o responsável pelo financeiro para realizar o cancelamento da duplicata.",
                                        "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if (MessageBox.Show("Confirma o estorno do processamento da proposta?", "Pergunta",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                    DialogResult.Yes)
                        try
                        {
                            TCN_Pedido.Deleta_Pedido((bsOrcamento.Current as TRegistro_Orcamento).rPedido, null);
                            MessageBox.Show("Proposta estornada com Sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LimparFitros();
                            nr_orcamento.Text = (bsOrcamento.Current as TRegistro_Orcamento).Nr_orcamentostr;
                            afterBusca();
                        }
                        catch (Exception ex)
                        { MessageBox.Show("Erro: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            }
        }

        private string VerificarSaldoEstoque()
        {
            string msg = string.Empty;
            (bsOrcamento.Current as TRegistro_Orcamento).lItens.FindAll(p => !p.St_servicobool).ForEach(p =>
            {
                p.Qtd_saldoestoque = this.BuscarSaldoLocal(p.Cd_produto, p.Cd_local);
                if (p.Quantidade > p.Qtd_saldoestoque)
                    msg += "Produto " + p.Cd_produto.Trim() + " sem saldo para faturar. Qtd: " + p.Quantidade.ToString("N3", new System.Globalization.CultureInfo("pt-BR")) + " Saldo: " +
                        p.Qtd_saldoestoque.ToString("N3", new System.Globalization.CultureInfo("pt-BR")) + "\r\n";
            });
            return msg;
        }

        private decimal BuscarSaldoLocal(string pCd_produto,
                                         string pCd_local)
        {
            if ((!string.IsNullOrEmpty((bsOrcamento.Current as TRegistro_Orcamento).Cd_empresa)) &&
                (!string.IsNullOrEmpty(pCd_produto)) &&
                (!string.IsNullOrEmpty(pCd_local)))
            {
                decimal saldo = decimal.Zero;
                CamadaNegocio.Estoque.TCN_LanEstoque.SaldoEstoqueLocal((bsOrcamento.Current as TRegistro_Orcamento).Cd_empresa,
                                                                       pCd_produto, 
                                                                       pCd_local, 
                                                                       ref saldo, null);
                return saldo;
            }
            else
                return decimal.Zero;
        }

        private void Print()
        {
            if (bsOrcamento.Current != null)
            {
                if (!(bsOrcamento.Current as TRegistro_Orcamento).St_registro.Trim().ToUpper().Equals("C"))
                {
                    Relatorio Relatorio = new Relatorio();
                    Relatorio.Altera_Relatorio = Altera_Relatorio;

                    //DADOS PERTINENTES PARA A GERAÇÂO DO RELATORIO
                    Relatorio.Nome_Relatorio = "TFLan_Pedido";
                    Relatorio.NM_Classe = "TFLan_Pedido";
                    Relatorio.Modulo = Tag.ToString().Substring(0, 3);


                    BindingSource BinEmpresa = new BindingSource();
                    BinEmpresa.DataSource = TCN_CadEmpresa.Busca(
                                                                 (bsOrcamento.Current as TRegistro_Orcamento).Cd_empresa,
                                                                 string.Empty,
                                                                 string.Empty,
                                                                 null);

                    BindingSource BinClifor = new BindingSource();
                    if (!string.IsNullOrEmpty((bsOrcamento.Current as TRegistro_Orcamento).Cd_clifor))
                        BinClifor.DataSource =TCN_CadClifor.Busca_Clifor((bsOrcamento.Current as TRegistro_Orcamento).Cd_clifor,
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
                                                                                                              1,
                                                                                                              null);

                    BindingSource BinEndereco = new BindingSource();
                    if (!string.IsNullOrEmpty((bsOrcamento.Current as TRegistro_Orcamento).Cd_clifor))
                        BinEndereco.DataSource =TCN_CadEndereco.Buscar(
                                                                        (bsOrcamento.Current as TRegistro_Orcamento).Cd_clifor,
                                                                        (bsOrcamento.Current as TRegistro_Orcamento).Cd_endereco,
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
                    BindingSource BinContatos = new BindingSource();
                    if (!string.IsNullOrEmpty((bsOrcamento.Current as TRegistro_Orcamento).Cd_clifor))
                        BinContatos.DataSource =TCN_CadContatoCliFor.Buscar(string.Empty,
                                                                                                               (bsOrcamento.Current as TRegistro_Orcamento).Cd_clifor,
                                                                                                                string.Empty,
                                                                                                                string.Empty,
                                                                                                                string.Empty,
                                                                                                                string.Empty,
                                                                                                                string.Empty,
                                                                                                                false,
                                                                                                                false,
                                                                                                                false,
                                                                                                                string.Empty,
                                                                                                                0,
                                                                                                                null);
                    BindingSource BinContatoVend = new BindingSource();
                    BinContatoVend.DataSource =TCN_CadContatoCliFor.Buscar(string.Empty,
                                                                                                               (bsOrcamento.Current as TRegistro_Orcamento).Cd_vendedor,
                                                                                                               string.Empty,
                                                                                                               string.Empty,
                                                                                                               string.Empty,
                                                                                                               string.Empty,
                                                                                                               string.Empty,
                                                                                                               false,
                                                                                                               false,
                                                                                                               false,
                                                                                                               string.Empty,
                                                                                                               1,
                                                                                                               null);

                    BindingSource BinContatoRepresentante = new BindingSource();
                    if (!string.IsNullOrEmpty((bsOrcamento.Current as TRegistro_Orcamento).Cd_representante))
                        BinContatoRepresentante.DataSource =TCN_CadContatoCliFor.Buscar(string.Empty,
                                                                                                                   (bsOrcamento.Current as TRegistro_Orcamento).Cd_representante,
                                                                                                                   string.Empty,
                                                                                                                   string.Empty,
                                                                                                                   string.Empty,
                                                                                                                   string.Empty,
                                                                                                                   string.Empty,
                                                                                                                   false,
                                                                                                                   false,
                                                                                                                   false,
                                                                                                                   string.Empty,
                                                                                                                   1,
                                                                                                                   null);
                    if (string.IsNullOrEmpty((bsOrcamento.Current as TRegistro_Orcamento).Cd_representante) ||
                        BinContatoRepresentante.Count.Equals(0))
                    {
                        BinContatoRepresentante.DataSource = new TList_CadContatoCliFor();
                        (BinContatoRepresentante.DataSource as TList_CadContatoCliFor).Add(
                            new TRegistro_CadContatoCliFor());
                    }

                    BindingSource BinParcelas = new BindingSource();
                    BinParcelas.DataSource = CamadaNegocio.Faturamento.Orcamento.TCN_Orcamento_DT_Vencto.Buscar((bsOrcamento.Current as TRegistro_Orcamento).Nr_orcamentostr,
                                                                                                          null);
                    //Buscar %ICMS do Estado
                    if (BinEndereco.Current != null)
                    {
                        object objICMS =
                            new TCD_CadUf().BuscarEscalar(
                                new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = "a.CD_UF",
                                    vOperador = "=",
                                    vVL_Busca = "'" + (BinEndereco.Current as TRegistro_CadEndereco).Cd_uf.Trim() + "'"
                                }
                            }, "a.PC_AliquotaICMS");
                        if (objICMS != null && !string.IsNullOrEmpty(objICMS.ToString()))
                            (bsOrcamento.Current as TRegistro_Orcamento).Pc_Icms_UF = Convert.ToDecimal(objICMS);
                    }
                    else if (!string.IsNullOrEmpty((bsOrcamento.Current as TRegistro_Orcamento).Uf))
                    {
                        object objICMS =
                            new TCD_CadUf().BuscarEscalar(
                                new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = "a.UF",
                                    vOperador = "=",
                                    vVL_Busca = "'" + (bsOrcamento.Current as TRegistro_Orcamento).Uf.Trim() + "'"
                                }
                            }, "a.PC_AliquotaICMS");
                        if (objICMS != null && !string.IsNullOrEmpty(objICMS.ToString()))
                            (bsOrcamento.Current as TRegistro_Orcamento).Pc_Icms_UF = Convert.ToDecimal(objICMS);
                    }

                    //Buscar ficha tecnica
                    (bsOrcamento.Current as TRegistro_Orcamento).lItens.ForEach(p =>
                    {
                        if (p.lFichaTec.Count.Equals(0))
                            p.lFichaTec = CamadaNegocio.Faturamento.Orcamento.TCN_FichaTecOrcItem.Buscar(p.Nr_orcamento.Value.ToString(),
                                                                                                         p.Id_item.Value.ToString(),
                                                                                                         string.Empty,
                                                                                                         null);
                    });

                    object cliforEmpresa = new TCD_CadEmpresa().BuscarEscalar(
                                       new TpBusca[]
                                        {
                                            new TpBusca()
                                            {
                                                vNM_Campo = "a.cd_empresa",
                                                vOperador = "=",
                                                vVL_Busca = "'" + (bsOrcamento.Current as TRegistro_Orcamento).Cd_empresa + "'"
                                            }
                                        }, "a.cd_clifor");
                    BindingSource BinDadosFin = new BindingSource();
                    BinDadosFin.DataSource =TCN_CadDados_Bancarios_Clifor.Busca(cliforEmpresa.ToString(),
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  null);

                    BindingSource BinContatosEmpresa = new BindingSource();
                    BinContatosEmpresa.DataSource =TCN_CadContatoCliFor.Buscar(string.Empty,
                                                                         cliforEmpresa.ToString(),
                                                                         string.Empty,
                                                                         string.Empty,
                                                                         string.Empty,
                                                                         string.Empty,
                                                                         string.Empty,
                                                                         false,
                                                                         false,
                                                                         false,
                                                                         string.Empty,
                                                                         0,
                                                                         null);

                    BindingSource BinEndEntrega = new BindingSource();
                    BinEndEntrega.DataSource = new TCD_CadEndereco().Select(
                        new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = "a.cd_clifor",
                                vOperador = "=",
                                vVL_Busca = "'" + (bsOrcamento.Current as TRegistro_Orcamento).Cd_clifor + "'"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "a.st_endentrega",
                                vOperador = "=",
                                vVL_Busca = "'S'"
                            }
                        }, 1, string.Empty);

                    BindingSource meu_bind = new BindingSource();
                    meu_bind.DataSource = new TList_Orcamento() { bsOrcamento.Current as TRegistro_Orcamento };
                    Relatorio.Adiciona_DataSource("EMPRESA", BinEmpresa);
                    Relatorio.Adiciona_DataSource("CLIFOR", BinClifor);
                    Relatorio.Adiciona_DataSource("ENDERECO_CLIFOR", BinEndereco);
                    Relatorio.Adiciona_DataSource("ITENS", bsItens);
                    Relatorio.Adiciona_DataSource("CONTATO_CLIFOR", BinContatos);
                    Relatorio.Adiciona_DataSource("CONTATO_VENDEDOR", BinContatoVend);
                    Relatorio.Adiciona_DataSource("CONTATO_REPRESENTANTE", BinContatoRepresentante);
                    Relatorio.Adiciona_DataSource("PARCELAS", BinParcelas);
                    Relatorio.Adiciona_DataSource("DADOSFIN", BinDadosFin);
                    Relatorio.Adiciona_DataSource("EMPRESACONTATO", BinContatosEmpresa);
                    Relatorio.Adiciona_DataSource("ENDENTREGA", BinEndEntrega);
                    Relatorio.DTS_Relatorio = meu_bind;

                    //Buscar CFG.Orcamento
                    TList_CFGOrcamento lCfg =
                        new TCD_CFGOrcamento().Select(
                            new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = "a.cd_empresa",
                                    vOperador = "=",
                                    vVL_Busca = "'" + (bsOrcamento.Current as TRegistro_Orcamento).Cd_empresa.Trim() + "'"
                                }
                            }, 0, string.Empty);
                    if (lCfg.Count > 0)
                        if (lCfg[0].LayoutAereo != null ||
                            lCfg[0].LayoutJaquetado != null ||
                            lCfg[0].LayoutPerifericos != null || 
                            lCfg[0].LayoutAgua != null ||
                            lCfg[0].LayoutFlex != null || 
                            lCfg[0].LayoutVertical != null ||
                            lCfg[0].LayoutJaquetadoRes != null)
                        {
                            PrintWordPDF(lCfg[0], (BinEndereco.Current as TRegistro_CadEndereco)
                                                     , (BinContatos.DataSource as TList_CadContatoCliFor)
                                                     , (BinClifor.Current as TRegistro_CadClifor)
                                                     , (BinParcelas.DataSource as TList_Orcamento_DT_Vencto));
                            return;
                        }


                    object obj = new TCD_CadTerminal().BuscarEscalar(
                                   new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.cd_terminal",
                                            vOperador = "=",
                                            vVL_Busca = "'" + Utils.Parametros.pubTerminal.Trim() + "'"
                                        }
                                    }, "a.tp_imporcamento");
                    if (obj == null ? false : obj.ToString().Trim().ToUpper().Equals("T"))
                        try
                        {
                            CamadaNegocio.Faturamento.Orcamento.TCN_Orcamento.ImprimirOrcamento(bsOrcamento.Current as TRegistro_Orcamento,
                                                                                         BinClifor.Current as TRegistro_CadClifor,
                                                                                         BinEndereco.Current as TRegistro_CadEndereco,
                                                                                         BinEmpresa.Current as TRegistro_CadEmpresa);
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    else
                    {

                        Relatorio.Ident = "FLan_Orcamento";
                        if (BinEmpresa.Current != null)
                            if ((BinEmpresa.Current as TRegistro_CadEmpresa).Img != null)
                                Relatorio.Parametros_Relatorio.Add("IMAGEM_RELATORIO", (BinEmpresa.Current as TRegistro_CadEmpresa).Img);
                        if (!Altera_Relatorio)
                        {
                            //Chamar tela de gerenciamento de impressao
                            using (TFGerenciadorImpressao fImp = new TFGerenciadorImpressao())
                            {
                                fImp.St_enabled_enviaremail = true;
                                fImp.pCd_clifor = (bsOrcamento.Current as TRegistro_Orcamento).Cd_clifor;
                                fImp.pCd_representante = (bsOrcamento.Current as TRegistro_Orcamento).Cd_representante;
                                fImp.pMensagem = "ORÇAMENTO Nº " + (bsOrcamento.Current as TRegistro_Orcamento).Nr_orcamentostr;
                                if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                                    Relatorio.Gera_Relatorio((bsOrcamento.Current as TRegistro_Orcamento).Nr_orcamentostr,
                                                             fImp.pSt_imprimir,
                                                             fImp.pSt_visualizar,
                                                             fImp.pSt_enviaremail,
                                                             fImp.pSt_exportPdf,
                                                             fImp.Path_exportPdf,
                                                             fImp.pDestinatarios,
                                                             null,
                                                             "ORÇAMENTO Nº " + (bsOrcamento.Current as TRegistro_Orcamento).Nr_orcamentostr,
                                                             fImp.pDs_mensagem);
                            }
                        }
                        else
                        {
                            Relatorio.Gera_Relatorio();
                            Altera_Relatorio = false;
                        }

                    }
                }
            }
        }

        private void PrintWordPDF(TRegistro_CFGOrcamento rCFG
            , TRegistro_CadEndereco rEndereco
            , TList_CadContatoCliFor lContatoClifor
            , TRegistro_CadClifor rClifor
            , TList_Orcamento_DT_Vencto lParcelas)
        {
            if (rCFG != null)
            {
                using (TFPrintOrcamentoWord fPrint = new TFPrintOrcamentoWord())
                {
                    fPrint.rCFG = rCFG;
                    fPrint.rEndereco = rEndereco;
                    fPrint.rClifor = rClifor;
                    fPrint.lContatoClifor = lContatoClifor;
                    fPrint.lParcelas = lParcelas;
                    fPrint.rOrcamento = bsOrcamento.Current as TRegistro_Orcamento;
                    (bsOrcamento.Current as TRegistro_Orcamento).lItens.ForEach(p =>
                        fPrint.lItem.Add(p));
                    fPrint.ShowDialog();
                }
            }
        }

        private bool bloqueioCredito()
        {
            if ((!string.IsNullOrEmpty((bsOrcamento.Current as TRegistro_Orcamento).Cd_clifor)))
            {
                CamadaDados.Financeiro.Duplicata.TRegistro_DadosBloqueio rDados = new CamadaDados.Financeiro.Duplicata.TRegistro_DadosBloqueio();
                if (CamadaNegocio.Financeiro.Duplicata.TCN_DadosBloqueio.VerificarBloqueioCredito((bsOrcamento.Current as TRegistro_Orcamento).Cd_clifor,
                                                               decimal.Zero,
                                                               true,
                                                               ref rDados,
                                                               null))
                    using (Financeiro.TFLan_BloqueioCredito fBloq = new Financeiro.TFLan_BloqueioCredito())
                    {
                        fBloq.rDados = rDados;
                        fBloq.Vl_fatura = decimal.Zero;
                        fBloq.ShowDialog();
                        return fBloq.St_desbloqueado;
                    }
                else
                    return true;
            }
            else
                return true;
        }

        private void TotalProjEspeciais()
        {
            decimal tot_projetos = decimal.Zero;
            object obj = new TCD_Orcamento_Item().BuscarEscalar(
                new TpBusca[]
                {
                    new TpBusca
                    {
                        vNM_Campo = "isnull(a.st_projespecial, 'N')",
                        vOperador = "=",
                        vVL_Busca = "'S'"
                    },
                    new TpBusca
                    {
                        vNM_Campo = "a.id_formulacao",
                        vOperador = "is",
                        vVL_Busca = "null"
                    },
                    new TpBusca
                    {
                        vNM_Campo = string.Empty,
                        vOperador = "exists",
                        vVL_Busca = "(select 1 from TB_FAT_Orcamento x " +
                                    "where x.nr_orcamento = a.nr_orcamento " +
                                    "and isnull(x.st_registro, 'AB') = 'AB') "
                    }
                }, "count(*)");
            if (obj == null ? false : !string.IsNullOrEmpty(obj.ToString()))
            {
                tot_projetos = Convert.ToDecimal(obj.ToString());
                lbLabel.Visible = true;
                lblProjeto.Visible = true;
                lbLabel.Text = tot_projetos > 1 ? "PROJETOS ESPECIAIS: " : "PROJETO ESPECIAL: ";
                lblProjeto.Text = tot_projetos.ToString();
            }
            else
            {
                lbLabel.Visible = false;
                lblProjeto.Visible = false;
            }
        }

        private void SimularImpostos()
        {
            if(bsOrcamento.Current != null)
                using (TFSimuladorImpostos fSimular = new TFSimuladorImpostos())
                {
                    fSimular.pCd_empresa = (bsOrcamento.Current as TRegistro_Orcamento).Cd_empresa;
                    fSimular.pNm_empresa = (bsOrcamento.Current as TRegistro_Orcamento).Nm_empresa;
                    string auxCfg = string.Empty;
                    if (!string.IsNullOrEmpty((bsOrcamento.Current as TRegistro_Orcamento).Cfg_pedido))
                    {
                        auxCfg = (bsOrcamento.Current as TRegistro_Orcamento).Cfg_pedido;
                        fSimular.pCfg_pedido = (bsOrcamento.Current as TRegistro_Orcamento).Cfg_pedido;
                        fSimular.pDs_tipopedido = (bsOrcamento.Current as TRegistro_Orcamento).Ds_tipopedido;
                        fSimular.pTp_mov = "S";
                    }
                    else
                    {
                        //Buscar config do orcamento
                        TList_CFGOrcamento lCfg =
                            CamadaNegocio.Faturamento.Cadastros.TCN_CFGOrcamento.Buscar((bsOrcamento.Current as TRegistro_Orcamento).Cd_empresa,
                                                                                        string.Empty,
                                                                                        string.Empty,
                                                                                        null);
                        if (lCfg.Count > 0)
                        {
                            auxCfg = (bsOrcamento.Current as TRegistro_Orcamento).Cfg_pedido;
                            fSimular.pCfg_pedido = lCfg[0].Cfg_pedido;
                            fSimular.pDs_tipopedido = lCfg[0].Ds_tipopedido;
                            fSimular.pTp_mov = "S";//Orcamento somente para venda
                        }
                    }
                    fSimular.pCd_clifor = (bsOrcamento.Current as TRegistro_Orcamento).Cd_clifor;
                    fSimular.pNm_clifor = (bsOrcamento.Current as TRegistro_Orcamento).Nm_clifor;
                    fSimular.pCd_endereco = (bsOrcamento.Current as TRegistro_Orcamento).Cd_endereco;
                    fSimular.pDs_endereco = (bsOrcamento.Current as TRegistro_Orcamento).Ds_endereco;
                    fSimular.St_calcavulso = false;
                    if (bsOrcamento.Current != null)
                        (bsOrcamento.Current as TRegistro_Orcamento).lItens.ForEach(p =>
                        {
                            fSimular.lProdSimular.Add(
                                new TRegistro_ProdutoSimular()
                                {
                                    Cd_produto = p.Cd_produto,
                                    Cd_condfiscal_produto = p.Cd_condfiscal_produto,
                                    Ds_condfiscal_produto = p.Ds_condfiscal_produto,
                                    Ds_produto = p.Ds_produto,
                                    Quantidade = p.Quantidade,
                                    Sg_unidade = p.Sigla_unid_produto,
                                    Ncm = p.NCM,
                                    Vl_unitario = p.Vl_unitario
                                });
                        });
                    fSimular.ShowDialog();
                }
        }

        private void TFLan_Proposta_Load(object sender, EventArgs e)
        {
            ShapeGrid.RestoreShape(this, gItens);
            ShapeGrid.RestoreShape(this, gOrcamento);
            ShapeGrid.RestoreShape(this, dataGridDefault2);
            Icon = ResourcesUtils.TecnoAliance_ICO;
            pFiltro.set_FormatZero();
            tlpProposta.ColumnStyles[1].Width = 0;
            cbEmpresa.DataSource = new TCD_CadEmpresa().Select(
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

            tcDetalhe.TabPages.Remove(EtaPro);
            if (TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin, "PERMITIR VISUALIZAR ETAPAS", null))
                tcDetalhe.TabPages.Add(EtaPro);
            st_estornar = TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin, "PERMITIR ESTORNAR CANCELAMENTO PROPOSTA", null);
            st_estornarProcess = TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin, "PERMITIR CANCELAR PEDIDO", null);
            //Buscar Compromissos Agendados
            DateTime dt_atual = CamadaDados.UtilData.Data_Servidor();
            lblAgenda.Text = CamadaNegocio.Faturamento.AgendaVendedor.TCN_AgendaVendedor.Buscar(string.Empty,
                                                                                                Utils.Parametros.pubLogin,
                                                                                                string.Empty,
                                                                                                string.Empty,
                                                                                                dt_atual.ToString("dd/MM/yyyy"),
                                                                                                "'0'",
                                                                                                null).Count().ToString();
            //Buscar Vendedor do Login
            object obj = new TCD_CadClifor().BuscarEscalar(
                new TpBusca[] 
                {
                    new TpBusca { vNM_Campo = "a.loginvendedor", vOperador = "=", vVL_Busca = "'" + Utils.Parametros.pubLogin.Trim() + "'" },
                    new TpBusca { vNM_Campo = "isnull(a.st_vendedor, 'N')", vOperador = "=", vVL_Busca = "'S'" },
                    new TpBusca { vNM_Campo = "isnull(a.st_registro, 'A')", vOperador = "<>", vVL_Busca = "'C'" },
                    new TpBusca { vNM_Campo = "isnull(a.st_funcativo, 'N')", vOperador = "=", vVL_Busca = "'S'" }
                }, "a.nm_clifor");
            if (obj != null)
                tslVendedor.Text = obj.ToString();
            else tslVendedor.Text = "LOGIN SEM VENDEDOR ATIVO";
            TotalProjEspeciais();
        }

        private void BB_Novo_Click(object sender, EventArgs e)
        {
            afterNovo();
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            afterBusca();
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BB_Excluir_Click(object sender, EventArgs e)
        {
            afterExclui();
        }
        
        private void bb_clifor_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaClifor(new EditDefault[] { nm_clifor }, string.Empty);
        }

        private void bb_endereco_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("a.ds_endereco|Endereço|200;a.cd_endereco|Codigo|80",
                                    new EditDefault[] { ds_endereco },
                                    new TCD_CadEndereco(), string.Empty);
        }
        
        private void bsOrcamento_PositionChanged(object sender, EventArgs e)
        {
            if (bsOrcamento.Current != null)
            {
                if ((bsOrcamento.Current as TRegistro_Orcamento).Nr_pedidovenda != null)
                {
                    //Buscar Pedido
                    (bsOrcamento.Current as TRegistro_Orcamento).rPedido =
                    new TCD_Pedido().Select(
                        new TpBusca[]
                        {
                                new TpBusca()
                                {
                                   vNM_Campo = "a.nr_pedido",
                                   vOperador = "=",
                                   vVL_Busca = (bsOrcamento.Current as TRegistro_Orcamento).Nr_pedidovenda.ToString()
                                }
                        }, 1, string.Empty)[0];

                    //Buscar Itens
                    (bsOrcamento.Current as TRegistro_Orcamento).rPedido.Pedido_Itens =
                        TCN_LanPedido_Item.Busca(string.Empty,
                                                string.Empty,
                                                string.Empty,
                                                (bsOrcamento.Current as TRegistro_Orcamento).rPedido.Nr_pedido.ToString(),
                                                string.Empty,
                                                string.Empty,
                                                "a.id_pedidoitem",
                                                false,
                                                null);
                }
                BB_Excluir.Text = (bsOrcamento.Current as TRegistro_Orcamento).St_registro.Trim().ToUpper().Equals("CA") ? "(F5)\nEstornar Cancel." : "(F5)\nCancelar";
                (bsOrcamento.Current as TRegistro_Orcamento).lItens =
                    CamadaNegocio.Faturamento.Orcamento.TCN_Orcamento_Item.Buscar(
                    (bsOrcamento.Current as TRegistro_Orcamento).Nr_orcamentostr,
                    false,
                    false,
                    null);
                (bsOrcamento.Current as TRegistro_Orcamento).lParcelas =
                    CamadaNegocio.Faturamento.Orcamento.TCN_Orcamento_DT_Vencto.Buscar(
                    (bsOrcamento.Current as TRegistro_Orcamento).Nr_orcamentostr,
                    null);
                tcDetalhe_SelectedIndexChanged(this, new EventArgs());
                bsOrcamento.ResetCurrentItem();
                TotalizarOrcamento();
                bsItens_PositionChanged(this, new EventArgs());
                tlpProposta.ColumnStyles[1].Width = (bsOrcamento.Current as TRegistro_Orcamento).St_registro.Trim().ToUpper().Equals("CA") ? 214 : 0;
            }
        }

        private void BB_Alterar_Click(object sender, EventArgs e)
        {
            afterAltera();
        }

        private void TFLan_Proposta_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F2))
                afterNovo();
            else if (e.KeyCode.Equals(Keys.F3))
                afterAltera();
            else if (e.KeyCode.Equals(Keys.F5))
                afterExclui();
            else if (e.KeyCode.Equals(Keys.F7))
                afterBusca();
            else if (e.KeyCode.Equals(Keys.F9))
                ProcessarOrcamento();
            else if (e.KeyCode.Equals(Keys.F10))
                EstornarProcess();
            else if (e.Control && e.KeyCode.Equals(Keys.P))
            {
                Altera_Relatorio = true;
                MessageBox.Show("Execute o relatório que deseja alterar!", "Mensagem");
            }
        }

        private void gOrcamento_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
                if (e.ColumnIndex == 0)
                {
                    if (e.Value.ToString().Trim().ToUpper().Equals("CANCELADA"))
                    {
                        DataGridViewRow linha = gOrcamento.Rows[e.RowIndex];
                        linha.DefaultCellStyle.ForeColor = Color.Red;
                    }
                    else if (e.Value.ToString().Trim().ToUpper().Equals("PROPOSTA APROVADA"))
                    {
                        DataGridViewRow linha = gOrcamento.Rows[e.RowIndex];
                        linha.DefaultCellStyle.ForeColor = Color.Blue;
                    }
                    else if (e.Value.ToString().Trim().ToUpper().Equals("PROPOSTA FECHADA"))
                    {
                        DataGridViewRow linha = gOrcamento.Rows[e.RowIndex];
                        linha.DefaultCellStyle.ForeColor = Color.Green;
                    }
                    else
                    {
                        DataGridViewRow linha = gOrcamento.Rows[e.RowIndex];
                        linha.DefaultCellStyle.ForeColor = Color.Black;
                    }
                }
        }

        private void bb_faturar_Click(object sender, EventArgs e)
        {
            ProcessarOrcamento();
        }

        private void visualizarPedidoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Print();
        }

        private void TFLan_Proposta_FormClosing(object sender, FormClosingEventArgs e)
        {
            ShapeGrid.SaveShape(this, gItens);
            ShapeGrid.SaveShape(this, gOrcamento);
            ShapeGrid.SaveShape(this, dataGridDefault2);
        }

        private void tcDetalhe_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bsOrcamento.Current == null)
                return;
            if (tcDetalhe.SelectedTab.Equals(tpNF))
            {
                //busca nota
                (bsOrcamento.Current as TRegistro_Orcamento).lNotaFiscal =
                    new CamadaDados.Faturamento.NotaFiscal.TCD_LanFaturamento().Select(
                        new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = string.Empty,
                                vOperador = "exists",
                                vVL_Busca = "(select 1 from vtb_fat_orcamento x "+
                                            " join tb_fat_pedido_itens z "+
                                            " on z.nr_orcamento = x.nr_orcamento " +
                                            "where z.Nr_Pedido = a.nr_pedido "+
                                            "and x.nr_orcamento = "+(bsOrcamento.Current as TRegistro_Orcamento).Nr_orcamento.ToString()+")"
                            }
                        }, 0, string.Empty);
                bsOrcamento.ResetCurrentItem();
            }
            else if (tcDetalhe.SelectedTab.Equals(tpdup))
            {
                // busca duplicata
                if ((bsOrcamento.Current as TRegistro_Orcamento).Nr_pedidovenda.HasValue)
                    (bsOrcamento.Current as TRegistro_Orcamento).lParc =
                            new CamadaDados.Financeiro.Duplicata.TCD_LanParcela().Select(
                            new TpBusca[]
                            {
                                new TpBusca
                                {
                                    vNM_Campo = "isnull(dup.st_registro, 'A')",
                                    vOperador = "<>",
                                    vVL_Busca = "'C'"
                                },
                                new TpBusca
                                {
                                    vNM_Campo = string.Empty,
                                    vOperador = "exists",
                                    vVL_Busca = "(select 1 from tb_fat_pedido_x_duplicata x " +
                                                "where x.cd_empresa = a.cd_empresa " +
                                                "and x.nr_lancto = a.nr_lancto " +
                                                "and x.nr_pedido = " + (bsOrcamento.Current as TRegistro_Orcamento).Nr_pedidovenda.Value.ToString() + ")"
                                }
                            }, 0, string.Empty, string.Empty, string.Empty);
                bsOrcamento.ResetCurrentItem();
            }
            else if (tcDetalhe.SelectedTab.Equals(EtaPro))
            {
                if ((bsOrcamento.Current as TRegistro_Orcamento).Nr_pedidovenda.HasValue)
                {
                    (bsOrcamento.Current as TRegistro_Orcamento).lEtapa = TCN_EtapaPedido.Busca(string.Empty,
                                                                                                (bsOrcamento.Current as TRegistro_Orcamento).Nr_pedidovenda.ToString(),
                                                                                                null);
                    (bsOrcamento.Current as TRegistro_Orcamento).lEtapa.ForEach(p => p.lProcEtapa = TCN_ProcEtapa.Busca(p.Id_etapastr,
                        p.Nr_pedidostr,
                        string.Empty,
                        null));
                }
                bsOrcamento.ResetCurrentItem();
            }
            else if (tcDetalhe.SelectedTab.Equals(tpAcessorios) && 
                (bsOrcamento.Current as TRegistro_Orcamento).Nr_pedidovenda != null)
            {
                //Buscar Acessórios
                (bsOrcamento.Current as TRegistro_Orcamento).lAcessorios =
                    TCN_AcessoriosPed.Buscar((bsOrcamento.Current as TRegistro_Orcamento).Nr_pedidovenda.ToString(),
                                                                                string.Empty,
                                                                                string.Empty,
                                                                                null);
                bsOrcamento.ResetCurrentItem();
            }
        }

        private void dgProcesso_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
                if (e.ColumnIndex == 0)

                    if (!string.IsNullOrEmpty((bs_processo[e.RowIndex] as TRegistro_ProcEtapa).Dt_processostr))
                    {
                        DataGridViewRow linha = gProcessos.Rows[e.RowIndex];
                        linha.DefaultCellStyle.ForeColor = Color.Blue;
                    }
                    else
                    {
                        DataGridViewRow linha = gProcessos.Rows[e.RowIndex];
                        linha.DefaultCellStyle.ForeColor = Color.Red;
                    }
        }

        private void dgEtapa_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
                if (e.ColumnIndex == 0)
                    if (e.Value.ToString().Trim().ToUpper().Equals("ABERTO"))
                    {
                        DataGridViewRow linha = gEtapas.Rows[e.RowIndex];
                        linha.DefaultCellStyle.ForeColor = Color.Red;
                    }
                    else
                    {
                        DataGridViewRow linha = gEtapas.Rows[e.RowIndex];
                        linha.DefaultCellStyle.ForeColor = Color.Blue;
                    }
        }

        private void bs_processo_PositionChanged(object sender, EventArgs e)
        {

            if (bs_processo.Current != null)
                (bs_processo.Current as TRegistro_ProcEtapa).lAnexo = TCN_AnexoPedido.Buscar(
                                            (bs_processo.Current as TRegistro_ProcEtapa).Nr_pedidostr,
                                            string.Empty,
                                            (bs_processo.Current as TRegistro_ProcEtapa).Id_processostr,
                                            (bs_processo.Current as TRegistro_ProcEtapa).Id_Anexo,
                                            null);
            bs_processo.ResetCurrentItem();
        }

        private void toolStripButton41_Click(object sender, EventArgs e)
        {
            if (bsAnexo.Current as TRegistro_AnexoPedido != null)
            {
                string ae;
                byte[] arquivoBuffer = (bsAnexo.Current as TRegistro_AnexoPedido).Anexo;
                string extensao = (bsAnexo.Current as TRegistro_AnexoPedido).Ext_Anexo; // retornar do banco tbm
                ae = System.IO.Path.ChangeExtension(System.IO.Path.GetTempFileName(), extensao);

                System.IO.File.WriteAllBytes(
                    ae,
                    arquivoBuffer);

                // para abrir o arquivo para o usuario
                System.Diagnostics.Process.Start(ae);
            }
        }

        private void bb_imfichatec_Click(object sender, EventArgs e)
        {
            if (bsFichaTec.Count > 0)
            {
                Relatorio Relatorio = new Relatorio();
                Relatorio.Altera_Relatorio = Altera_Relatorio;
                //DADOS PERTINENTES PARA A GERAÇÂO DO RELATORIO
                Relatorio.Nome_Relatorio = "REL_FAT_FICHATECNICA_ORC";
                Relatorio.NM_Classe = "REL_FAT_FICHATECNICA_ORC";
                Relatorio.Modulo = "FAT";
                Relatorio.Ident = "REL_FAT_FICHATECNICA_ORC";

                //Buscar ficha tecnica produto
                TList_Orcamento_Item lItens = new TList_Orcamento_Item();
                CamadaNegocio.Faturamento.Orcamento.TCN_Orcamento.MontarFichaTecItem((bsOrcamento.Current as TRegistro_Orcamento).Cd_empresa,
                                                                                     (bsItens.Current as TRegistro_Orcamento_Item).Cd_local,
                                                                                     bsItens.Current as TRegistro_Orcamento_Item,
                                                                                     lItens);
                BindingSource bsFicha = new BindingSource();
                bsFicha.DataSource = lItens;
                Relatorio.DTS_Relatorio = bsFicha;
                Relatorio.Parametros_Relatorio.Add("NR_PEDIDO", (bsItens.Current as TRegistro_Orcamento_Item).Nr_orcamento);
                Relatorio.Parametros_Relatorio.Add("CD_PRODUTO", (bsItens.Current as TRegistro_Orcamento_Item).Cd_produto);
                Relatorio.Parametros_Relatorio.Add("DS_PRODUTO", (bsItens.Current as TRegistro_Orcamento_Item).Ds_produto);

                if (!Altera_Relatorio)
                {
                    //Chamar tela de gerenciamento de impressao
                    using (TFGerenciadorImpressao fImp = new TFGerenciadorImpressao())
                    {
                        fImp.St_enabled_enviaremail = true;
                        fImp.pCd_clifor = string.Empty;
                        fImp.pMensagem = "FICHA TECNICA DO PRODUTO " + (bsItens.Current as TRegistro_Orcamento_Item).Cd_produto.Trim();
                        if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                            Relatorio.Gera_Relatorio((bsItens.Current as TRegistro_Orcamento_Item).Cd_produto.Trim(),
                                                     fImp.pSt_imprimir,
                                                     fImp.pSt_visualizar,
                                                     fImp.pSt_enviaremail,
                                                     fImp.pSt_exportPdf,
                                                     fImp.Path_exportPdf,
                                                     fImp.pDestinatarios,
                                                     null,
                                                     "FICHA TECNICA DO PRODUTO " + (bsItens.Current as TRegistro_Orcamento_Item).Cd_produto.Trim(),
                                                     fImp.pDs_mensagem);
                    }
                }
                else
                {
                    Relatorio.Gera_Relatorio();
                    Altera_Relatorio = false;
                }
            }
        }

        private void CD_UF_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.uf|=|'" + CD_UF.Text + "'",
                   new EditDefault[] { CD_UF }, new TCD_CadUf());
        }

        private void BB_UF_Click(object sender, EventArgs e)
        {
            string vColunas = "a.UF|Sigla|60;" +
                              "a.DS_UF|Estado|100";
            UtilPesquisa.BTN_BUSCA(vColunas,
                   new EditDefault[] { CD_UF }, new TCD_CadUf(), string.Empty);
        }

        private void listagemDeOrçamentosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bsOrcamento.Count > 0)
            {
                using (TFGerenciadorImpressao fImp = new TFGerenciadorImpressao())
                {
                    Relatorio Rel = new Relatorio();
                    Rel.Altera_Relatorio = Altera_Relatorio;
                    Rel.DTS_Relatorio = bsOrcamento;
                    Rel.Nome_Relatorio = "TFLan_Orcamento_Lista";
                    Rel.NM_Classe = this.Name;
                    Rel.Modulo = "FAT";
                    Rel.Ident = "TFLan_Orcamento_Lista";
                    fImp.St_enabled_enviaremail = true;
                    fImp.pCd_clifor = string.Empty;
                    fImp.pMensagem = "RELATÓRIO LISTA DE ORÇAMENTOS";

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
                                           "RELATÓRIO LISTA DE ORÇAMENTOS",
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
                                           "RELATÓRIO LISTA DE ORÇAMENTOS",
                                           fImp.pDs_mensagem);
                }
            }
            else
            {
                MessageBox.Show("Não existe Registros Para Imprimir o Relatório!");
            }
        }

        private void cd_representante_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + cd_representante.Text.Trim() + "';isnull(a.st_representante, 'N')|=|'S'",
               new EditDefault[] { cd_representante }, new TCD_CadClifor());
        }

        private void bb_representante_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaClifor(new EditDefault[] { cd_representante }, "isnull(a.st_representante, 'N')|=|'S'");
        }

        private void bb_excuir_etapa_Click(object sender, EventArgs e)
        {
            if (BS_etapa.Current != null)
            {
                if (bs_processo.Current != null)
                    if (!string.IsNullOrEmpty((bs_processo.Current as TRegistro_ProcEtapa).Dt_processostr))
                    {
                        MessageBox.Show("Não é possível excluir etapa FINALIZADA!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                if (MessageBox.Show("Confirma exclusão do registro?\r\n" +
                                       "Deseja excluir esta etapa.",
                                       "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                        == DialogResult.Yes)
                {
                    try
                    {
                        TCN_EtapaPedido.Excluir(BS_etapa.Current as TRegistro_EtapaPedido, null);
                        // afterBusca();
                        BS_etapa.RemoveCurrent();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
                MessageBox.Show("Obrigatorio selecionar etapa para excluir.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btn_finalizar_Click(object sender, EventArgs e)
        {
            if (bs_processo.Current != null)
            {
                //Verificar se usuario tem acesso a etapa.
                if (new TCD_CadUsuario_EtapaPed().BuscarEscalar(
                        new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = "a.id_etapa",
                                vOperador = "=",
                                vVL_Busca = (BS_etapa.Current as TRegistro_EtapaPedido).Id_etapastr
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "a.login",
                                vOperador = "=",
                                vVL_Busca = "'" + Utils.Parametros.pubLogin.Trim() + "'"
                            }
                        }, "1") == null)
                {
                    MessageBox.Show("Usuário não tem permissão para evoluir etapa " +
                                    (BS_etapa.Current as TRegistro_EtapaPedido).DS_Etapa.Trim() + "!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (!string.IsNullOrEmpty((bs_processo.Current as TRegistro_ProcEtapa).Dt_processostr))
                {
                    MessageBox.Show("Não é possível finalizar processo FINALIZADO!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (MessageBox.Show("Confirma a finalização do processo " +
                                   (bs_processo.Current as TRegistro_ProcEtapa).DS_Processo.Trim() + "?",
                                   "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                                    == DialogResult.Yes)
                    try
                    {
                        TCN_ProcEtapa.Finalizar(bs_processo.Current as TRegistro_ProcEtapa, (bsOrcamento.Current as TRegistro_Orcamento).rPedido, null);
                        MessageBox.Show("Processo finalizado com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        afterBusca();
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            }
        }

        private void btn_editarObs_Click(object sender, EventArgs e)
        {
            if (bs_processo.Current != null)
            {
                //Verificar se usuario tem acesso a etapa.
                if (new TCD_CadUsuario_EtapaPed().BuscarEscalar(
                        new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = "a.id_etapa",
                                vOperador = "=",
                                vVL_Busca = (BS_etapa.Current as TRegistro_EtapaPedido).Id_etapastr
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "a.login",
                                vOperador = "=",
                                vVL_Busca = "'" + Utils.Parametros.pubLogin.Trim() + "'"
                            }
                        }, "1") == null)
                {
                    MessageBox.Show("Usuário não tem permissão para evoluir etapa " +
                                    (BS_etapa.Current as TRegistro_EtapaPedido).DS_Etapa.Trim() + "!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                //Criar Form
                using (fEditar = new Form())
                {
                    fEditar.Size = new Size(520, 360);
                    fEditar.StartPosition = FormStartPosition.CenterScreen;
                    fEditar.ShowInTaskbar = false;
                    fEditar.Icon = ResourcesUtils.TecnoAliance_ICO;
                    fEditar.MinimizeBox = false;
                    fEditar.FormBorderStyle = FormBorderStyle.Fixed3D;
                    fEditar.Text = "Editar Obs";

                    //Criar Panel
                    Panel panel = new Panel();
                    panel.Dock = DockStyle.Fill;

                    // se processado apenas visualizar
                    if (string.IsNullOrEmpty((bs_processo.Current as TRegistro_ProcEtapa).Dt_processostr))
                    {
                        Button btn = new Button();
                        panel.Controls.Add(btn);
                        btn.Dock = DockStyle.Bottom;
                        btn.Text = "Gravar";
                        btn.Click += new System.EventHandler(btn_Click);
                    }
                    //Criar Texbox
                    TextBox txt = new TextBox();
                    fEditar.Controls.Add(panel);
                    panel.Controls.Add(txt);
                    txt.BorderStyle = BorderStyle.FixedSingle;
                    txt.Dock = DockStyle.Fill;
                    txt.Multiline = true;
                    txt.DataBindings.Add(new Binding("Text", bs_processo, "Obs", true, DataSourceUpdateMode.OnPropertyChanged));
                    txt.Text = (bs_processo.Current as TRegistro_ProcEtapa).Obs;
                    if (fEditar.ShowDialog() == DialogResult.OK)
                        if (!string.IsNullOrEmpty(txt.Text))
                            try
                            {
                                TCN_ProcEtapa.Gravar(bs_processo.Current as TRegistro_ProcEtapa, null);
                                afterBusca();
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }

            }
        }

        private void bb_excluir_procetapa_Click(object sender, EventArgs e)
        {
            if (BS_etapa.Current != null)
            {
                if (!string.IsNullOrEmpty((bs_processo.Current as TRegistro_ProcEtapa).Dt_processostr))
                {
                    MessageBox.Show("Não é possível excluir processo FINALIZADO!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if ((bs_processo.Current as TRegistro_ProcEtapa).lAnexo.Count > 0)
                {
                    MessageBox.Show("Não é possível excluir processo com anexo!\r\n" +
                                    "Exclua primeiro o anexo!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                {
                    if (MessageBox.Show("Confirma exclusão do registro?\r\n" +
                                       "Deseja excluir esta etapa.",
                                       "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                        == DialogResult.Yes)
                    {
                        try
                        {
                            TCN_ProcEtapa.Excluir(bs_processo.Current as TRegistro_ProcEtapa, null);
                            afterBusca();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
                MessageBox.Show("Obrigatorio selecionar etapa para excluir.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btn_reabrir_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty((bs_processo.Current as TRegistro_ProcEtapa).Dt_processostr))
            {
                //verifica se usuario pode reabrir etapa
                if (!TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin, "PERMITIR REABRIR ETAPA", null))
                {
                    MessageBox.Show("Usuário não possui permissão para reabrir!");
                }
                else
                {
                    if (MessageBox.Show("Reabrir processo selecionado? " +
                       (bs_processo.Current as TRegistro_ProcEtapa).DS_Processo.Trim() + "?",
                       "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                        == DialogResult.Yes)
                        try
                        {
                            TCN_ProcEtapa.Reabrir(bs_processo.Current as TRegistro_ProcEtapa, null);
                            MessageBox.Show("Processo reaberto com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            afterBusca();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                }
            }
            else
                MessageBox.Show("Processo está em aberto!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void bb_novoanexo_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty((bs_processo.Current as TRegistro_ProcEtapa).Dt_processostr))
            {
                if ((bsOrcamento.Current as TRegistro_Orcamento).rPedido != null)
                {
                    using (OpenFileDialog file = new OpenFileDialog())
                    {
                        if (file.ShowDialog() == DialogResult.OK)
                        {
                            if (System.IO.File.Exists(file.FileName))
                            {
                                if ((bs_processo.Current as TRegistro_ProcEtapa != null) && (BS_etapa.Current as TRegistro_EtapaPedido != null))
                                {
                                    TRegistro_AnexoPedido rAnexo =
                                        new TRegistro_AnexoPedido();
                                    rAnexo.Anexo = System.IO.File.ReadAllBytes(file.FileName);
                                    rAnexo.Ext_Anexo = System.IO.Path.GetExtension(file.FileName);
                                    InputBox ibp = new InputBox();
                                    ibp.Text = "Descrição Anexo";
                                    rAnexo.Id_processo = (bs_processo.Current as TRegistro_ProcEtapa).Id_processo;
                                    rAnexo.Id_etapa = (BS_etapa.Current as TRegistro_EtapaPedido).Id_etapa;
                                    string ds = ibp.ShowDialog();
                                    if (string.IsNullOrEmpty(ds))
                                    {
                                        MessageBox.Show("Obrigatório informar Descrição do Anexo!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        return;
                                    }
                                    try
                                    {
                                        rAnexo.Ds_anexo = ds;
                                        rAnexo.Nr_pedido = (bsOrcamento.Current as TRegistro_Orcamento).rPedido.Nr_pedido;
                                        TCN_AnexoPedido.Gravar(rAnexo, null);
                                        bs_processo_PositionChanged(this, new EventArgs());
                                        MessageBox.Show("Registro gravado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    }
                                    catch (Exception ex)
                                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Não é possível adicionar anexo onde  o processo é FINALIZADO!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void bb_excluiranexo_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty((bs_processo.Current as TRegistro_ProcEtapa).Dt_processostr))
            {
                if (bsAnexo.Current != null)
                    if (MessageBox.Show("Deseja excluir esse Anexo?", "Mensagem", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                        try
                        {
                            TCN_AnexoPedido.Excluir(bsAnexo.Current as TRegistro_AnexoPedido, null);
                            MessageBox.Show("Registro excluido com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //  tcItens_SelectedIndexChanged(this, new EventArgs());
                            bs_processo_PositionChanged(this, new EventArgs());
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
            else
            {
                MessageBox.Show("Não é possível excluir anexo do processo FINALIZADO!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_Click(object sender, EventArgs e)
        {
            fEditar.DialogResult = DialogResult.OK;
        }

        private void gerarDuplicataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bsOrcamento.Current != null)
                if ((bsOrcamento.Current as TRegistro_Orcamento).Nr_pedidovenda != null)
                {
                    //Verificar se o login tem acesso a tela de duplicatas
                    if (Utils.Parametros.pubLogin.Trim().ToUpper().Equals("MASTER") || Utils.Parametros.pubLogin.Trim().ToUpper().Equals("DESENV") ||
                        new TCD_CadAcesso().BuscarEscalar(
                                            new TpBusca[]
                                            {
                                                new TpBusca()
                                                {
                                                    vNM_Campo = "a.login",
                                                    vOperador = "=",
                                                    vVL_Busca = "'" + Utils.Parametros.pubLogin.Trim() + "'"
                                                },
                                                new TpBusca()
                                                {
                                                    vNM_Campo = "a.ID_Menu",
                                                    vOperador = "=",
                                                    vVL_Busca = "'050700' or exists(select 1 from tb_div_usuario_x_grupos x " +
                                                                                    "inner join tb_div_acesso y " +
                                                                                    "on y.Login = x.Logingrp " +
                                                                                    "where a.login = x.Loginusr " +
                                                                                    "and y.id_menu = '050700' " +
                                                                                    "and x.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "') "//Codigo Menu Tela Consulta Contas Pagar/Receber
                                                }
                                            }, "1") != null)
                    {
                        if (!(bsOrcamento.Current as TRegistro_Orcamento).rPedido.ST_Pedido.Trim().ToUpper().Equals("C"))
                        {
                            //Verificar se TP.Pedido tem permissão para gerar financeiro
                            if (new TCD_CadCFGPedido().BuscarEscalar(
                                 new TpBusca[]
                            {
                            new TpBusca()
                            {
                                vNM_Campo = "a.st_gerarfin",
                                vOperador = "=",
                                vVL_Busca = "'S'"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "a.cfg_pedido",
                                vOperador = "=",
                                vVL_Busca = "'" + (bsOrcamento.Current as TRegistro_Orcamento).rPedido.CFG_Pedido + "'"
                            }
                            }, "1") != null)
                            {
                                if (new TCD_Pedido().BuscarEscalar(
                                        new TpBusca[]
                                        {
                                            new TpBusca()
                                            {
                                                vNM_Campo = string.Empty,
                                                vOperador = "exists",
                                                vVL_Busca = "(select 1 from TB_FAT_Pedido_X_Duplicata x " +
                                                            "inner join TB_FIN_Duplicata y " +
                                                            "on x.cd_empresa = y.cd_empresa " +
                                                            "and x.nr_lancto = y.nr_lancto " +
                                                            "where isnull(y.st_registro, 'C') = 'A' " +
                                                            "and x.nr_pedido = '" + (bsOrcamento.Current as TRegistro_Orcamento).rPedido.Nr_pedido + "')"
                                            }
                                        }, "1") == null)
                                {
                                    using (Financeiro.TFLanDuplicata fDuplicata = new Financeiro.TFLanDuplicata())
                                    {
                                        fDuplicata.vCd_empresa = (bsOrcamento.Current as TRegistro_Orcamento).rPedido.CD_Empresa;
                                        fDuplicata.vNm_empresa = (bsOrcamento.Current as TRegistro_Orcamento).rPedido.Nm_Empresa;
                                        fDuplicata.vCd_clifor = (bsOrcamento.Current as TRegistro_Orcamento).rPedido.CD_Clifor;
                                        fDuplicata.vNm_clifor = (bsOrcamento.Current as TRegistro_Orcamento).rPedido.NM_Clifor;
                                        fDuplicata.vCd_endereco = (bsOrcamento.Current as TRegistro_Orcamento).rPedido.CD_Endereco;
                                        fDuplicata.vDs_endereco = (bsOrcamento.Current as TRegistro_Orcamento).rPedido.DS_Endereco;
                                        if (new TCD_CadCondPgto().BuscarEscalar(
                                                new TpBusca[]
                                                {
                                                    new TpBusca()
                                                    {
                                                        vNM_Campo = "a.CD_CondPGTO",
                                                        vOperador = "=",
                                                        vVL_Busca = "'" + (bsOrcamento.Current as TRegistro_Orcamento).rPedido.CD_CondPGTO.Trim() + "'"
                                                    },
                                                    new TpBusca()
                                                    {
                                                        vNM_Campo = "isnull(a.st_registro, 'A')",
                                                        vOperador = "<>",
                                                        vVL_Busca = "'C'"
                                                    }
                                                }, "1") == null)
                                        {
                                            MessageBox.Show("Condição de Pagamento não existe ou está cancelada!\r\n" +
                                                            "Troque a Condição de Pagamento da proposta para continuar! ", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            return;
                                        }
                                        fDuplicata.vCd_condpgto = (bsOrcamento.Current as TRegistro_Orcamento).rPedido.CD_CondPGTO;
                                        fDuplicata.vDs_condpgto = (bsOrcamento.Current as TRegistro_Orcamento).rPedido.DS_CondPgto;
                                        fDuplicata.vCd_moeda = (bsOrcamento.Current as TRegistro_Orcamento).rPedido.Cd_moeda;
                                        fDuplicata.vDs_moeda = (bsOrcamento.Current as TRegistro_Orcamento).rPedido.Ds_moeda;
                                        fDuplicata.vTp_mov = (bsOrcamento.Current as TRegistro_Orcamento).rPedido.TP_Movimento.Equals("E") ? "P" : "R";
                                        fDuplicata.vVl_documento = (bsOrcamento.Current as TRegistro_Orcamento).rPedido.Vl_totalpedido_liquido +
                                            ((bsOrcamento.Current as TRegistro_Orcamento).rPedido.Tp_frete.Trim().ToUpper().Equals("9") ||
                                             (bsOrcamento.Current as TRegistro_Orcamento).rPedido.Tp_frete.Trim().ToUpper().Equals("2") ?
                                            (bsOrcamento.Current as TRegistro_Orcamento).rPedido.Vl_frete : decimal.Zero);
                                        fDuplicata.vDt_emissao = CamadaDados.UtilData.Data_Servidor().ToString("dd/MM/yyyy");
                                        fDuplicata.vNr_pedido = (bsOrcamento.Current as TRegistro_Orcamento).rPedido.Nr_pedido;
                                        fDuplicata.vSt_finPed = true;
                                        if (fDuplicata.ShowDialog() == DialogResult.OK)
                                        {
                                            try
                                            {
                                                (bsOrcamento.Current as TRegistro_Orcamento).rPedido.lDup.Add(
                                                                        fDuplicata.dsDuplicata.Current as CamadaDados.Financeiro.Duplicata.TRegistro_LanDuplicata);
                                                TCN_Pedido.GravaDuplicata((bsOrcamento.Current as TRegistro_Orcamento).rPedido, null);
                                                afterBusca();
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
                                    MessageBox.Show("Não é possivel Gerar Financeiro! Pedido já possui Duplicata Ativa!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                            }
                            else
                            {
                                MessageBox.Show("Tipo de Pedido não tem permissão para Gerar Duplicata!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Não é possivel Gerar Duplicata em Pedido Cancelado!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                    else
                        MessageBox.Show("Usuário não tem acesso ao financeiro<TELA CONTA A PAGAR/RECEBER>!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
        }

        private void bb_inserirAcessorios_Click(object sender, EventArgs e)
        {
            if (!TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin, "PERMITIR ALTERAR ORÇAMENTO PROCESSADO", null))
            {
                MessageBox.Show("Usuário não possui permissão para alterar Orçamento processado!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if ((bsOrcamento.Current as TRegistro_Orcamento).Nr_pedidovenda != null)
            {
                using (TFAcessorioItem fItem = new TFAcessorioItem())
                {
                    fItem.pCd_empresa = (bsOrcamento.Current as TRegistro_Orcamento).rPedido.CD_Empresa;
                    if (fItem.ShowDialog() == DialogResult.OK)
                        if (fItem.rAcessorio != null)
                            try
                            {
                                if ((bsOrcamento.Current as TRegistro_Orcamento).rPedido.Pedido_Itens.Exists(p => p.Cd_produto.Equals(fItem.rAcessorio.Cd_produto)))
                                {
                                    MessageBox.Show("Não é possível inserir produtos existentes nos itens do pedido!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                                fItem.rAcessorio.Nr_pedido = (bsOrcamento.Current as TRegistro_Orcamento).rPedido.Nr_pedido;
                                TCN_AcessoriosPed.Gravar(fItem.rAcessorio, null);
                                MessageBox.Show("Item adicionado com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                tcDetalhe_SelectedIndexChanged(this, new EventArgs());
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            }
        }

        private void bb_excluirAcessorios_Click(object sender, EventArgs e)
        {
            if (!TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin, "PERMITIR ALTERAR ORÇAMENTO PROCESSADO", null))
            {
                MessageBox.Show("Usuário não possui permissão para alterar Orçamento processado!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (bsAcessoriosItem.Current != null)
                if (MessageBox.Show("Confirma a exclusão do acessório?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    == DialogResult.Yes)
                    try
                    {
                        TCN_AcessoriosPed.Excluir(bsAcessoriosItem.Current as TRegistro_AcessoriosPed, null);
                        MessageBox.Show("Acessório excluído com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        tcDetalhe_SelectedIndexChanged(this, new EventArgs());
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void Cd_produto_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVEProduto("a.cd_produto|=|'" + Cd_produto.Text.Trim() + "'",
                                                   new EditDefault[] { Cd_produto },
                                                   new CamadaDados.Estoque.Cadastros.TCD_CadProduto());
        }

        private void bb_produto_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaProduto(new EditDefault[] { Cd_produto }, string.Empty);
        }

        private void lblAgenda_Click(object sender, EventArgs e)
        {
            using (TFAgendaVendedor fAgenda = new TFAgendaVendedor())
            {
                fAgenda.ShowDialog();
                //Buscar Compromissos Agendados
                DateTime dt_atual = CamadaDados.UtilData.Data_Servidor();
                lblAgenda.Text = CamadaNegocio.Faturamento.AgendaVendedor.TCN_AgendaVendedor.Buscar(string.Empty,
                                                                                                    Utils.Parametros.pubLogin,
                                                                                                    string.Empty,
                                                                                                    string.Empty,
                                                                                                    dt_atual.ToString("dd/MM/yyyy"),
                                                                                                    "'0'",
                                                                                                    null).Count().ToString();
            }
        }
        
        private void bb_estornarProcess_Click(object sender, EventArgs e)
        {
            EstornarProcess();
        }

        private void folhaAzulToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bsOrcamento.Current != null)
            {
                if ((bsOrcamento.Current as TRegistro_Orcamento).rPedido.Nr_pedido > 0)

                {
                    TRegistro_Pedido pedido = (bsOrcamento.Current as TRegistro_Orcamento).rPedido;
                    TCN_Pedido.Busca_CFG_Fiscal(pedido);
                    TCN_Pedido.Busca_Pedido_Itens(pedido, false, null);
                    pedido.Pedidos_DT_Vencto = TCN_LanPedido_DT_Vencto.Busca(pedido.Nr_pedido, null);
                    if (pedido.Pedido_Itens.Count > 0)
                        pedido.Pedidos_DT_Vencto.ForEach(p => p.Vl_juro_fin = Math.Round((p.VL_Parcela * pedido.Pedido_Itens[0].Pc_juro_fin) / 100, 2));
                    BindingSource BinEmpresa = new BindingSource();
                    BinEmpresa.DataSource = TCN_CadEmpresa.Busca((bsOrcamento.Current as TRegistro_Orcamento).rPedido.CD_Empresa,
                                                                 string.Empty,
                                                                 string.Empty,
                                                                 null);

                    BindingSource BinClifor = new BindingSource();
                    BinClifor.DataSource = TCN_CadClifor.Busca_Clifor((bsOrcamento.Current as TRegistro_Orcamento).rPedido.CD_Clifor,
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
                                                                      1,
                                                                      null);

                    BindingSource BinEndereco = new BindingSource();
                    BinEndereco.DataSource = TCN_CadEndereco.Buscar((bsOrcamento.Current as TRegistro_Orcamento).rPedido.CD_Clifor,
                                                                    (bsOrcamento.Current as TRegistro_Orcamento).rPedido.CD_Endereco,
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

                    BindingSource BinEndEntrega = new BindingSource();
                    BinEndEntrega.DataSource = new TCD_CadEndereco().Select(
                        new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = "a.cd_clifor",
                                vOperador = "=",
                                vVL_Busca = "'" + (bsOrcamento.Current as TRegistro_Orcamento).rPedido.CD_Clifor + "'"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "a.st_endentrega",
                                vOperador = "=",
                                vVL_Busca = "'S'"
                            }
                        }, 1, string.Empty);


                    object cliforEmpresa = new TCD_CadEmpresa().BuscarEscalar(
                                        new TpBusca[]
                                        {
                                            new TpBusca()
                                            {
                                                vNM_Campo = "a.cd_empresa",
                                                vOperador = "=",
                                                vVL_Busca = "'" + (bsOrcamento.Current as TRegistro_Orcamento).rPedido.CD_Empresa + "'"
                                            }
                                        }, "a.cd_clifor");
                    BindingSource BinDadosFin = new BindingSource();
                    BinDadosFin.DataSource = TCN_CadDados_Bancarios_Clifor.Busca(cliforEmpresa.ToString(),
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  null);

                    BindingSource BinContatos = new BindingSource();
                    BinContatos.DataSource = TCN_CadContatoCliFor.Buscar(string.Empty,
                                                                         cliforEmpresa.ToString(),
                                                                         string.Empty,
                                                                         string.Empty,
                                                                         string.Empty,
                                                                         string.Empty,
                                                                         string.Empty,
                                                                         false,
                                                                         false,
                                                                         false,
                                                                         string.Empty,
                                                                         0,
                                                                         null);

                    BindingSource BinParcelas = new BindingSource();
                    if ((bsOrcamento.Current as TRegistro_Orcamento).rPedido.lDup.Count > 0)
                    {
                        CamadaDados.Financeiro.Duplicata.TList_RegLanParcela lParc =
                            new CamadaDados.Financeiro.Duplicata.TCD_LanParcela().Select(
                                new TpBusca[]
                                {
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.cd_empresa",
                                        vOperador = "=",
                                        vVL_Busca = "'" + (bsOrcamento.Current as TRegistro_Orcamento).rPedido.CD_Empresa.Trim() + "'"
                                    },
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.nr_lancto",
                                        vOperador = "=",
                                        vVL_Busca = (bsOrcamento.Current as TRegistro_Orcamento).rPedido.lDup[0].Nr_lancto.ToString()
                                    }
                                }, 0, string.Empty, string.Empty, string.Empty);
                        //Criar fonte de dados para parcelas pedido
                        lParc.ForEach(p =>
                        {
                            //Criar fonte de dados
                            DataTable tb_dup = new DataTable();
                            tb_dup.Columns.Add("Nr_Pedido", Type.GetType("System.Decimal"));
                            tb_dup.Columns.Add("VL_Parcela", Type.GetType("System.Decimal"));
                            tb_dup.Columns.Add("Dt_vencto", Type.GetType("System.DateTime"));
                            DataRow linha = tb_dup.NewRow();
                            linha["Nr_Pedido"] = (bsOrcamento.Current as TRegistro_Orcamento).rPedido.Nr_pedido;
                            linha["VL_Parcela"] = p.Vl_parcela;
                            linha["Dt_vencto"] = p.Dt_vencto;
                            BinParcelas.Add(linha);
                        });
                    }
                    else
                    {

                        BinParcelas.DataSource = TCN_LanPedido_DT_Vencto.Busca((bsOrcamento.Current as TRegistro_Orcamento).rPedido.Nr_pedido,
                                                                                                                 null);
                    }

                    BindingSource BinContatosClifor = new BindingSource();
                    BinContatosClifor.DataSource = TCN_CadContatoCliFor.Buscar(string.Empty,
                                                                                                               (bsOrcamento.Current as TRegistro_Orcamento).rPedido.CD_Clifor,
                                                                                                                string.Empty,
                                                                                                                string.Empty,
                                                                                                                string.Empty,
                                                                                                                string.Empty,
                                                                                                                string.Empty,
                                                                                                                false,
                                                                                                                false,
                                                                                                                false,
                                                                                                                string.Empty,
                                                                                                                0,
                                                                                                                null);

                    //Buscar Ficha Técnica do cadastro do produto
                    (bsOrcamento.Current as TRegistro_Orcamento).rPedido.Pedido_Itens.ForEach(p =>
                    {
                        if (new CamadaDados.Estoque.Cadastros.TCD_CadProduto().ProdutoComposto(p.Cd_produto))
                        {
                            p.lFicha =
                                CamadaNegocio.Estoque.Cadastros.TCN_FichaTecProduto.Buscar(p.Cd_produto,
                                                                                           string.Empty,
                                                                                           null);
                        }
                    });


                    Relatorio Relatorio = new Relatorio();
                    Relatorio.Altera_Relatorio = Altera_Relatorio;

                    //DADOS PERTINENTES PARA A GERAÇÂO DO RELATORIO
                    Relatorio.Nome_Relatorio = "TFRelPedido";
                    Relatorio.NM_Classe = "TFLan_Pedido";
                    Relatorio.Modulo = Tag.ToString().Substring(0, 3);

                    TList_Pedido lista_pedido = new TList_Pedido();
                    lista_pedido.Add(pedido);
                    BindingSource meu_bind = new BindingSource();
                    meu_bind.DataSource = lista_pedido;
                    BindingSource ITENS = new BindingSource();
                    ITENS.DataSource = (bsOrcamento.Current as TRegistro_Orcamento).rPedido.Pedido_Itens;
                    bsOrcamento.ResetCurrentItem();
                    Relatorio.Adiciona_DataSource("EMPRESA", BinEmpresa);
                    Relatorio.Adiciona_DataSource("CLIFOR", BinClifor);
                    Relatorio.Adiciona_DataSource("ENDERECO_CLIFOR", BinEndereco);
                    Relatorio.Adiciona_DataSource("ENDENTREGA", BinEndEntrega);
                    Relatorio.Adiciona_DataSource("ITENS", ITENS);
                    Relatorio.Adiciona_DataSource("DADOSFIN", BinDadosFin);
                    Relatorio.Adiciona_DataSource("EMPRESACONTATO", BinContatos);
                    Relatorio.Adiciona_DataSource("PARCELAS", BinParcelas);
                    Relatorio.Adiciona_DataSource("CONTATO_CLIFOR", BinContatosClifor);
                    Relatorio.DTS_Relatorio = meu_bind;

                    Relatorio.Ident = "TFRelPedido";
                    if (BinEmpresa.Current != null)
                        if ((BinEmpresa.Current as TRegistro_CadEmpresa).Img != null)
                            Relatorio.Parametros_Relatorio.Add("IMAGEM_RELATORIO", (BinEmpresa.Current as TRegistro_CadEmpresa).Img);
                    if (!Altera_Relatorio)
                    {
                        //Chamar tela de gerenciamento de impressao
                        using (TFGerenciadorImpressao fImp = new TFGerenciadorImpressao())
                        {
                            fImp.St_enabled_enviaremail = true;
                            fImp.pCd_clifor = (bsOrcamento.Current as TRegistro_Orcamento).rPedido.CD_Clifor;
                            fImp.pCd_representante = (bsOrcamento.Current as TRegistro_Orcamento).rPedido.Cd_representante;
                            fImp.pMensagem = ((bsOrcamento.Current as TRegistro_Orcamento).rPedido.Status_Pedido.Equals("ATIVO") ? "ORÇAMENTO Nº " : "PEDIDO Nº ") +
                                                                                       (bsOrcamento.Current as TRegistro_Orcamento).rPedido.Nr_pedido.ToString();
                            if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                                Relatorio.Gera_Relatorio((bsOrcamento.Current as TRegistro_Orcamento).rPedido.Nr_pedido.ToString(),
                                                        fImp.pSt_imprimir,
                                                        fImp.pSt_visualizar,
                                                        fImp.pSt_enviaremail,
                                                        fImp.pSt_exportPdf,
                                                        fImp.Path_exportPdf,
                                                        fImp.pDestinatarios,
                                                        null,
                                                        ((bsOrcamento.Current as TRegistro_Orcamento).rPedido.Status_Pedido.Equals("ATIVO") ? "ORÇAMENTO Nº " : "PEDIDO Nº ") +
                                                                                                        (bsOrcamento.Current as TRegistro_Orcamento).rPedido.Nr_pedido.ToString(),
                                                        fImp.pDs_mensagem);
                        }
                    }
                    else
                    {
                        Relatorio.Gera_Relatorio();
                        Altera_Relatorio = false;
                    }
                }
                else
                    MessageBox.Show("Proposta deve estar processada para gerar esta impressão!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void lblProjeto_Click(object sender, EventArgs e)
        {
            using (TFProjEspeciais fProj = new TFProjEspeciais())
            {
                if (fProj.ShowDialog() == DialogResult.OK)
                    if (fProj.lItem != null)
                        try
                        {
                            CamadaNegocio.Faturamento.Orcamento.TCN_Orcamento_Item.GravarLista(fProj.lItem, null);
                            MessageBox.Show("Itens alterados com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            TotalProjEspeciais();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void gItens_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
                if (e.ColumnIndex.Equals(0))
                {
                    if (e.Value.ToString().Trim().ToUpper().Equals("TRUE"))
                        gItens.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
                    else gItens.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                }
        }

        private void bsItens_PositionChanged(object sender, EventArgs e)
        {
            if(bsItens.Current != null)
            {
                (bsItens.Current as TRegistro_Orcamento_Item).lAnexo =
                    CamadaNegocio.Faturamento.Orcamento.TCN_AnexoItemOrc.Buscar((bsItens.Current as TRegistro_Orcamento_Item).Nr_orcamento.ToString(),
                                                                                (bsItens.Current as TRegistro_Orcamento_Item).Id_item.ToString(),
                                                                                null);
                bsItens.ResetCurrentItem();
            }
        }

        private void gOrcamento_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gOrcamento.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsOrcamento.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new TRegistro_Orcamento());
            TList_Orcamento lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gOrcamento.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gOrcamento.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new TList_Orcamento(lP.Find(gOrcamento.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gOrcamento.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new TList_Orcamento(lP.Find(gOrcamento.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gOrcamento.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsOrcamento.List as TList_Orcamento).Sort(lComparer);
            bsOrcamento.ResetBindings(false);
            gOrcamento.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
            bsOrcamento_PositionChanged(this, new EventArgs());
        }

        private void gItens_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gItens.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsItens.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new TRegistro_Orcamento_Item());
            TList_Orcamento_Item lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gItens.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gItens.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new TList_Orcamento_Item(lP.Find(gItens.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gItens.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new TList_Orcamento_Item(lP.Find(gItens.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gItens.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsItens.List as TList_Orcamento_Item).Sort(lComparer);
            bsItens.ResetBindings(false);
            gItens.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void calcularImpostosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SimularImpostos();
        }

        private void bbVendedor_Click(object sender, EventArgs e)
        {
            string cond = "isnull(a.st_vendedor, 'N')|=|'S'";
            UtilPesquisa.BTN_BuscaCliforC(new EditDefault[] { cd_vendedor }, cond);
        }

        private void cd_vendedor_Leave(object sender, EventArgs e)
        {
            string cond = "a.cd_clifor|=|'" + cd_vendedor.Text.Trim() + "';" +
                          "isnull(a.st_vendedor, 'N')|=|'S'";
            UtilPesquisa.EDIT_LeaveCliforC(cond, new EditDefault[] { cd_vendedor }, new TCD_CadClifor());
        }

        private void miTrocarCliente_Click(object sender, EventArgs e)
        {
            if (bsOrcamento.Current != null)
            {
                if((bsOrcamento.Current as TRegistro_Orcamento).St_registro.Trim().ToUpper() != "FT")
                {
                    MessageBox.Show("Permitido trocar cliente somente de proposta PROCESSADA.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                //Verificar se proposta ja possui troca cnpj
                if(new TCD_TrocaCliente().BuscarEscalar(
                    new TpBusca[]
                    {
                        new TpBusca
                        {
                            vNM_Campo = "a.nr_orcamento",
                            vOperador = "=",
                            vVL_Busca = (bsOrcamento.Current as TRegistro_Orcamento).Nr_orcamentostr
                        }
                    }, "1") != null)
                {
                    MessageBox.Show("Não é permitido fazer mais que uma troca de CNPJ por proposta.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                using (TFTrocarClienteProposta fTroca = new TFTrocarClienteProposta())
                {
                    fTroca.Orcamento = bsOrcamento.Current as TRegistro_Orcamento;
                    if(fTroca.ShowDialog() == DialogResult.OK)
                        try
                        {
                            CamadaNegocio.Faturamento.Orcamento.TCN_Orcamento.AlterarClienteProposta(fTroca.Orcamento, fTroca.pCd_clifor, fTroca.pMotivoTroca, fTroca.Login, null);
                            MessageBox.Show("Cliente alterado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LimparFitros();
                            nr_orcamento.Text = fTroca.Orcamento.Nr_orcamentostr;
                            afterBusca();
                        }
                        catch(Exception ex)
                        {
                            MessageBox.Show("Erro alterar cliente proposta: " + ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                }
            }
            else MessageBox.Show("Obrigatório selecionar proposta para trocar cliente.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void tsbTrocarItem_Click(object sender, EventArgs e)
        {
            if (bsItens.Current != null)
            {
                if ((bsOrcamento.Current as TRegistro_Orcamento).St_registro.Trim().ToUpper() != "FT")
                {
                    MessageBox.Show("Permitido trocar item somente de proposta PROCESSADA.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                using (TFTrocaItemProposta fTroca = new TFTrocaItemProposta())
                {
                    fTroca.rOrc = bsOrcamento.Current as TRegistro_Orcamento;
                    fTroca.rItemTroca = bsItens.Current as TRegistro_Orcamento_Item;
                    if(fTroca.ShowDialog() == DialogResult.OK)
                        try
                        {
                            CamadaNegocio.Faturamento.Orcamento.TCN_Orcamento_Item.TrocarItem(
                                new TRegistro_TrocaItemProposta
                                {
                                    Cd_empresa = (bsOrcamento.Current as TRegistro_Orcamento).Cd_empresa,
                                    MotivoTroca = fTroca.MotivoTroca,
                                    Login = fTroca.pLogin,
                                    ItemOrig = bsItens.Current as TRegistro_Orcamento_Item,
                                    ItemDest = fTroca.rNovoItem,
                                    rDup = fTroca.rDup
                                },
                                (bsOrcamento.Current as TRegistro_Orcamento).Cd_clifor,
                                (bsOrcamento.Current as TRegistro_Orcamento).Cd_endereco, 
                                null);
                            MessageBox.Show("Item trocado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LimparFitros();
                            nr_orcamento.Text = (bsOrcamento.Current as TRegistro_Orcamento).Nr_orcamentostr;
                            afterBusca();
                        }catch(Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            }
            else MessageBox.Show("Obrigatório selecionar item para trocar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}