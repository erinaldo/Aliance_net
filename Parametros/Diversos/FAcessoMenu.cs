using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Parametros.Diversos
{
    public partial class TFAcessoMenu : Form
    {
        public string Login
        { get; set; }

        public TFAcessoMenu()
        {
            InitializeComponent();
        }

        private void montarArvoreMenu()
        {
            //Buscar centro custo
            DataTable tb_menu = new CamadaDados.Diversos.TCD_CadMenu().Buscar(null, 0, "", "", "a.id_menu, a.nivel", null);
            if (tb_menu != null)
                if (tb_menu.Rows.Count > 0)
                {
                    tvMenu.BeginUpdate();
                    tvMenu.Nodes.Clear();
                    TreeNode[] nodeNivel1 = new TreeNode[0];
                    TreeNode[] nodeNivel2 = new TreeNode[0];
                    TreeNode[] nodeNivel3 = new TreeNode[0];
                    TreeNode[] nodeNivel4 = new TreeNode[0];
                    for (int i = 0; i < tb_menu.Rows.Count; i++)
                    {
                        switch (Convert.ToInt32(tb_menu.Rows[i]["Nivel"].ToString()))
                        {
                            case 1:
                                //Montar Nivel 1
                                Array.Resize(ref nodeNivel1, nodeNivel1.Length + 1);
                                nodeNivel1[nodeNivel1.Length - 1] = new TreeNode(tb_menu.Rows[i]["ID_Menu"].ToString().Trim() + " - " + tb_menu.Rows[i]["DS_Menu"].ToString().Trim());
                                tvMenu.Nodes.Add(nodeNivel1[nodeNivel1.Length - 1]);
                                break;
                            case 2:
                                //Montar Nivel 2
                                Array.Resize(ref nodeNivel2, nodeNivel2.Length + 1);
                                nodeNivel2[nodeNivel2.Length - 1] = new TreeNode(tb_menu.Rows[i]["ID_Menu"].ToString().Trim() + " - " + tb_menu.Rows[i]["DS_Menu"].ToString().Trim());
                                nodeNivel1[nodeNivel1.Length - 1].Nodes.Add(nodeNivel2[nodeNivel2.Length - 1]);
                                break;
                            case 3:
                                //Montar Nivel 3
                                Array.Resize(ref nodeNivel3, nodeNivel3.Length + 1);
                                nodeNivel3[nodeNivel3.Length - 1] = new TreeNode(tb_menu.Rows[i]["ID_Menu"].ToString().Trim() + " - " + tb_menu.Rows[i]["DS_Menu"].ToString().Trim());
                                nodeNivel2[nodeNivel2.Length - 1].Nodes.Add(nodeNivel3[nodeNivel3.Length - 1]);
                                break;
                            case 4:
                                //Montar Nivel 4
                                Array.Resize(ref nodeNivel4, nodeNivel4.Length + 1);
                                nodeNivel4[nodeNivel4.Length - 1] = new TreeNode(tb_menu.Rows[i]["ID_Menu"].ToString().Trim() + " - " + tb_menu.Rows[i]["DS_Menu"].ToString().Trim());
                                nodeNivel3[nodeNivel3.Length - 1].Nodes.Add(nodeNivel4[nodeNivel4.Length - 1]);
                                break;
                        }
                    }
                    tvMenu.EndUpdate();
                    tvMenu.CollapseAll();
                }
        }

        private bool existeAcessoMenu(string vId_menu)
        {
            if (bsAcesso.Count > 0)
            {
                for (int i = 0; i < bsAcesso.Count; i++)
                    if ((bsAcesso[i] as CamadaDados.Diversos.TRegistro_CadAcesso).Id_menu.Trim().Equals(vId_menu.Trim()))
                    {
                        bsAcesso.Position = i;
                        return true;
                    }
                return false;
            }
            else
                return false;
        }

        private void TFAcessoMenu_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pDetalhe.BackColor = Utils.SettingsUtils.Default.COLOR_1;
            this.montarArvoreMenu();
            //Buscar tabela de acesso para o usuario
            bsAcesso.DataSource = CamadaNegocio.Diversos.TCN_CadAcesso.Buscar(Login,
                                                                             string.Empty,
                                                                             false,
                                                                             string.Empty,
                                                                             0,
                                                                             "a.id_menu, c.nivel",
                                                                             null);
        }

        private void tvMenu_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            //Verificar se ja existe acesso para este item de menu
            string[] vAux = e.Node.Text.ToString().Split(new char[] { '-' });
            if (!existeAcessoMenu(vAux[0]))
            {
                //Gravar acesso para o item de menu
                //e todos os seus subitens caso exista
                CamadaNegocio.Diversos.TCN_CadAcesso.GravarAcesso(new CamadaDados.Diversos.TRegistro_CadAcesso()
                {
                    Id_menu = vAux[0].Trim(),
                    Login = Login,
                    Inclui = cbIncluir.Checked ? "S" : "N",
                    Altera = cbAlterar.Checked ? "S" : "N",
                    Exclui = cbExcluir.Checked ? "S" : "N"
                }, null);
                //Buscar tabela de acesso para o usuario
                bsAcesso.DataSource = CamadaNegocio.Diversos.TCN_CadAcesso.Buscar(Login,
                                                                                 string.Empty,
                                                                                 false,
                                                                                 string.Empty,
                                                                                 0,
                                                                                 "a.id_menu, c.nivel",
                                                                                 null);
            }
        }

        private void tList_CadAcessoDataGridDefault_DoubleClick(object sender, EventArgs e)
        {
            if (bsAcesso.Current != null)
            {
                CamadaNegocio.Diversos.TCN_CadAcesso.DeletarAcesso(bsAcesso.Current as CamadaDados.Diversos.TRegistro_CadAcesso, null);
                //Buscar Acesso
                bsAcesso.DataSource = CamadaNegocio.Diversos.TCN_CadAcesso.Buscar(Login,
                                                                                 string.Empty,
                                                                                 false,
                                                                                 string.Empty,
                                                                                 0,
                                                                                 "a.id_menu, c.nivel",
                                                                                 null);
            }
        }
    }
}
