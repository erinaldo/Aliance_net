using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using CamadaDados.Diversos;
using CamadaDados.Empreendimento;
using CamadaDados.Empreendimento.Cadastro;
using CamadaNegocio.Empreendimento;
using CamadaNegocio.Empreendimento.Cadastro;
using Utils;
using System.Runtime.InteropServices;
using Microsoft.CSharp;

namespace Empreendimento
{
    public partial class TFLan_EvoluirOrcamento : Form
    {
        private bool st_importar = false;
        private string label = "Orçamento";
        public bool projetista { get; set; } = false;
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
        private TList_CadCFGEmpreendimento registro_CadCFG;

        private bool St_editando = true;
        private int position = 0;
        private string Cd_tabelapreco = string.Empty;

        public TFLan_EvoluirOrcamento()
        {
            InitializeComponent();
            bsAtividade.DataSource = bsOrcamento;
            bsAtividade.DataMember = "lOrcProjeto";
            bsFichaTec.DataSource = bsAtividade;
            bsFichaTec.DataMember = "lFicha";
            bsDespesas.DataSource = bsOrcamento;
            bsDespesas.DataMember = "lDespesas";
        }

        private void HabilitarBotoes()
        {

            bbAddProjeto.Visible = St_editando;
            bbCorrigirProjeto.Visible = St_editando;
            bbExcluirProjeto.Visible = St_editando;
            bbAddFicha.Visible = St_editando;
            bbCorrigirFicha.Visible = St_editando;
            bbExcluirFicha.Visible = St_editando;
            bbExcluirDesp.Visible = St_editando;
            //bbAdicionarDesp.Visible = St_editando;
            bbaddmaoobra.Visible = St_editando;
            bbCorMaoobra.Visible = St_editando;
            bbExclurmaoobra.Visible = St_editando;
            bbEncargoimportar.Visible = St_editando;
            gOrcamento.Enabled = !St_editando;
        }

        private void buscatb()
        {
            object obj = new TCD_CadCFGEmpreendimento().BuscarEscalar(
                                    new TpBusca[]
                                    {
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.cd_empresa",
                                        vOperador = "=",
                                        vVL_Busca = "'" +(bsOrcamento.Current as TRegistro_Orcamento).Cd_empresa + "'"
                                    }
                                    }, "a.cd_tabelapreco");
            Cd_tabelapreco = obj == null ? string.Empty : obj.ToString();

        }

        private void afterBusca()
        {

            buscatb();

            bsOrcamento.DataSource = TCN_Orcamento.Buscar((bsOrcamento.Current as TRegistro_Orcamento).Cd_empresa,
                                                          cOrcamento.Id_orcamentostr,
                                                          cOrcamento.Nr_versaostr,
                                                          string.Empty,
                                                          string.Empty,
                                                          string.Empty,
                                                          string.Empty,
                                                          string.Empty,
                                                          "'A'",
                                                          null);
            bsOrcamento_PositionChanged(this, new EventArgs());
            if (bsOrcamento.Current != null)
                bsCFGEmpreendimento.DataSource = TCN_CadCFGEmpreendimento.Busca((bsOrcamento.Current as TRegistro_Orcamento).Cd_empresa, string.Empty, null);
            bsCFGEmpreendimento.ResetCurrentItem();
            if (bsCFGEmpreendimento.Count <= 0)
                bsCFGEmpreendimento.AddNew();
        }

        private void calculatotal()
        {
            if (bsOrcamento.Current != null)
            {
                decimal total = decimal.Zero;
                decimal totaldir = decimal.Zero;
                decimal totalpro = decimal.Zero;
                (bsOrcamento.Current as TRegistro_Orcamento).lOrcProjeto.ForEach(p =>
                {
                    p.lFicha.ForEach(o =>
                    {
                        total += o.Vl_subtotal;
                        if (o.St_fatdiretobool)
                            totaldir += o.Vl_subtotal;
                        else
                            totalpro += o.Vl_subtotal;

                    });
                });
                totalfatdireto.Value = totaldir;
                totalfatproprio.Value = totalpro;
                vltotal.Value = total;
            }

        }

        private void TFLan_EvoluirOrcamento_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;

            if (cOrcamento != null)
            {
                bsOrcamento.DataSource = new TList_Orcamento() { cOrcamento };
                bsOrcamento.ResetCurrentItem();
                St_editando = true;
                if (bsOrcamento.Count == 0)
                    this.afterBusca();
            }
            buscatb();
            this.HabilitarBotoes();
            if ((bsOrcamento.Current as TRegistro_Orcamento).St_registro.Equals("T")
                && (CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Parametros.pubLogin, "VISAO PROJETISTA", null)))
            {
                projetista = true;

                //dataGridDefault4.Columns[3].Visible = false;
                //dataGridDefault4.Columns[4].Visible = false;
                //dataGridDefault4.Columns[5].Visible = false;
            }

            if ((bsOrcamento.Current as TRegistro_Orcamento).St_registro.Equals("T") || (bsOrcamento.Current as TRegistro_Orcamento).St_registro.Equals("J"))
            {
                bnprojetobt.Visible = false;
                tcOrcamento.TabPages.Remove(tpDespesa);
                tcOrcamento.TabPages.Remove(tpMaoObra);
                tcOrcamento.TabPages.Remove(tbEncargos);
                //tcOrcamento.TabPages.Remove(tbTarefa);
            }
            calculatotal();

            if (projetista)
            {
                this.Text = "Evoluir Projeto";
                this.label = "Projeto";

            }
            if (bsMaoObra.Count > 0)
                validaencargos();

            //Totalizador do orçamento
            if (bsOrcamento.Current != null && (bsOrcamento.Current as TRegistro_Orcamento).Id_orc != null)
            {
                tot_vlOrcado.Visible = true;
                TpBusca[] tps = new TpBusca[0];
                Estruturas.CriarParametro(ref tps, "a.id_orcamento", (bsOrcamento.Current as TRegistro_Orcamento).Id_orc.ToString());
                object vl = new TCD_Orcamento().BuscarEscalar(tps, "a.Vl_Orcamento");
                tot_vlOrcado.Text += vl == null ? "" : Convert.ToDecimal(vl).ToString("N2", new System.Globalization.CultureInfo("pt-BR"));
            }

            registro_CadCFG = TCN_CadCFGEmpreendimento.Busca(string.Empty, string.Empty, null);
            if (registro_CadCFG.Count.Equals(0))
            {
                MessageBox.Show("Necessário ter pré-cadastrado configuração empreendimento", "Informativo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.Abort;
            }
            else if (registro_CadCFG[0].Cd_tabelapreco == null || string.IsNullOrEmpty(registro_CadCFG[0].Cd_tabelapreco))
            {
                MessageBox.Show("Necessário ter pré-cadastrado tabela de preço na configuração do empreendimento", "Informativo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.Abort;
            }
        }

        private void calculaunidades()
        {

            decimal valor = decimal.Zero;

            CamadaDados.Estoque.Cadastros.TList_CadUnidade unidade = CamadaNegocio.Estoque.Cadastros.TCN_CadUnidade.Busca(string.Empty, "HORAS", string.Empty, null);

            if (unidade.Count > 0)
                (bsOrcamento.Current as TRegistro_Orcamento).lMaoObra.ForEach(p =>
                {
                    if (!string.IsNullOrEmpty(p.Id_unidadestr))
                    {
                        valor = CamadaNegocio.Estoque.Cadastros.TCN_CadConvUnidade.ConvertUnid(p.Id_unidadestr, unidade[0].CD_Unidade, Math.Round(p.vl_unitario, 2, MidpointRounding.AwayFromZero), 2, null);
                        p.vl_horas100 = decimal.Multiply(valor, 2);
                        p.vl_horas50 = decimal.Multiply(valor, Convert.ToDecimal("1,5"));
                        p.vl_horas20 = decimal.Multiply(valor, Convert.ToDecimal("1,2"));
                    }
                });

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
                //Buscar requisitos
                (bsOrcamento.Current as TRegistro_Orcamento).lRequisitos =
                    TCN_RequisitoORc.Buscar(string.Empty,
                                          (bsOrcamento.Current as TRegistro_Orcamento).Cd_empresa,
                                          (bsOrcamento.Current as TRegistro_Orcamento).Id_orcamentostr,
                                          (bsOrcamento.Current as TRegistro_Orcamento).Nr_versaostr,
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
                    CamadaNegocio.Empreendimento.Cadastro.TCN_CadMaoObra.Busca(
                                        (bsOrcamento.Current as TRegistro_Orcamento).Id_orcamentostr,
                                        (bsOrcamento.Current as TRegistro_Orcamento).Nr_versaostr,
                                        (bsOrcamento.Current as TRegistro_Orcamento).Cd_empresa,
                                        string.Empty,
                                        null);
                calculaunidades();


                //Buscar encargos
                (bsOrcamento.Current as TRegistro_Orcamento).lOEncargo =
                    CamadaNegocio.Empreendimento.Cadastro.TCN_OrcamentoEncargo.Buscar(
                                        string.Empty,
                                        (bsOrcamento.Current as TRegistro_Orcamento).Cd_empresa,
                                        (bsOrcamento.Current as TRegistro_Orcamento).Nr_versaostr,
                                        (bsOrcamento.Current as TRegistro_Orcamento).Id_orcamentostr,
                                        null);
                // preenche itens
                (bsOrcamento.Current as TRegistro_Orcamento).lOrcProjeto.ForEach(p =>
                {
                    p.lFicha = TCN_FichaTec.Buscar(p.Cd_empresa,
                                                p.Id_orcamentostr,
                                                p.Nr_versaostr,
                                                p.Id_projetostr,
                                                p.Id_registrostr,
                                                string.Empty,
                                                null);
                });

                bsAtividade_PositionChanged(this, new EventArgs());
                bsOrcamento.ResetCurrentItem();
            }
        }

        private void bsAtividade_PositionChanged(object sender, EventArgs e)
        {
            if (bsAtividade.Current != null)
            {
                if (!st_importar)
                    if ((bsAtividade.Current as TRegistro_OrcProjeto).lFicha != null)
                        if ((bsAtividade.Current as TRegistro_OrcProjeto).lFicha.Count <= 0)
                        {
                            if (!string.IsNullOrEmpty((bsAtividade.Current as TRegistro_OrcProjeto).Id_orcamentostr)
                                && !string.IsNullOrEmpty((bsAtividade.Current as TRegistro_OrcProjeto).Nr_versaostr))
                                (bsAtividade.Current as TRegistro_OrcProjeto).lFicha =
                                    TCN_FichaTec.Buscar((bsAtividade.Current as TRegistro_OrcProjeto).Cd_empresa,
                                                        (bsAtividade.Current as TRegistro_OrcProjeto).Id_orcamentostr,
                                                        (bsAtividade.Current as TRegistro_OrcProjeto).Nr_versaostr,
                                                        (bsAtividade.Current as TRegistro_OrcProjeto).Id_projetostr,
                                                        (bsAtividade.Current as TRegistro_OrcProjeto).Id_registrostr,
                                                        string.Empty,
                                                        null);
                        }
                //if ((bsAtividade.Current as TRegistro_OrcProjeto).lRequisitos.Count <= 0)
                //{
                //if (!string.IsNullOrEmpty((bsAtividade.Current as TRegistro_OrcProjeto).Id_orcamentostr)
                //    && !string.IsNullOrEmpty((bsAtividade.Current as TRegistro_OrcProjeto).Nr_versaostr))
                //    (bsAtividade.Current as TRegistro_OrcProjeto).lRequisitos = TCN_Requisitos.Buscar((bsAtividade.Current as TRegistro_OrcProjeto).Id_projetostr,
                //                                                     string.Empty,
                //                                                     (bsAtividade.Current as TRegistro_OrcProjeto).Cd_empresa,
                //                                                     (bsAtividade.Current as TRegistro_OrcProjeto).Id_orcamentostr,
                //                                                     (bsAtividade.Current as TRegistro_OrcProjeto).Nr_versaostr,
                //                                                     (bsAtividade.Current as TRegistro_OrcProjeto).Id_registrostr,
                //                                                     null);
                ////}
                //bsRequisito.ResetCurrentItem();
            }
        }

        private void bbAtualizar_Click(object sender, EventArgs e)
        {
            this.afterBusca();
        }

        private void bbSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((bsOrcamento.Current as TRegistro_Orcamento) != null)
            {
                object obj = new TCD_CadCFGEmpreendimento().BuscarEscalar(
                                new TpBusca[]
                                {
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.cd_empresa",
                                        vOperador = "=",
                                        vVL_Busca = "'" +(bsOrcamento.Current as TRegistro_Orcamento).Cd_empresa + "'"
                                    }
                                }, "a.cd_tabelapreco");
                Cd_tabelapreco = obj == null ? string.Empty : obj.ToString();
                this.afterBusca();
            }
        }

        private void bbEditar_Click(object sender, EventArgs e)
        {
            if (bsOrcamento.Current != null)
            {
                St_editando = true;
                position = bsOrcamento.Position;
                HabilitarBotoes();


                //Incluir Despesas Padrão
                if ((bsOrcamento.Current as TRegistro_Orcamento).lDespesas.Count.Equals(0))
                {
                    TCN_CadDespesa.Busca(string.Empty, string.Empty, null).ForEach(p =>
                    (bsOrcamento.Current as TRegistro_Orcamento).lDespesas.Add(
                        new TRegistro_Despesas()
                        {
                            Id_despesa = p.Id_despesa,
                            Ds_despesa = p.Ds_despesa,
                            Cd_unidade = p.Cd_unidade,
                            Ds_unidade = p.Ds_unidade,
                            Sigla_unidade = p.Sigla_unidade
                        }));
                    bsOrcamento.ResetCurrentItem();
                }
            }
            else MessageBox.Show("Obrigatório selecionar orçamento para EDITAR.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void bbCancelar_Click(object sender, EventArgs e)
        {
            St_editando = false;
            HabilitarBotoes();
            afterBusca();
        }

        private void bbAddProjeto_Click(object sender, EventArgs e)
        {
            if (St_editando)
                using (Cadastro.FAtividades atv = new Cadastro.FAtividades())
                {
                    int i = 0;
                    CamadaDados.Empreendimento.Cadastro.TList_CadAtividade lista = new CamadaDados.Empreendimento.Cadastro.TList_CadAtividade();
                    (bsOrcamento.Current as TRegistro_Orcamento).lOrcProjeto.ForEach(p =>
                    {

                        TRegistro_CadAtividade a = new TRegistro_CadAtividade();
                        a.Ds_atividade = p.Ds_projeto;
                        if (p.Id_registro > i)
                            i = Convert.ToInt32(p.Id_registro);
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
                                //orc.Id_orcamentostr = (bsOrcamento.Current as TRegistro_Orcamento).Id_orcamentostr;
                                //orc.Nr_versaostr = (bsOrcamento.Current as TRegistro_Orcamento).Nr_versaostr;
                                orc.Id_projeto = p.Id_atividade;
                                orc.Id_registro = i;
                                orc.Ds_projeto = p.Ds_atividade;
                                orc.lFicha = new TList_FichaTec();
                                //p.lRequisitos.ForEach(or =>
                                //{
                                //    TRegistro_Requisitos req = new TRegistro_Requisitos();
                                //    req.ds_requisito = or.ds_requisito;
                                //    req.id_requisito = or.id_requisito;
                                //    req.Id_orcamento = (bsOrcamento.Current as TRegistro_Orcamento).Id_orcamento;
                                //    req.id_atividade = orc.Id_projetostr;
                                //    req.Id_registro = orc.Id_registro;
                                //    orc.lRequisitos.Add(req);
                                //});

                                bsAtividade.Add(orc);
                            }
                        });
                        bsAtividade.Position = bsAtividade.Count;
                        //  MessageBox.Show("Atividade Adicionada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        bsAtividade.ResetBindings(true);

                    }


                }

            //using (TFOrcProjeto fOrc = new TFOrcProjeto())
            //{
            //    if(fOrc.ShowDialog() == DialogResult.OK)
            //        if(fOrc.rOrc != null)
            //        {
            //            bsAtividade.Add(fOrc.rOrc);
            //        }
            //}
        }

        private void bbCorrigirProjeto_Click(object sender, EventArgs e)
        {
            if (St_editando)
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
                        //  MessageBox.Show("Atividade corrigida com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }
        }

        private void bbExcluirProjeto_Click(object sender, EventArgs e)
        {
            if (St_editando)
            {
                if (bsAtividade.Current != null)
                {
                    //Verificar se itens ficha já foram executadas
                    if (new CamadaDados.Empreendimento.TCD_RemessaNf().BuscarEscalar(
                        new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = "a.cd_empresa",
                                vOperador = "=",
                                vVL_Busca = "'" + (bsAtividade.Current as TRegistro_OrcProjeto).Cd_empresa.Trim() + "'"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "a.ID_Orcamento",
                                vOperador = "=",
                                vVL_Busca = (bsAtividade.Current as TRegistro_OrcProjeto).Id_orcamentostr
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "a.NR_Versao",
                                vOperador = "=",
                                vVL_Busca = (bsAtividade.Current as TRegistro_OrcProjeto).Nr_versaostr
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "a.id_atividade",
                                vOperador = "=",
                                vVL_Busca = (bsAtividade.Current as TRegistro_OrcProjeto).Id_projetostr
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "a.ID_Registro",
                                vOperador = "=",
                                vVL_Busca = (bsAtividade.Current as TRegistro_OrcProjeto).Id_registrostr
                            }
                        }, "1") != null)
                    {
                        MessageBox.Show("Não é possivel excluir atividade que possuem remessa!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if (MessageBox.Show("Confirma exclusão da atividade selecionada?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                         MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        if ((bsAtividade.Current as TRegistro_OrcProjeto).Id_projeto.HasValue)
                            (bsOrcamento.Current as TRegistro_Orcamento).lOrcProjetoDel.Add(bsAtividade.Current as TRegistro_OrcProjeto);
                        bsAtividade.RemoveCurrent();
                        //   MessageBox.Show("Atividade foi removida com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }
            }
        }

        private void bbAddFicha_Click(object sender, EventArgs e)
        {
            if (St_editando)
                if (bsAtividade.Current != null)
                    using (TFFichaTec fFicha = new TFFichaTec())
                    {
                        fFicha.pCd_empresa = (bsOrcamento.Current as TRegistro_Orcamento).Cd_empresa;
                        fFicha.pCd_tabelapreco = Cd_tabelapreco;
                        fFicha.projetista = projetista;
                        fFicha.vId_atividade = (bsAtividade.Current as TRegistro_OrcProjeto).Id_projetostr;
                        fFicha.vDs_atividade = (bsAtividade.Current as TRegistro_OrcProjeto).Ds_projeto;
                        if (fFicha.ShowDialog() == DialogResult.OK)
                        {
                            if (fFicha.lFicha != null && fFicha.lFicha.Count > 0)
                            {
                                (bsAtividade.Current as TRegistro_OrcProjeto).lFicha.AddRange(fFicha.lFicha);
                                bsAtividade.ResetCurrentItem();
                            }
                            else if (fFicha.rFicha != null)
                            {
                                TList_FichaTec l = new TList_FichaTec();
                                l.Add(fFicha.rFicha);

                                (bsAtividade.Current as TRegistro_OrcProjeto).lFicha.ForEach(p =>
                                {
                                    l.Add(p);
                                });
                                (bsAtividade.Current as TRegistro_OrcProjeto).lFicha = l;
                                bsAtividade.ResetCurrentItem();
                            }
                        }
                            
                    }
                else MessageBox.Show("Obrigatório selecionar atividade.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            calculatotal();
        }

        private void bbCorrigirFicha_Click(object sender, EventArgs e)
        {
            if (St_editando)
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

                        fFicha.projetista = projetista;
                        fFicha.rFicha = bsFichaTec.Current as TRegistro_FichaTec;
                        fFicha.pCd_tabelapreco = Cd_tabelapreco;
                        fFicha.pCd_empresa = (bsOrcamento.Current as TRegistro_Orcamento).Cd_empresa;
                        if (fFicha.ShowDialog() == DialogResult.OK)
                        {
                            int position = bsFichaTec.Position;
                            bsFichaTec.RemoveCurrent();
                            bsFichaTec.Insert(position, fFicha.rFicha);
                        }

                    }
            calculatotal();
        }

        private void bbExcluirFicha_Click(object sender, EventArgs e)
        {
            if (St_editando)
            {
                if (bsFichaTec.Current != null)
                {
                    //Verificar se mao de obra já foi executada
                    if (new CamadaDados.Empreendimento.TCD_RemessaNf().BuscarEscalar(
                        new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = "a.cd_empresa",
                                vOperador = "=",
                                vVL_Busca = "'" + (bsFichaTec.Current as TRegistro_FichaTec).Cd_empresa.Trim() + "'"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "a.ID_Orcamento",
                                vOperador = "=",
                                vVL_Busca = (bsFichaTec.Current as TRegistro_FichaTec).Id_orcamentostr
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "a.NR_Versao",
                                vOperador = "=",
                                vVL_Busca = (bsFichaTec.Current as TRegistro_FichaTec).Nr_versaostr
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "a.id_atividade",
                                vOperador = "=",
                                vVL_Busca = (bsFichaTec.Current as TRegistro_FichaTec).Id_projetostr
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "a.ID_Registro",
                                vOperador = "=",
                                vVL_Busca = (bsFichaTec.Current as TRegistro_FichaTec).Id_registrostr
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "a.ID_Ficha",
                                vOperador = "=",
                                vVL_Busca = (bsFichaTec.Current as TRegistro_FichaTec).Id_fichastr
                            }
                        }, "1") != null)
                    {
                        MessageBox.Show("Não é possivel excluir Itens que possuem remessa!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if (MessageBox.Show("Confirma exclusão ficha selecionada?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                         MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        if ((bsFichaTec.Current as TRegistro_FichaTec).Id_ficha.HasValue)
                            (bsAtividade.Current as TRegistro_OrcProjeto).lFichaDel.Add(bsFichaTec.Current as TRegistro_FichaTec);
                        bsFichaTec.RemoveCurrent();
                        //    MessageBox.Show("Ficha técnica removida com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }
            }
        }

        private void bbAdicionardespesa_Click(object sender, EventArgs e)
        {
            if (St_editando)
                using (TFLanDespesa fDespesa = new TFLanDespesa())
                {
                    if (fDespesa.ShowDialog() == DialogResult.OK)
                        if (fDespesa.rDespesa != null)
                        {
                            fDespesa.rDespesa.Vl_unitario = Math.Round(fDespesa.rDespesa.Vl_unitario, 2, MidpointRounding.AwayFromZero);
                            fDespesa.rDespesa.Vl_subtotal = Math.Round(fDespesa.rDespesa.Vl_subtotal, 2, MidpointRounding.AwayFromZero);

                            (bsOrcamento.Current as TRegistro_Orcamento).lDespesas.Add(fDespesa.rDespesa);
                            bsOrcamento.ResetCurrentItem();
                        }
                }
        }

        private void bbCorrigirDesp_Click(object sender, EventArgs e)
        {

        }

        private void bbExcluirDesp_Click(object sender, EventArgs e)
        {
            if (St_editando)
            {
                if (bsDespesas.Current != null)
                {
                    //Verificar se despesa já foi executada
                    if (new CamadaDados.Empreendimento.TCD_ExecDespesas().BuscarEscalar(
                            new TpBusca[]
                            {
                            new TpBusca()
                            {
                                vNM_Campo = "a.cd_empresa",
                                vOperador = "=",
                                vVL_Busca = "'" + (bsDespesas.Current as TRegistro_Despesas).Cd_empresa.Trim() + "'"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "a.ID_Orcamento",
                                vOperador = "=",
                                vVL_Busca = (bsDespesas.Current as TRegistro_Despesas).Id_orcamentostr
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "a.NR_Versao",
                                vOperador = "=",
                                vVL_Busca = (bsDespesas.Current as TRegistro_Despesas).Nr_versaostr
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "a.ID_RegDesp",
                                vOperador = "=",
                                vVL_Busca = (bsDespesas.Current as TRegistro_Despesas).Id_RegDespstr
                            }
                            }, "1") != null)
                    {
                        MessageBox.Show("Não é possivel excluir despesa que já foi executada!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if (MessageBox.Show("Confirma exclusão da despesa selecionada?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                         MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        if ((bsDespesas.Current as TRegistro_Despesas).Id_despesa.HasValue)
                            (bsOrcamento.Current as TRegistro_Orcamento).lDespesasDel.Add(bsDespesas.Current as TRegistro_Despesas);
                        bsDespesas.RemoveCurrent();
                        //  MessageBox.Show("Despesa removida com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }
            }
        }

        private void bbSalvar_Click(object sender, EventArgs e)
        {
            if (St_editando)
                try
                {
                    if (bsCFGEmpreendimento.Current != null)
                    {
                        (bsOrcamento.Current as TRegistro_Orcamento).Pc_cofins = (bsCFGEmpreendimento.Current as TRegistro_CadCFGEmpreendimento).Pc_Cofins;
                        (bsOrcamento.Current as TRegistro_Orcamento).Pc_pis = (bsCFGEmpreendimento.Current as TRegistro_CadCFGEmpreendimento).Pc_PIS;
                        (bsOrcamento.Current as TRegistro_Orcamento).Pc_margemcont = (bsCFGEmpreendimento.Current as TRegistro_CadCFGEmpreendimento).Pc_margemcont;
                        (bsOrcamento.Current as TRegistro_Orcamento).Pc_irpj = (bsCFGEmpreendimento.Current as TRegistro_CadCFGEmpreendimento).Pc_IRPJ;
                        (bsOrcamento.Current as TRegistro_Orcamento).Pc_csll = (bsCFGEmpreendimento.Current as TRegistro_CadCFGEmpreendimento).Pc_CSLL;
                    }
                    TCN_Orcamento.Evoluir(bsOrcamento.Current as TRegistro_Orcamento, null);
                    MessageBox.Show("Orçamento gravado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    St_editando = false;
                    HabilitarBotoes();
                    this.afterBusca();
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void bbEvoluir_Click(object sender, EventArgs e)
        {
            if (!St_editando)
                if (bsOrcamento.Current != null)
                {
                    if ((bsOrcamento.Current as TRegistro_Orcamento).lDespesas.Exists(p => p.Vl_subtotal.Equals(decimal.Zero)))
                    {
                        MessageBox.Show("Não é permitido processar orçamento com despesas sem valor.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if (MessageBox.Show("Confirma evolução do orçamento selecionado?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                         MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                        try
                        {
                            (bsOrcamento.Current as TRegistro_Orcamento).St_registro = "H";
                            TCN_Orcamento.Gravar(bsOrcamento.Current as TRegistro_Orcamento, null);
                            MessageBox.Show("Orçamento evoluido com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            afterBusca();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
                else MessageBox.Show("Obrigatório selecionar orçamento para evoluir.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

            if (St_editando)
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
                        // MessageBox.Show("Tarefa adicionada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }


        }

        private void validaencargos()
        {
            string encargos = string.Empty;
            int i = 0;

            TpBusca[] filtro = new TpBusca[0];




            if (bsEncargo.Count > 0)
            {
                (bsEncargo.List as TList_OrcamentoEncargo).ForEach(p =>
                {
                    encargos += "( a.id_encargo <> " + p.Id_encargostr + " )";
                    if (bsEncargo.Count > i + 1 && bsEncargo.Count > 0)
                        encargos += " and ";
                    i++;
                });
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vVL_Busca = encargos;
            }
            CamadaDados.Empreendimento.Cadastro.TList_CadEncargosFolha newEncargos = new TCD_CadEncargosFolha().Select(
                filtro, 0, string.Empty);
            newEncargos.ForEach(p =>
            {
                TRegistro_OrcamentoEncargo item = new TRegistro_OrcamentoEncargo();
                item.Cd_empresa = Convert.ToDecimal((bsOrcamento.Current as TRegistro_Orcamento).Cd_empresa);
                item.Id_encargostr = p.Id_encargostr;
                item.ds_encargo = p.Ds_encargo;
                item.Id_orcamentostr = (bsOrcamento.Current as TRegistro_Orcamento).Id_orcamentostr;
                item.Nr_versaostr = (bsOrcamento.Current as TRegistro_Orcamento).Nr_versaostr;
                item.pc_encargo = p.Pc_encargo;
                bsEncargo.Add(item);
            });


        }

        private void bbaddmaoobra_Click(object sender, EventArgs e)
        {
            using (Empreendimento.Cadastro.FCadMaoObra fMaoObra = new Cadastro.FCadMaoObra())
            {
                fMaoObra.vCd_Empresa = (bsOrcamento.Current as TRegistro_Orcamento).Cd_empresa;
                if (fMaoObra.ShowDialog() == DialogResult.OK)
                    if (fMaoObra.rMaoObra != null)
                    {
                        fMaoObra.rMaoObra.Id_MaoObra = (bsMaoObra.Count + 1);
                        bsMaoObra.Add(fMaoObra.rMaoObra);


                        calculaunidades();
                        validaencargos();
                        bsMaoObra.ResetCurrentItem();
                        //MessageBox.Show("Mão de obra adicionada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }


            }
        }

        private void bbCorMaoobra_Click(object sender, EventArgs e)
        {
            if (bsMaoObra.Current != null)
                using (Empreendimento.Cadastro.FCadMaoObra fMaoObra = new Cadastro.FCadMaoObra())
                {
                    fMaoObra.vCd_Empresa = (bsOrcamento.Current as TRegistro_Orcamento).Cd_empresa;
                    fMaoObra.rMaoObra = (bsMaoObra.Current as CamadaDados.Empreendimento.Cadastro.TRegistro_CadMaoObra);
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
                        //   MessageBox.Show("Mão de obra corrigida com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }
            else
                MessageBox.Show("Selecione uma mão de obra.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void bbExclurmaoobra_Click(object sender, EventArgs e)
        {
            if (St_editando)
            {
                if (bsMaoObra.Current != null)
                {
                    //Verificar se mao de obra já foi executada
                    if (new CamadaDados.Empreendimento.Cadastro.TCD_ExecCadMaoObra().BuscarEscalar(
                            new TpBusca[]
                            {
                            new TpBusca()
                            {
                                vNM_Campo = "a.cd_empresa",
                                vOperador = "=",
                                vVL_Busca = "'" + (bsMaoObra.Current as CamadaDados.Empreendimento.Cadastro.TRegistro_CadMaoObra).Id_empresastr.Trim() + "'"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "a.ID_Orcamento",
                                vOperador = "=",
                                vVL_Busca = (bsMaoObra.Current as CamadaDados.Empreendimento.Cadastro.TRegistro_CadMaoObra).Id_orcamentostr
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "a.NR_Versao",
                                vOperador = "=",
                                vVL_Busca = (bsMaoObra.Current as CamadaDados.Empreendimento.Cadastro.TRegistro_CadMaoObra).Nr_versaostr
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "a.ID_Registro",
                                vOperador = "=",
                                vVL_Busca = (bsMaoObra.Current as CamadaDados.Empreendimento.Cadastro.TRegistro_CadMaoObra).Id_MaoObratr
                            }
                            }, "1") != null)
                    {
                        MessageBox.Show("Não é possivel excluir mão de obra que já foi executada!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if (MessageBox.Show("Confirma exclusão da mão de obra selecionada?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                         MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        if ((bsMaoObra.Current as CamadaDados.Empreendimento.Cadastro.TRegistro_CadMaoObra).Id_cargo.HasValue)
                            (bsOrcamento.Current as TRegistro_Orcamento).lMaoObraDel.Add(bsMaoObra.Current as CamadaDados.Empreendimento.Cadastro.TRegistro_CadMaoObra);
                        bsMaoObra.RemoveCurrent();
                        for (int i = 0; (bsOrcamento.Current as TRegistro_Orcamento).lMaoObra.Count > i; i++)
                            (bsOrcamento.Current as TRegistro_Orcamento).lMaoObra[i].Id_MaoObra = i + 1;
                        bsOrcamento.ResetCurrentItem();
                        //         MessageBox.Show("Mão de obra removida com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }
            }
        }

        private void bbEncargoimportar_Click(object sender, EventArgs e)
        {
            using (Empreendimento.Cadastro.FFolha folha = new Cadastro.FFolha())
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
                    //bsEncargo.Clear();
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
                    // MessageBox.Show("Encargos corrigidos com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }


            }
        }

        private void bbImportarProjeto_Click(object sender, EventArgs e)
        {

        }

        private void bbAdicionarDesp_Click(object sender, EventArgs e)
        {
            using (Cadastro.FDespesas desp = new Cadastro.FDespesas())
            {
                TList_CadDespesa lista = new TList_CadDespesa();
                (bsDespesas.List as TList_Despesas).ForEach(p =>
                {
                    TRegistro_CadDespesa a = new TRegistro_CadDespesa();
                    a.Id_despesastr = p.Id_despesastr;
                    a.Ds_despesa = p.Ds_despesa;
                    lista.Add(a);
                });


                desp.rLDespesa = lista;

                if (desp.ShowDialog() == DialogResult.OK)
                {
                    decimal id_desp = decimal.Zero;
                    (bsDespesas.List as TList_Despesas).ForEach(o =>
                    {
                        if (Convert.ToDecimal(o.Id_RegDesp) > id_desp)
                            id_desp = Convert.ToDecimal(o.Id_RegDesp);
                    });

                    if (desp.rLDespesa.Count > 0)
                        desp.rLDespesa.ForEach(p =>
                        {
                            if (p.st_agregar)
                            {
                                id_desp++;
                                TRegistro_Despesas des = new TRegistro_Despesas();
                                des.Ds_despesa = p.Ds_despesa;
                                if (cOrcamento.St_registro.Equals("E"))
                                    des.ST_AddExec = "S";
                                des.Id_RegDesp = id_desp;
                                des.Id_despesa = p.Id_despesa;
                                bsDespesas.Add(des);
                            }
                        });
                    //    MessageBox.Show("Despesa adicionada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja cancelar o " + label + "?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            { this.DialogResult = DialogResult.Cancel; }
        }

        private void TFLan_EvoluirOrcamento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                bb_inutilizar_Click(this, new EventArgs());
            if (e.KeyCode.Equals(Keys.F6))
                bb_cancelar_Click(this, new EventArgs());
            if (e.KeyCode.Equals(Keys.F10))
                bbImportarProjeto_Click(this, new EventArgs());
        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            if (bsDespesas.Current != null)
                using (Empreendimento.TFLanDespesa desp = new TFLanDespesa())
                {
                    desp.rDespesa = (bsDespesas.Current as TRegistro_Despesas);
                    if (desp.ShowDialog() == DialogResult.OK)
                    {
                        TRegistro_Despesas a = new TRegistro_Despesas();
                        a = desp.rDespesa;
                        a.Quantidade = Math.Round(a.Quantidade, 2, MidpointRounding.AwayFromZero); ;
                        a.Vl_unitario = Math.Round(a.Vl_unitario, 2, MidpointRounding.AwayFromZero);
                        a.Vl_subtotal = Math.Round(a.Vl_subtotal, 2, MidpointRounding.AwayFromZero);


                        int position = bsAtividade.Position;
                        bsDespesas.RemoveCurrent();
                        bsDespesas.Insert(position, a);
                        bsDespesas.ResetCurrentItem();
                        // MessageBox.Show("Despesa corrigida com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }
        }

        private void dataGridDefault3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
                if (bsFichaTec.Current != null)
                {
                    (bsFichaTec.Current as TRegistro_FichaTec).St_fatdiretobool = !(bsFichaTec.Current as TRegistro_FichaTec).St_fatdiretobool;
                }
        }

        private void dataGridDefault5_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int foco = e.ColumnIndex;
            if (bsDespesas.Current != null)
                using (Empreendimento.TFLanDespesa desp = new TFLanDespesa())
                {
                    desp.rDespesa = (bsDespesas.Current as TRegistro_Despesas);
                    desp.foco = foco;
                    if (desp.ShowDialog() == DialogResult.OK)
                    {
                        (bsDespesas.Current as TRegistro_Despesas).Quantidade = Math.Round(desp.rDespesa.Quantidade, 2, MidpointRounding.AwayFromZero); ;
                        (bsDespesas.Current as TRegistro_Despesas).Vl_unitario = Math.Round(desp.rDespesa.Vl_unitario, 2, MidpointRounding.AwayFromZero);
                        (bsDespesas.Current as TRegistro_Despesas).Vl_subtotal = Math.Round(desp.rDespesa.Vl_subtotal, 2, MidpointRounding.AwayFromZero);
                        bsDespesas.ResetCurrentItem();
                        // MessageBox.Show("Despesa corrigida com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }

        }

        private void dataGridDefault6_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            bbCorMaoobra_Click(this, new EventArgs());
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (St_editando)
                if (bsEncargo.Current != null)
                    if (MessageBox.Show("Confirma exclusão do encargo selecionada?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                         MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        if ((bsEncargo.Current as TRegistro_OrcamentoEncargo).Id_encargo.HasValue)
                            (bsOrcamento.Current as TRegistro_Orcamento).lOEncargoDel.Add(bsEncargo.Current as TRegistro_OrcamentoEncargo);
                        bsEncargo.Remove(bsEncargo.Current);
                    }
        }

        private void miNfNormal_Click(object sender, EventArgs e)
        {
            if ((bsOrcamento.Current as TRegistro_Orcamento).St_registro.Equals("E"))
            {
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
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if ((bsOrcamento.Current as TRegistro_Orcamento).St_registro.Equals("E"))
            {
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
        }

        private void toolStripButton27_Click(object sender, EventArgs e)
        {
            if ((bsOrcamento.Current as TRegistro_Orcamento).St_registro.Equals("E"))
            {
                List<TRegistro_FichaTec> lficha = new List<TRegistro_FichaTec>();
                for (int i = 0; i < bsFichaTec.Count; i++)
                {
                    lficha.Add((bsFichaTec[i] as TRegistro_FichaTec));
                }

                CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento rNf =
                           Proc_Commoditties.ProcessaEmpreendimento.ProcessarEmpreendimento("N", (bsOrcamento.Current as TRegistro_Orcamento).Cd_clifor,
                                                                                                             (bsOrcamento.Current as TRegistro_Orcamento),
                                                                                                             lficha);
                CamadaNegocio.Empreendimento.TCN_Orcamento.ProcessarNFEmpreendimento(rNf, null, bsOrcamento.Current as TRegistro_Orcamento, null);


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
                // this.DialogResult = DialogResult.OK;
            }
        }

        private void dataGridDefault3_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            bbCorrigirProjeto_Click(this, new EventArgs());
        }

        private void dataGridDefault4_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (bsFichaTec.Current == null)
                return;
            (bsFichaTec.Current as TRegistro_FichaTec).Vl_subtotal =
                (bsFichaTec.Current as TRegistro_FichaTec).Quantidade * (bsFichaTec.Current as TRegistro_FichaTec).Vl_unitario;

            calculatotal();
        }

        private void dataGridDefault4_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {

        }

        private void dataGridDefault4_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void gGrade_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 25)
            {
                if (CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin, "PERMITIR FATURAMENTO DIRETO", null))
                    (bsFichaTec.Current as TRegistro_FichaTec).St_fatdiretobool =
                    !(bsFichaTec.Current as TRegistro_FichaTec).St_fatdiretobool;
                calculatotal();
            }
        }

        private void bsDespesas_DataSourceChanged(object sender, EventArgs e)
        {
            despesaChanged();
        }

        private void despesaChanged()
        {
            try
            {
                totDespesas.Text = totDespesas.Tag.ToString() + " R$ ";
                totDespesas.Text += (bsDespesas.List as IEnumerable<TRegistro_Despesas>).ToList().Sum(r => r.Vl_subtotal).ToString("N2", new System.Globalization.CultureInfo("pt-BR"));
            }
            catch { }

        }

        private void bsMaoObra_DataSourceChanged(object sender, EventArgs e)
        {
            maoobraChanged();
        }

        private void maoobraChanged()
        {
            try
            {
                totMaoObra.Text = totMaoObra.Tag.ToString() + " R$ ";
                totMaoObra.Text += (bsMaoObra.List as IEnumerable<TRegistro_CadMaoObra>).ToList().Sum(r => r.vl_subtotal).ToString("N2", new System.Globalization.CultureInfo("pt-BR"));
            }
            catch { }

        }

        private void bsDespesas_ListChanged(object sender, ListChangedEventArgs e)
        {
            despesaChanged();
        }

        private void bsDespesas_PositionChanged(object sender, EventArgs e)
        {
            despesaChanged();

        }

        private void bsMaoObra_ListChanged(object sender, ListChangedEventArgs e)
        {
            maoobraChanged();
        }

        private void bsMaoObra_PositionChanged(object sender, EventArgs e)
        {
            maoobraChanged();
        }

        private void orçamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bsOrcamento.Current != null)
            {
                st_importar = true;
                string id_orcamento = string.Empty;
                using (TFConsultaProjetos cProjetos = new TFConsultaProjetos())
                {
                    // cProjetos.vId_orcamento = (bsOrcamento.Current as TRegistro_Orcamento).Id_orcamentostr;

                    if (cProjetos.ShowDialog() == DialogResult.OK)
                    {
                        if (MessageBox.Show("Ao importar algumas informações serão perdidas, deseja importar?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                           MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                        {

                            //pega id
                            decimal id_registro = decimal.Zero;
                            (bsOrcamento.Current as TRegistro_Orcamento).lOrcProjeto.ForEach(p =>
                            {
                                if (p.Id_registro > id_registro)
                                    id_registro = Convert.ToDecimal(p.Id_registro) + 1;
                            });


                            TList_Orcamento lorcamento = new TList_Orcamento();
                            TList_Orcamento lprojeto2 = new TList_Orcamento();
                            //bsDespesas.Clear();
                            // bsEncargo.Clear();

                            lorcamento = cProjetos.lOrc;


                            //remove items não selecionados

                            lorcamento.ForEach(o =>
                            {
                                o.lRequisitos.ForEach(p =>
                                {
                                    p.id_orcamento = Convert.ToDecimal((bsOrcamento.Current as TRegistro_Orcamento).Id_orcamentostr);
                                    p.nr_versao = Convert.ToDecimal((bsOrcamento.Current as TRegistro_Orcamento).Nr_versaostr);
                                    bsRequisitos.Add(p);

                                });

                                o.lDespesas.Where(p => p.st_importar).ToList().ForEach(p =>
                                {
                                    p.Id_orcamentostr = (bsOrcamento.Current as TRegistro_Orcamento).Id_orcamentostr;
                                    p.Nr_versaostr = (bsOrcamento.Current as TRegistro_Orcamento).Nr_versaostr;
                                    p.Id_RegDesp = (bsDespesas.Count) + 1;
                                    bsDespesas.Add(p);
                                });

                                bsDespesas.ResetCurrentItem();
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
                                    //TList_Requisitos requisitos = new TList_Requisitos();


                                    p.Id_registro = id_registro;
                                    p.Id_orcamentostr = (bsOrcamento.Current as TRegistro_Orcamento).Id_orcamentostr;
                                    p.Nr_versaostr = (bsOrcamento.Current as TRegistro_Orcamento).Nr_versaostr;


                                    p.lFicha.Where(i => i.st_agregar).ToList().ForEach(i =>
                                    {
                                        i.Quantidade = i.quantidade_agregar;
                                        i.quantidade_agregar = decimal.Zero;
                                        i.Id_ficha = decimal.Zero;
                                        i.Id_orcamentostr = (bsOrcamento.Current as TRegistro_Orcamento).Id_orcamentostr;
                                        i.Id_projetostr = p.Id_projetostr;
                                        i.Nr_versaostr = (bsOrcamento.Current as TRegistro_Orcamento).Nr_versaostr;
                                        i.Vl_subtotal = i.Vl_unitario * i.Quantidade;
                                        i.Id_registrostr = (bsOrcamento.Current as TRegistro_Orcamento).Id_registrostr;
                                        if (i.st_composto.Equals("S"))
                                        {
                                            i.lfichaItens = CamadaNegocio.Empreendimento.TCN_FichaItens.Buscar(i.Cd_empresa, i.Id_orcamentostr, i.Nr_versaostr, i.Id_projetostr, i.Cd_produto, string.Empty, null);

                                        }

                                        lista.Add(i);
                                    });


                                    p.lFicha = lista;
                                    // p.lRequisitos = requisitos;
                                    bsAtividade.Add(p);

                                    bsAtividade.ResetCurrentItem();

                                });
                            });
                            bsAtividade.Position = bsAtividade.Count - 1;
                            st_importar = false;
                            //   bsAtividade.ResetCurrentItem();


                            MessageBox.Show("Importado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    //afterBusca();
                }
            }
            else
                MessageBox.Show("Selecione um Orcamento.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void fichaTécnicaExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {

                string fname = "";
                OpenFileDialog fdlg = new OpenFileDialog();
                fdlg.Title = "Excel File Dialog";
                fdlg.InitialDirectory = @"c:\";
                fdlg.Filter = "Excel File (*.xlsx*)|*.xlsx*";
                fdlg.FilterIndex = 1;
                fdlg.RestoreDirectory = true;
                if (fdlg.ShowDialog() == DialogResult.OK)
                {
                    fname = fdlg.FileName;
                }

                Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(fname);
                Microsoft.Office.Interop.Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
                Microsoft.Office.Interop.Excel.Range xlRange = xlWorksheet.UsedRange;

                int rowCount = xlRange.Rows.Count;
                int colCount = xlRange.Columns.Count;

                if (colCount < 3)
                {
                    MessageBox.Show("Quantidade de colunas do documento informado é inferior a três. " +
                        "Informe código do produto da ficha, a quantidade e atividade referente ao produto.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                for (int i = 1; i <= rowCount; i++) //linha
                {
                    //validação do codigo produto
                    if (xlRange.Cells[i, 1] != null
                            && xlRange.Cells[i, 1].Value2 != null
                                && validaExistenciaProduto(xlRange.Cells[i, 1].Value2.ToString())

                                    //validação da quantidade
                                    && xlRange.Cells[i, 2] != null
                                        && xlRange.Cells[i, 2].Value2 != null
                                            && validaQuantidadeInformada(xlRange.Cells[i, 2].Value2.ToString())

                                                //validação da atividade
                                                && xlRange.Cells[i, 3] != null
                                                    && xlRange.Cells[i, 3].Value2 != null
                                                        && validaExistenciaAtividade(xlRange.Cells[i, 3].Value2.ToString()))
                    {
                        adicionarNoBindingSource(xlRange.Cells[i, 1].Value2.ToString(),
                                                    Convert.ToDecimal(xlRange.Cells[i, 2].Value2.ToString()),
                                                        Convert.ToDecimal(xlRange.Cells[i, 3].Value2.ToString()));
                    }
                }

                GC.Collect();
                GC.WaitForPendingFinalizers();

                Marshal.ReleaseComObject(xlRange);
                Marshal.ReleaseComObject(xlWorksheet);

                xlWorkbook.Close();
                Marshal.ReleaseComObject(xlWorkbook);

                xlApp.Quit();
                Marshal.ReleaseComObject(xlApp);
            }
            catch
            {
                MessageBox.Show("Erro na importação do documento, valide as informações. " +
                        "Informe código do produto da ficha, a quantidade e atividade referente ao produto.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void adicionarNoBindingSource(string vCd_produto, decimal vQuantidade, decimal vAtividade)
        {
            vCd_produto = vCd_produto.SoNumero();
            if (!ExistsAtividadeNoBs(vAtividade))
            {
                TRegistro_OrcProjeto orc = new TRegistro_OrcProjeto();
                orc.Id_orcamentostr = (bsOrcamento.Current as TRegistro_Orcamento).Id_orcamentostr;
                orc.Nr_versaostr = (bsOrcamento.Current as TRegistro_Orcamento).Nr_versaostr;
                orc.Id_projeto = vAtividade;
                Utils.TpBusca[] tp = new TpBusca[0];
                Utils.Estruturas.CriarParametro(ref tp, "a.id_atividade", vAtividade.ToString());
                orc.Ds_projeto = new TCD_CadAtividade().BuscarEscalar(tp, "a.ds_atividade").ToString();
                orc.Id_registro = bsAtividade.Count + 1;
                orc.lFicha = new TList_FichaTec();
                bsAtividade.Add(orc);
                bsAtividade.ResetBindings(true);
            }


            //Selecionar a atividade na listagem para adicionar o respectivo produto a listagem de ficha tec
            object d = new CamadaDados.Estoque.Cadastros.TCD_CadProduto().BuscarPrecoVenda(registro_CadCFG[0].cd_empresa, Convert.ToInt32(vCd_produto).ToString("D7"), registro_CadCFG[0].Cd_tabelapreco);
            Utils.TpBusca[] tps = new TpBusca[0];
            Utils.Estruturas.CriarParametro(ref tps, "a.cd_produto", vCd_produto);
            TRegistro_FichaTec _FichaTec = new TRegistro_FichaTec()
            {
                Cd_produto = Convert.ToInt32(vCd_produto).ToString("D7"),
                Ds_produto = new CamadaDados.Estoque.TCD_ConsultaProduto().BuscarEscalar(tps, "a.ds_produto").ToString(),
                Quantidade = vQuantidade,
                Vl_unitario = d == null ? 0 : Convert.ToDecimal(d),
                Vl_subtotal = vQuantidade * Convert.ToDecimal(d),
                Cd_empresa = (bsOrcamento.Current as TRegistro_Orcamento).Cd_empresa,
                Id_orcamentostr = (bsOrcamento.Current as TRegistro_Orcamento).Id_orcamentostr,
                Nr_versaostr = (bsOrcamento.Current as TRegistro_Orcamento).Nr_versaostr,
                Id_projeto = vAtividade,
                Id_registrostr = (bsAtividade.List as IEnumerable<TRegistro_OrcProjeto>).ToList().Find(r => r.Id_projeto.Equals(vAtividade)).Id_registrostr
            };

            (bsAtividade.List as IEnumerable<TRegistro_OrcProjeto>)
                    .ToList().Find(r => r.Id_projeto
                            .Equals(vAtividade))
                                    .lFicha
                                            .Add(_FichaTec);
        }

        private bool ExistsAtividadeNoBs(decimal vAtividade)
        {
            return (bsAtividade.List as IEnumerable<TRegistro_OrcProjeto>).ToList().Exists(r => r.Id_projeto.Equals(vAtividade));
        }

        private bool validaExistenciaAtividade(string value2)
        {
            if (value2 == null)
                return false;
            object v = value2.SoNumero();
            if (string.IsNullOrEmpty(v.ToString()))
                return false;
            Utils.TpBusca[] tps = new TpBusca[0];
            Utils.Estruturas.CriarParametro(ref tps, "a.id_atividade", "'" + v.ToString() + "'");
            if (new TCD_CadAtividade().BuscarEscalar(tps, "1") != null)
                return true;
            return false;
        }

        private bool validaQuantidadeInformada(string value2)
        {
            if (value2 == null)
                return false;
            object v = value2.SoNumero();
            if (string.IsNullOrEmpty(v.ToString()))
                return false;
            else if (Convert.ToInt32(v) < 1)
                return false;
            return true;
        }

        private bool validaExistenciaProduto(string value2)
        {
            if (value2 == null)
                return false;
            object v = value2.SoNumero();
            if (string.IsNullOrEmpty(v.ToString()))
                return false;
            Utils.TpBusca[] tps = new TpBusca[0];
            Utils.Estruturas.CriarParametro(ref tps, "a.cd_produto", "'" + Convert.ToInt32(v).ToString("D7") + "'");
            Utils.Estruturas.CriarParametro(ref tps, "isnull(a.st_registro, 'C')", "'C'", "<>");
            if (new CamadaDados.Estoque.TCD_ConsultaProduto().BuscarEscalar(tps, "1") != null)
                return true;
            return false;
        }
    }
}

