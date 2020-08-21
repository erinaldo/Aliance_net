using System;
using System.Windows.Forms;
using Utils;

namespace Aliance.NET
{
    public partial class TFCalcChaveAcesso : Form
    {
        public TFCalcChaveAcesso()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if (string.IsNullOrEmpty(NR_CGC.Text.SoNumero()))
            {
                MessageBox.Show("Obrigatório informar CNPJ.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                NR_CGC.Focus();
                return;
            }
            if(string.IsNullOrEmpty(dt_ativacao.Text.SoNumero()))
            {
                MessageBox.Show("Obrigatorio informar data ativação.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dt_ativacao.Focus();
                return;
            }
            if (string.IsNullOrEmpty(nr_sequencial.Text))
            {
                MessageBox.Show("Obrigatório informar sequencial", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                nr_sequencial.Focus();
                return;
            }
            if(string.IsNullOrEmpty(qt_diasvalidade.Text))
            {
                MessageBox.Show("Obrigatorio informar quantidade de dias validade.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                qt_diasvalidade.Focus();
                return;
            }
            if (!Estruturas.ValidarChaveAcesso(NR_CGC.Text,
                                               Convert.ToDouble(nr_sequencial.Text),
                                               DateTime.Parse(dt_ativacao.Text),
                                               Convert.ToDouble(qt_diasvalidade.Text),
                                               chave1.Text.Trim() + 
                                               chave2.Text.Trim() + 
                                               chave3.Text.Trim() + 
                                               chave4.Text.Trim()))
            {
                MessageBox.Show("Chave de acesso invalida.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                chave1.Focus();
                return;
            }
            try
            {
                //Gravar licenca
                CamadaNegocio.Diversos.TCN_Licenca.Gravar(
                    new CamadaDados.Diversos.TRegistro_Licenca()
                    {
                        Dt_ativacaostr = dt_ativacao.Text,
                        Dt_ultimoacessostr = dt_ativacao.Text,
                        Qt_diasvalidade = decimal.Parse(qt_diasvalidade.Text),
                        Chave_validade = chave1.Text.Trim() + 
                                         chave2.Text.Trim() + 
                                         chave3.Text.Trim() + 
                                         chave4.Text.Trim(),
                        Nr_sequencial = Convert.ToInt32(nr_sequencial.Text),
                        Hash_chave = Estruturas.SHA1(dt_ativacao.Text.Trim() +
                                                     decimal.Parse(nr_sequencial.Text).ToString() +
                                                     Convert.ToInt32(qt_diasvalidade.Text).ToString() +
                                                     chave1.Text.Trim() + 
                                                     chave2.Text.Trim() + 
                                                     chave3.Text.Trim() + 
                                                     chave4.Text.Trim())
                    }, null);
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro gravar licença: " + ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.Cancel;
            }
        }

        private void TFCalcChaveAcesso_Load(object sender, EventArgs e)
        {
            Icon = ResourcesUtils.TecnoAliance_ICO;
            chave1.CharacterCasing = CharacterCasing.Normal;
            chave2.CharacterCasing = CharacterCasing.Normal;
            chave3.CharacterCasing = CharacterCasing.Normal;
            chave4.CharacterCasing = CharacterCasing.Normal;
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            afterGrava();
        }

        private void TFCalcChaveAcesso_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                DialogResult = DialogResult.Cancel;
        }

        private void NR_CGC_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(NR_CGC.Text.SoNumero()))
            {
                CNPJ_Valido.nr_CNPJ = NR_CGC.Text;
                if (string.IsNullOrEmpty(CNPJ_Valido.nr_CNPJ))
                {
                    MessageBox.Show("CNPJ Invalido.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    NR_CGC.Clear();
                }
            }
        }

        private void bb_clifor_Click(object sender, EventArgs e)
        {
            System.Data.DataRowView linha = FormBusca.UtilPesquisa.BTN_BuscaClifor(null, "a.tp_pessoa|=|'J'");
            if (linha != null)
                NR_CGC.Text = linha["nr_cgc"].ToString();
        }

        private void chave1_Leave(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(chave1.Text))
                if (chave1.Text.Trim().Length < 4)
                {
                    MessageBox.Show("Chave incompleta.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    chave1.Focus();
                }
        }

        private void chave2_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(chave2.Text))
                if (chave2.Text.Trim().Length < 4)
                {
                    MessageBox.Show("Chave incompleta.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    chave2.Focus();
                }
        }

        private void chave3_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(chave3.Text))
                if (chave3.Text.Trim().Length < 4)
                {
                    MessageBox.Show("Chave incompleta.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    chave3.Focus();
                }
        }

        private void chave4_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(chave4.Text))
                if (chave4.Text.Trim().Length < 4)
                {
                    MessageBox.Show("Chave incompleta.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    chave4.Focus();
                }
        }
    }
}
