using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FormBusca;

namespace Servicos
{
    public partial class TFLocalizarOsDevFornec : Form
    {
        public string Cd_empresa
        { get; set; }
        public string Nm_empresa
        { get; set; }
        public string Cd_fornecedor
        { get; set; }
        public string Nm_fornecedor
        { get; set; }

        public List<CamadaDados.Servicos.TRegistro_LanServico> lOs
        {
            get
            {
                return (bsOs.DataSource as CamadaDados.Servicos.TList_LanServico).FindAll(p => p.St_Lote);
            }
        }

        public TFLocalizarOsDevFornec()
        {
            InitializeComponent();
            this.Cd_empresa = string.Empty;
            this.Nm_empresa = string.Empty;
            this.Cd_fornecedor = string.Empty;
            this.Nm_fornecedor = string.Empty;
        }

        private void afterBusca()
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[4];
            //Status da OS
            filtro[0].vNM_Campo = "a.st_os";
            filtro[0].vOperador = "=";
            filtro[0].vVL_Busca = "'AB'";
            //Empresa
            filtro[1].vNM_Campo = "a.cd_empresa";
            filtro[1].vOperador = "=";
            filtro[1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            //Pertencer a um lote do fornecedor e o lote tem que estar processado
            filtro[2].vNM_Campo = string.Empty;
            filtro[2].vOperador = "exists";
            filtro[2].vVL_Busca = "(select 1 from tb_ose_lote_x_servico x " +
                                  "inner join tb_ose_lote y " +
                                  "on x.cd_empresa = y.cd_empresa " +
                                  "and x.id_lote = y.id_lote " +
                                  "where x.cd_empresa = a.cd_empresa " +
                                  "and x.id_os = a.id_os " +
                                  "and y.cd_fornecedor = '" + cd_fornecedor.Text.Trim() + "' " +
                                  "and isnull(y.st_registro, 'A') = 'P')";
            //Etapa Ordem Envio Terceiro
            filtro[3].vNM_Campo = string.Empty;
            filtro[3].vOperador = "exists";
            filtro[3].vVL_Busca = "(select 1 from tb_ose_evolucao x " +
                                    "inner join tb_ose_etapaordem y " +
                                    "on x.id_etapa = y.id_etapa " +
                                    "where x.cd_empresa = a.cd_empresa " +
                                    "and x.id_os = a.id_os " +
                                    "and isnull(x.st_evolucao, 'A') = 'A' " +
                                    "and isnull(y.st_envterceiro, 'N') = 'S')";
            if (cd_produto.Text.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_produtoos";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + cd_produto.Text.Trim() + "'";
            }
            if (nr_nfremessa.Text.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = "exists";
                filtro[filtro.Length - 1].vVL_Busca = "(select 1 from tb_ose_lote_x_servico x " +
                                                      "inner join tb_ose_lote y " +
                                                      "on x.cd_empresa = y.cd_empresa " +
                                                      "and x.id_lote = y.id_lote " +
                                                      "inner join tb_fat_notafiscal_item z " +
                                                      "on y.nr_pedido = z.nr_pedido " +
                                                      "inner join tb_fat_notafiscal w " +
                                                      "on z.cd_empresa = w.cd_empresa " +
                                                      "and z.nr_lanctofiscal = w.nr_lanctofiscal " +
                                                      "where x.cd_empresa = a.cd_empresa " +
                                                      "and x.id_os = a.id_os " +
                                                      "and w.nr_notafiscal = " + nr_nfremessa.Text.Trim() + ")";
            }
            bsOs.DataSource = new CamadaDados.Servicos.TCD_LanServico().Select(filtro, 0, string.Empty, string.Empty);
        }

        private void TFLocalizarOsDevFornec_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gOs);
            panelDados6.BackColor = Utils.SettingsUtils.Default.COLOR_1;
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pFiltro.set_FormatZero();
            cd_empresa.Text = this.Cd_empresa;
            nm_empresa.Text = this.Nm_empresa;
            cd_fornecedor.Text = this.Cd_fornecedor;
            nm_fornecedor.Text = this.Nm_fornecedor;
        }

        private void bb_produto_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaProduto(new Componentes.EditDefault[] { cd_produto }, string.Empty);
        }

        private void cd_produto_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVEProduto("a.cd_produto|=|'" + cd_produto.Text.Trim() + "'",
                new Componentes.EditDefault[] { cd_produto }, new CamadaDados.Estoque.Cadastros.TCD_CadProduto());
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            this.afterBusca();
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void gOs_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                (bsOs.Current as CamadaDados.Servicos.TRegistro_LanServico).St_Lote =
                    !(bsOs.Current as CamadaDados.Servicos.TRegistro_LanServico).St_Lote;
                bsOs.ResetCurrentItem();
            }
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void TFLocalizarOsDevFornec_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.DialogResult = DialogResult.OK;
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
            else if (e.KeyCode.Equals(Keys.F7))
                this.afterBusca();
        }

        private void TFLocalizarOsDevFornec_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gOs);
        }
    }
}
