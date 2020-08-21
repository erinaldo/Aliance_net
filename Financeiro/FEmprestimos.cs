using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Financeiro
{
    public partial class TFEmprestimos : Form
    {
        private bool vST_lancarCheque = false;

        public CamadaDados.Financeiro.Emprestimos.TRegistro_Emprestimos rEmp
        { get { return bsEmprestimo.Current as CamadaDados.Financeiro.Emprestimos.TRegistro_Emprestimos; } }

        public TFEmprestimos()
        {
            InitializeComponent();

            System.Collections.ArrayList cbx = new System.Collections.ArrayList();
            cbx.Add(new Utils.TDataCombo("RECEBIDO", "R"));
            cbx.Add(new Utils.TDataCombo("CONCEDIDO", "C"));

            tp_emprestimo.DataSource = cbx;
            tp_emprestimo.DisplayMember = "Display";
            tp_emprestimo.ValueMember = "Value";
        }

        private void BuscarEndereco()
        {
            if (!string.IsNullOrEmpty(cd_clifor.Text))
            {
                object obj = new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco().BuscarEscalar(
                    new Utils.TpBusca[]
                    {
                        new Utils.TpBusca()
                        {
                            vNM_Campo = "a.cd_clifor",
                            vOperador = "=",
                            vVL_Busca = "'" + cd_clifor.Text.Trim() + "'"
                        }
                    }, "a.cd_endereco");
                if (obj != null)
                    CD_Endereco.Text = obj.ToString();
            }
        }

        private void afterGrava()
        {
            if (pDados.validarCampoObrigatorio())
            {
                if (vl_emprestimo.Value.Equals(decimal.Zero))
                {
                    MessageBox.Show("Obrigatorio informar valor emprestimo.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    vl_emprestimo.Focus();
                    return;
                }
                if (vl_emprestimo.Focused)
                    (bsEmprestimo.Current as CamadaDados.Financeiro.Emprestimos.TRegistro_Emprestimos).Vl_emprestimo = vl_emprestimo.Value;
                if (vST_lancarCheque)
                {
                    using (TFLanListaCheques fListaCheques = new TFLanListaCheques())
                    {
                        fListaCheques.Tp_mov = tp_emprestimo.SelectedValue.ToString().Trim().ToUpper().Equals("C") ? "P" : "R";
                        fListaCheques.Cd_empresa = CD_Empresa.Text;
                        fListaCheques.Cd_contager = cd_contager.Text;
                        fListaCheques.Ds_contager = ds_contager.Text;
                        fListaCheques.Cd_clifor = cd_clifor.Text;
                        fListaCheques.Cd_portador = cd_portador.Text;
                        fListaCheques.Ds_portador = ds_portador.Text;
                        fListaCheques.Nm_clifor = nm_clifor.Text;
                        fListaCheques.Dt_emissao = dt_emprestimo.Data;
                        fListaCheques.Vl_totaltitulo = vl_emprestimo.Value;
                        if (fListaCheques.ShowDialog() == DialogResult.OK)
                            (bsEmprestimo.Current as CamadaDados.Financeiro.Emprestimos.TRegistro_Emprestimos).lCheque = fListaCheques.lCheques;
                        else
                        {
                            MessageBox.Show("Obrigatorio informar cheque(s) para gravar emprestimo.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                }
                this.DialogResult = DialogResult.OK;
            }
        }

        private void TFEmprestimos_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pDados.set_FormatZero();
            bsEmprestimo.AddNew();
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

        private void cd_clifor_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + cd_clifor.Text.Trim() + "'",
                                                    new Componentes.EditDefault[] { cd_clifor, nm_clifor },
                                                    new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
            this.BuscarEndereco();
        }

        private void bb_clifor_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_clifor, nm_clifor }, string.Empty);
            this.BuscarEndereco();
        }

        private void bb_endereco_Click(object sender, EventArgs e)
        {
            string vColunas = "a.DS_Endereco|Endereço|350;" +
                              "a.CD_Endereco|Cód. Endereço|80;" +
                              "a.UF|UF|80;" +
                              "a.DS_cidade|Cidade|100;" +
                              "a.CD_UF|Código|100";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_Endereco, DS_Endereco },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco(), "b.CD_CLIFOR|=|" + cd_clifor.Text);
        }

        private void CD_Endereco_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.CD_Endereco|=|'" + CD_Endereco.Text + "';" + "b.cd_clifor|=|'" + cd_clifor.Text + "'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_Endereco, DS_Endereco },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco());
        }
                
        private void bb_contager_Click(object sender, EventArgs e)
        {
            if (tp_emprestimo.SelectedValue == null)
            {
                MessageBox.Show("Obrigatorio selecionar tipo emprestimo para prosseguir.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string vCond = "|exists|(select 1 from tb_div_usuario_x_contager x " +
                           "where x.cd_contager = a.cd_contager " +
                           "and x.login = '" + Utils.Parametros.pubLogin.Trim() + "');" +
                           "|exists|(select 1 from TB_Fin_ContaGer_X_Empresa k " +
                           "where k.CD_ContaGer = a.CD_ContaGer " +
                           "and k.cd_Empresa = '" + CD_Empresa.Text + "');" +
                           "a.st_contaCF|=|1;" +
                           "a.st_contacartao|<>|0";
            if (tp_emprestimo.SelectedValue.ToString().Trim().ToUpper().Equals("C"))
            {
                if (vST_lancarCheque)
                    vCond += ";ISNULL(a.ST_ContaCompensacao,'N')|=|'S'";
                else
                    vCond += ";ISNULL(a.ST_ContaCompensacao,'N')|=|'N'";
            }
            else if (tp_emprestimo.SelectedValue.ToString().Trim().ToUpper().Equals("R"))
                vCond += ";ISNULL(a.st_contacompensacao, 'N')|<>|'S'";
            string vColunas = "a.ds_contager|Conta|350;" +
                              "a.CD_ContaGer|Cód. Conta|100";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_contager, ds_contager },
                                                new CamadaDados.Financeiro.Cadastros.TCD_CadContaGer(), vCond);
        }

        private void cd_contager_Leave(object sender, EventArgs e)
        {
            if (tp_emprestimo.SelectedValue == null)
            {
                MessageBox.Show("Obrigatorio selecionar tipo emprestimo para prosseguir.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string vColunas = "a.CD_ContaGer|=|'" + cd_contager.Text.Trim() + "';" +
                              "|exists|(select 1 from TB_Fin_ContaGer_X_Empresa k " +
                              "where k.CD_ContaGer = a.CD_ContaGer " +
                              "and k.cd_Empresa = '" + CD_Empresa.Text.Trim() + "' );" +
                              "|exists|(select 1 from tb_div_usuario_x_contager x " +
                              "where x.cd_contager = a.cd_contager " +
                              "and x.login = '" + Utils.Parametros.pubLogin.Trim() + "');" +
                              "a.st_contaCF|=|1;" +
                              "a.st_contacartao|=|0";
            if (tp_emprestimo.SelectedValue.ToString().Trim().ToUpper().Equals("C"))
            {
                if (vST_lancarCheque)
                    vColunas += ";ISNULL(a.ST_ContaCompensacao,'N')|=|'S'";
                else
                    vColunas += ";ISNULL(a.ST_ContaCompensacao,'N')|=|'N'";
            }
            else if (tp_emprestimo.SelectedValue.ToString().Trim().ToUpper().Equals("R"))
                vColunas += ";ISNULL(a.st_contacompensacao, 'N')|<>|'S'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vColunas,
            new Componentes.EditDefault[] { cd_contager, ds_contager },
            new CamadaDados.Financeiro.Cadastros.TCD_CadContaGer());
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void TFEmprestimos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }

        private void bb_portador_Click(object sender, EventArgs e)
        {
            string vColunas = "DS_Portador|Portador|350;" +
                  "CD_Portador|Cód. Portador|100";
            string vParam = "a.st_cartaocredito|=|1";
            DataRowView reg = FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_portador, ds_portador },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadPortador(), vParam);
            if (reg != null)
                vST_lancarCheque = reg["ST_ControleTitulo"].ToString().Trim().ToUpper().Equals("S");
            else
                vST_lancarCheque = false;
        }

        private void cd_portador_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_portador|=|'" + cd_portador.Text.Trim() + "';" +
                            "a.st_cartaocredito|=|1";
            DataRow reg = FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_portador, ds_portador },
                                                            new CamadaDados.Financeiro.Cadastros.TCD_CadPortador());
            if (reg != null)
                vST_lancarCheque = reg["ST_ControleTitulo"].ToString().Trim().ToUpper().Equals("S");
            else
                vST_lancarCheque = false;
        }

        private void bb_juro_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_juro|Juro|150;" +
                              "a.cd_juro|Codigo|80;" +
                              "a.pc_jurodiario_atrazo|% Juro|100";
            DataRowView linha = FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_juro, ds_juro },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadJuro(), string.Empty);
            if (linha != null)
                pc_juro.Value = decimal.Parse(linha["pc_jurodiario_atrazo"].ToString());
        }

        private void cd_juro_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_juro|=|'" + cd_juro.Text.Trim() + "'";
            DataRow linha = FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_juro, ds_juro },
                            new CamadaDados.Financeiro.Cadastros.TCD_CadJuro());
            if (linha != null)
                pc_juro.Value = decimal.Parse(linha["pc_jurodiario_atrazo"].ToString());
        }
    }
}
