using System;
using System.Windows.Forms;
using FormBusca;
using CamadaDados.Estoque;
using CamadaNegocio.Estoque;
using Utils;
using CamadaDados.Diversos;
using CamadaDados.Estoque.Cadastros;
using System.Collections;
using CamadaNegocio.Estoque.Cadastros;
using System.Data;

namespace Estoque
{
    public partial class TFLanEstoque : Form
    {
        private string pId_caracteristica { get; set; }
        public string pCd_empresa
        { get; set; }
        public string pCd_produto
        { get; set; }

        public TFLanEstoque()
        {
            InitializeComponent();
            pnl_Lan_Estoque.set_FormatZero();
            ArrayList cbx = new ArrayList();
            cbx.Add(new TDataCombo("ENTRADA", "E"));
            cbx.Add(new TDataCombo("SAIDA", "S"));
            tp_movimento.DataSource = cbx;
            tp_movimento.DisplayMember = "Display";
            tp_movimento.ValueMember = "Value";
            pCd_empresa = string.Empty;
            pCd_produto = string.Empty;
        }

        private void BB_Empresa_Click(object sender, EventArgs e)
        {
            string vColunas = "a.NM_Empresa|Empresa|350;" +
                              "a.CD_Empresa|Código|100";
            string vParam = "|EXISTS|(select 1 from tb_div_usuario_x_empresa x " +
                            "where x.cd_empresa = a.cd_empresa " +
                            "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                            "(exists(select 1 from tb_div_usuario_x_grupos y " +
                            "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            if (!string.IsNullOrEmpty(CD_Local.Text))
                vParam += "|exists|(select 1 from tb_est_empresa_x_localarm x " +
                          "         where x.cd_empresa = a.cd_empresa " +
                          "         and x.cd_local = '" + CD_Local.Text.Trim() + "')";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_Empresa, NM_Empresa },
                                    new TCD_CadEmpresa(), vParam);
            busca_Valor_Unitario();
        }

        private void CD_Empresa_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.CD_Empresa|=|'" + CD_Empresa.Text.Trim() + "';"+
                              "|EXISTS|(select 1 from tb_div_usuario_x_empresa x " +
                            "where x.cd_empresa = a.cd_empresa " +
                            "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                            "(exists(select 1 from tb_div_usuario_x_grupos y " +
                            "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            if (!string.IsNullOrEmpty(CD_Local.Text))
                vColunas += "|exists|(select 1 from tb_est_empresa_x_localarm x " +
                            "           where x.cd_empresa = a.cd_empresa " +
                            "           and x.cd_local = '" + CD_Local.Text.Trim() + "')";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_Empresa, NM_Empresa },
                                    new TCD_CadEmpresa());
            busca_Valor_Unitario();
        }

        private void BB_Produto_Click(object sender, EventArgs e)
        {
            string vParamFix = "isnull(e.ST_Servico, 'N') |<>| 'S';isnull(e.st_composto, 'N')|<>|'S';isnull(e.ST_ConsumoInterno, 'N')|<>|'S'";
            DataRowView linha = UtilPesquisa.BTN_BuscaProduto(new Componentes.EditDefault[] { CD_Produto, DS_Produto},vParamFix);
            if (linha != null)
                pId_caracteristica = linha["id_caracteristicaH"].ToString();
            else pId_caracteristica = string.Empty;
            busca_Valor_Unitario();
        }

        private void CD_Produto_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.CD_Produto|=|'" + CD_Produto.Text + "';isnull(e.ST_Servico, 'N')|<>|'S';isnull(e.st_composto, 'N')|<>|'S';isnull(e.ST_ConsumoInterno, 'N')|<>|'S'";
            DataRow linha = UtilPesquisa.EDIT_LEAVEProduto(vColunas, new Componentes.EditDefault[] { CD_Produto, DS_Produto, Sigla },
                                    new TCD_CadProduto());
            if (linha != null)
                pId_caracteristica = linha["id_caracteristicaH"].ToString();
            else pId_caracteristica = string.Empty;
            busca_Valor_Unitario();
        }
        
        private void BB_Local_Click(object sender, EventArgs e)
        {
            TList_CadLocalArm_X_Produto List_Local_x_Produto = new TList_CadLocalArm_X_Produto();
            if (!string.IsNullOrEmpty(CD_Produto.Text))
                List_Local_x_Produto = TCN_CadLocalArm_X_Produto.Busca(string.Empty, CD_Produto.Text);
            UtilPesquisa.BTN_BUSCA("a.DS_Local|Local|300;a.CD_Local|Código|80"
                               , new Componentes.EditDefault[] { CD_Local, DS_Local }, 
                               new TCD_CadLocalArm(List_Local_x_Produto.Count > 0 ? CD_Produto.Text : string.Empty, CD_Empresa.Text), "isnull(a.st_registro, 'A')|<>|'C'");
            busca_Valor_Unitario();
        }

        private void CD_Local_Leave(object sender, EventArgs e)
        {
            TList_CadLocalArm_X_Produto List_Local_x_Produto = new TList_CadLocalArm_X_Produto();
            if (!string.IsNullOrEmpty(CD_Produto.Text))
                List_Local_x_Produto = TCN_CadLocalArm_X_Produto.Busca(string.Empty, CD_Produto.Text);

            UtilPesquisa.EDIT_LEAVE("a.CD_Local|=|'" + CD_Local.Text + "';isnull(a.st_registro, 'A')|<>|'C'", 
                new Componentes.EditDefault[] { CD_Local, DS_Local }, 
                new TCD_CadLocalArm(List_Local_x_Produto.Count > 0 ? CD_Produto.Text : string.Empty, CD_Empresa.Text));
            busca_Valor_Unitario();
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void TFLanEstoque_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case (Keys.F6):
                    {
                        BB_Cancelar_Click(sender, new EventArgs()); break;
                    }
                case (Keys.F4):
                    {
                        BB_Gravar_Click(sender, new EventArgs()); break;
                    };
            }
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            if (Qtd_Saida.Focused)
                Qtd_Saida_Leave(this, new EventArgs());
            if (Qtd_Entrada.Focused)
                Qtd_Entrada_Leave(this, new EventArgs());
            if (VL_Unitario.Focused)
                VL_Unitario_Leave(this, new EventArgs());
            if (vl_subtotal.Focused)
                vl_subtotal_Leave(this, new EventArgs());
            if (pnl_Lan_Estoque.validarCampoObrigatorio())
            {
                if(!string.IsNullOrEmpty(pId_caracteristica))
                    using (Proc_Commoditties.TFGradeProduto fGrade = new Proc_Commoditties.TFGradeProduto())
                    {
                        fGrade.pId_caracteristica = pId_caracteristica;
                        fGrade.pCd_empresa = CD_Empresa.Text;
                        fGrade.pCd_produto = CD_Produto.Text;
                        fGrade.pDs_produto = DS_Produto.Text;
                        fGrade.pTp_movimento = tp_movimento.SelectedValue.ToString();
                        fGrade.pQuantidade = tp_movimento.SelectedValue.ToString().Trim().ToUpper().Equals("E") ? Qtd_Entrada.Value : Qtd_Saida.Value;
                        if (fGrade.ShowDialog() == DialogResult.OK)
                            fGrade.lGrade.ForEach(p => (BS_Lan_Estoque.Current as TRegistro_LanEstoque).lGrade.Add(p));
                        else
                        {
                            MessageBox.Show("Obrigatório informar grade.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                DialogResult = DialogResult.OK;
            }
        }

        public void busca_Valor_Unitario()
        {
            if(BS_Lan_Estoque.Current != null)
            {
               decimal Tot_Entrada = decimal.Zero;
               decimal Tot_Saida = decimal.Zero;
               decimal Tot_Saldo = decimal.Zero;
               decimal VL_Estoque_ent = decimal.Zero;
               decimal VL_Estoque_sai = decimal.Zero;
               decimal VL_SaldoEstoque = decimal.Zero;
               decimal VL_Medio = decimal.Zero;

               TCN_LanEstoque.Valores_EstoqueLocal((BS_Lan_Estoque.Current as TRegistro_LanEstoque).Cd_empresa, 
                                                   (BS_Lan_Estoque.Current as TRegistro_LanEstoque).Cd_produto, 
                                                   (BS_Lan_Estoque.Current as TRegistro_LanEstoque).Cd_local,
                                                   ref Tot_Entrada, 
                                                   ref Tot_Saida,
                                                   ref Tot_Saldo, 
                                                   ref VL_Estoque_ent, 
                                                   ref VL_Estoque_sai, 
                                                   ref VL_SaldoEstoque, 
                                                   ref VL_Medio,
                                                   null);


               TOT_ENTRADA.Text  = Tot_Entrada.ToString("N3", new System.Globalization.CultureInfo("pt-BR", true));
               TOT_SAIDA.Text = Tot_Saida.ToString("N3", new System.Globalization.CultureInfo("pt-BR", true));
               TOT_SALDO.Text = Tot_Saldo.ToString("N3", new System.Globalization.CultureInfo("pt-BR", true));
               VL_ENTRADA.Text = VL_Estoque_ent.ToString("N2", new System.Globalization.CultureInfo("pt-BR", true));
               VL_SAIDA.Text = VL_Estoque_sai.ToString("N2", new System.Globalization.CultureInfo("pt-BR", true));
               VL_SALDO.Text = VL_SaldoEstoque.ToString("N2", new System.Globalization.CultureInfo("pt-BR", true));
               VL_MEDIO.Text = VL_Medio.ToString("N7", new System.Globalization.CultureInfo("pt-BR", true));               
                
               VL_Unitario.Value = VL_Medio;
            }                       
        }

        private void TFLanEstoque_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
            Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            if (pCd_empresa.Trim() != "")
            {
                CD_Empresa.Text = pCd_empresa.Trim();
                CD_Empresa_Leave(this, new EventArgs());
            }
            if (pCd_produto.Trim() != "")
            {
                CD_Produto.Text = pCd_produto.Trim();
                CD_Produto_Leave(this, new EventArgs());
            }
        }

        private void tp_movimento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tp_movimento.SelectedValue != null)
                if (tp_movimento.SelectedValue.ToString().Trim().ToUpper().Equals("E"))
                {
                    lbl_quantidade.Text = "Qtd. Entrada:";
                    Qtd_Saida.Visible = false;
                    Qtd_Saida.ST_NotNull = false;
                    Qtd_Saida.Value = decimal.Zero;
                    Qtd_Entrada.Visible = true;
                    Qtd_Entrada.ST_NotNull = true;
                }
                else if (tp_movimento.SelectedValue.ToString().Trim().ToUpper().Equals("S"))
                {
                    lbl_quantidade.Text = "Qtd. Saida:";
                    Qtd_Entrada.Visible = false;
                    Qtd_Entrada.ST_NotNull = false;
                    Qtd_Entrada.Value = decimal.Zero;
                    Qtd_Saida.Visible = true;
                    Qtd_Saida.ST_NotNull = true;
                }
        }

        private void DT_Lancamento_Leave(object sender, EventArgs e)
        {
            if (tp_movimento.SelectedValue != null)
                if (tp_movimento.SelectedValue.ToString().Trim().ToUpper().Equals("E"))
                    Qtd_Entrada.Focus();
                else
                    Qtd_Saida.Focus();
        }

        private void Qtd_Saida_Leave(object sender, EventArgs e)
        {
            vl_subtotal.Value = Qtd_Saida.Value * VL_Unitario.Value;
        }

        private void Qtd_Entrada_Leave(object sender, EventArgs e)
        {
            vl_subtotal.Value = Qtd_Entrada.Value * VL_Unitario.Value;
        }

        private void VL_Unitario_Leave(object sender, EventArgs e)
        {
            vl_subtotal.Value = (Qtd_Entrada.Visible ? Qtd_Entrada.Value : Qtd_Saida.Value) * VL_Unitario.Value;
        }

        private void vl_subtotal_Leave(object sender, EventArgs e)
        {
            if ((Qtd_Saida.Value > 0) || (Qtd_Entrada.Value > 0))
                VL_Unitario.Value = vl_subtotal.Value / (Qtd_Entrada.Visible ? Qtd_Entrada.Value : Qtd_Saida.Value);
        }
    }
}
