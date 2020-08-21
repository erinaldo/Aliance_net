using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utils;

namespace Servicos
{
    public partial class TFPainelServSalao : Form
    {
        public bool Altera_Relatorio = false;
        System.Collections.Hashtable hs = new System.Collections.Hashtable();

        private CamadaDados.Servicos.Cadastros.TRegistro_CfgAgendamento rCfg
        { get; set; }

        public TFPainelServSalao()
        {
            InitializeComponent();
        }

        private void NovoAgendamento()
        {
            if (cbEmpresa.SelectedItem == null)
            {
                MessageBox.Show("Obrigatório selecionar empresa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbEmpresa.Focus();
                return;
            }
            using (TFAgendamento fAgenda = new TFAgendamento())
            {
                fAgenda.pCd_empresa = (cbEmpresa.SelectedItem as CamadaDados.Diversos.TRegistro_CadEmpresa).Cd_empresa;
                fAgenda.pData_agendamento = calendario.SelectionRange.Start.ToString("dd/MM/yyyy");
                if (fAgenda.ShowDialog() == DialogResult.OK)
                    if (fAgenda.rAgenda != null)
                        try
                        {
                            CamadaNegocio.Servicos.TCN_Agendamento.Gravar(fAgenda.rAgenda, null);
                            MessageBox.Show("Agendamento gravado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            BuscarAgendamento();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void AlterarAgendamento()
        {
            if (bsAgenda.Current != null)
                using (TFAgendamento fAgenda = new TFAgendamento())
                {
                    fAgenda.rAgenda = bsAgenda.Current as CamadaDados.Servicos.TRegistro_Agendamento;
                    fAgenda.pCd_empresa = (cbEmpresa.SelectedItem as CamadaDados.Diversos.TRegistro_CadEmpresa).Cd_empresa;
                    if (fAgenda.ShowDialog() == DialogResult.OK)
                        if (fAgenda.rAgenda != null)
                            try
                            {
                                CamadaNegocio.Servicos.TCN_Agendamento.Gravar(fAgenda.rAgenda, null);
                                MessageBox.Show("Agendamento alterado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                BuscarAgendamento();
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            else MessageBox.Show("Obrigatório selecionar agendamento para alterar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ExecutarServico()
        {
            if (bsAgenda.Current != null)
            {
                if (MessageBox.Show("Confirma execução do serviço?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                   == DialogResult.Yes)
                    try
                    {
                        if (rCfg == null)
                        {
                            MessageBox.Show("Não existe configuração para processar agendamento!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        bool st_executar = true;
                        if (string.IsNullOrEmpty((bsAgenda.Current as CamadaDados.Servicos.TRegistro_Agendamento).Cd_clifor))
                            using (TFAgendamento fAgenda = new TFAgendamento())
                            {
                                fAgenda.rAgenda = bsAgenda.Current as CamadaDados.Servicos.TRegistro_Agendamento;
                                if (fAgenda.ShowDialog() == DialogResult.OK)
                                    if (fAgenda.rAgenda != null)
                                        try
                                        {
                                            CamadaNegocio.Servicos.TCN_Agendamento.Gravar(fAgenda.rAgenda, null);
                                        }
                                        catch (Exception ex)
                                        { 
                                            MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            st_executar = false;
                                        }
                                    else st_executar = false;
                                else st_executar = false;
                            }
                        if (!st_executar)
                        {
                            MessageBox.Show("Não é permitido executar serviço sem cliente identificado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        if (string.IsNullOrEmpty((bsAgenda.Current as CamadaDados.Servicos.TRegistro_Agendamento).Cd_tecnico))
                        {
                            DataRowView linha = FormBusca.UtilPesquisa.BTN_BuscaClifor(null, "isnull(a.st_tecnico, 'N')|=|'S'");
                            if (linha != null)
                                (bsAgenda.Current as CamadaDados.Servicos.TRegistro_Agendamento).Cd_tecnico = linha["cd_clifor"].ToString();
                        }
                        (bsAgenda.Current as CamadaDados.Servicos.TRegistro_Agendamento).St_registro = "E";
                        //Criar serviço
                        CamadaDados.Servicos.TRegistro_LanServico rOs = new CamadaDados.Servicos.TRegistro_LanServico();
                        rOs.Cd_empresa = (bsAgenda.Current as CamadaDados.Servicos.TRegistro_Agendamento).Cd_empresa;
                        rOs.Cd_tabelapreco = rCfg.Cd_tabelapreco;
                        rOs.Tp_ordem = rCfg.Tp_ordem;
                        rOs.Cd_clifor = (bsAgenda.Current as CamadaDados.Servicos.TRegistro_Agendamento).Cd_clifor;
                        rOs.Nm_clifor = (bsAgenda.Current as CamadaDados.Servicos.TRegistro_Agendamento).Nm_clifor;
                        rOs.Cd_endereco = (bsAgenda.Current as CamadaDados.Servicos.TRegistro_Agendamento).Cd_endereco;
                        rOs.Ds_endereco = (bsAgenda.Current as CamadaDados.Servicos.TRegistro_Agendamento).Ds_endereco;
                        rOs.Dt_abertura = CamadaDados.UtilData.Data_Servidor();
                        rOs.St_prioridade = "1";
                        rOs.St_os = "AB";
                        
                        //Incluir Servico
                        CamadaDados.Servicos.TRegistro_LanServicosPecas rServico = new CamadaDados.Servicos.TRegistro_LanServicosPecas();
                        rServico.Cd_produto = (bsAgenda.Current as CamadaDados.Servicos.TRegistro_Agendamento).Cd_servico;
                        rServico.Cd_tecnico = (bsAgenda.Current as CamadaDados.Servicos.TRegistro_Agendamento).Cd_tecnico;
                        rServico.Quantidade = 1;
                        if (!string.IsNullOrEmpty(rCfg.Cd_tabelapreco))
                            rServico.Vl_unitario = CamadaNegocio.Estoque.Cadastros.TCN_LanPrecoItem.Busca_ConsultaPreco((bsAgenda.Current as CamadaDados.Servicos.TRegistro_Agendamento).Cd_empresa,
                                                                                                                        (bsAgenda.Current as CamadaDados.Servicos.TRegistro_Agendamento).Cd_servico,
                                                                                                                        rCfg.Cd_tabelapreco,
                                                                                                                        null);
                        if (rServico.Vl_unitario.Equals(decimal.Zero))
                            using (Componentes.TFQuantidade fQtd = new Componentes.TFQuantidade())
                            {
                                fQtd.Casas_decimais = 2;
                                fQtd.Ds_label = "Valor Serviço";
                                if (fQtd.ShowDialog() == DialogResult.OK)
                                    if (fQtd.Quantidade > decimal.Zero)
                                    {
                                        rServico.Vl_unitario = fQtd.Quantidade;
                                        rServico.Vl_subtotal = fQtd.Quantidade;
                                        rServico.Cd_local = rCfg.Cd_local;
                                    }
                            }
                        else
                            rServico.Vl_subtotal = rServico.Vl_unitario;
                        CamadaDados.Estoque.Cadastros.TList_FichaTecProduto lFicha =
                        CamadaNegocio.Estoque.Cadastros.TCN_FichaTecProduto.Buscar((bsAgenda.Current as CamadaDados.Servicos.TRegistro_Agendamento).Cd_servico, string.Empty, null);
                        if (lFicha.Count > 0)
                            lFicha.ForEach(p =>
                                rServico.lFichaTecOS.Add(new CamadaDados.Servicos.TRegistro_FichaTecOS()
                                {
                                    Cd_item = p.Cd_item,
                                    Ds_item = p.Ds_item,
                                    Quantidade = p.Quantidade,
                                    Vl_UnitCusto = CamadaNegocio.Estoque.TCN_LanEstoque.BuscarVlEstoqueUltimaCompra((bsAgenda.Current as CamadaDados.Servicos.TRegistro_Agendamento).Cd_empresa,
                                                                                                                    p.Cd_item,
                                                                                                                    null)
                                }));
                        else
                        {
                            CamadaDados.Servicos.TList_LanServicosPecas lServico =
                            new CamadaDados.Servicos.TCD_LanServicosPecas().Select(
                                new TpBusca[]
                                {
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.cd_empresa",
                                        vOperador = "=",
                                        vVL_Busca = "'" + (bsAgenda.Current as CamadaDados.Servicos.TRegistro_Agendamento).Cd_empresa.Trim() + "'"
                                    },
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.cd_produto",
                                        vOperador = "=",
                                        vVL_Busca = "'" + (bsAgenda.Current as CamadaDados.Servicos.TRegistro_Agendamento).Cd_servico.Trim() + "'"
                                    }
                                }, 1, string.Empty, "os.dt_abertura desc");
                            if(lServico.Count > 0)
                            {
                                //Buscar Ficha Tecnica
                                CamadaDados.Servicos.TList_FichaTecOS lFTec =
                                    CamadaNegocio.Servicos.TCN_FichaTecOS.Buscar(lServico[0].Cd_empresa,
                                                                                 lServico[0].Id_osstr,
                                                                                 lServico[0].Id_pecastr,
                                                                                 string.Empty,
                                                                                 null);
                                if(lFTec.Count > 0)
                                    using (TFListaFichaTec fLista = new TFListaFichaTec())
                                    {
                                        fLista.lFicha = lFTec;
                                        if (fLista.ShowDialog() == DialogResult.OK)
                                            fLista.lFicha.ForEach(p =>
                                                rServico.lFichaTecOS.Add(new CamadaDados.Servicos.TRegistro_FichaTecOS()
                                                {
                                                    Cd_item = p.Cd_item,
                                                    Ds_item = p.Ds_item,
                                                    Quantidade = p.Quantidade,
                                                    Vl_UnitCusto = CamadaNegocio.Estoque.TCN_LanEstoque.BuscarVlEstoqueUltimaCompra((bsAgenda.Current as CamadaDados.Servicos.TRegistro_Agendamento).Cd_empresa,
                                                                                                                                    p.Cd_item,
                                                                                                                                    null)
                                                }));
                                    }
                            }
                        }
                        rOs.lServico.Add(rServico);
                        CamadaNegocio.Servicos.TCN_Agendamento.ExecutarServico(bsAgenda.Current as CamadaDados.Servicos.TRegistro_Agendamento, rOs, null);
                        MessageBox.Show("Serviço executado com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                BuscarAgendamento();
                BuscarOS();
            }
        }

        private void DesmarcarAgendamento()
        {
            if (bsAgenda.Current != null)
            {
                InputBox ibp = new InputBox();
                ibp.Text = "Motivo Desmarcar Agendamento";
                string motivo = ibp.ShowDialog();
                if (string.IsNullOrEmpty(motivo))
                {
                    MessageBox.Show("Obrigatorio informar motivo desmarcar agendamento.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                (bsAgenda.Current as CamadaDados.Servicos.TRegistro_Agendamento).Motivodesmarcar = motivo;
                (bsAgenda.Current as CamadaDados.Servicos.TRegistro_Agendamento).St_registro = "D";
                try
                {
                    CamadaNegocio.Servicos.TCN_Agendamento.Gravar(bsAgenda.Current as CamadaDados.Servicos.TRegistro_Agendamento, null);
                    MessageBox.Show("Agendamento desmarcado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                BuscarAgendamento();
            }
            else MessageBox.Show("Obrigatório selecionar agendamento para desmarcar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void NaoCompareceu()
        {
            if (bsAgenda.Current != null)
            {
                if (MessageBox.Show("Marcar agendamento como não compareceu?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    == DialogResult.Yes)
                    try
                    {
                        (bsAgenda.Current as CamadaDados.Servicos.TRegistro_Agendamento).St_registro = "N";
                        CamadaNegocio.Servicos.TCN_Agendamento.Gravar(bsAgenda.Current as CamadaDados.Servicos.TRegistro_Agendamento, null);
                        MessageBox.Show("Agendamento alterado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                BuscarAgendamento();
            }
            else MessageBox.Show("Obrigatório selecinar agendamento.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ExcluirAgendamento()
        {
            if (bsAgenda.Current != null)
            {
                if ((bsAgenda.Current as CamadaDados.Servicos.TRegistro_Agendamento).St_registro.Trim().ToUpper() != "A")
                {
                    MessageBox.Show("Permitido CANCELAR somente agendamento ATIVO.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (MessageBox.Show("Confirma exclusão do agendamento?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    == DialogResult.Yes)
                    try
                    {
                        (bsAgenda.Current as CamadaDados.Servicos.TRegistro_Agendamento).St_registro = "C";
                        CamadaNegocio.Servicos.TCN_Agendamento.Gravar(bsAgenda.Current as CamadaDados.Servicos.TRegistro_Agendamento, null);
                        MessageBox.Show("Agendamento excluido com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                BuscarAgendamento();
            }
            else MessageBox.Show("Obrigatório selecinar agendamento.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BuscarAgendamento()
        {
            string tec = string.Empty;
            if (tecnico.SelectedIndex > 0)
                if (hs.ContainsKey(tecnico.Text.Trim()))
                    tec = hs[tecnico.Text.Trim()].ToString();
            bsAgenda.DataSource = CamadaNegocio.Servicos.TCN_Agendamento.Buscar(cbEmpresa.SelectedItem == null ? string.Empty : (cbEmpresa.SelectedItem as CamadaDados.Diversos.TRegistro_CadEmpresa).Cd_empresa,
                                                                                string.Empty,
                                                                                string.Empty,
                                                                                tec,
                                                                                string.Empty,
                                                                                calendario.SelectionRange.Start.ToString("dd/MM/yyyy"),
                                                                                calendario.SelectionRange.Start.ToString("dd/MM/yyyy"),
                                                                                "'A'",
                                                                                "a.dt_agendamento",
                                                                                null);
        }

        private void BuscarOS()
        {
            bsO.DataSource = new CamadaDados.Servicos.TCD_LanServico().Select(
                                new TpBusca[]
                                {
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.cd_empresa",
                                        vOperador = "=",
                                        vVL_Busca = "'" + (cbEmpresa.SelectedItem == null ? "a.cd_empresa" : (cbEmpresa.SelectedItem as CamadaDados.Diversos.TRegistro_CadEmpresa).Cd_empresa) + "'"
                                    },
                                    new TpBusca()
                                    {
                                        vNM_Campo = "isnull(a.st_os, 'AB')",
                                        vOperador = "in",
                                        vVL_Busca = "('AB', 'FE')"
                                    },
                                    new TpBusca()
                                    {
                                        vNM_Campo = string.Empty,
                                        vOperador = "exists",
                                        vVL_Busca = "(select 1 from tb_ose_agendamento x " +
                                                    "where x.cd_empresa = a.cd_empresa and x.id_os = a.id_os)"
                                    }
                                }, 0, string.Empty, "a.id_os");
            bsO_PositionChanged(this, new EventArgs());
        }

        private void BuscarPreVenda()
        {
            bsPreVend.DataSource = CamadaNegocio.Faturamento.PDV.TCN_PreVenda.Buscar(cbEmpresa.SelectedItem == null ? string.Empty : (cbEmpresa.SelectedItem as CamadaDados.Diversos.TRegistro_CadEmpresa).Cd_empresa,
                                                                                     string.Empty,
                                                                                     string.Empty,
                                                                                     string.Empty,
                                                                                     string.Empty,
                                                                                     string.Empty,
                                                                                     string.Empty,
                                                                                     "'A'",
                                                                                     true,
                                                                                     string.Empty,
                                                                                     null);
        }

        private void ProcessarOS()
        {
            if (bsO.Current != null)
            {
                try
                {
                    CamadaDados.Faturamento.PDV.TRegistro_PreVenda rPreVenda =
                        Proc_Commoditties.TProcessarOS.ProcessarOSServico(bsO.Current as CamadaDados.Servicos.TRegistro_LanServico);
                    CamadaNegocio.Servicos.TCN_LanServico.ProcessarOSPreVenda(bsO.Current as CamadaDados.Servicos.TRegistro_LanServico, rPreVenda, null, null);
                    BuscarOS();
                    if (MessageBox.Show("Serviço finalizado com sucesso.\r\n" +
                                       "Deseja faturar venda?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        FaturarPreVenda(rPreVenda);
                    BuscarPreVenda();
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
            else MessageBox.Show("Obrigatório selecionar OS para processar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void FaturarPreVenda(CamadaDados.Faturamento.PDV.TRegistro_PreVenda rVenda)
        {
            //Buscar dados PDV
            CamadaDados.Faturamento.Cadastros.TList_PontoVenda lPdv =
                CamadaNegocio.Faturamento.Cadastros.TCN_PontoVenda.Buscar(string.Empty,
                                                                          string.Empty,
                                                                          Utils.Parametros.pubTerminal,
                                                                          string.Empty,
                                                                          null);
            if(lPdv.Count.Equals(0))
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
                    CamadaNegocio.Faturamento.Cadastros.TCN_CFGCupomFiscal.Buscar(rVenda.Cd_empresa, null);
                if (lCfg.Count.Equals(0))
                {
                    MessageBox.Show("Não existe configuração para realizar venda na empresa " + rVenda.Cd_empresa.Trim() + ".",
                        "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                CamadaDados.Faturamento.PDV.TRegistro_VendaRapida rCupom = new CamadaDados.Faturamento.PDV.TRegistro_VendaRapida();
                rCupom.Cd_tabelapreco = rVenda.Cd_tabelaPreco;
                rCupom.Cd_vend = rVenda.Cd_vendedor;
                rCupom.Cd_empresa = rVenda.Cd_empresa;
                rCupom.Cd_clifor = rVenda.Cd_clifor;
                rCupom.Nm_clifor = rVenda.Nm_clifor;
                rCupom.Id_pessoa = rVenda.Id_pessoa;
                rCupom.Cd_cliforInd = rVenda.Cd_cliforInd;
                rCupom.Cd_endereco = rVenda.Cd_endereco;
                rCupom.Ds_observacao = rVenda.Ds_observacao;
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
                rVenda.lItens = CamadaNegocio.Faturamento.PDV.TCN_ItensPreVenda.Buscar(rVenda.Cd_empresa,
                                                                                       rVenda.Id_prevendastr,
                                                                                       string.Empty,
                                                                                       string.Empty,
                                                                                       true,
                                                                                       null);
                rVenda.lItens.ForEach(p =>
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
                                Cd_vendedor = rVenda.Cd_vendedor,
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
                        {
                            MessageBox.Show("Obrigatorio informar portador para finalizar venda.");
                            return;
                        }
                    else
                    {
                        MessageBox.Show("Obrigatorio informar portador para finalizar venda.");
                        return;
                    }
                }
                ThreadEspera tEsperaDev = new ThreadEspera("Inicio processo gravar venda rapida...");
                try
                {
                    FecharVenda(rCupom, lCfg[0], tEsperaDev);
                    BuscarPreVenda();
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                finally
                {
                    tEsperaDev.Fechar();
                    tEsperaDev = null;
                }
            }
            else
                MessageBox.Show("Não existe caixa aberto para faturar venda.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void FecharVenda(CamadaDados.Faturamento.PDV.TRegistro_VendaRapida rVenda, 
                                 CamadaDados.Faturamento.Cadastros.TRegistro_CFGCupomFiscal rCfg,
                                 ThreadEspera tEspera)
        {
            CamadaNegocio.Faturamento.PDV.TCN_VendaRapida.GravarVendaRapida(rVenda,
                                                                            null,
                                                                            null,
                                                                            null);
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
                                                                             0,
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

            //Verificar se PDV imprime Venda automática
            if (new CamadaDados.Faturamento.Cadastros.TCD_PontoVenda().BuscarEscalar(
                            new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = "a.cd_terminal",
                                    vOperador = "=",
                                    vVL_Busca = "'" + Utils.Parametros.pubTerminal.Trim() + "'"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = "isnull(a.st_impvendaauto, 'N')",
                                    vOperador = "=",
                                    vVL_Busca = "'S'"
                                }
                            }, "1") == null)
            {
                if (MessageBox.Show("Deseja imprimir orçamento venda?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    == DialogResult.Yes)
                    try
                    {
                        if (lCupom.Count > 0)
                        {
                            if (lTerminal[0].Tp_imporcamento.Trim().ToUpper().Equals("T"))
                            {
                                CamadaNegocio.Faturamento.PDV.TCN_VendaRapida.ImprimirVendaRapida(lCupom[0]);
                                return;
                            }
                            else if (lTerminal[0].Tp_imporcamento.Trim().ToUpper().Equals("R"))
                            {
                                if (string.IsNullOrEmpty(lTerminal[0].Porta_imptick))
                                    throw new Exception("Não existe porta de impressão configurada para o terminal " + Utils.Parametros.pubTerminal.Trim());
                                CamadaNegocio.Faturamento.PDV.TCN_VendaRapida.ImprimirReduzido(lCupom[0], rCfg.Cd_clifor, rCfg.St_impcpfcnpjbool, lTerminal[0].Porta_imptick);
                            }
                            else if (lTerminal[0].Tp_imporcamento.Trim().ToUpper().Equals("F"))
                                ImprimirGraficoReduzido(lCupom[0]);
                            else
                                ImprimirGrafico(lCupom[0]);
                        }
                    }
                    catch (Exception ex)
                    { MessageBox.Show("Erro imprimir venda: " + ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
            else
            {
                try
                {
                    if (lCupom.Count > 0)
                    {
                        if (lTerminal[0].Tp_imporcamento.Trim().ToUpper().Equals("T"))
                        {
                            CamadaNegocio.Faturamento.PDV.TCN_VendaRapida.ImprimirVendaRapida(lCupom[0]);
                            return;
                        }
                        else if (lTerminal[0].Tp_imporcamento.Trim().ToUpper().Equals("R"))
                        {
                            if (string.IsNullOrEmpty(lTerminal[0].Porta_imptick))
                                throw new Exception("Não existe porta de impressão configurada para o terminal " + Utils.Parametros.pubTerminal.Trim());
                            CamadaNegocio.Faturamento.PDV.TCN_VendaRapida.ImprimirReduzido(lCupom[0], rCfg.Cd_clifor, rCfg.St_impcpfcnpjbool, lTerminal[0].Porta_imptick);
                        }
                        else if (lTerminal[0].Tp_imporcamento.Trim().ToUpper().Equals("F"))
                            ImprimirGraficoReduzido(lCupom[0]);
                        else
                            ImprimirGrafico(lCupom[0]);
                    }
                }
                catch (Exception ex)
                { MessageBox.Show("Erro imprimir venda: " + ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }

            CamadaDados.Financeiro.Adiantamento.TList_LanAdiantamento lCredito =
                new CamadaDados.Financeiro.Adiantamento.TCD_LanAdiantamento().Select(
                new TpBusca[]
                {
                    new TpBusca()
                    {
                        vNM_Campo = string.Empty,
                        vOperador = "exists",
                        vVL_Busca = "(select 1 from tb_pdv_cupom_x_movcaixa x " +
                                    "where x.id_adto = a.id_adto " +
                                    "and x.cd_empresa = '" + lCupom[0].Cd_empresa.Trim() + "' " +
                                    "and x.id_cupom = " + lCupom[0].Id_vendarapidastr + ")"
                    }
                }, 0, string.Empty);
            //Imprimir comprovante de credito
            if (lTerminal[0].Tp_imporcamento.Trim().ToUpper().Equals("R"))
            {

                if (lCredito.Count > 0)
                {
                    System.IO.FileInfo f = null;
                    System.IO.StreamWriter w = null;
                    f = new System.IO.FileInfo(System.IO.Path.GetTempPath() + System.IO.Path.DirectorySeparatorChar + "Credito.txt");
                    w = f.CreateText();
                    try
                    {
                        w.WriteLine(" =========================================");
                        w.WriteLine("            COMPROVANTE CREDITO           ");
                        w.WriteLine(" =========================================");
                        w.WriteLine("NR. Venda Origem: ".FormatStringDireita(32, ' ') + lCupom[0].Id_vendarapidastr.FormatStringEsquerda(10, '0'));
                        lCredito.ForEach(p =>
                        {
                            w.WriteLine("NR. Credito: ".FormatStringDireita(32, ' ') + p.Id_adto.ToString().FormatStringEsquerda(10, '0'));
                            w.WriteLine("Data: ".FormatStringDireita(32, ' ') + p.Dt_lanctostring);
                            w.WriteLine("Valor: ".FormatStringEsquerda(32, ' ') + p.Vl_total_devolver.ToString("N2", new System.Globalization.CultureInfo("pt-BR")));
                            //Imprimir observacao cupom
                            if (!string.IsNullOrEmpty(p.Ds_adto))
                            {
                                string obs = p.Ds_adto.Trim();
                                w.WriteLine("Observacoes".FormatStringDireita(42, '-'));
                                while (true)
                                {
                                    if (obs.Length <= 40)
                                    {
                                        w.WriteLine("  " + obs);
                                        break;
                                    }
                                    else
                                    {
                                        w.WriteLine("  " + obs.Substring(0, 40));
                                        obs = obs.Remove(0, 40);
                                    }
                                }
                            }
                            w.WriteLine();
                        });
                        w.Write(Convert.ToChar(12));
                        w.Write(Convert.ToChar(27));
                        w.Write(Convert.ToChar(109));
                        w.Flush();
                        f.CopyTo(lTerminal[0].Porta_imptick);
                    }
                    catch (Exception ex)
                    { MessageBox.Show("Erro impressão comprovante credito: " + ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    finally
                    {
                        w.Dispose();
                        f = null;
                    }
                }
            }
            else if (lTerminal[0].Tp_imporcamento.Trim().ToUpper().Equals("F"))
            {
                if (lCredito.Count > 0)
                {
                    FormRelPadrao.Relatorio Relatorio = new FormRelPadrao.Relatorio();
                    Relatorio.Nome_Relatorio = "TFLanVendaRapida_ComprovanteCred";
                    Relatorio.NM_Classe = "TFLanVendaRapida_ComprovanteCred";
                    Relatorio.Modulo = "FAT";
                    Relatorio.Ident = "TFLanVendaRapida_ComprovanteCred";
                    Relatorio.Altera_Relatorio = Altera_Relatorio;

                    BindingSource BinEmpresa = new BindingSource();
                    BinEmpresa.DataSource = CamadaNegocio.Diversos.TCN_CadEmpresa.Busca(lCupom[0].Cd_empresa,
                                                                                        string.Empty,
                                                                                        string.Empty,
                                                                                        null);
                    Relatorio.Adiciona_DataSource("EMPRESA", BinEmpresa);

                    BindingSource BinCredito = new BindingSource();
                    BinCredito.DataSource = lCredito;
                    Relatorio.Adiciona_DataSource("CREDITO", BinCredito);

                    BindingSource meu_bind = new BindingSource();
                    meu_bind.DataSource = lCupom[0];
                    Relatorio.DTS_Relatorio = meu_bind;


                    if (!Altera_Relatorio)
                    {
                        //Chamar tela de gerenciamento de impressao
                        using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                        {
                            fImp.St_enabled_enviaremail = true;
                            fImp.pCd_clifor = string.Empty;
                            fImp.pMensagem = "Comprovante de Crédito";
                            if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                                Relatorio.Gera_Relatorio(string.Empty,
                                                        fImp.pSt_imprimir,
                                                        fImp.pSt_visualizar,
                                                        fImp.pSt_enviaremail,
                                                        fImp.pSt_exportPdf,
                                                        fImp.Path_exportPdf,
                                                        fImp.pDestinatarios,
                                                        null,
                                                        "Comprovante de Crédito",
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

        private void ImprimirGrafico(CamadaDados.Faturamento.PDV.TRegistro_VendaRapida val)
        {
            FormRelPadrao.Relatorio Relatorio = new FormRelPadrao.Relatorio();
            Relatorio.Nome_Relatorio = "TFLanVendaRapida";
            Relatorio.NM_Classe = "TFLanVendaRapida";
            Relatorio.Modulo = "FAT";
            Relatorio.Ident = "Orcamento_VendaRapida";
            Relatorio.Altera_Relatorio = Altera_Relatorio;

            BindingSource BinEmpresa = new BindingSource();
            BinEmpresa.DataSource = CamadaNegocio.Diversos.TCN_CadEmpresa.Busca(val.Cd_empresa,
                                                                                string.Empty,
                                                                                string.Empty,
                                                                                null);
            Relatorio.Adiciona_DataSource("EMPRESA", BinEmpresa);

            if (!string.IsNullOrEmpty(val.Cd_clifor))
            {
                BindingSource BinClifor = new BindingSource();
                BinClifor.DataSource = CamadaNegocio.Financeiro.Cadastros.TCN_CadClifor.Busca_Clifor(val.Cd_clifor,
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
                Relatorio.Adiciona_DataSource("CLIENTE", BinClifor);

                BindingSource BinEndereco = new BindingSource();
                BinEndereco.DataSource = CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Buscar(val.Cd_clifor,
                                                                                                   val.Cd_endereco,
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
                Relatorio.Adiciona_DataSource("ENDCLIENTE", BinEndereco);
            }
            //Financeiro Venda
            BindingSource BinPortador = new BindingSource();
            BinPortador.DataSource = new CamadaDados.Faturamento.PDV.TCD_CaixaPDV().SelectMovCaixa(
                                        new TpBusca[]
                                                        {
                                                            new TpBusca()
                                                            {
                                                                vNM_Campo = "a.cd_empresa",
                                                                vOperador = "=",
                                                                vVL_Busca = "'" + val.Cd_empresa.Trim() + "'"
                                                            },
                                                            new TpBusca()
                                                            {
                                                                vNM_Campo = "a.id_cupom",
                                                                vOperador = "=",
                                                                vVL_Busca = val.Id_vendarapidastr
                                                            }
                                                        }, string.Empty);
            Relatorio.Adiciona_DataSource("FINPORTADOR", BinPortador);
            //Duplicata Venda
            BindingSource BinDup = new BindingSource();
            BinDup.DataSource = new CamadaDados.Financeiro.Duplicata.TCD_LanParcela().Select(
                                    new TpBusca[]
                                                    {
                                                        new TpBusca()
                                                        {
                                                            vNM_Campo = "isnull(dup.st_registro, 'A')",
                                                            vOperador = "<>",
                                                            vVL_Busca = "'C'"
                                                        },
                                                        new TpBusca()
                                                        {
                                                            vNM_Campo = string.Empty,
                                                            vOperador = "exists",
                                                            vVL_Busca = "(select 1 from tb_pdv_cupomfiscal_x_duplicata x " +
                                                                        "where x.cd_empresa = a.cd_empresa "+
                                                                        "and x.nr_lancto = a.nr_lancto " +
                                                                        "and x.cd_empresa = '" + val.Cd_empresa.Trim() + "' " +
                                                                        "and x.id_cupom = " + val.Id_vendarapidastr + ")"
                                                        }
                                                    }, 0, string.Empty, string.Empty, string.Empty);
            Relatorio.Adiciona_DataSource("FINDUP", BinDup);

            //Fatura Cartao Venda
            BindingSource BinFat = new BindingSource();
            BinFat.DataSource = new CamadaDados.Financeiro.Cartao.TCD_FaturaCartao().Select(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = string.Empty,
                                            vOperador = "exists",
                                            vVL_Busca = "(select 1 from TB_FIN_FaturaCartao_X_Caixa x " +
                                                        "inner join TB_PDV_Cupom_X_MovCaixa y " +
                                                        "on y.cd_contager = x.cd_contager " +
                                                        "and y.cd_lanctocaixa = x.cd_lanctocaixa " +
                                                        "where x.id_fatura = a.id_fatura " +
                                                        "and y.cd_empresa = '" + val.Cd_empresa.Trim() + "' " + 
                                                        "and y.id_cupom = " + val.Id_vendarapidastr + ")"
                                        }
                                    }, 0, string.Empty, string.Empty);
            Relatorio.Adiciona_DataSource("FATCARTAO", BinFat);

            BindingSource meu_bind = new BindingSource();
            meu_bind.DataSource = val;
            Relatorio.DTS_Relatorio = meu_bind;

            //Verificar se Venda possui OS faturada
            StringBuilder obsOS = new StringBuilder();
            CamadaDados.Servicos.TList_LanServico lOS =
                new CamadaDados.Servicos.TCD_LanServico().Select(
                new TpBusca[]
                {
                    new TpBusca()
                    {
                        vNM_Campo = string.Empty,
                        vOperador = "exists",
                        vVL_Busca = "(select 1 from TB_OSE_Pecas_X_PreVenda x " +
                                    "inner join TB_PDV_PreVenda_X_VendaRapida y " +
                                    "on x.CD_Empresa = y.CD_Empresa " +
                                    "and x.ID_PreVenda = y.ID_PreVenda " +
                                    "and x.ID_ItemPreVenda = y.ID_ItemPreVenda " +
                                    "where x.ID_OS = a.ID_OS " +
                                    "and y.Id_Cupom = '" + val.Id_vendarapidastr.Trim() + "')"
                    }
                }, 0, string.Empty, string.Empty);
            if (lOS.Count > 0)
            {
                obsOS.AppendLine("Pré-Venda Referente a OS:" + lOS[0].Id_osstr.Trim() + "   Placa: " + lOS[0].Placaveiculo.Trim() + "  Modelo: " + lOS[0].Ds_veiculo.Trim());
                val.ObsOS = obsOS.ToString();
            }


            if (!Altera_Relatorio)
            {
                //Chamar tela de gerenciamento de impressao
                using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                {
                    fImp.St_enabled_enviaremail = true;
                    fImp.pCd_clifor = val.Cd_clifor;
                    fImp.pMensagem = "ORÇAMENTO Nº " + val.Id_vendarapidastr;
                    if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                        Relatorio.Gera_Relatorio(val.Id_vendarapidastr,
                                                fImp.pSt_imprimir,
                                                fImp.pSt_visualizar,
                                                fImp.pSt_enviaremail,
                                                fImp.pSt_exportPdf,
                                                fImp.Path_exportPdf,
                                                fImp.pDestinatarios,
                                                null,
                                                "ORÇAMENTO Nº " + val.Id_vendarapidastr,
                                                fImp.pDs_mensagem);
                }
            }
            else
            {
                Relatorio.Gera_Relatorio();
                Altera_Relatorio = false;
            }
        }

        private void ImprimirGraficoReduzido(CamadaDados.Faturamento.PDV.TRegistro_VendaRapida val)
        {
            FormRelPadrao.Relatorio Relatorio = new FormRelPadrao.Relatorio();
            Relatorio.Nome_Relatorio = "TFLanVendaRapida";
            Relatorio.NM_Classe = "TFLanVendaRapida";
            Relatorio.Modulo = "FAT";
            Relatorio.Ident = "Orcamento_VendaGraficaReduzido";
            Relatorio.Altera_Relatorio = Altera_Relatorio;

            BindingSource BinEmpresa = new BindingSource();
            BinEmpresa.DataSource = CamadaNegocio.Diversos.TCN_CadEmpresa.Busca(val.Cd_empresa,
                                                                                string.Empty,
                                                                                string.Empty,
                                                                                null);
            Relatorio.Adiciona_DataSource("EMPRESA", BinEmpresa);

            if (!string.IsNullOrEmpty(val.Cd_clifor))
            {
                BindingSource BinClifor = new BindingSource();
                BinClifor.DataSource = CamadaNegocio.Financeiro.Cadastros.TCN_CadClifor.Busca_Clifor(val.Cd_clifor,
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
                Relatorio.Adiciona_DataSource("CLIENTE", BinClifor);

                BindingSource BinEndereco = new BindingSource();
                BinEndereco.DataSource = CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Buscar(val.Cd_clifor,
                                                                                                   val.Cd_endereco,
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
                Relatorio.Adiciona_DataSource("ENDCLIENTE", BinEndereco);
            }
            //Financeiro Venda
            BindingSource BinPortador = new BindingSource();
            BinPortador.DataSource = new CamadaDados.Faturamento.PDV.TCD_CaixaPDV().SelectMovCaixa(
                                        new TpBusca[]
                                                        {
                                                            new TpBusca()
                                                            {
                                                                vNM_Campo = "a.cd_empresa",
                                                                vOperador = "=",
                                                                vVL_Busca = "'" + val.Cd_empresa.Trim() + "'"
                                                            },
                                                            new TpBusca()
                                                            {
                                                                vNM_Campo = "a.id_cupom",
                                                                vOperador = "=",
                                                                vVL_Busca = val.Id_vendarapidastr
                                                            }
                                                        }, string.Empty);
            Relatorio.Adiciona_DataSource("FINPORTADOR", BinPortador);
            //Duplicata Venda
            BindingSource BinDup = new BindingSource();
            BinDup.DataSource = new CamadaDados.Financeiro.Duplicata.TCD_LanParcela().Select(
                                    new TpBusca[]
                                                    {
                                                        new TpBusca()
                                                        {
                                                            vNM_Campo = "isnull(dup.st_registro, 'A')",
                                                            vOperador = "<>",
                                                            vVL_Busca = "'C'"
                                                        },
                                                        new TpBusca()
                                                        {
                                                            vNM_Campo = string.Empty,
                                                            vOperador = "exists",
                                                            vVL_Busca = "(select 1 from tb_pdv_cupomfiscal_x_duplicata x " +
                                                                        "where x.cd_empresa = a.cd_empresa "+
                                                                        "and x.nr_lancto = a.nr_lancto " +
                                                                        "and x.cd_empresa = '" + val.Cd_empresa.Trim() + "' " +
                                                                        "and x.id_cupom = " + val.Id_vendarapidastr + ")"
                                                        }
                                                    }, 0, string.Empty, string.Empty, string.Empty);
            Relatorio.Adiciona_DataSource("FINDUP", BinDup);

            //Fatura Cartao Venda
            BindingSource BinFat = new BindingSource();
            BinFat.DataSource = new CamadaDados.Financeiro.Cartao.TCD_FaturaCartao().Select(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = string.Empty,
                                            vOperador = "exists",
                                            vVL_Busca = "(select 1 from TB_FIN_FaturaCartao_X_Caixa x " +
                                                        "inner join TB_PDV_Cupom_X_MovCaixa y " +
                                                        "on y.cd_contager = x.cd_contager " +
                                                        "and y.cd_lanctocaixa = x.cd_lanctocaixa " +
                                                        "where x.id_fatura = a.id_fatura " +
                                                        "and y.cd_empresa = '" + val.Cd_empresa.Trim() + "' " + 
                                                        "and y.id_cupom = " + val.Id_vendarapidastr + ")"
                                        }
                                    }, 0, string.Empty, string.Empty);
            Relatorio.Adiciona_DataSource("FATCARTAO", BinFat);

            BindingSource meu_bind = new BindingSource();
            meu_bind.DataSource = val;
            Relatorio.DTS_Relatorio = meu_bind;

            //Verificar se Venda possui OS faturada
            StringBuilder obsOS = new StringBuilder();
            CamadaDados.Servicos.TList_LanServico lOS =
                new CamadaDados.Servicos.TCD_LanServico().Select(
                new TpBusca[]
                {
                    new TpBusca()
                    {
                        vNM_Campo = string.Empty,
                        vOperador = "exists",
                        vVL_Busca = "(select 1 from TB_OSE_Pecas_X_PreVenda x " +
                                    "inner join TB_PDV_PreVenda_X_VendaRapida y " +
                                    "on x.CD_Empresa = y.CD_Empresa " +
                                    "and x.ID_PreVenda = y.ID_PreVenda " +
                                    "and x.ID_ItemPreVenda = y.ID_ItemPreVenda " +
                                    "where x.ID_OS = a.ID_OS " +
                                    "and y.Id_Cupom = '" + val.Id_vendarapidastr.Trim() + "')"
                    }
                }, 0, string.Empty, string.Empty);
            if (lOS.Count > 0)
            {
                obsOS.AppendLine("Pré-Venda Referente a OS:" + lOS[0].Id_osstr.Trim() + "   Placa: " + lOS[0].Placaveiculo.Trim() + "  Modelo: " + lOS[0].Ds_veiculo.Trim());
                val.ObsOS = obsOS.ToString();
            }


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
            string print = string.Empty;
            print = obj == null ? string.Empty : obj.ToString();
            if (string.IsNullOrEmpty(print))
                using (Parametros.Diversos.TFListaImpressoras fLista = new Parametros.Diversos.TFListaImpressoras())
                {
                    if (fLista.ShowDialog() == DialogResult.OK)
                        if (!string.IsNullOrEmpty(fLista.Impressora))
                            print = fLista.Impressora;

                }
            //Imprimir
            if (!string.IsNullOrEmpty(print))
                Relatorio.ImprimiGraficoReduzida(print,
                                                 true,
                                                 false,
                                                 null,
                                                 string.Empty,
                                                 string.Empty,
                                                 1);
            Altera_Relatorio = false;
        }

        private void TFPainelServSalao_Load(object sender, EventArgs e)
        {
            Icon = ResourcesUtils.TecnoAliance_ICO;
            pCliente.set_FormatZero();
            tlpServico.ColumnStyles[1].Width = 0;
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
            cbEmpresa.Refresh();
            tecnico.Items.Add("<TODOS>");
            new CamadaDados.Financeiro.Cadastros.TCD_CadClifor().Select(new TpBusca[]
                                                                            {
                                                                                new TpBusca()
                                                                                {
                                                                                    vNM_Campo = "isnull(a.st_tecnico, 'N')",
                                                                                    vOperador = "=",
                                                                                    vVL_Busca = "'S'"
                                                                                },
                                                                                new TpBusca()
                                                                                {
                                                                                    vNM_Campo = "isnull(a.st_registro, 'A')",
                                                                                    vOperador = "<>",
                                                                                    vVL_Busca = "'C'"
                                                                                }
                                                                            }, 0, string.Empty).ForEach(p=>
                                                                                {
                                                                                    hs.Add(p.Nm_clifor, p.Cd_clifor);
                                                                                    tecnico.Items.Add(p.Nm_clifor.Trim());
                                                                                });
            tecnico.SelectedIndex = 0;
            BuscarAgendamento();
            BuscarOS();
            BuscarPreVenda();
        }

        private void agendarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NovoAgendamento();
        }

        private void calendario_DateChanged(object sender, DateRangeEventArgs e)
        {
            BuscarAgendamento();
            BuscarOS();
            BuscarPreVenda();
        }

        private void alterarAgendamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AlterarAgendamento();
        }

        private void desmarcarAgendamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DesmarcarAgendamento();
        }

        private void nãoCompareceuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NaoCompareceu();
        }

        private void excluirAgendamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExcluirAgendamento();
        }

        private void executarServiçoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExecutarServico();    
        }

        private void bsO_PositionChanged(object sender, EventArgs e)
        {
            if (bsO.Current != null)
            {
                (bsO.Current as CamadaDados.Servicos.TRegistro_LanServico).lServico =
                    new CamadaDados.Servicos.TCD_LanServicosPecas().Select(
                        new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = "a.id_os",
                                vOperador = "=",
                                vVL_Busca = (bsO.Current as CamadaDados.Servicos.TRegistro_LanServico).Id_osstr
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "a.cd_empresa",
                                vOperador = "=",
                                vVL_Busca = "'" + (bsO.Current as CamadaDados.Servicos.TRegistro_LanServico).Cd_empresa.Trim() + "'"
                            }
                        }, 0, string.Empty, string.Empty);
                bsO.ResetCurrentItem();
                bsServico_PositionChanged(this, new EventArgs());
            }
        }

        private void bb_inserirServicos_Click(object sender, EventArgs e)
        {
            if (bsO.Current != null)
            {
                using (TFServicosSalao fPecas = new TFServicosSalao())
                {
                    fPecas.CD_Empresa = (bsO.Current as CamadaDados.Servicos.TRegistro_LanServico).Cd_empresa;
                    fPecas.Nm_empresa = (bsO.Current as CamadaDados.Servicos.TRegistro_LanServico).Nm_empresa;
                    fPecas.CD_TabelaPreco = (bsO.Current as CamadaDados.Servicos.TRegistro_LanServico).Cd_tabelapreco;
                    fPecas.Cd_clifor = (bsO.Current as CamadaDados.Servicos.TRegistro_LanServico).Cd_clifor;
                    if (fPecas.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            //Buscar Ficha Tecnica
                            CamadaNegocio.Estoque.Cadastros.TCN_FichaTecProduto.Buscar(fPecas.rPeca.Cd_produto, string.Empty, null).ForEach(p =>
                            fPecas.rPeca.lFichaTecOS.Add(new CamadaDados.Servicos.TRegistro_FichaTecOS()
                            {
                                Cd_item = p.Cd_item,
                                Ds_item = p.Ds_item,
                                Quantidade = p.Quantidade,
                                Vl_UnitCusto = CamadaNegocio.Estoque.TCN_LanEstoque.BuscarVlEstoqueUltimaCompra((bsO.Current as CamadaDados.Servicos.TRegistro_LanServico).Cd_empresa,
                                                                                                                p.Cd_item,
                                                                                                                null)
                            }));
                            //Inserir novo registro
                            fPecas.rPeca.Cd_empresa = (bsO.Current as CamadaDados.Servicos.TRegistro_LanServico).Cd_empresa;
                            fPecas.rPeca.Id_os = (bsO.Current as CamadaDados.Servicos.TRegistro_LanServico).Id_os;
                            CamadaNegocio.Servicos.TCN_LanServicoPecas.Gravar(fPecas.rPeca, null);
                            MessageBox.Show("Serviço inserido com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            BuscarOS();
                            bsO.ResetCurrentItem();
                            bsServico.ResetCurrentItem();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);}
                    }
                }
            }
            else
                MessageBox.Show("Não existe ordem de serviço selecionada.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void bb_alterarServicos_Click(object sender, EventArgs e)
        {
            if (bsO.Current != null)
            {
                if (bsServico.Current == null)
                {
                    MessageBox.Show("Obrigatorio selecionar Serviço para alterar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                using (TFServicosSalao fPeca = new TFServicosSalao())
                {
                    fPeca.CD_Empresa = (bsO.Current as CamadaDados.Servicos.TRegistro_LanServico).Cd_empresa;
                    fPeca.Nm_empresa = (bsO.Current as CamadaDados.Servicos.TRegistro_LanServico).Nm_empresa;
                    fPeca.CD_TabelaPreco = (bsO.Current as CamadaDados.Servicos.TRegistro_LanServico).Cd_tabelapreco;
                    fPeca.Cd_clifor = (bsO.Current as CamadaDados.Servicos.TRegistro_LanServico).Cd_clifor;
                    fPeca.rPeca = (bsServico.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas);
                    if (fPeca.ShowDialog() == DialogResult.OK)
                        try
                        {
                            //Alterar registro
                            CamadaNegocio.Servicos.TCN_LanServicoPecas.Gravar(fPeca.rPeca, null);
                            MessageBox.Show("Serviço alterado com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                    BuscarOS();
                    bsO.ResetCurrentItem();
                    bsServico.ResetCurrentItem();
                }
            }
            else
                MessageBox.Show("Não existe peça(serviço) selecionado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void bb_excluirServicos_Click(object sender, EventArgs e)
        {
            if (bsO.Current != null)
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
                        //Excluir serviço
                        CamadaNegocio.Servicos.TCN_LanServicoPecas.Excluir(
                            bsServico.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas, null);
                        MessageBox.Show("Serviço excluído com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        bsO.ResetCurrentItem();
                        BuscarOS();
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            }
            else
                MessageBox.Show("Não existe ordem Peça/Serviço selecionado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void bb_fechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bsServico_PositionChanged(object sender, EventArgs e)
        {
            if (bsServico.Current != null)
            {
                (bsServico.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas).lFichaTecOS =
                    CamadaNegocio.Servicos.TCN_FichaTecOS.Buscar((bsServico.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas).Cd_empresa,
                                                                 (bsServico.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas).Id_osstr,
                                                                 (bsServico.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas).Id_pecastr,
                                                                 string.Empty,
                                                                 null);
                if (new CamadaDados.Estoque.Cadastros.TCD_CadProduto().ProdutoComposto((bsServico.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas).Cd_produto))
                {
                    tlpServico.ColumnStyles[1].SizeType = SizeType.Percent;
                    tlpServico.ColumnStyles[1].Width = 40;
                }
                else
                    tlpServico.ColumnStyles[1].Width = 0;
                bsServico.ResetCurrentItem();
            }
        }

        private void bbNovoAgendamento_Click(object sender, EventArgs e)
        {
            NovoAgendamento();
        }

        private void alterarAgendamentoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AlterarAgendamento();
        }

        private void executarServiçoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ExecutarServico();
        }

        private void desmarcarAgendamentoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DesmarcarAgendamento();
        }

        private void nãoCompareceuToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            NaoCompareceu();
        }

        private void excluirAgendamentoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ExcluirAgendamento();
        }

        private void bbExcluiItemFicha_Click(object sender, EventArgs e)
        {
            if(bsFichaTec.Current != null)
                if(MessageBox.Show("Confirma exclusão item ficha tecnica?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                     MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    try
                    {
                        CamadaNegocio.Servicos.TCN_FichaTecOS.Excluir(bsFichaTec.Current as CamadaDados.Servicos.TRegistro_FichaTecOS, null);
                        MessageBox.Show("Item Ficha Tecnica excluido com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        bsFichaTec.RemoveCurrent();
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void bbAltItemFicha_Click(object sender, EventArgs e)
        {
            if(bsFichaTec.Current != null)
                using (TFItemFichaTec fItem = new TFItemFichaTec())
                {
                    fItem.rFicha = bsFichaTec.Current as CamadaDados.Servicos.TRegistro_FichaTecOS;
                    fItem.pCd_empresa = (cbEmpresa.SelectedItem as CamadaDados.Diversos.TRegistro_CadEmpresa).Cd_empresa;
                    if (rCfg != null)
                    {
                        fItem.pCd_local = rCfg.Cd_local;
                        fItem.pDs_local = rCfg.Ds_local;
                    }
                    if(fItem.ShowDialog() == DialogResult.OK)
                        try
                        {
                            CamadaNegocio.Servicos.TCN_FichaTecOS.Gravar(fItem.rFicha, null);
                            MessageBox.Show("Item Ficha Tecnica alterado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    bsServico_PositionChanged(this, new EventArgs());
                }
        }

        private void bbAddItemFicha_Click(object sender, EventArgs e)
        {
            if(bsServico.Current != null)
                using (TFItemFichaTec fItem = new TFItemFichaTec())
                {
                    fItem.pCd_empresa = (cbEmpresa.SelectedItem as CamadaDados.Diversos.TRegistro_CadEmpresa).Cd_empresa;
                    if (rCfg != null)
                    {
                        fItem.pCd_local = rCfg.Cd_local;
                        fItem.pDs_local = rCfg.Ds_local;
                    }
                    if(fItem.ShowDialog() == DialogResult.OK)
                        if(fItem.rFicha != null)
                            try
                            {
                                fItem.rFicha.Cd_empresa = (bsServico.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas).Cd_empresa;
                                fItem.rFicha.Id_os = (bsServico.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas).Id_os;
                                fItem.rFicha.Id_peca = (bsServico.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas).Id_peca;
                                CamadaNegocio.Servicos.TCN_FichaTecOS.Gravar(fItem.rFicha, null);
                                MessageBox.Show("Item gravado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                bsServico_PositionChanged(this, new EventArgs());
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
        }

        private void bbFaturarServico_Click(object sender, EventArgs e)
        {
            if (bsPreVend.Current != null)
                FaturarPreVenda(bsPreVend.Current as CamadaDados.Faturamento.PDV.TRegistro_PreVenda);
            else MessageBox.Show("Obrigatório selecionar venda para faturar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void bbFinalizarServico_Click(object sender, EventArgs e)
        {
            ProcessarOS();
        }

        private void cbEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbEmpresa.SelectedItem != null)
            {
                CamadaDados.Servicos.Cadastros.TList_CfgAgendamento lCfg =
                    CamadaNegocio.Servicos.Cadastros.TCN_CfgAgendamento.Buscar((cbEmpresa.SelectedItem as CamadaDados.Diversos.TRegistro_CadEmpresa).Cd_empresa, null);
                if (lCfg.Count > 0)
                    rCfg = lCfg[0];
            }
            BuscarAgendamento();
            BuscarOS();
            BuscarPreVenda();
        }

        private void consultaDetalhadaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            using (TFConDetAgendamento fDet = new TFConDetAgendamento())
            {
                fDet.pCd_empresa = cbEmpresa.SelectedItem == null ? string.Empty : (cbEmpresa.SelectedItem as CamadaDados.Diversos.TRegistro_CadEmpresa).Cd_empresa;
                fDet.ShowDialog();
            }
        }

        private void bb_abrirCaixa_Click(object sender, EventArgs e)
        {
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
                MessageBox.Show("Já existe caixa aberto para o login <" + Utils.Parametros.pubLogin.Trim().ToUpper() + ">.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            using (Proc_Commoditties.TFAbrirCaixaPDV fAbrir = new Proc_Commoditties.TFAbrirCaixaPDV())
            {
                if (fAbrir.ShowDialog() == DialogResult.OK)
                    if (fAbrir.rCaixa != null)
                    {
                        try
                        {
                            CamadaNegocio.Faturamento.PDV.TCN_CaixaPDV.AbrirCaixa(fAbrir.rCaixa, null);
                            MessageBox.Show("Caixa aberto com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    }
            }
        }

        private void bb_fecharCaixa_Click(object sender, EventArgs e)
        {
            //Verificar se existe caixa aberto para o pdv/login
            CamadaDados.Faturamento.PDV.TList_CaixaPDV lCaixa = 
                new CamadaDados.Faturamento.PDV.TCD_CaixaPDV().Select(
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
                            vNM_Campo = "isnull(a.st_registro, 'A')",
                            vOperador = "=",
                            vVL_Busca = "'A'"
                        }
                    }, 1, string.Empty);
            if (lCaixa.Count > 0)
            {
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
                using (PDV.TFFechaCaixaOperacional fFechar = new PDV.TFFechaCaixaOperacional())
                {
                    fFechar.Id_caixa = lCaixa[0].Id_caixastr;
                    if (fFechar.ShowDialog() == DialogResult.OK)
                        if (fFechar.lPortador != null)
                        {
                            lCaixa[0].lPorFecharCaixa = fFechar.lPortador;
                            lCaixa[0].Dt_fechamento = CamadaDados.UtilData.Data_Servidor();
                            lCaixa[0].St_registro = "F";
                            if (lCaixa[0].Vl_transportar.Equals(decimal.Zero))
                            {
                                if (lPdv[0].St_fixarvlretidobool)
                                    lCaixa[0].Vl_transportar = lPdv[0].Vl_maxretcaixa;
                                else
                                    using (Componentes.TFQuantidade fQtde = new Componentes.TFQuantidade())
                                    {
                                        fQtde.Ds_label = "Vl. Retido Caixa";
                                        fQtde.Vl_saldo = lPdv[0].Vl_maxretcaixa;
                                        fQtde.Casas_decimais = 2;
                                        if (fQtde.ShowDialog() == DialogResult.OK)
                                            lCaixa[0].Vl_transportar = fQtde.Quantidade;
                                    }
                            }
                            try
                            {
                                CamadaNegocio.Faturamento.PDV.TCN_CaixaPDV.FecharCaixa(lCaixa[0], null);
                                //Imprimir Extrato Fechamento Caixa
                                FormRelPadrao.Relatorio extrato = new FormRelPadrao.Relatorio();
                                extrato.Altera_Relatorio = Altera_Relatorio;
                                extrato.Nome_Relatorio = "EXTRATO_FECHAMENTO_CAIXA_OPERACIONAL";
                                extrato.NM_Classe = "TFLanFrenteCaixa";
                                extrato.Modulo = "PDV";
                                extrato.Ident = "EXTRATO_FECHAMENTO_CAIXA_OPERACIONAL";
                                BindingSource bs_caixa = new BindingSource();
                                bs_caixa.DataSource = lCaixa;
                                extrato.Adiciona_DataSource("CAIXA", bs_caixa);
                                BindingSource bs = new BindingSource();
                                bs.DataSource = CamadaNegocio.Faturamento.PDV.TCN_FechamentoCaixa.Buscar(lCaixa[0].Id_caixastr,
                                                                                                         string.Empty,
                                                                                                         "'A'",
                                                                                                         null);
                                extrato.DTS_Relatorio = bs;
                                //Buscar retiradas a processar
                                object obj =
                                new CamadaDados.Faturamento.PDV.TCD_RetiradaCaixa().BuscarEscalar(
                                    new TpBusca[]
                                            {
                                                new TpBusca()
                                                {
                                                    vNM_Campo = "a.id_caixa",
                                                    vOperador = "=",
                                                    vVL_Busca = lCaixa[0].Id_caixastr
                                                },
                                                new TpBusca()
                                                {
                                                    vNM_Campo = "isnull(a.st_registro, 'A')",
                                                    vOperador = "=",
                                                    vVL_Busca = "'A'"
                                                }
                                            }, "isnull(sum(a.Vl_Retirada), 0)");
                                if (obj != null)
                                    extrato.Parametros_Relatorio.Add("VL_RET_PROCESSAR", decimal.Parse(obj.ToString()));
                                using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                                {
                                    fImp.St_enabled_enviaremail = true;
                                    fImp.pCd_clifor = string.Empty;
                                    fImp.pMensagem = "EXTRATO FECHAMENTO CAIXA OPERACIONAL";

                                    if (Altera_Relatorio)
                                    {
                                        extrato.Gera_Relatorio(string.Empty,
                                                               fImp.pSt_imprimir,
                                                               fImp.pSt_visualizar,
                                                               fImp.pSt_enviaremail,
                                                               fImp.pSt_exportPdf,
                                                               fImp.Path_exportPdf,
                                                               fImp.pDestinatarios,
                                                               null,
                                                               "EXTRATO FECHAMENTO CAIXA OPERACIONAL",
                                                               fImp.pDs_mensagem);
                                        Altera_Relatorio = false;
                                    }
                                    else
                                        if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                                            extrato.Gera_Relatorio(string.Empty,
                                                                   fImp.pSt_imprimir,
                                                                   fImp.pSt_visualizar,
                                                                   fImp.pSt_enviaremail,
                                                                   fImp.pSt_exportPdf,
                                                                   fImp.Path_exportPdf,
                                                                   fImp.pDestinatarios,
                                                                   null,
                                                                   "EXTRATO FECHAMENTO CAIXA OPERACIONAL",
                                                                   fImp.pDs_mensagem);
                                }
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                        }
                }
            }
            else
                MessageBox.Show("Não existe caixa aberto para o Usuario " + Utils.Parametros.pubLogin.Trim(), "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void bb_estornarServico_Click(object sender, EventArgs e)
        {
            if(bsO.Current != null)
                if(MessageBox.Show("Confirma estorno da execução do serviço?", "Pergunta", MessageBoxButtons.YesNo,
                     MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    try
                    {
                        CamadaNegocio.Servicos.TCN_LanServico.cancelar(bsO.Current as CamadaDados.Servicos.TRegistro_LanServico, null);
                        BuscarAgendamento();
                        BuscarOS();
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void bbEstornarFat_Click(object sender, EventArgs e)
        {
            if(bsPreVend.Current != null)
                if (MessageBox.Show("Confirma estorno do faturamento corrente?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    == DialogResult.Yes)
                {
                    try
                    {
                        //Buscar OS da Venda corrente
                        CamadaDados.Servicos.TList_LanServico lOs = new CamadaDados.Servicos.TCD_LanServico().Select(
                                                                        new TpBusca[]
                                                                    {
                                                                        new TpBusca()
                                                                        {
                                                                            vNM_Campo = string.Empty,
                                                                            vOperador = "exists",
                                                                            vVL_Busca = "(select 1 from tb_ose_pecas_x_prevenda x " +
                                                                                        "where x.cd_empresa = a.cd_empresa " +
                                                                                        "and x.id_os = a.id_os " +
                                                                                        "and x.cd_empresa = '" + (bsPreVend.Current as CamadaDados.Faturamento.PDV.TRegistro_PreVenda).Cd_empresa.Trim() + "' " +
                                                                                        "and x.id_prevenda = " + (bsPreVend.Current as CamadaDados.Faturamento.PDV.TRegistro_PreVenda).Id_prevendastr + ")"
                                                                        }
                                                                    }, 1, string.Empty, string.Empty);
                        if (lOs.Count > 0)
                        {
                            CamadaNegocio.Servicos.TCN_LanServico.EstornarOSPreVenda(lOs[0], null);
                            MessageBox.Show("Faturamento estornado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            BuscarOS();
                            BuscarPreVenda();
                            return;
                        }
                        else
                        {
                            MessageBox.Show("Não foi encontrado OS para a venda corrente.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            using (TFVendasEstornar fVenda = new TFVendasEstornar())
            {
                if(fVenda.ShowDialog() == DialogResult.OK)
                    if(fVenda.rVenda != null)
                        try
                        {
                            //Buscar OS da Venda corrente
                            CamadaDados.Servicos.TList_LanServico lOs = new CamadaDados.Servicos.TCD_LanServico().Select(
                                                                            new TpBusca[]
                                                                    {
                                                                        new TpBusca()
                                                                        {
                                                                            vNM_Campo = string.Empty,
                                                                            vOperador = "exists",
                                                                            vVL_Busca = "(select 1 from tb_ose_pecas_x_prevenda x " +
                                                                                        "inner join tb_pdv_prevenda_x_vendarapida y " +
                                                                                        "on x.cd_empresa = y.cd_empresa " +
                                                                                        "and x.id_prevenda = y.id_prevenda " +
                                                                                        "and x.id_itemprevenda = y.id_itemprevenda " +
                                                                                        "where x.cd_empresa = a.cd_empresa " +
                                                                                        "and x.id_os = a.id_os " +
                                                                                        "and y.cd_empresa = '" + fVenda.rVenda.Cd_empresa.Trim() + "' " +
                                                                                        "and y.id_cupom = " + fVenda.rVenda.Id_vendarapidastr + ")"
                                                                        }
                                                                    }, 1, string.Empty, string.Empty);
                            if (lOs.Count > 0)
                            {
                                CamadaNegocio.Servicos.TCN_LanServico.EstornarOSPreVenda(lOs[0], null);
                                MessageBox.Show("Faturamento estornado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                BuscarOS();
                                BuscarPreVenda();
                                return;
                            }
                            else
                            {
                                MessageBox.Show("Não foi encontrado OS para a venda corrente.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void bbVendas_Click(object sender, EventArgs e)
        {
            using (TFVendasEstornar fVendas = new TFVendasEstornar())
            {
                fVendas.St_consulta = true;
                fVendas.ShowDialog();
            }
        }

        private void tcCentral_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tcCentral.SelectedTab.Equals(tpAgTecnico))
            {
                bsTecnico.DataSource = new CamadaDados.Financeiro.Cadastros.TCD_CadClifor().Select(
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
                                                vNM_Campo = "isnull(a.st_tecnico, 'N')",
                                                vOperador = "=",
                                                vVL_Busca = "'S'"
                                            }
                                        }, 0, string.Empty);
                bsTecnico_PositionChanged(this, new EventArgs());
            }
        }

        private void bsTecnico_PositionChanged(object sender, EventArgs e)
        {
            if (bsTecnico.Current != null)
                bsAgTecnico.DataSource = CamadaNegocio.Servicos.TCN_Agendamento.Buscar(cbEmpresa.SelectedItem == null ? string.Empty : (cbEmpresa.SelectedItem as CamadaDados.Diversos.TRegistro_CadEmpresa).Cd_empresa,
                                                                                       string.Empty,
                                                                                       string.Empty,
                                                                                       (bsTecnico.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadClifor).Cd_clifor,
                                                                                       string.Empty,
                                                                                       string.Empty,
                                                                                       string.Empty,
                                                                                       "'A'",
                                                                                       "a.dt_agendamento",
                                                                                       null);
            else bsAgTecnico.Clear();
        }

        private void tecnico_SelectedIndexChanged(object sender, EventArgs e)
        {
            BuscarAgendamento();
        }

        private void bb_clifor_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_clifor, nm_clifor }, string.Empty);
            if (!string.IsNullOrEmpty(cd_clifor.Text))
            {
                bsServicoCliente.DataSource = new CamadaDados.Servicos.TCD_LanServicosPecas().Select(
                                                new TpBusca[]
                                                {
                                                    new TpBusca()
                                                    {
                                                        vNM_Campo = "a.cd_empresa",
                                                        vOperador = "=",
                                                        vVL_Busca = "'" + (cbEmpresa.SelectedItem == null ? string.Empty : (cbEmpresa.SelectedItem as CamadaDados.Diversos.TRegistro_CadEmpresa).Cd_empresa) + "'"
                                                    },
                                                    new TpBusca()
                                                    {
                                                        vNM_Campo = "os.cd_clifor",
                                                        vOperador = "=",
                                                        vVL_Busca = "'" + cd_clifor.Text.Trim() + "'"
                                                    }
                                                }, 0, string.Empty, string.Empty);
                bsServicoCliente_PositionChanged(this, new EventArgs());
            }
            else
            {
                bsServicoCliente.Clear();
                bsServicoCliente.ResetCurrentItem();
            }
        }

        private void cd_clifor_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + cd_clifor.Text.Trim() + "'",
                new Componentes.EditDefault[] { cd_clifor, nm_clifor }, new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
            if (!string.IsNullOrEmpty(cd_clifor.Text))
            {
                bsServicoCliente.DataSource = new CamadaDados.Servicos.TCD_LanServicosPecas().Select(
                                                new TpBusca[]
                                                {
                                                    new TpBusca()
                                                    {
                                                        vNM_Campo = "a.cd_empresa",
                                                        vOperador = "=",
                                                        vVL_Busca = "'" + (cbEmpresa.SelectedItem == null ? string.Empty : (cbEmpresa.SelectedItem as CamadaDados.Diversos.TRegistro_CadEmpresa).Cd_empresa) + "'"
                                                    },
                                                    new TpBusca()
                                                    {
                                                        vNM_Campo = "os.cd_clifor",
                                                        vOperador = "=",
                                                        vVL_Busca = "'" + cd_clifor.Text.Trim() + "'"
                                                    }
                                                }, 0, string.Empty, string.Empty);
                bsServicoCliente_PositionChanged(this, new EventArgs());
            }
            else
            {
                bsServicoCliente.Clear();
                bsServicoCliente.ResetCurrentItem();
            }
        }

        private void bsServicoCliente_PositionChanged(object sender, EventArgs e)
        {
            if (bsServicoCliente.Current != null)
            {
                (bsServicoCliente.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas).lFichaTecOS =
                    CamadaNegocio.Servicos.TCN_FichaTecOS.Buscar((bsServicoCliente.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas).Cd_empresa,
                                                                 (bsServicoCliente.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas).Id_osstr,
                                                                 (bsServicoCliente.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas).Id_pecastr,
                                                                 string.Empty,
                                                                 null);
                bsServicoCliente.ResetCurrentItem();
            }
        }

        private void bb_vendarapida_Click(object sender, EventArgs e)
        {
            using (Faturamento.TFLanVendaRapida fVenda = new Faturamento.TFLanVendaRapida())
            {
                fVenda.ShowDialog();
            }
        }
    }
}
