using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CamadaDados.Estoque.Cadastros;
using CamadaNegocio.Estoque.Cadastros;

namespace Estoque.Cadastros
{
    public partial class TFCadMarkup : Form
    {
        public TFCadMarkup()
        {
            InitializeComponent();
        }

        private void afterNovo()
        {
            using (TFMarkup fMarkup = new TFMarkup())
            {
                if (fMarkup.ShowDialog() == DialogResult.OK)
                    if (fMarkup.rMarkup != null)
                        try
                        {
                            CamadaNegocio.Estoque.Cadastros.TCN_Markup.Gravar(fMarkup.rMarkup, null);
                            MessageBox.Show("Indice Markup cadastrado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            id_markup.Clear();
                            ds_markup.Clear();
                            id_markup.Text = fMarkup.rMarkup.Id_markupstr;
                            this.afterBusca();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void afterAltera()
        {
            if (bsMarkup.Current != null)
            {
                using (TFMarkup fMarkup = new TFMarkup())
                {
                    fMarkup.rMarkup = bsMarkup.Current as CamadaDados.Estoque.Cadastros.TRegistro_Markup;
                    if(fMarkup.ShowDialog() == DialogResult.OK)
                        if(fMarkup.rMarkup != null)
                            try
                            {
                                CamadaNegocio.Estoque.Cadastros.TCN_Markup.Gravar(fMarkup.rMarkup, null);
                                MessageBox.Show("Indice Markup alterado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    id_markup.Clear();
                    ds_markup.Clear();
                    id_markup.Text = fMarkup.rMarkup.Id_markupstr;
                    this.afterBusca();
                }
            }
        }

        private void afterExclui()
        {
            if(bsMarkup.Current != null)
                if (MessageBox.Show("Confirma exclusão do registro selecionado?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                     MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    try
                    {
                        CamadaNegocio.Estoque.Cadastros.TCN_Markup.Excluir(bsMarkup.Current as CamadaDados.Estoque.Cadastros.TRegistro_Markup, null);
                        MessageBox.Show("Indice excluido com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        id_markup.Clear();
                        ds_markup.Clear();
                        this.afterBusca();
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void afterBusca()
        {
            bsMarkup.DataSource = TCN_Markup.Buscar(cd_empresa.Text,
                                                    id_markup.Text,
                                                    ds_markup.Text,
                                                    null);
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            this.afterBusca();
        }

        private void TFCadMarkup_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, dataGridDefault1);
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
        }

        private void BB_Novo_Click(object sender, EventArgs e)
        {
            this.afterNovo();
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bb_alterar_Click(object sender, EventArgs e)
        {
            this.afterAltera();
        }

        private void BB_Excluir_Click(object sender, EventArgs e)
        {
            this.afterExclui();
        }

        private void TFCadMarkup_KeyDown(object sender, KeyEventArgs e)
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

        private void TFCadMarkup_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, dataGridDefault1);
        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { cd_empresa }, string.Empty);
        }

        private void cd_empresa_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "'", new Componentes.EditDefault[] { cd_empresa });
        }
    }
}
