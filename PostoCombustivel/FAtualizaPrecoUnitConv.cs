using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PostoCombustivel
{
    public partial class TFAtualizaPrecoUnitConv : Form
    {
        public List<CamadaDados.PostoCombustivel.TRegistro_Convenio_Clifor> lConvCli
        {
            get
            {
                if (bsConvClifor.Count > 0)
                    return (bsConvClifor.List as CamadaDados.PostoCombustivel.TList_Convenio_Clifor).FindAll(p => p.St_processar);
                else return null;
            }
        }

        public TFAtualizaPrecoUnitConv()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if (bsConvClifor.Count > 0)
                if ((bsConvClifor.List as CamadaDados.PostoCombustivel.TList_Convenio_Clifor).Exists(p => p.St_processar) &&
                    (pc_ajuste.Value > decimal.Zero ||
                    st_placaconveniada.Checked ||
                    st_motconveniado.Checked ||
                    st_exigirrequisicao.Checked ||
                    st_nomeMot.Checked ||
                    st_faturardireto.Checked))
                {
                    if ((bsConvClifor.List as CamadaDados.PostoCombustivel.TList_Convenio_Clifor).Exists(p => p.St_processar && p.Vl_unitario.Equals(decimal.Zero)) &&
                        tp_ajuste.SelectedIndex.Equals(0))
                        if (MessageBox.Show("Convênios com valor unitario igual a zero não serão atualizados utilizando percentual.\r\n" +
                                            "Deseja continuar?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) != DialogResult.Yes)
                            return;
                    (bsConvClifor.List as CamadaDados.PostoCombustivel.TList_Convenio_Clifor).FindAll(p => p.St_processar).ForEach(p=>
                        {
                            if(somar_diminuir.SelectedIndex.Equals(0))
                                p.Vl_unitario += tp_ajuste.SelectedIndex.Equals(0) ? Math.Round(decimal.Divide(decimal.Multiply(p.Vl_unitario, pc_ajuste.Value), 100), 3, MidpointRounding.AwayFromZero) : pc_ajuste.Value;
                            else p.Vl_unitario -= tp_ajuste.SelectedIndex.Equals(0) ? Math.Round(decimal.Divide(decimal.Multiply(p.Vl_unitario, pc_ajuste.Value), 100), 3, MidpointRounding.AwayFromZero) : pc_ajuste.Value;
                            if (st_placaconveniada.Checked)
                                p.St_placaconveniadabool = true;
                            if (st_motconveniado.Checked)
                                p.St_motconveniadobool = true;
                            if (st_exigirrequisicao.Checked)
                                p.St_exigirrequisicaobool = true;
                            if (st_nomeMot.Checked)
                                p.St_exigirnomemotbool = true;
                            if (st_faturardireto.Checked)
                                p.St_faturardiretobool = true;
                        });
                    DialogResult = DialogResult.OK;
                }
                else
                    MessageBox.Show("Obrigatorio informar pelo menos uma alteração.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void afterBusca()
        {
            if (string.IsNullOrEmpty(cd_empresa.Text))
            {
                MessageBox.Show("Obrigatorio informar empresa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cd_empresa.Focus();
                return;
            }
            Utils.TpBusca[] filtro = new Utils.TpBusca[1];
            filtro[0].vNM_Campo = "a.cd_empresa";
            filtro[0].vOperador = "=";
            filtro[0].vVL_Busca = "'" + cd_empresa.Text.Trim() + "'";
            if (!string.IsNullOrEmpty(cd_clifor.Text))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_clifor";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + cd_clifor.Text.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(cd_produto.Text))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_produto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + cd_produto.Text.Trim() + "'";
            }
            if (vl_ini.Value > decimal.Zero)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.vl_unitario";
                filtro[filtro.Length - 1].vOperador = ">=";
                filtro[filtro.Length - 1].vVL_Busca = vl_ini.Value.ToString(new System.Globalization.CultureInfo("en-US", true));
            }
            if (vl_fin.Value > decimal.Zero)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.vl_unitario";
                filtro[filtro.Length - 1].vOperador = "<=";
                filtro[filtro.Length - 1].vVL_Busca = vl_fin.Value.ToString(new System.Globalization.CultureInfo("en-US", true));
            }
            bsConvClifor.DataSource = new CamadaDados.PostoCombustivel.TCD_Convenio_Clifor().Select(filtro, 0, string.Empty);
        }

        private void TFAtualizaPrecoUnitConv_Load(object sender, EventArgs e)
        {
            Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pFiltro.set_FormatZero();
            tp_ajuste.SelectedIndex = 0;
            somar_diminuir.SelectedIndex = 0;
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

        private void bb_clifor_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_clifor }, string.Empty);
        }

        private void cd_clifor_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + cd_clifor.Text.Trim() + "'",
                new Componentes.EditDefault[] { cd_clifor }, new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void bb_produto_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaProduto(new Componentes.EditDefault[] { cd_produto }, "isnull(e.st_combustivel, 'N')|=|'S'");
        }

        private void cd_produto_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LEAVEProduto("a.cd_produto|=|'" + cd_produto.Text.Trim() + ";" +
                                                     "isnull(e.st_combustivel, 'N')|=|'S'",
                                                     new Componentes.EditDefault[] { cd_produto },
                                                     new CamadaDados.Estoque.Cadastros.TCD_CadProduto());
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            afterBusca();
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            afterGrava();
        }

        private void TFAtualizaPrecoUnitConv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                DialogResult = DialogResult.Cancel;
            else if (e.KeyCode.Equals(Keys.F7))
                afterBusca();
        }

        private void gConvClifor_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                (bsConvClifor.Current as CamadaDados.PostoCombustivel.TRegistro_Convenio_Clifor).St_processar =
                    !(bsConvClifor.Current as CamadaDados.PostoCombustivel.TRegistro_Convenio_Clifor).St_processar;
                bsConvClifor.ResetCurrentItem();
            }
        }

        private void cbTodos_Click(object sender, EventArgs e)
        {
            if (bsConvClifor.Count > 0)
            {
                (bsConvClifor.List as CamadaDados.PostoCombustivel.TList_Convenio_Clifor).ForEach(p => p.St_processar = cbTodos.Checked);
                bsConvClifor.ResetBindings(true);
            }
        }
    }
}
