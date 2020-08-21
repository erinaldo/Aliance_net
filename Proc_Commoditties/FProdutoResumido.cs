using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Utils;
using CamadaDados.Estoque.Cadastros;
using FormBusca;
using Componentes;
using CamadaDados.Fiscal;

namespace Proc_Commoditties
{
    public partial class TFProdutoResumido : Form
    {
        private TRegistro_CadProduto _produto;

        public TRegistro_CadProduto Produto
        {
            get
            {
                if (!string.IsNullOrEmpty(codigobarra.Text))
                    (bsProduto.Current as TRegistro_CadProduto).lCodBarra.Add(new TRegistro_CodBarra { Cd_codbarra = codigobarra.Text });
                return bsProduto.Current as TRegistro_CadProduto;
            }
            set { _produto = value; }
        }

        public TFProdutoResumido()
        {
            InitializeComponent();
            System.Collections.ArrayList cbx = new System.Collections.ArrayList();
            cbx.Add(new TDataCombo("MERCADORIA PARA REVENDA", "00"));
            cbx.Add(new TDataCombo("MATERIA-PRIMA", "01"));
            cbx.Add(new TDataCombo("EMBALAGEM", "02"));
            cbx.Add(new TDataCombo("PRODUTO EM PROCESSO", "03"));
            cbx.Add(new TDataCombo("PRODUTO ACABADO", "04"));
            cbx.Add(new TDataCombo("SUBPRODUTO", "05"));
            cbx.Add(new TDataCombo("PRODUTO INTERMEDIARIO", "06"));
            cbx.Add(new TDataCombo("MATERIAL DE USO E CONSUMO", "07"));
            cbx.Add(new TDataCombo("ATIVO IMOBILIZADO", "08"));
            cbx.Add(new TDataCombo("SERVICOS", "09"));
            cbx.Add(new TDataCombo("OUTROS INSUMOS", "10"));
            cbx.Add(new TDataCombo("OUTRAS", "99"));
            tp_item.DataSource = cbx;
            tp_item.ValueMember = "Value";
            tp_item.DisplayMember = "Display";
        }

        private void afterGrava()
        {
            if (pDadosProd.validarCampoObrigatorio())
                DialogResult = DialogResult.OK;
        }

        private void TFProdutoResumido_Load(object sender, EventArgs e)
        {
            Icon = ResourcesUtils.TecnoAliance_ICO;
            if (_produto != null)
            {
                bsProduto.DataSource = new TList_CadProduto { _produto };
                bsProduto.ResetCurrentItem();
                //Buscar codigo barras
                object obj = new TCD_CodBarra().BuscarEscalar(new TpBusca[] { new TpBusca { vNM_Campo = "a.cd_produto", vOperador = "=", vVL_Busca = "'" + _produto.CD_Produto.Trim() + "'" } }, "a.cd_codbarra");
                if (obj != null)
                    codigobarra.Text = obj.ToString();
            }
            else bsProduto.AddNew();
        }

        private void BB_GrupoProduto_Click(object sender, EventArgs e)
        {
            string vColunas = "a.DS_Grupo|Descrição Grupo Produto|350;" +
                              "a.CD_Grupo|Cód. Grupo|100";
            string vParamFixo = "a.TP_Grupo|=|'A'";
            UtilPesquisa.BTN_BUSCA(vColunas, new EditDefault[] { CD_Grupo, DS_Grupo },
                                    new TCD_CadGrupoProduto(), vParamFixo);
        }

        private void CD_Grupo_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.CD_Grupo|=|'" + CD_Grupo.Text + "';" +
                              "a.TP_Grupo|=|'A'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new EditDefault[] { CD_Grupo, DS_Grupo },
                                    new TCD_CadGrupoProduto());
        }

        private void BB_CondFiscalProduto_Click(object sender, EventArgs e)
        {
            string vColunas = "DS_CondFiscal_Produto|Condição Fiscal|350;" +
                              "CD_CondFiscal_Produto|Cód. Cond. Fiscal|100";
            UtilPesquisa.BTN_BUSCA(vColunas, new EditDefault[] { CD_CondFiscal_Produto, ds_condfiscal_produto },
                                    new TCD_CadCondFiscalProduto(), "");
        }

        private void CD_CondFiscal_Produto_Leave(object sender, EventArgs e)
        {
            string vColunas = "CD_CondFiscal_Produto|=|'" + CD_CondFiscal_Produto.Text + "'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new EditDefault[] { CD_CondFiscal_Produto, ds_condfiscal_produto },
                                    new TCD_CadCondFiscalProduto());
        }

        private void BB_TpProduto_Click(object sender, EventArgs e)
        {
            string vColunas = "DS_TPProduto|Tipo Produto|350;" +
                              "TP_Produto|Cód. TPProduto|100;" +
                              "ST_Servico|Servico|80;" +
                              "ST_Composto|Composto|80;" +
                              "ST_MPrima|Materia Prima|80;" +
                              "ST_Embalagem|Embalagem|80;" +
                              "ST_RegAnvisa|Farmacêutico|80";
            DataRowView linha = UtilPesquisa.BTN_BUSCA(vColunas, new EditDefault[] { TP_Produto, ds_tpproduto },
                                    new TCD_CadTpProduto(), string.Empty);
        }

        private void TP_Produto_Leave(object sender, EventArgs e)
        {
            string vColunas = "TP_Produto|=|'" + TP_Produto.Text + "'";
            DataRow linha = UtilPesquisa.EDIT_LEAVE(vColunas, new EditDefault[] { TP_Produto, ds_tpproduto },
                                    new TCD_CadTpProduto());
        }

        private void BB_Unidade_Click(object sender, EventArgs e)
        {
            string vColunas = "DS_Unidade|Descrição Unidade|350;" +
                              "CD_Unidade|Cód. Unidade|100;" +
                              "Sigla_Unidade|Sigla|80";
            UtilPesquisa.BTN_BUSCA(vColunas, new EditDefault[] { CD_Unidade, ds_unidade, sigla_unidade },
                                    new TCD_CadUnidade(), string.Empty);
        }

        private void CD_Unidade_Leave(object sender, EventArgs e)
        {
            string vColunas = "CD_Unidade|=|'" + CD_Unidade.Text + "'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new EditDefault[] { CD_Unidade, ds_unidade, sigla_unidade },
                                    new TCD_CadUnidade());
        }

        private void bb_ncm_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_ncm|Descrição NCM|250;" +
                              "a.ncm|NCM|80";
            UtilPesquisa.BTN_BUSCA(vColunas, new EditDefault[] { ncm, ds_ncm },
                                    new TCD_CadNCM(), string.Empty);
        }

        private void ncm_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(ncm.Text))
            {
                EditDefault cadNcm = new EditDefault();
                cadNcm.Text = ncm.Text;
                string vColunas = "a.ncm|=|'" + ncm.Text.Trim() + "'";
                DataRow linha = UtilPesquisa.EDIT_LEAVE(vColunas, new EditDefault[] { ncm, ds_ncm },
                                        new TCD_CadNCM());
                if (linha == null)
                {
                    if (cadNcm.Text.SoNumero().Trim().Length != 8)
                    {
                        MessageBox.Show("NCM incorreto!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    InputBox ibp = new InputBox();
                    ibp.Text = "NCM";
                    string ds = ibp.ShowDialog();
                    if (string.IsNullOrEmpty(ds))
                    {
                        MessageBox.Show("Obrigatorio informar descrição NCM.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    try
                    {
                        CamadaNegocio.Fiscal.TCN_CadNCM.GravarNCM(
                            new CamadaDados.Fiscal.TRegistro_CadNCM()
                            {
                                NCM = cadNcm.Text,
                                Ds_NCM = ds
                            });
                        MessageBox.Show("NCM gravado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ncm.Text = cadNcm.Text;
                        ds_ncm.Text = ds;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            afterGrava();
        }

        private void TFProdutoResumido_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                DialogResult = DialogResult.Cancel;
        }

        private void bb_saldoest_Click(object sender, EventArgs e)
        {

            using (Proc_Commoditties.TFSaldoEstPrecoVenda fSaldo = new Proc_Commoditties.TFSaldoEstPrecoVenda())
            {
                //  fSaldo.pSt_servico = st_servico.Checked;
                if (fSaldo.ShowDialog() == DialogResult.OK)
                {
                    if (!string.IsNullOrEmpty(fSaldo.Cd_local))
                    {
                        CamadaDados.Estoque.TRegistro_LanEstoque rEstoque = new CamadaDados.Estoque.TRegistro_LanEstoque();
                        rEstoque.Cd_empresa = fSaldo.Cd_empresa;
                        rEstoque.Cd_local = fSaldo.Cd_local;
                        rEstoque.Dt_lancto = CamadaDados.UtilData.Data_Servidor();
                        rEstoque.Tp_movimento = "E";
                        rEstoque.Qtd_entrada = fSaldo.Quantidade;
                        rEstoque.Qtd_saida = decimal.Zero;
                        rEstoque.Vl_unitario = fSaldo.Vl_unitario;
                        rEstoque.Vl_subtotal = fSaldo.Quantidade * fSaldo.Vl_unitario;
                        rEstoque.Tp_lancto = "M";
                        rEstoque.St_registro = "A";
                        (bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).vl_unitario = rEstoque.Vl_unitario;
                        (bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).rSaldoEst = rEstoque;
                    }
                    if (!string.IsNullOrEmpty(fSaldo.Cd_tabelapreco))
                    {
                        string[] tabela = fSaldo.Cd_tabelapreco.Split(new char[] { ';' });
                        for (int i = 0; tabela.Count() > i; i++)
                        {
                            CamadaDados.Estoque.TRegistro_LanPrecoItem rPreco = new CamadaDados.Estoque.TRegistro_LanPrecoItem();
                            rPreco.CD_Empresa = fSaldo.Cd_empresa;
                            rPreco.CD_TabelaPreco = tabela[i];
                            rPreco.Dt_preco = CamadaDados.UtilData.Data_Servidor();
                            rPreco.VL_PrecoVenda = fSaldo.Vl_precovenda;
                            (bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).vl_unitario = rPreco.VL_PrecoVenda;
                            (bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).lPrecoItem.Add(rPreco);
                        }
                    }
                }
            }
        }

        private void btn_Marca_Click(object sender, EventArgs e)
        {
            string vColunas = "a.DS_Marca|Descrição Marca|350;" +
                              "a.CD_Marca|Cód. Marca|100";
            string vParamFixo = "";
            UtilPesquisa.BTN_BUSCA(vColunas, new EditDefault[] { CD_Marca, DS_Marca },
                                    new TCD_CadMarca(), vParamFixo);
        }

        private void CD_Marca_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.CD_Marca|=|'" + CD_Marca.Text + "'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new EditDefault[] { CD_Marca, DS_Marca },
                                    new TCD_CadMarca());
        }
    }
}
