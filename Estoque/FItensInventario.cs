using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FormBusca;

namespace Estoque
{
    public partial class TFItensInventario : Form
    {
        public string Id_inventario
        { get; set; }
        public List<CamadaDados.Estoque.Cadastros.TRegistro_CadProduto> lProd
        {
            get
            {
                if (bsProduto.Count > 0)
                    return (bsProduto.DataSource as CamadaDados.Estoque.Cadastros.TList_CadProduto).FindAll(p => p.St_processar);
                else
                    return null;
            }
        }

        public TFItensInventario()
        {
            InitializeComponent();
            this.Id_inventario = string.Empty;
        }

        private void afterBusca()
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[3];
            filtro[0].vNM_Campo = "isnull(e.st_servico, 'N')";
            filtro[0].vOperador = "<>";
            filtro[0].vVL_Busca = "'S'";
            filtro[1].vNM_Campo = "isnull(a.st_registro, 'A')";
            filtro[1].vOperador = "<>";
            filtro[1].vVL_Busca = "'C'";
            filtro[2].vNM_Campo = "isnull(e.st_composto, 'S')";
            filtro[2].vOperador = "<>";
            filtro[2].vVL_Busca = "'S'";
            if (!string.IsNullOrEmpty(Id_inventario))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = "not exists";
                filtro[filtro.Length - 1].vVL_Busca = "(select 1 from tb_est_inventario_item x " +
                                                      "where x.cd_produto = a.cd_produto " +
                                                      "and x.id_inventario = " + Id_inventario + ")";
            }
            if(!string.IsNullOrEmpty(cd_grupo.Text))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_grupo";
                filtro[filtro.Length - 1].vOperador = "like";
                filtro[filtro.Length - 1].vVL_Busca = "'" + cd_grupo.Text.Trim() + "%'";
            }
            if(!string.IsNullOrEmpty(tp_produto.Text))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.tp_produto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + tp_produto.Text.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(cd_marca.Text))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_marca";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + cd_marca.Text.Trim() + "'";
            }
            if(!string.IsNullOrEmpty(cd_produto.Text))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_produto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + cd_produto.Text.Trim() + "'";
            }
            bsProduto.DataSource = new CamadaDados.Estoque.Cadastros.TCD_CadProduto().Select(filtro, 0, string.Empty, string.Empty, string.Empty);
        }

        private void bb_grupo_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_grupo|Grupo Produto|200;" +
                              "a.cd_grupo|Cd. Grupo|80";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_grupo },
                                            new CamadaDados.Estoque.Cadastros.TCD_CadGrupoProduto(), string.Empty);
        }

        private void cd_grupo_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_grupo|=|'" + cd_grupo.Text.Trim() + "'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_grupo },
                                            new CamadaDados.Estoque.Cadastros.TCD_CadGrupoProduto());
        }

        private void bb_tpproduto_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_tpproduto|Tipo Produto|200;" +
                              "a.tp_produto|TP. Produto|80";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { tp_produto },
                                            new CamadaDados.Estoque.Cadastros.TCD_CadTpProduto(), string.Empty);
        }

        private void tp_produto_Leave(object sender, EventArgs e)
        {
            string vParam = "a.tp_produto|=|'" + tp_produto.Text.Trim() + "'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { tp_produto },
                                                new CamadaDados.Estoque.Cadastros.TCD_CadTpProduto());
        }

        private void bb_produto_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaProduto(new Componentes.EditDefault[] { cd_produto }, "isnull(e.st_servico, 'N')|<>|'S'");
        }

        private void cd_produto_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LEAVEProduto("a.cd_produto|=|'" + cd_produto.Text.Trim() + "';isnull(e.st_servico, 'N')|<>|'S'",
                                                    new Componentes.EditDefault[] { cd_produto },
                                                    new CamadaDados.Estoque.Cadastros.TCD_CadProduto());
        }

        private void TFItensInventario_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pFiltro.set_FormatZero();
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            this.afterBusca();
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void st_marcatodos_Click(object sender, EventArgs e)
        {
            if (bsProduto.Count > 0)
            {
                (bsProduto.DataSource as CamadaDados.Estoque.Cadastros.TList_CadProduto).ForEach(p => p.St_processar = st_marcatodos.Checked);
                bsProduto.ResetBindings(true);
            }
        }

        private void gProduto_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e != null)
                if (e.ColumnIndex == 0)
                {
                    (bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).St_processar =
                        !(bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).St_processar;
                    bsProduto.ResetCurrentItem();
                }
        }

        private void TFItensInventario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.DialogResult = DialogResult.OK;
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
            else if (e.KeyCode.Equals(Keys.F7))
                this.afterBusca();
        }

        private void cd_marca_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.cd_marca|=|" + cd_marca.Text,
                                   new Componentes.EditDefault[] { cd_marca },
                                   new CamadaDados.Estoque.Cadastros.TCD_CadMarca());
        }

        private void bb_marca_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_marca|Marca|200;" +
                              "a.cd_marca|Id. Marca|80";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_marca },
                                    new CamadaDados.Estoque.Cadastros.TCD_CadMarca(),
                                    string.Empty);
        }
    }
}
