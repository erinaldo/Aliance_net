using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CamadaDados.Diversos;
using Utils;
using FormBusca;

namespace Parametros.Diversos
{
    public partial class TFLan_Compromisso : Form
    {
        public string Id_Compromisso
        { get; set; }
        public  new CamadaDados.Diversos.TList_LanCompromisso lCompromisso
        { get; set; }

        public TFLan_Compromisso()
        {
            InitializeComponent();
            gCompromisso.RowTemplate.Height = 100;
            gCompromisso.RowTemplate.MinimumHeight = 20;
        }

        private void LimparCampos()
        {
            dt_ini.Clear();
            dt_fin.Clear();
            id_compromisso.Clear();
            nm_compromisso.Clear();
            login.Clear();
            cbAtivo.Checked = false;
            cbExecutado.Checked = false;
            cbCancelado.Checked = false;

        }

        private void afterNovo()
        {
            using (TFCompromisso fCompromisso = new TFCompromisso())
            {
                fCompromisso.Text = "NOVO COMPROMISSO";
                if (fCompromisso.ShowDialog() == DialogResult.OK)
                {
                    if (fCompromisso.rCompromisso != null)
                    {
                        try
                        {
                            CamadaNegocio.Diversos.TCN_LanCompromisso.Gravar(fCompromisso.rCompromisso, null);
                            MessageBox.Show("Compromisso gravado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.afterBusca();
                            if (fCompromisso.rCompromisso.St_enviaremailbool &&
                                (!string.IsNullOrEmpty(fCompromisso.rCompromisso.EmailUsuarioCompromisso)))
                                new FormRelPadrao.Email(new List<string>() { fCompromisso.rCompromisso.EmailUsuarioCompromisso },
                                                        fCompromisso.rCompromisso.Ds_Compromisso.Trim(),
                                                        "Data Compromisso: " + fCompromisso.rCompromisso.DtCompromisso + "\r\n" +
                                                        "Compromisso: " + fCompromisso.rCompromisso.Nm_Compromisso.Trim(),
                                                        new List<string>()).EnviarEmail();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void afterAltera() 
        {
            if (bsCompromisso.Current != null) 
            {
                using (TFCompromisso fCompromisso = new TFCompromisso()) 
                {
                    fCompromisso.rCompromisso = (bsCompromisso.Current as CamadaDados.Diversos.TRegistro_LanCompromisso);
                    if(fCompromisso.ShowDialog() == DialogResult.OK)
                    {
                        if (fCompromisso != null) 
                        {
                            try
                            {
                                CamadaNegocio.Diversos.TCN_LanCompromisso.Gravar(fCompromisso.rCompromisso, null);
                                MessageBox.Show("Compromisso alterado com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.afterBusca();
                                if (fCompromisso.rCompromisso.St_enviaremailbool &&
                                (!string.IsNullOrEmpty(fCompromisso.rCompromisso.EmailUsuarioCompromisso)))
                                    new FormRelPadrao.Email(new List<string>() { fCompromisso.rCompromisso.EmailUsuarioCompromisso },
                                                            fCompromisso.rCompromisso.Ds_Compromisso.Trim(),
                                                            "Alteração Compromisso.\r\n" +
                                                            "Data Compromisso: " + fCompromisso.rCompromisso.DtCompromisso + "\r\n" +
                                                            "Compromisso: " + fCompromisso.rCompromisso.Nm_Compromisso.Trim(),
                                                            new List<string>()).EnviarEmail();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }

            }
            else
                MessageBox.Show("Necessário selecionar um compromisso para alterar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void afterExclui()
        {
            if (bsCompromisso.Current != null)
            {
                if (MessageBox.Show("Deseja realmente excluir o compromisso selecionado?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                     MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    try
                    {

                        CamadaNegocio.Diversos.TCN_LanCompromisso.Deleta(bsCompromisso.Current as TRegistro_LanCompromisso, null);
                        MessageBox.Show("Compromisso excluído com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.afterBusca();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
                MessageBox.Show("Obrigatório selecionar um compromisso para e efetuar a exclusão.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void afterBusca()
        {
            string status = string.Empty;
            string virg = string.Empty;
            if (cbAtivo.Checked)
            {
                status = "'A'";
                virg = ",";
            }
            if (cbExecutado.Checked)
            {
                status += virg + "'E'";
                virg = ",";
            }
            if (cbCancelado.Checked)
                status += virg + "'C'";
            bsCompromisso.DataSource = CamadaNegocio.Diversos.TCN_LanCompromisso.Busca(id_compromisso.Text,
                                                                                       nm_compromisso.Text,
                                                                                       string.Empty,
                                                                                       dt_ini.Text,
                                                                                       dt_fin.Text,
                                                                                       login.Text,
                                                                                       status,
                                                                                       null);
        }

        private void BB_Novo_Click(object sender, EventArgs e)
        {
            afterNovo();
        }

        private void BB_Alterar_Click(object sender, EventArgs e)
        {
            afterAltera();
        }

        private void BB_Excluir_Click(object sender, EventArgs e)
        {
            afterExclui();
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            this.afterBusca();
        }

        private void calendario_DateSelected(object sender, DateRangeEventArgs e)
        {
            bsCompromisso.DataSource = CamadaNegocio.Diversos.TCN_LanCompromisso.Busca(string.Empty,
                                                                                       string.Empty,
                                                                                       string.Empty,
                                                                                       e.Start.ToString("dd/MM/yyyy 00:00:00"),
                                                                                       e.Start.ToString("dd/MM/yyyy 23:59:59"),
                                                                                       string.Empty,
                                                                                       string.Empty,
                                                                                       null);
        }

        private void gCompromisso_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
                if (e.ColumnIndex.Equals(0))
                {
                    if (e.Value.ToString().Trim().ToUpper().Equals("EXECUTADO"))
                        gCompromisso.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Green;
                    else if (e.Value.ToString().Trim().ToUpper().Equals("CANCELADO"))
                        gCompromisso.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
                    else
                        gCompromisso.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                }
        }

        private void TFLan_Compromisso_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            calendario.TitleBackColor = Utils.SettingsUtils.Default.COLOR_1;
            if (lCompromisso != null)
                bsCompromisso.DataSource = lCompromisso;

            if (!string.IsNullOrEmpty(Id_Compromisso))
            {
                id_compromisso.Text = Id_Compromisso;
                this.afterBusca();
            }
        }

        private void BB_Usuario_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("login|Login|80;Nome_usuario|Nome Login|350",
              new Componentes.EditDefault[] { login }, new TCD_CadUsuario(), "");
        }

        private void login_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("login|=|'" + login.Text + "'", new Componentes.EditDefault[] { login }
                , new TCD_CadUsuario());
        }

        private void TFLan_Compromisso_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F2))
                this.afterNovo();
            else if (e.KeyCode.Equals(Keys.F3))
                this.afterAltera();
            else if (e.KeyCode.Equals(Keys.F5))
                this.afterExclui();
            else if (e.KeyCode.Equals(Keys.F7))
                this.afterBusca();
        }
    }
}