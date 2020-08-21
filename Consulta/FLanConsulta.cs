using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Utils;
using FormBusca;
using CamadaDados.Consulta.Cadastro;
using CamadaNegocio.Consulta.Cadastro;
using System.Collections;
using Componentes;

namespace Consulta
{
    public partial class TFLanConsulta : FormCadPadrao.FFormCadPadrao
    {
        decimal CD_Amarracao = 0;
        int posicaobusca = -1;
        
        public TFLanConsulta()
        {
            InitializeComponent();
            NM_Consulta.CharacterCasing = CharacterCasing.Normal;
        }

        public override void formatZero()
        {
            pDados.set_FormatZero();
        }

        public override void habilitarControls(bool value)
        {
            pDados.HabilitarControls(value, this.vTP_Modo);
        }

        public override string gravarRegistro()
        {
            if (tcCentral.SelectedIndex == 0)
            {
                //GRAVA O REGISTRO
                if (NM_Consulta.Text.Trim().Equals(""))
                {
                    MessageBox.Show("Atenção, é necessário informar o nome da consulta!");
                    NM_Consulta.Focus();
                }
                else
                {
                    //CRIA OS DADOS DA CONSULTA
                    (BS_Consulta.Current as TRegistro_Cad_Consulta).Login = CamadaDados.TDataQuery.getPubVariavel(TInfo.pub, "LOGIN");
                    //(BS_Consulta.Current as TRegistro_Cad_Consulta).CD_Clifor = CD_Clifor;

                    string retorno = TCN_Cad_Consulta.GravaConsulta((BS_Consulta.Current as TRegistro_Cad_Consulta), null);

                    if (retorno != "")
                    {
                        (BS_Consulta.Current as TRegistro_Cad_Consulta).ID_Consulta = CamadaDados.TDataQuery.getPubVariavel(retorno, "@P_ID_Consulta");
                        BS_Consulta.ResetBindings(true);
                        return retorno;
                    }
                    else
                    {
                        tcCentral.SelectedIndex = 0;
                        MessageBox.Show("Não foi possível lançar a consulta tente novamente!");
                    }
                }
            }
            else if (tcCentral.SelectedIndex == 1)
            {
                //ADICIONA AS TABElAS
                if (treeTabelas.SelectedNode != null)
                {
                    TreeNode node = treeTabelas.SelectedNode;

                    //INSTANCIA O REGISTRO
                    TRegistro_Cad_Amarracoes Cad_Amarracoes = new TRegistro_Cad_Amarracoes();
                    Cad_Amarracoes.ID_Consulta = (BS_Consulta.Current as TRegistro_Cad_Consulta).ID_Consulta;
                    Cad_Amarracoes.NM_Tabela = node.Text;
                    Cad_Amarracoes.ST_Principal = "N";

                    if (cb_TabelaPrincipal.Checked)
                    {
                        TCN_Cad_Amarracoes.AlterarTodosStatus(Cad_Amarracoes);
                        Cad_Amarracoes.ST_Principal = "S";
                    }

                    string retorno = TCN_Cad_Amarracoes.GravaAmarracoes(Cad_Amarracoes);

                    if (retorno != "")
                    {
                        CD_Amarracao = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(retorno, "@P_ID_AMARRACOES"));
                    }


                    buscarTabelasAdicionadas();
                }
            }
            else if (tcCentral.SelectedIndex == 2)
            {
                if (cb_TipoAmarracao.SelectedItem == null)
                {
                    MessageBox.Show("Atenção, é necessário selecionar um tipo de amarração!");
                    cb_TipoAmarracao.Focus();
                }
                else
                if (treeBase.SelectedNode != null && treeEstrangeira.SelectedNode != null)
                {
                    if (treeBase.SelectedNode.Parent != null && treeEstrangeira.SelectedNode.Parent != null)
                    {
                        //GRAVA OS DADOS DA AMARRAÇÃO
                        if (pDadosAddCampoAmarracao.validarCampoObrigatorio())
                        {
                            TRegistro_Cad_Amarracoes Cad_Amarracoes = new TRegistro_Cad_Amarracoes();
                            Cad_Amarracoes.ID_Consulta = (BS_Consulta.Current as TRegistro_Cad_Consulta).ID_Consulta;
                            Cad_Amarracoes.ID_Amarracoes = Convert.ToDecimal(treeEstrangeira.SelectedNode.Parent.Name);
                            Cad_Amarracoes.NM_Tabela = treeEstrangeira.SelectedNode.Parent.Text;
                            string[] ID_Tipo_Amarracao = cb_TipoAmarracao.SelectedItem.ToString().Trim().Split(new char[] { '-' });
                            Cad_Amarracoes.ID_Tipo_Amarracao = Convert.ToDecimal(ID_Tipo_Amarracao[0].Trim());

                            string retorno = TCN_Cad_Amarracoes.GravaAmarracoes(Cad_Amarracoes);

                            if (retorno != "")
                            {
                                CD_Amarracao = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(retorno, "@P_ID_AMARRACOES"));
                            }
                            
                            if (CD_Amarracao > 0)
                            {
                                TRegistro_Cad_Campo_Amarracao Cad_Campo_Amarracao = new TRegistro_Cad_Campo_Amarracao();
                                Cad_Campo_Amarracao.ID_Amarracoes = CD_Amarracao;
                                Cad_Campo_Amarracao.Campo_Base = treeBase.SelectedNode.Text;
                                Cad_Campo_Amarracao.Campo_Estrangeiro = treeEstrangeira.SelectedNode.Text;
                                Cad_Campo_Amarracao.NM_Tabela_Base = treeBase.SelectedNode.Parent.Text;
                                Cad_Campo_Amarracao.NM_Tabela_Estrangeiro = treeEstrangeira.SelectedNode.Parent.Text;

                                TCN_Cad_Campo_Amarracao.GravaCampoAmarracao(Cad_Campo_Amarracao);
                            }

                            buscarRegistros();
                        }
                    }
                }
            }
            else if (tcCentral.SelectedIndex == 4)
            {
                if (treeCampo.SelectedNode != null)
                {
                    if (treeCampo.SelectedNode.Text.IndexOf("TB_") != -1)
                    {
                        MessageBox.Show("Por favor, seleciona um campo!");
                    }
                    else
                    {
                        //GRAVA O CAMPO
                        if (cb_OperadorFiltro.SelectedItem == null)
                        {
                            MessageBox.Show("Por favor, selecione um operador!");
                            cb_OperadorFiltro.Focus();
                        }
                        else if (ID_ParamClasse.Text == "")
                        {
                            MessageBox.Show("Por favor, selecione um parâmetro!");
                            ID_ParamClasse.Focus();
                        }
                        else
                        {
                            TRegistro_Cad_Filtro Cad_Filtro = new TRegistro_Cad_Filtro();
                            Cad_Filtro.ID_Consulta = (BS_Consulta.Current as TRegistro_Cad_Consulta).ID_Consulta;
                            Cad_Filtro.NM_Campo = treeCampo.SelectedNode.Text;
                            string[] ID_Operador = cb_OperadorFiltro.SelectedItem.ToString().Trim().Split(new char[] { '-' });
                            Cad_Filtro.ID_Operador = Convert.ToDecimal(ID_Operador[0].Trim());
                            Cad_Filtro.ID_ParamClasse = Convert.ToDecimal(ID_ParamClasse.Text);
                            Cad_Filtro.Alias_Campo = treeCampo.SelectedNode.Parent.Text;
                            Cad_Filtro.ST_Ligacao = "A";

                            //VERIFICA SE A ALGUM DADOS LANÇADO
                            TList_Cad_Filtro lista = TCN_Cad_Filtro.Busca(0, (BS_Consulta.Current as TRegistro_Cad_Consulta).ID_Consulta, "");

                            if (lista != null)
                            {
                                if (lista.Count > 0)
                                {
                                    Cad_Filtro.ST_Ligacao = "O";
                                }
                            }

                            string retorno = TCN_Cad_Filtro.GravaFiltro(Cad_Filtro);

                            buscarRegistros();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Por favor, selecione um campo!");
                }
            }
            else if (tcCentral.SelectedIndex == 5)
            {
                //ADICIONA A ORDENAÇÃO
                if (treeOrdenacaoCampo.SelectedNode.Parent != null)
                {
                    string Order = "A";
                    if (rb_Desc.Checked)
                    {
                        Order = "D";
                    }

                    TRegistro_Cad_Ordenacao Cad_Ordenacao = new TRegistro_Cad_Ordenacao();
                    Cad_Ordenacao.TP_Ordenacao = Order;
                    Cad_Ordenacao.ID_Consulta = (BS_Consulta.Current as TRegistro_Cad_Consulta).ID_Consulta;
                    Cad_Ordenacao.NM_Campo = treeOrdenacaoCampo.SelectedNode.Text;
                    Cad_Ordenacao.Alias_Campo = treeOrdenacaoCampo.SelectedNode.Parent.Text;

                    TCN_Cad_Ordenacao.GravaOrdenacao(Cad_Ordenacao);

                    buscarRegistros();
                }
            }

            return "";
        }

        public override void excluirRegistro()
        {
            if (tcCentral.SelectedIndex == 0)
            {
                if (BS_Consulta.Current != null)
                {
                    if (MessageBox.Show("Confirma Exclusão do Registro?", "Mensagem",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                    System.Windows.Forms.DialogResult.Yes)
                    {
                        TCN_Cad_Consulta.DeletaConsulta((BS_Consulta.Current as TRegistro_Cad_Consulta), null);
                        buscarRegistros();
                    }
                }
            }
            else if (tcCentral.SelectedIndex == 1)
            {
                if (treeTabelasAdicionadas.SelectedNode != null)
                {
                    if (MessageBox.Show("Confirma Exclusão do Registro?", "Mensagem",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                    System.Windows.Forms.DialogResult.Yes)
                    {
                        TreeNode node = treeTabelasAdicionadas.SelectedNode;
                        if (node.Text.EndsWith("*"))
                        {
                            if (treeTabelasAdicionadas.Nodes.Count > 0)
                            {
                                TreeNode noPrincipal = treeTabelasAdicionadas.Nodes[0];

                                TRegistro_Cad_Amarracoes Cad_Amarracoes_Principal = new TRegistro_Cad_Amarracoes();
                                Cad_Amarracoes_Principal.ID_Amarracoes = Convert.ToDecimal(noPrincipal.Name);
                                Cad_Amarracoes_Principal.ID_Consulta = (BS_Consulta.Current as TRegistro_Cad_Consulta).ID_Consulta;
                                Cad_Amarracoes_Principal.NM_Tabela = noPrincipal.Text;
                                Cad_Amarracoes_Principal.ST_Principal = "S";

                                TCN_Cad_Amarracoes.GravaAmarracoes(Cad_Amarracoes_Principal);
                            }
                        }
                        TRegistro_Cad_Amarracoes Cad_Amarracoes = new TRegistro_Cad_Amarracoes();
                        Cad_Amarracoes.ID_Amarracoes = Convert.ToDecimal(node.Name);

                        TCN_Cad_Amarracoes.DeletaAmarracoes(Cad_Amarracoes);

                        buscarTabelasAdicionadas();

                        if (treeTabelasAdicionadas.Nodes.Count > 0)
                        {
                            cb_TabelaPrincipal.Checked = false;
                        }
                        else
                        {
                            cb_TabelaPrincipal.Checked = true;
                        }
                    }
                }
            }
            else if (tcCentral.SelectedIndex == 2)
            {
                if (BS_CampoAmarracao.Current != null)
                {
                    if (MessageBox.Show("Confirma Exclusão do Registro?", "Mensagem",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                        System.Windows.Forms.DialogResult.Yes)
                    {
                        TRegistro_Cad_Campo_Amarracao Cad_Campo_Amarracao = new TRegistro_Cad_Campo_Amarracao();
                        Cad_Campo_Amarracao.ID_Campo_Amarracao = (BS_CampoAmarracao.Current as TRegistro_Cad_Campo_Amarracao).ID_Campo_Amarracao;

                        TCN_Cad_Campo_Amarracao.DeletaCampoAmarracao(Cad_Campo_Amarracao);

                        buscarRegistros();
                    }
                }
            }
            else if (tcCentral.SelectedIndex == 4)
            {
                if (BS_Filtro.Current != null)
                {
                    if (MessageBox.Show("Confirma Exclusão do Registro?", "Mensagem",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                        System.Windows.Forms.DialogResult.Yes)
                    {
                        TRegistro_Cad_Filtro Cad_Filtro = new TRegistro_Cad_Filtro();
                        Cad_Filtro.ID_Filtro = (BS_Filtro.Current as TRegistro_Cad_Filtro).ID_Filtro;

                        //DELETA O FILTRO
                        TCN_Cad_Filtro.DeletaFiltro(Cad_Filtro);

                        buscarRegistros();
                    }
                }
            }
            else if (tcCentral.SelectedIndex == 5)
            {
                if (treeCampoOrdenado.SelectedNode != null)
                {
                    TRegistro_Cad_Ordenacao Cad_Ordenacao = new TRegistro_Cad_Ordenacao();
                    Cad_Ordenacao.ID_Ordenacao = Convert.ToDecimal(treeCampoOrdenado.SelectedNode.Name);
                    TCN_Cad_Ordenacao.DeletaOrdenacao(Cad_Ordenacao);

                    buscarRegistros();
                }
            }
        }

        public override void afterNovo()
        {
            tcCentral.SelectedIndex = 0;

            base.afterNovo();
            BS_Consulta.AddNew();
            NM_Consulta.Enabled = true;
            NM_Consulta.Focus();
        }

        public override void afterAltera()
        {
            base.afterAltera();
            NM_Consulta.Enabled = true;
            NM_Consulta.Focus();
        }

        public override void afterGrava()
        {
            if (tcCentral.SelectedIndex == 0)
            {
                if (this.gravarRegistro() != "")
                {
                    this.vTP_Modo = TTpModo.tm_busca;
                    this.habilitarControls(false);
                    NM_Consulta.Enabled = false;
                    this.buscarRegistros();
                    this.modoBotoes(this.vTP_Modo, true, true, false, true, false, true, true);
                }
                else
                {
                    //NM_Consulta.Enabled = false;
                    this.vTP_Modo = TTpModo.tm_Insert;
                    this.modoBotoes(this.vTP_Modo, true, false, true, false, true, true, false);
                }
            }
            else
            {
                this.gravarRegistro();
            }
        }

        public override void afterExclui()
        {
            excluirRegistro();
        }

        public override void afterBusca()
        {
            if (tcCentral.SelectedIndex == 0)
            {
                BB_Excluir.Visible = true;
                buscarRegistros();
            }
        }

        public override int buscarRegistros()
        {
            if (tcCentral.SelectedIndex == 0)
            {
                TList_Cad_Consulta lista = TCN_Cad_Consulta.Busca(0, CamadaDados.TDataQuery.getPubVariavel(TInfo.pub, "LOGIN"), NM_Consulta.Text, 0);
                if (lista != null)
                {
                    if (lista.Count > 0)
                    {
                        BS_Consulta.DataSource = lista;
                    }
                    else
                    {
                        BS_Consulta.Clear();
                    }

                    return lista.Count;
                }
            }
            else if (tcCentral.SelectedIndex == 1)
            {
                TList_Cad_Usuario_X_Tabela lista = TCN_Cad_Usuario_X_Tabela.Busca(CamadaDados.TDataQuery.getPubVariavel(TInfo.pub, "LOGIN"), "", "");
                if (lista != null)
                {
                    if (lista.Count > 0)
                    {
                        treeTabelas.Nodes.Clear();
                        for (int i = 0; i < lista.Count; i++)
                        {
                            TreeNode no = new TreeNode(lista[i].NM_Tabela);
                            treeTabelas.Nodes.AddRange(new TreeNode[] { no });
                        }
                    }
                    else
                    {
                        treeTabelas.Nodes.Clear();
                    }

                    return lista.Count;
                }
            }
            else if (tcCentral.SelectedIndex == 2)
            {
                TList_Cad_Campo_Amarracao lista = TCN_Cad_Campo_Amarracao.Busca(0, (BS_Consulta.Current as TRegistro_Cad_Consulta).ID_Consulta, 0, 0);
                if (lista != null)
                {
                    if (lista.Count > 0)
                    {
                        BS_CampoAmarracao.DataSource = lista;
                    }
                    else
                    {
                        BS_CampoAmarracao.Clear();
                    }

                    BS_CampoAmarracao.ResetBindings(true);
                    return lista.Count;
                }
            }
            else if (tcCentral.SelectedIndex == 4)
            {
                TList_Cad_Filtro lista = TCN_Cad_Filtro.Busca(0, (BS_Consulta.Current as TRegistro_Cad_Consulta).ID_Consulta, "");
                if (lista != null)
                {
                    if (lista.Count > 0)
                    {
                        BS_Filtro.DataSource = lista;
                    }
                    else
                    {
                        BS_Filtro.Clear();
                    }

                    BS_Filtro.ResetBindings(true);
                    return lista.Count;
                }
            }
            else if (tcCentral.SelectedIndex == 5)
            {
                TList_Cad_Ordenacao lista = TCN_Cad_Ordenacao.Busca(0, (BS_Consulta.Current as TRegistro_Cad_Consulta).ID_Consulta, "");
                if (lista != null)
                {
                    if (lista.Count > 0)
                    {
                        treeCampoOrdenado.Nodes.Clear();
                        for (int i = 0; i < lista.Count; i++)
                        {
                            TreeNode no = new TreeNode(lista[i].NM_Campo + " (" + (lista[i].TP_Ordenacao.Equals("A") ? "ASC" : "DESC") + ")");
                            no.Name = lista[i].ID_Ordenacao.ToString();
                            treeCampoOrdenado.Nodes.AddRange(new TreeNode[] { no });
                        }
                    }
                    else
                    {
                        treeCampoOrdenado.Nodes.Clear();
                    }
                    return lista.Count;
                }
            }

            return 0;
        }

        #region "ABA 1 - CONSULTA"

            private void tabTabela_Enter(object sender, EventArgs e)
            {
                NM_Consulta.Focus();
            }

            private void BS_Consulta_CurrentChanged(object sender, EventArgs e)
            {
                if (BS_Consulta.Current != null && (BS_Consulta.Current as TRegistro_Cad_Consulta).DS_SQL != "")
                {
                    ///HabilitarAbas(true);
                }
                else
                {
                    ///HabilitarAbas(false);
                }

                if (BS_Consulta.Current != null && (BS_Consulta.Current as TRegistro_Cad_Consulta).ID_Consulta.Trim() != "")
                {
                    BB_Alterar.Visible = true;
                }
                else
                {
                    BB_Alterar.Visible = true;
                }
            }

            public void HabilitarAbas(bool habilitar)
            {
                if (habilitar)
                {
                    tcCentral.TabPages.Add(tabAmarracoes);
                    tcCentral.TabPages.Add(tabFiltroAmarracao);
                    tcCentral.TabPages.Add(tabCampo);
                    tcCentral.TabPages.Add(tabFiltros);
                    tcCentral.TabPages.Add(tabOrdenacao);
                }
                else
                {
                    tcCentral.TabPages.RemoveAt(5);
                    tcCentral.TabPages.RemoveAt(4);
                    tcCentral.TabPages.RemoveAt(3);
                    tcCentral.TabPages.RemoveAt(2);
                    tcCentral.TabPages.RemoveAt(1);
                }
            }

            private void bb_DigitarSQL_Click(object sender, EventArgs e)
            {
                if (BS_Consulta != null && (BS_Consulta.Current as TRegistro_Cad_Consulta).ID_Consulta.Trim() != "")
                {
                    TFCad_SQL frameCad_SQL = new TFCad_SQL((BS_Consulta.Current as TRegistro_Cad_Consulta), false);
                    frameCad_SQL.ShowDialog();
                    
                    buscarRegistros();
                }
                else
                {
                    MessageBox.Show("Atenção, é necessário selecionar ou gravar a consulta para lançar a SQL!");
                    NM_Consulta.Focus();
                }
            }

        #endregion

        #region "ABA 2 - TABELAS"

            private void tabAmarracao_Enter(object sender, EventArgs e)
            {
                if (BS_Consulta.Current != null && (BS_Consulta.Current as TRegistro_Cad_Consulta).ID_Consulta.Trim() != "")
                {
                    //BUSCA OS DADOS PARA AS TABELAS DE LIGAÇÃO
                    buscarRegistros();
                    buscarTabelasAdicionadas();
                }
                else
                {
                    tcCentral.SelectedIndex = 0;
                    //MessageBox.Show("É necessário selecionar uma consulta, ou, salva-lá antes de definir seus requisitos!");
                    NM_Consulta.Focus();
                }
            }

            public void buscarTabelasAdicionadas()
            {
                TList_Cad_Amarracoes lista = TCN_Cad_Amarracoes.Busca(0, (BS_Consulta.Current as TRegistro_Cad_Consulta).ID_Consulta);
                if (lista != null)
                {
                    if (lista.Count > 0)
                    {
                        treeTabelasAdicionadas.Nodes.Clear();
                        for (int i = 0; i < lista.Count; i++)
                        {
                            TreeNode no = new TreeNode(lista[i].NM_Tabela + (lista[i].ST_Principal.Equals("S") ? "*" : ""));
                            no.Name = lista[i].ID_Amarracoes.ToString();
                            treeTabelasAdicionadas.Nodes.AddRange(new TreeNode[] { no });
                        }
                    }
                    else
                    {
                        treeTabelasAdicionadas.Nodes.Clear();
                    }
                }
            }

            private void treeTabelas_DoubleClick(object sender, EventArgs e)
            {
                gravarRegistro();

                if (treeTabelasAdicionadas.Nodes.Count > 0)
                {
                    cb_TabelaPrincipal.Checked = false;
                }
            }

            private void Filtro_Tabela_KeyUp(object sender, KeyEventArgs e)
            {
                buscaTree(treeTabelas, Filtro_Tabela.Text, null);
            }

        #endregion

        #region "ABA 3 - FILTRO TABELA"

            public void Adiciona_Tree(TreeView treeBase)
            {
                treeBase.Nodes.Clear();

                //ADICIONA OS DADOS
                TList_Cad_Amarracoes lista = TCN_Cad_Amarracoes.Busca(0, (BS_Consulta.Current as TRegistro_Cad_Consulta).ID_Consulta);

                //BUSCA OS CAMPOS DAS TABELAS AMARRADAS
                for (int i = 0; i < lista.Count; i++)
                {
                    //CRIO O GROUP BOX DAS TABELAS
                    TreeNode node = new TreeNode();
                    node.NodeFont = new Font("Microsoft Sans Serif", 8, FontStyle.Bold);
                    node.Text = lista[i].NM_Tabela.ToString();
                    node.Name = lista[i].ID_Amarracoes.ToString();
                    treeBase.Nodes.AddRange(new TreeNode[] { node });

                    //CRIO O LIST
                    TList_Cad_Campo_Tabela listaCampo = busca_Campos(lista[i].NM_Tabela);

                    if (listaCampo != null)
                    {
                        TreeNode[] treeNode = new TreeNode[listaCampo.Count];

                        for (int x = 0; x < listaCampo.Count; x++)
                        {
                            TreeNode nodeFilho = new TreeNode();
                            nodeFilho.Text = listaCampo[x].NM_Campo.Trim().ToString();

                            if (listaCampo[x].Chave_Estrangeira == "S")
                            {
                                nodeFilho.ForeColor = Color.Red;
                            }

                            treeNode[x] = nodeFilho;
                            //treeBase.Nodes[i].Nodes.Add(listaCampo[x].NM_Campo.Trim());
                        }

                        if (listaCampo.Count > 0)
                        {
                            treeBase.Nodes[i].Nodes.AddRange(treeNode);
                        }
                    }
                }

                treeBase.ExpandAll();
            }

            private void tabFiltroAmarracao_Enter(object sender, EventArgs e)
            {
                if (BS_Consulta.Current != null && (BS_Consulta.Current as TRegistro_Cad_Consulta).ID_Consulta.Trim() != "")
                {
                    buscarRegistros();
                    //Popula_Tabela();
                    Popula_TipoAmarracao();
                    Adiciona_Tree(treeBase);
                    Adiciona_Tree(treeEstrangeira);
                }
                else
                {
                    tcCentral.SelectedIndex = 0;
                    //MessageBox.Show("É necessário selecionar uma consulta, ou, salva-lá antes de definir seus requisitos!");
                    NM_Consulta.Focus();
                }
            }

            public void Popula_TipoAmarracao()
            {
                cb_TipoAmarracao.Items.Clear();
                //BUSCA OS OPERADORES
                TList_Cad_TipoAmarracao list = TCN_Cad_TipoAmarracao.Buscar("", "", "", "", 0, null);

                if (list != null)
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        cb_TipoAmarracao.Items.Add(list[i].ID_Tipo_Amarracao + " - " + list[i].Nm_Tipo_Amarracao);
                    }
                }
                else
                {
                    cb_TipoAmarracao.Items.Clear();
                }
            }

        #endregion

        #region "ABA 4 - CAMPO"

            public void monta_Aba_Campo()
            {
                flowLayoutCampo.Controls.Clear();

                //BUSCA AS TABELAS QUE ESTÃO AMARRADAS
                TList_Cad_Amarracoes listaAmarracoes = TCN_Cad_Amarracoes.Busca(0, (BS_Consulta.Current as TRegistro_Cad_Consulta).ID_Consulta);
                
                //BUSCA OS CAMPOS DAS TABELAS AMARRADAS
                for (int i = 0; i < listaAmarracoes.Count; i++)
                {
                    //CRIO O CHECKLIST DAS TABELAS
                    GroupBox groupBox = new GroupBox();
                    groupBox.Text = listaAmarracoes[i].NM_Tabela;
                    CheckedListBoxDefault checkTabela = new CheckedListBoxDefault();
                    checkTabela.CheckOnClick = true;
                    TList_Cad_Campo_Tabela listaCampo = busca_Campos(listaAmarracoes[i].NM_Tabela);
                    
                    if (listaCampo != null)
                    {
                        for (int x = 0; x < listaCampo.Count; x++)
                        {
                            checkTabela.Items.Add(listaCampo[x].NM_Campo.Trim());
                            checkTabela.Name = listaCampo[x].NM_Tabela;

                            if (listaCampo[x].ST_Existe == "S")
                            {
                                checkTabela.SetItemChecked(x, true);
                            }
                        }
                    }
                    
                    //ADD O CHECKLISTBOX PARA O GROUP BOX
                    checkTabela.Dock = DockStyle.Fill;
                    groupBox.Controls.Add(checkTabela);
                    flowLayoutCampo.Controls.Add(groupBox);
                }
            }

            public TList_Cad_Campo_Tabela busca_Campos(string vNM_Tabela)
            {
                TList_Cad_Campo_Tabela lista = TCN_Cad_Campo_Tabela.Busca(vNM_Tabela, (BS_Consulta.Current as TRegistro_Cad_Consulta).ID_Consulta);
                return lista;
            }

            private void tabCampo_Leave(object sender, EventArgs e)
            {
                if (BS_Consulta.Current != null)
                {
                    //GRAVA OS CAMPOS SELECIONADOS
                    TCN_Cad_Campo.DeletaTodosCampo((BS_Consulta.Current as TRegistro_Cad_Consulta).ID_Consulta);

                    for (int i = 0; i < flowLayoutCampo.Controls.Count; i++)
                    {
                        if (flowLayoutCampo.Controls[i] is GroupBox)
                        {
                            for (int y = 0; y < flowLayoutCampo.Controls[i].Controls.Count; y++)
                            {
                                if (flowLayoutCampo.Controls[i].Controls[y] is Componentes.CheckedListBoxDefault)
                                {
                                    for (int x = 0; x < (flowLayoutCampo.Controls[i].Controls[y] as Componentes.CheckedListBoxDefault).CheckedItems.Count; x++)
                                    {
                                        TRegistro_Cad_Campo Cad_Campo = new TRegistro_Cad_Campo();
                                        Cad_Campo.ID_Consulta = (BS_Consulta.Current as TRegistro_Cad_Consulta).ID_Consulta;
                                        Cad_Campo.NM_Campo = (flowLayoutCampo.Controls[i].Controls[y] as Componentes.CheckedListBoxDefault).CheckedItems[x].ToString();
                                        Cad_Campo.Alias_Campo = (flowLayoutCampo.Controls[i].Controls[y] as Componentes.CheckedListBoxDefault).Name;

                                        TCN_Cad_Campo.GravaCampo(Cad_Campo);
                                    }
                                }
                            }
                        }
                    }
                }
            }

            private void tcCentral_SelectedIndexChanged(object sender, EventArgs e)
            {
                if (BS_Consulta.Current != null && (BS_Consulta.Current as TRegistro_Cad_Consulta).ID_Consulta.Trim() != "")
                {
                    if (tcCentral.SelectedIndex > 0)
                    {
                        //HABILITADOS
                        BB_Novo.Visible = true;
                        BB_Gravar.Visible = true;
                        BB_Excluir.Visible = true;
                        BB_Fechar.Visible = true;

                        //DESABILITADOS
                        BB_Buscar.Visible = false;
                        BB_Cancelar.Visible = false;
                        BB_Imprimir.Visible = false;
                        BB_Alterar.Visible = false;
                        BB_Buscar.Visible = false;
                    }

                    if (tcCentral.SelectedIndex == 3)
                    {
                        monta_Aba_Campo();
                    }
                }
                else
                {
                    tcCentral.SelectedIndex = 0;
                    MessageBox.Show("É necessário selecionar uma consulta, ou, salva-lá antes de definir seus requisitos!");
                    NM_Consulta.Focus();
                }
            }

        #endregion

        #region "ABA 5 - FILTROS"

            private void tabFiltros_Enter(object sender, EventArgs e)
            {
                if (BS_Consulta.Current != null && (BS_Consulta.Current as TRegistro_Cad_Consulta).ID_Consulta.Trim() != "")
                {
                    Adiciona_Tree(treeCampo);

                    //BUSCA OS OPERADORES
                    Popula_List_Operadores();

                    buscarRegistros();
                }
                else
                {
                    tcCentral.SelectedIndex = 0;
                    MessageBox.Show("É necessário selecionar uma consulta, ou, salva-lá antes de definir seus requisitos!");
                    NM_Consulta.Focus();
                }
            }

            public void Popula_List_Operadores()
            {
                cb_OperadorFiltro.Items.Clear();
                TList_Cad_Operador list = TCN_Cad_Operador.Busca(0, "", "");

                if (list != null)
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        cb_OperadorFiltro.Items.Add(list[i].ID_Operador + " - " + list[i].NM_Operador);
                    }
                }
                else
                {
                    cb_OperadorFiltro.Items.Clear();
                }
            }

            private void BB_ParamClasse_Click(object sender, EventArgs e)
            {
                UtilPesquisa.BTN_BUSCA("a.ID_ParamClasse|Código Parâmetro|80;" +
                                       "a.NM_Param|Nome Parâmetro|350;" +
                                       "a.NM_CampoFormat|Campo Format|350;" +
                                       "a.NM_Classe|Nome Classe|350",
                                       new Componentes.EditDefault[] { ID_ParamClasse, NM_Param, NM_CampoFormat },
                                       new TCD_Cad_ParamClasse(), "");
            }

            private void ID_ParamClasse_Leave(object sender, EventArgs e)
            {
                UtilPesquisa.EDIT_LEAVE("a.ID_ParamClasse|=|'" + ID_ParamClasse.Text + "'",
                                        new Componentes.EditDefault[] { ID_ParamClasse, NM_Param, NM_CampoFormat },
                                        new TCD_Cad_ParamClasse());
            }

        #endregion

        #region "ABA 6 - ORDENAÇÃO"

            private void tabOrdenacao_Enter(object sender, EventArgs e)
            {
                if (BS_Consulta.Current != null && (BS_Consulta.Current as TRegistro_Cad_Consulta).ID_Consulta.Trim() != "")
                {
                    Adiciona_Tree(treeOrdenacaoCampo);
                }
                else
                {
                    tcCentral.SelectedIndex = 0;
                    MessageBox.Show("É necessário selecionar uma consulta, ou, salva-lá antes de definir seus requisitos!");
                    NM_Consulta.Focus();
                }
            }

            private void treeOrdenacaoCampo_DoubleClick(object sender, EventArgs e)
            {
                gravarRegistro();
            }

        #endregion

        public TreeNode buscaTree(TreeView tree, string nome, TreeNodeCollection nodes)
        {
            TreeNode node = null;

            if (nodes == null)
            {
                nodes = tree.Nodes;
            }

            for (int i = 0; i < nodes.Count; i++)
            {
                if (nodes[i].Text.ToUpper().IndexOf(nome) > -1 && posicaobusca != i)
                {
                    node = nodes[i];
                    posicaobusca = i;
                    break;
                }
                else
                {
                    node = null;
                }

                if (nodes[i].Nodes.Count > 0 && node == null)
                {
                    return buscaTree(tree, nome, nodes[i].Nodes);
                }

            }

            if (node != null)
            {
                tree.SelectedNode = node;
                tree.SelectedNode.Expand();
                Point localNode = tree.SelectedNode.Bounds.Location;
                tree.AutoScrollOffset = localNode;
            }
            else
            {
                posicaobusca = -1;
            }

            return node;
        }

        private void Filtro_Consulta_KeyUp(object sender, KeyEventArgs e)
        {
            buscaTree(treeCampo, Filtro_Consulta.Text, null);
        }

        private void Filtro_Base_KeyUp(object sender, KeyEventArgs e)
        {
            buscaTree(treeBase, Filtro_Base.Text, null);
        }

        private void Filtro_Estrangeiro_KeyUp(object sender, KeyEventArgs e)
        {
            buscaTree(treeEstrangeira, Filtro_Estrangeiro.Text, null);
        }

        private void Filtro_Ordenacao_KeyUp(object sender, KeyEventArgs e)
        {
            buscaTree(treeOrdenacaoCampo, Filtro_Ordenacao.Text, null);
        }

        private void TFLanConsulta_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, grid_CampoAmarracao);
            Utils.ShapeGrid.RestoreShape(this, grid_Filtro);
            Utils.ShapeGrid.RestoreShape(this, grid_Tabela);
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
        }

        private void TFLanConsulta_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, grid_CampoAmarracao);
            Utils.ShapeGrid.SaveShape(this, grid_Filtro);
            Utils.ShapeGrid.SaveShape(this, grid_Tabela);
        }
    }
}

