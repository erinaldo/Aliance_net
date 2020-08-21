using CamadaDados.Locacao;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Utils;

namespace Locacao
{
    public partial class TFVendaItensCargaAvulsa : Form
    {
        private CamadaDados.Diversos.TList_CfgEmpresa lCfgEmpresa { get; set; }
        public List<TRegistro_AbastItens> lItens
        {
            get
            {
                if (bsItensAbast.Count > 0)
                    return (bsItensAbast.DataSource as TList_AbastItens).FindAll(p => p.St_processar);
                else
                    return null; 
            }
        }
        public string Cd_empresa
        { get { return cbEmpresa.SelectedValue.ToString(); } }

        public TFVendaItensCargaAvulsa()
        {
            InitializeComponent();
            Height = Screen.PrimaryScreen.Bounds.Height - (Screen.PrimaryScreen.Bounds.Height / 10) * 1;
            Width = Screen.PrimaryScreen.Bounds.Width - (Screen.PrimaryScreen.Bounds.Width / 10) * 1;
        }

        private void afterGrava()
        {
            this.DialogResult = DialogResult.OK;
        }

        private void afterBusca()
        {
            if (cbEmpresa.SelectedValue == null)
            {
                MessageBox.Show("Obrigatorio informar empresa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbEmpresa.Focus();
                return;
            }
            TpBusca[] filtro = new TpBusca[1];

            //Retirar Itens Faturados
            filtro[0].vNM_Campo = string.Empty;
            filtro[0].vOperador = "not exists";
            filtro[0].vVL_Busca = "(select 1 from TB_LOC_AbastItens_X_NFCeItens x " +
                                  "where x.cd_empresa = a.cd_empresa " +
                                  "and x.id_loc = a.id_loc " +
                                  "and x.id_item = a.id_item " +
                                  "and x.id_carga = a.id_carga " +
                                  "and x.id_itemcarga = a.id_itemcarga) ";
            if (!string.IsNullOrEmpty(id_carga.Text))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_carga";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = id_carga.Text;
            }
            if (!string.IsNullOrEmpty(cd_produto.Text))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "b.cd_produto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + cd_produto.Text.Trim() + "'";
            }
            //Empresa
            if (cbEmpresa.SelectedValue != null)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + cbEmpresa.SelectedValue.ToString() + "'";
            }
            if (dt_ini.Text.Trim() != "/  /")
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_abast)))";
                filtro[filtro.Length - 1].vOperador = ">=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(dt_ini.Text).ToString("yyyyMMdd")) + "'";
            }
            if (dt_fin.Text.Trim() != "/  /")
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_abast)))";
                filtro[filtro.Length - 1].vOperador = "<=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(dt_fin.Text).ToString("yyyyMMdd")) + "'";
            }
            bsItensAbast.DataSource = new TCD_AbastItens().Select(filtro, 0, string.Empty);
            tot_venda.Value = (bsItensAbast.List as TList_AbastItens).Sum(p => p.Vl_subtotal);
        }

        private void TFVendaItensCargaAvulsa_Load(object sender, EventArgs e)
        {
            Icon = ResourcesUtils.TecnoAliance_ICO;
            //Buscar Empresa
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
            //Buscar CFG Empresa
            lCfgEmpresa =
            CamadaNegocio.Diversos.TCN_CfgEmpresa.Buscar(cbEmpresa.SelectedValue.ToString(), null);
            if (lCfgEmpresa.Count.Equals(0))
            {
                MessageBox.Show("Não existe configuração parâmetro Empresa: " + cbEmpresa.SelectedValue.ToString(), "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.Cancel;
                return;
            }
        }

        private void cbProcessar_Click(object sender, EventArgs e)
        {
            if (bsItensAbast.Count > 0)
            {
                (bsItensAbast.DataSource as TList_AbastItens).ForEach(p => p.St_processar = cbProcessar.Checked);
                tot_cupom.Value = (bsItensAbast.DataSource as TList_AbastItens).Where(p => p.St_processar).Sum(p => p.Vl_subtotal);
                bsItensAbast.ResetBindings(true);
            }
        }

        private void gItens_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                (bsItensAbast.Current as TRegistro_AbastItens).St_processar =
                    !(bsItensAbast.Current as TRegistro_AbastItens).St_processar;
                bsItensAbast.ResetCurrentItem();
                if (bsItensAbast.Count > 0)
                    tot_cupom.Value = (bsItensAbast.DataSource as TList_AbastItens).Where(p => p.St_processar).Sum(p => p.Vl_subtotal);
            }
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            afterGrava();
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            afterBusca();
        }

        private void TFVendaItensCargaAvulsa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.DialogResult = DialogResult.OK;
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
            else if (e.KeyCode.Equals(Keys.F7))
                this.afterBusca();
        }

        private void cd_produto_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LEAVEProduto("a.cd_produto|=|'" + cd_produto.Text.Trim() + "'",
                                                   new Componentes.EditDefault[] { cd_produto },
                                                   new CamadaDados.Estoque.Cadastros.TCD_CadProduto());
        }

        private void bb_produto_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaProduto(new Componentes.EditDefault[] { cd_produto }, string.Empty);
        }
    }
}
