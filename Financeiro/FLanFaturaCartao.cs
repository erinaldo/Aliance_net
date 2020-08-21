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
    public partial class TFLanFaturaCartao : Form
    {
        public CamadaDados.Financeiro.Cartao.TRegistro_FaturaCartao rFatura
        { get { return bsFaturaCartao.Current as CamadaDados.Financeiro.Cartao.TRegistro_FaturaCartao; } }

        public TFLanFaturaCartao()
        {
            InitializeComponent();
            System.Collections.ArrayList cbx1 = new System.Collections.ArrayList();
            cbx1.Add(new Utils.TDataCombo("PAGAR", "P"));
            cbx1.Add(new Utils.TDataCombo("RECEBER", "R"));
            tp_movimento.DataSource = cbx1;
            tp_movimento.DisplayMember = "Display";
            tp_movimento.ValueMember = "Value";
        }

        private void afterGrava()
        {
            if (pDados.validarCampoObrigatorio())
            {
                if (vl_nominal.Focused)
                    (bsFaturaCartao.Current as CamadaDados.Financeiro.Cartao.TRegistro_FaturaCartao).Vl_nominal = vl_nominal.Value;
                if (bsBandeiraCartao.Current == null)
                {
                    MessageBox.Show("Obrigatorio informar bandeira cartão.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                (bsFaturaCartao.Current as CamadaDados.Financeiro.Cartao.TRegistro_FaturaCartao).Id_bandeira =
                    (bsBandeiraCartao.Current as CamadaDados.Financeiro.Cadastros.TRegistro_Cad_BandeiraCartao).ID_Bandeira;
                this.DialogResult = DialogResult.OK;
            }
        }

        private void TFLanFaturaCartao_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pDados.set_FormatZero();
            bsFaturaCartao.AddNew();
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void TFLanFaturaCartao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }

        private void BB_Empresa_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { CD_Empresa }, null);
        }

        private void CD_Empresa_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + CD_Empresa.Text.Trim() + "'", new Componentes.EditDefault[] { CD_Empresa });
        }

        private void bb_contager_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_contager|Conta Gerencial|200;" +
                              "a.cd_contager|Codigo|80";
            string vParam = "a.st_contacartao|=|0;" +
                            "|exists|(select 1 from tb_fin_contager_x_empresa x " +
                            "           where x.cd_contager = a.cd_contager " +
                            "           and x.cd_empresa = '" + CD_Empresa.Text.Trim() + "');" +
                            "|exists|(select 1 from tb_div_usuario_x_contager x " +
                            "           where x.cd_contager = a.cd_contager " +
                            "           and x.login = '" + Utils.Parametros.pubLogin.Trim() + "')";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_contager, ds_contager },
                                            new CamadaDados.Financeiro.Cadastros.TCD_CadContaGer(), vParam);
        }

        private void cd_contager_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_contager|=|'" + cd_contager.Text.Trim() + "';" +
                            "a.st_contacartao|=|0;" +
                            "|exists|(select 1 from tb_fin_contager_x_empresa x " +
                            "           where x.cd_contager = a.cd_contager " +
                            "           and x.cd_empresa = '" + CD_Empresa.Text.Trim() + "');" +
                            "|exists|(select 1 from tb_div_usuario_x_contager x " +
                            "           where x.cd_contager = a.cd_contager " +
                            "           and x.login = '" + Utils.Parametros.pubLogin.Trim() + "')";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_contager, ds_contager },
                                            new CamadaDados.Financeiro.Cadastros.TCD_CadContaGer());
        }

        private void bb_historico_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_Historico|Historico|350;" +
                              "a.CD_Historico|Cód. Historico|100";
            string vParamFixo = "a.tp_mov|=|'R'";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_historico, ds_historico },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadHistorico(), vParamFixo);
        }

        private void cd_historico_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_historico|=|'" + cd_historico.Text.Trim() + "';" +
                                "a.tp_mov|=|'R'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_historico, ds_historico },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadHistorico());
        }

        private void rbDebito_CheckedChanged(object sender, EventArgs e)
        {
            bsBandeiraCartao.DataSource = CamadaNegocio.Financeiro.Cadastros.TCN_Cad_BandeiraCartao.Buscar(string.Empty,
                                                                                                           string.Empty,
                                                                                                           rbDebito.Checked ? "D" : "C",
                                                                                                           0,
                                                                                                           string.Empty,
                                                                                                           null);
        }
    }
}
