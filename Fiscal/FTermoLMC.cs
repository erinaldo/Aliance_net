using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Fiscal
{
    public partial class TFTermoLMC : Form
    {
        public DateTime? dt_ref
        { get; set; }
        public string Cd_empresa
        { get; set; }
        public string Nm_empresa
        { get; set; }
        public string Cd_produto
        { get; set; }
        
        public DateTime pDt_ref
        { get { return dt_referencia.Value; } }
        public string pCd_empresa
        { get { return CD_Empresa.Text; } }
        public List<CamadaDados.Estoque.Cadastros.TRegistro_CadProduto> lProd
        {
            get
            {
                if (bsProduto.Count > 0)
                    return (bsProduto.List as CamadaDados.Estoque.Cadastros.TList_CadProduto).FindAll(p => p.St_processar);
                else
                    return null;
            }
        }
        public decimal Qtd_paginas
        { get { return qt_paginas.Value; } }
        public decimal Nr_ordem
        { get { return nr_ordem.Value; } }

        public TFTermoLMC()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if (string.IsNullOrEmpty(CD_Empresa.Text))
            {
                MessageBox.Show("Obrigatorio informar empresa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CD_Empresa.Focus();
                return;
            }
            DialogResult = DialogResult.OK;
        }

        private void TFTermoLMC_Load(object sender, EventArgs e)
        {
            Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pDados.set_FormatZero();

            if (dt_ref.HasValue)
                dt_referencia.Value = dt_ref.Value;
            CD_Empresa.Text = Cd_empresa;
            NM_Empresa.Text = Nm_empresa;
            //Buscar combustivel
            bsProduto.DataSource = new CamadaDados.Estoque.Cadastros.TCD_CadProduto().Select(
                                    new Utils.TpBusca[]
                                    {
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "isnull(e.st_combustivel, 'N')",
                                            vOperador = "=",
                                            vVL_Busca = "'S'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = string.Empty,
                                            vOperador = "exists",
                                            vVL_Busca = "(select 1 from tb_pdc_tanque x " +
                                                        "where x.cd_produto = a.cd_produto)"
                                        }
                                    }, 0, string.Empty, string.Empty, string.Empty);
            if ((bsProduto.Count > 0) && (!string.IsNullOrEmpty(Cd_produto)))
                if ((bsProduto.List as CamadaDados.Estoque.Cadastros.TList_CadProduto).Exists(p => p.CD_Produto.Trim().Equals(Cd_produto.Trim())))
                {
                    (bsProduto.List as CamadaDados.Estoque.Cadastros.TList_CadProduto).Find(p => p.CD_Produto.Trim().Equals(Cd_produto.Trim())).St_processar = true;
                    bsProduto.ResetBindings(true);
                }
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void BB_Empresa_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { CD_Empresa, NM_Empresa }, string.Empty);
        }

        private void CD_Empresa_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + CD_Empresa.Text.Trim() + "'",
                                                        new Componentes.EditDefault[] { CD_Empresa, NM_Empresa });
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            afterGrava();
        }

        private void TFTermoLMC_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                DialogResult = DialogResult.Cancel;
        }

        private void dt_referencia_ValueChanged(object sender, EventArgs e)
        {
            qt_paginas.Value = DateTime.DaysInMonth(dt_ref.Value.Year, dt_ref.Value.Month) + 2;
        }

        private void gProduto_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                (bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).St_processar =
                    !(bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).St_processar;
                bsProduto.ResetCurrentItem();
            }
        }
    }
}
