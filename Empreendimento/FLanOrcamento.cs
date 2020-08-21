using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utils;
using CamadaDados.Empreendimento;
using CamadaNegocio.Empreendimento;
using CamadaDados.Faturamento.NotaFiscal;
using CamadaNegocio.Faturamento.NotaFiscal;
using FormRelPadrao;

namespace Empreendimento
{
    public partial class TFLanOrcamento : Form
    {

        private bool Altera_Relatorio = false;
        public TFLanOrcamento()
        {
            InitializeComponent();
        }
        private void gravarNovaVersao()
        {
            string nr_versao = string.Empty;
            if (bsOrcamento.Current != null)
            {
                (bsOrcamento.Current as TRegistro_Orcamento).St_registro = "A";
                (bsOrcamento.Current as TRegistro_Orcamento).Nr_versaostr = string.Empty;
                (bsOrcamento.Current as TRegistro_Orcamento).Nr_versao = decimal.Zero;
                TCN_Orcamento.Gravar(bsOrcamento.Current as TRegistro_Orcamento, null);
                nr_versao = (bsOrcamento.Current as TRegistro_Orcamento).Nr_versaostr;
                //id_orcamento.Text = !string.IsNullOrEmpty((bsOrcamento.Current as TRegistro_Orcamento).id_orc) ? (bsOrcamento.Current as TRegistro_Orcamento).id_orc : (bsOrcamento.Current as TRegistro_Orcamento).Id_orcamentostr;
                for (int i = 0; i < (bsOrcamento.Current as TRegistro_Orcamento).lOrcProjeto.Count; i++)
                {
                    (bsOrcamento.Current as TRegistro_Orcamento).lOrcProjeto[i].Nr_versaostr = nr_versao;
                    for (int j = 0; j < ((bsOrcamento.Current as TRegistro_Orcamento).lOrcProjeto[i] as TRegistro_OrcProjeto).lFicha.Count; j++)
                    {
                        ((bsOrcamento.Current as TRegistro_Orcamento).lOrcProjeto[i] as TRegistro_OrcProjeto).lFicha[j].Nr_versaostr = nr_versao;
                       // TCN_FichaTec.Gravar(((bsOrcamento.Current as TRegistro_Orcamento).lOrcProjeto[i] as TRegistro_OrcProjeto).lFicha[j], null);
                    }
                    TCN_OrcProjeto.Gravar((bsOrcamento.Current as TRegistro_Orcamento).lOrcProjeto[i], null);
                   
                }
            }
            this.nr_versao.Text = nr_versao;
            afterBusca();

        }


        private bool comparaTotais()
        {
            if (bsOrcamento.Current != null)
            {
                decimal fichaTec = decimal.Zero;
                decimal despesas = decimal.Zero;
                decimal totaldespesas = decimal.Zero;
                decimal totalficha = decimal.Zero;
                decimal total = decimal.Zero;
                string stregistro = string.Empty;


                for (int i = 0; i < bsOrcProjeto.Count; i++)
                {
                    for (int j = 0; j < (bsOrcProjeto.List[i] as TRegistro_OrcProjeto).lFicha.Count; j++)
                    {
                        fichaTec += ((bsOrcProjeto.List[i] as TRegistro_OrcProjeto).lFicha[j] as TRegistro_FichaTec).Vl_subtotal;
                    }
                }

                for (int i = 0; i < bsOrcamento.Count; i++)
                {
                    for (int j = 0; j < (bsOrcamento.List[i] as TRegistro_Orcamento).lDespesas.Count; j++)
                    {
                        despesas += ((bsOrcamento.List[i] as TRegistro_Orcamento).lDespesas[j] as TRegistro_Despesas).Vl_subtotal;
                    }
                }
            

                object total_ficha = new TCD_Orcamento().BuscarEscalar(new TpBusca[]{
                                                                            new TpBusca(){
                                                                                vNM_Campo = "a.id_orcamento",
                                                                                vOperador = "=",
                                                                                vVL_Busca = (bsOrcamento.Current as TRegistro_Orcamento).Id_orcamentostr
                                                                            },new TpBusca(){
                                                                                vNM_Campo = "a.nr_versao",
                                                                                vOperador = "=",
                                                                                vVL_Busca = (bsOrcamento.Current as TRegistro_Orcamento).Nr_versaostr
                                                                            }
                                                                        }, "isnull((select isnull(sum(x.vl_subtotal), 0) from TB_EMP_FichaTec x"
						                                              +  " where x.cd_empresa = a.CD_Empresa"+
						                                                    " and x.ID_Orcamento = a.ID_Orcamento and a.nr_versao = x.nr_versao), 0)"
                                                                       );

                object total_despesas = new TCD_Orcamento().BuscarEscalar(new TpBusca[]{
                                                                                new TpBusca(){
                                                                                    vNM_Campo = "a.id_orcamento",
                                                                                    vOperador = "=",
                                                                                    vVL_Busca = (bsOrcamento.Current as TRegistro_Orcamento).Id_orcamentostr
                                                                                },new TpBusca(){
                                                                                vNM_Campo = "a.nr_versao",
                                                                                vOperador = "=",
                                                                                vVL_Busca = (bsOrcamento.Current as TRegistro_Orcamento).Nr_versaostr
                                                                            }
                                                                            }, "(select isnull(sum(x.vl_subtotal), 0) from TB_EMP_Despesas x"
						                                                       +"  where x.cd_empresa = a.CD_Empresa"+
						                                                        " and x.ID_Orcamento = a.ID_Orcamento and x.nr_versao = a.nr_versao), 0)"
                                                                           );
                object vlmaodeobra = new CamadaDados.Empreendimento.Cadastro.TCD_CadCFGEmpreendimento().BuscarEscalar(new TpBusca[]{
                                                                                new TpBusca(){
                                                                                    vNM_Campo = "a.cd_empresa",
                                                                                    vOperador = "=",
                                                                                    vVL_Busca = (bsOrcamento.Current as TRegistro_Orcamento).Cd_empresa
                                                                                }
                                                                            }, "a.pc_lucromaodeobra",string.Empty,string.Empty,null
                                                                           );

                
                despesas = despesas != decimal.Zero ? despesas : Convert.ToDecimal(total_despesas) ;
                fichaTec = fichaTec != decimal.Zero ? fichaTec : Convert.ToDecimal(total_ficha);
                
                total = despesas + Convert.ToDecimal(total_ficha);
                
               

                tot_despesas.Value = despesas;
                tot_projeto.Value = Convert.ToDecimal(total_ficha);
                tot_resultado.Value = total;
                object st_registro = new TCD_Orcamento().BuscarEscalar(new TpBusca[]{
                                                                                new TpBusca(){
                                                                                    vNM_Campo = "a.id_orcamento",
                                                                                    vOperador = "=",
                                                                                    vVL_Busca = (bsOrcamento.Current as TRegistro_Orcamento).Id_orcamentostr
                                                                                },
                                                                                new TpBusca(){
                                                                                    vNM_Campo = "a.nr_versao",
                                                                                    vOperador = "=",
                                                                                    vVL_Busca = (bsOrcamento.Current as TRegistro_Orcamento).Nr_versaostr
                                                                                }
                                                                            }, "a.st_registro"
                                                                           );
                stregistro = st_registro.ToString();

                if (!stregistro.Equals("A") && !stregistro.Equals("T") && !stregistro.Equals("E"))
                {
                    if (totalficha != (fichaTec))
                    {
                        return false;
                    }
                    else
                        if (totaldespesas != despesas)
                        {
                            return false;
                        }
                        else
                            return true;
                }
                else
                    return true;
            }
            return true;
        }

        private void afterBusca()
        {
            bsOrcamento.DataSource = TCN_Orcamento.Buscar(cd_empresa.Text,
                                                          id_orcamento.Text,
                                                          nr_versao.Text,
                                                          cd_clifor.Text,
                                                          string.Empty,
                                                          rbIni.Checked ? "I" : rbFin.Checked ? "F" : string.Empty,
                                                          dt_ini.Text,
                                                          dt_fin.Text,
                                                          st_projeto.Checked ? "= 'T'" : st_finalizado.Checked ? "= 'F'" : st_projeto_conc.Checked ? "= 'X'" : st_execucao.Checked ? "= 'E'" : st_aprovadorep.Checked ? "= 'R' OR isnull(a.st_registro, 'A') = 'P' " : "= 'A' OR ISNULL(a.st_registro,'A') = 'N' ",
                                                          null);
            bsOrcamento_PositionChanged(this, new EventArgs());
            bsOrcamento.ResetCurrentItem();
        }

        public void aprovarOrcamento()
        {
            if (bsOrcamento.Current != null)
            {
                string idorc = (bsOrcamento.Current as TRegistro_Orcamento).Id_orcamentostr;
                string nrver = (bsOrcamento.Current as TRegistro_Orcamento).Nr_versaostr;
                string id_novo_odc = string.Empty;
                if ((bsOrcamento.Current as TRegistro_Orcamento).lOrcProjeto.Count > 0)
                {
                    if (((bsOrcamento.Current as TRegistro_Orcamento).lOrcProjeto[0] as TRegistro_OrcProjeto).lFicha.Count > 0)
                    {
                        if ((bsOrcamento.Current as TRegistro_Orcamento).St_registro.Equals("N"))
                        {
                            //evoluir p
                            (bsOrcamento.Current as TRegistro_Orcamento).St_registro = "P";
                            (bsOrcamento.Current as TRegistro_Orcamento).vl_orcamento = tot_projeto.Value;
                            TCN_Orcamento.Gravar((bsOrcamento.Current as TRegistro_Orcamento), null);

                            TList_Orcamento listorcamento = TCN_Orcamento.Buscar(
                                                    (bsOrcamento.Current as TRegistro_Orcamento).Cd_empresa,
                                                    (bsOrcamento.Current as TRegistro_Orcamento).Id_orcamentostr,
                                                    string.Empty, (bsOrcamento.Current as TRegistro_Orcamento).Cd_clifor, (bsOrcamento.Current as TRegistro_Orcamento).Cd_vendedor, string.Empty, string.Empty, string.Empty, " = 'N' or a.st_registro = 'A'",
                                null);

                            //cria o projeto
                            (bsOrcamento.Current as TRegistro_Orcamento).Id_orcamentostr = string.Empty;
                            //(bsOrcamento.Current as TRegistro_Orcamento).id_orc = idorc;
                            //(bsOrcamento.Current as TRegistro_Orcamento).nr_ver = nrver;
                            (bsOrcamento.Current as TRegistro_Orcamento).Nr_versaostr = string.Empty;
                            (bsOrcamento.Current as TRegistro_Orcamento).St_registro = "T";
                            id_novo_odc = TCN_Orcamento.Gravar(bsOrcamento.Current as TRegistro_Orcamento, null);

                            for (int o = 0; o < listorcamento.Count; o++)
                            {
                                if ((listorcamento[o] as TRegistro_Orcamento).Id_orcamentostr.Equals(idorc))
                                {
                                    if ((listorcamento[o] as TRegistro_Orcamento).St_registro.Equals("P"))
                                    {
                                        for (int p = 0; p < (listorcamento[o] as TRegistro_Orcamento).lOrcProjeto.Count; p++)
                                        {
                                            (listorcamento[o] as TRegistro_Orcamento).lOrcProjeto[p].Id_orcamentostr = id_novo_odc;
                                            TCN_OrcProjeto.Gravar((listorcamento[o] as TRegistro_Orcamento).lOrcProjeto[p] as TRegistro_OrcProjeto, null);

                                            for (int f = 0; f < ((listorcamento[o] as TRegistro_Orcamento).lOrcProjeto[p] as TRegistro_OrcProjeto).lFicha.Count; f++)
                                            {
                                                ((listorcamento[o] as TRegistro_Orcamento).lOrcProjeto[p] as TRegistro_OrcProjeto).lFicha[f].Id_orcamentostr = id_novo_odc;
                                                TCN_FichaTec.Gravar(((listorcamento[o] as TRegistro_Orcamento).lOrcProjeto[p] as TRegistro_OrcProjeto).lFicha[f], null);
                                            }

                                        }
                                        for (int p = 0; p < (listorcamento[o] as TRegistro_Orcamento).lDespesas.Count; p++)
                                        {
                                            (listorcamento[o] as TRegistro_Orcamento).lDespesas[p].Id_orcamentostr = id_novo_odc;
                                            TCN_Despesas.Gravar((listorcamento[o] as TRegistro_Orcamento).lDespesas[p] as TRegistro_Despesas, null);
                                        }
                                    }
                                    else
                                    {
                                        (listorcamento[o] as TRegistro_Orcamento).St_registro = "R";
                                        (listorcamento[o] as TRegistro_Orcamento).Id_orcamentostr = TCN_Orcamento.Gravar(listorcamento[o] as TRegistro_Orcamento, null);
                                    }

                                }


                            }
                            st_projeto.Checked = true;
                        }
                        else
                            MessageBox.Show("Pode aprovar apenas orcamento em negociação.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        //id_orcamento.Text = !string.IsNullOrEmpty((bsOrcamento.Current as TRegistro_Orcamento).id_orc) ? (bsOrcamento.Current as TRegistro_Orcamento).id_orc : (bsOrcamento.Current as TRegistro_Orcamento).Id_orcamentostr;
                        nr_versao.Text = string.Empty;
                        afterBusca();
                    }
                    else
                        MessageBox.Show("Selecione um orcamento para poder aprovar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void TFLanOrcamento_Load(object sender, EventArgs e)
        {

            bbNovaVersao.Visible = true;
            bnprojetobt.Visible = true;
            bsFichabt.Visible = true;
            tcCentral.TabPages.Remove(tpNotaFiscal);
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pFiltro.set_FormatZero();
            if (CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin, "VISAO ORCAMENTISTA", null))
            {
                st_orcamento.Visible = true;
                st_aprovadorep.Visible = true;
                st_orcamento.Checked = true;
            }
            else
            {
                st_orcamento.Visible = false;
                st_aprovadorep.Visible = false;
                st_projeto.Checked = true;
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

        private void bb_clifor_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_clifor }, string.Empty);
        }

        private void cd_clifor_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + cd_clifor.Text.Trim() + "'",
                new Componentes.EditDefault[] { cd_clifor }, new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void bbAddOrc_Click(object sender, EventArgs e)
        {
            if (st_projeto.Checked)
            {
                MessageBox.Show("Ops não pode adicionar orcamento pelo menu projeto.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }else
            using (TFOrcamento fOrc = new TFOrcamento())
            {
                if(fOrc.ShowDialog() == DialogResult.OK)
                    if(fOrc.rOrcamento != null)
                        try
                        {
                            if (comparaTotais())
                            {
                                fOrc.rOrcamento.Id_orcamento = decimal.Zero;
                                fOrc.rOrcamento.Id_orcamentostr = string.Empty;
                                fOrc.rOrcamento.St_registro = "A";
                                TCN_Orcamento.Gravar(fOrc.rOrcamento, null);
                            }else
                                gravarNovaVersao();
                            id_orcamento.Text = fOrc.rOrcamento.Id_orcamentostr;
                            MessageBox.Show("Orcamento adicionado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            
                            this.afterBusca();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                
            }
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            this.afterBusca();
        }
        private bool st_produto_cadastrado()
        {
            bool st = false;
            // vereifica se existe produto cadastrado 
            if(st_execucao.Checked)
            if (bsOrcamento.Current != null)
            {
                TList_FichaTec list_ficha = TCN_FichaTec.Buscar(
                                    (bsOrcamento.Current as TRegistro_Orcamento).Cd_empresa,
                                    (bsOrcamento.Current as TRegistro_Orcamento).Id_orcamentostr,
                                    (bsOrcamento.Current as TRegistro_Orcamento).Nr_versaostr,
                                    string.Empty,string.Empty, string.Empty, null);
                list_ficha.ForEach(p =>
                {
                    object qtdproduto = new CamadaDados.Empreendimento.TCD_FichaTec().BuscarEscalar(new TpBusca[]{
                                                                                                                            new TpBusca(){
                                                                                                                                vNM_Campo = "a.ds_produto",
                                                                                                                                vOperador = "like",
                                                                                                                                vVL_Busca = "'"+(p.Ds_produto)+"'"
                                                                                                                            },
                                                                                                                            new TpBusca(){
                                                                                                                                vOperador = "exists",
                                                                                                                                vVL_Busca = "(select 1 from tb_est_produto x where a.cd_produto = x.cd_produto)"
                                                                                                                            }
                                    
                                                                                                                        },"a.cd_produto");
                    if (qtdproduto == null)
                        st = true;
                });
            }
            if (st) 
                MessageBox.Show("Existe produto não cadastrado!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                

            return st;


        }


        private void finalizarProjeto()
        {
            if (bsOrcamento.Current as TRegistro_Orcamento != null)
            {
                if ((bsOrcamento.Current as TRegistro_Orcamento).lOrcProjeto.Count > 0)
                    if (((bsOrcamento.Current as TRegistro_Orcamento).lOrcProjeto[0] as TRegistro_OrcProjeto).lFicha.Count > 0)
                    {
                        if ((bsOrcamento.Current as TRegistro_Orcamento).St_registro.Equals("T"))
                        {
                            if (MessageBox.Show("Deseja Evoluir para execução o projeto?", "Mensagem",
                                      MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                                      System.Windows.Forms.DialogResult.Yes)
                            {

                                st_produto_cadastrado();

                                //gravar registro finalizado
                                (bsOrcamento.Current as TRegistro_Orcamento).St_registro = "X";
                                TCN_Orcamento.Gravar((bsOrcamento.Current as TRegistro_Orcamento), null);

                                //gravar registro em execucao
                                (bsOrcamento.Current as TRegistro_Orcamento).St_registro = "E";
                                (bsOrcamento.Current as TRegistro_Orcamento).Id_orcamentostr = string.Empty;
                                
                                //(bsOrcamento.Current as TRegistro_Orcamento).Nr_versao = decimal.Zero;
                                //(bsOrcamento.Current as TRegistro_Orcamento).Nr_versaostr = string.Empty;
                                TCN_Orcamento.Gravar((bsOrcamento.Current as TRegistro_Orcamento), null);
                                //id_orcamento.Text = !string.IsNullOrEmpty((bsOrcamento.Current as TRegistro_Orcamento).id_orc) ? (bsOrcamento.Current as TRegistro_Orcamento).id_orc : (bsOrcamento.Current as TRegistro_Orcamento).Id_orcamentostr;
                                MessageBox.Show("Projeto finalizado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                st_execucao.Checked = true;
                            }
                        }
                        else
                            MessageBox.Show("Pode finalizar apenas projeto em execução.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                        MessageBox.Show("Inclua um produto para executar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
                MessageBox.Show("Selecione um orcamento para executar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void TFLanOrcamento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F2) && st_orcamento.Checked)
                BB_Novo_Click(this, new EventArgs());
            if (e.KeyCode.Equals(Keys.F7) )
                this.afterBusca();
            if (e.KeyCode.Equals(Keys.F8) && st_orcamento.Checked)
                EvoluirNegociacao();
            if (e.KeyCode.Equals(Keys.F3) && !st_finalizado.Checked)
                BB_Alterar_Click(this,new EventArgs());
            if (e.KeyCode.Equals(Keys.F6) && st_orcamento.Checked)
                bbNovaVersao_Click(this, new EventArgs());
            if (e.KeyCode.Equals(Keys.F9) && st_orcamento.Checked)
                aprovarOrcamento();
            if (e.KeyCode.Equals(Keys.F8) && st_projeto.Checked)
                finalizarProjeto();
            if (e.KeyCode.Equals(Keys.F8) && st_execucao.Checked)
                bbFinalizar_Click2(this, new EventArgs());
            if (e.KeyCode.Equals(Keys.F4) && st_execucao.Checked )
                bbFat_Click(this,new EventArgs());
            if (e.KeyCode.Equals(Keys.F5) && st_orcamento.Checked)
                BB_Excluir_Click(this, new EventArgs());
        }

        private void bbCorrigirOrc_Click(object sender, EventArgs e)
        {
            
        }

        private void bbAddProjeto_Click(object sender, EventArgs e)
        {

            if (st_projeto.Checked)
            {
                MessageBox.Show("Selecione um Orcamento.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            

            if (bsOrcamento.Current != null)
                using (TFOrcProjeto fOrc = new TFOrcProjeto())
                {
                    if(fOrc.ShowDialog() == DialogResult.OK)
                        if(fOrc.rOrc != null)
                            try
                            {

                                if (!comparaTotais())
                                {
                                    gravarNovaVersao();
                                }
                                fOrc.rOrc.Cd_empresa = (bsOrcamento.Current as TRegistro_Orcamento).Cd_empresa;
                                fOrc.rOrc.Id_orcamento = (bsOrcamento.Current as TRegistro_Orcamento).Id_orcamento;
                                fOrc.rOrc.Nr_versao = (bsOrcamento.Current as TRegistro_Orcamento).Nr_versao;
                                TCN_OrcProjeto.Gravar(fOrc.rOrc, null);
                               
                                MessageBox.Show("Projeto incluido com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                bsOrcamento_PositionChanged(this,new EventArgs());
                                bsOrcProjeto.Position = bsOrcProjeto.Count - 1;
                                bsOrcProjeto.ResetBindings(true);
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            else 
                MessageBox.Show("Obrigatório selecionar ORÇAMENTO para incluir PROJETO.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void bsOrcamento_PositionChanged(object sender, EventArgs e)
        {
            if (bsOrcamento.Current != null)
            {
                if ((bsOrcamento.Current as TRegistro_Orcamento).Status.Equals("NEGOCIACAO") && st_orcamento.Checked)
                {
                    bn_despesas.Visible = false;
                    bnficha.Visible = false;
                    bnorcamento.Visible = false;
                    bnprojetos.Visible = false;
                }
                else
                {
                    bn_despesas.Visible = true;
                    bnficha.Visible = true;
                    bnorcamento.Visible = true;
                    bnprojetos.Visible = true;
                }

                //Buscar Projetos
                (bsOrcamento.Current as TRegistro_Orcamento).lOrcProjeto =
                    TCN_OrcProjeto.Buscar((bsOrcamento.Current as TRegistro_Orcamento).Cd_empresa,
                                          (bsOrcamento.Current as TRegistro_Orcamento).Id_orcamentostr,
                                          (bsOrcamento.Current as TRegistro_Orcamento).Nr_versaostr,
                                          string.Empty,
                                          string.Empty,
                                          null);

                List<CamadaDados.Empreendimento.TRegistro_Despesas> lDespesas = TCN_Despesas.Buscar(
                                          (bsOrcamento.Current as TRegistro_Orcamento).Cd_empresa,
                                          (bsOrcamento.Current as TRegistro_Orcamento).Id_orcamentostr,
                                          (bsOrcamento.Current as TRegistro_Orcamento).Nr_versaostr,
                                          string.Empty, string.Empty, null);

                List<CamadaDados.Empreendimento.TRegistro_Despesas> lDesp = new List<CamadaDados.Empreendimento.TRegistro_Despesas>();
                //lDespesas.ForEach(p =>
                //    {
                //        if (lDesp.Count.Equals(0) || !lDesp.Exists(x => x.Id_despesapai.Equals(p.Id_despesapai)))
                //        {
                //            CamadaDados.Empreendimento.TRegistro_Despesas r =
                //                new CamadaDados.Empreendimento.TRegistro_Despesas();
                //            r.Ds_despesa = p.Ds_despesapai;
                //            r.Id_despesapai = p.Id_despesapai;
                //            lDesp.Add(r);
                //        }
                //        lDesp.Add(p);
                //    });
                (bsOrcamento.Current as TRegistro_Orcamento).lDespesas.RemoveAll(p => 0 == 0);
                
                lDesp.ForEach(p => (bsOrcamento.Current as TRegistro_Orcamento).lDespesas.Add(p));
                bsOrcamento.ResetCurrentItem();

                bsOrcProjeto_PositionChanged(this, new EventArgs());

                comparaTotais();
                bsFatDireto.DataSource = CamadaNegocio.Empreendimento.Cadastro.TCN_CadFatDireto.Buscar(
                                                                                    (bsOrcamento.Current as TRegistro_Orcamento).Cd_empresa,    
                                                                                    (bsOrcamento.Current as TRegistro_Orcamento).Id_orcamentostr,
                                                                                    string.Empty, //(bsOrcamento.Current as TRegistro_Orcamento).id_projeto,
                                                                                    (bsOrcamento.Current as TRegistro_Orcamento).Nr_versaostr,
                                                                                    string.Empty,
                                                                                    string.Empty,
                                                                                    string.Empty,string.Empty,string.Empty,string.Empty,string.Empty,null
                                                                                    );
                bsFatDireto.ResetCurrentItem();
                bsFatDireto_PositionChanged(this,new EventArgs());

                //if (!(string.IsNullOrEmpty((bsOrcamento.Current as TRegistro_Orcamento).nr_lanctofiscal)))
                //{
                //    bsNotaFiscal.DataSource =
                //                new CamadaDados.Faturamento.NotaFiscal.TCD_LanFaturamento().Select(
                //                    new TpBusca[]
                //                { 
                //                    new TpBusca()
                //                    {
                //                        vNM_Campo = string.Empty,
                //                        vOperador = "exists",
                //                        vVL_Busca = "(select 1 from TB_EMP_NFRemessa x "+
                //                                    "where x.Nr_LanctoFiscal = a.Nr_LanctoFiscal "+
                //                                    "and x.id_orcamento = "+(bsOrcamento.Current as TRegistro_Orcamento).Id_orcamentostr.ToString()+" "+
                //                                    "and x.nr_versao = "+(bsOrcamento.Current as TRegistro_Orcamento).Nr_versaostr.ToString()+")"
                //                    }
                //                }, 0, string.Empty);
                //    bsNotaFiscal.ResetCurrentItem();
                //    Tot_orcamento.Value = (bsOrcamento.Current as TRegistro_Orcamento).vl_orcamento;

                //}

            }
            else
            {
                tot_despesas.Value = decimal.Zero;
                tot_projeto.Value = decimal.Zero;
                tot_resultado.Value = decimal.Zero;
            }
        }

        private void bbCorrigirProjeto_Click(object sender, EventArgs e)
        {
            
            if (bsOrcProjeto.Current != null)
            {
                using (TFOrcProjeto fOrc = new TFOrcProjeto())
                {
                    fOrc.rOrc = bsOrcProjeto.Current as TRegistro_OrcProjeto;
                    if(fOrc.ShowDialog() == DialogResult.OK)
                        try
                        {

                            if (!comparaTotais())
                            {
                                gravarNovaVersao();
                            }
                            fOrc.rOrc.Cd_empresa = (bsOrcamento.Current as TRegistro_Orcamento).Cd_empresa;
                            fOrc.rOrc.Id_orcamento = (bsOrcamento.Current as TRegistro_Orcamento).Id_orcamento;
                            fOrc.rOrc.Nr_versao = (bsOrcamento.Current as TRegistro_Orcamento).Nr_versao;
                            TCN_OrcProjeto.Gravar(fOrc.rOrc, null);
                            bsOrcamento_PositionChanged(this, new EventArgs());

                            MessageBox.Show("Projeto corrigido com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            }
            else MessageBox.Show("Obrigatório selecionar PROJETO para corrigir.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void bsOrcProjeto_PositionChanged(object sender, EventArgs e)
        {
            if (bsOrcProjeto.Current != null)
            {
            
                (bsOrcProjeto.Current as TRegistro_OrcProjeto).lFicha =
                    TCN_FichaTec.Buscar((bsOrcProjeto.Current as TRegistro_OrcProjeto).Cd_empresa,
                                        (bsOrcProjeto.Current as TRegistro_OrcProjeto).Id_orcamentostr,
                                        (bsOrcProjeto.Current as TRegistro_OrcProjeto).Nr_versaostr,
                                        (bsOrcProjeto.Current as TRegistro_OrcProjeto).Id_projetostr, string.Empty,
                                        string.Empty,
                                        null);
            
                bsOrcProjeto.ResetCurrentItem();
            }
        }

        private void bbAdicionardespesa_Click(object sender, EventArgs e)
        {
            
            if(bsOrcamento.Current != null)
            using (TFLanDespesa fDespesa = new TFLanDespesa())
            {
                fDespesa.pcd_empresa = (bsOrcamento.Current as TRegistro_Orcamento).Cd_empresa;

                if (fDespesa.ShowDialog() == DialogResult.OK)
                {
                    if (!comparaTotais())
                    {
                        gravarNovaVersao();
                    }
                    fDespesa.rDespesa.Cd_empresa = (bsOrcamento.Current as TRegistro_Orcamento).Cd_empresa;
                    fDespesa.rDespesa.Id_orcamento = (bsOrcamento.Current as TRegistro_Orcamento).Id_orcamento;
                    fDespesa.rDespesa.Nr_versao = (bsOrcamento.Current as TRegistro_Orcamento).Nr_versao;
                    TCN_Despesas.Gravar(fDespesa.rDespesa, null);
                    bsOrcamento_PositionChanged(this, new EventArgs());
                    MessageBox.Show("Despesa adicionada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    afterBusca();
                }
            }

        }

        private void bbALterardespesa_click(object sender, EventArgs e)
        {
            if (bsDespesas.Current != null)
            {
                if ((bsDespesas.Current as TRegistro_Despesas).Quantidade > decimal.Zero && (bsDespesas.Current as TRegistro_Despesas).Vl_unitario > decimal.Zero)
                {
                    using (TFLanDespesa fDespesa = new TFLanDespesa())
                    {
                        fDespesa.rDespesa = bsDespesas.Current as TRegistro_Despesas;

                        if (fDespesa.ShowDialog() == DialogResult.OK)
                        {
                            if (!comparaTotais())
                            {
                                gravarNovaVersao();
                            }

                            fDespesa.rDespesa.Cd_empresa = (bsOrcamento.Current as TRegistro_Orcamento).Cd_empresa;
                            fDespesa.rDespesa.Id_orcamento = (bsOrcamento.Current as TRegistro_Orcamento).Id_orcamento;
                            fDespesa.rDespesa.Nr_versao = (bsOrcamento.Current as TRegistro_Orcamento).Nr_versao;
                            TCN_Despesas.Gravar(fDespesa.rDespesa, null);
                            bsOrcamento_PositionChanged(this, new EventArgs());
                            afterBusca();
                            MessageBox.Show("Despesa adicionada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                    }
                }
                else
                    MessageBox.Show("Selecione uma despesa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
                MessageBox.Show("Selecione uma despesa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void bbexcluirdespesa_click(object sender, EventArgs e)
        {
            
            if (bsDespesas.Current as TRegistro_Despesas != null)
            {
                if (MessageBox.Show("Deseja Realmente Excluir a despesa ?", "Mensagem",
                       MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                       System.Windows.Forms.DialogResult.Yes)
                {
                    if (!comparaTotais())
                    {
                        gravarNovaVersao();
                    }

                    TCN_Despesas.Excluir((bsDespesas.Current as TRegistro_Despesas), null);
                    MessageBox.Show("despesa excluido com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    afterBusca();
                }
            }
        }

        private void bbExcluirOrc_Click(object sender, EventArgs e)
        {
            
        }

        private void bbExcluirProjeto_Click(object sender, EventArgs e)
        {
            
            if (bsOrcProjeto.Current != null)
            {
                if (MessageBox.Show("Deseja Realmente Excluir o Projeto?", "Mensagem",
                       MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                       System.Windows.Forms.DialogResult.Yes)
                {
                    if(!validaExcluir())
                    {
                        if (!comparaTotais())
                        {
                            gravarNovaVersao();
                        }
                        (bsOrcProjeto.Current as TRegistro_OrcProjeto).lFicha.ForEach(p =>
                            p.lfichaItens = TCN_FichaItens.Buscar((bsFicha.Current as TRegistro_FichaTec).Cd_empresa,
                                                                                          (bsFicha.Current as TRegistro_FichaTec).Id_orcamentostr,
                                                                                          (bsFicha.Current as TRegistro_FichaTec).Nr_versaostr,
                                                                                          (bsFicha.Current as TRegistro_FichaTec).Id_projetostr,
                                                                                          string.Empty,
                                                                                          string.Empty, null)
                        );

                        TCN_OrcProjeto.Excluir((bsOrcProjeto.Current as TRegistro_OrcProjeto), null);
                        MessageBox.Show("Item excluido com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        afterBusca();
                    }
                    else
                        MessageBox.Show("Não pode excluir item faturado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
                MessageBox.Show("Selecione um projeto.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void tcCentral_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void gDespesas_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
            {
                if (e.ColumnIndex == 0)
                    //if (string.IsNullOrEmpty((bsDespesas[e.RowIndex] as CamadaDados.Empreendimento.TRegistro_Despesas).Tp_despesa))
                    //{
                    //    gDespesas.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Blue;
                    //    gDespesas.Rows[e.RowIndex].DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
                    //}
                    //else
                    {
                        gDespesas.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                        gDespesas.Rows[e.RowIndex].DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular);
                    }
            }
        }

        private void bb_vendedor_Click(object sender, EventArgs e)
        {
            string vColunas = "a.nm_clifor|Nome Vendedor|200;" +
                              "a.cd_clifor|Cd. Vendedor|80";
            string vParam = "isnull(a.st_vendedor, 'N')|=|'S';" +
                            "isnull(a.st_funcativo, 'N')|=|'S'";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_vendedor },
                new CamadaDados.Financeiro.Cadastros.TCD_CadClifor(),
               vParam);
        }

        private void cd_vendedor_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_clifor|=|'" + cd_vendedor.Text.Trim() + "';" +
                            "isnull(a.st_vendedor, 'N')|=|'S';" +
                            "isnull(a.st_funcativo, 'N')|=|'S'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_vendedor },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void bbImportarProjeto_Click(object sender, EventArgs e)
        {
            if (bsOrcamento.Current != null)
            {
                string id_orcamento = string.Empty;
                using (TFConsultaProjetos cProjetos = new TFConsultaProjetos())
                {
                    cProjetos.vId_orcamento = this.id_orcamento.Text;
                    
                    if (cProjetos.ShowDialog() == DialogResult.OK)
                    {
                        TList_Orcamento lprojeto = new TList_Orcamento();
                        lprojeto = cProjetos.lOrc;
                        TList_FichaTec lFicha = new TList_FichaTec();
                        
                        //remove items não selecionados
                        /*

                        lprojeto.Where(p => p.st_importar).ToList().ForEach(p =>
                                  {
                                      //p.lFicha = TCN_FichaTec.Buscar(p.Cd_empresa,p.Id_orcamentostr,p.Nr_versaostr,p.Id_projetostr,string.Empty,null
                                      //    );
                                      p.lFicha.Where(i => i.st_agregar).ToList().ForEach(i =>
                                      {
                                          i.Quantidade = i.quantidade_agregar;
                                          i.quantidade_agregar = decimal.Zero;
                                          i.Id_ficha = decimal.Zero;
                                          i.Id_orcamentostr = (bsOrcamento.Current as TRegistro_Orcamento).Id_orcamentostr;
                                          i.Id_projetostr = string.Empty;
                                          i.Nr_versaostr = (bsOrcamento.Current as TRegistro_Orcamento).Nr_versaostr;
                                          lFicha.Add(i);

                                      });
                                      p.Id_orcamentostr = (bsOrcamento.Current as TRegistro_Orcamento).Id_orcamentostr;
                                      p.Id_projetostr = string.Empty;
                                      p.Nr_versaostr = (bsOrcamento.Current as TRegistro_Orcamento).Nr_versaostr;
                                      p.lFicha = lFicha;
                                      TCN_OrcProjeto.Gravar(p, null);
                                  }
                              );
                        */
                        bsOrcProjeto.ResetCurrentItem();


                    }
                } 
                afterBusca();
            }
            else
                MessageBox.Show("Selecione um Orcamento.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void toolStripButton24_Click(object sender, EventArgs e)
        {

            this.afterBusca();
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButton27_Click(object sender, EventArgs e)
        {
            if (bsOrcamento.Current != null)
            {
                afterBusca();
            }
        }

        private void bbImportarProjeto_DisplayStyleChanged(object sender, EventArgs e)
        {

        }
        private void EvoluirNegociacao()
        {
            if (bsOrcamento.Current as TRegistro_Orcamento != null)
            {
                if ((bsOrcamento.Current as TRegistro_Orcamento).lOrcProjeto.Count > 0)
                {
                    if (((bsOrcamento.Current as TRegistro_Orcamento).lOrcProjeto[0] as TRegistro_OrcProjeto).lFicha.Count > 0)
                    {
                        if ((bsOrcamento.Current as TRegistro_Orcamento).St_registro.Equals("A"))
                        {
                            if (MessageBox.Show("Deseja Evoluir o orcamento para negociação?", "Mensagem",
                                      MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                                      System.Windows.Forms.DialogResult.Yes)
                            {
                                (bsOrcamento.Current as TRegistro_Orcamento).St_registro = "N";
                                TCN_Orcamento.Gravar((bsOrcamento.Current as TRegistro_Orcamento), null);
                                MessageBox.Show("Orcamento evoluido com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                afterBusca();
                            }
                        }
                        else
                            MessageBox.Show("Pode evoluir apenas orcamento em aberto.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                        MessageBox.Show("Deve incluir projeto para evoluir.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                  
                }else
                    MessageBox.Show("Deve incluir produtos para evoluir.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    
            }else
            MessageBox.Show("Selecione um orcamento para poder evoluir.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void toolStripButton27_Click_1(object sender, EventArgs e)
        {
            EvoluirNegociacao();
        }

        private void bindingNavigator4_RefreshItems(object sender, EventArgs e)
        {

        }

        private void toolStripButton28_Click(object sender, EventArgs e)
        {
            aprovarOrcamento();
        }

        private void st_projeto_CheckedChanged(object sender, EventArgs e)
        {

            bn_despesas.Visible = st_projeto.Checked;
            bnficha.Visible = st_projeto.Checked;
            bnorcamento.Visible = st_projeto.Checked;
            bnprojetos.Visible = st_projeto.Checked;
            bbFat.Visible = st_projeto.Checked;
            bnprojetobt.Visible = st_projeto.Checked;
            bsFichabt.Visible = st_projeto.Checked;
            BB_Novo.Visible = st_projeto.Checked;
            BB_Alterar.Visible = st_projeto.Checked;
            BB_Excluir.Visible = !st_projeto.Checked;

            bbExecutar.Visible = st_projeto.Checked;
            bbFat.Visible = !st_projeto.Checked;
            afterBusca();
        }

        private void st_orcamento_CheckedChanged(object sender, EventArgs e)
        {
            bbaprovar.Visible = st_orcamento.Checked;
            bbevoluir.Visible = st_orcamento.Checked;
            bbExecutar.Visible = !st_orcamento.Checked;
            bbImportarProjeto.Visible = st_orcamento.Checked;
            bbNovaVersao.Visible = st_orcamento.Checked;

            bn_despesas.Visible = st_orcamento.Checked;
            bnficha.Visible = st_orcamento.Checked;
            bnorcamento.Visible = st_orcamento.Checked;
            bnprojetos.Visible = st_orcamento.Checked;
            bnprojetobt.Visible = st_orcamento.Checked;
            bsFichabt.Visible = st_orcamento.Checked;
            BB_Novo.Visible = st_orcamento.Checked;
            BB_Alterar.Visible = st_orcamento.Checked;
            BB_Excluir.Visible = st_orcamento.Checked;


            bbFat.Visible = !st_orcamento.Checked;
            afterBusca();


        }

        private void bbFinalizar_Click(object sender, EventArgs e)
        {
            finalizarProjeto();
        }


        private void st_aprovadorep_CheckedChanged(object sender, EventArgs e)
        {
            bbExecutar.Visible = !st_aprovadorep.Checked;
            bn_despesas.Visible = !st_aprovadorep.Checked;
            bnficha.Visible = !st_aprovadorep.Checked;
            bnorcamento.Visible = !st_aprovadorep.Checked;
            bnprojetos.Visible = !st_aprovadorep.Checked;
            bnprojetobt.Visible = !st_aprovadorep.Checked;
            bsFichabt.Visible = !st_aprovadorep.Checked;
            bbFat.Visible = !st_aprovadorep.Checked;
            BB_Novo.Visible = !st_aprovadorep.Checked;
            BB_Alterar.Visible = !st_aprovadorep.Checked;
            BB_Excluir.Visible = !st_aprovadorep.Checked;
            afterBusca();
        }

        private void st_finalizado_CheckedChanged(object sender, EventArgs e)
        {
            if (st_finalizado.Checked)
            {
                bbExecutar.Visible = !st_finalizado.Checked;
                bn_despesas.Visible = !st_finalizado.Checked;
                bnficha.Visible = !st_finalizado.Checked;
                bnorcamento.Visible = !st_finalizado.Checked;
                bnprojetos.Visible = !st_finalizado.Checked;
                bbFat.Visible = !st_finalizado.Checked;
                bnprojetobt.Visible = !st_finalizado.Checked;
                bsFichabt.Visible = !st_finalizado.Checked;
                BB_Novo.Visible = st_finalizado.Checked;
                BB_Alterar.Visible = !st_finalizado.Checked;
                BB_Excluir.Visible = !st_finalizado.Checked;
                tcCentral.TabPages.Add(tpNotaFiscal);
                afterBusca();
            }
            else
                tcCentral.TabPages.Remove(tpNotaFiscal);
        }

        private void editFloat2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void bbFat_Click(object sender, EventArgs e)
        {

            if (st_produto_cadastrado())
                return;

                 object valor = new TCD_FichaTec().BuscarEscalar(new TpBusca[]{
                                                                    new TpBusca(){
                                                                        vNM_Campo =  "a.nr_versao",
                                                                        vOperador = "=",
                                                                        vVL_Busca = (bsOrcamento.Current as TRegistro_Orcamento).Nr_versaostr
                                                                    },
                                                                    new TpBusca(){
                                                                        vNM_Campo = "a.id_orcamento",
                                                                        vOperador = "=",
                                                                        vVL_Busca = (bsOrcamento.Current as TRegistro_Orcamento).Id_orcamentostr
                                                                    }
                                                                    }, "sum(isnull(a.quantidade - a.qtd_faturada,0)) as total_afaturar");
                if (Convert.ToDecimal(valor) > 0)
                {

                        using (FItensRemessa itensRemessa = new FItensRemessa())
                        {
                            itensRemessa.rOrcamento = (bsOrcamento.Current as TRegistro_Orcamento);
                            itensRemessa.vNr_Versao = (bsOrcamento.Current as TRegistro_Orcamento).Nr_versaostr;
                            itensRemessa.vCD_Empresa = (bsOrcamento.Current as TRegistro_Orcamento).Cd_empresa;
                            itensRemessa.vID_Orcamento = (bsOrcamento.Current as TRegistro_Orcamento).Id_orcamentostr;
                            itensRemessa.vTp_Fat = "Normal";

                            if (itensRemessa.ShowDialog() == DialogResult.OK)
                            {
                                afterBusca();
                            }
                        }

                }
                else 
                    MessageBox.Show("Empreendimento não existe saldo a faturar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
             
        }

        private void gProjeto_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void gOrc_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
                if (e.ColumnIndex == 0)
                {
                    if (e.Value.ToString().Trim().ToUpper().Equals("ABERTO"))
                    {
                        DataGridViewRow linha = gOrc.Rows[e.RowIndex];
                        linha.DefaultCellStyle.ForeColor = Color.Blue;
                    }
                    else if (e.Value.ToString().Trim().ToUpper().Equals("NEGOCIACAO"))
                    {
                        DataGridViewRow linha = gOrc.Rows[e.RowIndex];
                        linha.DefaultCellStyle.ForeColor = Color.Tomato;
                    }
                    else if (e.Value.ToString().Trim().ToUpper().Equals("FINALIZADO"))
                    {
                        DataGridViewRow linha = gOrc.Rows[e.RowIndex];
                        linha.DefaultCellStyle.ForeColor = Color.SteelBlue;
                    }
                    else if (e.Value.ToString().Trim().ToUpper().Equals("REPROVADO"))
                    {
                        DataGridViewRow linha = gOrc.Rows[e.RowIndex];
                        linha.DefaultCellStyle.ForeColor = Color.Red;
                    }
                    else if (e.Value.ToString().Trim().ToUpper().Equals("APROVADO"))
                    {
                        DataGridViewRow linha = gOrc.Rows[e.RowIndex];
                        linha.DefaultCellStyle.ForeColor = Color.Black;
                    }
                    else if (e.Value.ToString().Trim().ToUpper().Equals("EMPREENDIMENTO"))
                    {
                        DataGridViewRow linha = gOrc.Rows[e.RowIndex];
                        linha.DefaultCellStyle.ForeColor = Color.Purple;
                    }
                    else if (e.Value.ToString().Trim().ToUpper().Equals("EXECUCAO"))
                    {
                        DataGridViewRow linha = gOrc.Rows[e.RowIndex];
                        linha.DefaultCellStyle.ForeColor = Color.Green;
                    }
                    else
                    {
                        DataGridViewRow linha = gOrc.Rows[e.RowIndex];
                        linha.DefaultCellStyle.ForeColor = Color.Black;
                    }
                }
        }

        private void st_execucao_ChangeUICues(object sender, UICuesEventArgs e)
        {

        }

        private void st_execucao_CheckedChanged(object sender, EventArgs e)
        {
            bbExecutar.Visible = !st_execucao.Checked;
            bbFat.Visible = st_execucao.Checked;
            bbFinalizar.Visible = st_execucao.Checked;
            bn_despesas.Visible = st_execucao.Checked;
            bbFat.Visible = st_execucao.Checked;
            bnficha.Visible = st_execucao.Checked;
            bnorcamento.Visible = st_execucao.Checked;
            bbExcluirFicha.Visible = !st_execucao.Checked;
            toolStripButton27.Visible = st_execucao.Checked;
            bsFichabt.Visible = st_execucao.Checked;
            bnprojetobt.Visible = st_execucao.Checked;
            BB_Novo.Visible = st_execucao.Checked;
            BB_Alterar.Visible = st_execucao.Checked;
            bbNovoProduto.Visible = st_execucao.Checked;
            BB_Excluir.Visible = !st_execucao.Checked;
            bbDuplicata.Visible = st_execucao.Checked;

            if (st_execucao.Checked)
            {
                tcCentral.TabPages.Add(tpNotaFiscal);
                afterBusca();
            }
            else
                tcCentral.TabPages.Remove(tpNotaFiscal);
            bnprojetos.Visible = st_execucao.Checked;

        }

        private void st_projeto_conc_CheckedChanged(object sender, EventArgs e)
        {

            // nr_versao.Text = (bsOrcamento.Current as TRegistro_Orcamento).Nr_versaostr;
            afterBusca();
        }

        private void toolStripButton40_Click(object sender, EventArgs e)
        {

        }

        private void Imprime_Danfe()
        {
            Relatorio Danfe = new Relatorio();
            Danfe.Altera_Relatorio = Altera_Relatorio;
            //Buscar NFe
            TRegistro_LanFaturamento rNfe = TCN_LanFaturamento.BuscarNF((bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_empresa,
                                                                        (bsNotaFiscal.Current as TRegistro_LanFaturamento).Nr_lanctofiscalstr,
                                                                        null);
            //Buscar Itens NFe
            rNfe.ItensNota = TCN_LanFaturamento_Item.Busca(rNfe.Cd_empresa,
                                                           rNfe.Nr_lanctofiscalstr,
                                                           string.Empty,
                                                           null);
            Danfe.Parametros_Relatorio.Add("VL_IPI", rNfe.ItensNota.Sum(v=> v.Vl_ipi));
            Danfe.Parametros_Relatorio.Add("VL_ICMS", rNfe.ItensNota.Sum(v=> v.Vl_icms + v.Vl_FCP));
            Danfe.Parametros_Relatorio.Add("VL_BASEICMS", rNfe.ItensNota.Sum(v=> v.Vl_basecalcICMS));
            Danfe.Parametros_Relatorio.Add("VL_BASEICMSSUBST", rNfe.ItensNota.Sum(v=> v.Vl_basecalcSTICMS));
            Danfe.Parametros_Relatorio.Add("VL_ICMSSUBST", rNfe.ItensNota.Sum(v=> v.Vl_ICMSST + v.Vl_FCPST));

            BindingSource Bin = new BindingSource();
            Bin.DataSource = new TList_RegLanFaturamento() { rNfe };
            Danfe.Nome_Relatorio = "TFLanFaturamento_Danfe";
            Danfe.NM_Classe = "TFLanConsultaNFe";
            Danfe.Modulo = "FAT";
            Danfe.Ident = "TFLanFaturamento_Danfe";
            Danfe.DTS_Relatorio = Bin;
            //Buscar financeiro da DANFE
            CamadaDados.Financeiro.Duplicata.TList_RegLanParcela lParc =
                new CamadaDados.Financeiro.Duplicata.TCD_LanParcela().Select(
                                new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = "isnull(a.st_registro, 'A')",
                                            vOperador = "<>",
                                            vVL_Busca = "'L'"
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = string.Empty,
                                            vOperador = "exists",
                                            vVL_Busca = "(select 1 from tb_fin_duplicata x " +
                                                        "inner join tb_fat_notafiscal_x_duplicata y " +
                                                        "on x.cd_empresa = y.cd_empresa " +
                                                        "and x.nr_lancto = y.nr_lanctoduplicata " +
                                                        "where isnull(x.st_registro, 'A') <> 'C' " +
                                                        "and x.cd_empresa = a.cd_empresa " +
                                                        "and x.nr_lancto = a.nr_lancto " +
                                                        "and y.cd_empresa = '" + (bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_empresa.Trim() + "' " +
                                                        "and y.nr_lanctofiscal = " + (bsNotaFiscal.Current as TRegistro_LanFaturamento).Nr_lanctofiscal + ")"
                                        }
                                    }, 0, string.Empty, "a.dt_vencto, c.nm_clifor", string.Empty);
            if (lParc.Count == 0)
            {
                //Verificar se Nota a nota foi vinculada de um cupom e buscar o Financeiro
                lParc =
                    new CamadaDados.Financeiro.Duplicata.TCD_LanParcela().Select(
                                    new TpBusca[]
                                        {
                                            new TpBusca()
                                            {
                                                vNM_Campo = "isnull(a.st_registro, 'A')",
                                                vOperador = "<>",
                                                vVL_Busca = "'L'"
                                            },
                                            new TpBusca()
                                            {
                                                vNM_Campo = string.Empty,
                                                vOperador = "exists",
                                                vVL_Busca = "(select 1 from tb_fin_duplicata x " +
                                                            "inner join TB_PDV_CupomFiscal_X_Duplicata y " +
                                                            "on x.cd_empresa = y.cd_empresa " +
                                                            "and x.nr_lancto = y.nr_lancto " +
                                                            "inner join TB_PDV_Cupom_X_VendaRapida k " +
                                                            "on y.cd_empresa = k.cd_empresa " +
                                                            "and y.id_cupom = k.id_vendarapida " +
                                                            "inner join TB_FAT_ECFVinculadoNF z " +
                                                            "on k.cd_empresa = z.cd_empresa " +
                                                            "and k.id_cupom = z.id_cupom " +
                                                            "where isnull(x.st_registro, 'A') <> 'C' " +
                                                            "and x.cd_empresa = a.cd_empresa " +
                                                            "and x.nr_lancto = a.nr_lancto " +
                                                            "and z.cd_empresa = '" + (bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_empresa.Trim() + "' " +
                                                            "and z.nr_lanctofiscal = " + (bsNotaFiscal.Current as TRegistro_LanFaturamento).Nr_lanctofiscal + ")"
                                            }
                                        }, 0, string.Empty, "a.dt_vencto, c.nm_clifor", string.Empty);
                if (lParc.Count == 0)
                {
                    //Verificar se Nota foi gerada de uma venda rapida e buscar o Financeiro
                    lParc =
                        new CamadaDados.Financeiro.Duplicata.TCD_LanParcela().Select(
                            new TpBusca[]
                                        {
                                            new TpBusca()
                                            {
                                                vNM_Campo = "isnull(a.st_registro, 'A')",
                                                vOperador = "<>",
                                                vVL_Busca = "'L'"
                                            },
                                            new TpBusca()
                                            {
                                                vNM_Campo = string.Empty,
                                                vOperador = "exists",
                                                vVL_Busca = "(select 1 from tb_fin_duplicata x " +
                                                            "inner join TB_PDV_CupomFiscal_X_Duplicata y " +
                                                            "on x.cd_empresa = y.cd_empresa " +
                                                            "and x.nr_lancto = y.nr_lancto " +
                                                            "inner join TB_PDV_Pedido_X_VendaRapida k " +
                                                            "on k.cd_empresa = y.cd_empresa " +
                                                            "and k.id_vendarapida = y.id_cupom " +
                                                            "inner join TB_FAT_NotaFiscal z " +
                                                            "on z.cd_empresa = k.cd_empresa " +
                                                            "and z.nr_pedido = k.nr_pedido " +
                                                            "where isnull(x.st_registro, 'A') <> 'C' " +
                                                            "and x.cd_empresa = a.cd_empresa " +
                                                            "and x.nr_lancto = a.nr_lancto " +
                                                            "and z.cd_empresa = '" + (bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_empresa.Trim() + "' " +
                                                            "and z.nr_lanctofiscal = " + (bsNotaFiscal.Current as TRegistro_LanFaturamento).Nr_lanctofiscal + ")"
                                            }
                                       }, 0, string.Empty, "a.dt_vencto, c.nm_clifor", string.Empty);
                }
            }
            if (lParc.Count > 0)
            {
                for (int i = 0; i < lParc.Count; i++)
                {
                    if (i < 12)
                    {
                        Danfe.Parametros_Relatorio.Add("DT_VENCTO" + i.ToString(), lParc[i].Dt_venctostring);
                        Danfe.Parametros_Relatorio.Add("VL_DUP" + i.ToString(), lParc[i].Vl_parcela_padrao);
                    }
                    else
                        break;
                }
            }
            //Verificar se existe logo configurada para a empresa
            object log = new CamadaDados.Diversos.TCD_CadEmpresa().BuscarEscalar(
                            new TpBusca[]
                                        {
                                            new TpBusca()
                                            {
                                                vNM_Campo = "a.cd_empresa",
                                                vOperador = "=",
                                                vVL_Busca = "'" + (bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_empresa.Trim() + "'"
                                            }
                                        }, "a.logoEmpresa");
            if (log != null)
                Danfe.Parametros_Relatorio.Add("IMAGEM_RELATORIO", log);
            Danfe.Gera_Relatorio();
        }


        private void afterPrint()
        {
            if (bsNotaFiscal.Current != null)
                if ((bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_modelo.Trim().Equals("55"))
                {
                    //Verificar o status de retorno da NF-e
                    object obj = new CamadaDados.Faturamento.NFE.TCD_LanLoteNFE_X_NotaFiscal().BuscarEscalar(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.cd_empresa",
                                            vOperador = "=",
                                            vVL_Busca = "'" + (bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_empresa.Trim() + "'"
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.nr_lanctofiscal",
                                            vOperador = "=",
                                            vVL_Busca = (bsNotaFiscal.Current as TRegistro_LanFaturamento).Nr_lanctofiscal.ToString()
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.Status",
                                            vOperador = "=",
                                            vVL_Busca = "'100'"
                                        }
                                    }, "1");
                    if (obj != null)
                    {
                        using (TFGerenciadorImpressao fImp = new TFGerenciadorImpressao())
                        {
                            fImp.St_enabled_enviaremail = true;
                            fImp.pCd_clifor = (bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_clifor;
                            fImp.pMensagem = "NF-e Nº " + (bsNotaFiscal.Current as TRegistro_LanFaturamento).Nr_notafiscal.ToString();
                            if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                                Imprime_Danfe();
                        }
                    }
                    else
                        MessageBox.Show("Permitido imprimir DANFE somente de NF-e aceita pela receita.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if ((bsNotaFiscal.Current as TRegistro_LanFaturamento).St_registro.Trim().ToUpper().Equals("C"))
                    {
                        MessageBox.Show("Não é permitido imprimir nota fiscal cancelada.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if ((bsNotaFiscal.Current as TRegistro_LanFaturamento).Tp_nota.Trim().ToUpper().Equals("T"))
                    {
                        MessageBox.Show("Não é permitido imprimir nota fiscal de terceiro.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    using (TFGerenciadorImpressao fImp = new TFGerenciadorImpressao())
                    {
                        fImp.St_enabled_enviaremail = true;
                        fImp.pCd_clifor = (bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_clifor;
                        fImp.pMensagem = "NOTA FISCAL Nº " + (bsNotaFiscal.Current as TRegistro_LanFaturamento).Nr_notafiscal.ToString();
                        if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                            Imprime_NotaFiscal(TCN_LanFaturamento.BuscarNF((bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_empresa,
                                                                           (bsNotaFiscal.Current as TRegistro_LanFaturamento).Nr_lanctofiscalstr,
                                                                           null),
                                               fImp.pSt_imprimir,
                                               fImp.pSt_visualizar,
                                               fImp.pSt_enviaremail,
                                               fImp.pDestinatarios,
                                               "NOTA FISCAL Nº " + (bsNotaFiscal.Current as TRegistro_LanFaturamento).Nr_notafiscal.ToString(),
                                               fImp.pDs_mensagem);
                    }
                }
        }
        private void Imprime_NotaFiscal(TRegistro_LanFaturamento rNf,
                                        bool St_imprimir,
                                        bool St_visualizar,
                                        bool St_enviaremail,
                                        List<string> Destinatarios,
                                        string Titulo,
                                        string Mensagem)
        {
            LayoutNotaFiscal Relatorio = new LayoutNotaFiscal();
            Relatorio.Imprime_NF(rNf,
                                St_imprimir,
                                St_visualizar,
                                St_enviaremail,
                                Destinatarios,
                                Titulo,
                                Mensagem);
        }

        private void bbFinalizar_Click2(object sender, EventArgs e)
        {

            if (bsOrcamento.Current as TRegistro_Orcamento != null)
            {
                if ((bsOrcamento.Current as TRegistro_Orcamento).lOrcProjeto.Count > 0)
                    if (((bsOrcamento.Current as TRegistro_Orcamento).lOrcProjeto[0] as TRegistro_OrcProjeto).lFicha.Count > 0)
                    {
                        if ((bsOrcamento.Current as TRegistro_Orcamento).St_registro.Equals("E"))
                        {
                            if (MessageBox.Show("Deseja Finalizar o projeto?", "Mensagem",
                                      MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                                      System.Windows.Forms.DialogResult.Yes)
                            {
                                //gravar registro finalizado
                                (bsOrcamento.Current as TRegistro_Orcamento).St_registro = "F";
                                TCN_Orcamento.Gravar((bsOrcamento.Current as TRegistro_Orcamento), null);


                                MessageBox.Show("Projeto finalizado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                st_finalizado.Checked = true;
                            }
                        }
                        else
                            MessageBox.Show("Pode finalizar apenas projeto em aprovado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                        MessageBox.Show("Deve incluir produtos para finalizar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    
            
            }
            else
                MessageBox.Show("Selecione um orcamento para finalizar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void nFServiçoToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (bsOrcamento.Current == null)
            {
                MessageBox.Show("Selecione um projeto!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            List<TRegistro_FichaTec> lficha = new List<TRegistro_FichaTec>();
            for (int i = 0; i < bsFicha.Count; i++)
            {
                lficha.Add((bsFicha[i] as TRegistro_FichaTec));
            }

            CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento rNf =
                       Proc_Commoditties.ProcessaEmpreendimento.ProcessarEmpreendimento("N",(bsOrcamento.Current as TRegistro_Orcamento).Cd_clifor,
                                                                                                         (bsOrcamento.Current as TRegistro_Orcamento),
                                                                                                         lficha);
            CamadaNegocio.Empreendimento.TCN_Orcamento.ProcessarNFEmpreendimento(rNf,null, bsOrcamento.Current as TRegistro_Orcamento, null);


            if (rNf.Tp_nota.Trim().ToUpper().Equals("P") && rNf.Cd_modelo.Trim().Equals("55"))
                if (MessageBox.Show("Deseja enviar NF-e para a receita agora?", "Pergunta", MessageBoxButtons.YesNo,
                     MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    //Verificar se é nota de produto ou mista
                    object obj = new CamadaDados.Faturamento.Cadastros.TCD_CadSerieNF().BuscarEscalar(
                                    new Utils.TpBusca[]
                                                {
                                                    new Utils.TpBusca()
                                                    {
                                                        vNM_Campo = "a.nr_serie",
                                                        vOperador = "=",
                                                        vVL_Busca = "'" + rNf.Nr_serie + "'"
                                                    }
                                                }, "a.tp_serie");
                    if (obj != null)
                        if (obj.ToString().Trim().ToUpper().Equals("P") ||
                            obj.ToString().Trim().ToUpper().Equals("M"))
                        {
                            try
                            {
                                using (srvNFE.TFGerenciarNFe fGerNfe = new srvNFE.TFGerenciarNFe())
                                {
                                    fGerNfe.rNfe = CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.BuscarNF(rNf.Cd_empresa,
                                                                                                                    rNf.Nr_lanctofiscalstr,
                                                                                                                    null);
                                    fGerNfe.ShowDialog();
                                }
                            }
                            catch (Exception ex)
                            { MessageBox.Show("Erro enviar NF-e: " + ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                        }
                        else if (obj.ToString().Trim().ToUpper().Equals("S"))
                        {
                            try
                            {
                                CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento rNfs =
                                    CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.BuscarNF(rNf.Cd_empresa,
                                                                                                     rNf.Nr_lanctofiscalstr,
                                                                                                     null);
                                NFES.TGerarRPS.CriarArquivoRPS(rNfs.rCfgNfe, new List<CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento>() { rNfs });
                                MessageBox.Show("NFS-e enviada com sucesso. Aguarde alguns segundos e consulte o status do lote.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            catch (Exception ex)
                            { MessageBox.Show("Erro enviar NFS-e: " + ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                        }
                }
            this.DialogResult = DialogResult.OK;

        }

        private void bsFicha_PositionChanged(object sender, EventArgs e){
       
        }

        private void bbNovaVersao_Click(object sender, EventArgs e)
        {
            if(bsOrcamento.Current != null)
                if (MessageBox.Show("Deseja gerar nova versão?", "Mensagem",
                                          MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                                          System.Windows.Forms.DialogResult.Yes)
                {
                
                    
                    gravarNovaVersao();
                
                
                }
        }

        private bool validaExcluir()
        {
            object a = new CamadaDados.Faturamento.NotaFiscal.TCD_LanFaturamento().BuscarEscalar(
                                    new TpBusca[]
                                { 
                                    new TpBusca()
                                    {
                                        vNM_Campo = string.Empty,
                                        vOperador = "exists",
                                        vVL_Busca = "(select 1 from TB_EMP_NFRemessa x "+
                                                    "where x.Nr_LanctoFiscal = a.Nr_LanctoFiscal "+
                                                    "and x.id_orcamento = "+(bsOrcamento.Current as TRegistro_Orcamento).Id_orcamentostr.ToString()+" "+
                                                    "and x.nr_versao = "+(bsOrcamento.Current as TRegistro_Orcamento).Nr_versaostr.ToString()+")"
                                    }
                                }, " COUNT(1) ");
            if(Convert.ToDecimal(a) > 0 )
                return true;
            else
                return false;
        }


        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

            if (st_produto_cadastrado())
                return;
            using (Cadastro.FFatDireto direto = new Cadastro.FFatDireto())
            {
                direto.vCD_Clifor = (bsOrcamento.Current as TRegistro_Orcamento).Cd_clifor;
                direto.vNr_Versao = (bsOrcamento.Current as TRegistro_Orcamento).Nr_versaostr;
                direto.vID_Orcamento = (bsOrcamento.Current as TRegistro_Orcamento).Id_orcamentostr;
                direto.vCD_Empresa = (bsOrcamento.Current as TRegistro_Orcamento).Cd_empresa;
                direto.ShowDialog();
                afterBusca();

            }
        }

        private void toolStripButton27_Click_2(object sender, EventArgs e)
        {

            if (st_produto_cadastrado())
                return;
            if (bsOrcamento.Current == null)
            {
                MessageBox.Show("Selecione um projeto!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            List<TRegistro_FichaTec> lficha = new List<TRegistro_FichaTec>();
            for (int i = 0; i < bsFicha.Count; i++)
            {
                lficha.Add((bsFicha[i] as TRegistro_FichaTec));
            }

            CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento rNf =
                       Proc_Commoditties.ProcessaEmpreendimento.ProcessarEmpreendimento("N",(bsOrcamento.Current as TRegistro_Orcamento).Cd_clifor,
                                                                                                         (bsOrcamento.Current as TRegistro_Orcamento),
                                                                                                         lficha);
            CamadaNegocio.Empreendimento.TCN_Orcamento.ProcessarNFEmpreendimento(rNf,null, bsOrcamento.Current as TRegistro_Orcamento, null);


            if (rNf.Tp_nota.Trim().ToUpper().Equals("P") && rNf.Cd_modelo.Trim().Equals("55"))
                if (MessageBox.Show("Deseja enviar NF-e para a receita agora?", "Pergunta", MessageBoxButtons.YesNo,
                     MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    //Verificar se é nota de produto ou mista
                    object obj = new CamadaDados.Faturamento.Cadastros.TCD_CadSerieNF().BuscarEscalar(
                                    new Utils.TpBusca[]
                                                {
                                                    new Utils.TpBusca()
                                                    {
                                                        vNM_Campo = "a.nr_serie",
                                                        vOperador = "=",
                                                        vVL_Busca = "'" + rNf.Nr_serie + "'"
                                                    }
                                                }, "a.tp_serie");
                    if (obj != null)
                        if (obj.ToString().Trim().ToUpper().Equals("P") ||
                            obj.ToString().Trim().ToUpper().Equals("M"))
                        {
                            try
                            {
                                using (srvNFE.TFGerenciarNFe fGerNfe = new srvNFE.TFGerenciarNFe())
                                {
                                    fGerNfe.rNfe = CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.BuscarNF(rNf.Cd_empresa,
                                                                                                                    rNf.Nr_lanctofiscalstr,
                                                                                                                    null);
                                    fGerNfe.ShowDialog();
                                }
                            }
                            catch (Exception ex)
                            { MessageBox.Show("Erro enviar NF-e: " + ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                        }
                        else if (obj.ToString().Trim().ToUpper().Equals("S"))
                        {
                            try
                            {
                                CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento rNfs =
                                    CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.BuscarNF(rNf.Cd_empresa,
                                                                                                     rNf.Nr_lanctofiscalstr,
                                                                                                     null);
                                NFES.TGerarRPS.CriarArquivoRPS(rNfs.rCfgNfe, new List<CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento>() { rNfs });
                                MessageBox.Show("NFS-e enviada com sucesso. Aguarde alguns segundos e consulte o status do lote.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            catch (Exception ex)
                            { MessageBox.Show("Erro enviar NFS-e: " + ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                        }
                }
            this.DialogResult = DialogResult.OK;

        }

        private void bsFatItemDireto_PositionChanged(object sender, EventArgs e)
        {
            
        }

        private void bsFatDireto_PositionChanged(object sender, EventArgs e)
        {
            if (bsFatDireto.Current != null)
            {
                bsFatItemDireto.DataSource = CamadaNegocio.Empreendimento.Cadastro.TCN_CadFatDiretoItem.Buscar(
                                                                                    (bsOrcamento.Current as TRegistro_Orcamento).Cd_empresa,
                                                                                    (bsOrcamento.Current as TRegistro_Orcamento).Id_orcamentostr,
                                                                                    string.Empty, //(bsOrcamento.Current as TRegistro_Orcamento).id_projeto,
                                                                                    (bsOrcamento.Current as TRegistro_Orcamento).Nr_versaostr,
                                                                                    (bsOrcamento.Current as TRegistro_Orcamento).Cd_clifor,
                                                                                    (bsFatDireto.Current as CamadaDados.Empreendimento.Cadastro.TRegistro_CadFatDireto).Id_faturamentostr,
                                                                                    string.Empty, string.Empty, string.Empty, string.Empty, null
                                                                                    );
                bsFatItemDireto.ResetCurrentItem();

            }
        }

        private void bbAddFicha_Click(object sender, EventArgs e)
        {
            if (bsOrcProjeto.Current != null && bsOrcamento.Current != null)
            {
                if (st_execucao.Checked)
                {
                    if (!CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin, "PERMITIR ADICIONAR EXECUCAO", null))
                        using (Proc_Commoditties.TFLanSessaoPDV fSessao = new Proc_Commoditties.TFLanSessaoPDV())
                        {
                            if (fSessao.ShowDialog() == DialogResult.OK)
                            {
                                if (!CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(fSessao.Usuario.Trim().ToUpper(), "PERMITIR ADICIONAR EXECUCAO", null))
                                {
                                    MessageBox.Show("Usuario não tem acesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                            }
                        }
                }
                using (TFFichaTec fFicha = new TFFichaTec())
                {
                    fFicha.pCd_empresa = (bsOrcProjeto.Current as TRegistro_OrcProjeto).Cd_empresa;
                    fFicha.pId_Orcamento = (bsOrcProjeto.Current as TRegistro_OrcProjeto).Id_orcamentostr;
                    fFicha.pId_projeto = (bsOrcProjeto.Current as TRegistro_OrcProjeto).Id_projetostr;
                    fFicha.pNr_Versao = (bsOrcProjeto.Current as TRegistro_OrcProjeto).Nr_versaostr;
                    fFicha.vId_atividade = (bsOrcProjeto.Current as TRegistro_OrcProjeto).Id_projetostr;
                    fFicha.vDs_atividade = (bsOrcProjeto.Current as TRegistro_OrcProjeto).Ds_projeto;
                    if (fFicha.ShowDialog() == DialogResult.OK)
                        try
                        {
                            if (!comparaTotais())
                            {
                                gravarNovaVersao();
                            }
                            fFicha.rFicha.Cd_empresa = (bsOrcamento.Current as TRegistro_Orcamento).Cd_empresa;
                            fFicha.rFicha.Id_orcamento = (bsOrcamento.Current as TRegistro_Orcamento).Id_orcamento;
                            fFicha.rFicha.Nr_versao = (bsOrcamento.Current as TRegistro_Orcamento).Nr_versao;
                            fFicha.rFicha.Id_projeto = (bsOrcProjeto.Current as TRegistro_OrcProjeto).Id_projeto;
                            
                            TCN_FichaTec.Gravar(fFicha.rFicha, null);
                            bsOrcProjeto_PositionChanged(this, new EventArgs());
                            bsFicha.Position = bsFicha.Count - 1;
                            bsFicha.ResetBindings(true);
                            afterBusca();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            }
            else MessageBox.Show("Obrigatório selecionar PROJETO para incluir FICHA.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        
        }

        private void bbCorrigirFicha_Click(object sender, EventArgs e)
        {

            if (bsFicha.Current != null)
                using (TFFichaTec fFicha = new TFFichaTec())
                {
                    fFicha.pCd_empresa = (bsOrcamento.Current as TRegistro_Orcamento).Cd_empresa;
                    fFicha.pId_Ficha = (bsFicha.Current as TRegistro_FichaTec).Id_fichastr;
                    fFicha.pId_Orcamento = (bsOrcamento.Current as TRegistro_Orcamento).Id_orcamentostr;
                    fFicha.pId_projeto = (bsOrcProjeto.Current as TRegistro_OrcProjeto).Id_projetostr;
                    fFicha.pNr_Versao = (bsOrcamento.Current as TRegistro_Orcamento).Nr_versaostr;
                    (bsFicha.Current as TRegistro_FichaTec).lfichaItens = TCN_FichaItens.Buscar((bsOrcProjeto.Current as TRegistro_OrcProjeto).Cd_empresa,
                                                                                     (bsOrcProjeto.Current as TRegistro_OrcProjeto).Id_orcamentostr,
                                                                                     (bsOrcProjeto.Current as TRegistro_OrcProjeto).Nr_versaostr,
                                                                                     (bsOrcProjeto.Current as TRegistro_OrcProjeto).Id_projetostr,
                                                                                     (bsFicha.Current as TRegistro_FichaTec).Id_fichastr,
                                                                                     string.Empty, null);
                    fFicha.rFicha = (bsFicha.Current as TRegistro_FichaTec);
                    if (fFicha.ShowDialog() == DialogResult.OK)
                        try
                        {

                            if (!comparaTotais())
                            {
                                gravarNovaVersao();
                            }
                            fFicha.rFicha.Cd_empresa = (bsOrcamento.Current as TRegistro_Orcamento).Cd_empresa;
                            fFicha.rFicha.Id_orcamento = (bsOrcamento.Current as TRegistro_Orcamento).Id_orcamento;
                            fFicha.rFicha.Nr_versao = (bsOrcamento.Current as TRegistro_Orcamento).Nr_versao;
                            fFicha.rFicha.Id_projeto = (bsOrcProjeto.Current as TRegistro_OrcProjeto).Id_projeto;

                            TCN_FichaTec.Gravar(fFicha.rFicha, null);
                            bsOrcProjeto_PositionChanged(this, new EventArgs());
                            afterBusca();

                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            else MessageBox.Show("Obrigatório selecionar PROJETO para incluir FICHA.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        
        }

        private void bbExcluirFicha_Click(object sender, EventArgs e)
        {

            if (bsFicha.Current as TRegistro_FichaTec != null)
            {
                if (MessageBox.Show("Deseja Realmente Excluir o item?", "Mensagem",
                       MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    object a = new TCD_FichaItens().BuscarEscalar(new TpBusca[]{
                                                                        new TpBusca(){
                                                                            vNM_Campo = "a.cd_empresa",
                                                                            vOperador = "=",
                                                                            vVL_Busca = (bsFicha.Current as TRegistro_FichaTec).Cd_empresa
                                                                        },
                                                                        new TpBusca(){
                                                                            vNM_Campo = "a.id_projeto",
                                                                            vOperador = "=",
                                                                            vVL_Busca = (bsFicha.Current as TRegistro_FichaTec).Id_projetostr
                                                                        },
                                                                        new TpBusca(){
                                                                            vNM_Campo = "a.nr_versao",
                                                                            vOperador = "=",
                                                                            vVL_Busca = (bsFicha.Current as TRegistro_FichaTec).Nr_versaostr
                                                                        },
                                                                        new TpBusca(){
                                                                            vNM_Campo = "a.id_orcamento",
                                                                            vOperador = "=",
                                                                            vVL_Busca = (bsFicha.Current as TRegistro_FichaTec).Id_orcamentostr
                                                                        },
                                                                        new TpBusca(){
                                                                            vNM_Campo = "a.id_ficha",
                                                                            vOperador = "=",
                                                                            vVL_Busca = (bsFicha.Current as TRegistro_FichaTec).Id_fichastr
                                                                        }}, "COUNT(1)");


                    if (Convert.ToDecimal(a) <= 0)
                    {
                        if (!comparaTotais())
                        {
                            gravarNovaVersao();
                        }
                        (bsFicha.Current as TRegistro_FichaTec).lfichaItens = TCN_FichaItens.Buscar((bsFicha.Current as TRegistro_FichaTec).Cd_empresa,
                                                                                         (bsFicha.Current as TRegistro_FichaTec).Id_orcamentostr,
                                                                                         (bsFicha.Current as TRegistro_FichaTec).Nr_versaostr,
                                                                                         (bsFicha.Current as TRegistro_FichaTec).Id_projetostr,
                                                                                         string.Empty,
                                                                                         string.Empty, null);
                        TCN_FichaTec.Excluir((bsFicha.Current as TRegistro_FichaTec), null);
                        MessageBox.Show("Item excluido com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        afterBusca();
                    }
                    else
                        MessageBox.Show("Não pode excluir item faturado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
                MessageBox.Show("Selecione uma ficha.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        
        }

        private void BB_Novo_Click(object sender, EventArgs e)
        {
            if (st_projeto.Checked)
            {
                MessageBox.Show("Ops não pode adicionar orcamento pelo menu projeto.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
                using (TFOrcamento fOrc = new TFOrcamento())
                {
                    id_orcamento.Text = string.Empty;
                    st_orcamento.Checked = true;
                    if (fOrc.ShowDialog() == DialogResult.OK)
                        if (fOrc.rOrcamento != null)
                            try
                            {
                                if (comparaTotais())
                                {
                                    fOrc.rOrcamento.Id_orcamento = decimal.Zero;
                                    fOrc.rOrcamento.Id_orcamentostr = string.Empty;
                                    fOrc.rOrcamento.St_registro = "A";
                                    TCN_Orcamento.Gravar(fOrc.rOrcamento, null);
                                }
                                else
                                    gravarNovaVersao();
                                //id_orcamento.Text = !string.IsNullOrEmpty(fOrc.rOrcamento.id_orc)? fOrc.rOrcamento.id_orc : fOrc.rOrcamento.Id_orcamentostr ;
                                MessageBox.Show("Orcamento adicionado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                this.afterBusca();
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }

                }
        }

        private void BB_Alterar_Click(object sender, EventArgs e)
        {

            if (bsOrcamento.Current != null)
                using (TFOrcamento fOrc = new TFOrcamento())
                {
                    fOrc.rOrcamento = bsOrcamento.Current as TRegistro_Orcamento;
                    if (fOrc.ShowDialog() == DialogResult.OK)
                    {

                        (bsOrcamento.DataSource as TList_Orcamento).Remove((bsOrcamento.Current as TRegistro_Orcamento));
                        (bsOrcamento.DataSource as TList_Orcamento).Add(fOrc.rOrcamento);
                    }
                    try
                    {
                        if (comparaTotais())
                            TCN_Orcamento.Gravar(fOrc.rOrcamento, null);
                        else
                            gravarNovaVersao();
                        //id_orcamento.Text = !string.IsNullOrEmpty(fOrc.rOrcamento.id_orc)? fOrc.rOrcamento.id_orc : fOrc.rOrcamento.Id_orcamentostr;
                        MessageBox.Show("Orçamento corrigido com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.afterBusca();
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            else MessageBox.Show("Obrigatório selecionar orçamento para corrigir.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BB_Excluir_Click(object sender, EventArgs e)
        {
            if (bsOrcamento.Current as TRegistro_Orcamento != null)
            {
                validaExcluir();

                if (MessageBox.Show("Deseja Realmente Excluir o orcamento ?", "Mensagem",
                          MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                          System.Windows.Forms.DialogResult.Yes)
                {
                    (bsOrcamento.Current as TRegistro_Orcamento).St_registro = "C";
                    TCN_Orcamento.Gravar((bsOrcamento.Current as TRegistro_Orcamento), null);
                    MessageBox.Show("Orcamento excluido com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
                MessageBox.Show("Selecione um Orcamento.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void bbDuplicata_Click(object sender, EventArgs e)
        {
            if (bsDespesas.Current != null)
            {
                object ex = new CamadaDados.Empreendimento.TCD_ExecDespesas().BuscarEscalar(new TpBusca[]{
                                                                                                new TpBusca(){
                                                                                                    vNM_Campo = "a.id_despesa",
                                                                                                    vOperador= "=",
                                                                                                    vVL_Busca = (bsDespesas.Current as TRegistro_Despesas).Id_despesa.ToString()
                                                                                                },
                                                                                                new TpBusca(){
                                                                                                    vNM_Campo = "b.id_orcamento",
                                                                                                    vOperador = "=",
                                                                                                    vVL_Busca = (bsDespesas.Current as TRegistro_Despesas).Id_orcamento.ToString()
                                                                                                }, 
                                                                                                new TpBusca(){
                                                                                                    vNM_Campo = "b.nr_versao",
                                                                                                    vOperador = "=",
                                                                                                    vVL_Busca = (bsDespesas.Current as TRegistro_Despesas).Nr_versaostr
                                                                                                }}, "1");
                if (ex == null)
                    using (Empreendimento.FGerarDuplicata ferar = new FGerarDuplicata())
                    {
                        ferar.rDespesa = (bsDespesas.Current as TRegistro_Despesas);
                        ferar.vVl_Doc = (bsDespesas.Current as TRegistro_Despesas).Vl_subtotal;
                        ferar.ShowDialog();

                    }



            }
            else
            {
                MessageBox.Show("Despesa não há saldo.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }


        }

        private void gFicha_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if(st_execucao.Checked)
            if (e.Value != null)
                if (e.ColumnIndex == 0)
                {
                    if (e.Value.ToString().Trim().ToUpper().Equals(""))
                    {
                        DataGridViewRow linha = gFicha.Rows[e.RowIndex];
                        linha.DefaultCellStyle.ForeColor = Color.Red;
                    }
                    else
                    {
                        DataGridViewRow linha = gFicha.Rows[e.RowIndex];
                        linha.DefaultCellStyle.ForeColor = Color.Black;
                    }
                }
                

        }

        private void bbNovoProduto_Click(object sender, EventArgs e)
        {
            if (bsFicha.Current != null)
            {
                if (string.IsNullOrEmpty((bsFicha.Current as TRegistro_FichaTec).Cd_produto))
                {

                    using (Proc_Commoditties.TFAtualizaCadProduto fProd = new Proc_Commoditties.TFAtualizaCadProduto())
                    {
                        CamadaDados.Estoque.Cadastros.TRegistro_CadProduto rproduto = new CamadaDados.Estoque.Cadastros.TRegistro_CadProduto();
                        rproduto.DS_Produto = (bsFicha.Current as TRegistro_FichaTec).Ds_produto;
                        fProd.rProd = rproduto;
                        fProd.Cd_empresa = (bsFicha.Current as TRegistro_FichaTec).Cd_empresa;

                        if (fProd.ShowDialog() == DialogResult.OK)
                            if (fProd.rProd != null)
                                try
                                {
                                    CamadaNegocio.Estoque.Cadastros.TCN_CadProduto.Gravar(fProd.rProd, null);
                                    MessageBox.Show("Produto gravado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    //Buscar registro produto
                                    (bsFicha.Current as TRegistro_FichaTec).Cd_produto = fProd.rProd.CD_Produto;
                                    TCN_FichaTec.Gravar((bsFicha.Current as TRegistro_FichaTec), null);
                                    bsFicha.ResetCurrentItem();
                                    bsOrcProjeto_PositionChanged(this, new EventArgs());
                                }
                                catch (Exception ex)
                                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    }
                }
                else MessageBox.Show("Produto já cadastrado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            } else MessageBox.Show("Selecione uma ficha.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    
        }

        private void tot_resultado_ValueChanged(object sender, EventArgs e)
        {

        }

        private void toolStripButton40_Click_1(object sender, EventArgs e)
        {

        }

        private void cd_vendedor_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
