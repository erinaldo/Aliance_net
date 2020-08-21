using CamadaDados.Diversos;
using CamadaDados.Estoque.Cadastros;
using CamadaDados.Frota.Cadastros;
using FormBusca;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utils;

namespace Frota
{
    public partial class TFPneu : Form
    {
        private TRegistro_LanPneu rpneu;
        public TRegistro_LanPneu rPneu
        {
            get
            {
                if (bsPneu.Current != null)
                    return bsPneu.Current as TRegistro_LanPneu;
                else
                    return null;
            }
            set { rpneu = value; }
        }
        public TFPneu()
        {
            InitializeComponent();
            System.Collections.ArrayList cbx = new System.Collections.ArrayList();
            cbx.Add(new TDataCombo("NOVO", "0"));
            cbx.Add(new TDataCombo("USADO", "1"));
            cbx.Add(new TDataCombo("RECAPADO NOVO", "2"));
            cbx.Add(new TDataCombo("RECAPADO USADO", "2"));

            tp_estado.DataSource = cbx;
            tp_estado.ValueMember = "Value";
            tp_estado.DisplayMember = "Display";
        }


        private void afterGrava()
        {
            if (pDados.validarCampoObrigatorio())
                DialogResult = DialogResult.OK;
        }

        private void TFPneu_Load(object sender, EventArgs e)
        {
            this.Icon = ResourcesUtils.TecnoAliance_ICO;
            if (rpneu != null)
            {
                bsPneu.DataSource = new TList_LanPneu() { rpneu };
                cbEmpresa.Enabled = false;
                Nr_serie.Enabled = false;
                cd_produto.Enabled = false;
                bb_produto.Enabled = false;
            }
            else
                bsPneu.AddNew();
            //Buscar Empresa
            cbEmpresa.DataSource = new TCD_CadEmpresa().Select(
                                   new TpBusca[]
                                   {
                                        new TpBusca()
                                        {
                                            vNM_Campo = string.Empty,
                                            vOperador = "exists",
                                            vVL_Busca = "(select 1 from tb_div_usuario_x_empresa x " +
                                                        "where x.cd_empresa = a.cd_empresa " +
                                                        "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                                        "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                                        "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))"
                                        }
                                   }, 0, string.Empty);
            cbEmpresa.DisplayMember = "NM_Empresa";
            cbEmpresa.ValueMember = "CD_Empresa";
            //Buscar Produto Pneu
            TList_CadProduto lProduto = new TCD_CadProduto().Select(
                new TpBusca[]
                {
                    new TpBusca()
                    {
                        vNM_Campo = "isnull(a.st_registro, 'A')",
                        vOperador = "=",
                        vVL_Busca = "'A'"
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "isnull(e.ST_Pneu, 'N')",
                        vOperador = "=",
                        vVL_Busca = "'S'"
                    }
                }, 0, string.Empty, string.Empty, string.Empty);

            if (lProduto.Count.Equals(1))
            {
                cd_produto.Text = lProduto[0].CD_Produto;
                ds_produto.Text = lProduto[0].DS_Produto;
            }
            else if (lProduto.Count.Equals(0))
            {
                MessageBox.Show("Não existe nenhum produto cadastrado com o Tipo de Produto Pneu!\r\n" +
                                "Por favor verifique o tipo de produto, e atualize o cadastro de produto. ", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.Cancel;
            }
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            afterGrava();
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void TFPneu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }

        private void bb_produto_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaProduto(new Componentes.EditDefault[] { cd_produto }, "isnull(e.ST_Pneu, 'N')|=|'S'");
        }

        private void cd_produto_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVEProduto("a.cd_produto|=|'" + cd_produto.Text.Trim() + "'; isnull(e.ST_Pneu, 'N')|=|'S'",
                                                   new Componentes.EditDefault[] { cd_produto, ds_produto },
                                                   new CamadaDados.Estoque.Cadastros.TCD_CadProduto());
        }
    }
}
