using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FormBusca;

namespace Commoditties
{
    public partial class TFAtualizaPedido : Form
    {
        public CamadaDados.Faturamento.Pedido.TList_RegLanPedido_Item lPedItem
        {
            get
            {
                if (bsItensPedido.Count > 0)
                {
                    CamadaDados.Faturamento.Pedido.TList_RegLanPedido_Item aux = new CamadaDados.Faturamento.Pedido.TList_RegLanPedido_Item();
                    for (int i = 0; i < bsItensPedido.Count; i++)
                        if ((bsItensPedido[i] as CamadaDados.Faturamento.Pedido.TRegistro_LanPedido_Item).St_gerarConferencia)
                            aux.Add(bsItensPedido[i] as CamadaDados.Faturamento.Pedido.TRegistro_LanPedido_Item);
                    return aux;
                }
                else
                    return null;
            }
        }

        public TFAtualizaPedido()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if (vl_unitario.Value.Equals(0))
            {
                MessageBox.Show("Obrigatorio informar novo valor unitario para gravar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            for (int i = 0; i < bsItensPedido.Count; i++)
                (bsItensPedido[i] as CamadaDados.Faturamento.Pedido.TRegistro_LanPedido_Item).Vl_unitario = vl_unitario.Value;
            this.DialogResult = DialogResult.OK;
        }

        private void afterBusca()
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(nr_contrato.Text))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "contrato.nr_contrato";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = nr_contrato.Text;
            }
            if (!string.IsNullOrEmpty(nr_pedido.Text))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_pedido";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = nr_pedido.Text;
            }
            if (!string.IsNullOrEmpty(cd_clifor.Text))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "n.cd_clifor";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + cd_clifor.Text.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(cd_empresa.Text))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "n.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + cd_empresa.Text.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(cd_produto.Text))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_produto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + cd_produto.Text.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(anosafra.Text))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "contrato.anosafra";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + anosafra.Text.Trim() + "'";
            }
            string status = string.Empty;
            string virg = string.Empty;
            if (cbEntrada.Checked)
            {
                status += virg + "'E'";
                virg = ",";
            }
            if (cbSaida.Checked)
            {
                status += virg + "'S'";
                virg = ",";
            }
            if (!string.IsNullOrEmpty(status))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "n.tp_movimento";
                filtro[filtro.Length - 1].vOperador = "in";
                filtro[filtro.Length - 1].vVL_Busca = "(" + status.Trim() + ")";
            }
            bsItensPedido.DataSource = new CamadaDados.Faturamento.Pedido.TCD_LanPedido_Item().Select(filtro,
                                                                                                      0,
                                                                                                      string.Empty,
                                                                                                      string.Empty,
                                                                                                      "contrato.nr_contrato, a.nr_pedido, a.cd_produto");
        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            string vParam = "|EXISTS|(select 1 from tb_div_usuario_x_empresa x " +
                            "where x.cd_empresa = a.cd_empresa " +
                            "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                            "(exists(select 1 from tb_div_usuario_x_grupos y " +
                            "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            UtilPesquisa.BTN_BUSCA("a.NM_empresa|Nome Empresa|300;a.CD_Empresa|Cd.Empresa|80;UF|UF|80"
                , new Componentes.EditDefault[] { cd_empresa }, new CamadaDados.Diversos.TCD_CadEmpresa(), vParam);
        }

        private void cd_empresa_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "';" +
                              "|EXISTS|(select 1 from tb_div_usuario_x_empresa x " +
                              "where x.cd_empresa = a.cd_empresa " +
                              "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                              "(exists(select 1 from tb_div_usuario_x_grupos y " +
                              "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cd_empresa }, new CamadaDados.Diversos.TCD_CadEmpresa());
        }

        private void bb_clifor_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_clifor }, "isnull(a.st_registro, 'A')|<>|'C'");
        }

        private void cd_clifor_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.cd_clifor|=|'" + cd_clifor.Text + "';isnull(a.st_registro, 'A')|<>|'C'"
                , new Componentes.EditDefault[] { cd_clifor },
                new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void bb_produto_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaProduto(new Componentes.EditDefault[] { cd_produto }, string.Empty);
        }

        private void cd_produto_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVEProduto("a.cd_produto|=|'" + cd_produto.Text.Trim() + "'",
                                            new Componentes.EditDefault[] { cd_produto },
                                            new CamadaDados.Estoque.Cadastros.TCD_CadProduto());
        }

        private void bb_safra_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_safra|Ano Safra|200;" +
                              "a.anosafra|Cd. Safra|80";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { anosafra },
                                    new CamadaDados.Graos.TCD_CadSafra(), "isnull(a.st_registro, 'A')|<>|'C'");
        }

        private void anosafra_Leave(object sender, EventArgs e)
        {
            string vParam = "a.anosafra|=|'" + anosafra.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { anosafra },
                                    new CamadaDados.Graos.TCD_CadSafra());
        }

        private void st_marcartodos_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < bsItensPedido.Count; i++)
                (bsItensPedido[i] as CamadaDados.Faturamento.Pedido.TRegistro_LanPedido_Item).St_gerarConferencia = st_marcartodos.Checked;
            bsItensPedido.ResetBindings(true);
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void TFAtualizaPedido_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
            else if (e.KeyCode.Equals(Keys.F7))
                this.afterBusca();
        }

        private void gItensPedido_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                (bsItensPedido.Current as CamadaDados.Faturamento.Pedido.TRegistro_LanPedido_Item).St_gerarConferencia = 
                    !(bsItensPedido.Current as CamadaDados.Faturamento.Pedido.TRegistro_LanPedido_Item).St_gerarConferencia;
                bsItensPedido.ResetCurrentItem();
            }
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            this.afterBusca();
        }

        private void TFAtualizaPedido_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gItensPedido);
            panelDados1.BackColor = Utils.SettingsUtils.Default.COLOR_1;
            pDados.BackColor = Utils.SettingsUtils.Default.COLOR_2;

            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
        }

        private void TFAtualizaPedido_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gItensPedido);
        }
    }
}
