using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CamadaDados.Consulta.Cadastro;
using CamadaNegocio.Consulta.Cadastro;
using Utils;
using FormBusca;
using System.Collections;
using CamadaDados.Diversos;
using CamadaNegocio.Diversos;
using FormRelPadrao;
using BancoDados;

namespace Consulta
{
    public partial class TFEscolha_Menu : Form
    {
        public TRegistro_Cad_Report Cad_Report = new TRegistro_Cad_Report(); 
        private TList_CadMenu CacheListaMenu;
        public TRegistro_CadMenu Reg_CadMenu = null;
        public TObjetoBanco banco = null;

        public TFEscolha_Menu()
        {
            InitializeComponent();
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            DS_Menu.CharacterCasing = CharacterCasing.Normal;
            CacheListaMenu = TCN_CadMenu.Busca("", "", false, "a.id_menu", false, "", banco);
            PopulaMenus();
        }

        #region "METODOS POPULA OS MENUS"

            public void PopulaMenus()
            {
                //BUSCA TODOS OS MENUS PAIS
                List<TRegistro_CadMenu> ItemsMenus = CacheListaMenu.Where(c => (c.id_menuraiz == null && c.nivel == 1 && c.tp_evento.Equals("S"))).ToList<TRegistro_CadMenu>();

                if (ItemsMenus.Count > 0)
                {
                    for (int x = 0; x < ItemsMenus.Count; x++)
                    {
                        if (ItemsMenus[x].ds_menu.Trim() != "")
                        {
                            TreeNode noMenu = new TreeNode(ItemsMenus[x].id_menu + " - " + ItemsMenus[x].ds_menu.Trim());
                            noMenu.Name = ItemsMenus[x].id_menu.ToString().Trim();
                            noMenu.Tag = ItemsMenus[x].nivel.ToString();
                            treeMenu.Nodes.AddRange(new TreeNode[] { noMenu });

                            //BUSCA TODOS OS MENUS PAIS
                            List<TRegistro_CadMenu> ItemsFilhosMenus = CacheListaMenu.Where(c => (c.id_menuraiz == ItemsMenus[x].id_menu && c.tp_evento.Equals("S"))).ToList<TRegistro_CadMenu>();
                            if (ItemsFilhosMenus.Count > 0)
                            {
                                AddCamposTree(ItemsFilhosMenus, treeMenu.Nodes);
                                VerificaExisteFilhos(ItemsFilhosMenus, CacheListaMenu);
                            }
                        }
                    }
                }
            }

            public void AddCamposTree(List<TRegistro_CadMenu> listaMenu, TreeNodeCollection Node)
            {
                for (int k = 0; k < Node.Count; k++)
                {
                    TreeNode noMenuPai = Node[k];
                    for (int q = 0; q < listaMenu.Count; q++)
                    {
                        if (listaMenu[q].id_menuraiz != null)
                        {
                            if (noMenuPai.Name.ToString() == listaMenu[q].id_menuraiz.ToString().Trim())
                            {
                                if (listaMenu[q].ds_menu.Trim() != "")
                                {
                                    TreeNode noMenu = new TreeNode(listaMenu[q].id_menu + " - " + listaMenu[q].ds_menu.Trim());
                                    noMenu.Name = listaMenu[q].id_menu;
                                    noMenu.Tag = listaMenu[q].nivel.ToString();
                                    Node[k].Nodes.AddRange(new TreeNode[] { noMenu });
                                }
                            }
                        }
                    }

                    if (Node[k].Nodes.Count > 0)
                    {
                        AddCamposTree(listaMenu, Node[k].Nodes);
                    }
                }
            }

            public void VerificaExisteFilhos(List<TRegistro_CadMenu> ItemsFilhosMenus, TList_CadMenu listaMenu)
            {
                for (int i = 0; i < ItemsFilhosMenus.Count; i++)
                {
                    List<TRegistro_CadMenu> ItemsFilhos = listaMenu.Where(c => (c.id_menuraiz == ItemsFilhosMenus[i].id_menu && c.tp_evento.Equals("S"))).ToList<TRegistro_CadMenu>();

                    if (ItemsFilhos.Count > 0)
                    {
                        AddCamposTree(ItemsFilhos, treeMenu.Nodes);
                        VerificaExisteFilhos(ItemsFilhos, listaMenu);
                    }
                }
            }

        #endregion

        #region "ABA 1 - AÇÕES DO MENU"

            private void tsb_AddItem_Click(object sender, EventArgs e)
            {
                //BUSCA O NO SELECIONADO E QUEBRA ELE EM PARTES
                if (treeMenu.SelectedNode != null)
                {
                    TreeNode nodeSel = treeMenu.SelectedNode;
                    decimal nivel = Convert.ToDecimal(Convert.ToInt32(nodeSel.Tag.ToString()));

                    if (nivel < 4)
                    {
                        //ADD OS PARAMETROS
                        if (nivel == 1)
                            Nr1.Text = nodeSel.Name.Substring(0, 2);
                        else if (nivel == 2)
                            Nr1.Text = nodeSel.Name.Substring(0, 3);
                        else if (nivel == 3)
                            Nr1.Text = nodeSel.Name.Substring(0, 4);


                        //SETA O NIVELnivel++
                        cb_Nivel.SelectedIndex = Convert.ToInt32(nivel++);
                        //MOSTRA A TELA
                        ItemMenu.Text = nodeSel.Text;
                        DS_Menu.Enabled = true;
                        treeMenu.Enabled = false;
                        bb_OK.Enabled = true;
                        if (nivel == 4)
                        {
                            rb_Sintetico.Checked = false;
                            rb_Sintetico.Enabled = false;
                            rb_Analitico.Checked = true;
                            rb_Analitico.Enabled = false;
                            Nr2.Text = "";
                            Nr2.Enabled = false;
                            Nr2_SelectedIndexChanged(null, null);
                            bb_OK.Focus();
                        }
                        else
                        {
                            rb_Sintetico.Checked = true;
                            rb_Sintetico.Enabled = true;
                            rb_Analitico.Checked = false;
                            rb_Analitico.Enabled = true;
                            Nr2.Enabled = true;
                            Nr2.SelectedIndex = 0;
                            Nr2_SelectedIndexChanged(null, null);
                            rb_Sintetico.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Atenção, não é possível adicionar filhos para este nível!");
                    }
                }
                else
                {
                    MessageBox.Show("Atenção, é necessário selecionar uma raiz!");
                }
            }

            private void tsb_DelItem_Click(object sender, EventArgs e)
            {
                if (treeMenu.SelectedNode != null)
                {
                    TreeNode nodeSel = treeMenu.SelectedNode;
                    if (nodeSel.Nodes.Count <= 0)
                    {
                        if (MessageBox.Show("Deseja realmente deletar este item do menu?", "Mensagem",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                            System.Windows.Forms.DialogResult.Yes)
                        {
                            TRegistro_CadMenu Reg_CadMenu = new TRegistro_CadMenu();
                            Reg_CadMenu.id_menu = nodeSel.Name.Trim();
                            string retorno = TCN_CadMenu.DeletarMenuAcesso(Reg_CadMenu, banco);
                            if (retorno != "")
                            {
                                treeMenu.Nodes.Remove(treeMenu.SelectedNode);

                                //CARREGA NOVAMENTE O MENU
                                //Type t = Application.OpenForms["FMenuPrin"].GetType();
                                //t.GetMethod("CarregaMenu").Invoke(Application.OpenForms["FMenuPrin"], new object[] { "MASTER", new TDatUsuario(), true });

                                CacheListaMenu = TCN_CadMenu.Busca("", "", false, "a.id_menu", false, "", banco);
                            }
                            else
                            {
                                MessageBox.Show("Atenção, não foi possível deletar o item!");
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Atenção, este item do menu tem subitems e não pode ser deletado!");
                    }
                }
                else
                {
                    MessageBox.Show("Atenção, é necessário selecionar um item!");
                }
            }

            public int BuscaMaxNode(TreeNode node)
            {
                int MaxCodigo = 0;

                if (node.Nodes.Count > 0)
                {
                    MaxCodigo = Convert.ToInt32(node.Nodes[node.Nodes.Count - 1].Name.Substring(node.Nodes[node.Nodes.Count - 1].Name.Length - 2));
                    MaxCodigo++;
                }

                return MaxCodigo;
            }

            private void rb_Analitico_CheckedChanged(object sender, EventArgs e)
            {
                if (rb_Analitico.Checked)
                {
                    if (cb_Nivel.Text != "1")
                    {
                        string digito = treeMenu.SelectedNode.Name[Convert.ToInt32(cb_Nivel.Text) - 1].ToString();

                        for (int i = 0; i < Nr2.Items.Count; i++)
                        {
                            if (Nr2.Items[i].ToString() == digito)
                            {
                                Nr2.SelectedIndex = i;
                                break;
                            }
                        }
                    }

                    DS_Menu.Enabled = false;
                    DS_Menu.Text = Cad_Report.DS_Report;
                    Nr2_SelectedIndexChanged(null, null);
                    Nr2.Enabled = false;
                }
            }

            private void rb_Sintetico_CheckedChanged(object sender, EventArgs e)
            {
                if (rb_Sintetico.Checked)
                {
                    DS_Menu.Text = "";
                    DS_Menu.Enabled = true;
                    Nr2_SelectedIndexChanged(null, null);
                    Nr2.Enabled = true;
                }
            }

            private void Nr2_SelectedIndexChanged(object sender, EventArgs e)
            {
                if (pDadosItemMenu.Visible)
                {
                    string iniString = Nr1.Text + Nr2.Text;
                    if (cb_Nivel.Text == "4")
                        iniString = treeMenu.SelectedNode.Name.Substring(0, 4);
                    string MaxCodigo = "00";
                    if (CacheListaMenu.Where(c => c.id_menu.StartsWith(iniString)).Count() > 0)
                    {
                        MaxCodigo = CacheListaMenu.Where(c => c.id_menu.StartsWith(iniString)).Max(c => Convert.ToInt32(c.id_menu.Equals("") ? "-1" : c.id_menu)).ToString();
                        if (cb_Nivel.Text == "4")
                            MaxCodigo = (Convert.ToInt32(MaxCodigo.Substring(MaxCodigo.Length - 2)) + 1).ToString();
                        else if (MaxCodigo.Length > 2)
                            MaxCodigo = (MaxCodigo.Substring(MaxCodigo.Length - 2)).ToString();
                    }

                    if (rb_Analitico.Checked)
                        MaxCodigo = (Convert.ToInt32(MaxCodigo) + 1).ToString();
                    if (cb_Nivel.Text == "4" || rb_Analitico.Checked)
                        MaxCodigo = System.String.Format("{0:D2}", Convert.ToInt32(MaxCodigo));

                    Nr3.Text = MaxCodigo;
                    int i = 6 - (Nr1.Text + Nr2.Text + Nr3.Text).Length;
                    if (i > 0)
                    {
                        while (i != 0)
                        {
                            Nr3.Text = Nr3.Text + "0";
                            i--;
                        }
                    }
                }
            }

            private void bb_SalvarMenu_Click(object sender, EventArgs e)
            {
                try
                {
                    if (pDadosItemMenu.ValidarCampos(pDadosItemMenu))
                    {
                        Reg_CadMenu = new TRegistro_CadMenu();
                        Reg_CadMenu.id_menu = (Nr1.Text + Nr2.Text + Nr3.Text).Trim();

                        if (CacheListaMenu.Where(c => c.id_menu.Equals(Reg_CadMenu.id_menu)).Count() <= 0)
                        {
                            Reg_CadMenu.ds_menu = DS_Menu.Text;
                            Reg_CadMenu.nivel = Convert.ToDecimal(cb_Nivel.Text);
                            if (rb_Analitico.Checked)
                                Reg_CadMenu.tp_evento = "R";
                            else
                                Reg_CadMenu.tp_evento = "S";
                            Reg_CadMenu.id_menuraiz = treeMenu.SelectedNode.Name.ToString().Trim();
                            Reg_CadMenu.ID_Report = Cad_Report.ID_Report;

                            if (rb_Analitico.Checked)
                            {
                                this.DialogResult = DialogResult.OK;
                                this.Dispose();
                            }
                            else
                            {
                                //GRAVA NOVO MENU SINTETICO
                                string retorno = TCN_CadMenu.GravarMenu(Reg_CadMenu, banco);

                                TreeNode noMenu = new TreeNode(Reg_CadMenu.id_menu + " - " + Reg_CadMenu.ds_menu.Trim());
                                noMenu.Name = Reg_CadMenu.id_menu.ToString().Trim();
                                noMenu.Tag = Reg_CadMenu.nivel.ToString();
                                treeMenu.SelectedNode.Nodes.AddRange(new TreeNode[] { noMenu });

                                //FECHA E LIMPA O PANEL
                                treeMenu.Enabled = true;
                                bb_OK.Enabled = false;
                                LimpaAba();
                                CacheListaMenu = TCN_CadMenu.Busca("", "", false, "a.id_menu", false, "", banco);
                            }
                        }
                        else
                        {
                            throw new Exception("Atenção, não foi possível lançar o item do menu, já existe um item com este código!");
                        }
                    }
                }
                catch (Exception erro)
                {
                    MessageBox.Show("ERRO: " + erro.Message, "Mensagem");
                    bb_OK.Focus();
                }
            }

            private void bb_CancelarMenu_Click(object sender, EventArgs e)
            {
                pDadosItemMenu.Visible = false;
                treeMenu.Enabled = true;
                LimpaAba();
                this.DialogResult = DialogResult.Cancel;
            }

            private void LimpaAba()
            {
                DS_Menu.Text = "";
                DS_Menu.Enabled = false;
                Nr1.Text = "";
                Nr1.Enabled = false;
                cb_Nivel.SelectedIndex = 0;
                cb_Nivel.Enabled = false;
                Nr2.SelectedIndex = 0;
                Nr2.Enabled = false;
                Nr3.Text = "";
                Nr3.Enabled = false;
                ItemMenu.Text = "";
                ItemMenu.Enabled = false;
            }

        #endregion

            private void TFEscolha_Menu_Load(object sender, EventArgs e)
            {
                if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                    Idioma.TIdioma.AjustaCultura(this);
            }
    }
}

