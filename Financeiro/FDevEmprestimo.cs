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
    public partial class TFDevEmprestimo : Form
    {
        private bool vST_lancarCheque = false;

        private CamadaDados.Financeiro.Emprestimos.TRegistro_Emprestimos remp;
        public CamadaDados.Financeiro.Emprestimos.TRegistro_Emprestimos rEmp
        {
            get { return bsEmprestimo.Current as CamadaDados.Financeiro.Emprestimos.TRegistro_Emprestimos; }
            set { remp = value; }
        }

        public TFDevEmprestimo()
        {
            InitializeComponent();

            System.Collections.ArrayList cbx = new System.Collections.ArrayList();
            cbx.Add(new Utils.TDataCombo("RECEBIDO", "R"));
            cbx.Add(new Utils.TDataCombo("CONCEDIDO", "C"));

            tp_emprestimo.DataSource = cbx;
            tp_emprestimo.DisplayMember = "Display";
            tp_emprestimo.ValueMember = "Value";
        }

        private void afterGrava()
        {
            if (pDados.validarCampoObrigatorio())
            {
                if (vl_devolver.Value.Equals(decimal.Zero))
                {
                    MessageBox.Show("Obrigatorio informar valor devolver.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    vl_devolver.Focus();
                    return;
                }
                if (vl_devolver.Value > vl_saldo.Value)
                    vl_devolver.Value = vl_saldo.Value;
                if (vl_saldo.Focused)
                    (bsEmprestimo.Current as CamadaDados.Financeiro.Emprestimos.TRegistro_Emprestimos).Vl_devolver = vl_devolver.Value;
                if (vST_lancarCheque)
                {
                    using (TFLanListaCheques fListaCheques = new TFLanListaCheques())
                    {
                        fListaCheques.Tp_mov = tp_emprestimo.SelectedValue.ToString().Trim().ToUpper().Equals("C") ? "R" : "P";
                        fListaCheques.Cd_empresa = CD_Empresa.Text;
                        fListaCheques.Cd_contager = cd_contager_dev.Text;
                        fListaCheques.Ds_contager = ds_contager_dev.Text;
                        fListaCheques.Cd_clifor = (bsEmprestimo.Current as CamadaDados.Financeiro.Emprestimos.TRegistro_Emprestimos).Cd_clifor;
                        fListaCheques.Cd_portador = cd_portador.Text;
                        fListaCheques.Ds_portador = ds_portador.Text;
                        fListaCheques.Nm_clifor = (bsEmprestimo.Current as CamadaDados.Financeiro.Emprestimos.TRegistro_Emprestimos).Nm_clifor;
                        fListaCheques.Dt_emissao = (bsEmprestimo.Current as CamadaDados.Financeiro.Emprestimos.TRegistro_Emprestimos).Dt_emprestimo;
                        fListaCheques.Vl_totaltitulo = vl_devolver.Value;
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

        private void vl_devolver_Leave(object sender, EventArgs e)
        {
            if (vl_devolver.Value > vl_saldo.Value)
            {
                MessageBox.Show("Valor devolver não pode ser maior que saldo devolver.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                vl_devolver.Value = vl_saldo.Value;
                vl_devolver.Focus();
            }
        }

        private void TFDevEmprestimo_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pDados.set_FormatZero();
            bsEmprestimo.DataSource = new CamadaDados.Financeiro.Emprestimos.TList_Emprestimos() { remp };
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void TFDevEmprestimo_KeyDown(object sender, KeyEventArgs e)
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

        private void bb_contager_dev_Click(object sender, EventArgs e)
        {
            string vCond = "|exists|(select 1 from tb_div_usuario_x_contager x " +
                           "where x.cd_contager = a.cd_contager " +
                           "and x.login = '" + Utils.Parametros.pubLogin.Trim() + "');" +
                           "|exists|(select 1 from TB_Fin_ContaGer_X_Empresa k " +
                           "where k.CD_ContaGer = a.CD_ContaGer " +
                           "and k.cd_Empresa = '" + CD_Empresa.Text + "');" +
                           "a.st_contaCF|=|1;" +
                           "a.st_contacartao|<>|0";
            if (tp_emprestimo.SelectedValue.ToString().Trim().ToUpper().Equals("R"))
            {
                if (vST_lancarCheque)
                    vCond += ";ISNULL(a.ST_ContaCompensacao,'N')|=|'S'";
                else
                    vCond += ";ISNULL(a.ST_ContaCompensacao,'N')|=|'N'";
            }
            else if (tp_emprestimo.SelectedValue.ToString().Trim().ToUpper().Equals("C"))
                vCond += ";ISNULL(a.st_contacompensacao, 'N')|<>|'S'";
            string vColunas = "a.ds_contager|Conta|350;" +
                              "a.CD_ContaGer|Cód. Conta|100";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_contager_dev, ds_contager_dev },
                                                new CamadaDados.Financeiro.Cadastros.TCD_CadContaGer(), vCond);
        }

        private void cd_contager_dev_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.CD_ContaGer|=|'" + cd_contager_dev.Text.Trim() + "';" +
                              "|exists|(select 1 from TB_Fin_ContaGer_X_Empresa k " +
                              "where k.CD_ContaGer = a.CD_ContaGer " +
                              "and k.cd_Empresa = '" + CD_Empresa.Text.Trim() + "' );" +
                              "|exists|(select 1 from tb_div_usuario_x_contager x " +
                              "where x.cd_contager = a.cd_contager " +
                              "and x.login = '" + Utils.Parametros.pubLogin.Trim() + "');" +
                              "a.st_contaCF|=|1;" +
                              "a.st_contacartao|=|0";
            if (tp_emprestimo.SelectedValue.ToString().Trim().ToUpper().Equals("R"))
            {
                if (vST_lancarCheque)
                    vColunas += ";ISNULL(a.ST_ContaCompensacao,'N')|=|'S'";
                else
                    vColunas += ";ISNULL(a.ST_ContaCompensacao,'N')|=|'N'";
            }
            else if (tp_emprestimo.SelectedValue.ToString().Trim().ToUpper().Equals("C"))
                vColunas += ";ISNULL(a.st_contacompensacao, 'N')|<>|'S'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vColunas,
            new Componentes.EditDefault[] { cd_contager_dev, ds_contager_dev },
            new CamadaDados.Financeiro.Cadastros.TCD_CadContaGer());
        }
    }
}
