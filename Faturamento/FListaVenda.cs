using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Faturamento
{
    public partial class TFListaVenda : Form
    {
        public List<CamadaDados.Faturamento.PDV.TRegistro_VendaRapida> lVenda
        {
            get
            {
                if (bsVenda.Count > 0)
                    return (bsVenda.List as CamadaDados.Faturamento.PDV.TList_VendaRapida).FindAll(p => p.St_processar);
                else return null;
            }
        }

        public TFListaVenda()
        {
            InitializeComponent();
        }

        private void afterBusca()
        {
            bsVenda.DataSource = CamadaNegocio.Faturamento.PDV.TCN_VendaRapida.Buscar(string.Empty,
                                                                                      cbEmpresa.SelectedValue == null ? string.Empty : cbEmpresa.SelectedValue.ToString(),
                                                                                      cd_vendedor.Text,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      dt_ini.Text,
                                                                                      dt_fin.Text,
                                                                                      decimal.Zero,
                                                                                      decimal.Zero,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      "'A'",
                                                                                      0,
                                                                                      null);
        }

        private void TFListaVenda_Load(object sender, EventArgs e)
        {
            Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
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
            cbEmpresa.DisplayMember = "NM_Empresa";
            cbEmpresa.ValueMember = "CD_Empresa";
        }

        private void bbvendedor_Click(object sender, EventArgs e)
        {
            string vColunas = "a.nm_clifor|Nome Vendedor|200;" +
                              "a.cd_clifor|Cd. Vendedor|80";
            string vParam = "||(isnull(a.st_vendedor, 'N') = 'S') or (isnull(a.st_tecnico, 'N') = 'S');" +
                            "isnull(a.st_funcativo, 'N')|=|'S'";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_vendedor, nm_vendedor },
                new CamadaDados.Financeiro.Cadastros.TCD_CadClifor(),
               vParam);
        }

        private void cd_vendedor_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_clifor|=|'" + cd_vendedor.Text.Trim() + "';" +
                            "||(isnull(a.st_vendedor, 'N') = 'S') or (isnull(a.st_tecnico, 'N') = 'S');" +
                            "isnull(a.st_funcativo, 'N')|=|'S'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_vendedor, nm_vendedor },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void bbBuscar_Click(object sender, EventArgs e)
        {
            afterBusca();
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void TFListaVenda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                DialogResult = DialogResult.OK;
            else if (e.KeyCode.Equals(Keys.F6))
                DialogResult = DialogResult.Cancel;
            else if (e.KeyCode.Equals(Keys.F7))
                afterBusca();
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

        private void cbTodos_Click(object sender, EventArgs e)
        {
            if (bsVenda.Count > 0)
            {
                (bsVenda.List as CamadaDados.Faturamento.PDV.TList_VendaRapida).ForEach(p => p.St_processar = cbTodos.Checked);
                bsVenda.ResetBindings(true);
            }
        }
    }
}
