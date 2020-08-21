using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CamadaDados.Almoxarifado;
using CamadaNegocio.Almoxarifado;
using FormBusca;
using Utils;
using CamadaDados.Estoque.Cadastros;
using CamadaDados.Diversos;

namespace Almoxarifado.Cadastros
{
    public partial class TFCadItens : FormCadPadrao.FFormCadPadrao
    {
        public TFCadItens()
        {
            InitializeComponent();
            DTS = BS_CadItens;
        }

        public override string gravarRegistro()
        {
            if (pDados.validarCampoObrigatorio())
                return TCN_CadItens.Gravar(BS_CadItens.Current as TRegistro_CadItens, null);
            else
                return string.Empty;
        }

        public override int buscarRegistros()
        {
            TList_CadItens lista = TCN_CadItens.Buscar(cd_produto.Text,
                                                       id_almox.Text,
                                                       id_rua.Text,
                                                       id_secao.Text,
                                                       id_celula.Text,
                                                       null);
            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    BS_CadItens.DataSource = lista;
                }
                else
                    if ((vTP_Modo == TTpModo.tm_Standby) || (vTP_Modo == TTpModo.tm_busca))
                        BS_CadItens.Clear();
                return lista.Count;
            }
            else
                return 0;
        }

        public override void afterCancela()
        {
            base.afterCancela();
            if (vTP_Modo == TTpModo.tm_Insert)
                BS_CadItens.RemoveCurrent();
        }

        public override void habilitarControls(bool value)
        {
            pDados.HabilitarControls(value, this.vTP_Modo);
        }

        public override void afterAltera()
        {
            base.afterAltera();
            bb_cdProduto.Enabled = false;
            bb_almox.Enabled = false;
            id_rua.Focus();
        }

        public override void afterBusca()
        {
            base.afterBusca();
        }

        public override void formatZero()
        {
            pDados.set_FormatZero();
        }

        public override void afterNovo()
        {
            if ((vTP_Modo == TTpModo.tm_busca) || (vTP_Modo == TTpModo.tm_Standby))
                BS_CadItens.AddNew();
            base.afterNovo();
            cd_produto.Focus();
        }

        public override void excluirRegistro()
        {
            if ((this.vTP_Modo == TTpModo.tm_Standby) || (this.vTP_Modo == TTpModo.tm_busca))
                if (MessageBox.Show("Confirma Exclusão do Registro?", "Mensagem",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                System.Windows.Forms.DialogResult.Yes)
                {
                    TCN_CadItens.Excluir(BS_CadItens.Current as TRegistro_CadItens, null);
                    BS_CadItens.RemoveCurrent();
                    pDados.LimparRegistro();
                    afterBusca();
                }
        }

        private void bb_cdProduto_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaProduto(new Componentes.EditDefault[] { cd_produto, ds_produto }, "isnull(e.st_consumointerno, 'N')|=|'S'");
        }

        private void cd_produto_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVEProduto("a.cd_produto|=|'" + cd_produto.Text.Trim() + "';isnull(e.st_consumointerno, 'N')|=|'S'",
                                            new Componentes.EditDefault[] { cd_produto, ds_produto },
                                            new TCD_CadProduto());
        }

        private void bb_almox_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_almoxarifado|Almoxarifado|150;" +
                              "a.id_almox|Id. Almox.|80";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { id_almox, ds_almox },
                                    new TCD_CadAlmoxarifado(), string.Empty);
        }

        private void id_almox_Leave(object sender, EventArgs e)
        {
            string vParam = "a.id_almox|=|" + id_almox.Text;
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { id_almox, ds_almox },
                                    new CamadaDados.Almoxarifado.TCD_CadAlmoxarifado());
        }

        private void bb_rua_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_rua|Rua|150;" +
                              "a.id_rua|Id. Rua|80";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { id_rua, ds_rua },
                                    new TCD_CadRua(), string.Empty);
        }

        private void id_rua_Leave(object sender, EventArgs e)
        {
            string vParam = "a.id_rua|=|" + id_rua.Text;
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { id_rua, ds_rua },
                                    new TCD_CadRua());
        }

        private void bb_secao_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_secao|Seção|150;" +
                              "a.id_secao|Id. Seção|80";
            string vParam = "a.id_rua|=|" + (string.IsNullOrEmpty(id_rua.Text) ? "null" : id_rua.Text);
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { id_secao, ds_secao },
                                    new TCD_CadSecao(), vParam);
        }

        private void id_secao_Leave(object sender, EventArgs e)
        {
            string vParam = "a.id_secao|=|" + id_secao.Text + ";" +
                "a.id_rua|=|" + (string.IsNullOrEmpty(id_rua.Text) ? "null" : id_rua.Text);
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { id_secao, ds_secao },
                                    new TCD_CadSecao());
        }

        private void bb_celula_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_celula|Celula|150;" +
                              "a.id_celula|Id. Celula|80";
            string vParam = "a.id_rua|=|" + (string.IsNullOrEmpty(id_rua.Text) ? "null" : id_rua.Text) + ";" +
                "a.id_secao|=|" + (string.IsNullOrEmpty(id_secao.Text) ? "null" : id_secao.Text);
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { id_celula, ds_celula },
                                    new TCD_CadCelulaArm(), vParam);
        }

        private void id_celula_Leave(object sender, EventArgs e)
        {
            string vParam = "a.id_celula|=|" + id_celula.Text + ";" +
                "a.id_rua|=|" + (string.IsNullOrEmpty(id_rua.Text) ? "null" : id_rua.Text) + ";" +
                "a.id_secao|=|" + (string.IsNullOrEmpty(id_secao.Text) ? "null" : id_secao.Text);
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { id_celula, ds_celula },
                                    new TCD_CadCelulaArm());
        }

        private void TFCadItens_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gPesquisa);
        }

        private void TFCadItens_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gPesquisa);
        }

        private void cd_produto_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void ds_produto_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
