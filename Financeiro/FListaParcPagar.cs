using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Financeiro
{
    public partial class TFListaParcPagar : Form
    {
        public string pCd_empresa
        { get; set; }
        public List<CamadaDados.Financeiro.Duplicata.TRegistro_LanParcela> lParc
        {
            get
            {
                if (bsParcela.Count > 0)
                    return (bsParcela.List as CamadaDados.Financeiro.Duplicata.TList_RegLanParcela).FindAll(p => p.St_processar);
                else return null;
            }
        }

        public TFListaParcPagar()
        {
            InitializeComponent();
        }

        private void afterBusca()
        {
            if (string.IsNullOrEmpty(CD_Empresa.Text))
            {
                MessageBox.Show("Obrigatorio informar empresa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CD_Empresa.Focus();
                return;
            }
            Utils.TpBusca[] filtro = new Utils.TpBusca[5];
            //Empresa
            filtro[0].vNM_Campo = "a.cd_empresa";
            filtro[0].vOperador = "=";
            filtro[0].vVL_Busca = "'" + CD_Empresa.Text.Trim() + "'";
            //Tipo Movimento
            filtro[1].vNM_Campo = "a.tp_mov";
            filtro[1].vOperador = "=";
            filtro[1].vVL_Busca = "'P'";
            //Status
            filtro[2].vNM_Campo = "isnull(a.st_registro, 'A')";
            filtro[2].vOperador = "<>";
            filtro[2].vVL_Busca = "'L'";
            //Status
            filtro[3].vNM_Campo = "isnull(a.st_registro, 'A')";
            filtro[3].vOperador = "<>";
            filtro[3].vVL_Busca = "'G'";
            //Status
            filtro[4].vNM_Campo = "isnull(dup.st_registro, 'A')";
            filtro[4].vOperador = "<>";
            filtro[4].vVL_Busca = "'C'";
            if (!string.IsNullOrEmpty(NR_Docto.Text))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_docto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + NR_Docto.Text.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(nr_lancto.Text))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_lancto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = nr_lancto.Text;
            }
            if (!string.IsNullOrEmpty(CD_Clifor.Text))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_clifor";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + CD_Clifor.Text.Trim() + "'";
            }
            if (DT_Inicial.Text.Trim() != "/  /")
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), " + (RB_Emissao.Checked ? "a.dt_emissao" : "a.dt_vencto") + ")))";
                filtro[filtro.Length - 1].vOperador = ">=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Convert.ToDateTime(DT_Inicial.Text).ToString("yyyyMMdd") + "'";
            }
            if (DT_Final.Text.Trim() != "/  /")
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), " + (RB_Emissao.Checked ? "a.dt_emissao" : "a.dt_vencto") + ")))";
                filtro[filtro.Length - 1].vOperador = "<=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Convert.ToDateTime(DT_Final.Text).ToString("yyyyMMdd") + "'";
            }
            bsParcela.DataSource = new CamadaDados.Financeiro.Duplicata.TCD_LanParcela().Select(filtro, 0, string.Empty, string.Empty, string.Empty);
        }

        private void TFListaParcPagar_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pFiltro.set_FormatZero();
            CD_Empresa.Text = pCd_empresa;
            CD_Empresa.Enabled = string.IsNullOrEmpty(pCd_empresa);
            BB_Empresa.Enabled = string.IsNullOrEmpty(pCd_empresa);
        }

        private void cbTodos_Click(object sender, EventArgs e)
        {
            if (bsParcela.Count > 0)
            {
                (bsParcela.List as CamadaDados.Financeiro.Duplicata.TList_RegLanParcela).ForEach(p => p.St_processar = cbTodos.Checked);
                bsParcela.ResetBindings(true);
            }
        }

        private void gParcela_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                (bsParcela.Current as CamadaDados.Financeiro.Duplicata.TRegistro_LanParcela).St_processar =
                    !(bsParcela.Current as CamadaDados.Financeiro.Duplicata.TRegistro_LanParcela).St_processar;
                bsParcela.ResetCurrentItem();
            }
        }

        private void BB_Empresa_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { CD_Empresa }, string.Empty);
        }

        private void CD_Empresa_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + CD_Empresa.Text.Trim() + "'", new Componentes.EditDefault[] { CD_Empresa });
        }

        private void BB_Clifor_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { CD_Clifor }, string.Empty);
        }

        private void CD_Clifor_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + CD_Clifor.Text.Trim() + "'",
                new Componentes.EditDefault[] { CD_Clifor }, new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void TFListaParcPagar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.DialogResult = DialogResult.OK;
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
            else if (e.KeyCode.Equals(Keys.F7))
                this.afterBusca();
        }

        private void bb_buscar_Click(object sender, EventArgs e)
        {
            this.afterBusca();
        }
    }
}
