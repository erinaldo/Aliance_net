using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Utils;
using FormBusca;

namespace Financeiro.Cadastros
{
    public partial class TFCadCfgEmprestimos : FormCadPadrao.FFormCadPadrao
    {
        public TFCadCfgEmprestimos()
        {
            InitializeComponent();
        }

        public override string gravarRegistro()
        {
            if (pDados.validarCampoObrigatorio())
                return CamadaNegocio.Financeiro.Cadastros.TCN_CfgEmprestimos.Gravar(bsCfgEmprestimos.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CfgEmprestimos, null);
            else
                return string.Empty;
        }

        public override int buscarRegistros()
        {
            CamadaDados.Financeiro.Cadastros.TList_CfgEmprestimos lista =
                CamadaNegocio.Financeiro.Cadastros.TCN_CfgEmprestimos.Buscar(cd_empresa.Text,
                                                                             null);
            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    bsCfgEmprestimos.DataSource = lista;
                }
                else
                    if ((vTP_Modo == Utils.TTpModo.tm_Standby) || ((vTP_Modo == Utils.TTpModo.tm_busca)))
                        bsCfgEmprestimos.Clear();
                return lista.Count;
            }
            else
                return 0;
        }

        public override void habilitarControls(bool value)
        {
            pDados.HabilitarControls(value, this.vTP_Modo);
        }

        public override void formatZero()
        {
            this.pDados.set_FormatZero();
        }

        public override void afterNovo()
        {
            if ((vTP_Modo == Utils.TTpModo.tm_busca) || (vTP_Modo == Utils.TTpModo.tm_Standby))
                bsCfgEmprestimos.AddNew();
            base.afterNovo();
            cd_empresa.Focus();
        }

        public override void afterAltera()
        {
            base.afterAltera();
            bb_empresa.Enabled = false;
        }

        public override void afterCancela()
        {
            base.afterCancela();
            if (vTP_Modo == Utils.TTpModo.tm_Insert)
                bsCfgEmprestimos.RemoveCurrent();
        }

        public override void excluirRegistro()
        {
            if (MessageBox.Show("Confirma Exclusão do Registro?", "Mensagem",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                    System.Windows.Forms.DialogResult.Yes)
            {
                try
                {
                    CamadaNegocio.Financeiro.Cadastros.TCN_CfgEmprestimos.Excluir(bsCfgEmprestimos.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CfgEmprestimos, null);
                    pDados.LimparRegistro();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { cd_empresa, nm_empresa }, string.Empty);
        }

        private void cd_empresa_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "'", new Componentes.EditDefault[] { cd_empresa, nm_empresa });
        }

        private void bb_historico_r_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_historico|Historico Operação|200;" +
                              "a.cd_historico|Cd. Historico|80";
            string vParam = "a.Tp_Mov|=|'R'";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_historico_r, ds_historico_r },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadHistorico(), vParam);
        }

        private void cd_historico_r_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_historico|=|'" + cd_historico_r.Text.Trim() + "';" +
                            "a.Tp_Mov|=|'R'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_historico_r, ds_historico_r },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadHistorico());
        }

        private void bb_historico_dev_r_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_historico|Historico Operação|200;" +
                              "a.cd_historico|Cd. Historico|80";
            string vParam = "a.Tp_Mov|=|'P'";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_historico_dev_r, ds_historico_dev_r },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadHistorico(), vParam);
        }

        private void cd_historico_dev_r_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_historico|=|'" + cd_historico_dev_r.Text.Trim() + "';" +
                            "a.Tp_Mov|=|'P'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_historico_dev_r, ds_historico_dev_r },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadHistorico());
        }

        private void bb_centroresult_Click(object sender, EventArgs e)
        {
            using (FormBusca.TFBuscaCentroResult fBusca = new FormBusca.TFBuscaCentroResult())
            {
                fBusca.Tp_registro = "'R'";
                if (fBusca.ShowDialog() == DialogResult.OK)
                    if (!string.IsNullOrEmpty(fBusca.Cd_centro))
                    {
                        cd_centroresult_r.Text = fBusca.Cd_centro;
                        ds_centroresult_r.Text = fBusca.Ds_centro;
                    }
            }
        }

        private void cd_centroresult_r_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_centroresult|=|" + cd_centroresult_r.Text.Trim() + ";" +
                            "isnull(a.st_sintetico, 'N')|<>|'S';" +
                            "a.tp_registro|=|'R'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_centroresult_r, ds_centroresult_r },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CentroResultado());
        }

        private void bb_centroresult_dev_r_Click(object sender, EventArgs e)
        {
            using (FormBusca.TFBuscaCentroResult fBusca = new FormBusca.TFBuscaCentroResult())
            {
                fBusca.Tp_registro = "'D'";
                if (fBusca.ShowDialog() == DialogResult.OK)
                    if (!string.IsNullOrEmpty(fBusca.Cd_centro))
                    {
                        cd_centroresult_dev_r.Text = fBusca.Cd_centro;
                        ds_centroresult_dev_r.Text = fBusca.Ds_centro;
                    }
            }
        }

        private void cd_centroresult_dev_r_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_centroresult|=|" + cd_centroresult_dev_r.Text.Trim() + ";" +
                            "isnull(a.st_sintetico, 'N')|<>|'S';" +
                            "a.tp_registro|=|'D'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_centroresult_dev_r, ds_centroresult_dev_r },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CentroResultado());
        }

        private void bb_historico_c_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_historico|Historico Operação|200;" +
                              "a.cd_historico|Cd. Historico|80";
            string vParam = "a.Tp_Mov|=|'P'";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_historico_c, ds_historico_c },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadHistorico(), vParam);
        }

        private void cd_historico_c_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_historico|=|'" + cd_historico_r.Text.Trim() + "';" +
                            "a.Tp_Mov|=|'P'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_historico_c, ds_historico_c },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadHistorico());
        }

        private void bb_historico_dev_c_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_historico|Historico Operação|200;" +
                              "a.cd_historico|Cd. Historico|80";
            string vParam = "a.Tp_Mov|=|'R'";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_historico_dev_c, ds_historico_dev_c },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadHistorico(), vParam);
        }

        private void cd_historico_dev_c_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_historico|=|'" + cd_historico_dev_c.Text.Trim() + "';" +
                            "a.Tp_Mov|=|'R'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_historico_dev_c, ds_historico_dev_c },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadHistorico());
        }

        private void bb_centroresult_c_Click(object sender, EventArgs e)
        {
            using (FormBusca.TFBuscaCentroResult fBusca = new FormBusca.TFBuscaCentroResult())
            {
                fBusca.Tp_registro = "'D'";
                if (fBusca.ShowDialog() == DialogResult.OK)
                    if (!string.IsNullOrEmpty(fBusca.Cd_centro))
                    {
                        cd_centroresult_c.Text = fBusca.Cd_centro;
                        ds_centroresult_c.Text = fBusca.Ds_centro;
                    }
            }
        }

        private void cd_centroresult_c_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_centroresult|=|" + cd_centroresult_c.Text.Trim() + ";" +
                            "isnull(a.st_sintetico, 'N')|<>|'S';" +
                            "a.tp_registro|=|'D'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_centroresult_c, ds_centroresult_c },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CentroResultado());
        }

        private void bb_centroresult_dev_c_Click(object sender, EventArgs e)
        {
            using (FormBusca.TFBuscaCentroResult fBusca = new FormBusca.TFBuscaCentroResult())
            {
                fBusca.Tp_registro = "'R'";
                if (fBusca.ShowDialog() == DialogResult.OK)
                    if (!string.IsNullOrEmpty(fBusca.Cd_centro))
                    {
                        cd_centroresult_dev_c.Text = fBusca.Cd_centro;
                        ds_centroresult_dev_c.Text = fBusca.Ds_centro;
                    }
            }
        }

        private void cd_centroresult_dev_c_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_centroresult|=|" + cd_centroresult_dev_c.Text.Trim() + ";" +
                            "isnull(a.st_sintetico, 'N')|<>|'S';" +
                            "a.tp_registro|=|'R'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_centroresult_dev_c, ds_centroresult_dev_c },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CentroResultado());
        }
    }
}
