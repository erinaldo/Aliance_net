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
    public partial class FLocalizarOsLote : Form
    {
        public string Cd_empresa
        { get; set; }
        public string Nm_empresa
        { get; set; }
        public List<CamadaDados.Servicos.TRegistro_LanServico> lOs
        {
            get
            {
                return (bsOs.DataSource as CamadaDados.Servicos.TList_LanServico).FindAll(p => p.St_Lote);
            }
        }

        public FLocalizarOsLote()
        {
            InitializeComponent();
        }

        private void afterBusca()
        {
            if (tp_ordem.Text.Trim() != string.Empty)
            {
                Utils.TpBusca[] filtro = new Utils.TpBusca[5];
                //Status da OS
                filtro[0].vNM_Campo = "a.st_os";
                filtro[0].vOperador = "=";
                filtro[0].vVL_Busca = "'AB'";
                //Empresa
                filtro[1].vNM_Campo = "a.cd_empresa";
                filtro[1].vOperador = "=";
                filtro[1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
                //Tipo Ordem
                filtro[2].vNM_Campo = "a.tp_ordem";
                filtro[2].vOperador = "=";
                filtro[2].vVL_Busca = "'" + tp_ordem.Text.Trim() + "'";
                //Etapa Ordem
                filtro[3].vNM_Campo = string.Empty;
                filtro[3].vOperador = "exists";
                filtro[3].vVL_Busca = "(select 1 from tb_ose_evolucao x " +
                                        "inner join tb_ose_etapaordem y " +
                                        "on x.id_etapa = y.id_etapa " +
                                        "where x.cd_empresa = a.cd_empresa " +
                                        "and x.id_os = a.id_os " +
                                        "and isnull(x.st_evolucao, 'A') = 'A' " +
                                        "and isnull(y.st_envterceiro, 'N') = 'S')";
                //Nao estar amarrado a um lote
                filtro[4].vNM_Campo = string.Empty;
                filtro[4].vOperador = "not exists";
                filtro[4].vVL_Busca = "(select 1 from tb_ose_lote_x_servico x " +
                                        "where x.cd_empresa = a.cd_empresa " +
                                        "and x.id_os = a.id_os)";
                if (CD_Produto_Busca.Text.Trim() != string.Empty)
                {
                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[filtro.Length - 1].vNM_Campo = "a.cd_produtoos";
                    filtro[filtro.Length - 1].vOperador = "=";
                    filtro[filtro.Length - 1].vVL_Busca = "'" + CD_Produto_Busca.Text.Trim() + "'";
                }
                if (CD_Clifor_Busca.Text.Trim() != string.Empty)
                {
                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[filtro.Length - 1].vNM_Campo = "a.cd_clifor";
                    filtro[filtro.Length - 1].vOperador = "=";
                    filtro[filtro.Length - 1].vVL_Busca = "'" + CD_Clifor_Busca.Text.Trim() + "'";
                }
                if ((DT_Inic.Text.Trim() != string.Empty) && (DT_Inic.Text.Trim() != "/  /"))
                {
                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[filtro.Length - 1].vNM_Campo = "a.dt_abertura";
                    filtro[filtro.Length - 1].vOperador = ">=";
                    filtro[filtro.Length - 1].vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(DT_Inic.Text).ToString("yyyyMMdd")) + " 00:00:00'";
                }
                if ((DT_Final.Text.Trim() != string.Empty) && (DT_Final.Text.Trim() != "/  /"))
                {
                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[filtro.Length - 1].vNM_Campo = "a.dt_abertura";
                    filtro[filtro.Length - 1].vOperador = "<=";
                    filtro[filtro.Length - 1].vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(DT_Final.Text).ToString("yyyyMMdd")) + " 23:59:59'";
                }

                bsOs.DataSource = new CamadaDados.Servicos.TCD_LanServico().Select(filtro, 0, string.Empty, string.Empty);
            }
            else
                MessageBox.Show("Obrigatorio informar tipo de ordem serviço.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void FLocalizarOsLote_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, dataGridDefault3);
            panelDados6.BackColor = Utils.SettingsUtils.Default.COLOR_1;
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pFiltro.set_FormatZero();
            cd_empresa.Text = Cd_empresa;
            nm_empresa.Text = Nm_empresa;
            tp_ordem.Focus();
        }

        private void dataGridDefault3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                (bsOs.Current as CamadaDados.Servicos.TRegistro_LanServico).St_Lote =
                    !(bsOs.Current as CamadaDados.Servicos.TRegistro_LanServico).St_Lote;
                bsOs.ResetCurrentItem();
            }
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void FLocalizarOsLote_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.DialogResult = DialogResult.OK;
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
            else if (e.KeyCode.Equals(Keys.F7))
                this.afterBusca();
        }

        private void bb_tpordem_Click(object sender, EventArgs e)
        {
            string vColunas = "DS_TipoOrdem|Tipo Ordem|200;" +
                              "TP_Ordem|TP. Ordem|80";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { tp_ordem },
                                            new CamadaDados.Servicos.Cadastros.TCD_TpOrdem(), string.Empty);
        }

        private void tp_ordem_Leave(object sender, EventArgs e)
        {
            string vColunas = "tp_ordem|=|" + tp_ordem.Text.Trim();
            FormBusca.UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { tp_ordem },
                new CamadaDados.Servicos.Cadastros.TCD_TpOrdem());
        }

        private void BB_Clifor_Busca_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { CD_Clifor_Busca }, string.Empty);
        }

        private void CD_Clifor_Busca_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_clifor|=|'" + CD_Clifor_Busca.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { CD_Clifor_Busca },
                new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void BB_Produto_Busca_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaProduto(new Componentes.EditDefault[] { CD_Produto_Busca }, string.Empty);
        }

        private void CD_Produto_Busca_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVEProduto("a.cd_produto|=|'" + CD_Produto_Busca.Text.Trim() + "'",
                new Componentes.EditDefault[] { CD_Produto_Busca }, new CamadaDados.Estoque.Cadastros.TCD_CadProduto());
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            this.afterBusca();
        }

        private void FLocalizarOsLote_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, dataGridDefault3);
        }
    }
}
