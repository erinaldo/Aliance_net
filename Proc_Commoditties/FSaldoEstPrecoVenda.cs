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
    public partial class TFSaldoEstPrecoVenda : Form
    {
        public bool pSt_servico
        { get; set; }
        private string pCd_empresa;
        public string Cd_empresa
        { get { return cd_empresa.Text; } set { pCd_empresa = value; } }

        public string Cd_local
        { get { return cd_local.Text; } }

        public decimal Quantidade
        { get { return quantidade.Value; } }

        public decimal Vl_unitario
        { get { return vl_unitario.Value; } }

        private string CD_tabelapreco;
        public string Cd_tabelapreco
        {
            get
            {
                string ret = string.Empty;
                if ((bsTabPreco.DataSource as CamadaDados.Diversos.TList_CadTbPreco).Exists(p => p.St_processar))
                {
                    (bsTabPreco.DataSource as CamadaDados.Diversos.TList_CadTbPreco).FindAll(p => p.St_processar).ForEach(p =>
                     {
                         ret += p.CD_TabelaPreco + ";";
                     });
                    return ret.TrimEnd(';');
                }
                else return ret;
            }
            set { CD_tabelapreco = value; }
        }

        public decimal Vl_precovenda
        { get { return vl_precovenda.Value; } }

        public TFSaldoEstPrecoVenda()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if (string.IsNullOrEmpty(cd_empresa.Text))
            {
                MessageBox.Show("Obrigatorio informar empresa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cd_empresa.Focus();
                return;
            }
            if (!string.IsNullOrEmpty(cd_local.Text) && !pSt_servico)
            {
                if (quantidade.Value.Equals(decimal.Zero))
                {
                    MessageBox.Show("Obrigatorio informar quantidade.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    quantidade.Focus();
                    return;
                }
                if (vl_unitario.Value.Equals(decimal.Zero))
                {
                    MessageBox.Show("Obrigatorio informar valor custo.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    vl_unitario.Focus();
                    return;
                }
            }
            if ((bsTabPreco.DataSource as CamadaDados.Diversos.TList_CadTbPreco).Exists(p=> p.St_processar) && vl_precovenda.Value.Equals(decimal.Zero))
            {
                MessageBox.Show("Obrigatorio informar preço de venda.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                vl_precovenda.Focus();
                return;
            }
            this.DialogResult = DialogResult.OK;
        }

        private void FSaldoEstPrecoVenda_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pSaldoEstoque.set_FormatZero();
            cd_empresa.Text = pCd_empresa;
            cd_empresa_Leave(this, new EventArgs());
            bsTabPreco.DataSource = CamadaNegocio.Diversos.TCN_CadTbPreco.Busca(string.Empty, string.Empty, string.Empty);
            (bsTabPreco.DataSource as CamadaDados.Diversos.TList_CadTbPreco).ForEach(p=>
            {
                if (p.CD_TabelaPreco.Equals(CD_tabelapreco))
                    p.St_processar = true;
            });
            bsTabPreco.ResetCurrentItem();
        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { cd_empresa, nm_empresa }, string.Empty);
        }

        private void cd_empresa_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "'", new Componentes.EditDefault[] { cd_empresa, nm_empresa });
        }

        private void bb_local_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BUSCA("a.DS_Local|Local|300;a.CD_Local|Código|80",
                                               new Componentes.EditDefault[] { cd_local, ds_local },
                                               new CamadaDados.Estoque.Cadastros.TCD_CadLocalArm(string.Empty, cd_empresa.Text), string.Empty);
        }

        private void cd_local_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LEAVE("a.CD_Local|=|'" + cd_local.Text.Trim() + "'",
                                                new Componentes.EditDefault[] { cd_local, ds_local },
                                                new CamadaDados.Estoque.Cadastros.TCD_CadLocalArm(string.Empty, cd_empresa.Text));
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void quantidade_Leave(object sender, EventArgs e)
        {
            vl_subtotal.Value = quantidade.Value * vl_unitario.Value;
        }

        private void vl_unitario_Leave(object sender, EventArgs e)
        {
            vl_subtotal.Value = quantidade.Value * vl_unitario.Value;
        }

        private void TFSaldoEstPrecoVenda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }

        private void cbTodos_Click(object sender, EventArgs e)
        {
            if (bsTabPreco.Count > 0)
            {
                (bsTabPreco.DataSource as CamadaDados.Diversos.TList_CadTbPreco).ForEach(p => p.St_processar = cbTodos.Checked);
                bsTabPreco.ResetBindings(true);
            }
        }

        private void gTabPreco_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                (bsTabPreco.Current as CamadaDados.Diversos.TRegistro_CadTbPreco).St_processar =
                    !(bsTabPreco.Current as CamadaDados.Diversos.TRegistro_CadTbPreco).St_processar;
                bsTabPreco.ResetCurrentItem();
            }
        }
    }
}
