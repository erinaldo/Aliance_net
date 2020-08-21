using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FormBusca
{
    public partial class TFCustoProduto : Form
    {
        public string pCd_empresa
        { get; set; }
        public string pNm_empresa
        { get; set; }
        public string pCd_produto
        { get; set; }
        public string pDs_produto
        { get; set; }
        public string pUnd
        { get; set; }

        public TFCustoProduto()
        {
            InitializeComponent();
        }

        private void afterBusca()
        {
            if (!string.IsNullOrEmpty(cd_empresa.Text))
            {
                DataTable tb_estoque = new CamadaDados.Estoque.TCD_LanEstoque().BuscarEstoqueSintetico(
                                    new Utils.TpBusca[]
                                    {
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "a.cd_empresa",
                                            vOperador = "=",
                                            vVL_Busca = "'" + cd_empresa.Text.Trim() + "'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "a.cd_produto",
                                            vOperador = "=",
                                            vVL_Busca = "'" + pCd_produto.Trim() + "'"
                                        }
                                    }, string.Empty, string.Empty);
                if (tb_estoque != null)
                    if (tb_estoque.Rows.Count > 0)
                    {
                        qtd_estoque.Value = decimal.Parse(tb_estoque.Rows[0]["Tot_Saldo"].ToString());
                        vl_ultimacompra.Value = decimal.Parse(tb_estoque.Rows[0]["vl_ultimacompra"].ToString());
                        vl_medio.Value = decimal.Parse(tb_estoque.Rows[0]["Vl_Medio"].ToString());
                    }
            }
        }

        private void TFCustoProduto_Load(object sender, EventArgs e)
        {
            pDados.set_FormatZero();
            cd_empresa.Text = pCd_empresa;
            nm_empresa.Text = pNm_empresa;
            cd_produto.Text = pCd_produto;
            ds_produto.Text = pDs_produto;
            und.Text = pUnd;
            cd_empresa.Enabled = string.IsNullOrEmpty(pCd_empresa);
            bb_empresa.Enabled = string.IsNullOrEmpty(pCd_empresa);
            this.afterBusca();
        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { cd_empresa, nm_empresa }, string.Empty);
            this.afterBusca();
        }

        private void cd_empresa_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "'", new Componentes.EditDefault[] { cd_empresa, nm_empresa });
            this.afterBusca();
        }
    }
}
