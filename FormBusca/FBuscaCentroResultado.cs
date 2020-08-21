using CamadaDados.Financeiro.Cadastros;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FormBusca
{
    public partial class TFBuscaCentroResultado : Form
    {
        public string Cd_centro
        { get; set; }
        public string Ds_centro
        { get; set; }
        public string Tipo_registro
        { get; set; }
        public string Tp_registro
        { get; set; }
        public string St_deducao
        { get; set; }
        public bool St_sintetico
        { get; set; }
        private int index = 1;
        public string Cd_centroresult
        { get; set; }
        private TList_CentroResultado lCentro
        { get; set; }
        private TreeNodeMouseClickEventArgs tree
        { get; set; }
        public TFBuscaCentroResultado()
        {
            InitializeComponent();
            this.Height = Screen.PrimaryScreen.Bounds.Height - (Screen.PrimaryScreen.Bounds.Height / 10) * 1;
            this.Width = Screen.PrimaryScreen.Bounds.Width - (Screen.PrimaryScreen.Bounds.Width / 10) * 2;
        }

        private void afterBusca(TreeNodeMouseClickEventArgs e)
        {
            if (bsCentroResult.Current != null && e.Node.Tag != null)
            {
                if (!St_sintetico && e.Node.Tag.ToString().Trim().ToUpper() == "S")
                {
                    MessageBox.Show("Não é permitido incluir item SINTÉTICO.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (St_sintetico && e.Node.Tag.ToString().Trim().ToUpper() != "S")
                {
                    MessageBox.Show("Não é permitido incluir item ANÁLITICO.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                Cd_centro = e.Node.Name;
                Ds_centro = e.Node.Text;
                this.DialogResult = DialogResult.OK;
            }
        }

        private void BuscaCentro()
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Tp_registro))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.tp_registro";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "" + Tp_registro.Trim() + "";
            }
            if (!string.IsNullOrEmpty(St_deducao))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "isnull(a.st_deducao, 'N')";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + St_deducao.Trim() + "'";
            }
            bsCentroResult.DataSource = new CamadaDados.Financeiro.Cadastros.TCD_CentroResultado().Select(filtro, 0, string.Empty);
        }

        private void BuscarIndexContaCtb(bool down)
        {
            try
            {
                if (bsCentroResult.Current != null)
                {
                    if (down)
                    {
                        TreeNode[] tns = trvCResultado.Nodes.Find(lCentro[index].Cd_centroresult, true);
                        if (tns.Length > 0)
                        {
                            trvCResultado.SelectedNode = tns[0];
                            if (index + 1 < lCentro.Count)
                                index++;
                            else
                                index = 0;
                            lbSequencia.Text = (index + 1).ToString() + " de " + lCentro.Count;
                        }
                    }
                    else
                    {
                        TreeNode[] tns = trvCResultado.Nodes.Find(lCentro[index].Cd_centroresult, true);
                        if (tns.Length > 0)
                        {
                            trvCResultado.SelectedNode = tns[0];
                            if (index > 0)
                                index--;
                            else
                                index = lCentro.Count - 1;
                            lbSequencia.Text = (index + 1).ToString() + " de " + lCentro.Count;
                        }
                    }
                   
                }
            }
            catch { }
        }

        public void PopulaMenus()
        {
            trvCResultado.Nodes.Clear();
            //Buscar Centro Resultado
            CamadaDados.Financeiro.Cadastros.TList_CentroResultado lCentroResult =
                string.IsNullOrEmpty(Cd_centroresult) ?
                CamadaNegocio.Financeiro.Cadastros.TCN_CentroResultado.Buscar(string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              null) :
                new CamadaDados.Financeiro.Cadastros.TCD_CentroResultado().Select(
                new Utils.TpBusca[]
                {
                    new Utils.TpBusca()
                    {
                        vNM_Campo = string.Empty,
                        vOperador = string.Empty,
                        vVL_Busca = "(a.cd_centroresult = '" + Cd_centroresult.Trim() + "' or a.cd_centroresult_pai = '" + Cd_centroresult.Trim() + "')"
                    }
                }, 0, string.Empty);
            //BUSCA TODOS OS MENUS PAIS
            List<TRegistro_CentroResultado> lItensPai = lCentroResult.FindAll(p => string.IsNullOrEmpty(p.Cd_centroresult_pai) && p.Nivel.Equals(1));
            if (lItensPai.Count > 0)
            {
                lItensPai.ForEach(p =>
                {
                    TreeNode no = new TreeNode(p.Ds_centroresultado.Trim());
                    no.Name = p.Cd_centroresult.Trim();
                    no.Tag = p.St_sintetico;
                    if (p.St_sinteticobool)
                        no.ForeColor = Color.Red;
                    trvCResultado.Nodes.AddRange(new TreeNode[] { no });
                    //Buscar todos os registro filhos
                    List<TRegistro_CentroResultado> lItensFilho = lCentroResult.FindAll(v => v.Cd_centroresult_pai.Trim().Equals(p.Cd_centroresult.Trim()));
                    if (lItensFilho.Count > 0)
                    {
                        AddCamposTree(lItensFilho, trvCResultado.Nodes);
                        VerificaExisteFilhos(lItensFilho, lCentroResult);
                    }
                });
            }
            if (cbxExpandir.SelectedIndex.Equals(0))
                trvCResultado.ExpandAll();
            trvCResultado.SelectedNode = trvCResultado.Nodes[0];
        }

        public void AddCamposTree(List<TRegistro_CentroResultado> listaMenu, TreeNodeCollection Node)
        {
            for (int k = 0; k < Node.Count; k++)
            {
                TreeNode noMenuPai = Node[k];
                for (int q = 0; q < listaMenu.Count; q++)
                {
                    if (!string.IsNullOrEmpty(listaMenu[q].Cd_centroresult_pai))
                        if (noMenuPai.Name.ToString().Trim().Equals(listaMenu[q].Cd_centroresult_pai.Trim()))
                        {
                            TreeNode noMenu = new TreeNode(listaMenu[q].Ds_centroresultado.Trim());
                            noMenu.Name = listaMenu[q].Cd_centroresult.Trim();
                            noMenu.Tag = listaMenu[q].St_sintetico;
                            if (listaMenu[q].St_sinteticobool)
                                noMenu.ForeColor = Color.Red;
                            Node[k].Nodes.AddRange(new TreeNode[] { noMenu });
                            if (listaMenu[q].Nivel.Equals(2) && cbxExpandir.SelectedIndex.Equals(1))
                                Node[k].ExpandAll();
                        }
                }

                if (Node[k].Nodes.Count > 0)
                    AddCamposTree(listaMenu, Node[k].Nodes);
            }
        }

        public void VerificaExisteFilhos(List<TRegistro_CentroResultado> ItemsFilhosMenus, TList_CentroResultado listaMenu)
        {
            for (int i = 0; i < ItemsFilhosMenus.Count; i++)
            {
                List<TRegistro_CentroResultado> ItemsFilhos = listaMenu.FindAll(c => (c.Cd_centroresult_pai.Trim().Equals(ItemsFilhosMenus[i].Cd_centroresult.Trim())));

                if (ItemsFilhos.Count > 0)
                {
                    AddCamposTree(ItemsFilhos, trvCResultado.Nodes);
                    VerificaExisteFilhos(ItemsFilhos, listaMenu);
                }
            }
        }

        private void TFBuscaCentroResultado_Load(object sender, EventArgs e)
        {
            this.BuscaCentro();
            ds_centro.Focus();
            if (!string.IsNullOrEmpty(FormBusca.Properties.Settings.Default.ST_EXPANDIR.ToString()))
                cbxExpandir.SelectedIndex = FormBusca.Properties.Settings.Default.ST_EXPANDIR;
            else
                cbxExpandir.SelectedIndex = 0;
            this.PopulaMenus();
        }

        private void cbxExpandir_SelectedIndexChanged(object sender, EventArgs e)
        {
            FormBusca.Properties.Settings.Default.ST_EXPANDIR = cbxExpandir.SelectedIndex;
            FormBusca.Properties.Settings.Default.Save();
            this.PopulaMenus();
        }

        private void trvCResultado_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            trvCResultado.Focus();
            TreeNode tn = this.trvCResultado.SelectedNode;
            int x = tn.Bounds.X;
            int y = tn.Bounds.Y;
            //Click on the selected node
            TreeNodeMouseClickEventArgs treeNodeMouseClickEventArgs = new TreeNodeMouseClickEventArgs(tn, MouseButtons.Left, 1, x, y);
            this.afterBusca(treeNodeMouseClickEventArgs);
        }

        private void ds_centro_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lCentro = new TList_CentroResultado();
                (bsCentroResult.DataSource as TList_CentroResultado)
                    .FindAll(p => p.Ds_centroresultado.Contains(ds_centro.Text)).ForEach(p =>
                     {
                         lCentro.Add(p);
                     });
                TreeNode[] tns = trvCResultado.Nodes.Find(lCentro[0].Cd_centroresult, true);
                if (tns.Length > 0)
                    trvCResultado.SelectedNode = tns[0];
                if (lCentro != null)
                {
                    decimal result = lCentro.Count();
                    if (result == 0)
                    {
                        lbResultado.Text = "NENHUM RESULTADO ENCONTRADO";
                        index = 0;
                    }
                    else if (result == 1)
                    {
                        lbResultado.Text = result.ToString() + " RESULTADO ENCONTRADO";
                        index = 0;
                    }
                    else if (result > 1)
                    {
                        lbResultado.Text = result.ToString() + " RESULTADOS ENCONTRADOS";
                        index = 0;
                    }
                    lbSequencia.Text = (index + 1).ToString() + " de " + result.ToString();
                }
            }
            catch { }
        }

        private void TFBuscaCentroResultado_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                trvCResultado.Focus();
                TreeNode tn = this.trvCResultado.SelectedNode;
                int x = tn.Bounds.X;
                int y = tn.Bounds.Y;
                //Click on the selected node
                TreeNodeMouseClickEventArgs treeNodeMouseClickEventArgs = new TreeNodeMouseClickEventArgs(tn, MouseButtons.Left, 1, x, y);
                this.afterBusca(treeNodeMouseClickEventArgs);
            }
            else if (e.KeyCode.Equals(Keys.Down))
                this.BuscarIndexContaCtb(true);
            else if (e.KeyCode.Equals(Keys.Up))
                this.BuscarIndexContaCtb(false);
        }
    }
}
