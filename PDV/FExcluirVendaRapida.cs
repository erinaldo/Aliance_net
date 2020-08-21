using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace PDV
{
    public partial class TFExcluirVendaRapida : Form
    {
        public List<CamadaDados.Faturamento.PDV.TRegistro_VendaRapida> lVenda
        {
            get
            {
                if (bsVenda.Count > 0)
                    return (bsVenda.DataSource as CamadaDados.Faturamento.PDV.TList_VendaRapida).FindAll(p => p.St_processar);
                else return null;
            }
        }

        public TFExcluirVendaRapida()
        {
            InitializeComponent();
        }

        private void afterBusca()
        {
            if (cbEmpresa.SelectedItem == null)
            {
                MessageBox.Show("Obrigatorio informar empresa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbEmpresa.Focus();
                return;
            }
            Utils.TpBusca[] filtro = new Utils.TpBusca[4];

            //Venda Ativa
            filtro[0].vNM_Campo = "isnull(a.st_registro, 'A')";
            filtro[0].vOperador = "<>";
            filtro[0].vVL_Busca = "'C'";
            //Nao ter gerado cupom 
            filtro[1].vNM_Campo = string.Empty;
            filtro[1].vOperador = "not exists";
            filtro[1].vVL_Busca = "(select 1 from TB_PDV_Cupom_X_VendaRapida x " +
                                  "inner join tb_pdv_nfce y " +
                                  "on x.cd_empresa = y.cd_empresa " +
                                  "and x.id_cupom = y.id_nfce " +
                                  "where x.cd_empresa = a.cd_empresa " +
                                  "and x.id_vendarapida = a.id_vendarapida " +
                                  "and isnull(y.st_registro, 'A') <> 'C')";
            //Nao ter gerado pedido
            filtro[2].vNM_Campo = string.Empty;
            filtro[2].vOperador = "not exists";
            filtro[2].vVL_Busca = "(select 1 from TB_PDV_Pedido_X_VendaRapida x " +
                                  "where x.cd_empresa = a.cd_empresa " +
                                  "and x.id_vendarapida = a.id_cupom)";
            //Empresa
            filtro[3].vNM_Campo = "a.cd_empresa";
            filtro[3].vOperador = "=";
            filtro[3].vVL_Busca = "'" + cbEmpresa.SelectedValue.ToString() + "'";
            if (!string.IsNullOrEmpty(id_cupom.Text))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_cupom";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = id_cupom.Text;
            }
            //Cliente
            if (!string.IsNullOrEmpty(cd_clifor.Text))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_clifor";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + cd_clifor.Text.Trim() + "'";
            }
            if (dt_ini.Text.Trim() != "/  /")
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.dt_emissao";
                filtro[filtro.Length - 1].vOperador = ">=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(dt_ini.Text).ToString("yyyyMMdd")) + " 00:00:00'";
            }
            if (dt_fin.Text.Trim() != "/  /")
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.dt_emissao";
                filtro[filtro.Length - 1].vOperador = "<=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(dt_fin.Text).ToString("yyyyMMdd")) + " 23:59:59'";
            }
            if (!string.IsNullOrEmpty(id_prevenda.Text))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = "exists";
                filtro[filtro.Length - 1].vVL_Busca = "(select 1 from tb_pdv_prevenda_x_vendarapida x " +
                                                      "where x.cd_empresa = a.cd_empresa " +
                                                      "and x.id_cupom = a.id_cupom " +
                                                      "and x.id_prevenda = " + id_prevenda.Text + ")";
            }
            bsVenda.DataSource = new CamadaDados.Faturamento.PDV.TCD_VendaRapida().Select(filtro, 0, string.Empty, string.Empty);
        }

        private void TFExcluirVendaRapida_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gVenda);
            Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pFiltro.set_FormatZero();
            //Buscar Empresa
            cbEmpresa.DataSource = new CamadaDados.Diversos.TCD_CadEmpresa().Select(
                                    new Utils.TpBusca[]
                                    {
                                        new Utils.TpBusca()
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
            cbEmpresa.DisplayMember = "nm_empresa";
            cbEmpresa.ValueMember = "cd_empresa";
        }

        private void BB_Clifor_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_clifor, nm_clifor }, string.Empty);
        }

        private void cd_clifor_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + cd_clifor.Text.Trim() + "'",
                                                    new Componentes.EditDefault[] { cd_clifor, nm_clifor },
                                                    new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void cbProcessar_Click(object sender, EventArgs e)
        {
            if (bsVenda.Count > 0)
            {
                (bsVenda.List as CamadaDados.Faturamento.PDV.TList_VendaRapida).ForEach(p => p.St_processar = cbProcessar.Checked);
                bsVenda.ResetBindings(true);
            }
        }

        private void gVenda_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                (bsVenda.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida).St_processar =
                    !(bsVenda.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida).St_processar;
                bsVenda.ResetCurrentItem();
            }
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            afterBusca();
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void TFExcluirVendaRapida_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                DialogResult = DialogResult.OK;
            else if (e.KeyCode.Equals(Keys.F6))
                DialogResult = DialogResult.Cancel;
            else if (e.KeyCode.Equals(Keys.F7))
                afterBusca();
        }

        private void TFExcluirVendaRapida_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gVenda);
        }
    }
}
