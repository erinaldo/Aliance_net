using System;
using System.Drawing;
using System.Windows.Forms;
using FormBusca;
using CamadaNegocio.Estoque;
using CamadaDados.Estoque;
using Utils;
using CamadaDados.Estoque.Cadastros;
using CamadaNegocio.Estoque.Cadastros;
using Estoque.Cadastros;

namespace Estoque
{
    public partial class TFAtualizaPrecoSaldo : Form
    {
        private string Cd_empdefault
        { get; set; }
        private CamadaDados.Faturamento.Cadastros.TList_CFGCupomFiscal lCfg
        { get; set; }
        private  TRegistro_CadProduto rProd
        { get; set; }
        private string codigoBarra = string.Empty;
        public TFAtualizaPrecoSaldo()
        {
            InitializeComponent();
        }

        private void LimparCampos()
        {
            cd_produto.Clear();
            DS_Produto.Clear();
            codBarra.Clear();
            cd_empresa.Clear();
            nm_empresa.Clear();
            cd_local.Clear();
            ds_local.Clear();
            cd_tabelapreco.Clear();
            ds_tabelapreco.Clear();
            quantidade.Value = decimal.Zero;
            vl_custo.Value = decimal.Zero;
            vl_subtotal.Value = decimal.Zero;
            vl_entrada.Value = decimal.Zero;
            qtd_entrada.Value = decimal.Zero;
            total_entrada.Value = decimal.Zero;
            vl_precovenda.Value = decimal.Zero;
            codigoBarra = string.Empty;
            rProd = null;
        }

        private void afterNovo()
        {
            pDados.Enabled = true;
            cd_produto.Enabled = true;
            cd_empresa.Enabled = true;
            bb_empresa.Enabled = true;
            cd_local.Enabled = true;
            bb_local.Enabled = true;
            cd_tabelapreco.Enabled = true;
            bb_tabpreco.Enabled = true;
            vl_precovenda.Enabled = true;
            codBarra.Enabled = true;
            qtd_entrada.Enabled = true;
            vl_entrada.Enabled = true;
            BB_Novo.Visible = false;
            BB_Gravar.Visible = true;
            BB_Cancelar.Visible = true;
            LimparCampos();
            //Buscar empresa do usuario
            object obj_emp = new CamadaDados.Diversos.TCD_CadUsuario_Empresa().BuscarEscalar(
                                new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.login",
                                            vOperador = "=",
                                            vVL_Busca = "'" + Parametros.pubLogin.Trim() + "'"
                                        }
                                    }, "a.cd_empresa");
            Cd_empdefault = obj_emp != null ? obj_emp.ToString() : string.Empty;
            //Buscar Config Cupom
            lCfg = CamadaNegocio.Faturamento.Cadastros.TCN_CFGCupomFiscal.Buscar((Cd_empdefault), null);
            //Preencher CD.Empresa
            if (lCfg.Count > 0)
                cd_empresa.Text = lCfg[0].Cd_empresa.Trim();
            else
                cd_empresa.Text = Cd_empdefault;
            cd_empresa_Leave(this, new EventArgs());
            //Tabela Preco
            cd_tabelapreco.Text = "01";
            cd_tabelapreco_Leave(this, new EventArgs());
            //Buscar local armazenagem
            object obj = new TCD_CadLocalArm().BuscarEscalar(
                            new TpBusca[]
                                {
                                    new TpBusca()
                                    {
                                        vNM_Campo = string.Empty,
                                        vOperador = "exists",
                                        vVL_Busca = "(select 1 from tb_est_empresa_x_localarm x " +
                                                    "where x.cd_local = a.cd_local " +
                                                    "and x.cd_empresa = '" + cd_empresa.Text.Trim() + "')"
                                    }
                                }, "a.cd_local");
            if (obj != null)
            {
                cd_local.Text = obj.ToString();
                cd_local_Leave(this, new EventArgs());
            }
            cd_produto.Focus();
        }

        private void afterGrava()
        {
            if (rProd != null)
            {
                if (!string.IsNullOrEmpty(cd_tabelapreco.Text))
                {
                    if (vl_precovenda.Value > 0)
                    {
                        TRegistro_LanPrecoItem rPreco = new TRegistro_LanPrecoItem();
                        rPreco.CD_Empresa = cd_empresa.Text;
                        rPreco.CD_TabelaPreco = cd_tabelapreco.Text;
                        rPreco.Dt_preco = CamadaDados.UtilData.Data_Servidor();
                        rPreco.VL_PrecoVenda = vl_precovenda.Value;
                        rProd.lPrecoItem.Add(rPreco);
                        TCN_CadProduto.Gravar(rProd, null);
                        MessageBox.Show("Produto Atualizado com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("É necessário informar tabela preço!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                

                //Adicionar Código de Barras
                if (!string.IsNullOrEmpty(codBarra.Text))
                    rProd.lCodBarra.Add(
                        new TRegistro_CodBarra() { Cd_codbarra = codBarra.Text }); 
                try
                {

                    if (string.IsNullOrEmpty(cd_local.Text))
                    {
                        MessageBox.Show("Informe o Local de Armazenagem para ajustar estoque!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cd_local.Focus();
                        return;
                    }
                    if (qtd_entrada.Value.Equals(decimal.Zero))
                    {
                        MessageBox.Show("Informe a QTD de ajuste de estoque do produto!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        qtd_entrada.Focus();
                        return;
                    }
                    if (vl_entrada.Value.Equals(decimal.Zero))
                    {
                        MessageBox.Show("Informe o Valor Médio do produto!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        vl_entrada.Focus();
                        return;
                    }
                    if (quantidade.Value != qtd_entrada.Value)
                    {
                        //Gravar no estoque
                        TRegistro_LanEstoque regEstoque = new TRegistro_LanEstoque();
                        regEstoque.Cd_empresa = cd_empresa.Text;
                        regEstoque.Cd_produto = cd_produto.Text;
                        regEstoque.Cd_local = cd_local.Text;
                        regEstoque.Dt_lancto = CamadaDados.UtilData.Data_Servidor();
                        regEstoque.Vl_medioestoque = vl_entrada.Value;
                        regEstoque.St_registro = "A";
                        regEstoque.Tp_lancto = "M";
                        if (quantidade.Value < qtd_entrada.Value)
                        {
                            regEstoque.Tp_movimento = "E";
                            regEstoque.Qtd_entrada = qtd_entrada.Value - quantidade.Value;
                            regEstoque.Vl_subtotal = vl_entrada.Value * (qtd_entrada.Value - quantidade.Value);
                        }
                        else
                        {
                            regEstoque.Tp_movimento = "S";
                            regEstoque.Qtd_saida = quantidade.Value - qtd_entrada.Value;
                            regEstoque.Vl_subtotal = vl_entrada.Value * (quantidade.Value - qtd_entrada.Value);
                        }
                        regEstoque.Vl_unitario = vl_entrada.Value;
                        //Gravar Estoque
                        TCN_LanEstoque.GravarEstoque(regEstoque, null);
                        //Atualizar Vl.Médio
                        TCN_LanEstoque.AcertarVlMedio(regEstoque, null);
                    }
                    else
                    {
                        MessageBox.Show("Não é possivel alterar estoque de produto mantendo a mesma quantidade!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    //Gravar Produto                   
                    CamadaNegocio.Estoque.Cadastros.TCN_CadProduto.Gravar(rProd, null);
                    MessageBox.Show("Produto Atualizado com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimparCampos();
                    BB_Gravar.Visible = false;
                    BB_Cancelar.Visible = false;
                    BB_Novo.Visible = true;
                    pDados.Enabled = false;
                }
                catch(Exception ex)
                {MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);}
            }
        }

        private decimal BuscarSaldoLocal()
        {
            if ((!string.IsNullOrEmpty(cd_empresa.Text)) &&
                (!string.IsNullOrEmpty(cd_produto.Text)) &&
                (!string.IsNullOrEmpty(cd_local.Text)))
            {
                decimal saldo = decimal.Zero;
                TCN_LanEstoque.SaldoEstoqueLocal(cd_empresa.Text, cd_produto.Text, cd_local.Text, ref saldo, null);
                return saldo;
            }
            else
                return decimal.Zero;
        }

        private string BuscarCodBarra()
        {
            object obj = new TCD_CodBarra().BuscarEscalar(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.cd_produto",
                                            vOperador = "=",
                                            vVL_Busca = "'" + cd_produto.Text.Trim() + "'"
                                        }
                                    }, "a.CD_CodBarra");

            if (obj != null)
            {
                if (string.IsNullOrEmpty(codBarra.Text))
                    return obj.ToString();
                else
                    return codBarra.Text;
            }
            else
                return codBarra.Text;
        }

        private void BuscarProduto()
        {
            if (!string.IsNullOrEmpty(cd_empresa.Text))
            {
                //Prencher variavel codigo de barra
                codigoBarra = cd_produto.Text;
                TpBusca[] filtro = new TpBusca[0];
                if (string.IsNullOrEmpty(cd_produto.Text))
                    rProd = UtilPesquisa.BuscarProduto(string.Empty,
                                                       cd_empresa.Text,
                                                       nm_empresa.Text,
                                                       cd_tabelapreco.Text,
                                                       new Componentes.EditDefault[] { cd_produto, DS_Produto },
                                                       null);
                else if (cd_produto.Text.SoNumero().Trim().Length != cd_produto.Text.Trim().Length)
                    rProd = UtilPesquisa.BuscarProduto(cd_produto.Text,
                                                       cd_empresa.Text,
                                                       nm_empresa.Text,
                                                       cd_tabelapreco.Text,
                                                       new Componentes.EditDefault[] { cd_produto, DS_Produto },
                                                       null);
                else
                {
                    Array.Resize(ref filtro, filtro.Length + 2);
                    filtro[filtro.Length - 2].vNM_Campo = "isnull(a.st_registro, 'A')";
                    filtro[filtro.Length - 2].vOperador = "<>";
                    filtro[filtro.Length - 2].vVL_Busca = "'C'";
                    filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                    filtro[filtro.Length - 1].vOperador = string.Empty;
                    filtro[filtro.Length - 1].vVL_Busca = "(a.cd_produto like '%" + cd_produto.Text.Trim() + "') or " +
                                                          "(a.Codigo_Alternativo = '" + (!string.IsNullOrWhiteSpace(cd_produto.TextOld) ? cd_produto.TextOld : cd_produto.Text.Trim()) + "') or " +
                                                          "(exists(select 1 from tb_est_codbarra x " +
                                                          "           where x.cd_produto = a.cd_produto " +
                                                          "           and x.cd_codbarra = '" + cd_produto.Text.Trim() + "'))";
                    TList_CadProduto lProd = new TCD_CadProduto().Select(filtro, 0, string.Empty, string.Empty, string.Empty);
                    if (lProd.Count > 0)
                        rProd = lProd[0];
                }
                if (rProd != null)
                {
                    cd_produto.Text = rProd.CD_Produto;
                    DS_Produto.Text = rProd.DS_Produto;
                    cd_local.Enabled = !rProd.St_composto;
                    bb_local.Enabled = !rProd.St_composto;
                    qtd_entrada.Enabled = !rProd.St_composto;
                    vl_entrada.Enabled = !rProd.St_composto;
                    codBarra.Text = BuscarCodBarra();
                    //Buscar Preço Venda
                    if (!string.IsNullOrEmpty(cd_produto.Text) && !string.IsNullOrEmpty(cd_tabelapreco.Text))
                        vl_precovenda.Value = TCN_LanPrecoItem.Busca_ConsultaPreco(cd_empresa.Text, cd_produto.Text, cd_tabelapreco.Text, null);
                    if (!rProd.St_composto)
                    {
                        //Buscar Preço Custo
                        if (!string.IsNullOrEmpty(cd_produto.Text) && !string.IsNullOrEmpty(cd_local.Text))
                        {
                            vl_custo.Value = TCN_LanEstoque.Vl_MedioLocal(cd_empresa.Text, cd_produto.Text, cd_local.Text, null);
                            vl_entrada.Value = vl_custo.Value;
                        }
                        //Buscar Saldo
                        quantidade.Value = BuscarSaldoLocal();
                        //Total Custo Estoque
                        if (quantidade.Value > 0 && vl_custo.Value > 0)
                            vl_subtotal.Value = quantidade.Value * vl_custo.Value;
                    }
                }
                else
                {
                    cd_produto.Clear();
                    cd_produto.Focus();
                    //se o produto nao existir com o codigo add ao campo para cadastrar
                    if (!string.IsNullOrEmpty(codigoBarra))
                    {
                        codBarra.Text = codigoBarra;
                        if (InputBox("Pergunta", "Produto não encontrado com o código de barras!\r\n" +
                                 "Deseja incluir código ao novo produto ou relacionar ao existente?") == DialogResult.Yes)
                            bb_novoProd_Click(this, new EventArgs());
                        else
                            BuscarProduto();
                    }
                }
                if (!string.IsNullOrEmpty(cd_local.Text))
                    qtd_entrada.Focus();
            }
            else
            {
                MessageBox.Show("Obrigatório selecionar empresa para Buscar o Produto!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cd_empresa.Focus();
            }
        }

        private void TFAtualizaPrecoSaldo_Load(object sender, EventArgs e)
        {
            BB_Gravar.Visible = false;
            BB_Cancelar.Visible = false;
            BB_Excluir.Visible = false;
            Icon = ResourcesUtils.TecnoAliance_ICO;
            pDados.set_FormatZero();
        }

        private void cd_produto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                SelectNextControl(ActiveControl, !e.Shift, true, true, true);
        }

        private void cd_tabelapreco_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_tabelapreco|=|'" + cd_tabelapreco.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_tabelapreco, ds_tabelapreco },
                                                new CamadaDados.Diversos.TCD_CadTbPreco());
        }

        private void bb_tabpreco_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_tabelapreco|Tabela Preço|200;" +
                              "a.cd_tabelapreco|Cd. Tabela|80";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_tabelapreco, ds_tabelapreco },
                                                new CamadaDados.Diversos.TCD_CadTbPreco(), string.Empty);
            BuscarProduto();
        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            string vColunas = "a.NM_Empresa|Empresa|350;" +
                              "a.CD_Empresa|Código|100";
            string vParamFixo = "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.cd_empresa = A.cd_empresa " +
                                            "and ((x.login = '" + Parametros.pubLogin.Trim() + "') or " +
                                            "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                            "       where y.logingrp = x.login and y.loginusr = '" + Parametros.pubLogin.Trim() + "'))))";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_empresa },
                                    new CamadaDados.Diversos.TCD_CadEmpresa(), vParamFixo);
            BuscarProduto();
        }

        private void cd_empresa_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.CD_Empresa|=|'" + cd_empresa.Text.Trim() + "';" +
                              "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.cd_empresa = A.cd_empresa " +
                                            "and ((x.login = '" + Parametros.pubLogin.Trim() + "') or " +
                                            "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                            "       where y.logingrp = x.login and y.loginusr = '" + Parametros.pubLogin.Trim() + "'))))";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cd_empresa },
                                    new CamadaDados.Diversos.TCD_CadEmpresa());
        }

        private void bb_local_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("a.DS_Local|Local|300;a.CD_Local|Código|80",
                                              new Componentes.EditDefault[] { cd_local, ds_local },
                                              new TCD_CadLocalArm(string.Empty, cd_empresa.Text), string.Empty);
            BuscarProduto();
        }

        private void cd_local_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.CD_Local|=|'" + cd_local.Text.Trim() + "'",
                                               new Componentes.EditDefault[] { cd_local, ds_local },
                                               new TCD_CadLocalArm(string.Empty, cd_empresa.Text));
        }

        private void TFAtualizaPrecoSaldo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F2))
                afterNovo();
            else if (e.KeyCode.Equals(Keys.F4))
                afterGrava();
            else if (e.KeyCode.Equals(Keys.F5))
                LimparCampos();
            else if (e.KeyCode.Equals(Keys.F6))
                DialogResult = DialogResult.Cancel;
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            afterGrava();
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void BB_Novo_Click(object sender, EventArgs e)
        {
            afterNovo();
        }

        private void BB_Excluir_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void qtd_entrada_Leave(object sender, EventArgs e)
        {
            total_entrada.Value = qtd_entrada.Value * vl_entrada.Value;
        }

        private void vl_entrada_Leave(object sender, EventArgs e)
        {
            total_entrada.Value = qtd_entrada.Value * vl_entrada.Value;
            //Tabulação
            if (!string.IsNullOrEmpty(cd_tabelapreco.Text))
                vl_precovenda.Focus();
        }

        private void bb_novoProd_Click(object sender, EventArgs e)
        {
            using (TFProduto fProd = new TFProduto())
            {
                if(fProd.ShowDialog() == DialogResult.OK)
                    if(fProd.rProd != null)
                        try
                        {
                            TCN_CadProduto.Gravar(fProd.rProd, null);
                            cd_produto.Text = fProd.rProd.CD_Produto;
                            MessageBox.Show("Produto gravado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            BuscarProduto();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void cd_produto_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cd_produto.Text))
                BuscarProduto();
        }

        public static DialogResult InputBox(string title, string promptText)
        {
            Form form = new Form();
            Label label = new Label();
            Button buttonIncluir = new Button();
            Button buttonRelacionar = new Button();

            form.Text = title;
            label.Text = promptText;

            buttonIncluir.Text = "Incluir";
            buttonRelacionar.Text = "Relacionar";
            buttonIncluir.DialogResult = DialogResult.Yes;
            buttonRelacionar.DialogResult = DialogResult.No;

            label.SetBounds(9, 20, 372, 13);
            buttonIncluir.SetBounds(228, 72, 75, 23);
            buttonRelacionar.SetBounds(309, 72, 75, 23);

            label.AutoSize = true;
            buttonIncluir.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonRelacionar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            form.ClientSize = new Size(396, 107);
            form.Controls.AddRange(new Control[] { label, buttonIncluir, buttonRelacionar });
            form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.CancelButton = buttonIncluir;
            form.CancelButton = buttonRelacionar;

            DialogResult dialogResult = form.ShowDialog();
            return dialogResult;
        }
    }
}
