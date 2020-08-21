using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Utils;

namespace Locacao
{
    public partial class TFMedicao : Form
    {
        public List<CamadaDados.Locacao.TRegistro_ProdutoItens> lProdutos
        {
            get
            {
                if (bsProdutoItens.Count > 0)
                    return (bsProdutoItens.List as ICollection<CamadaDados.Locacao.TRegistro_ProdutoItens>).Where(x => x.Qt_medida > decimal.Zero).ToList();
                else return null;
            }
        }
        public DateTime pDtMedicao { get { return DateTime.Parse(dt_medicao.Text); } }
        public TFMedicao()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if(!dt_medicao.Text.IsDateTime())
            {
                MessageBox.Show("Obrigatório informar data medição.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dt_medicao.Focus();
                return;
            }
            if(bsProdutoItens.Count.Equals(0))
            {
                MessageBox.Show("Obrigtório selecionar produtos para medição.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            DialogResult = DialogResult.OK;
        }

        private void gGrade_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is DataGridViewTextBoxEditingControl)
                e.Control.KeyPress += Control_KeyPress;
        }

        private void Control_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                e.Handled = true;
        }

        private void gGrade_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            gGrade[e.ColumnIndex, e.RowIndex].Value = decimal.Zero;
            gGrade.EndEdit();
        }

        private void TFMedicao_Load(object sender, EventArgs e)
        {
            Icon = ResourcesUtils.TecnoAliance_ICO;
            cbEmpresa.DataSource = new CamadaDados.Diversos.TCD_CadEmpresa().Select(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = string.Empty,
                                            vOperador = "exists",
                                            vVL_Busca = "(select 1 from tb_div_usuario_x_empresa x " +
                                                        "where x.cd_empresa = a.cd_empresa " +
                                                        "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                                        "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                                        "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))"
                                        }
                                    }, 0, string.Empty);
            cbEmpresa.DisplayMember = "NM_Empresa";
            cbEmpresa.ValueMember = "CD_Empresa";
        }

        private void cbEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbEmpresa.SelectedItem != null)
            {
                cbPatrimonio.DataSource = new CamadaDados.Locacao.TCD_ItensLocTerceiro().Select(
                    new TpBusca[]
                    {
                        new TpBusca
                        {
                            vNM_Campo = "a.cd_empresa",
                            vOperador = "=",
                            vVL_Busca = "'" + (cbEmpresa.SelectedItem as CamadaDados.Diversos.TRegistro_CadEmpresa).Cd_empresa.Trim() + "'"
                        },
                        new TpBusca
                        {
                            vNM_Campo = "isnull(a.st_registro, 'A')",
                            vOperador = "<>",
                            vVL_Busca = "'C'"
                        },
                        new TpBusca
                        {
                            vNM_Campo = string.Empty,
                            vOperador = "exists",
                            vVL_Busca = "(select 1 from tb_loc_locterceiro x " +
                                        "where x.cd_empresa = a.cd_empresa " +
                                        "and x.id_loc = a.id_loc " +
                                        "and isnull(x.st_registro, 'A') = 'A')"
                        }
                    }, 0, string.Empty);
                cbPatrimonio.DisplayMember = "DS_Produto";
                cbPatrimonio.ValueMember = "Ds_patrimonio";
            }
        }

        private void cbPatrimonio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbPatrimonio.SelectedItem != null)
                bsProdutoItens.DataSource = CamadaNegocio.Locacao.TCN_ProdutoItens.Buscar(
                    (cbPatrimonio.SelectedItem as CamadaDados.Locacao.TRegistro_ItensLocTerceiro).Cd_empresa,
                    (cbPatrimonio.SelectedItem as CamadaDados.Locacao.TRegistro_ItensLocTerceiro).Id_locstr,
                    (cbPatrimonio.SelectedItem as CamadaDados.Locacao.TRegistro_ItensLocTerceiro).Id_itemstr,
                    null);
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            afterGrava();
        }

        private void TFMedicao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                DialogResult = DialogResult.Cancel;
        }
    }
}
