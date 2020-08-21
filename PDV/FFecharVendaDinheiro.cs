using System;
using System.Windows.Forms;

namespace PDV
{
    public partial class TFFecharVendaDinheiro : Form
    {
        private CamadaDados.Faturamento.Cadastros.TList_DescontoVendedor lDesc
        { get; set; }
        public CamadaDados.Faturamento.PDV.TRegistro_VendaRapida rCupom
        { get; set; }
        public string pCd_empresa
        { get; set; }
        public string pCd_operador
        { get; set; }
        public string pLoginDesconto
        { get; set; }
        public decimal pVl_receber
        { get; set; }
        public decimal pVl_desconto
        { get { return vl_desconto.Value; } }
        public decimal pVl_dinheiro
        { get { return vl_dinheiro.Value; } }
        public decimal pVl_troco
        { get { return vl_troco.Value; } }
        public CamadaDados.Faturamento.Cadastros.TList_PontoVenda lPdv
        { get; set; }

        public TFFecharVendaDinheiro()
        {
            InitializeComponent();
        }

        private bool ValorDinheiro(decimal Valor)
        {
            bool retorno = false;
            if (vl_dinheiro.Value < vl_receber.Value)
            {
                vl_dinheiro.Value += Valor;
                retorno = true;
            }
            if(vl_dinheiro.Value > vl_receber.Value)
                vl_troco.Value = vl_dinheiro.Value - vl_receber.Value;
            return retorno;
        }

        private void afterGrava()
        {
            if (pc_desconto.Focused)
                pc_desconto_Leave(this, new EventArgs());
            if (vl_desconto.Focused)
                vl_desconto_Leave(this, new EventArgs());
            if (vl_dinheiro.Focused)
                vl_dinheiro_Leave(this, new EventArgs());
            if (vl_dinheiro.Value < vl_receber.Value)
            {
                MessageBox.Show("Obrigatório informar valor DINHEIRO.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                vl_dinheiro.Focus();
                return;
            }
            if (vl_dinheiro.Value < vl_receber.Value)
            {
                MessageBox.Show("Não é permitido informar Vl.Dinheiro menor que o valor á receber!");
                vl_dinheiro.Value = vl_receber.Value;
                vl_dinheiro.Focus();
                return;
            }
            DialogResult = DialogResult.OK;
        }

        private void TotalizarCampos()
        {
            vl_receber.Value = vl_venda.Value - vl_desconto.Value;
            vl_dinheiro.Value = vl_receber.Value;
            vl_troco.Value = decimal.Zero;
        }

        private void AbrirGavetaDinheiro()
        {
            if (lPdv.Count > 0)
                if (lPdv[0].St_gavetadinheirobool)
                {
                    //Buscar porta comunicacao
                    object obj_porta = new CamadaDados.Diversos.TCD_CadTerminal().BuscarEscalar(
                                        new Utils.TpBusca[]
                                        {
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = "a.cd_terminal",
                                                vOperador = "=",
                                                vVL_Busca = "'" + lPdv[0].Cd_terminal.Trim() + "'"
                                            }
                                        }, "a.porta_imptick");
                    if (obj_porta != null)
                        try
                        {
                            Utils.TGavetaDinheiro.AbrirGaveta(obj_porta.ToString(), lPdv[0].CMD_Abrirgaveta);
                        }
                        catch (Exception ex)
                        { MessageBox.Show("Erro executar comando: " + ex.Message.Trim()); }
                    else MessageBox.Show("Terminal " + lPdv[0].Cd_terminal.Trim() + "-" + lPdv[0].Ds_terminal.Trim() + " não tem porta comunicação configurada.",
                        "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
        }

        private bool VerificarTotDesconto(CamadaDados.Faturamento.PDV.TRegistro_VendaRapida val, decimal tot_desconto)
        {
            for (int i = 0; i < (val.lItem.Count); i++)
            {
                if (lDesc.Count > 0)
                {
                    if (!string.IsNullOrEmpty(val.Cd_tabelapreco))
                        if (lDesc.Exists(p => p.Cd_tabelapreco.Trim().Equals(val.Cd_tabelapreco.Trim()) &&
                                            p.Cd_grupo.Trim().Equals(val.lItem[i].Cd_grupo.Trim())))
                        {
                            //Desconto por tabela de preco e grupo de produto
                            decimal pc_max_desc = lDesc.Find(p => p.Cd_tabelapreco.Trim().Equals(val.Cd_tabelapreco.Trim()) &&
                                                                    p.Cd_grupo.Trim().Equals(val.lItem[i].Cd_grupo.Trim())).Pc_max_desconto;
                            decimal pc_desconto = tot_desconto * 100 / pVl_receber;
                            if (pc_desconto > pc_max_desc)
                            {
                                MessageBox.Show("A tabela de preço e o grupo de produto está configurado para dar desconto máximo de " + pc_max_desc.ToString("N2", new System.Globalization.CultureInfo("pt-BR")) + "%.",
                                                            "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                //Chamar tela de usuario com autorizacao para o % desconto solicitado
                                using (Financeiro.TFLoginDesconto fLogin = new Financeiro.TFLoginDesconto())
                                {
                                    fLogin.Cd_tabelapreco = val.Cd_tabelapreco;
                                    fLogin.Cd_grupo = val.lItem[i].Cd_grupo;
                                    fLogin.Cd_empresa = val.Cd_empresa;
                                    fLogin.Pc_desc = pc_desconto;
                                    if (fLogin.ShowDialog() != DialogResult.OK)
                                        return false;
                                    else
                                    {
                                        pLoginDesconto = fLogin.Logindesconto;
                                        return true;
                                    }
                                }
                            }
                            else return true;
                        }
                        else if (lDesc.Exists(p => p.Cd_tabelapreco.Trim().Equals(val.Cd_tabelapreco.Trim())))
                        {
                            //Desconto por tabela de preço
                            decimal pc_max_desc = lDesc.Find(p => p.Cd_tabelapreco.Trim().Equals(val.Cd_tabelapreco.Trim())).Pc_max_desconto;
                            decimal pc_desconto = tot_desconto * 100 / pVl_receber;
                            if (pc_desconto > pc_max_desc)
                            {
                                MessageBox.Show("A tabela de preço está configurado para dar desconto máximo de " + pc_max_desc.ToString("N2", new System.Globalization.CultureInfo("pt-BR")) + "%.",
                                                            "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                //Chamar tela de usuario com autorizacao para o % desconto solicitado
                                using (Financeiro.TFLoginDesconto fLogin = new Financeiro.TFLoginDesconto())
                                {
                                    fLogin.Cd_tabelapreco = val.Cd_tabelapreco;
                                    fLogin.Cd_empresa = val.Cd_empresa;
                                    fLogin.Pc_desc = pc_desconto;
                                    if (fLogin.ShowDialog() != DialogResult.OK)
                                        return false;
                                    else
                                    {
                                        pLoginDesconto = fLogin.Logindesconto;
                                        return true;
                                    }
                                }
                            }
                            else return true;
                        }
                    //Desconto por grupo de produto
                    if (lDesc.Exists(p => p.Cd_grupo.Trim().Equals(val.lItem[i].Cd_grupo.Trim())))
                    {
                        decimal pc_max_desc = lDesc.Find(p => p.Cd_grupo.Trim().Equals(val.lItem[i].Cd_grupo.Trim())).Pc_max_desconto;
                        decimal pc_desconto = tot_desconto * 100 / pVl_receber;
                        if (pc_desconto > pc_max_desc)
                        {
                            MessageBox.Show("Desconto informado é maior que o desconto permitido pelo grupo produto!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //Chamar tela de usuario com autorizacao para o % desconto solicitado
                            using (Financeiro.TFLoginDesconto fLogin = new Financeiro.TFLoginDesconto())
                            {
                                fLogin.Cd_grupo = val.lItem[i].Cd_grupo;
                                fLogin.Cd_empresa = val.Cd_empresa;
                                fLogin.Pc_desc = pc_desconto;
                                if (fLogin.ShowDialog() != DialogResult.OK)
                                    return false;
                                else
                                {
                                    pLoginDesconto = fLogin.Logindesconto;
                                    return true;
                                }
                            }
                        }
                        else return true;
                    }
                    //Desconto por vendedor e empresa
                    decimal pc_descontoOp = tot_desconto * 100 / pVl_receber;
                    if (pc_descontoOp > lDesc[0].Pc_max_desconto)
                    {
                        MessageBox.Show("Vendedor está configurado para dar desconto máximo de " + lDesc[0].Pc_max_desconto.ToString("N2", new System.Globalization.CultureInfo("pt-BR")) + "%.",
                                                    "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //Chamar tela de usuario com autorizacao para o % desconto solicitado
                        using (Financeiro.TFLoginDesconto fLogin = new Financeiro.TFLoginDesconto())
                        {
                            fLogin.Cd_empresa = val.Cd_empresa;
                            fLogin.Pc_desc = pc_descontoOp;
                            if (fLogin.ShowDialog() != DialogResult.OK)
                                return false;
                            else
                            {
                                pLoginDesconto = fLogin.Logindesconto;
                                return true;
                            }
                        }
                    }
                    else return true;
                }
                else return true;
            }
            return true;
        }

        private void TFFecharVendaDinheiro_Load(object sender, EventArgs e)
        {
            //Buscar lista de descontos configuradas para o vendedor
            if (!string.IsNullOrEmpty(pCd_operador))
            {
                lDesc =
                   CamadaNegocio.Faturamento.Cadastros.TCN_DescontoVendedor.Buscar(pCd_operador,
                                                                                   pCd_empresa,
                                                                                   string.Empty,
                                                                                   string.Empty,
                                                                                   null);
            }
            //Somente validar desconto se venda possuir vendedor
            if (!string.IsNullOrEmpty(pCd_operador) ? (lDesc == null ? true : lDesc.Count.Equals(0)) : false)
            {
                pc_desconto.Enabled = false;
                vl_desconto.Enabled = false;
            }
            vl_venda.Value = pVl_receber;
            vl_receber.Value = pVl_receber;
            if(lPdv != null)
                lblAbrirGaveta.Visible = lPdv[0].St_gavetadinheirobool;
            vl_dinheiro.Focus();
        }

        private void pc_desconto_Leave(object sender, EventArgs e)
        {
            if ((pc_desconto.Value > decimal.Zero) &&
                (vl_venda.Value > decimal.Zero))
            {
                vl_desconto.Value = Math.Round(vl_venda.Value * pc_desconto.Value / 100, 2);
                if (!VerificarTotDesconto(rCupom, vl_desconto.Value))
                    Close();  
                TotalizarCampos();
            }
        }

        private void vl_desconto_Leave(object sender, EventArgs e)
        {
            if ((vl_desconto.Value > decimal.Zero) &&
                (vl_venda.Value > decimal.Zero))
            {
                //Calcular % Desconto
                pc_desconto.Value = Math.Round(vl_desconto.Value * 100 / vl_venda.Value, 2);
                VerificarTotDesconto(rCupom, vl_desconto.Value);
                TotalizarCampos();
            }
        }

        private void vl_dinheiro_Leave(object sender, EventArgs e)
        {
            if (vl_dinheiro.Value < vl_receber.Value)
                vl_troco.Value = decimal.Zero;
            else
                vl_troco.Value = vl_dinheiro.Value - vl_receber.Value;
            //Abrir Gaveta
            if (vl_troco.Value > 0)
                this.AbrirGavetaDinheiro();
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void bb_gravar_Click(object sender, EventArgs e)
        {
            afterGrava();
        }

        private void TFFecharVendaDinheiro_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                DialogResult = DialogResult.Cancel;
            else if (e.KeyCode.Equals(Keys.Right))
                AbrirGavetaDinheiro();
        }

        private void pc_desconto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                pc_desconto_Leave(this, new EventArgs());
                vl_desconto.Focus();
            }
        }

        private void vl_desconto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                vl_desconto_Leave(this, new EventArgs());
                vl_dinheiro.Focus();
            }
        }

        private void vl_dinheiro_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                vl_dinheiro_Leave(this, new EventArgs());
                bb_gravar.Focus();
            }
        }

        private void bb100_Click(object sender, EventArgs e)
        {
            if(ValorDinheiro(100))
                bb100.BackColor = System.Drawing.Color.Orange;
        }

        private void bb50_Click(object sender, EventArgs e)
        {
            if(ValorDinheiro(50))
                bb50.BackColor = System.Drawing.Color.Orange;
        }

        private void bb20_Click(object sender, EventArgs e)
        {
            if(ValorDinheiro(20))
                bb20.BackColor = System.Drawing.Color.Orange;
        }

        private void bb10_Click(object sender, EventArgs e)
        {
            if(ValorDinheiro(10))
                bb10.BackColor = System.Drawing.Color.Orange;
        }

        private void bb5_Click(object sender, EventArgs e)
        {
            if(ValorDinheiro(5))
                bb5.BackColor = System.Drawing.Color.Orange;
        }

        private void bb2_Click(object sender, EventArgs e)
        {
            if(ValorDinheiro(2))
                bb2.BackColor = System.Drawing.Color.Orange;
        }

        private void bb1_Click(object sender, EventArgs e)
        {
            if(ValorDinheiro(1))
                bb1.BackColor = System.Drawing.Color.Orange;
        }

        private void bb050_Click(object sender, EventArgs e)
        {
            if(ValorDinheiro(Convert.ToDecimal(0.50)))
                bb050.BackColor = System.Drawing.Color.Orange;
        }

        private void bb025_Click(object sender, EventArgs e)
        {
            if(ValorDinheiro(Convert.ToDecimal(0.25)))
                bb025.BackColor = System.Drawing.Color.Orange;
        }

        private void bb010_Click(object sender, EventArgs e)
        {
            if(ValorDinheiro(Convert.ToDecimal(0.10)))
                bb010.BackColor = System.Drawing.Color.Orange;
        }

        private void bb005_Click(object sender, EventArgs e)
        {
            if(ValorDinheiro(Convert.ToDecimal(0.05)))
                bb005.BackColor = System.Drawing.Color.Orange;
        }
    }
}
