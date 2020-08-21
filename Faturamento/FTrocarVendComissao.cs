using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Faturamento
{
    public partial class TFTrocarVendComissao : Form
    {
        public List<CamadaDados.Faturamento.Comissao.TRegistro_Fechamento_Comissao> lComissao
        {
            get
            {
                if (bsComissao.Count > 0)
                    return (bsComissao.List as CamadaDados.Faturamento.Comissao.TList_Fechamento_Comissao).FindAll(p => p.St_processar);
                else return null;
            }
        }
        public string Cd_vendTransf
        {
            get { return cbVendTransf.SelectedValue == null ? string.Empty : cbVendTransf.SelectedValue.ToString(); }
        }

        public TFTrocarVendComissao()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if (cbVendTransf.SelectedValue == null)
            {
                MessageBox.Show("Obrigatório selecionar vendedor para receber comissão.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbVendTransf.Focus();
                return;
            }
            this.DialogResult = DialogResult.OK;
        }

        private void afterBusca()
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[1];
            filtro[0].vNM_Campo = "a.vl_faturado";
            filtro[0].vOperador = "=";
            filtro[0].vVL_Busca = "0";
            if (!string.IsNullOrEmpty(CD_Empresa.Text))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + CD_Empresa.Text.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(CD_CompVend.Text))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_vendedor";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + CD_CompVend.Text.Trim() + "'";
            }
            if (dt_ini.Text.Trim() != "/  /")
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_lancto)))";
                filtro[filtro.Length - 1].vOperador = ">=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(dt_ini.Text).ToString("yyyyMMdd") + "'";
            }
            if (dt_fin.Text.Trim() != "/  /")
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_lancto)))";
                filtro[filtro.Length - 1].vOperador = "<=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(dt_fin.Text).ToString("yyyyMMdd") + "'";
            }
            bsComissao.DataSource = new CamadaDados.Faturamento.Comissao.TCD_Fechamento_Comissao().Select(filtro, 0, string.Empty);
        }

        private void TFTrocarVendComissao_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pFiltro.set_FormatZero();
            cbVendTransf.DataSource = new CamadaDados.Financeiro.Cadastros.TCD_CadClifor().Select(
                                        new Utils.TpBusca[]
                                        {
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = "isnull(a.st_funcativo, 'N')",
                                                vOperador = "=",
                                                vVL_Busca = "'S'"
                                            },
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = string.Empty,
                                                vOperador = string.Empty,
                                                vVL_Busca = "(isnull(a.st_vendedor, 'N') = 'S') or (isnull(a.st_tecnico, 'N') = 'S') or (isnull(a.st_motorista, 'N') = 'S')"
                                            }
                                        }, 0, string.Empty);
            cbVendTransf.DisplayMember = "nm_clifor";
            cbVendTransf.ValueMember = "cd_clifor";
        }

        private void BB_Empresa_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { CD_Empresa }, string.Empty);
        }

        private void CD_Empresa_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + CD_Empresa.Text.Trim() + "'", new Componentes.EditDefault[] { CD_Empresa });
        }

        private void BB_CompVend_Click(object sender, EventArgs e)
        {
            string vColunas = "a.nm_clifor|Nome Vendedor|200;" +
                              "a.cd_clifor|Cd. Vendedor|80";
            string vParam = "||(isnull(a.st_vendedor, 'N') = 'S') or (isnull(a.st_tecnico, 'N') = 'S') or (isnull(a.st_motorista, 'N') = 'S');" +
                            "isnull(a.st_funcativo, 'N')|=|'S'";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_CompVend },
                new CamadaDados.Financeiro.Cadastros.TCD_CadClifor(),
               vParam);
        }

        private void CD_CompVend_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_clifor|=|'" + CD_CompVend.Text.Trim() + "';" +
                            "||(isnull(a.st_vendedor, 'N') = 'S') or (isnull(a.st_tecnico, 'N') = 'S') or (isnull(a.st_motorista, 'N') = 'S');" +
                            "isnull(a.st_funcativo, 'N')|=|'S'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { CD_CompVend },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void bbBuscar_Click(object sender, EventArgs e)
        {
            this.afterBusca();
        }

        private void gComissao_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                (bsComissao.Current as CamadaDados.Faturamento.Comissao.TRegistro_Fechamento_Comissao).St_processar =
                    !(bsComissao.Current as CamadaDados.Faturamento.Comissao.TRegistro_Fechamento_Comissao).St_processar;
                bsComissao.ResetCurrentItem();
            }
        }

        private void cbProcessarPed_Click(object sender, EventArgs e)
        {
            if (bsComissao.Count > 0)
            {
                (bsComissao.List as CamadaDados.Faturamento.Comissao.TList_Fechamento_Comissao).ForEach(p => p.St_processar = cbProcessarPed.Checked);
                bsComissao.ResetBindings(true);
            }
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void TFTrocarVendComissao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }
    }
}
