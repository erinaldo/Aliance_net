using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Faturamento.Cadastros
{
    public partial class TFProgFidelidade : Form
    {
        public TFProgFidelidade()
        {
            InitializeComponent();
        }

        private void afterNovo()
        {
            using (TFProgFid fProg = new TFProgFid())
            {
                if(fProg.ShowDialog() == DialogResult.OK)
                    if(fProg.rProg != null)
                        try
                        {
                            CamadaNegocio.Faturamento.Fidelizacao.TCN_ProgFidelidade.Gravar(fProg.rProg, null);
                            MessageBox.Show("Programação gravada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.afterBusca();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void afterAltera()
        {
            if(bsProgFid.Current != null)
                using (TFProgFid fProg = new TFProgFid())
                {
                    fProg.rProg = bsProgFid.Current as CamadaDados.Faturamento.Fidelizacao.TRegistro_ProgFidelidade;
                    if(fProg.ShowDialog() == DialogResult.OK)
                        try
                        {
                            CamadaNegocio.Faturamento.Fidelizacao.TCN_ProgFidelidade.Gravar(fProg.rProg, null);
                            MessageBox.Show("Programação alterada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    this.afterBusca();
                }
        }

        private void afterExclui()
        {
            if(bsProgFid.Current != null)
                if(MessageBox.Show("Confirma exclusão programação corrente?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                     MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    try
                    {
                        CamadaNegocio.Faturamento.Fidelizacao.TCN_ProgFidelidade.Excluir(bsProgFid.Current as CamadaDados.Faturamento.Fidelizacao.TRegistro_ProgFidelidade, null);
                        MessageBox.Show("Programação excluida com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.afterBusca();
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void afterBusca()
        {
            bsProgFid.DataSource = CamadaNegocio.Faturamento.Fidelizacao.TCN_ProgFidelidade.Buscar(cd_empresa.Text, null);
        }

        private void TFProgFidelidade_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pFiltro.set_FormatZero();
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { cd_empresa }, string.Empty);
        }

        private void cd_empresa_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "'", new Componentes.EditDefault[] { cd_empresa });
        }

        private void BB_Novo_Click(object sender, EventArgs e)
        {
            this.afterNovo();
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            this.afterBusca();
        }

        private void BB_Alterar_Click(object sender, EventArgs e)
        {
            this.afterAltera();
        }

        private void BB_Excluir_Click(object sender, EventArgs e)
        {
            this.afterExclui();
        }

        private void TFProgFidelidade_KeyDown(object sender, KeyEventArgs e)
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
