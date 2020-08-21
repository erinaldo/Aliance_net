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
using System.Reflection;

namespace Parametros.Config
{
    public partial class TFCad_Menu : FormPadrao.FFormPadrao
    {
        private TList_CadMenu CacheListaMenu;
        private TList_CadMenu CacheListaInfo = new TList_CadMenu();

        public TFCad_Menu()
        {
            InitializeComponent();
            CacheListaMenu = TCN_CadMenu.Busca(string.Empty, 
                                               string.Empty, 
                                               false, 
                                               "a.id_menu", 
                                               false, 
                                               string.Empty, 
                                               null);
            PopulaMenus();
            PopulaMenusInfo();
            BB_Novo.Visible = false;
            BB_Buscar.Visible = false;
            BB_Gravar.Visible = true;
            BB_Excluir.Visible = true;
        }

        public override void afterGrava()
        {
            try
            {
                //GRAVA MENUS
                if (treeMenuPreCad.SelectedNode != null)
                {
                    TreeNode nodeMenu = treeMenuPreCad.SelectedNode;
                    TList_CadMenu ListMenuVar = new TList_CadMenu();
                    ListMenuVar = CriaListNode(ListMenuVar, nodeMenu);

                    if (ListMenuVar.Count > 0)
                    {
                        TCN_CadMenu.GravarMenu(ListMenuVar, null);
                        
                        CarregaDados();
                    }
                    else
                    {
                        MessageBox.Show("Não foi possível lançar o menu, tente novamente!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("É necessário selecionar um item pré-cadastrado!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public override void afterExclui()
        {
            //DELETA MENU
            if (treeMenu.SelectedNode != null)
            {
                if (MessageBox.Show("Confirma Exclusão do Item do Menu?", "Mensagem",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                System.Windows.Forms.DialogResult.Yes)
                {
                    //excluir
                    TreeNode nodeMenu = treeMenu.SelectedNode;
                    if (nodeMenu.Nodes.Count == 0)
                    {
                        List<TRegistro_CadMenu> RegMenuVar = CacheListaMenu.Where(p => (p.id_menu == nodeMenu.Name)).ToList<TRegistro_CadMenu>();

                        if (RegMenuVar.Count > 0)
                        {
                            TRegistro_CadMenu regMenu = (RegMenuVar[0] as TRegistro_CadMenu);

                            if (regMenu.tp_evento.Trim() == "R")
                                TCN_Cad_Report.AtualizaMenuReport(regMenu.id_menu, null);
                            TCN_CadMenu.DeletarMenuAcesso(regMenu, null);

                            CarregaDados();
                        }
                        else
                            MessageBox.Show("Não foi possível excluir o menu, tente novamente!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                        MessageBox.Show("Não é possível excluir menu que tem filhos!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("É necessário selecionar um item do menu!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void CarregaDados()
        {
            treeMenu.Nodes.Clear();
            CacheListaMenu = TCN_CadMenu.Busca("", "", false, "a.id_menu", false, "", null);
            PopulaMenus();
            Type t = Application.OpenForms["FMenuPrin"].GetType();
            t.GetMethod("CarregaMenu").Invoke(Application.OpenForms["FMenuPrin"], new object[] { "MASTER", true });
        }

        public TList_CadMenu CriaListNode(TList_CadMenu lista, TreeNode nodeMenu)
        {
            List<TRegistro_CadMenu> RegMenuVar = CacheListaInfo.Where(p => (p.id_menu == nodeMenu.Name)).ToList<TRegistro_CadMenu>();

            if (RegMenuVar.Count > 0)
            {
                TRegistro_CadMenu regMenu = (RegMenuVar[0] as TRegistro_CadMenu);
                lista.Add(regMenu);

                if (nodeMenu.Nodes.Count > 0)
                {
                    for (int i = 0; i < nodeMenu.Nodes.Count; i++)
                        CriaListNode(lista, nodeMenu.Nodes[i]);
                }
            }

            return lista;
        }

        #region "MENU CADASTRADOS"

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
                            noMenu.Tag = ItemsMenus[x].tp_evento.ToString();
                            
                            treeMenu.Nodes.AddRange(new TreeNode[] { noMenu });

                            //BUSCA TODOS OS MENUS PAIS
                            List<TRegistro_CadMenu> ItemsFilhosMenus = CacheListaMenu.Where(c => (c.id_menuraiz == ItemsMenus[x].id_menu)).ToList<TRegistro_CadMenu>();
                            if (ItemsFilhosMenus.Count > 0)
                            {
                                AddCamposTree(ItemsFilhosMenus, treeMenu.Nodes);
                                VerificaExisteFilhos(ItemsFilhosMenus, CacheListaMenu);
                            }
                        }
                    }
                }

                //treeMenu.ExpandAll();
                //treeMenu.SelectedNode = treeMenu.Nodes[0];
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
                                    noMenu.Tag = listaMenu[q].tp_evento.ToString();
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
                    List<TRegistro_CadMenu> ItemsFilhos = listaMenu.Where(c => (c.id_menuraiz == ItemsFilhosMenus[i].id_menu)).ToList<TRegistro_CadMenu>();

                    if (ItemsFilhos.Count > 0)
                    {
                        AddCamposTree(ItemsFilhos, treeMenu.Nodes);
                        VerificaExisteFilhos(ItemsFilhos, listaMenu);
                    }
                }
            }

        #endregion

        #region "MENU INFO"

            public void PopulaMenusInfo()
            {
                System.IO.DirectoryInfo folder = new System.IO.DirectoryInfo(Utils.Parametros.pubPathAliance.Trim());
                System.IO.FileInfo[] lista = folder.GetFiles("*.dll");
                Int32 tam = lista.Length;
                string[] registros;

                for (int x = 0; x < tam; x++)
                {
                    try
                    {
                        Assembly extAssembly = Assembly.LoadFrom(lista[x].FullName.Trim());
                        string Mod = extAssembly.ManifestModule.Name.Replace(".dll", "");

                        object extInfo = extAssembly.CreateInstance(Mod + ".TInfo");

                        string tt = extInfo.GetType().GetMethod("getInfoMenu").Invoke(extInfo, null).ToString();
                        registros = tt.Split('|');
                        for (int y = 0; y < registros.Length; y++)
                        {
                            TRegistro_CadMenu regMenu = RetornaRegMenu(registros[y], extAssembly.ManifestModule.Name);
                            CacheListaInfo.Add(regMenu);
                        }

                    }
                    catch (System.IO.FileLoadException ex)
                    {
                        MessageBox.Show("Arquivo: " + ex.FileName.Remove(0, 8) + "\r\n" +
                                        "O sistema não pode ler o arquivo especificado.\r\n\r\n " + ex.StackTrace, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (System.IO.FileNotFoundException ex)
                    {
                        MessageBox.Show("Arquivo: " + ex.FileName.Remove(0, 8) + "\r\n" +
                                        "O sistema não pode encontrar o arquivo especificado.\r\n\r\n " + ex.StackTrace, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch
                    {
                    }
                }

                List<TRegistro_CadMenu> ItemsMenus = CacheListaInfo.Where(c => (c.id_menuraiz == null && c.nivel == 1 && c.tp_evento.Equals("S"))).OrderBy(p => p.id_menu).ToList<TRegistro_CadMenu>();

                if (ItemsMenus.Count > 0)
                {
                    for (int x = 0; x < ItemsMenus.Count; x++)
                    {
                        if (ItemsMenus[x].ds_menu.Trim() != "")
                        {
                            TreeNode noMenu = new TreeNode(ItemsMenus[x].id_menu + " - " + ItemsMenus[x].ds_menu.Trim());
                            noMenu.Name = ItemsMenus[x].id_menu.ToString().Trim();
                            noMenu.Tag = ItemsMenus[x].tp_evento.ToString();
                            treeMenuPreCad.Nodes.AddRange(new TreeNode[] { noMenu });

                            //BUSCA TODOS OS MENUS PAIS
                            List<TRegistro_CadMenu> ItemsFilhosMenus = CacheListaInfo.Where(c => (c.id_menuraiz == ItemsMenus[x].id_menu)).OrderBy(p => p.id_menu).ToList<TRegistro_CadMenu>();
                            if (ItemsFilhosMenus.Count > 0)
                            {
                                AddCamposTree(ItemsFilhosMenus, treeMenuPreCad.Nodes);
                                VerificaExisteFilhosInfo(ItemsFilhosMenus, CacheListaInfo);
                            }
                        }
                    }
                }

                //treeMenuPreCad.ExpandAll();
                //treeMenuPreCad.SelectedNode = treeMenuPreCad.Nodes[0];
            }

            public TRegistro_CadMenu RetornaRegMenu(string lin, string modulo)
            {
                TRegistro_CadMenu reg = new TRegistro_CadMenu();
                string[] campos = lin.Split(':');
                reg.id_menu = campos[0].Trim();
                reg.id_menuraiz = (campos[1].Trim() != "NULL" ? campos[1] : null);
                reg.cd_modulo = (campos[2].Trim() != "NULL" ? campos[2] : null);
                reg.nm_classe = (campos[3].Trim() != "NULL" ? campos[3] : null);
                reg.ds_menu = (campos[4].Trim() != "NULL" ? campos[4] : null);
                reg.nm_modulo = modulo;
                if (string.IsNullOrEmpty(reg.nm_classe))
                    reg.tp_evento = "S";
                else
                    reg.tp_evento = "P";

                if (string.IsNullOrEmpty(reg.id_menuraiz))
                    reg.nivel = 1;

                return reg;
            }

            public void VerificaExisteFilhosInfo(List<TRegistro_CadMenu> ItemsFilhosMenus, TList_CadMenu listaMenu)
            {
                for (int i = 0; i < ItemsFilhosMenus.Count; i++)
                {
                    List<TRegistro_CadMenu> ItemsFilhos = listaMenu.Where(c => (c.id_menuraiz == ItemsFilhosMenus[i].id_menu)).OrderBy(p => p.id_menu).ToList<TRegistro_CadMenu>();

                    if (ItemsFilhos.Count > 0)
                    {
                        AddCamposTree(ItemsFilhos, treeMenuPreCad.Nodes);
                        VerificaExisteFilhos(ItemsFilhos, listaMenu);
                    }
                }
            }

        #endregion

        #region "DRAG DROP"

            private void tree_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
            {

            }

            private void tree_DragOver(object sender, System.Windows.Forms.DragEventArgs e)
            {

            }

            private void tree_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
            {

            }

        #endregion

            private void TFCad_Menu_Load(object sender, EventArgs e)
            {
                if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                    Idioma.TIdioma.AjustaCultura(this);
            }
    }
}

