using System;
using System.Drawing;
using System.Linq;
using CamadaDados.Faturamento.Pedido;
using System.Windows.Forms;
using FormBusca;
using Utils;
using CamadaNegocio.Diversos;
using CamadaDados.Financeiro.Cadastros;

namespace Faturamento
{
    public partial class TFLan_Orcamento : Form
    {
        private bool Altera_Relatorio = false;

        public TFLan_Orcamento()
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
            cbAR.Checked = false;
            cbCancelado.Checked = false;
            cbFaturado.Checked = false;
        }

        private void afterNovo()
        {
            using (TFOrcamento fOrcamento = new TFOrcamento())
            {
                fOrcamento.Text = "NOVO ORÇAMENTO";
                if (fOrcamento.ShowDialog() == DialogResult.OK)
                    if (fOrcamento.rOrcamento != null)
                    {
                        try
                        {
                            CamadaNegocio.Faturamento.Orcamento.TCN_Orcamento.Gravar(fOrcamento.rOrcamento, null);
                            MessageBox.Show("Orçamento gravado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                if ((bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).St_registro.Trim().ToUpper().Equals("FT"))
                {
                    MessageBox.Show("Não é permitido excluir orçamento FATURADO.\r\n" +
                                    "Necessario antes estornar o faturamento <PEDIDO/VENDA RAPIDA/ORDEM SERVIÇO> do orçamento.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (MessageBox.Show("Confirma cancelamento do orçamento?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                     MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    try
                    {
                        CamadaNegocio.Faturamento.Orcamento.TCN_Orcamento.CancelarOrcamento(bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento, null);
                        MessageBox.Show("Orçamento cancelado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LimparFitros();
                        cbAberto.Checked = true;
                        afterBusca();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
                MessageBox.Show("Obrigatorio selecionar orçamento para excluir.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void afterAltera()
        {
            if (bsOrcamento.Current != null)
            {
                if ((bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).St_registro.Trim().ToUpper().Equals("CA"))
                {
                    MessageBox.Show("Não é permitido alterar orçamento CANCELADO.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                using (TFOrcamento fOrc = new TFOrcamento())
                {
                    (bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).lItens.ForEach(p => p.lFichaTec = CamadaNegocio.Faturamento.Orcamento.TCN_FichaTecOrcItem.Buscar(p.Nr_orcamento.Value.ToString(), p.Id_item.Value.ToString(), string.Empty, null));
                    fOrc.rOrcamento = (bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento);
                    fOrc.St_editar = !(bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).St_registro.Trim().ToUpper().Equals("FT");
                    if (fOrc.ShowDialog() == DialogResult.OK)
                    {
                        if (fOrc.rOrcamento != null)
                        {
                            try
                            {
                                CamadaNegocio.Faturamento.Orcamento.TCN_Orcamento.Gravar(fOrc.rOrcamento, null);
                                MessageBox.Show("Orçamento alterado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
                MessageBox.Show("Necessario selecionar orçamento para alterar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (cbAR.Checked)
            {
                cond += virg + "'AR'";
                virg = ",";
            }
            if (cbCancelado.Checked)
            {
                cond += virg + "'CA'";
                virg = ",";
            }
            if (cbFaturado.Checked)
            {
                cond += "'FT'";
                virg = ",";
            }
            bsOrcamento.DataSource = CamadaNegocio.Faturamento.Orcamento.TCN_Orcamento.Buscar(nr_orcamento.Text,
                                                                                              cd_empresa.Text,
                                                                                              string.Empty,
                                                                                              cd_vendedor.Text,
                                                                                              cd_representante.Text,
                                                                                              string.Empty,
                                                                                              string.Empty,
                                                                                              nm_clifor.Text,
                                                                                              ds_endereco.Text,
                                                                                              CD_UF.Text,
                                                                                              DT_Inicial.Text,
                                                                                              DT_Final.Text,
                                                                                              decimal.Zero,
                                                                                              decimal.Zero,
                                                                                              cond,
                                                                                              string.Empty,
                                                                                              "N",
                                                                                              string.Empty,
                                                                                              false,
                                                                                              false,
                                                                                              cd_pedido.Text,cd_grupo.Text,
                                                                                              false,
                                                                                              false,
                                                                                              null);
            bsOrcamento_PositionChanged(this, new EventArgs());
            bsItens_PositionChanged(this, new EventArgs());
        }

        private void TotalizarOrcamento()
        {
            if (bsOrcamento.Current != null)
            {
                tot_subtotal.Value = (bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).lItens.Sum(p => p.Vl_subtotal);
                tot_desconto.Value = (bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).lItens.Sum(p => p.Vl_desconto);
                tot_frete.Value = (bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).lItens.Sum(p => p.Vl_frete);
                tot_juro.Value = (bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).lItens.Sum(p => p.Vl_acrescimo);
                tot_juro_fin.Value = (bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).lItens.Sum(p => p.Vl_juro_fin);
                tot_liquido.Value = (bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).lItens.Sum(p => p.Vl_subtotalliq) +
                                    (bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).Vl_impostosomar -
                                    (bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).Vl_impostosubtrair;
                tot_custo.Value = (bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).lItens.Sum(p => p.Vl_custototal);
                if (tot_liquido.Value > decimal.Zero)
                {
                    if (tot_liquido.Value >= tot_custo.Value)
                    {
                        pc_lucro.Value = 100 - (tot_custo.Value * 100 / tot_liquido.Value);
                        lblLucro.Text = "% Lucro";
                        lblLucro.ForeColor = Color.Blue;
                    }
                    else
                    {
                        pc_lucro.Value = (tot_custo.Value * 100 / tot_liquido.Value) - 100;
                        lblLucro.Text = "% Perda";
                        lblLucro.ForeColor = Color.Red;
                    }
                }
            }
        }

        private void ProcessarOrcamento()
        {
            if (bsOrcamento.Current != null)
            {
                if (!TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin, "PERMITIR PROCESSAR ORÇAMENTO", null))
                {
                    MessageBox.Show("Usuário não tem acesso para processar orçamento!",  "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if ((bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).St_registro.Trim().ToUpper().Equals("CA"))
                {
                    MessageBox.Show("Não é permitido processar orçamento CANCELADO.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if ((bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).St_registro.Trim().ToUpper().Equals("FT"))
                {
                    MessageBox.Show("Orçamento ja se encontra processado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (string.IsNullOrEmpty((bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).Cd_clifor))
                {
                    MessageBox.Show("Não é permitido processar orçamento sem cliente cadastrado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (string.IsNullOrEmpty((bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).Cd_endereco))
                {
                    MessageBox.Show("Não é permitido processar orçamento sem endereço cadastrado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if ((bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).lItens.Count < 1)
                {
                    MessageBox.Show("Não é permitido processar orçamento sem itens.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if ((bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).lItens.Exists(p => string.IsNullOrEmpty(p.Cd_produto)))
                {
                    MessageBox.Show("Não é permitido processar orçamento com produto sem cadastro.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                CamadaDados.Faturamento.Cadastros.TList_CFGOrcamento lCfg =
                    CamadaNegocio.Faturamento.Cadastros.TCN_CFGOrcamento.Buscar((bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).Cd_empresa,
                                                                                string.Empty,
                                                                                string.Empty,
                                                                                null);
                if (lCfg.Count.Equals(0))
                {
                    MessageBox.Show("Não existe configuração para processar orçamento na empresa " + (bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).Cd_empresa,
                        "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (MessageBox.Show("Confirma processamento do orçamento selecionado?", "Pergunta", MessageBoxButtons.YesNo,
                     MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    using (TFProcessarOrcamento fProcessar = new TFProcessarOrcamento())
                    {
                        fProcessar.rOrcamento = bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento;
                        if (fProcessar.ShowDialog() == DialogResult.OK)
                            if (fProcessar.rOrcamento != null)
                            {
                                //Verificar se Orcamento possui servico
                                if (fProcessar.rOrcamento.lItens.Exists(p => p.St_servicobool) && lCfg[0].St_gerarosbool)
                                {
                                    if (!lCfg[0].Tp_ordem.HasValue)
                                    {
                                        MessageBox.Show("Não existe TIPO ORDEM configurado para gerar OS dos serviços.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        return;
                                    }
                                }
                                try
                                {
                                    CamadaNegocio.Faturamento.Orcamento.TCN_Orcamento.ProcessarOrcamento(fProcessar.rOrcamento, lCfg[0], null);
                                    MessageBox.Show("Orçamento processado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    LimparFitros();
                                    nr_orcamento.Text = fProcessar.rOrcamento.Nr_orcamentostr;
                                    afterBusca();
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                    }
                }
            }
            else
                MessageBox.Show("Necessario selecionar orçamento para processar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Print()
        {
            if (bsOrcamento.Current != null)
            {              
                if (!(bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).St_registro.Trim().ToUpper().Equals("C"))
                {
                    FormRelPadrao.Relatorio Relatorio = new FormRelPadrao.Relatorio();
                    Relatorio.Altera_Relatorio = Altera_Relatorio;

                    //DADOS PERTINENTES PARA A GERAÇÂO DO RELATORIO
                    Relatorio.Nome_Relatorio = "TFLan_Pedido";
                    Relatorio.NM_Classe = "TFLan_Pedido";
                    Relatorio.Modulo = Tag.ToString().Substring(0, 3);


                    BindingSource BinEmpresa = new BindingSource();
                    BinEmpresa.DataSource = TCN_CadEmpresa.Busca(
                                                                 (bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).Cd_empresa,
                                                                 string.Empty,
                                                                 string.Empty,
                                                                 null);

                    BindingSource BinClifor = new BindingSource();
                    if (!string.IsNullOrEmpty((bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).Cd_clifor))
                        BinClifor.DataSource = CamadaNegocio.Financeiro.Cadastros.TCN_CadClifor.Busca_Clifor((bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).Cd_clifor,
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
                    if (!string.IsNullOrEmpty((bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).Cd_clifor))
                        BinEndereco.DataSource = CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Buscar(
                                                                        (bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).Cd_clifor,
                                                                        (bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).Cd_endereco,
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
                    if (!string.IsNullOrEmpty((bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).Cd_clifor))
                        BinContatos.DataSource = CamadaNegocio.Financeiro.Cadastros.TCN_CadContatoCliFor.Buscar(string.Empty,
                                                                                                               (bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).Cd_clifor,
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
                    BinContatoVend.DataSource = CamadaNegocio.Financeiro.Cadastros.TCN_CadContatoCliFor.Buscar(string.Empty,
                                                                                                               (bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).Cd_vendedor,
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
                    if (!string.IsNullOrEmpty((bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).Cd_representante))
                        BinContatoRepresentante.DataSource = CamadaNegocio.Financeiro.Cadastros.TCN_CadContatoCliFor.Buscar(string.Empty,
                                                                                                                   (bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).Cd_representante,
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
                    if (string.IsNullOrEmpty((bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).Cd_representante) ||
                        BinContatoRepresentante.Count.Equals(0))
                    {
                        BinContatoRepresentante.DataSource = new TList_CadContatoCliFor();
                        (BinContatoRepresentante.DataSource as TList_CadContatoCliFor).Add(
                            new TRegistro_CadContatoCliFor());
                    }

                    BindingSource BinParcelas = new BindingSource();
                    BinParcelas.DataSource = CamadaNegocio.Faturamento.Orcamento.TCN_Orcamento_DT_Vencto.Buscar((bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).Nr_orcamentostr,
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
                            (bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).Pc_Icms_UF = Convert.ToDecimal(objICMS);
                    }
                    else if (!string.IsNullOrEmpty((bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).Uf))
                    {
                        object objICMS =
                            new TCD_CadUf().BuscarEscalar(
                                new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = "a.UF",
                                    vOperador = "=",
                                    vVL_Busca = "'" + (bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).Uf.Trim() + "'"
                                }
                            }, "a.PC_AliquotaICMS");
                        if (objICMS != null && !string.IsNullOrEmpty(objICMS.ToString()))
                            (bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).Pc_Icms_UF = Convert.ToDecimal(objICMS);
                    }

                    //Buscar ficha tecnica
                    (bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).lItens.ForEach(p =>
                    {
                        if (p.lFichaTec.Count.Equals(0))
                            p.lFichaTec = CamadaNegocio.Faturamento.Orcamento.TCN_FichaTecOrcItem.Buscar(p.Nr_orcamento.Value.ToString(),
                                                                                                         p.Id_item.Value.ToString(),
                                                                                                         string.Empty,
                                                                                                         null);
                    });

                    object cliforEmpresa = new CamadaDados.Diversos.TCD_CadEmpresa().BuscarEscalar(
                                       new TpBusca[]
                                        {
                                            new TpBusca()
                                            {
                                                vNM_Campo = "a.cd_empresa",
                                                vOperador = "=",
                                                vVL_Busca = "'" + (bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).Cd_empresa + "'"
                                            }
                                        }, "a.cd_clifor");
                    BindingSource BinDadosFin = new BindingSource();
                    BinDadosFin.DataSource = CamadaNegocio.Financeiro.Cadastros.TCN_CadDados_Bancarios_Clifor.Busca(cliforEmpresa.ToString(),
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  null);

                    BindingSource BinContatosEmpresa = new BindingSource();
                    BinContatosEmpresa.DataSource = CamadaNegocio.Financeiro.Cadastros.TCN_CadContatoCliFor.Buscar(string.Empty,
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
                                vVL_Busca = "'" + (bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).Cd_clifor + "'"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "a.st_endentrega",
                                vOperador = "=",
                                vVL_Busca = "'S'"
                            }
                        }, 1, string.Empty);

                    //Buscar CFG.Orcamento
                    CamadaDados.Faturamento.Cadastros.TList_CFGOrcamento lCfg =
                        new CamadaDados.Faturamento.Cadastros.TCD_CFGOrcamento().Select(
                            new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = "a.cd_empresa",
                                    vOperador = "=",
                                    vVL_Busca = "'" + (bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).Cd_empresa.Trim() + "'"
                                }
                            }, 0, string.Empty);

                    //Calcular  % Impostos Itens Orçamento
                    if (lCfg.Count > 0)
                        CalcularPcImpostos(lCfg[0], BinEmpresa.Current as CamadaDados.Diversos.TRegistro_CadEmpresa);
                    BindingSource meu_bind = new BindingSource();
                    meu_bind.DataSource = new CamadaDados.Faturamento.Orcamento.TList_Orcamento() { bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento };
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

                   
                    if (lCfg.Count > 0)
                        if (lCfg[0].LayoutAereo != null &&
                            lCfg[0].LayoutJaquetado != null &&
                            lCfg[0].LayoutPerifericos != null)
                        {
                            PrintWordPDF(lCfg[0], (BinEndereco.Current as TRegistro_CadEndereco)
                                                     , (BinContatos.DataSource as TList_CadContatoCliFor)
                                                     , (BinClifor.Current as TRegistro_CadClifor)
                                                     , (BinParcelas.DataSource as CamadaDados.Faturamento.Orcamento.TList_Orcamento_DT_Vencto));
                            return;
                        }


                    object obj = new CamadaDados.Diversos.TCD_CadTerminal().BuscarEscalar(
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
                            CamadaNegocio.Faturamento.Orcamento.TCN_Orcamento.ImprimirOrcamento(bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento,
                                                                                         BinClifor.Current as TRegistro_CadClifor,
                                                                                         BinEndereco.Current as TRegistro_CadEndereco,
                                                                                         BinEmpresa.Current as CamadaDados.Diversos.TRegistro_CadEmpresa);
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    else
                    {

                        Relatorio.Ident = "FLan_Orcamento";
                        if (BinEmpresa.Current != null)
                            if ((BinEmpresa.Current as CamadaDados.Diversos.TRegistro_CadEmpresa).Img != null)
                                Relatorio.Parametros_Relatorio.Add("IMAGEM_RELATORIO", (BinEmpresa.Current as CamadaDados.Diversos.TRegistro_CadEmpresa).Img);
                        if (!Altera_Relatorio)
                        {
                            //Chamar tela de gerenciamento de impressao
                            using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                            {
                                fImp.St_enabled_enviaremail = true;
                                fImp.pCd_clifor = (bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).Cd_clifor;
                                fImp.pCd_representante = (bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).Cd_representante;
                                fImp.pMensagem = "ORÇAMENTO Nº " + (bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).Nr_orcamentostr;
                                if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                                    Relatorio.Gera_Relatorio((bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).Nr_orcamentostr,
                                                             fImp.pSt_imprimir,
                                                             fImp.pSt_visualizar,
                                                             fImp.pSt_enviaremail,
                                                             fImp.pSt_exportPdf,
                                                             fImp.Path_exportPdf,
                                                             fImp.pDestinatarios,
                                                             null,
                                                             "ORÇAMENTO Nº " + (bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).Nr_orcamentostr,
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

        private void PrintWordPDF(CamadaDados.Faturamento.Cadastros.TRegistro_CFGOrcamento rCFG
            , TRegistro_CadEndereco rEndereco
            , TList_CadContatoCliFor lContatoClifor
            , TRegistro_CadClifor rClifor
            , CamadaDados.Faturamento.Orcamento.TList_Orcamento_DT_Vencto lParcelas)
        {
            if (rCFG != null )
            {
                using (TFPrintOrcamentoWord fPrint = new TFPrintOrcamentoWord())
                {
                    fPrint.rCFG = rCFG;
                    fPrint.rEndereco = rEndereco;
                    fPrint.rClifor = rClifor;
                    fPrint.lContatoClifor = lContatoClifor;
                    fPrint.lParcelas = lParcelas;
                    fPrint.rOrcamento = bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento;
                    (bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).lItens.ForEach(p =>
                        fPrint.lItem.Add(p));
                    fPrint.ShowDialog();
                }
            }
        }

        private void CalcularPcImpostos(CamadaDados.Faturamento.Cadastros.TRegistro_CFGOrcamento rCFG,
                                        CamadaDados.Diversos.TRegistro_CadEmpresa rEmpresa)
        {
            //Buscar movimentacao comercial do tipo de pedido
            CamadaDados.Faturamento.Cadastros.TList_CadCFGPedidoFiscal lCfgPed =
                new CamadaDados.Faturamento.Cadastros.TCD_CadCFGPedidoFiscal().Select(
                            new Utils.TpBusca[]
                            {
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = "a.cfg_pedido",
                                        vOperador = "=",
                                        vVL_Busca = "'" + rCFG.Cfg_pedido.Trim() + "'"
                                    },
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = "a.tp_fiscal",
                                        vOperador = "=",
                                        vVL_Busca = "'NO'"
                                    }
                            }, 1, string.Empty);
            if (lCfgPed.Count > 0)
            {
                CamadaDados.Fiscal.TList_ProdutoSimular lProdSimular = new CamadaDados.Fiscal.TList_ProdutoSimular();
                (bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).lItens.ForEach(p =>
                {
                    lProdSimular.Add(
                        new CamadaDados.Fiscal.TRegistro_ProdutoSimular()
                        {
                            Cd_produto = p.Cd_produto,
                            Cd_condfiscal_produto = p.Cd_condfiscal_produto,
                            Ds_condfiscal_produto = p.Ds_condfiscal_produto,
                            Ds_produto = p.Ds_produto,
                            Quantidade = p.Quantidade,
                            Sg_unidade = p.Sigla_unid_produto,
                            Vl_unitario = p.Vl_unitario
                        });
                });
                //Buscar Condição Fiscal Clifor
                object Cd_condfical_clifor =
                    new CamadaDados.Financeiro.Cadastros.TCD_CadClifor().BuscarEscalar(
                        new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = "a.cd_clifor",
                                vOperador = "=",
                                vVL_Busca = "'" + (bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).Cd_clifor.Trim() + "'"
                            }
                        }, "a.CD_CondFiscal_Clifor");
                //Buscar TP.Pessoa
                object Tp_pessoa =
                    new CamadaDados.Financeiro.Cadastros.TCD_CadClifor().BuscarEscalar(
                        new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = "a.cd_clifor",
                                vOperador = "=",
                                vVL_Busca = "'" + (bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).Cd_clifor.Trim() + "'"
                            }
                        }, "a.Tp_pessoa");
                //Buscar CD.UF Endereço Clifor
                object CD_UFDest =
                    new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco().BuscarEscalar(
                        new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = "a.cd_clifor",
                                vOperador = "=",
                                vVL_Busca = "'" + (bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).Cd_clifor.Trim() + "'"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "a.cd_endereco",
                                vOperador = "=",
                                vVL_Busca = "'" + (bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).Cd_endereco.Trim() + "'"
                            }
                        }, "a.cd_uf");
                for (int i = 0; i < lProdSimular.Count; i++)
                {
                    string retobs = string.Empty;
                    (lProdSimular[i] as CamadaDados.Fiscal.TRegistro_ProdutoSimular).lImpProduto =
                        CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento_Item.procuraImpostosPorUf((bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).Cd_empresa,
                                                                                                          rEmpresa.rEndereco.Cd_uf,
                                                                                                          CD_UFDest != null ? CD_UFDest.ToString() : string.Empty,
                                                                                                          lCfgPed[0].Cd_movtostring,
                                                                                                          "S",
                                                                                                          Cd_condfical_clifor != null ? Cd_condfical_clifor.ToString() : string.Empty,
                                                                                                          (lProdSimular[i] as CamadaDados.Fiscal.TRegistro_ProdutoSimular).Cd_condfiscal_produto,
                                                                                                          (lProdSimular[i] as CamadaDados.Fiscal.TRegistro_ProdutoSimular).Vl_subtotal,
                                                                                                          (lProdSimular[i] as CamadaDados.Fiscal.TRegistro_ProdutoSimular).Quantidade,
                                                                                                          ref retobs,
                                                                                                          DateTime.Now,
                                                                                                          (lProdSimular[i] as CamadaDados.Fiscal.TRegistro_ProdutoSimular).Cd_produto,
                                                                                                          string.Empty,
                                                                                                          string.Empty,
                                                                                                          null);
                    (lProdSimular[i] as CamadaDados.Fiscal.TRegistro_ProdutoSimular).lImpProduto.Concat(CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento_Item.procuraCondicaoFiscalImpostos(Cd_condfical_clifor != null ? Cd_condfical_clifor.ToString() : string.Empty,
                                                                                                                                    (lProdSimular[i] as CamadaDados.Fiscal.TRegistro_ProdutoSimular).Cd_condfiscal_produto,
                                                                                                                                    lCfgPed[0].Cd_movtostring,
                                                                                                                                    "S",
                                                                                                                                    Tp_pessoa != null ? Tp_pessoa.ToString() : string.Empty,
                                                                                                                                    (bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).Cd_empresa,
                                                                                                                                    lCfgPed[0].Nr_serie,
                                                                                                                                    (bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).Cd_clifor,
                                                                                                                                    string.Empty,
                                                                                                                                    DateTime.Now,
                                                                                                                                    (lProdSimular[i] as CamadaDados.Fiscal.TRegistro_ProdutoSimular).Quantidade,
                                                                                                                                    (lProdSimular[i] as CamadaDados.Fiscal.TRegistro_ProdutoSimular).Vl_subtotal,
                                                                                                                                    string.Empty,
                                                                                                                                    string.Empty,
                                                                                                                                    null));
                    if ((lProdSimular[i] as CamadaDados.Fiscal.TRegistro_ProdutoSimular).lImpProduto.Exists(p => p.Imposto.St_ICMS))
                    {
                        //% ICMS
                        (bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).lItens.Find(p =>
                        p.Cd_produto.Equals((lProdSimular[i] as CamadaDados.Fiscal.TRegistro_ProdutoSimular).Cd_produto)).Pc_icms =
                        (lProdSimular[i] as CamadaDados.Fiscal.TRegistro_ProdutoSimular).lImpProduto.Find(p => p.Imposto.St_ICMS).Pc_aliquota;
                        //% ICMS ST
                        (bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).lItens.Find(p =>
                        p.Cd_produto.Equals((lProdSimular[i] as CamadaDados.Fiscal.TRegistro_ProdutoSimular).Cd_produto)).Pc_icms_ST =
                        (lProdSimular[i] as CamadaDados.Fiscal.TRegistro_ProdutoSimular).lImpProduto.Find(p => p.Imposto.St_ICMS).Pc_aliquotasubst;
                    }
                    if ((lProdSimular[i] as CamadaDados.Fiscal.TRegistro_ProdutoSimular).lImpProduto.Exists(p => p.Imposto.St_PIS))
                    {
                        //% PIS
                        (bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).lItens.Find(p =>
                        p.Cd_produto.Equals((lProdSimular[i] as CamadaDados.Fiscal.TRegistro_ProdutoSimular).Cd_produto)).Pc_pis =
                        (lProdSimular[i] as CamadaDados.Fiscal.TRegistro_ProdutoSimular).lImpProduto.Find(p => p.Imposto.St_PIS).Pc_aliquota;
                    }
                    if ((lProdSimular[i] as CamadaDados.Fiscal.TRegistro_ProdutoSimular).lImpProduto.Exists(p => p.Imposto.St_Cofins))
                    {
                        //% COFINS
                        (bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).lItens.Find(p =>
                        p.Cd_produto.Equals((lProdSimular[i] as CamadaDados.Fiscal.TRegistro_ProdutoSimular).Cd_produto)).Pc_cofins =
                        (lProdSimular[i] as CamadaDados.Fiscal.TRegistro_ProdutoSimular).lImpProduto.Find(p => p.Imposto.St_Cofins).Pc_aliquota;
                    }
                    if ((lProdSimular[i] as CamadaDados.Fiscal.TRegistro_ProdutoSimular).lImpProduto.Exists(p => p.Imposto.St_IPI))
                    {
                        //% IPI
                        (bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).lItens.Find(p =>
                        p.Cd_produto.Equals((lProdSimular[i] as CamadaDados.Fiscal.TRegistro_ProdutoSimular).Cd_produto)).Pc_ipi =
                        (lProdSimular[i] as CamadaDados.Fiscal.TRegistro_ProdutoSimular).lImpProduto.Find(p => p.Imposto.St_IPI).Pc_aliquota;
                    }
                }
            }         
        }

        private void VerificarEstoque()
        {
            if (bsItens.Current != null)
                if (new CamadaDados.Estoque.Cadastros.TCD_CadProduto().ProdutoComposto((bsItens.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item).Cd_produto) ||
                    new CamadaDados.Estoque.Cadastros.TCD_CadProduto().ProdutoIndustrializado(
                    (bsItens.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item).Cd_produto))
                    using (TFDisponibilidadeEstoque fDisp = new TFDisponibilidadeEstoque())
                    {
                        fDisp.Cd_empresa = (bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).Cd_empresa;
                        fDisp.Nm_empresa = (bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).Nm_empresa;
                        fDisp.rItemOrc = bsItens.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item;
                        fDisp.ShowDialog();
                    }
        }

        private void TFLan_Orcamento_Load(object sender, EventArgs e)
        {
            ShapeGrid.RestoreShape(this, gItens);
            ShapeGrid.RestoreShape(this, gOrcamento);
            ShapeGrid.RestoreShape(this, dataGridDefault2);
            ShapeGrid.RestoreShape(this, dataGridDefault3);
            Icon = ResourcesUtils.TecnoAliance_ICO;
            pFiltro.set_FormatZero();
            tlpFichaTec.ColumnStyles[1] = new ColumnStyle(SizeType.Percent, 0);

            bool st_vercusto = TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin, "PERMITIR VISUALIZAR CUSTO VENDA", null);
            lblCusto.Visible = st_vercusto;
            tot_custo.Visible = st_vercusto;
            lblLucro.Visible = st_vercusto;
            pc_lucro.Visible = st_vercusto;
            if (!st_vercusto)
                gItens.Columns.Remove(cVl_custototal);
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

        private void cd_empresa_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "'", new Componentes.EditDefault[] { cd_empresa });
        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { cd_empresa }, string.Empty);
        }

        private void bb_clifor_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { nm_clifor }, string.Empty);
        }

        private void bb_endereco_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("a.ds_endereco|Endereço|200;a.cd_endereco|Codigo|80",
                                    new Componentes.EditDefault[] { ds_endereco },
                                    new TCD_CadEndereco(), string.Empty);
        }

        private void bb_vendedor_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_vendedor }, "isnull(a.st_vendedor, 'N')|=|'S';isnull(a.st_funcativo, 'N')|=|'S'");
        }

        private void cd_vendedor_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + cd_vendedor.Text.Trim() + "';isnull(a.st_vendedor, 'N')|=|'S';isnull(a.st_funcativo, 'N')|=|'S'",
                new Componentes.EditDefault[] { cd_vendedor }, new TCD_CadClifor());
        }

        private void bsOrcamento_PositionChanged(object sender, EventArgs e)
        {
            if (bsOrcamento.Current != null)
            {
                BB_Alterar.Text = (bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).St_registro.Trim().ToUpper().Equals("FT") ? "(F3)\nVisualizar" : "(F3)\nAlterar";
                (bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).lItens =
                    CamadaNegocio.Faturamento.Orcamento.TCN_Orcamento_Item.Buscar(
                    (bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).Nr_orcamentostr,
                    false,
                    false,
                    null);
                (bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).lParcelas =
                    CamadaNegocio.Faturamento.Orcamento.TCN_Orcamento_DT_Vencto.Buscar(
                    (bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).Nr_orcamentostr,
                    null);
                bsOrcamento.ResetCurrentItem();
                bsItens_PositionChanged(this, new EventArgs());
                TotalizarOrcamento();
            }
        }

        private void BB_Alterar_Click(object sender, EventArgs e)
        {
            afterAltera();
        }

        private void TFLan_Orcamento_KeyDown(object sender, KeyEventArgs e)
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
                VerificarEstoque();
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
                    if (e.Value.ToString().Trim().ToUpper().Equals("CANCELADO"))
                    {
                        DataGridViewRow linha = gOrcamento.Rows[e.RowIndex];
                        linha.DefaultCellStyle.ForeColor = Color.Red;
                    }
                    else if (e.Value.ToString().Trim().ToUpper().Equals("AGUARDANDO RETORNO"))
                    {
                        DataGridViewRow linha = gOrcamento.Rows[e.RowIndex];
                        linha.DefaultCellStyle.ForeColor = Color.Teal;
                    }
                    else if (e.Value.ToString().Trim().ToUpper().Equals("PROCESSADO"))
                    {
                        DataGridViewRow linha = gOrcamento.Rows[e.RowIndex];
                        linha.DefaultCellStyle.ForeColor = Color.Blue;
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

        private void bsItens_PositionChanged(object sender, EventArgs e)
        {
            if (bsItens.Current != null)
            {
                //Buscar ficha tecnica item orcamento
                (bsItens.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item).lFichaTec =
                    CamadaNegocio.Faturamento.Orcamento.TCN_FichaTecOrcItem.Buscar((bsItens.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item).Nr_orcamento.Value.ToString(),
                                                                                   (bsItens.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item).Id_item.Value.ToString(),
                                                                                   string.Empty,
                                                                                   null);
                bsOrcamento.ResetCurrentItem();
                if ((bsItens.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item).lFichaTec.Count > 0)
                    tlpFichaTec.ColumnStyles[1] = new ColumnStyle(SizeType.Percent, 50);
                else
                    tlpFichaTec.ColumnStyles[1] = new ColumnStyle(SizeType.Percent, 0);
            }
        }

        private void relatorioSeparacaooItensDoPedidoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bsOrcamento.Current != null)
                using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                {
                    FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                    BindingSource BinEmpresa = new BindingSource();
                    BinEmpresa.DataSource = TCN_CadEmpresa.Busca((bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).Cd_empresa,
                                                                 string.Empty,
                                                                 string.Empty,
                                                                 null);
                    Rel.Altera_Relatorio = Altera_Relatorio;
                    CamadaDados.Faturamento.Orcamento.TList_Orcamento_Item lItem = new CamadaDados.Faturamento.Orcamento.TList_Orcamento_Item();
                    CamadaNegocio.Faturamento.Orcamento.TCN_Orcamento.MontarListaSeparacaoOrc((bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).Nr_orcamentostr,
                                                                                              (bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).Cd_empresa,
                                                                                              lItem,
                                                                                              0);
                    BindingSource dts = new BindingSource();
                    dts.DataSource = lItem;
                    Rel.DTS_Relatorio = dts;
                    BindingSource bs_pedido = new BindingSource();
                    CamadaDados.Faturamento.Orcamento.TList_Orcamento lPed = new CamadaDados.Faturamento.Orcamento.TList_Orcamento();
                    lPed.Add((bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento));
                    bs_pedido.DataSource = lPed;
                    Rel.Adiciona_DataSource("bs_Pedido", bs_pedido);
                    Rel.Adiciona_DataSource("BS_EMPRESA", BinEmpresa);
                    Rel.NM_Classe = "TFLan_Orcamento";
                    Rel.Ident = "REL_SeparacaoOrcamento";
                    Rel.NM_Classe = Name;
                    Rel.Modulo = Tag.ToString().Substring(0, 3);
                    fImp.St_enabled_enviaremail = true;
                    fImp.pCd_clifor = string.Empty;
                    fImp.pMensagem = "RELATORIO FICHA TECNICA ORÇAMENTO";

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
                                           "RELATORIO FICHA TECNICA ORÇAMENTO",
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
                                               "RELATORIO FICHA TECNICA ORÇAMENTO",
                                               fImp.pDs_mensagem);
                }
        }

        private void visualizarPedidoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Print();
        }

        private void bb_disponibilidadeestoque_Click(object sender, EventArgs e)
        {
            VerificarEstoque();
        }

        private void TFLan_Orcamento_FormClosing(object sender, FormClosingEventArgs e)
        {
            ShapeGrid.SaveShape(this, gItens);
            ShapeGrid.SaveShape(this, gOrcamento);
            ShapeGrid.SaveShape(this, dataGridDefault2);
            ShapeGrid.SaveShape(this, dataGridDefault3);
        }

        private void tcDetalhe_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bsOrcamento.Current != null)
            {
                if (tcDetalhe.SelectedTab.Equals(tpNF))
                {
                    //busca nota
                    (bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).lNotaFiscal =
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
                                                "and x.nr_orcamento = "+(bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).Nr_orcamento.ToString()+")"
                                }
                            }, 0, string.Empty);

                }

                if (tcDetalhe.SelectedTab.Equals(tpdup))
                {

                    // busca duplicata
                    (bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).lParc =
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
                                                "and x.nr_pedido = " + (bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).Nr_pedidovenda.ToString() + ")"
                                }
                            }, 0, string.Empty, string.Empty, string.Empty);
                }
                bsOrcamento.ResetCurrentItem();

            }
        }

        private void dgProcesso_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
                if (e.ColumnIndex == 0)

                    if (!string.IsNullOrEmpty((bs_processo[e.RowIndex] as CamadaDados.Faturamento.Pedido.TRegistro_ProcEtapa).Dt_processostr))
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
                (bs_processo.Current as CamadaDados.Faturamento.Pedido.TRegistro_ProcEtapa).lAnexo =
                    CamadaNegocio.Faturamento.Pedido.TCN_AnexoPedido.Buscar(
                                            (bs_processo.Current as CamadaDados.Faturamento.Pedido.TRegistro_ProcEtapa).Nr_pedidostr,
                                            string.Empty,
                                            (bs_processo.Current as CamadaDados.Faturamento.Pedido.TRegistro_ProcEtapa).Id_processostr,
                                            (bs_processo.Current as CamadaDados.Faturamento.Pedido.TRegistro_ProcEtapa).Id_Anexo,
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
                FormRelPadrao.Relatorio Relatorio = new FormRelPadrao.Relatorio();
                Relatorio.Altera_Relatorio = Altera_Relatorio;
                //DADOS PERTINENTES PARA A GERAÇÂO DO RELATORIO
                Relatorio.Nome_Relatorio = "REL_FAT_FICHATECNICA_ORC";
                Relatorio.NM_Classe = "REL_FAT_FICHATECNICA_ORC";
                Relatorio.Modulo = "FAT";
                Relatorio.Ident = "REL_FAT_FICHATECNICA_ORC";

                //Buscar ficha tecnica produto
                CamadaDados.Faturamento.Orcamento.TList_Orcamento_Item lItens = new CamadaDados.Faturamento.Orcamento.TList_Orcamento_Item();
                CamadaNegocio.Faturamento.Orcamento.TCN_Orcamento.MontarFichaTecItem((bsOrcamento.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento).Cd_empresa,
                                                                                     (bsItens.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item).Cd_local,
                                                                                     bsItens.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item,
                                                                                     lItens);
                BindingSource bsFicha = new BindingSource();
                bsFicha.DataSource = lItens;
                Relatorio.DTS_Relatorio = bsFicha;
                Relatorio.Parametros_Relatorio.Add("NR_PEDIDO", (bsItens.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item).Nr_orcamento);
                Relatorio.Parametros_Relatorio.Add("CD_PRODUTO", (bsItens.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item).Cd_produto);
                Relatorio.Parametros_Relatorio.Add("DS_PRODUTO", (bsItens.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item).Ds_produto);

                if (!Altera_Relatorio)
                {
                    //Chamar tela de gerenciamento de impressao
                    using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                    {
                        fImp.St_enabled_enviaremail = true;
                        fImp.pCd_clifor = string.Empty;
                        fImp.pMensagem = "FICHA TECNICA DO PRODUTO " + (bsItens.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item).Cd_produto.Trim();
                        if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                            Relatorio.Gera_Relatorio((bsItens.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item).Cd_produto.Trim(),
                                                     fImp.pSt_imprimir,
                                                     fImp.pSt_visualizar,
                                                     fImp.pSt_enviaremail,
                                                     fImp.pSt_exportPdf,
                                                     fImp.Path_exportPdf,
                                                     fImp.pDestinatarios,
                                                     null,
                                                     "FICHA TECNICA DO PRODUTO " + (bsItens.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item).Cd_produto.Trim(),
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
                   new Componentes.EditDefault[] { CD_UF }, new TCD_CadUf());
        }

        private void BB_UF_Click(object sender, EventArgs e)
        {
            string vColunas = "a.UF|Sigla|60;" +
                              "a.DS_UF|Estado|100";
            UtilPesquisa.BTN_BUSCA(vColunas,
                   new Componentes.EditDefault[] { CD_UF }, new TCD_CadUf(), string.Empty);
        }

        private void listagemDeOrçamentosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bsOrcamento.Count > 0)
            {
                using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                {
                    FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
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
               new Componentes.EditDefault[] { cd_representante }, new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void bb_representante_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_representante }, "isnull(a.st_representante, 'N')|=|'S'");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string vColunas = "a.cd_grupo|Grupo Produto|60;" +
                              "a.ds_grupo|Descrição|100";
            UtilPesquisa.BTN_BUSCA(vColunas,
                   new Componentes.EditDefault[] { cd_grupo }, new CamadaDados.Estoque.Cadastros.TCD_CadGrupoProduto(), "a.nivel|=|1");

        }

        private void cd_grupo_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.cd_grupo|=|'" + cd_grupo.Text + "'",
                   new Componentes.EditDefault[] { cd_grupo }, new CamadaDados.Estoque.Cadastros.TCD_CadGrupoProduto());

        }
    }
}