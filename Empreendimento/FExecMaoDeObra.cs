using System;
using System.Windows.Forms;
using CamadaDados.Empreendimento.Cadastro;
using Utils;

namespace Empreendimento
{
    public partial class FExecMaoDeObra : Form
    {
        private TRegistro_CadMaoObra cMao { get; set; }
        public TRegistro_CadMaoObra rMao
        {
            get
            {
                return bsMao.Current as TRegistro_CadMaoObra;
            }
            set
            {
                cMao = value;
            }
        }
        decimal quantidade = decimal.Zero;
        decimal quantidade_exec = decimal.Zero;
        private TRegistro_ExecCadMaoObra cexecMao { get; set; }
        public TRegistro_ExecCadMaoObra rexecMao
        {
            get
            {
                return bsExecOrc.Current as TRegistro_ExecCadMaoObra;
            }
            set
            {
                cexecMao = value;
            }
        }
        public FExecMaoDeObra()
        {
            InitializeComponent();
        }

        private void FExecMaoDeObra_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
            {
                bb_inutilizar_Click(this, new EventArgs());
            }
            else if (e.KeyCode.Equals(Keys.F6))
            {
                bb_cancelar_Click(this, new EventArgs());
            }
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            if (bsMao.Current != null)
            {
                if (quantidade > decimal.Zero)
                {
                    if (quantidade_exec <= decimal.Zero)
                    {
                        MessageBox.Show("Deve informar o valor da hora trabalhada", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        qtd_hr_exec.Focus();
                        return;
                    }
                }
                (bsExecOrc.Current as TRegistro_ExecCadMaoObra).qtd_executada = quantidade_exec;
                bsExecOrc.ResetCurrentItem();
                DialogResult = DialogResult.OK;
            }
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void FExecMaoDeObra_Load(object sender, EventArgs e)
        {

            if (cMao != null)
            {
                bsMao.Add(cMao);


                bsExecOrc.AddNew();
                (bsExecOrc.Current as TRegistro_ExecCadMaoObra).Id_empresastr = cMao.Id_empresastr;
                (bsExecOrc.Current as TRegistro_ExecCadMaoObra).Id_orcamento = cMao.Id_orcamento;
                (bsExecOrc.Current as TRegistro_ExecCadMaoObra).Nr_versao = cMao.Nr_versao;
                (bsExecOrc.Current as TRegistro_ExecCadMaoObra).Id_registro = cMao.Id_MaoObra;
                (bsExecOrc.Current as TRegistro_ExecCadMaoObra).Id_execucao = decimal.Zero;

                System.Collections.ArrayList cbx = new System.Collections.ArrayList();
                cbx.Add(new Utils.TDataCombo("Normal", "0"));
                cbx.Add(new Utils.TDataCombo("Hora 50", "1"));
                cbx.Add(new Utils.TDataCombo("Hora 100", "2"));
                cbx.Add(new Utils.TDataCombo("Hora 150", "4"));
                cbx.Add(new Utils.TDataCombo("Adicional Noturno", "3"));
                cbTipoHora.DataSource = cbx;
                cbTipoHora.DisplayMember = "Display";
                cbTipoHora.ValueMember = "Value";
              //  cbEmpresa_SelectedIndexChanged(this, new EventArgs());
            }
        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            string vColunas = "a.NM_CLIFOR|Nm. Funcionario|200;" +
                              "a.CD_CLIFOR|Cd. Funcionaro|80";
            string vparam = "a.st_funcionarios|=|'S';" +
                            "a.id_cargo|=|'" + (bsMao.Current as TRegistro_CadMaoObra).Id_cargostr + "'";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_empresa, nm_empresa },
                new CamadaDados.Financeiro.Cadastros.TCD_CadClifor(),
               vparam);
        }

        private void cd_empresa_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LEAVE(
              "a.CD_CLIFOR|=|" + cd_empresa.Text + ";a.id_cargo|=|'" + (bsMao.Current as TRegistro_CadMaoObra).Id_cargostr + "'" +
              "a.st_funcionarios|=|'S'",
              new Componentes.EditDefault[] { cd_empresa, nm_empresa },
              new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void qtd_hr_exec_Leave(object sender, EventArgs e)
        {
            if (quantidade < quantidade_exec)
            {
                if (!CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin, "PERMITIR FATURAR MAIORES VALORES", null))
                    using (Proc_Commoditties.TFLanSessaoPDV fSessao = new Proc_Commoditties.TFLanSessaoPDV())
                    {
                        fSessao.Mensagem = "Usuário sem permissão de APROVAR";
                        if (fSessao.ShowDialog() == DialogResult.OK)
                        {
                            if (!CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(fSessao.Usuario, "PERMITIR FATURAR MAIORES VALORES", null))
                            {
                                MessageBox.Show("Usuário não tem permissão!");

                                qtd_hr_exec.Text = qtd_hr.Text;
                                qtd_hr_exec.Focus();
                                return;
                            }
                        }
                        else
                            return;
                    }
                else
                {
                    decimal ae = decimal.Zero;
                    String[] a = qtd_hr_exec.Text.Trim().Split(':');
                    if (Convert.ToDecimal(a[1].ToString()) >= 60)
                    {
                        ae = 59;
                    }
                    else
                        ae = Convert.ToDecimal(a[1]);

                    qtd_hr_exec.Text = (a[0]) + ":" + ae;


                }
            }
            //dt_ini_Leave(this, new EventArgs());
        }

        private void dt_ini_Leave(object sender, EventArgs e)
        {
            //Retirado preenchido automático a pedido Marelly
            //decimal hora =  qtd_hr_exec.Value;
            //double hra = Convert.ToDouble(hora);
            //if (!dt_ini.Text.Equals("  /  /       :"))
            //    dt_fim.Text = Convert.ToDateTime(dt_ini.Text).AddHours(hra).ToString();
            if (!string.IsNullOrEmpty(dt_inicial.Text.SoNumero()))
                try
                {
                    dt_inicial.TextMaskFormat = MaskFormat.IncludeLiterals;
                    Convert.ToDateTime(dt_inicial.Text);
                }
                catch
                {
                    MessageBox.Show("Data Invalida!");
                    dt_inicial.Focus();
                    dt_inicial.Clear();
                }
        }

        private void cbEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            decimal quanti = decimal.Zero;
            if (cbTipoHora.SelectedValue.Equals("0"))
                quanti = cMao.Quantidade - cMao.qtd_executada;
            else if (cbTipoHora.SelectedValue.Equals("1"))
                quanti = cMao.qtd_horascinco - cMao.qtd_exec_50;
            else if (cbTipoHora.SelectedValue.Equals("2"))
                quanti = cMao.qtd_horascen - cMao.qtd_exec_100;
            else if (cbTipoHora.SelectedValue.Equals("3"))
                quanti = cMao.qtd_adNoturno - cMao.qtd_exec_20;
            else if (cbTipoHora.SelectedValue.Equals("4"))
                quanti = cMao.Qtd_horas150 - cMao.Qtd_exec_150;
            else quanti = cMao.Quantidade - cMao.qtd_executada;

            if (quanti >= decimal.Zero)
            {
                string[] vl = quanti.ToString("N2", new System.Globalization.CultureInfo("pt-BR")).Split(',');
                string qtd = string.Empty;
                decimal a = decimal.Divide(decimal.Multiply(Convert.ToDecimal(vl[1].ToString()), 60), 100);
                qtd = ((vl[0].SoNumero() + ":").Substring(0).FormatStringEsquerda(3, '0') + a).Substring(0).FormatStringDireita(5, '0');
                this.qtd_hr.Text = qtd.ToString();
                quantidade = quanti;
            }
            else
            {
                this.qtd_hr.Text = string.Empty;
                quantidade = decimal.Zero;
            }
            //  dt_ini_Leave(this, new EventArgs());
            bsExecOrc.ResetCurrentItem();
        }

        private void dt_final_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(dt_final.Text.SoNumero()))
                try
                {
                    dt_final.TextMaskFormat = MaskFormat.IncludeLiterals;
                    Convert.ToDateTime(dt_final.Text);
                }
                catch
                {
                    MessageBox.Show("Data Invalida!");
                    dt_final.Focus();
                    dt_final.Clear();
                }
        }

        private void qtd_hr_exec_TextChanged(object sender, EventArgs e)
        {

            if (qtd_hr_exec.Text.SoNumero().Length >= 4)
            {
                decimal a = decimal.Zero;

                string[] ae = qtd_hr_exec.Text.Split(':');
                a = decimal.Divide(decimal.Multiply(Convert.ToDecimal(ae[1]), 100), 60);

                string ee = (ae[0] + "," + a.ToString("N0", new System.Globalization.CultureInfo("pt-BR")));
                // (bsExecOrc.Current as CamadaDados.Empreendimento.Cadastro.TRegistro_ExecCadMaoObra).qtd_executada = Convert.ToDecimal(ee);
                quantidade_exec = Convert.ToDecimal(ee);
            }
        }

        private void qtd_hr_TextChanged(object sender, EventArgs e)
        {
            if (qtd_hr.Text.SoNumero().Length >= 4)
            {
                decimal a = decimal.Zero;

                string[] ae = qtd_hr.Text.Split(':');
                a = decimal.Divide(decimal.Multiply(Convert.ToDecimal(ae[1]), 100), 60);

                string ee = ae[0] + "," + a.ToString("N0", new System.Globalization.CultureInfo("pt-BR"));
                //  (bsMao.Current as CamadaDados.Empreendimento.Cadastro.TRegistro_CadMaoObra).qtd_executada = Convert.ToDecimal(ee);
                quantidade = Convert.ToDecimal(ee);
            }

        }
         
    }
}
