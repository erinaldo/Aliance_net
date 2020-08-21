using System;
using System.Windows.Forms;
using FormBusca;

namespace Faturamento
{
    public partial class TFPromocao : Form
    {
        private CamadaDados.Faturamento.Promocao.TRegistro_PromocaoVenda rpromocao;
        public CamadaDados.Faturamento.Promocao.TRegistro_PromocaoVenda rPromocao
        {
            get
            {
                if (bsPromocao.Current != null)
                    return bsPromocao.Current as CamadaDados.Faturamento.Promocao.TRegistro_PromocaoVenda;
                else
                    return null;
            }
            set
            {
                rpromocao = value;
            }
        }

        public TFPromocao()
        {
            InitializeComponent();
            System.Collections.ArrayList cbx = new System.Collections.ArrayList();
            cbx.Add(new Utils.TDataCombo("ATIVA", "A"));
            cbx.Add(new Utils.TDataCombo("FINALIZADA", "F"));
            st_registro.DataSource = cbx;
            st_registro.DisplayMember = "Display";
            st_registro.ValueMember = "Value";
        }

        private void afterGrava()
        {
            if (pDados.validarCampoObrigatorio())
                DialogResult = DialogResult.OK;
        }

        private void InserirItem()
        {
            if (bsPromocao.Current != null)
                using (TFGrupoPromocao fGrupo = new TFGrupoPromocao())
                {
                    if(fGrupo.ShowDialog() == DialogResult.OK)
                        if (fGrupo.rGrupo != null)
                        {
                            if (!string.IsNullOrEmpty(fGrupo.rGrupo.Cd_grupo))
                            {
                                if ((bsPromocao.Current as CamadaDados.Faturamento.Promocao.TRegistro_PromocaoVenda).lGrupo.Exists(
                                  p => p.Cd_grupo.Trim().Equals(fGrupo.rGrupo.Cd_grupo.Trim())))
                                {
                                    (bsPromocao.Current as CamadaDados.Faturamento.Promocao.TRegistro_PromocaoVenda).lGrupo.Find(
                                        p => p.Cd_grupo.Trim().Equals(fGrupo.rGrupo.Cd_grupo.Trim())).Tp_promocao = fGrupo.rGrupo.Tp_promocao;
                                    (bsPromocao.Current as CamadaDados.Faturamento.Promocao.TRegistro_PromocaoVenda).lGrupo.Find(
                                        p => p.Cd_grupo.Trim().Equals(fGrupo.rGrupo.Cd_grupo.Trim())).Vl_promocao = fGrupo.rGrupo.Vl_promocao;
                                    (bsPromocao.Current as CamadaDados.Faturamento.Promocao.TRegistro_PromocaoVenda).lGrupo.Find(
                                        p => p.Cd_grupo.Trim().Equals(fGrupo.rGrupo.Cd_grupo.Trim())).Qtd_minimavenda = fGrupo.rGrupo.Qtd_minimavenda;
                                }
                                else
                                    (bsPromocao.Current as CamadaDados.Faturamento.Promocao.TRegistro_PromocaoVenda).lGrupo.Add(fGrupo.rGrupo);
                            }
                            if(!string.IsNullOrEmpty(fGrupo.rGrupo.Cd_produto))
                            {
                                if ((bsPromocao.Current as CamadaDados.Faturamento.Promocao.TRegistro_PromocaoVenda).lGrupo.Exists(
                                  p => p.Cd_produto.Trim().Equals(fGrupo.rGrupo.Cd_produto.Trim())))
                                {
                                    (bsPromocao.Current as CamadaDados.Faturamento.Promocao.TRegistro_PromocaoVenda).lGrupo.Find(
                                        p => p.Cd_produto.Trim().Equals(fGrupo.rGrupo.Cd_produto.Trim())).Tp_promocao = fGrupo.rGrupo.Tp_promocao;
                                    (bsPromocao.Current as CamadaDados.Faturamento.Promocao.TRegistro_PromocaoVenda).lGrupo.Find(
                                        p => p.Cd_produto.Trim().Equals(fGrupo.rGrupo.Cd_produto.Trim())).Vl_promocao = fGrupo.rGrupo.Vl_promocao;
                                    (bsPromocao.Current as CamadaDados.Faturamento.Promocao.TRegistro_PromocaoVenda).lGrupo.Find(
                                        p => p.Cd_produto.Trim().Equals(fGrupo.rGrupo.Cd_produto.Trim())).Qtd_minimavenda = fGrupo.rGrupo.Qtd_minimavenda;
                                }
                                else
                                    (bsPromocao.Current as CamadaDados.Faturamento.Promocao.TRegistro_PromocaoVenda).lGrupo.Add(fGrupo.rGrupo);
                            }
                            bsPromocao.ResetCurrentItem();
                        }
                }
            else
                MessageBox.Show("Não existe promoção para inserir grupo.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ExcluirItem()
        {
            if (bsGrupo.Current != null)
            {
                (bsPromocao.Current as CamadaDados.Faturamento.Promocao.TRegistro_PromocaoVenda).lGrupoDel.Add(
                    bsGrupo.Current as CamadaDados.Faturamento.Promocao.TRegistro_Promocao_X_Grupo);
                bsGrupo.RemoveCurrent();
            }
            else
                MessageBox.Show("Não existe grupo selecionado para excluir.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BB_Empresa_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { CD_Empresa, NM_Empresa }, string.Empty);
        }

        private void CD_Empresa_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + CD_Empresa.Text.Trim() + "'", new Componentes.EditDefault[] { CD_Empresa, NM_Empresa });
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btn_Inserir_Item_Click(object sender, EventArgs e)
        {
            InserirItem();
        }

        private void btn_Deleta_Item_Click(object sender, EventArgs e)
        {
            ExcluirItem();
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            afterGrava();
        }

        private void TFPromocao_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, dataGridDefault1);
            Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pDados.set_FormatZero();
            if (rpromocao != null)
            {
                bsPromocao.DataSource = new CamadaDados.Faturamento.Promocao.TList_PromocaoVenda() { rpromocao };
                CD_Empresa.Enabled = false;
                BB_Empresa.Enabled = false;
                ds_promocao.Focus();
            }
            else
            {
                bsPromocao.AddNew();
                st_registro.Enabled = false;
                bsPromocao.ResetCurrentItem();
            }
        }

        private void TFPromocao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                DialogResult = DialogResult.Cancel;
            else if (e.Control && e.KeyCode.Equals(Keys.F10))
                InserirItem();
            else if (e.Control && e.KeyCode.Equals(Keys.F12))
                ExcluirItem();
        }

        private void CD_Empresa_TextChanged(object sender, EventArgs e)
        {

        }

        private void NM_Empresa_TextChanged(object sender, EventArgs e)
        {

        }

        private void TFPromocao_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, dataGridDefault1);
        }
    }
}
