using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utils;

namespace Balanca
{
    public partial class TFPsDiversasAplicar : Form
    {
        public List<CamadaDados.Balanca.TRegistro_PesagemDiversas> lPsDiversas
        {
            get
            {
                if (bsPsDiversas.Count > 0)
                    return (bsPsDiversas.List as CamadaDados.Balanca.TList_PesagemDiversas).FindAll(p => p.St_processar);
                else return null;
            }
        }

        public TFPsDiversasAplicar()
        {
            InitializeComponent();
        }

        private void afterBusca()
        {
            if (string.IsNullOrEmpty(cd_empresa.Text))
            {
                MessageBox.Show("Obrigatório informar empresa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cd_empresa.Focus();
                return;
            }
            if (string.IsNullOrEmpty(CD_Clifor.Text))
            {
                MessageBox.Show("Obrigatório informar cliente.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CD_Clifor.Focus();
                return;
            }
            if (string.IsNullOrEmpty(cd_produto.Text))
            {
                MessageBox.Show("Obrigatório informar produto.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cd_produto.Focus();
                return;
            }
            TpBusca[] filtro = new TpBusca[6];
            filtro[0].vNM_Campo = "a.cd_empresa";
            filtro[0].vOperador = "=";
            filtro[0].vVL_Busca = "'" + cd_empresa.Text.Trim() + "'";
            filtro[1].vNM_Campo = "a.cd_clifor";
            filtro[1].vOperador = "=";
            filtro[1].vVL_Busca = "'" + CD_Clifor.Text.Trim() + "'";
            filtro[2].vNM_Campo = "a.cd_produto";
            filtro[2].vOperador = "=";
            filtro[2].vVL_Busca = "'" + cd_produto.Text.Trim() + "'";
            filtro[3].vNM_Campo = "isnull(a.st_registro, 'A')";
            filtro[3].vOperador = "=";
            filtro[3].vVL_Busca = "'F'";
            filtro[4].vNM_Campo = "a.tp_movimento";
            filtro[4].vOperador = "=";
            filtro[4].vVL_Busca = rbEntrada.Checked ? "'E'" : "'S'";
            filtro[5].vNM_Campo = "a.nr_lanctofiscal";
            filtro[5].vOperador = "is";
            filtro[5].vVL_Busca = "null";
            if (!string.IsNullOrEmpty(dt_ini.Text.SoNumero()))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), case when a.tp_movimento = 'E' then a.dt_bruto else a.dt_tara end)))";
                filtro[filtro.Length - 1].vOperador = ">=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(dt_ini.Text).ToString("yyyyMMdd") + "'";
            }
            if (!string.IsNullOrEmpty(dt_fin.Text.SoNumero()))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), case when a.tp_movimento = 'E' then a.dt_bruto else a.dt_tara end)))";
                filtro[filtro.Length - 1].vOperador = "<=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(dt_fin.Text).ToString("yyyyMMdd") + "'";
            }
            bsPsDiversas.DataSource = new CamadaDados.Balanca.TCD_PesagemDiversas().Select(filtro, 0, string.Empty);
            tot_psdisponivel.Text = (bsPsDiversas.List as CamadaDados.Balanca.TList_PesagemDiversas).Sum(p => p.Ps_liquidobruto).ToString("N0", new System.Globalization.CultureInfo("pt-BR"));
        }

        private void TFPsDiversasAplicar_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pFiltro.set_FormatZero();
        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { cd_empresa }, string.Empty);
        }

        private void cd_empresa_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "'",
                new Componentes.EditDefault[] { cd_empresa });
        }

        private void bbCliente_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { CD_Clifor }, string.Empty);
        }

        private void CD_Clifor_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + CD_Clifor.Text.Trim() + "'",
                new Componentes.EditDefault[] { CD_Clifor }, new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void bbProduto_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaProduto(new Componentes.EditDefault[] { cd_produto }, string.Empty);
        }

        private void cd_produto_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LEAVEProduto("a.cd_produto|=|'" + cd_produto.Text.Trim() + "'",
                new Componentes.EditDefault[] { cd_produto }, new CamadaDados.Estoque.Cadastros.TCD_CadProduto());
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            this.afterBusca();
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void TFPsDiversasAplicar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.DialogResult = DialogResult.OK;
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
            else if (e.KeyCode.Equals(Keys.F7))
                this.afterBusca();
        }

        private void cbTodos_Click(object sender, EventArgs e)
        {
            if (bsPsDiversas.Count > 0)
            {
                (bsPsDiversas.List as CamadaDados.Balanca.TList_PesagemDiversas).ForEach(p => p.St_processar = cbTodos.Checked);
                bsPsDiversas.ResetBindings(true);
                tot_psaplicar.Text = (bsPsDiversas.List as CamadaDados.Balanca.TList_PesagemDiversas).Where(p => p.St_processar).Sum(p => p.Ps_liquidobruto).ToString("N0", new System.Globalization.CultureInfo("pt-BR"));
            }
        }

        private void gPsDiversas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                (bsPsDiversas.Current as CamadaDados.Balanca.TRegistro_PesagemDiversas).St_processar =
                    !(bsPsDiversas.Current as CamadaDados.Balanca.TRegistro_PesagemDiversas).St_processar;
                bsPsDiversas.ResetCurrentItem();
                tot_psaplicar.Text = (bsPsDiversas.List as CamadaDados.Balanca.TList_PesagemDiversas).Where(p => p.St_processar).Sum(p => p.Ps_liquidobruto).ToString("N0", new System.Globalization.CultureInfo("pt-BR"));
            }
        }
    }
}
