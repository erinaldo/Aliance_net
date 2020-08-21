using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utils;
using CamadaDados.Diversos;
using CamadaNegocio.Diversos;

namespace Parametros.Diversos
{
    public partial class TFCadLojaVirtual : Form
    {
        public TFCadLojaVirtual()
        {
            InitializeComponent();
        }

        private void afterNovo()
        {
            using (TFLojaVirtual fLoja = new Diversos.TFLojaVirtual())
            {
                if(fLoja.ShowDialog() == DialogResult.OK)
                    if(fLoja.Loja != null)
                        try
                        {
                            TCN_LojaVirtual.Gravar(fLoja.Loja, null);
                            MessageBox.Show("Loja gravada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            afterBusca();
                        }
                        catch(Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void afterAltera()
        {
            if(bsLojaVirtual.Current != null)
                using (TFLojaVirtual fLoja = new TFLojaVirtual())
                {
                    fLoja.Loja = bsLojaVirtual.Current as TRegistro_LojaVirtual;
                    if(fLoja.ShowDialog() == DialogResult.OK)
                        try
                        {
                            TCN_LojaVirtual.Gravar(fLoja.Loja, null);
                            MessageBox.Show("Loja alterada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch(Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    afterBusca();
                }
        }

        private void afterExclui()
        {
            if(bsLojaVirtual.Current != null)
                if(MessageBox.Show("Confirma exclusão do registro selecionado?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    == DialogResult.Yes)
                    try
                    {
                        TCN_LojaVirtual.Excluir(bsLojaVirtual.Current as TRegistro_LojaVirtual, null);
                        MessageBox.Show("Loja excluida com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        afterBusca();
                    }
                    catch(Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void afterBusca()
        {
            bsLojaVirtual.DataSource = TCN_LojaVirtual.Buscar(cbEmpresa.SelectedItem == null ? string.Empty : cbEmpresa.SelectedValue.ToString(),
                                                              id_loja.Text,
                                                              nm_loja.Text,
                                                              null);
        }

        private void TFCadLojaVirtual_Load(object sender, EventArgs e)
        {
            Icon = ResourcesUtils.TecnoAliance_ICO;
            pFiltro.set_FormatZero();
            cbEmpresa.DataSource = new CamadaDados.Diversos.TCD_CadEmpresa().Select(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = string.Empty,
                                            vOperador = "exists",
                                            vVL_Busca = "(select 1 from tb_div_usuario_x_empresa x " +
                                                        "where x.cd_empresa = a.cd_empresa " +
                                                        "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                                        "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                                        "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))"
                                        }
                                    }, 0, string.Empty);
            cbEmpresa.DisplayMember = "NM_Empresa";
            cbEmpresa.ValueMember = "CD_Empresa";
        }

        private void BB_Novo_Click(object sender, EventArgs e)
        {
            afterNovo();
        }

        private void BB_Excluir_Click(object sender, EventArgs e)
        {
            afterExclui();
        }

        private void BB_Alterar_Click(object sender, EventArgs e)
        {
            afterAltera();
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            afterBusca();
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void TFCadLojaVirtual_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F2))
                afterNovo();
            else if (e.KeyCode.Equals(Keys.F3))
                afterAltera();
            else if (e.KeyCode.Equals(Keys.F5))
                afterExclui();
            else if (e.KeyCode.Equals(Keys.F7))
                afterBusca();
        }
    }
}
