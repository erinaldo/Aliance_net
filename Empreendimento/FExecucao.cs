using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using CamadaDados.Empreendimento;
using CamadaDados.Empreendimento.Cadastro;
using CamadaNegocio.Empreendimento;

namespace Empreendimento
{
    public partial class FExecucao : Form
    {
        private TRegistro_Orcamento cOrcamento;
        public TRegistro_Orcamento rOrcamento
        {
            get
            {
                return bsOrcamento.Current as TRegistro_Orcamento;
            }
            set
            {
                cOrcamento = value;
            }
        }

        private TRegistro_CadCFGEmpreendimento rCFG;
        public TRegistro_CadCFGEmpreendimento cCFG
        {
            set { rCFG = value; }
            get { return bsCFGEmpreendimento.Current as TRegistro_CadCFGEmpreendimento; }
        }

        public FExecucao()
        {
            InitializeComponent();
        }
        
        private void bbAddProjeto_Click(object sender, EventArgs e)
        {
            using (Cadastro.FAtividades atv = new Cadastro.FAtividades())
            {
                int i = 0;
                TList_CadAtividade lista = new TList_CadAtividade();
                (bsOrcamento.Current as TRegistro_Orcamento).lOrcProjeto.ForEach(p =>
                {

                    TRegistro_CadAtividade a = new TRegistro_CadAtividade();
                    a.Ds_atividade = p.Ds_projeto;
                    if (p.Id_projeto > i)
                        i = Convert.ToInt32(p.Id_projeto);
                    lista.Add(a);
                });
                atv.rLAtividade = lista;
                if (atv.ShowDialog() == DialogResult.OK)
                {
                    atv.rLAtividade.ForEach(p =>
                    {
                        if (p.st_agregar)
                        {
                            i++;
                            TRegistro_OrcProjeto orc = new TRegistro_OrcProjeto();
                            orc.Id_orcamentostr = (bsOrcamento.Current as TRegistro_Orcamento).Id_orcamentostr;
                            orc.Nr_versaostr = (bsOrcamento.Current as TRegistro_Orcamento).Nr_versaostr;
                            orc.Id_projeto = i;
                            orc.Ds_projeto = p.Ds_atividade;
                            orc.lFicha = null;
                            bsAtividade.Add(orc);
                        }
                    });
                    MessageBox.Show("Atividade Adicionada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void bbCorrigirProjeto_Click(object sender, EventArgs e)
        {
            using (TFOrcProjeto fOrc = new TFOrcProjeto())
            {
                TRegistro_OrcProjeto copia = (TRegistro_OrcProjeto)(bsAtividade.Current as TRegistro_OrcProjeto).Clone();
                fOrc.rOrc = bsAtividade.Current as TRegistro_OrcProjeto;
                if (fOrc.ShowDialog() != DialogResult.OK)
                {
                    int position = bsAtividade.Position;
                    bsAtividade.RemoveCurrent();
                    bsAtividade.Insert(position, copia);
                    bsOrcamento.ResetCurrentItem();
                    MessageBox.Show("Atividade corrigida com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void bbExcluirProjeto_Click(object sender, EventArgs e)
        {
            if (bsAtividade.Current != null)
                if (MessageBox.Show("Confirma exclusão da atividade selecionada?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                     MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    if ((bsAtividade.Current as TRegistro_OrcProjeto).Id_projeto.HasValue)
                        (bsOrcamento.Current as TRegistro_Orcamento).lOrcProjetoDel.Add(bsAtividade.Current as TRegistro_OrcProjeto);
                    bsAtividade.RemoveCurrent();
                    MessageBox.Show("Atividade foi removida com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
        }

        private void bbAddFicha_Click(object sender, EventArgs e)
        {
                if (bsAtividade.Current != null)
                    using (TFFichaTec fFicha = new TFFichaTec())
                    {
                        fFicha.pCd_empresa = (bsOrcamento.Current as TRegistro_Orcamento).Cd_empresa;
                        fFicha.pCd_tabelapreco = (bsCFGEmpreendimento.Current as TRegistro_CadCFGEmpreendimento).Cd_tabelapreco;
                        if (fFicha.ShowDialog() == DialogResult.OK)
                            if (fFicha.rFicha != null)
                            {
                                (bsAtividade.Current as TRegistro_OrcProjeto).lFicha.Add(fFicha.rFicha);
                                bsAtividade.ResetCurrentItem();
                                MessageBox.Show("Ficha técnica adicionada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                    }
                else MessageBox.Show("Obrigatório selecionar atividade.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void bbCorrigirFicha_Click(object sender, EventArgs e)
        {
            if (bsFichaTec.Current != null)
                using (TFFichaTec fFicha = new TFFichaTec())
                {
                    if ((bsFichaTec.Current as TRegistro_FichaTec).lfichaItens.Count <= 0)
                        if ((bsFichaTec.Current as TRegistro_FichaTec).st_composto.Equals("S"))
                        {
                            if ((bsFichaTec.Current as TRegistro_FichaTec).lfichaItens.Count <= 0)
                            {
                                (bsFichaTec.Current as TRegistro_FichaTec).lfichaItens.Clear();
                                if ((bsFichaTec.Current as TRegistro_FichaTec).lfichaItens != null)
                                    (bsFichaTec.Current as TRegistro_FichaTec).lfichaItens = TCN_FichaItens.Buscar((bsFichaTec.Current as TRegistro_FichaTec).Cd_empresa,
                                                                    (bsFichaTec.Current as TRegistro_FichaTec).Id_orcamentostr, (bsFichaTec.Current as TRegistro_FichaTec).Nr_versaostr,
                                                                    (bsFichaTec.Current as TRegistro_FichaTec).Id_projetostr, (bsFichaTec.Current as TRegistro_FichaTec).Id_fichastr,
                                                                    string.Empty, null);
                            }
                            if ((bsFichaTec.Current as TRegistro_FichaTec).lfichaItens.Count <= 0)
                            {
                                CamadaDados.Estoque.Cadastros.TList_FichaTecProduto lFichaitens = CamadaNegocio.Estoque.Cadastros.TCN_FichaTecProduto.Buscar((bsFichaTec.Current as TRegistro_FichaTec).Cd_produto, string.Empty, null);
                                lFichaitens.ForEach(iten =>
                                {
                                    TRegistro_FichaItens item = new TRegistro_FichaItens();
                                    item.Cd_itemstr = iten.Cd_item;
                                    item.ds_item = iten.Ds_item;
                                    item.quantidade = iten.Quantidade;
                                    item.vl_unitario = iten.Vl_custoservico;
                                    item.vl_subtotal = iten.Vl_subtotalservico;
                                    (bsFichaTec.Current as TRegistro_FichaTec).lfichaItens.Add(item);
                                });
                            }
                        }
                    fFicha.rFicha = bsFichaTec.Current as TRegistro_FichaTec;
                    fFicha.pCd_empresa = (bsOrcamento.Current as TRegistro_Orcamento).Cd_empresa;
                    if (fFicha.ShowDialog() == DialogResult.OK)
                    {
                        int position = bsFichaTec.Position;
                        bsFichaTec.RemoveCurrent();
                        bsFichaTec.Insert(position, fFicha.rFicha);
                        MessageBox.Show("Ficha técinica adicionada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
        }

        private void bbExcluirFicha_Click(object sender, EventArgs e)
        {
            if (bsFichaTec.Current != null)
                if (MessageBox.Show("Confirma exclusão ficha selecionada?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                     MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    if ((bsFichaTec.Current as TRegistro_FichaTec).Id_ficha.HasValue)
                        (bsAtividade.Current as TRegistro_OrcProjeto).lFichaDel.Add(bsFichaTec.Current as TRegistro_FichaTec);
                    bsFichaTec.RemoveCurrent();
                    MessageBox.Show("Ficha técnica removida com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (bsDespesas.Current != null)
                using (TFLanDespesa desp = new TFLanDespesa())
                {
                    desp.rDespesa = (bsDespesas.Current as TRegistro_Despesas);
                    if (desp.ShowDialog() == DialogResult.OK)
                    {
                        (bsDespesas.Current as TRegistro_Despesas).Quantidade = Math.Round(desp.rDespesa.Quantidade, 2, MidpointRounding.AwayFromZero); ;
                        (bsDespesas.Current as TRegistro_Despesas).Vl_unitario = Math.Round(desp.rDespesa.Vl_unitario, 2, MidpointRounding.AwayFromZero);
                        (bsDespesas.Current as TRegistro_Despesas).Vl_subtotal = Math.Round(desp.rDespesa.Vl_subtotal, 2, MidpointRounding.AwayFromZero);
                        bsDespesas.ResetCurrentItem();
                        MessageBox.Show("Despesa corrigida com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
        }

        private void bbExcluirDesp_Click(object sender, EventArgs e)
        {
            if (bsDespesas.Current != null)
                if (MessageBox.Show("Confirma exclusão da despesa selecionada?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                     MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    if ((bsDespesas.Current as TRegistro_Despesas).Id_despesa.HasValue)
                        (bsOrcamento.Current as TRegistro_Orcamento).lDespesasDel.Add(bsDespesas.Current as TRegistro_Despesas);
                    bsDespesas.RemoveCurrent();
                    MessageBox.Show("Despesa removida com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
        }

        private void bbaddmaoobra_Click(object sender, EventArgs e)
        {
            using (Cadastro.FCadMaoObra fMaoObra = new Cadastro.FCadMaoObra())
            {
                fMaoObra.vCd_Empresa = (bsOrcamento.Current as TRegistro_Orcamento).Cd_empresa;
                if (fMaoObra.ShowDialog() == DialogResult.OK)
                    if (fMaoObra.rMaoObra != null)
                    {
                        fMaoObra.rMaoObra.Id_MaoObra = (bsMaoObra.Count + 1);
                        bsMaoObra.Add(fMaoObra.rMaoObra);
                        bsMaoObra.ResetCurrentItem();
                        MessageBox.Show("Mão de obra adicionada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
            }
        }

        private void bbCorMaoobra_Click(object sender, EventArgs e)
        {
            if (bsMaoObra.Current != null)
                using (Cadastro.FCadMaoObra fMaoObra = new Cadastro.FCadMaoObra())
                {
                    fMaoObra.vCd_Empresa = (bsOrcamento.Current as TRegistro_Orcamento).Cd_empresa;
                    fMaoObra.rMaoObra = (bsMaoObra.Current as TRegistro_CadMaoObra);
                    if (fMaoObra.ShowDialog() == DialogResult.OK)
                    {
                        if (fMaoObra.rMaoObra != null)
                        {
                            (bsMaoObra.Current as TRegistro_CadMaoObra).cargahorariaMes = fMaoObra.rMaoObra.cargahorariaMes;
                            (bsMaoObra.Current as TRegistro_CadMaoObra).ds_cargo = fMaoObra.rMaoObra.ds_cargo;
                            (bsMaoObra.Current as TRegistro_CadMaoObra).ds_unidade = fMaoObra.rMaoObra.ds_unidade;
                            (bsMaoObra.Current as TRegistro_CadMaoObra).Id_cargo = fMaoObra.rMaoObra.Id_cargo;
                            (bsMaoObra.Current as TRegistro_CadMaoObra).Id_unidadestr = fMaoObra.rMaoObra.Id_unidadestr;
                            (bsMaoObra.Current as TRegistro_CadMaoObra).qtd_horascinco = fMaoObra.rMaoObra.qtd_horascinco;
                            (bsMaoObra.Current as TRegistro_CadMaoObra).qtd_horascen = fMaoObra.rMaoObra.qtd_horascen;
                            (bsMaoObra.Current as TRegistro_CadMaoObra).qtd_pessoas = fMaoObra.rMaoObra.qtd_pessoas;
                            (bsMaoObra.Current as TRegistro_CadMaoObra).qtd_adNoturno = fMaoObra.rMaoObra.qtd_adNoturno;
                            (bsMaoObra.Current as TRegistro_CadMaoObra).Quantidade = Math.Round(fMaoObra.rMaoObra.Quantidade, 2, MidpointRounding.AwayFromZero);
                            (bsMaoObra.Current as TRegistro_CadMaoObra).vl_subtotal = Math.Round(fMaoObra.rMaoObra.vl_subtotal, 2, MidpointRounding.AwayFromZero);
                            (bsMaoObra.Current as TRegistro_CadMaoObra).vl_unitario = Math.Round(fMaoObra.rMaoObra.vl_unitario, 2, MidpointRounding.AwayFromZero);

                            bsMaoObra.ResetCurrentItem();
                        }
                        MessageBox.Show("Mão de obra corrigida com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            else
                MessageBox.Show("Selecione uma mão de obra.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void bbExclurmaoobra_Click(object sender, EventArgs e)
        {
            if (bsMaoObra.Current != null)
                if (MessageBox.Show("Confirma exclusão da mão de obra selecionada?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                     MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    if ((bsMaoObra.Current as CamadaDados.Empreendimento.Cadastro.TRegistro_CadMaoObra).Id_cargo.HasValue)
                        (bsOrcamento.Current as TRegistro_Orcamento).lMaoObraDel.Add(bsMaoObra.Current as CamadaDados.Empreendimento.Cadastro.TRegistro_CadMaoObra);
                    bsMaoObra.RemoveCurrent();
                    MessageBox.Show("Mão de obra removida com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
        }

        private void bbEncargoimportar_Click(object sender, EventArgs e)
        {
            using (Cadastro.FFolha folha = new Cadastro.FFolha())
            {
                if (bsEncargo.Count > 0)
                {
                    List<TRegistro_CadEncargosFolha> lencargo = new List<TRegistro_CadEncargosFolha>();
                    (bsEncargo.List as List<TRegistro_OrcamentoEncargo>).ForEach(p =>
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
                            bsEncargo.Add(oe);
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
                    MessageBox.Show("Encargos corrigidos com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            if (bsEncargo.Current != null)
                if (MessageBox.Show("Confirma exclusão do encargo selecionada?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                     MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    if ((bsEncargo.Current as TRegistro_OrcamentoEncargo).Id_encargo.HasValue)
                        (bsOrcamento.Current as TRegistro_Orcamento).lOEncargoDel.Add(bsEncargo.Current as TRegistro_OrcamentoEncargo);
                    bsEncargo.Remove(bsEncargo.Current);
                    MessageBox.Show("Encargo removida com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
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
                        bsTarefas.Add(rtarefa);
                        bsTarefas.ResetCurrentItem();
                    }
                    MessageBox.Show("Tarefa adicionada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
        }

        private void bbImportar_Click(object sender, EventArgs e)
        {
            if (bsOrcamento.Current != null)
            {
                string id_orcamento = string.Empty;
                using (TFConsultaProjetos cProjetos = new TFConsultaProjetos())
                {
                    if (cProjetos.ShowDialog() == DialogResult.OK)
                    {
                        TList_Orcamento lorcamento = new TList_Orcamento();
                        TList_Orcamento lprojeto2 = new TList_Orcamento();
                        lorcamento = cProjetos.lOrc;
                        lorcamento.ForEach(o => {

                            o.lDespesas.Where(p => p.st_importar).ToList().ForEach(p =>
                            {
                                p.Id_orcamentostr = (bsOrcamento.Current as TRegistro_Orcamento).Id_orcamentostr;
                                p.Nr_versaostr = (bsOrcamento.Current as TRegistro_Orcamento).Nr_versaostr;
                                p.Id_RegDesp = (bsDespesas.Count) + 1;
                                bsDespesas.Add(p);
                            });
                            o.lOEncargo.Where(p => p.st_importar).ToList().ForEach(p =>
                            {
                                p.Id_orcamentostr = (bsOrcamento.Current as TRegistro_Orcamento).Id_orcamentostr;
                                p.Nr_versaostr = (bsOrcamento.Current as TRegistro_Orcamento).Nr_versaostr;
                                p.vl_encargo = decimal.Zero;
                                bsEncargo.Add(p);
                            });
                            o.lMaoObra.Where(p => p.st_importar).ToList().ForEach(p =>
                            {
                                p.Id_orcamentostr = (bsOrcamento.Current as TRegistro_Orcamento).Id_orcamentostr;
                                p.Nr_versaostr = (bsOrcamento.Current as TRegistro_Orcamento).Nr_versaostr;
                                p.Id_MaoObra = (bsMaoObra).Count + 1;
                                bsMaoObra.Add(p);
                            });
                            o.lOrcProjeto.Where(p => p.st_importar).ToList().ForEach(p =>
                            {
                                TList_FichaTec lista = new TList_FichaTec();
                                p.lFicha.Where(i => i.st_agregar).ToList().ForEach(i =>
                                {
                                    i.Quantidade = i.quantidade_agregar;
                                    i.quantidade_agregar = decimal.Zero;
                                    i.Id_ficha = decimal.Zero;
                                    i.Id_orcamentostr = (bsOrcamento.Current as TRegistro_Orcamento).Id_orcamentostr;
                                    i.Id_projetostr = string.Empty;
                                    i.Nr_versaostr = (bsOrcamento.Current as TRegistro_Orcamento).Nr_versaostr;
                                    i.Vl_subtotal = i.Vl_unitario * i.Quantidade;
                                    if (i.st_composto.Equals("S"))
                                    {
                                        CamadaDados.Estoque.Cadastros.TList_FichaTecProduto lFichaitens = CamadaNegocio.Estoque.Cadastros.TCN_FichaTecProduto.Buscar(i.Cd_produto, string.Empty, null);
                                        lFichaitens.ForEach(iten =>
                                        {
                                            TRegistro_FichaItens item = new TRegistro_FichaItens();
                                            item.Cd_itemstr = iten.Cd_item;
                                            item.ds_item = iten.Ds_item;
                                            item.quantidade = iten.Quantidade;
                                            item.vl_unitario = iten.Vl_custoservico;
                                            item.vl_subtotal = iten.Vl_subtotalservico;
                                            i.lfichaItens.Add(item);
                                        });

                                    }

                                    lista.Add(i);
                                });

                                p.Id_orcamentostr = (bsOrcamento.Current as TRegistro_Orcamento).Id_orcamentostr;
                                p.Id_projeto = (bsAtividade).Count + 1;
                                p.Nr_versaostr = (bsOrcamento.Current as TRegistro_Orcamento).Nr_versaostr;
                                p.lFicha = lista;
                                bsAtividade.Add(p);

                                bsAtividade.ResetCurrentItem();

                            });
                        });
                        bsAtividade.Position = bsAtividade.Count - 1;
                        MessageBox.Show("Importado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
                MessageBox.Show("Selecione um Orcamento.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja gravar o orçamento?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                if (bsCFGEmpreendimento.Current != null)
                {
                    (bsOrcamento.Current as TRegistro_Orcamento).Pc_cofins = (bsCFGEmpreendimento.Current as TRegistro_CadCFGEmpreendimento).Pc_Cofins;
                    (bsOrcamento.Current as TRegistro_Orcamento).Pc_pis = (bsCFGEmpreendimento.Current as TRegistro_CadCFGEmpreendimento).Pc_PIS;
                    (bsOrcamento.Current as TRegistro_Orcamento).Pc_margemcont = (bsCFGEmpreendimento.Current as TRegistro_CadCFGEmpreendimento).Pc_margemcont;
                    (bsOrcamento.Current as TRegistro_Orcamento).Pc_irpj = (bsCFGEmpreendimento.Current as TRegistro_CadCFGEmpreendimento).Pc_IRPJ;
                    (bsOrcamento.Current as TRegistro_Orcamento).Pc_csll = (bsCFGEmpreendimento.Current as TRegistro_CadCFGEmpreendimento).Pc_CSLL;
                }
                bool grava = true;
                string mensagem = string.Empty;
                (bsOrcamento.Current as TRegistro_Orcamento).lDespesas.ForEach(de =>
                {
                    if (de.Vl_subtotal == decimal.Zero)
                    {
                        mensagem = "Existe despesa com valor zerado.";
                        grava = false;
                    }
                });
                (bsOrcamento.Current as TRegistro_Orcamento).lMaoObra.ForEach(de =>
                {
                    if (de.vl_subtotal == decimal.Zero)
                    {
                        mensagem = "Existe Mão de obra com valor zerado.";
                        grava = false;
                    }
                });
                if ((bsOrcamento.Current as TRegistro_Orcamento).lOrcProjeto.Count <= 0)
                {
                    MessageBox.Show("Obrigatório ter atividade.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    grava = false;
                }
            (bsAtividade.Current as TRegistro_OrcProjeto).lFicha.ForEach(de =>
            {
                if (de.Vl_subtotal == decimal.Zero)
                {
                    mensagem = "Exister ficha tecnica com valor zerado.";
                    grava = false;
                }
            });
                if (grava)
                    DialogResult = DialogResult.OK;
                else
                    MessageBox.Show(mensagem, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
