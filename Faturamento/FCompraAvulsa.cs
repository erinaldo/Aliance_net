using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Faturamento
{
    public partial class TFCompraAvulsa : Form
    {
        private CamadaDados.Faturamento.CompraAvulsa.TRegistro_CompraAvulsa rcompra;
        public CamadaDados.Faturamento.CompraAvulsa.TRegistro_CompraAvulsa rCompra
        { 
            get { return bsCompraAvulsa.Current as CamadaDados.Faturamento.CompraAvulsa.TRegistro_CompraAvulsa; }
            set { rcompra = value; }
        }

        public TFCompraAvulsa()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if (pDados.validarCampoObrigatorio())
                DialogResult = DialogResult.OK;
        }

        private void InserirItem()
        {
            using (TFItemCompraAvulsa fItem = new TFItemCompraAvulsa())
            {
                fItem.CD_Empresa = cd_empresa.Text;
                fItem.Nm_empresa = nm_empresa.Text;
                if(fItem.ShowDialog() == DialogResult.OK)
                    if (fItem.rItem != null)
                    {
                        (bsCompraAvulsa.Current as CamadaDados.Faturamento.CompraAvulsa.TRegistro_CompraAvulsa).lItens.Add(fItem.rItem);
                        bsCompraAvulsa.ResetCurrentItem();
                        TotalizarCompra();
                    }
            }
        }

        private void ExcluirItem()
        {
            if (bsItensCompra.Current != null)
                if (MessageBox.Show("Confirma exclusão do item selecionado?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                     MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    if((bsItensCompra.Current as CamadaDados.Faturamento.CompraAvulsa.TRegistro_Compra_Itens).Id_itemcompra.HasValue)
                        (bsCompraAvulsa.Current as CamadaDados.Faturamento.CompraAvulsa.TRegistro_CompraAvulsa).lItensDel.Add(
                            bsItensCompra.Current as CamadaDados.Faturamento.CompraAvulsa.TRegistro_Compra_Itens);
                    bsItensCompra.RemoveCurrent();
                    TotalizarCompra();
                }
        }

        private void BuscarEndereco()
        {
            if (!string.IsNullOrEmpty(cd_clifor.Text))
            {
                CamadaDados.Financeiro.Cadastros.TList_CadEndereco lEnd =
                    CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Buscar(cd_clifor.Text,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              1,
                                                                              null);
                if (lEnd.Count > 0)
                {
                    cd_endereco.Text = lEnd[0].Cd_endereco;
                    ds_endereco.Text = lEnd[0].Ds_endereco;
                }
            }
        }

        private void TotalizarCompra()
        {
            if (bsCompraAvulsa.Current != null)
            {
                tot_itens.Value = (bsCompraAvulsa.Current as CamadaDados.Faturamento.CompraAvulsa.TRegistro_CompraAvulsa).lItens.Sum(p => p.Vl_subtotal);
                if ((bsCompraAvulsa.Current as CamadaDados.Faturamento.CompraAvulsa.TRegistro_CompraAvulsa).lItens.Count > 0)
                    if ((bsCompraAvulsa.Current as CamadaDados.Faturamento.CompraAvulsa.TRegistro_CompraAvulsa).lItens.Exists(p => p.Pc_desconto > decimal.Zero))
                        Pc_DescGeral.Value = (bsCompraAvulsa.Current as CamadaDados.Faturamento.CompraAvulsa.TRegistro_CompraAvulsa).lItens.Where(p => p.Pc_desconto > decimal.Zero).Average(p => p.Pc_desconto);
                        if ((bsCompraAvulsa.Current as CamadaDados.Faturamento.CompraAvulsa.TRegistro_CompraAvulsa).lItens.Count > 0)
                            Vl_despesas_Geral.Value = (bsCompraAvulsa.Current as CamadaDados.Faturamento.CompraAvulsa.TRegistro_CompraAvulsa).lItens.Sum(p => p.Vl_despesas);
                        else
                            Vl_despesas_Geral.Value = decimal.Zero;
                   
                        Pc_DescGeral.Value = decimal.Zero;
              
                    Pc_DescGeral.Value = decimal.Zero;
                VL_Desconto_Geral.Value = (bsCompraAvulsa.Current as CamadaDados.Faturamento.CompraAvulsa.TRegistro_CompraAvulsa).lItens.Sum(p => p.Vl_desconto);
                bsCompraAvulsa.ResetCurrentItem();
            }
        }

        private void TFCompraAvulsa_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gItensCompra);
            Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pDados.set_FormatZero();
            if (rcompra != null)
            {
                bsCompraAvulsa.DataSource = new CamadaDados.Faturamento.CompraAvulsa.TList_CompraAvulsa() { rcompra };
                cd_empresa.Enabled = false;
                bb_empresa.Enabled = false;
            }
            else
                bsCompraAvulsa.AddNew();
        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { cd_empresa, nm_empresa }, string.Empty);
        }

        private void btn_Deleta_Item_Click(object sender, EventArgs e)
        {
            ExcluirItem();
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void cd_empresa_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "'",
                                                    new Componentes.EditDefault[] { cd_empresa, nm_empresa });
        }

        private void bb_clifor_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_clifor, nm_clifor }, string.Empty);
            BuscarEndereco();
        }

        private void cd_clifor_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + cd_clifor.Text.Trim() + "'",
                                                    new Componentes.EditDefault[] { cd_clifor, nm_clifor },
                                                    new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
            BuscarEndereco();
        }

        private void bb_endereco_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_endereco|Endereço|200;"+
                              "a.cd_endereco|Codigo|80";
            string vParam = "a.cd_clifor|=|'" + cd_clifor.Text.Trim() + "'";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_endereco, ds_endereco },
                                            new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco(),
                                            vParam);
        }

        private void cd_endereco_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_clifor|=|'" + cd_clifor.Text.Trim() + "';" +
                            "a.cd_endereco|=|'" + cd_endereco.Text.Trim() + "'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_endereco, ds_endereco },
                                            new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco());
        }

        private void btn_Inserir_Item_Click(object sender, EventArgs e)
        {
            InserirItem();
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            afterGrava();
        }

        private void TFCompraAvulsa_KeyDown(object sender, KeyEventArgs e)
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

        private void Pc_DescGeral_Leave(object sender, EventArgs e)
        {
            if (bsCompraAvulsa.Current != null)
            {
                (bsCompraAvulsa.Current as CamadaDados.Faturamento.CompraAvulsa.TRegistro_CompraAvulsa).Pc_desconto = Pc_DescGeral.Value;
                CamadaNegocio.Faturamento.CompraAvulsa.TCN_CompraAvulsa.RatearDesconto(bsCompraAvulsa.Current as CamadaDados.Faturamento.CompraAvulsa.TRegistro_CompraAvulsa, true);
                TotalizarCompra();
            }
        }

        private void VL_Desconto_Geral_Leave(object sender, EventArgs e)
        {
            if (bsCompraAvulsa.Current != null)
            {
                (bsCompraAvulsa.Current as CamadaDados.Faturamento.CompraAvulsa.TRegistro_CompraAvulsa).Vl_desconto = VL_Desconto_Geral.Value;
                CamadaNegocio.Faturamento.CompraAvulsa.TCN_CompraAvulsa.RatearDesconto(bsCompraAvulsa.Current as CamadaDados.Faturamento.CompraAvulsa.TRegistro_CompraAvulsa, false);
                TotalizarCompra();
            }
        }

        private void Vl_despesas_Geral_Leave(object sender, EventArgs e)
        {
            if (bsCompraAvulsa.Current != null)
            {
                (bsCompraAvulsa.Current as CamadaDados.Faturamento.CompraAvulsa.TRegistro_CompraAvulsa).Vl_despesas = Vl_despesas_Geral.Value;
                TotalizarCompra();
            }
        }

        private void TFCompraAvulsa_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gItensCompra);
        }
    }
}
