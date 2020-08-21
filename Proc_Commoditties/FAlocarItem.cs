using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Proc_Commoditties
{
    public partial class TFAlocarItem : Form
    {
        public string Cd_produto
        { get; set; }
        public string Ds_produto
        { get; set; }
        public string Sigla_unidade
        { get; set; }
        public string Cd_empresa
        {get;set;}

        public string Id_almox
        { get { return id_almox.Text; } }
        public decimal Quantidade
        { get; set; }

        public TFAlocarItem()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if (string.IsNullOrEmpty(id_almox.Text))
            {
                MessageBox.Show("Obrigatorio informar almoxarifado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                id_almox.Focus();
                return;
            }
            if (quantidade.Value.Equals(decimal.Zero))
            {
                MessageBox.Show("Obrigatorio informar quantidade alocar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                quantidade.Focus();
                return;
            }
            this.DialogResult = DialogResult.OK;
        }

        private void BuscarAlocacao()
        {
            if((!string.IsNullOrEmpty(cd_produto.Text)) &&
                (!string.IsNullOrEmpty(id_almox.Text)))
            {
                CamadaDados.Almoxarifado.TList_CadItens lItens =
                    CamadaNegocio.Almoxarifado.TCN_CadItens.Buscar(cd_produto.Text,
                                                                   id_almox.Text,
                                                                   string.Empty,
                                                                   string.Empty,
                                                                   string.Empty,
                                                                   null);
                if (lItens.Count > 0)
                {
                    id_rua.Text = lItens[0].Id_ruaString;
                    ds_rua.Text = lItens[0].Ds_rua;
                    id_secao.Text = lItens[0].Id_secaoString;
                    ds_secao.Text = lItens[0].Ds_secao;
                    id_celula.Text = lItens[0].Id_celulastr;
                    ds_celula.Text = lItens[0].Ds_celula;
                }
            }
        }

        private void TFAlocarItem_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            cd_produto.Text = this.Cd_produto;
            ds_produto.Text = this.Ds_produto;
            sigla_unidade.Text = this.Sigla_unidade;
            quantidade.Value = this.Quantidade;
        }

        private void bb_almox_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_almoxarifado|Almoxarifado|150;" +
                              "a.id_almox|Id. Almox.|80";
            string vParam = "|exists|(select 1 from tb_amx_almox_x_empresa x " +
                            "           where x.id_almox = a.id_almox " +
                            "           and x.cd_empresa = '" + Cd_empresa.Trim() + "');" +
                            "|exists|(select 1 from tb_amx_itens y " +
                            "           where y.id_almox = a.id_almox " +
                            "           and y.cd_produto = '" + Cd_produto.Trim() + "')";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { id_almox, ds_almoxarifado },
                                            new CamadaDados.Almoxarifado.TCD_CadAlmoxarifado(), vParam);
            this.BuscarAlocacao();

        }

        private void id_almox_Leave(object sender, EventArgs e)
        {
            string vParam = "a.id_almox|=|" + id_almox.Text + ";" +
                            "|exists|(select 1 from tb_amx_almox_x_empresa x " +
                            "           where x.id_almox = a.id_almox " +
                            "           and x.cd_empresa = '" + Cd_empresa.Trim() + "');" +
                            "|exists|(select 1 from tb_amx_itens y " +
                            "           where y.id_almox = a.id_almox " +
                            "           and y.cd_produto = '" + Cd_produto.Trim() + "')";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { id_almox, ds_almoxarifado },
                                                new CamadaDados.Almoxarifado.TCD_CadAlmoxarifado());
            this.BuscarAlocacao();
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void TFAlocarItem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }
    }
}
