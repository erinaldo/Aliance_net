using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FormBusca;
using Utils;

namespace Proc_Commoditties
{
    public partial class TFAtualizaCadProduto : Form
    {
        private CamadaDados.Estoque.Cadastros.TRegistro_CadProduto rprod;
        public CamadaDados.Estoque.Cadastros.TRegistro_CadProduto rProd
        {
            get
            {
                if (bsProduto.Current != null)
                    return bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto;
                else
                    return null;
            }
            set { rprod = value; }
        }

        public string Cd_empresa
        { get; set; }
        public string Cd_tabelapreco
        { get; set; }
        public bool pSt_servico
        { get; set; }

        public TFAtualizaCadProduto()
        {
            InitializeComponent();
            System.Collections.ArrayList cbx = new System.Collections.ArrayList();
            cbx.Add(new Utils.TDataCombo("MERCADORIA PARA REVENDA", "00"));
            cbx.Add(new Utils.TDataCombo("MATERIA-PRIMA", "01"));
            cbx.Add(new Utils.TDataCombo("EMBALAGEM", "02"));
            cbx.Add(new Utils.TDataCombo("PRODUTO EM PROCESSO", "03"));
            cbx.Add(new Utils.TDataCombo("PRODUTO ACABADO", "04"));
            cbx.Add(new Utils.TDataCombo("SUBPRODUTO", "05"));
            cbx.Add(new Utils.TDataCombo("PRODUTO INTERMEDIARIO", "06"));
            cbx.Add(new Utils.TDataCombo("MATERIAL DE USO E CONSUMO", "07"));
            cbx.Add(new Utils.TDataCombo("ATIVO IMOBILIZADO", "08"));
            cbx.Add(new Utils.TDataCombo("SERVICOS", "09"));
            cbx.Add(new Utils.TDataCombo("OUTROS INSUMOS", "10"));
            cbx.Add(new Utils.TDataCombo("OUTRAS", "99"));
            tp_item.DataSource = cbx;
            tp_item.ValueMember = "Value";
            tp_item.DisplayMember = "Display";
        }

        private void afterGrava()
        {
            if (pDadosProd.validarCampoObrigatorio())
            {
                ncm_Leave(this, new EventArgs());
                if (!string.IsNullOrEmpty(cod_barras.Text))
                    (bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).lCodBarra.Add(
                        new CamadaDados.Estoque.Cadastros.TRegistro_CodBarra() { Cd_codbarra = cod_barras.Text });                      
                this.DialogResult = DialogResult.OK;
            }
        }

        private void TFAtualizaCadProduto_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pDadosProd.set_FormatZero();
            if (rprod != null)
            {
                bsProduto.DataSource = new CamadaDados.Estoque.Cadastros.TList_CadProduto() { rprod };
                CD_Produto.Enabled = string.IsNullOrEmpty(rprod.CD_Produto) ? !CamadaNegocio.Diversos.TCN_CadParamSys.St_AutoInc("CD_Produto") : false;
                codigo_alternativo.Focus();
                rprod.lCodBarra.ForEach(p =>
                {
                    cod_barras.Text = p.Cd_codbarra;
                });
            }
            else
            {
                CD_Produto.Enabled = !CamadaNegocio.Diversos.TCN_CadParamSys.St_AutoInc("CD_Produto");
                bsProduto.AddNew();
                if (!CD_Produto.Focus())
                    codigo_alternativo.Focus();
            }
            TP_Produto_Leave(this, new EventArgs());

        }

        private void BB_GrupoProduto_Click(object sender, EventArgs e)
        {
            string vColunas = "a.DS_Grupo|Descrição Grupo Produto|350;" +
                              "a.CD_Grupo|Cód. Grupo|100";
            string vParamFixo = "a.TP_Grupo|=|'A'";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_Grupo, DS_Grupo },
                                    new CamadaDados.Estoque.Cadastros.TCD_CadGrupoProduto(), vParamFixo);
        }

        private void CD_Grupo_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.CD_Grupo|=|'" + CD_Grupo.Text + "';" +
                              "a.TP_Grupo|=|'A'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_Grupo, DS_Grupo },
                                    new CamadaDados.Estoque.Cadastros.TCD_CadGrupoProduto());
        }

        private void BB_CondFiscalProduto_Click(object sender, EventArgs e)
        {
            string vColunas = "DS_CondFiscal_Produto|Condição Fiscal|350;" +
                              "CD_CondFiscal_Produto|Cód. Cond. Fiscal|100";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_CondFiscal_Produto, ds_condfiscal_produto },
                                    new CamadaDados.Fiscal.TCD_CadCondFiscalProduto(), string.Empty);
        }

        private void CD_CondFiscal_Produto_Leave(object sender, EventArgs e)
        {
            string vColunas = "CD_CondFiscal_Produto|=|'" + CD_CondFiscal_Produto.Text + "'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_CondFiscal_Produto, ds_condfiscal_produto },
                                    new CamadaDados.Fiscal.TCD_CadCondFiscalProduto());
        }

        private void BB_TpProduto_Click(object sender, EventArgs e)
        {
            string vColunas = "DS_TPProduto|Tipo Produto|350;" +
                              "TP_Produto|Cód. TPProduto|100;" +
                              "ST_Servico|Servico|80;" +
                              "ST_Composto|Composto|80;" +
                              "ST_MPrima|Materia Prima|80;" +
                              "ST_Embalagem|Embalagem|80";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { TP_Produto, ds_tpproduto },
                                    new CamadaDados.Estoque.Cadastros.TCD_CadTpProduto(), string.Empty);
        }

        private void TP_Produto_Leave(object sender, EventArgs e)
        {
            if (pSt_servico)
            {
                object obj = new CamadaDados.Estoque.Cadastros.TCD_CadTpProduto().BuscarEscalar(
                    new Utils.TpBusca[]
                    {
                        new Utils.TpBusca()
                        {
                            vNM_Campo = "a.st_servico",
                            vOperador = "=",
                            vVL_Busca = "'S'"
                        }
                    }, "a.TP_Produto");
                if (obj != null)
                    TP_Produto.Text = obj.ToString();
            }
            string vColunas = "TP_Produto|=|'" + TP_Produto.Text + "'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { TP_Produto, ds_tpproduto },
                                    new CamadaDados.Estoque.Cadastros.TCD_CadTpProduto());
        }

        private void BB_Unidade_Click(object sender, EventArgs e)
        {
            string vColunas = "DS_Unidade|Descrição Unidade|350;" +
                              "CD_Unidade|Cód. Unidade|100;" +
                              "Sigla_Unidade|Sigla|80";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_Unidade, ds_unidade, sigla_unidade },
                                    new CamadaDados.Estoque.Cadastros.TCD_CadUnidade(), string.Empty);
        }

        private void CD_Unidade_Leave(object sender, EventArgs e)
        {
            string vColunas = "CD_Unidade|=|'" + CD_Unidade.Text + "'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_Unidade, ds_unidade, sigla_unidade },
                                    new CamadaDados.Estoque.Cadastros.TCD_CadUnidade());
        }

        private void bb_ncm_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_ncm|Descrição NCM|250;" +
                              "a.ncm|NCM|80";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { ncm, ds_ncm },
                                    new CamadaDados.Fiscal.TCD_CadNCM(), string.Empty);
        }

        private void ncm_Leave(object sender, EventArgs e)
        {
            Componentes.EditDefault cadNcm = new Componentes.EditDefault();
            cadNcm.Text = ncm.Text;
            string vColunas = "a.ncm|=|'" + ncm.Text.Trim() + "'";
           DataRow linha = UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { ncm, ds_ncm },
                                    new CamadaDados.Fiscal.TCD_CadNCM());

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

        private void bb_anp_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_anp|Descrição|200;" +
                              "a.cd_anp|Cd. ANP|80";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_anp, ds_anp },
                                    new CamadaDados.Estoque.Cadastros.TCD_CodANP(), string.Empty);
        }

        private void cd_anp_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_anp|=|'" + cd_anp.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_anp, ds_anp },
                                    new CamadaDados.Estoque.Cadastros.TCD_CodANP());
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void TFAtualizaCadProduto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }

        private void bb_saldoest_Click(object sender, EventArgs e)
        {
            using (TFSaldoEstPrecoVenda fSaldo = new TFSaldoEstPrecoVenda())
            {
                fSaldo.Cd_empresa = Cd_empresa;
                fSaldo.Cd_tabelapreco = Cd_tabelapreco;
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
                        (bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).rSaldoEst = rEstoque;
                    }
                    if (!string.IsNullOrEmpty(fSaldo.Cd_tabelapreco))
                    {
                        string[] tabela = fSaldo.Cd_tabelapreco.Split(new char[] { ';' });
                        for (int i = 0; tabela.Count() > i; i++)
                        {
                            CamadaDados.Estoque.TRegistro_LanPrecoItem rPreco = new CamadaDados.Estoque.TRegistro_LanPrecoItem();
                            rPreco.CD_Empresa = fSaldo.Cd_empresa;
                            rPreco.CD_TabelaPreco = fSaldo.Cd_tabelapreco;
                            rPreco.Dt_preco = CamadaDados.UtilData.Data_Servidor();
                            rPreco.VL_PrecoVenda = fSaldo.Vl_precovenda;
                            (bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).lPrecoItem.Add(rPreco);
                        }
                    }
                }
            }
        }
    }
}
