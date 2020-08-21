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
    public partial class TFInventario : Form
    {
        private CamadaDados.Estoque.Tregistro_Inventario rinventario;
        public CamadaDados.Estoque.Tregistro_Inventario rInventario
        {
            get
            {
                if (bsInventario.Current != null)
                    return bsInventario.Current as CamadaDados.Estoque.Tregistro_Inventario;
                else
                    return null;
            }
            set { rinventario = value; }
        }

        public TFInventario()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if (pDados.validarCampoObrigatorio())
                this.DialogResult = DialogResult.OK;
        }

        private void InserirItem()
        {
            using (TFItensInventario fItem = new TFItensInventario())
            {
                fItem.Id_inventario = (bsInventario.Current as CamadaDados.Estoque.Tregistro_Inventario).Id_inventario.HasValue ?
                    (bsInventario.Current as CamadaDados.Estoque.Tregistro_Inventario).Id_inventario.Value.ToString() : string.Empty;
                if(fItem.ShowDialog() == DialogResult.OK)
                    if (fItem.lProd != null)
                    {
                        fItem.lProd.ForEach(p =>
                            {
                                //Verificar se o produto ja nao existe na lista
                                if (!(bsInventario.Current as CamadaDados.Estoque.Tregistro_Inventario).lItensInventario.Exists(v => v.Cd_produto.Trim().Equals(p.CD_Produto.Trim())))
                                {
                                    (bsInventario.Current as CamadaDados.Estoque.Tregistro_Inventario).lItensInventario.Add(
                                        new CamadaDados.Estoque.TRegistro_Inventario_Item()
                                        {
                                            Cd_produto = p.CD_Produto,
                                            Ds_produto = p.DS_Produto
                                        });
                                }
                            });
                        bsInventario.ResetCurrentItem();
                    }
            }
        }

        private void ExcluirItem()
        {
            if(bsItensInventario.Current != null)
                if (MessageBox.Show("Confirma exclusão do item selecionado?", "Pergunta", MessageBoxButtons.YesNo,
                     MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    (bsInventario.Current as CamadaDados.Estoque.Tregistro_Inventario).lItensDel.Add(
                        bsItensInventario.Current as CamadaDados.Estoque.TRegistro_Inventario_Item);
                    bsItensInventario.RemoveCurrent();
                }
        }

        private void BB_Empresa_Click(object sender, EventArgs e)
        {
            string vColunas = "a.NM_Empresa|Empresa|350;" +
                              "a.CD_Empresa|Código|100";
            string vParam = "|EXISTS|(select 1 from tb_div_usuario_x_empresa x " +
                            "where x.cd_empresa = a.cd_empresa " +
                            "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                            "(exists(select 1 from tb_div_usuario_x_grupos y " +
                            "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_Empresa, NM_Empresa },
                                    new CamadaDados.Diversos.TCD_CadEmpresa(), vParam);
        }

        private void CD_Empresa_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.CD_Empresa|=|'" + CD_Empresa.Text.Trim() + "';" +
                              "|EXISTS|(select 1 from tb_div_usuario_x_empresa x " +
                            "where x.cd_empresa = a.cd_empresa " +
                            "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                            "(exists(select 1 from tb_div_usuario_x_grupos y " +
                            "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_Empresa, NM_Empresa },
                                    new CamadaDados.Diversos.TCD_CadEmpresa());
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void TFInventario_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pDados.set_FormatZero();
            if (rinventario != null)
            {
                //Verificar se o inventario possui saldo lancado
                object obj = new CamadaDados.Estoque.TCD_Inventario_Item_X_Saldo().BuscarEscalar(
                                new Utils.TpBusca[]
                                {
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = "a.id_inventario",
                                        vOperador = "=",
                                        vVL_Busca = rinventario.Id_inventario.Value.ToString()
                                    }
                                }, "1");
                CD_Empresa.Enabled = obj == null;
                BB_Empresa.Enabled = obj == null;
                bsInventario.DataSource = new CamadaDados.Estoque.Tlist_Inventario() { rinventario };
                bsInventario.ResetBindings(true);
            }
            else
                bsInventario.AddNew();
        }

        private void ts_btn_Inserir_Endereco_Click(object sender, EventArgs e)
        {
            this.InserirItem();
        }

        private void ts_btn_Deletar_Endereco_Click(object sender, EventArgs e)
        {
            this.ExcluirItem();
        }

        private void TFInventario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
            else if (e.Control && e.KeyCode.Equals(Keys.F10))
                this.InserirItem();
            else if(e.Control && e.KeyCode.Equals(Keys.F12))
                this.ExcluirItem();
        }
    }
}
