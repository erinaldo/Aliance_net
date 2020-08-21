using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Proc_Commoditties
{
    public partial class TFContingenciaNFCeOFF : Form
    {
        public List<CamadaDados.Faturamento.Cadastros.TRegistro_PontoVenda> lPDV
        {
            get
            {
                if (bsPDV.Count > 0)
                    return (bsPDV.List as CamadaDados.Faturamento.Cadastros.TList_PontoVenda).FindAll(p => p.St_processar);
                else return null;
            }
        }
        public string pCd_empresa
        { get { return cd_empresa.Text; } }
        public string pJustificativa
        { get { return justificativa.Text.Trim(); } }

        public TFContingenciaNFCeOFF()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if (bsPDV.Count.Equals(0))
            {
                MessageBox.Show("Não existe PDV disponivel para configurar CONTINGENCIA.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (!(bsPDV.List as CamadaDados.Faturamento.Cadastros.TList_PontoVenda).Exists(p => p.St_processar))
            {
                MessageBox.Show("Obrigatorio selecionar PDV para configurar CONTINGENCIA.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrEmpty(cd_empresa.Text))
            {
                MessageBox.Show("Obrigatorio informar empresa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cd_empresa.Focus();
                return;
            }
            if (justificativa.Text.Trim().Length < 15)
            {
                MessageBox.Show("Obrigatorio informar pelo menos 15 caracteres como JUSTIFICATIVA.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                justificativa.Focus();
                return;
            }
            DialogResult = DialogResult.OK;
        }

        private void TFContingenciaNFCeOFF_Load(object sender, EventArgs e)
        {
            Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pDados.set_FormatZero();
            bsPDV.DataSource = new CamadaDados.Faturamento.Cadastros.TCD_PontoVenda().Select(
                                new Utils.TpBusca[]
                                {
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = "isnull(a.st_registro, 'A')",
                                        vOperador = "<>",
                                        vVL_Busca = "'C'"
                                    },
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = string.Empty,
                                        vOperador = "not exists",
                                        vVL_Busca = "(select 1 from tb_pdv_contingencianfceoff x " +
                                                    "where x.id_pdv = a.id_pdv " +
                                                    "and isnull(x.st_registro, 'A') <> 'F')"
                                    }
                                }, 0, string.Empty);
        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { cd_empresa, nm_empresa }, string.Empty);
        }

        private void cd_empresa_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "'", new Componentes.EditDefault[] { cd_empresa, nm_empresa });
        }

        private void cbTodos_Click(object sender, EventArgs e)
        {
            if (bsPDV.Count > 0)
            {
                (bsPDV.List as CamadaDados.Faturamento.Cadastros.TList_PontoVenda).FindAll(p => p.St_processar = cbTodos.Checked);
                bsPDV.ResetBindings(true);
            }
        }

        private void gPDV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (bsPDV.Current != null)
            {
                (bsPDV.Current as CamadaDados.Faturamento.Cadastros.TRegistro_PontoVenda).St_processar =
                    !(bsPDV.Current as CamadaDados.Faturamento.Cadastros.TRegistro_PontoVenda).St_processar;
                bsPDV.ResetCurrentItem();
            }
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            afterGrava();
        }

        private void TFContingenciaNFCeOFF_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                DialogResult = DialogResult.Cancel;
        }

        private void justificativa_TextChanged(object sender, EventArgs e)
        {
            lblTotCaracteres.Text = "Total Caracteres " + justificativa.Text.Trim().Length.ToString();
        }
    }
}
