using System;
using System.Collections.Generic;
using CamadaDados.Empreendimento;
using CamadaDados.Empreendimento.Cadastro;
using CamadaNegocio.Empreendimento;
using CamadaNegocio.Empreendimento.Cadastro;
using Utils;
using System.Windows.Forms;
using System.Data;

namespace Empreendimento
{
    public partial class FOrcamentoDetalhado : Form
    {

        private TRegistro_Orcamento cOrcamento;
        public TRegistro_Orcamento rOrcamento
        {
            get
            {
                return bsOrcamento.Current as TRegistro_Orcamento;
            }
            set { cOrcamento = value; }
        }



        public string pCD_Empresa { get; set; }
        public string pID_Orcamento { get; set; }
        public string pNR_Versao {get;set;}
        public FOrcamentoDetalhado()
        {
            InitializeComponent();
        }

        private void bbBuscar_Click(object sender, EventArgs e)
        {
            afterBusca();
        }

        private void afterBusca()
        {
            //buscar orcamento/itens
            bsOrcamento.DataSource = TCN_Orcamento.Buscar(cOrcamento.Cd_endereco,
                                                             cOrcamento.Id_orcamentostr,
                                                             cOrcamento.Nr_versaostr,
                                                             string.Empty,
                                                             string.Empty,
                                                             string.Empty,
                                                             string.Empty,
                                                             string.Empty,
                                                             "'H'",
                                                             null);
            bsOrcamento_PositionChanged(this, new EventArgs());

        }
        
        private void bsOrcamento_PositionChanged(object sender, EventArgs e)
        {
            if (bsOrcamento.Current != null)
            { //Buscar Atividades
                (bsOrcamento.Current as TRegistro_Orcamento).lOrcProjeto =
                    TCN_OrcProjeto.Buscar((bsOrcamento.Current as TRegistro_Orcamento).Cd_empresa,
                                          (bsOrcamento.Current as TRegistro_Orcamento).Id_orcamentostr,
                                          (bsOrcamento.Current as TRegistro_Orcamento).Nr_versaostr,
                                          string.Empty,
                                          string.Empty,
                                          null);
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
                (bsOrcamento.Current as TRegistro_Orcamento).lOEncargo =
                    TCN_OrcamentoEncargo.Buscar(string.Empty,
                                        (bsOrcamento.Current as TRegistro_Orcamento).Cd_empresa,
                                        (bsOrcamento.Current as TRegistro_Orcamento).Nr_versaostr,
                                        (bsOrcamento.Current as TRegistro_Orcamento).Id_orcamentostr, null);
                calculaEncargos();



                bsOrcamento.ResetCurrentItem();
                bsAtividade_PositionChanged(this, new EventArgs());
            }
        }

        private void bsAtividade_PositionChanged(object sender, EventArgs e)
        {
            if (bsAtividade.Current != null)
            {
               
                    bsFichaTec.DataSource =
                        TCN_FichaTec.Buscar((bsAtividade.Current as TRegistro_OrcProjeto).Cd_empresa,
                                            (bsAtividade.Current as TRegistro_OrcProjeto).Id_orcamentostr,
                                            (bsAtividade.Current as TRegistro_OrcProjeto).Nr_versaostr,
                                            (bsAtividade.Current as TRegistro_OrcProjeto).Id_projetostr,
                                            (bsAtividade.Current as TRegistro_OrcProjeto).Id_registrostr,
                                            string.Empty,
                                            null);
                bsFichaTec.ResetCurrentItem();
            }
        }

        private void FOrcamentoDetalhado_Load(object sender, EventArgs e)
        {
            Icon = ResourcesUtils.TecnoAliance_ICO;
            if (cOrcamento != null)
            {
                bsOrcamento.DataSource = new TList_Orcamento() { cOrcamento };
                bsOrcamento.Position = 0;
                if (cOrcamento == null)
                    afterBusca();
                else
                    bsOrcamento_PositionChanged(this, new EventArgs());

                // buscar dados de cfg 
                bsCfgOrc.DataSource = TCN_CadCFGEmpreendimento.Busca(cOrcamento.Cd_empresa, string.Empty, null);
                bsCfgOrc.ResetCurrentItem();

                if(cOrcamento.St_registro.Equals("H") && (CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Parametros.pubLogin, "PERMITIR APROVAR", null)))
                {
                    bbreabrir.Visible = true;
                    bb_inutilizar.Visible = true;
                }
                else
                {
                    bbreabrir.Visible = false;
                    bb_inutilizar.Visible = false;
                    bnprojetobt.Visible = false;
                    st_empglobal.Enabled = false;
                    totimposto.Enabled = false;
                    cofins.Enabled = false;
                    irpj.Enabled = false;
                    adirpj.Enabled = false;
                    contribuicao.Enabled = false;
                    custofin.Enabled = false;
                    vlOrcContr.Enabled = false;
                    comissao.Enabled = false;
                    csll.Enabled = false;
                    cofins.Enabled = false;
                    custofin.Enabled = false;
                    custo_desp.Enabled = false;
                    custo_ficha.Enabled = false;
                    custo_maoobra.Enabled = false;
                    pis.Enabled = false;
                    issqn.Enabled = false;
                    inss.Enabled = false;
                    pc_descprog.Enabled = false;
                }

                calculaFinaltext();
            }
            else
                bsOrcamento.AddNew();

            calculaEncargos();


            if (bsOrcamento.Current != null && bsCfgOrc.Current != null)
            {
                (bsOrcamento.Current as TRegistro_Orcamento).Pc_margemcont = string.IsNullOrEmpty((bsOrcamento.Current as TRegistro_Orcamento).Pc_margemcont.ToString())? (bsCfgOrc.Current as TRegistro_CadCFGEmpreendimento).Pc_margemcont: (bsOrcamento.Current as TRegistro_Orcamento).Pc_margemcont;
                cofins.Value = cofins.Value.Equals(decimal.Zero) ? (bsCfgOrc.Current as TRegistro_CadCFGEmpreendimento).Pc_Cofins : cofins.Value;
                csll.Value = csll.Value.Equals(decimal.Zero) ? (bsCfgOrc.Current as TRegistro_CadCFGEmpreendimento).Pc_CSLL : csll.Value;
                irpj.Value = irpj.Value.Equals(decimal.Zero) ? (bsCfgOrc.Current as TRegistro_CadCFGEmpreendimento).Pc_IRPJ : irpj.Value;
                pis.Value = pis.Value.Equals(decimal.Zero) ? (bsCfgOrc.Current as TRegistro_CadCFGEmpreendimento).Pc_PIS : pis.Value;

            }
        }

        public void calculaFinal()
        {

            (bsOrcamento.Current as TRegistro_Orcamento).vl_orcamento = (bsOrcamento.Current as TRegistro_Orcamento).Custo_Despesas 
                + (bsOrcamento.Current as TRegistro_Orcamento).ficha_fp 
                + (bsOrcamento.Current as TRegistro_Orcamento).custo_folha 
                + (bsOrcamento.Current as TRegistro_Orcamento).tot_encargo;
        }
        public void calculaFinaltext()
        { 
            if(bsOrcamento.Current != null)
            if (string.IsNullOrEmpty(tot_encargo.Text))
                tot_encargo.Text = (bsOrcamento.Current as TRegistro_Orcamento).tot_encargo.ToString();
            if (bsOrcamento.Current != null)
            {
                if ((bsOrcamento.Current as TRegistro_Orcamento).lOEncargo.Count > 0 )
                {
                    decimal pc_valor = decimal.Zero;
                    (bsOrcamento.Current as TRegistro_Orcamento).lOEncargo.ForEach(p =>
                    {
                        pc_valor += p.pc_encargo;
                        p.vl_encargo = (bsOrcamento.Current as TRegistro_Orcamento).custo_folha * decimal.Divide(p.pc_encargo, 100);
                    });
                    tot_encargo.Text = (Math.Round((bsOrcamento.Current as TRegistro_Orcamento).custo_folha * (pc_valor / 100), 2, MidpointRounding.AwayFromZero)).ToString();
                }
                decimal a = contribuicao.Value + comissao.Value + custofin.Value == decimal.Zero ? 1 :
                                                        (1 + decimal.Divide((contribuicao.Value + comissao.Value + custofin.Value), 100));
                vlOrcContr.Value = Math.Round((
                                                decimal.Multiply(
                                                    vlOrcamento.Value,
                                                    contribuicao.Value + comissao.Value + custofin.Value == decimal.Zero ? 1 :
                                                        (1+ decimal.Divide(( contribuicao.Value + comissao.Value + custofin.Value), 100))
                                                    )
                                          ), 2, MidpointRounding.AwayFromZero);
                if (vlOrcContr.Value == decimal.Zero)
                    vlOrcContr.Value = vlOrcamento.Value;

            }
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            if(bsOrcamento.Current != null)
            try
            {
                    if (MessageBox.Show("Confirma Gravar Orcamento? evoluir para Em Negociação.", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                               MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        (bsOrcamento.Current as TRegistro_Orcamento).St_registro = "N";
                        (bsOrcamento.Current as TRegistro_Orcamento).vl_orcamento = (bsOrcamento.Current as TRegistro_Orcamento).total_orcdesc;

                        TList_CadCFGEmpreendimento lcfg = new TCD_CadCFGEmpreendimento().Select(null, 0, string.Empty);
                        if (lcfg.Count.Equals(0) || lcfg[0].ValidadePropostaDias == null || lcfg[0].ValidadePropostaDias < 1)
                        {
                            throw new Exception("Na configuração de empreemdimento é necessário informar " +
                                "a validade de dias para a proposta. Assim o sistema pode calcular a data de validade. " +
                                "Não será possível finalizar a operaçao, o valor deve ser maior que zero");
                        }

                        //Atribuição da data de validade do orçamento
                        if (lcfg.Count > 0 && lcfg[0].ValidadePropostaDias != null)
                        {
                            (bsOrcamento.Current as TRegistro_Orcamento).Dt_validade = CamadaDados.UtilData.Data_Servidor().AddDays(Convert.ToDouble(lcfg[0].ValidadePropostaDias));
                            bsOrcamento.ResetCurrentItem();
                        }

                        TCN_Orcamento.Evoluir(bsOrcamento.Current as TRegistro_Orcamento, null);
                        MessageBox.Show("Orçamento gravado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DialogResult = DialogResult.OK;
                    }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void FOrcamentoDetalhado_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                bb_inutilizar_Click(this, new EventArgs());
            else if (e.KeyCode.Equals(Keys.F5))
                toolStripButton1_Click(this, new EventArgs());
        }

        private void Default_Leave(object sender, EventArgs e)
        {
            calculaFinaltext();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

            if (bsOrcamento.Current != null) if (MessageBox.Show("Deseja reabrir Orçamento?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                         MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    try
                    {
                        using (TFTarefas ftarefa = new TFTarefas())
                        {
                            ftarefa.pCd_Empresa = (bsOrcamento.Current as TRegistro_Orcamento).Cd_empresa;
                            if (ftarefa.ShowDialog() == DialogResult.OK)
                            {
                                if (ftarefa.pDs_tarefa != null)
                                {
                                    TRegistro_Tarefas rtarefa = new TRegistro_Tarefas();
                                    rtarefa.Cd_empresa = ftarefa.pCd_Empresa;
                                    rtarefa.Ds_tarefa = ftarefa.pDs_tarefa;
                                    rtarefa.Id_orcamentostr = (bsOrcamento.Current as TRegistro_Orcamento).Id_orcamentostr;
                                    rtarefa.Nr_versaostr = (bsOrcamento.Current as TRegistro_Orcamento).Nr_versaostr;
                                    rtarefa.Login = Utils.Parametros.pubLogin;
                                    TCN_Tarefas.Gravar(rtarefa,null);
                                }
                            }
                        }
                        (bsOrcamento.Current as TRegistro_Orcamento).St_registro = "O";
                        TCN_Orcamento.Gravar(bsOrcamento.Current as TRegistro_Orcamento, null);
                        MessageBox.Show("Orçamento reaberto.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
        }

        private void editDefault15_Leave(object sender, EventArgs e)
        {
            calculaFinaltext();
        }

        private void editFloat1_Leave(object sender, EventArgs e)
        {
            calculaFinaltext();
        }

        private void contribuicao_KeyDown(object sender, KeyEventArgs e)
        {

        }
        private void calculaEncargos()
        {
            calculaFinaltext();
        }

        private void dataGridDefault7_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
                using (Componentes.TFQuantidade fQtd = new Componentes.TFQuantidade())
                {
                    fQtd.Text = "Percentual";
                    fQtd.Ds_label = "Percentual";
                    //fQtd.Vl_default = (bsFicha.Current as TRegistro_FichaTec).vl_faturar;
                    if (fQtd.ShowDialog() == DialogResult.OK)
                        if (fQtd.Quantidade > decimal.Zero)
                        {
                            (bsEncargos.Current as TRegistro_OrcamentoEncargo).pc_encargo =
                                Math.Round(fQtd.Quantidade, 2, MidpointRounding.AwayFromZero); 
                        }
                        else
                        {
                            MessageBox.Show("Obrigatório informar Percentual!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    else
                    {
                        (bsEncargos.Current as TRegistro_OrcamentoEncargo).pc_encargo = decimal.Zero;
                    }
                }
            calculaEncargos();
            bsEncargos.ResetCurrentItem();
        }

        private void bbAddProjeto_Click(object sender, EventArgs e)
        {
            using (Cadastro.FFolha folha = new Cadastro.FFolha())
            {
                if (bsEncargos.Count > 0)
                {
                    List<TRegistro_CadEncargosFolha> lencargo = new List<TRegistro_CadEncargosFolha>();
                    (bsEncargos.List as List<TRegistro_OrcamentoEncargo>).ForEach(p =>
                    {
                        TRegistro_CadEncargosFolha ea = new TRegistro_CadEncargosFolha();
                        ea.Id_encargostr = p.Id_encargostr;
                        ea.st_agregar = true;
                        ea.Ds_encargo = p.ds_encargo;
                        lencargo.Add(ea);
                    });
                    folha.rLfolha = lencargo;
                }
                if (folha.ShowDialog() == DialogResult.OK)
                {
                   // bsEncargos.Clear();
                    folha.rLfolha.ForEach(p =>
                    {
                        if (p.st_agregar)
                        {
                            TRegistro_OrcamentoEncargo oe = new TRegistro_OrcamentoEncargo();
                            oe.Cd_empresastr = (bsOrcamento.Current as TRegistro_Orcamento).Cd_empresa;
                            oe.Id_orcamento = (bsOrcamento.Current as TRegistro_Orcamento).Id_orcamento;
                            oe.Nr_versao = (bsOrcamento.Current as TRegistro_Orcamento).Nr_versao;
                            oe.Id_encargo = p.Id_encargo;
                            oe.ds_encargo = p.Ds_encargo;
                            oe.pc_encargo = p.Pc_encargo;
                            bsEncargos.Add(oe);
                        }
                        else
                        {
                            TRegistro_OrcamentoEncargo oe = new TRegistro_OrcamentoEncargo();
                            oe.Cd_empresastr = (bsOrcamento.Current as TRegistro_Orcamento).Cd_empresa;
                            oe.Id_orcamento = (bsOrcamento.Current as TRegistro_Orcamento).Id_orcamento;
                            oe.Nr_versao = (bsOrcamento.Current as TRegistro_Orcamento).Nr_versao;
                            oe.Id_encargo = p.Id_encargo;
                            oe.ds_encargo = p.Ds_encargo;
                            oe.pc_encargo = p.Pc_encargo;
                            (bsOrcamento.Current as TRegistro_Orcamento).lOEncargoDel.Add(oe);
                        }
                    });
                    calculaEncargos();
                }
            }
        }

        private void bbExcluirProjeto_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirma exclusão do encargo selecionado?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                bsEncargos.Remove(bsEncargos.Current);
                (bsOrcamento.Current as TRegistro_Orcamento).lOEncargoDel.Add(bsEncargos.Current as CamadaDados.Empreendimento.Cadastro.TRegistro_OrcamentoEncargo);
            }
        }

        private void tot_encargo_Leave(object sender, EventArgs e)
        {
            Default_Leave(this, new EventArgs());
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
                using (TFTarefas ftarefa = new TFTarefas())
                {
                    ftarefa.pCd_Empresa = (bsOrcamento.Current as TRegistro_Orcamento).Cd_empresa;
                    if (ftarefa.ShowDialog() == DialogResult.OK)
                    {
                        if (ftarefa.pDs_tarefa != null)
                        {
                            TRegistro_Tarefas rtarefa = new TRegistro_Tarefas();
                            rtarefa.Cd_empresa = ftarefa.pCd_Empresa;
                            rtarefa.Ds_tarefa = ftarefa.pDs_tarefa;
                            rtarefa.Id_orcamentostr = (bsOrcamento.Current as TRegistro_Orcamento).Id_orcamentostr;
                            rtarefa.Nr_versaostr = (bsOrcamento.Current as TRegistro_Orcamento).Nr_versaostr;
                            rtarefa.Login = Utils.Parametros.pubLogin;
                            bsTarefa.Add(rtarefa);
                            bsTarefa.ResetCurrentItem();
                        }
                        MessageBox.Show("Tarefa adicionada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }
        }

        private void bb_vendedor_Click(object sender, EventArgs e)
        {
            DataRowView linha = FormBusca.UtilPesquisa.BTN_BUSCA("a.ds_condpgto|Condição pgto|150;a.cd_condpgto|Código|50",
                new Componentes.EditDefault[] { cd_vendedor, nm_vendedor },
                new CamadaDados.Financeiro.Cadastros.TCD_CadCondPgto(), string.Empty);
            if (linha != null)
            {
                if (!string.IsNullOrEmpty(linha["Pc_custofin"].ToString()))
                {
                    (bsOrcamento.Current as TRegistro_Orcamento).Pc_custofin = Convert.ToDecimal(linha["Pc_custofin"].ToString());
                    bsOrcamento.ResetCurrentItem();
                }
                
            }
        }

        private void cd_vendedor_Leave(object sender, EventArgs e)
        {
            DataRow linha = FormBusca.UtilPesquisa.EDIT_LEAVE("a.cd_condpgto|=|'" + cd_vendedor.Text.Trim() + "'",
                                              new Componentes.EditDefault[] { cd_vendedor, nm_vendedor },
                                              new CamadaDados.Financeiro.Cadastros.TCD_CadCondPgto());
            if (linha != null)
            {
                if (!string.IsNullOrEmpty(linha["Pc_custofin"].ToString()))
                {
                    (bsOrcamento.Current as TRegistro_Orcamento).Pc_custofin = Convert.ToDecimal(linha["Pc_custofin"].ToString());
                    bsOrcamento.ResetCurrentItem();
                }
            }
        }
    }
}
