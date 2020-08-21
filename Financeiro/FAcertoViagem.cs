using CamadaNegocio.Financeiro.Viagem;
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
    public partial class TFAcertoViagem : Form
    {
        public List<CamadaDados.Financeiro.Viagem.TRegistro_Viagem> lViagem
        {
            get
            {
                if (bsViagem.Count > 0)
                    return (bsViagem.DataSource as CamadaDados.Financeiro.Viagem.TList_Viagem).FindAll(p => p.St_processar);
                else
                    return null;
            }
        }
        public TFAcertoViagem()
        {
            InitializeComponent();
            Height = Screen.PrimaryScreen.Bounds.Height - (Screen.PrimaryScreen.Bounds.Height / 10) * 1;
            Width = Screen.PrimaryScreen.Bounds.Width - (Screen.PrimaryScreen.Bounds.Width / 10) * 1;
        }

        private void afterGrava()
        {
            if (bsViagem.Current != null)
                if ((bsViagem.DataSource as CamadaDados.Financeiro.Viagem.TList_Viagem).Exists(p => p.St_processar))
                    DialogResult = DialogResult.OK;
                else
                    MessageBox.Show("Obrigatório selecionar viagens para processar!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void afterBusca()
        {
            if (cbEmpresa.SelectedValue != null &&
                !string.IsNullOrEmpty(cd_funcionario.Text))
            {
                bsViagem.DataSource = TCN_Viagem.Buscar(string.Empty,
                                                      cbEmpresa.SelectedValue.ToString(),
                                                      cd_funcionario.Text,
                                                      string.Empty,
                                                      string.Empty,
                                                      string.Empty,
                                                      string.Empty,
                                                      string.Empty,
                                                      string.Empty,
                                                      "'A'",
                                                      null);
                bsViagem.ResetCurrentItem();
                Totalizar();
            }
        }

        private void Totalizar()
        {
            if (bsViagem.Current != null)
            {
                SaldoAtual.Value = (bsViagem.Current as CamadaDados.Financeiro.Viagem.TRegistro_Viagem).SaldoDevolverC;
                TotalDespesas.Value = (bsViagem.DataSource as CamadaDados.Financeiro.Viagem.TList_Viagem).FindAll(p => p.St_processar).Sum(p => p.Vl_despesasM);
                SaldoRestante.Value = (bsViagem.Current as CamadaDados.Financeiro.Viagem.TRegistro_Viagem).SaldoDevolverC -
                                      (bsViagem.DataSource as CamadaDados.Financeiro.Viagem.TList_Viagem).FindAll(p => p.St_processar).Sum(p => p.Vl_despesasM) <= 0 ? 0 :
                                      (bsViagem.Current as CamadaDados.Financeiro.Viagem.TRegistro_Viagem).SaldoDevolverC -
                                      (bsViagem.DataSource as CamadaDados.Financeiro.Viagem.TList_Viagem).FindAll(p => p.St_processar).Sum(p => p.Vl_despesasM);
                TotalPagar.Value = (bsViagem.DataSource as CamadaDados.Financeiro.Viagem.TList_Viagem).FindAll(p => p.St_processar).Sum(p => p.Vl_despesasM) -
                                    (bsViagem.Current as CamadaDados.Financeiro.Viagem.TRegistro_Viagem).SaldoDevolverC > 0 ?
                                    (bsViagem.DataSource as CamadaDados.Financeiro.Viagem.TList_Viagem).FindAll(p => p.St_processar).Sum(p => p.Vl_despesasM) -
                                    (bsViagem.Current as CamadaDados.Financeiro.Viagem.TRegistro_Viagem).SaldoDevolverC : 0;
            }
        }

        private void TFAcertoViagem_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pConsulta.set_FormatZero();
            //Buscar Empresa
            cbEmpresa.DataSource = new CamadaDados.Diversos.TCD_CadEmpresa().Select(
                                    new Utils.TpBusca[]
                                    {
                                        new Utils.TpBusca()
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

        private void cd_funcionario_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_clifor|=|'" + cd_funcionario.Text.Trim() + "';" +
                                "ISNULL(a.st_funcionarios, 'N')|=|'S'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_funcionario, nm_funcionario },
                                            new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
            afterBusca();
        }

        private void bb_funcionario_Click(object sender, EventArgs e)
        {
            string vColunas = "a.nm_clifor|Motorista|200;" +
                             "a.cd_clifor|Codigo|80";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_funcionario, nm_funcionario },
                new CamadaDados.Financeiro.Cadastros.TCD_CadClifor(),
               "ISNULL(a.st_funcionarios, 'N')|=|'S'");
            afterBusca();
        }

        private void cbTodos_Click(object sender, EventArgs e)
        {
            if (bsViagem.Count > 0)
            {
                (bsViagem.DataSource as CamadaDados.Financeiro.Viagem.TList_Viagem).ForEach(p => p.St_processar = cbTodos.Checked);
                bsViagem.ResetBindings(true);
                Totalizar();
            }
        }

        private void gViagem_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                (bsViagem.Current as CamadaDados.Financeiro.Viagem.TRegistro_Viagem).St_processar =
                    !(bsViagem.Current as CamadaDados.Financeiro.Viagem.TRegistro_Viagem).St_processar;
                bsViagem.ResetCurrentItem();
                Totalizar();
            }
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            afterGrava();
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void TFAcertoViagem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                DialogResult = DialogResult.Cancel;
        }

        private void cbEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            afterBusca();
        }
    }
}
